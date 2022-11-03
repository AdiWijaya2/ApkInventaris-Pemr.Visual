Imports MySql.Data.MySqlClient

Public Class formBarang

    Sub isiGrid()
        Call DBconn()
        DA = New MySqlDataAdapter("Select * From tabel_barang", Conn)
        DS = New DataSet
        DA.Fill(DS, "tabel_barang")
        DataGridView1.DataSource = DS.Tables("tabel_barang")
        DataGridView1.ReadOnly = True

    End Sub


    Sub bersih()
        txtHarga.Clear()
        txtStok.Clear()
        txtKode.Clear()
        txtNama.Clear()
        btnTambah.Text = "Tambah"
    End Sub

    Sub isiCb()
        Call DBconn()
        CMD = New MySqlCommand("Select kode_barang From tabel_barang", Conn)
        RD = CMD.ExecuteReader
        cbBarang.Items.Clear()
        Do While RD.Read
            cbBarang.Items.Add(RD.Item(0))
        Loop
        CMD.Dispose()
        RD.Close()
        Conn.Close()
    End Sub


    Private Sub formBarang_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call DBconn()
        Call isiGrid()
        Call isiCb()

    End Sub

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        If btnTambah.Text = "Tambah" Then
            btnTambah.Text = "Simpan"
            txtKode.Focus()
        Else
            Try
                Call DBconn()
                CMD = New MySqlCommand("Select kode_barang From tabel_barang where kode_barang = '" & txtKode.Text & "'", Conn)
                RD = CMD.ExecuteReader
                RD.Read()
                If RD.HasRows Then
                    MsgBox("Data barang tersebut telah terdaftar", MsgBoxStyle.Exclamation, "Peringatan")
                Else
                    Call DBconn()
                    simpan = "INSERT INTO tabel_barang VALUES (?,?,?,?)"
                    CMD = Conn.CreateCommand
                    With CMD
                        .CommandText = simpan
                        .Connection = Conn
                        .Parameters.Add("p1", MySqlDbType.String, 8).Value = txtKode.Text
                        .Parameters.Add("p2", MySqlDbType.String, 30).Value = txtNama.Text
                        .Parameters.Add("p3", MySqlDbType.Int32, 8).Value = txtHarga.Text
                        .Parameters.Add("p4", MySqlDbType.Int32, 4).Value = txtStok.Text
                        .ExecuteNonQuery()
                    End With
                    Call isiGrid()
                    Call bersih()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
            End Try
        End If
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        Call bersih()
    End Sub

End Class
