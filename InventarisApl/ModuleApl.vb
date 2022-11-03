Imports MySql.Data.MySqlClient

Module ModuleApl
    Public Conn As MySqlConnection
    Public RD As MySqlDataReader
    Public DA As MySqlDataAdapter
    Public CMD As MySqlCommand
    Public DS As DataSet

    Public simpan, ubah, hapus As String

    Public Sub DBconn()
        Dim SqlConn As String
        SqlConn = "server=localhost;Uid=root;Pwd=;Database=dbinventaris;"
        Conn = New MySqlConnection(SqlConn)

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If

    End Sub


End Module


