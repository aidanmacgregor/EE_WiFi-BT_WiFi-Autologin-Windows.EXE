Imports System.Net
Imports System.Text
Imports System.IO


Public Class Form1

    '' set application name and application path variables (Part Of AutoRun)
    Private ReadOnly applicationName As String = Application.ProductName
    Private ReadOnly applicationPath As String = Application.ExecutablePath

    '' Global Cookie For Login & Logout
    Dim logincookie As CookieContainer

    '' Login Counter Variable
    Dim LoginCount As Integer

    '' set new backgroundworker
    Private ReadOnly MyBackgroundWorker As New System.ComponentModel.BackgroundWorker


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '' Hide Crossthreading Error
        CheckForIllegalCrossThreadCalls = False

        '' Icon & Lights
        NotifyIcon1.Visible = True
        NotifyIcon1.Icon = My.Resources.TrayRED
        ButtonRunninStatus.BackColor = Color.Red

        '' ComboBox Options
        Dim comboSource As New Dictionary(Of String, String) From {
            {"1", "BT Home Broadband"},
            {"2", "BT Buisness Broadband"},
            {"3", "BT Wi-Fi"}
        }
        ComboBoxAcctype.DataSource = New BindingSource(comboSource, Nothing)
        ComboBoxAcctype.DisplayMember = "Value"
        ComboBoxAcctype.ValueMember = "Key"

        '' Load ComboBox Previous Settings (System - Settings - Integer)
        ComboBoxAcctype.SelectedIndex = My.Settings.saveAccType

        '' add the following to the form load event to Check Value Of AutoRun (Regisery Key) & Update CheckBox
        Dim regKey As Microsoft.Win32.RegistryKey
        regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

        '' set backgroundworker settings
        MyBackgroundWorker.WorkerSupportsCancellation = True
        MyBackgroundWorker.WorkerReportsProgress = True
        AddHandler MyBackgroundWorker.DoWork, AddressOf MyBackgroundWorker_Login_Loop
        AddHandler MyBackgroundWorker.RunWorkerCompleted, AddressOf MyBackgroundWorker_Completed

        '' Check For AutoRun Registery Key, Mark Checkbox & Start Service if key is present
        If CStr(regKey.GetValue(applicationName)) = """" & applicationPath & """" Then
            checkboxAutorun.Checked = True
        Else
            checkboxAutorun.Checked = False
        End If
        regKey.Close()

        '' Enable & set button text
        ButtonStartStop.Text = "Start Service"

        '' Check For Autorun & Minimise On Startup
        If checkboxAutorun.Checked = True Then
            Me.ButtonStartStop.PerformClick()
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False
        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStartStop.Click

        If ButtonStartStop.Text = "Start Service" Then

            '' Sleep To Ensure Enough Time For Thread To Initalise Before Stopping (Dont Know If Nesicerry But Seems Like Good Idea)
            Threading.Thread.Sleep(1000)

            '' Change Button Function
            ButtonStartStop.Text = "Stop Service"

            '' Status Button Coulour
            ButtonRunninStatus.BackColor = Color.Green

            '' Clear HTTP Response
            RichTextBoxHTTPresponse.Clear()

            '' start backgroundworker process
            If MyBackgroundWorker.IsBusy = False Then
                MyBackgroundWorker.RunWorkerAsync()
            End If

        ElseIf ButtonStartStop.Text = "Stop Service" Then

            '' Sleep To Ensure Enough Time For Thread To Initalise Before Stopping (Dont Know If Nesicerry But Seems Like Good Idea)
            Threading.Thread.Sleep(1000)

            '' cancel bacgroundworker process (sets CancellationPending to True)
            MyBackgroundWorker.CancelAsync()

        End If

    End Sub


    Private Sub MyBackgroundWorker_Login_Loop(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        '' Label To Loop Back To On Exeption
ErrorLoop:

        '' start infinite loop
        Do

            Try

                '' Combo Box Read Selection
                Dim keyAcctype As String = DirectCast(ComboBoxAcctype.SelectedItem, KeyValuePair(Of String, String)).Key
                Dim valueAcctype As String = DirectCast(ComboBoxAcctype.SelectedItem, KeyValuePair(Of String, String)).Value

                If My.Computer.Network.Ping("1.1.1.1") = False Then

                    '' Wait Before Testing Internet Again (May Help Reduce Any False Positives)
                    Threading.Thread.Sleep(500)

                    If My.Computer.Network.Ping("8.8.8.8") = False Then

                        '' Internet Status "LED"
                        ButtonInternetStatus.BackColor = Color.Red
                        NotifyIcon1.Icon = My.Resources.TrayRED

                        '' Clear HTTP Request
                        RichTextBoxHTTPresponse.Clear()

                        '' Post Data String
                        Dim postData As String = $"username={TextBoxEmail.Text}&password={TextBoxPassword.Text}"

                        '' Post Data Settings
                        Dim tempCookies As New CookieContainer
                        Dim encoding As New UTF8Encoding
                        Dim byteData As Byte() = encoding.GetBytes(postData)

                        If keyAcctype = 1 Then

                            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://btwifi.com:8443/tbbLogon"), HttpWebRequest)
                            postReq.Method = "POST"
                            postReq.KeepAlive = False
                            postReq.CookieContainer = tempCookies
                            postReq.ContentType = "application/x-www-form-urlencoded"
                            postReq.Referer = "https://google.com"
                            postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; RV:26.0) Gecko/20100101 Firefox/26.0"
                            postReq.ContentLength = byteData.Length

                            Dim postreqstream As Stream = postReq.GetRequestStream()
                            postreqstream.Write(byteData, 0, byteData.Length)
                            postreqstream.Close()
                            Dim postresponse As HttpWebResponse
                            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                            tempCookies.Add(postresponse.Cookies)
                            logincookie = tempCookies
                            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
                            Dim thepage As String = postreqreader.ReadToEnd

                            '' Temporary Write Response To Rich Text Box
                            RichTextBoxHTTPresponse.Text = thepage

                            '' Check Rich Text Box & Replace Withe Useful Message
                            If thepage.Contains("You&#8217;re now logged on to BT Wi-Fi") Then
                                RichTextBoxHTTPresponse.Text = ("Logged In Sucsesfully " & TimeString)
                                LoginCount = Integer.Parse(TextBoxLoginCount.Text)
                                LoginCount += 1
                                TextBoxLoginCount.Text = LoginCount
                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then
                                RichTextBoxHTTPresponse.Text = "Username/Password Error"
                            End If

                        ElseIf keyAcctype = 2 Then

                            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://www.btwifi.com:8443/ante?partnerNetwork=btb"), HttpWebRequest)
                            postReq.Method = "POST"
                            postReq.KeepAlive = False
                            postReq.CookieContainer = tempCookies
                            postReq.ContentType = "application/x-www-form-urlencoded"
                            postReq.Referer = "https://google.com"
                            postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; RV:26.0) Gecko/20100101 Firefox/26.0"
                            postReq.ContentLength = byteData.Length

                            Dim postreqstream As Stream = postReq.GetRequestStream()
                            postreqstream.Write(byteData, 0, byteData.Length)
                            postreqstream.Close()
                            Dim postresponse As HttpWebResponse
                            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                            tempCookies.Add(postresponse.Cookies)
                            logincookie = tempCookies
                            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
                            Dim thepage As String = postreqreader.ReadToEnd

                            '' Temporary Write Response To Rich Text Box
                            RichTextBoxHTTPresponse.Text = thepage

                            '' Check Rich Text Box & Replace Withe Useful Message
                            If thepage.Contains("You&#8217;re now logged on to BT Wi-Fi") Then
                                RichTextBoxHTTPresponse.Text = ("Logged In Sucsesfully " & TimeString)
                                LoginCount = Integer.Parse(TextBoxLoginCount.Text)
                                LoginCount += 1
                                TextBoxLoginCount.Text = LoginCount
                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then
                                RichTextBoxHTTPresponse.Text = "Username/Password Error"
                            End If

                        ElseIf keyAcctype = 3 Then

                            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://www.btwifi.com:8443/ante"), HttpWebRequest)
                            postReq.Method = "POST"
                            postReq.KeepAlive = False
                            postReq.CookieContainer = tempCookies
                            postReq.ContentType = "application/x-www-form-urlencoded"
                            postReq.Referer = "https://google.com"
                            postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; RV:26.0) Gecko/20100101 Firefox/26.0"
                            postReq.ContentLength = byteData.Length

                            Dim postreqstream As Stream = postReq.GetRequestStream()
                            postreqstream.Write(byteData, 0, byteData.Length)
                            postreqstream.Close()
                            Dim postresponse As HttpWebResponse
                            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                            tempCookies.Add(postresponse.Cookies)
                            logincookie = tempCookies
                            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
                            Dim thepage As String = postreqreader.ReadToEnd

                            '' Temporary Write Response To Rich Text Box
                            RichTextBoxHTTPresponse.Text = thepage

                            '' Check Rich Text Box & Replace Withe Useful Message
                            If thepage.Contains("You&#8217;re now logged on to BT Wi-Fi") Then
                                RichTextBoxHTTPresponse.Text = ("Logged In Sucsesfully " & TimeString)
                                LoginCount = Integer.Parse(TextBoxLoginCount.Text)
                                LoginCount += 1
                                TextBoxLoginCount.Text = LoginCount
                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then
                                RichTextBoxHTTPresponse.Text = "Username/Password Error"
                            End If

                        End If
                    End If
                Else
                    ''Green Internet Status If Ping Sucsessful
                    ButtonInternetStatus.BackColor = Color.Green
                    NotifyIcon1.Icon = My.Resources.TrayGREEN
                End If

            Catch ex As Exception  '' This Exeption Cathes Ping Failing & DNS ERRORS

                '' Listen For CancelAsync & Exit The Loop
                If MyBackgroundWorker.CancellationPending = True Then
                    Exit Do
                End If

                '' Internet Connection Fail Status Light
                ButtonInternetStatus.BackColor = Color.Red
                NotifyIcon1.Icon = My.Resources.TrayRED

                '' Change info Label
                RichTextBoxHTTPresponse.Text = "No BT Wi-Fi Connection"

                '' Wait Before Testing Internet Again To Not Flood Server With Requests
                Threading.Thread.Sleep(1000)

                RichTextBoxHTTPresponse.Clear()

                '' Loop Attemps To Login Instead Of Exeption & Crash
                GoTo ErrorLoop

            End Try

            '' Listen For Do Loop Exit
            If MyBackgroundWorker.CancellationPending = True Then

                Exit Do

            End If

            '' Wait Before Testing Internet Again To Not Flood Server With Requests
            Threading.Thread.Sleep(1000)

        Loop

    End Sub


    Private Sub MyBackgroundWorker_Completed(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)

        RichTextBoxHTTPresponse.Clear()

        '' Try & Catch Exeption To Avoid Crashes
        Try

            Dim postData As String = ""
            Dim tempCookies As New CookieContainer
            Dim encoding As New UTF8Encoding
            Dim byteData As Byte() = encoding.GetBytes(postData)

            Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://btwifi.com:8443/accountLogoff/home?confirmed=true"), HttpWebRequest)
            postReq.Method = "POST"
            postReq.KeepAlive = False
            postReq.CookieContainer = tempCookies
            postReq.ContentType = "application/x-www-form-urlencoded"
            postReq.Referer = "https://google.com"
            postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; RV:26.0) Gecko/20100101 Firefox/26.0"
            postReq.ContentLength = byteData.Length

            Dim postreqstream As Stream = postReq.GetRequestStream()
            postreqstream.Write(byteData, 0, byteData.Length)
            postreqstream.Close()
            Dim postresponse As HttpWebResponse
            postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
            tempCookies.Add(postresponse.Cookies)
            logincookie = tempCookies
            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
            Dim thepage As String = postreqreader.ReadToEnd

            '' Temporary Write Response To Rich Text Box
            RichTextBoxHTTPresponse.Text = thepage

            '' Check Rich Text Box & Replace Withe Useful Message
            If thepage.Contains("landing.htm") Then
                RichTextBoxHTTPresponse.Text = "Logged Out"
            End If

            '' Status "Lights"
            ButtonRunninStatus.BackColor = Color.Red
            ButtonInternetStatus.BackColor = Color.Red
            NotifyIcon1.Icon = My.Resources.TrayRED

            '' Change Button Function
            ButtonStartStop.Text = "Start Service"

            '' Try & Catch Exeption To Avoid Crashes
        Catch ex As Exception

            '' Error Shows When Unable To Resolve BT Wi-Fi DNS
            RichTextBoxHTTPresponse.Text = "Error Logging Out"

            ''cancel bacgroundworker process (sets CancellationPending to True)
            MyBackgroundWorker.CancelAsync()

            '' Change Button Function & "Lights"
            ButtonRunninStatus.BackColor = Color.Red
            ButtonStartStop.Text = "Start Service"
            NotifyIcon1.Icon = My.Resources.TrayRED

        End Try

    End Sub


    '' Handle Login Count Reset Button
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles ButtonResetLogincount.Click

        Dim ask As MsgBoxResult = MsgBox("Really Delete Login Count Data? (Irriversable)", MsgBoxStyle.YesNo)

        If ask = MsgBoxResult.Yes Then
            TextBoxLoginCount.Text = 0
        End If

    End Sub


    '' Handle Map Opening
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

        Dim ask As MsgBoxResult = MsgBox("Open BT Wi-Fi Map?", MsgBoxStyle.YesNo)
        If ask = MsgBoxResult.Yes Then
            Try
                Dim url As String = “https://info.btwifi.com:442/find/“
                Process.Start(url)
            Catch ex As Exception
                MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
            End Try
        End If

    End Sub


    '' Handle Version & Website Opening
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        AboutBox1.Show()

    End Sub


    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles ButtonAbout.Click

        AboutBox1.Show()

    End Sub


    '' While closing the program, Handles Minimising On [X]
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        '' Close Disable & Minimise To Tray
        Me.WindowState = FormWindowState.Minimized
        e.Cancel = True

    End Sub


    '' Handle The Minimize To Tray Function
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = False
        End If

    End Sub


    '' Handle The Double Click (OPEN) Of The System Tray Icon (Add In [DESIGN] page to form)
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal

    End Sub


    '' Handle Context Menu Open (Right CLick System Tray > Open)
    Private Sub ContextOpen_Click(sender As Object, e As EventArgs) Handles contextOpen.Click

        Me.Visible = True
        Me.WindowState = FormWindowState.Normal

    End Sub


    '' Handle Context Menu Exit (Right CLick System Tray > Exit)
    Private Sub ContextExit_Click(sender As Object, e As EventArgs) Handles contextExit.Click

        Application.ExitThread()

    End Sub


    Private Sub ComboBoxAcctype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAcctype.DropDownClosed

        My.Settings.saveAccType = ComboBoxAcctype.SelectedIndex
        My.Settings.Save()

    End Sub


    Private Sub TextBoxEmail_TextChanged(sender As Object, e As EventArgs) Handles TextBoxEmail.TextChanged

        My.Settings.saveEmail = TextBoxEmail.Text
        My.Settings.Save()

    End Sub


    Private Sub TextBoxPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPassword.TextChanged

        My.Settings.savePassword = TextBoxPassword.Text
        My.Settings.Save()

    End Sub


    Private Sub TextBoxLoginCount_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLoginCount.TextChanged

        My.Settings.SaveLoginCount = TextBoxLoginCount.Text
        My.Settings.Save()

    End Sub


    Private Sub checkboxAutorun_CheckedChanged(sender As Object, e As EventArgs) Handles checkboxAutorun.CheckedChanged

        'Set Or Remove registry key to Autorun application if checkbox is checked
        If checkboxAutorun.Checked Then
            Dim regKey As Microsoft.Win32.RegistryKey
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.SetValue(applicationName, """" & applicationPath & """")
            regKey.Close()
        Else
            Dim regKey As Microsoft.Win32.RegistryKey
            regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.DeleteValue(applicationName, False)
            regKey.Close()
        End If

    End Sub


End Class

