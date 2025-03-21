Imports System.IO

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Display a confirmation dialog
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the directories?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        ' Check the user's response
        If result = DialogResult.Yes Then
            ' Specify the parent directory path
            Dim parentDirectory As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            ' Specify the keywords to check for in directory names
            Dim keywords As String() = {"EE_WiFi", "BT_Wi-Fi", "BT_WiFi"}
            ' Get all subdirectories in the parent directory
            Dim subdirectories As String() = Directory.GetDirectories(parentDirectory)
            ' Iterate through each subdirectory
            For Each subdirectory In subdirectories
                ' Check if the subdirectory contains any of the specified keywords
                If keywords.Any(Function(keyword) subdirectory.Contains(keyword)) Then
                    ' Delete the directory
                    Try
                        Directory.Delete(subdirectory, True) ' Set the second parameter to True to delete recursively
                        MessageBox.Show($"Deleted directory: {subdirectory}")
                    Catch ex As Exception
                        ' Handle the exception (e.g., directory in use, access denied)
                        MessageBox.Show($"Error deleting directory {subdirectory}: {ex.Message}")
                    End Try
                End If
            Next
            Environment.Exit(0)
        End If
    End Sub

    Private Sub ButtonHotspot_Click(sender As Object, e As EventArgs) Handles ButtonHotspot.Click
        Try
            ' Open WiFi settings using the process start
            Process.Start("ms-settings:network-mobilehotspot")
        Catch ex As Exception
            ' Handle any exceptions that may occur
            MessageBox.Show("Error opening WiFi Hotspot settings: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ' Open the Network & Internet settings
            Process.Start("ms-settings:network")

            ' If you want to navigate directly to the "Change adapter options" section (where network connections are listed), you can use:
            ' Process.Start("ms-settings:network-ethernet")

        Catch ex As Exception
            ' Handle any exceptions that may occur
            MessageBox.Show("Error opening Network & Internet settings: " & ex.Message)
        End Try
    End Sub
End Class