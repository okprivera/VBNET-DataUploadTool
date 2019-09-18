Imports System.Data.SqlClient

Module modPractical
    Public cmd As New SqlCommand
    'Public connStr As String = "Data Source=localhost;Initial Catalog=PracticalTest;Persist Security Info=True;User ID=sa;Password=sa"
    Public connStr As String = "Data Source=localhost;Initial Catalog=PracticalTest;Persist Security Info=True;Integrated Security=SSPI"
    Public conn As New SqlConnection(connStr)

    Public Function LoadConnection()
        conn.Open()

        If conn.State = 0 Then
            MsgBox(UCase("Please check your DB connection. Press OK to exit."), vbCritical, "ezyVet Practical - Oscar Kenneth Rivera")
            Application.Exit()
        End If
    End Function
    Public Function changeDelimiter(line As String) As String
        Dim regEx As Object = CreateObject("VBScript.regexp")
        regEx.IgnoreCase = True
        regEx.Global = True
        regEx.Pattern = ",(?=([^" & Chr(34) & "]*" & Chr(34) & "[^" & Chr(34) & "]*" & Chr(34) & ")*(?![^" & Chr(34) & "]*" & Chr(34) & "))"

        changeDelimiter = regEx.Replace(line, "#|#")
    End Function
    Public Sub vbsSetFocus(prmStr As Object, prmCtrl As Control)
        'enable control
        On Error Resume Next
        prmStr.SelectAll()
        prmCtrl.BackColor = Color.LightGreen
    End Sub
End Module
