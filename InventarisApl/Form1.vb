Public Class Form1

    Private Sub FormBarangToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormBarangToolStripMenuItem1.Click
        formBarang.StartPosition = FormStartPosition.CenterScreen
        formBarang.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class