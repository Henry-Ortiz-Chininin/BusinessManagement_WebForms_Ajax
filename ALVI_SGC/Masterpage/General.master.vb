Imports ALVI_Security
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Class Masterpage_General
    Inherits System.Web.UI.MasterPage

    Public ReadOnly Property IdSeccion() As String
        Get
            Return hdnIdSeccion.Value
        End Get
    End Property

    Public ReadOnly Property IdMenu() As String
        Get
            Return hdnIdMenu.Value
        End Get
    End Property

    Public ReadOnly Property TipoCambio As Double
        Get
            Return hdnTipoCambio.Value
        End Get
    End Property

    Public ReadOnly Property Seccion() As String
        Get
            Dim strSeccion As String = ""
            If hdnIdSeccion.Value <> "" Then
                Dim objSeccion As New ALVI_Security.clsMenu
                Dim dtbData As Data.DataTable = objSeccion.Obtener(0)
                For Each dtrItem As Data.DataRow In dtbData.Select("int_IDMenu='" & hdnIdSeccion.Value & "'")
                    strSeccion = dtrItem("var_TituloMenu")
                Next
            End If

            Return strSeccion
        End Get
    End Property

    Public ReadOnly Property IdSubMenu() As String
        Get
            Return hdnIdSubMenu.Value
        End Get
    End Property

    Public ReadOnly Property IdUsuario() As String
        Get
            Return hdnIdUsuario.Value
        End Get
    End Property


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If Not IsPostBack Then
            Session("Usuario") = "ADMIN"

            Session("Empresa") = "0000001"
            Session("Contabilidad") = "0000001"
            Session("EjercicioEmpresa") = "0000002"
            Session("PlanContable") = "0000001"
            Session("nomEjercicioEmpresa") = Now.Year
            Session("nomContabilidad") = ""
            Session("nomEmpresa") = "ALJUZA"

            If Request("Usuario") <> "" Then
                Dim objSeguridad As New ALVI_Security.General
                Session("Usuario") = objSeguridad.Decrypta(Request("Usuario"))
            End If
            If Session("Usuario") = "" Then
                Response.Redirect("~/Security/login.aspx", True)
            Else
                pnlLogin.Visible = False
                pnlSesion.Visible = True
            End If
        End If
        Dim objUsuario As New ALVI_Security.clsPerfilUsuario
        If objUsuario.ObtenerxUsuario(Session("Usuario")) = True Then
            Session("IdPerfil") = objUsuario.Datos.Rows(0)("int_IDPerfil")
        Else
            Session("IdPerfil") = 0
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblUsuario.Text = Session("Usuario")
        lblFecha.Text = "Fecha: " & Format(Now, "dd/MM/yyyy HH:mm")

        If Not IsPostBack Then
            Dim objTipoCambio As New ALVI_LOGIC.Maestros.Administracion.TipoCambio
            objTipoCambio.Listar(Format(Now.Date.AddDays(-7), "dd/MM/yyyy"), Format(Now.Date, "dd/MM/yyyy"))
            hdnTipoCambio.Value = 0
            lblTipoCambio.Text = "TC: 0.00/0.00"
            For Each dtrItem As Data.DataRow In objTipoCambio.Datos.Select("", "dtm_Fecha asc")
                hdnTipoCambio.Value = Format(dtrItem("num_Venta"), "#,##0.0000")
                lblTipoCambio.Text = "TC:" & Format(dtrItem("num_Venta"), "#,##0.0000") & "/" & Format(dtrItem("num_Compra"), "#,##0.0000")

            Next
            Session("TipoCambio") = hdnTipoCambio.Value
            hdnIdSeccion.Value = Request("IdSeccion")
            hdnIdMenu.Value = Request("IdMenu")
            hdnIdSubMenu.Value = Request("IdSubMenu")

            hdnSeccion.Value = "Portal"
            hdnRuta.Value = "http://" & Request.Url.Authority & Request.ApplicationPath
            Construir()
        End If
    End Sub

    Protected Sub btnCerrarSesion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrarSesion.Click
        Session.Abandon()
        Session.Clear()
        Response.Redirect("~/Security/login.aspx", True)
    End Sub

    Protected Sub tmrSesion_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrSesion.Tick
        pnlLogin.Visible = True
        pnlSesion.Visible = False
    End Sub

    Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAceptar.Click
        Try
            Dim objConexion As New clsUsuario

            If objConexion.Obtener(Me.txtLogin.Text, txtClave.Text) = True Then
                Dim objSeguridad As New ALVI_Security.General

                Session("Usuario") = objConexion.IDUsuario
                pnlLogin.Visible = False
                pnlSesion.Visible = True
                lblUsuario.Text = Session("Usuario")
                'Response.Redirect("Default.aspx?USI=" & objSeguridad.Encrypta(objConexion.IDUsuario), True)
            Else
                Session("Usuario") = ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub Construir()
        Dim strURL As String = Request.Url.AbsolutePath
        'If hdnIdSeccion.Value = "" Then
        '    Exit Sub
        'End If

        Dim objMenu As New clsPerfilMenu
        Dim objSeguridad As New ALVI_Security.General

        Dim dtbSistemas As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 0, 0)
        litMenu.Text = "<ul>"
        'NIVEL 0
        For Each dtrSistema In dtbSistemas.Rows
            litMenu.Text = litMenu.Text & "<li "
            If hdnIdSeccion.Value.ToString = dtrSistema("int_IDMenu").ToString Then
                litMenu.Text = litMenu.Text & " class='MenuOn' >"
            Else
                litMenu.Text = litMenu.Text & " class='MenuOff' >"
            End If
            litMenu.Text = litMenu.Text & "<a href='#'>" & dtrSistema("var_TituloMenu") & "</a>"
            'NIVEL 1
            Dim dtbDatos As Data.DataTable = objMenu.ObtenerxUsuario(Session("Usuario"), 1, dtrSistema("int_IDMenu"))
            litMenu.Text = litMenu.Text & "<ul>"
            For Each dtrItem In dtbDatos.Rows
                litMenu.Text = litMenu.Text & "<li "
                If hdnIdMenu.Value.ToString = dtrItem("int_IdMenu").ToString Then
                    litMenu.Text = litMenu.Text & " class='MenuOn' >"
                Else
                    litMenu.Text = litMenu.Text & " class='MenuOff' >"
                End If

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

                        If hdnIdSubMenu.Value.ToString = dtrSubItem("int_IdMenu").ToString Then
                            litMenu.Text = litMenu.Text & " class='MenuItemOn' >"
                        Else
                            litMenu.Text = litMenu.Text & " class='MenuItemOff' >"
                        End If

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

    Protected Sub tmrReloj_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrReloj.Tick
        lblFecha.Text = "Fecha: " & Format(Now, "dd/MM/yyyy HH:mm")
    End Sub
End Class

