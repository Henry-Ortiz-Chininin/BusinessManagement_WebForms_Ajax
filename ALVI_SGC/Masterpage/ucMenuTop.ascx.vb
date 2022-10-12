Imports ALVI_Security

Partial Class Security_ucMenuTop
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strIdSeccion As String = Request("IdSeccion")
        If strIdSeccion = "" Then
            strIdSeccion = Session("IdSeccion")
        End If
        Dim tblRow As New TableRow
        Dim tblCell As TableCell

        Dim objMenu As New clsPerfilMenu
        Dim dtbDatos As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 0, 0)
        For Each dtrItem In dtbDatos.Rows
            tblCell = New TableCell
            If strIdSeccion = dtrItem("int_IdMenu") Then
                Session("IdSeccion") = dtrItem("int_IdMenu")
                tblCell.CssClass = "MenuOn"
            Else
                tblCell.CssClass = "MenuOff"
            End If
            tblCell.Text = "<a href='" & dtrItem("var_RutaMenu") & "?IdSeccion=" & dtrItem("int_IdMenu") & "'>" & dtrItem("var_TituloMenu") & "</a>"
            tblRow.Cells.Add(tblCell)
        Next
        tblOpciones.Rows.Add(tblRow)

    End Sub

End Class
