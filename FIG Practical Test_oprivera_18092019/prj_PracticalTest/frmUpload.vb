Imports System.IO

Public Class frmUpload
    Dim txt As String
    Private Sub FrmUpload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUploadTxt.Text = "CLICK BROWSE BUTTON TO START"
        txtFileName.Text = ""

        If txtFileName.Text = "" Then
            cmdUpload.Enabled = False
        End If
    End Sub

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Dispose()
        frmMain.Show()
    End Sub

    Private Sub CmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Open File Dialog"
        fd.InitialDirectory = Application.StartupPath
        fd.Filter = "All .csv|*.csv"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            txtFileName.Text = fd.FileName
            txt = txtFileName.Text
            cmdUpload.Enabled = True
        End If

        If txt <> "" Then
            lblUploadTxt.Text = "CLICK UPLOAD"
        End If
    End Sub

    Private Sub CmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click
        Dim tmpFirstname, tmpLastname, tmpCompanyName, tmpAddress, tmpCity, tmpState, tmpPost, tmpPhone1, tmpPhone2, tmpEmail, tmpWeb
        Dim cnt As Integer
        Dim rec_cnt As Integer = 0
        Dim maxcnt = File.ReadAllLines(txt).Length
        Dim arr() As String

        Try

            prgBar.Maximum = maxcnt

            For Each line As String In File.ReadLines(txt)
                line = Replace(Trim(line), "'", "`")

                If line.Contains("first_name,last_name") Then
                    GoTo nxtline
                End If

                arr = Split(changeDelimiter(line), "#|#")

                tmpFirstname = arr(0)
                tmpLastname = arr(1)
                tmpCompanyName = Replace(Trim(arr(2)), """", "")
                tmpAddress = arr(3)
                tmpCity = arr(4)
                tmpState = arr(5)
                tmpPost = arr(6)
                tmpPhone1 = arr(7)
                tmpPhone2 = arr(8)
                tmpEmail = arr(9)
                tmpWeb = arr(10)

                cmd.Connection = conn 'ESTABLISH CONNECTION TO SQL
                rec_cnt = rec_cnt + 1 'SUCCESSFUL VALIDATION COUNT AND ACT AS CONTACT ID

                'DATA INSERTION USING BACKEND STORED PROC
                cmd.Connection = conn
                cmd.CommandText = "EXEC SP_INSERTDATA '" & tmpFirstname & "','" & tmpLastname & "','" & tmpCompanyName & "','" & tmpAddress & "','" & tmpCity & "','" & tmpState & "','" & tmpPost & "','" & tmpPhone1 & "','" & tmpPhone2 & "','" & tmpEmail & "','" & tmpWeb & "'"
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                GoTo nxtline
nxtline:
                cnt = cnt + 1
                prgBar.Value = cnt
                lblUploadTxt.Text = "SUCCESSFULLY UPLOADED " & rec_cnt & " OF " & maxcnt
            Next line

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class