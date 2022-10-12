
Partial Class Security_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'If Session("Usuario") = "" Then
        '    Response.Redirect("login.aspx", True)

        'End If
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Dim objTipoCambio As New GMLogic.General.TipoCambio
    '        objTipoCambio.IdTipoCambio = Format(Now.Date, "yyyyMMdd")
    '        Session("TC_VentaSunat") = 1
    '        If objTipoCambio.Listar() = True Then
    '            Session("TC_VentaSunat") = objTipoCambio.VentaSunat
    '        End If

    '        Session("IGV") = 0.19
    '        Dim objParametros As New GMLogic.General.Parametros
    '        objParametros.Grupo = "IMPUESTO"
    '        objParametros.Listar()
    '        For Each dtrItem As Data.DataRow In objParametros.Datos.Select("var_IdParametro='IGV'", "")
    '            Session("IGV") = dtrItem("var_Valor")
    '        Next

    '        Dim objProducto As New GMLogic.Almacen.Producto
    '        If objProducto.Listar() = True Then
    '            Session("dtbProductos") = objProducto.Datos
    '        End If
    '    End If

    'End Sub
End Class
