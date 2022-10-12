Imports ALVI_Security

Partial Class Security_ucMenuLeft
    Inherits System.Web.UI.UserControl

    Protected Sub tblMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblMenu.Load

        If Not IsPostBack Then
            IdSeccion.Value = Request("IdSeccion")
            If IdSeccion.Value = "" Then
                IdSeccion.Value = "0"
            End If
            IdMenu.Value = Request("IdMenu")
            If IdMenu.Value = "" Then
                IdMenu.Value = "0"
            End If
            IdSubMenu.Value = Request("IdSubMenu")
            If IdSubMenu.Value = "" Then
                IdSubMenu.Value = 0
            End If
            Construir()
        Else
            Construir()
        End If

    End Sub
    Private Sub Construir()

        Dim tblRow As TableRow
        Dim tblCell As TableCell

        Session("IdSeccion") = IdSeccion.Value
        Session("IdMenu") = IdMenu.Value
        Session("IdSubMenu") = IdSubMenu.Value

        Dim strURL As String = Request.Url.AbsolutePath

        Dim objMenu As New clsPerfilMenu
        Dim dtbDatos As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 1, IdSeccion.Value)
        For Each dtrItem In dtbDatos.Rows
            tblRow = New TableRow
            tblCell = New TableCell
            If IdMenu.Value.ToString = dtrItem("int_IdMenu").ToString Then
                tblCell.CssClass = "MenuOn"
            Else
                tblCell.CssClass = "MenuOff"
            End If

            If dtrItem("var_RutaMenu") <> "" Then
                tblCell.Text = "<a href='" & dtrItem("var_RutaMenu") & "?IdSeccion=" & IdSeccion.Value & _
                                            "&IdMenu=" & dtrItem("int_IdMenu") & "'>" & dtrItem("var_TituloMenu") & "</a>"
                tblRow.Cells.Add(tblCell)
                tblMenu.Rows.Add(tblRow)
            Else
                tblCell.Text = dtrItem("var_TituloMenu")
                tblRow.Cells.Add(tblCell)
                tblMenu.Rows.Add(tblRow)
            End If

            Dim objSubMenu As New clsPerfilMenu
            Dim dtbSubDatos As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 2, dtrItem("int_IdMenu"))
            For Each dtrSubItem In dtbSubDatos.Rows
                tblRow = New TableRow
                tblCell = New TableCell
                If IdSubMenu.Value.ToString = dtrSubItem("int_IdMenu").ToString Then
                    tblCell.CssClass = "MenuItemOn"
                Else
                    tblCell.CssClass = "MenuItemOff"
                End If

                tblCell.Text = "<a href='" & dtrSubItem("var_RutaMenu") & "?IdSeccion=" & Request("IdSeccion") & _
                "&IdMenu=" & dtrItem("int_IdMenu") & _
                "&IdSubMenu=" & dtrSubItem("int_IdMenu") & "'>" & dtrSubItem("var_TituloMenu") & "</a>"
                tblRow.Cells.Add(tblCell)
                tblMenu.Rows.Add(tblRow)
            Next
        Next
    End Sub
End Class
