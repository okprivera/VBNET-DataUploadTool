Public Class frmMain
    Private Sub UploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadToolStripMenuItem.Click
        Me.Hide()
        frmUpload.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        conn.Close()
        Me.Dispose()
    End Sub

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadConnection()
    End Sub

    Private Sub GenerateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerateToolStripMenuItem.Click
        Me.Hide()
        frmGenerate.Show()
    End Sub
End Class