Imports System.Data.SqlClient

Public Class frmGenerate
    Private Sub FrmGenerate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtSearch.Select()
    End Sub

    Private Sub frmGenerate_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
        frmMain.Show()
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'Dim strQuery As String
        Dim table As New DataTable()
        Dim tmpSRCH As String

        Try
            tmpSRCH = txtSearch.Text

            DataGridView1.DataSource = Nothing
            DataGridView1.Refresh()

            cmd.Connection = conn
            cmd.CommandTimeout = 300
            cmd.CommandText = "EXEC SP_SEARCH '" & tmpSRCH & "'"

            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(table)

            DataGridView1.DataSource = table
            DataGridView1.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        vbsSetFocus(txtSearch, txtSearch)
    End Sub
    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Asc(e.KeyChar) = 39 Then
            e.Handled = True
        End If
    End Sub
End Class