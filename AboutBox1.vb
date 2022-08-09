Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Close()

    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonDonate.Click

        Try
            Dim url As String = “https://www.buymeacoffee.com/aidanmacgregor“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
        End Try

    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonOtherStuff.Click

        Try
            Dim url As String = “https://linktr.ee/aidanmacgregor“
            Process.Start(url)
        Catch ex As Exception
            MessageBox.Show("BT Wi-Fi Autologin Service --ERROR OPENING BROWSER--")
        End Try

    End Sub



End Class
