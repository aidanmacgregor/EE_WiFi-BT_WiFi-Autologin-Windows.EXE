Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

        Try
            Dim url As String = “https://github.com/aidanmacgregor/“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
        End Try

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Try
            Dim url As String = “https://www.youtube.com/c/AidanMacgregor“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
        End Try

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

        Try
            Dim url As String = “https://www.facebook.com/aidanmacgregorATV“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
        End Try

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked

        Try
            Dim url As String = “https://t.me/aidansromhelp“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
        End Try

    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked

        Try
            Dim url As String = “https://linktr.ee/aidanmacgregor“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim url As String = “https://www.buymeacoffee.com/aidanmacgregor“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
        End Try

    End Sub
End Class
