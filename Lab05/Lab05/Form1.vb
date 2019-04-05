' **************************************************************************************************************************************************/
' * Lab 5: Text Editor
' * Program: Lab05                     
' * Course: NET DEVELOPMENT I (NETD-2202)                                                                 
' * Author:      Natan Colavite Dellagiustina  - 100722419                                    
' * Date:        April 5th, 2019 
' *                                                                                
' * Description:                                                                    
' *              This program will prompt the user a form application with a text editor, where the user will have the option to either create a new
' *              .txt file, open an already saved .txt file and save/save as the file as .txt. It will also have a menu with the "Edit" tab, which
' *              is going to have the commands to Copy, Paste and Cut the text.
' **************************************************************************************************************************************************/

Option Strict On

Imports System.IO

Public Class frmTextEditor

    Const formName As String = "Text Editor - "

    Private Sub mnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click

        Me.Text = formName & "New"
        txtTextInput.Clear()

    End Sub

    Private Sub mnuOpen_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click

        Me.Text = formName & "Open"
        Dim openFileDialog As New OpenFileDialog
        Dim FilePath As String = String.Empty

        If openFileDialog.ShowDialog() = DialogResult.OK Then

            FilePath = openFileDialog.FileName

            Dim fileReader As New StreamReader(FilePath)
            txtTextInput.Text = fileReader.ReadToEnd()
            fileReader.Close()
        End If
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click

        Me.Text = formName & "About"
        MessageBox.Show("NETD-2202" & vbCrLf & vbCrLf & "Lab # 5" & vbCrLf & vbCrLf & "Natan Colavite Dellagiustina")

    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click

        Me.Text = formName & "Save"
        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "Txt files (*.txt)|*.txt"

        Dim filePath As String = String.Empty

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            filePath = saveFileDialog.FileName
            Save(filePath)
        End If
    End Sub

    Private Sub Save(saveFilePath As String)

        Dim fileStream As New FileStream(saveFilePath, FileMode.Create, FileAccess.Write)
        Dim writeStream As New StreamWriter(fileStream)

        writeStream.Write(txtTextInput.Text)
        writeStream.Close()

    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click

        Me.Text = formName & "Save As"
        Dim saveFileDialog As New SaveFileDialog
        Dim saveFile As String
        saveFileDialog.Filter = "Txt files (*.txt)|*.txt"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then

            saveFile = saveFileDialog.FileName

            Dim streamWriter As New StreamWriter(saveFile)

            streamWriter.Write(txtTextInput.Text)
            streamWriter.Close()
        End If
    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click

        If String.IsNullOrEmpty(txtTextInput.Text.ToString()) Then
        Else
            My.Computer.Clipboard.SetText(txtTextInput.SelectedText)
        End If
    End Sub

    Private Sub mnuCut_Click(sender As Object, e As EventArgs) Handles mnuCut.Click

        If String.IsNullOrEmpty(txtTextInput.Text.ToString()) Then
        Else
            My.Computer.Clipboard.SetText(txtTextInput.SelectedText)
            txtTextInput.SelectedText = ""
        End If
    End Sub

    Private Sub mnuPaste_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click

        txtTextInput.SelectedText() = My.Computer.Clipboard.GetText()

    End Sub

End Class
