Imports System.Net
Imports System.Text
Imports System.IO


Public Class Form1

    '' All This Is Related  To Bringing The Window To Foreground
    Public Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hwnd As Integer) As Integer
    Public Declare Auto Function FindWindow Lib "user32.dll" (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
    Public Declare Function IsIconic Lib "user32.dll" (ByVal hwnd As Integer) As Boolean
    Public Declare Function ShowWindow Lib "user32.dll" (ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    Public Const SW_RESTORE As Integer = 9
    Public Const SW_SHOW As Integer = 5


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

            CheckBoxAutorun.Checked = True

        Else

            CheckBoxAutorun.Checked = False

        End If

        regKey.Close()

        '' Enable & set button text
        ButtonStartStop.Text = "Start Service"

        '' Check For Autorun & Minimise On Startup
        If CheckBoxAutorun.Checked = True Then

            Me.ButtonStartStop.PerformClick()
            Me.WindowState = FormWindowState.Minimized
            Me.ShowInTaskbar = False

        End If

    End Sub


    Private Sub ButtonStartStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStartStop.Click

        If ButtonStartStop.Text = "Start Service" Then

            '' start backgroundworker process
            If MyBackgroundWorker.IsBusy = False Then

                MyBackgroundWorker.RunWorkerAsync()

            End If

            '' Status Button Coulour
            ButtonRunninStatus.BackColor = Color.Green

            '' Clear HTTP Response
            RichTextBoxHTTPresponse.Clear()

            '' Change Button Function
            ButtonStartStop.Text = "Stop Service"

        ElseIf ButtonStartStop.Text = "Stop Service" Then

            '' cancel bacgroundworker process (sets CancellationPending to True)
            MyBackgroundWorker.CancelAsync()

        End If

    End Sub


    Private Sub MyBackgroundWorker_Login_Loop(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

        '' start infinite loop
        Do
            '' Try & Catch Exeption To Avoid Crashes
            Try

                '' Combo Box Read Selection
                Dim keyAcctype As String = DirectCast(ComboBoxAcctype.SelectedItem, KeyValuePair(Of String, String)).Key
                Dim valueAcctype As String = DirectCast(ComboBoxAcctype.SelectedItem, KeyValuePair(Of String, String)).Value

                If My.Computer.Network.Ping("1.1.1.1") = False Then

                    '' Wait Before Testing Internet Again (May Help Reduce Any False Positives)
                    Threading.Thread.Sleep(500)

                    If My.Computer.Network.Ping("8.8.8.8") = False Then

                        '' Internet Connection Status Indicators
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

                        If CInt(keyAcctype) = 1 Then

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
                                TextBoxLoginCount.Text = CStr(LoginCount)

                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then

                                RichTextBoxHTTPresponse.Text = "Username/Password Error"

                            End If

                        ElseIf CInt(keyAcctype) = 2 Then

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
                                TextBoxLoginCount.Text = CStr(LoginCount)

                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then

                                RichTextBoxHTTPresponse.Text = "Username/Password Error"

                            End If

                        ElseIf CInt(keyAcctype) = 3 Then

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
                                TextBoxLoginCount.Text = CStr(LoginCount)

                            ElseIf thepage.Contains("Please check you have entered your Username/Password correctly") Then

                                RichTextBoxHTTPresponse.Text = "Username/Password Error"

                            End If
                        End If
                    End If

                Else

                    '' Internet Connection Status Indicators
                    ButtonInternetStatus.BackColor = Color.Green
                    NotifyIcon1.Icon = My.Resources.TrayGREEN

                    '' Wait Before Testing Internet Again (May Help Reduce Any False Positives)
                    Threading.Thread.Sleep(1000)

                    If RichTextBoxHTTPresponse.Text = "Ping Error/Not BT Wi-Fi? (DNS)" Then

                        RichTextBoxHTTPresponse.Clear()

                    End If

                    '' Listen For CancelAsync & Exit The Loop
                    If MyBackgroundWorker.CancellationPending = True Then

                        '' cancel bacgroundworker process First To Prevent Issues Running After Closing (sets CancellationPending to True)
                        MyBackgroundWorker.CancelAsync()
                        Exit Do

                    End If

                End If

            Catch ex As Exception  '' This Exeption Cathes Ping Failing & DNS ERRORS

                '' Listen For CancelAsync & Exit The Loop
                If MyBackgroundWorker.CancellationPending = True Then

                    '' cancel bacgroundworker process First To Prevent Issues Running After Closing (sets CancellationPending to True)
                    MyBackgroundWorker.CancelAsync()
                    Exit Do

                End If

                RichTextBoxHTTPresponse.Text = "Ping Error/Not BT Wi-Fi? (DNS)"

                '' Internet Connection Status Indicators
                ButtonInternetStatus.BackColor = Color.Red
                NotifyIcon1.Icon = My.Resources.TrayRED

            End Try

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

            '' Running & Internet Connection Status Indicators
            ButtonRunninStatus.BackColor = Color.Red
            ButtonInternetStatus.BackColor = Color.Red
            NotifyIcon1.Icon = My.Resources.TrayRED

            '' Change Button Function
            ButtonStartStop.Text = "Start Service"

            '' Try & Catch Exeption To Avoid Crashes
        Catch ex As Exception

            '' Error Shows When Unable To Resolve BT Wi-Fi DNS
            RichTextBoxHTTPresponse.Text = "Log Out Error, Not BT Wi-Fi? (DNS) "

            '' Buttom, Running & Internet Connection Status Indicators
            ButtonRunninStatus.BackColor = Color.Red
            ButtonStartStop.Text = "Start Service"
            NotifyIcon1.Icon = My.Resources.TrayRED

        End Try

    End Sub


    '' While closing the program, Handles Minimising On [X]
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        '' Close Disable & Minimise To Tray
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
        Me.ShowInTaskbar = False
        e.Cancel = True

    End Sub


    '' Handle The Double Click (OPEN) Of The System Tray Icon (Add In [DESIGN] page to form)
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

        If Me.WindowState = FormWindowState.Minimized Then

            Me.Show()
            FocusWindow("BT Wi-Fi Autologin Service", Nothing)
            Me.ShowInTaskbar = True

        Else

            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.ShowInTaskbar = False

        End If

    End Sub


    '' Handle Context Menu Exit (Right CLick System Tray > Exit)
    Private Sub ContextExit_Click(sender As Object, e As EventArgs) Handles contextExit.Click

        '' cancel bacgroundworker process First To Prevent Issues Running After Closing (sets CancellationPending to True)
        MyBackgroundWorker.CancelAsync()
        Application.ExitThread()

    End Sub


    '' Handle Context Menu Open (Right CLick System Tray > Open)
    Private Sub ContextOpen_Click(sender As Object, e As EventArgs) Handles contextOpen.Click

        FocusWindow("BT Wi-Fi Autologin Service", Nothing)
        Me.ShowInTaskbar = True

    End Sub


    '' Brings This Window To Front Focus With Context Menu Open (Right CLick System Tray > Open) - Call By Using: FocusWindow("BT Wi-Fi Autologin Service", Nothing)
    Private Sub FocusWindow(ByVal strWindowCaption As String, ByVal strClassName As String)

        Dim hWnd As Integer
        hWnd = FindWindow(strClassName, strWindowCaption)

        If hWnd > 0 Then

            SetForegroundWindow(hWnd)

            If IsIconic(hWnd) Then

                ShowWindow(hWnd, SW_RESTORE)

            Else

                ShowWindow(hWnd, SW_SHOW)

            End If
        End If

    End Sub


    '' Saves The Dropdown Option As Soon As Chosen (To Ensure Savimg From Exit, Shutdown & Restart)
    Private Sub ComboBoxAcctype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAcctype.DropDownClosed

        My.Settings.saveAccType = ComboBoxAcctype.SelectedIndex
        My.Settings.Save()

    End Sub


    '' Saves The Email Text As Soon As User Types (To Ensure Savimg From Exit, Shutdown & Restart)
    Private Sub TextBoxEmail_TextChanged(sender As Object, e As EventArgs) Handles TextBoxEmail.TextChanged

        My.Settings.saveEmail = TextBoxEmail.Text
        My.Settings.Save()

    End Sub


    '' Saves The Password Text As Soon As User Types (To Ensure Savimg From Exit, Shutdown & Restart)
    Private Sub TextBoxPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPassword.TextChanged

        My.Settings.savePassword = TextBoxPassword.Text
        My.Settings.Save()

    End Sub


    '' Saves The Login Count As Soon As It Gets Updated (To Ensure Savimg From Exit, Shutdown & Restart)
    Private Sub TextBoxLoginCount_TextChanged(sender As Object, e As EventArgs) Handles TextBoxLoginCount.TextChanged

        My.Settings.SaveLoginCount = TextBoxLoginCount.Text
        My.Settings.Save()

    End Sub


    '' Saves The Autorun Status & Add/Remove Reg Key As Soon As It Gets Updated (To Ensure Savimg From Exit, Shutdown & Restart)
    Private Sub CheckboxAutorun_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAutorun.CheckedChanged

        'Set Or Remove registry key to Autorun application if checkbox is checked
        If CheckBoxAutorun.Checked Then

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


    '' Handle Login Count Reset Button
    Private Sub ButtonResetLogincount_Click(sender As Object, e As EventArgs) Handles ButtonResetLogincount.Click

        Dim ask As MsgBoxResult = MsgBox("Really Delete Login Count Data? (Irriversable)", MsgBoxStyle.YesNo)

        If ask = MsgBoxResult.Yes Then

            TextBoxLoginCount.Text = CStr(0)

        End If

    End Sub


    '' Handle Map Opening
    Private Sub LinkLabelMap_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelMap.LinkClicked

        Dim ask As MsgBoxResult = MsgBox("Open BT Wi-Fi Map?", MsgBoxStyle.YesNo)

        If ask = MsgBoxResult.Yes Then
            '' Try & Catch Exeption To Avoid Crashes
            Try

                Dim url As String = “https://info.btwifi.com:442/find/“
                Process.Start(url)

            Catch ex As Exception

                MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")

            End Try
        End If

    End Sub


    '' Handle About Box Open On "By: Aidan Macgregor Label"
    Private Sub LinkLabelAidanMacgregor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAidanMacgregor.LinkClicked

        AboutBox1.Show()

    End Sub


    '' About Box Button Open More Info
    Private Sub ButtonAbout_Click(sender As Object, e As EventArgs) Handles ButtonAbout.Click

        AboutBox1.Show()

    End Sub



End Class

