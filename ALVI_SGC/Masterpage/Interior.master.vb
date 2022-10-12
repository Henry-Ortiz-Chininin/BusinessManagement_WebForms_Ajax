Imports ALVI_Security

Partial Class MASTER_Interior
    Inherits System.Web.UI.MasterPage


    Private Sub Construir()
        Dim strURL As String = Request.Url.AbsolutePath
        'If hdnIdSeccion.Value = "" Then
        '    Exit Sub
        'End If

        Dim objMenu As New clsPerfilMenu
        Dim objSeguridad As New ALVI_Security.General

        Dim dtbSistemas As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 0, 0)

        If dtbSistemas.Rows.Count = 0 Then
            Exit Sub
        End If

        litMenu.Text = "<ul>"
        'NIVEL 0
        Dim i As Integer = 0
        For Each dtrSistema In dtbSistemas.Rows
            litMenu.Text = litMenu.Text & "<li "
            litMenu.Text = litMenu.Text & " class='MenuOn' >"
            litMenu.Text = litMenu.Text & "<a href='#'>" & dtrSistema("var_TituloMenu") & "</a>"

            'NIVEL 1
            Dim dtbDatos As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 1, dtrSistema("int_IDMenu"))
            litMenu.Text = litMenu.Text & "<ul>"
            For Each dtrItem In dtbDatos.Rows
                litMenu.Text = litMenu.Text & "<li "
                litMenu.Text = litMenu.Text & " class='MenuOff' >"
                
                If dtrItem("var_RutaMenu") <> "" Then
                    litMenu.Text = litMenu.Text & "<a href='" & dtrItem("var_RutaMenu") & "?IdSeccion=" & dtrSistema("int_IDMenu") & _
                                                "&IdMenu=" & dtrItem("int_IdMenu") & "&Usuario=" & objSeguridad.Encrypta(Session("Usuario")) & _
                                                "'>" & dtrItem("var_TituloMenu") & "</a>"
                Else
                    litMenu.Text = litMenu.Text & "<a href='#'>" & dtrItem("var_TituloMenu") & "</a>"

                    'NIVEL 2
                    Dim objSubMenu As New clsPerfilMenu
                    Dim dtbSubDatos As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 2, dtrItem("int_IdMenu"))
                    litMenu.Text = litMenu.Text & "<ul>"
                    For Each dtrSubItem In dtbSubDatos.Rows

                        litMenu.Text = litMenu.Text & "<li "
                        litMenu.Text = litMenu.Text & " class='MenuItemOff' >"
                        
                        litMenu.Text = litMenu.Text & "<a href='" & dtrSubItem("var_RutaMenu") & "?IdSeccion=" & dtrSistema("int_IDMenu") & _
                        "&IdMenu=" & dtrItem("int_IdMenu") & _
                        "&IdSubMenu=" & dtrSubItem("int_IdMenu") & _
                        "&Usuario=" & objSeguridad.Encrypta(Session("Usuario")) & _
                        "'>" & dtrSubItem("var_TituloMenu") & "</a>"

                        Dim objMenu3 As New clsPerfilMenu
                        Dim dtbDatos3 As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 3, dtrSubItem("int_IdMenu"))
                        If dtbDatos3.Rows.Count > 0 Then
                            litMenu.Text = litMenu.Text & "<ul>"
                            For Each dtrItem3 In dtbDatos3.Rows
                                litMenu.Text = litMenu.Text & "<li "
                                litMenu.Text = litMenu.Text & " class='MenuItemOff' >"

                                litMenu.Text = litMenu.Text & "<a href='" & dtrItem3("var_RutaMenu") & "?IdSeccion=" & dtrSistema("int_IDMenu") & _
                                "&IdMenu=" & dtrItem("int_IdMenu") & _
                                "&IdSubMenu=" & dtrSubItem("int_IdMenu") & _
                                "&IdSubMenu2=" & dtrItem3("int_IdMenu") & _
                                "&Usuario=" & objSeguridad.Encrypta(Session("Usuario")) & _
                                "'>" & dtrItem3("var_TituloMenu") & "</a>"
                                litMenu.Text = litMenu.Text & "</li>"
                            Next

                            litMenu.Text = litMenu.Text & "</ul>"

                        End If

                        litMenu.Text = litMenu.Text & "</li>"
                    Next
                    litMenu.Text = litMenu.Text & "</ul>"
                End If
                litMenu.Text = litMenu.Text & "</li>"
            Next
            litMenu.Text = litMenu.Text & "</ul>"


            litMenu.Text = litMenu.Text & "</li>"
        Next
        litMenu.Text = litMenu.Text & "</ul>"


    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Session("Usuario") = "ADMIN"

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnSeccion.Value = "Portal"
            hdnRuta.Value = "http://" & Request.Url.Authority & Request.ApplicationPath
            Construir()
        End If

    End Sub
End Class

