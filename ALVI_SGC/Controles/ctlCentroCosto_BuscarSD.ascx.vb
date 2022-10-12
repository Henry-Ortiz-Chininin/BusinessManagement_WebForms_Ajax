
Partial Class Controles_ctlCentroCosto_BuscarSD
    Inherits System.Web.UI.UserControl


    Public Property IdCentroCosto() As String
        Get
            Return txtIdCentroCosto.Text
        End Get
        Set(ByVal value As String)
            txtIdCentroCosto.Text = value
        End Set
    End Property
    'Public Property Descripcion() As String
    '    Get
    '        Return txtCentroCosto.Text
    '    End Get
    '    Set(ByVal value As String)
    '        txtCentroCosto.Text = value
    '    End Set
    'End Property
    Public Sub Limpia()
        txtIdCentroCosto.Text = ""
        'txtCentroCosto.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            'txtCentroCosto.Text = ""
            txtIdCentroCosto.Text = ""
        End If
    End Sub
    Private Sub BindLista()
        Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
        Dim strCriterio As String = ""
        If txtIdCentroCosto.Text <> "" Then
            strCriterio = "var_IdCentroCosto LIKE '" & txtIdCentroCosto.Text & "'+'%'"
            'ElseIf txtCentroCosto.Text <> "" Then
            '    strCriterio = "var_Descripcion LIKE '%'+'" & txtCentroCosto.Text & "'+'%'"
            '    strCriterio = Replace(strCriterio.ToUpper, " AND ", "")
            '    strCriterio = Replace(strCriterio.ToUpper, " OR ", "")
        End If

        objCentroCosto.Listar()
        Dim objAcceso As New ALVI_Security.Accesos.AccesoPerfil

        Dim dtbDatos As Data.DataTable = objCentroCosto.Datos
        '= objAcceso.FiltrarAccesos(objCentroCosto.Datos, Session("IdPerfil"), "A", "var_IdCentroCosto")

        Dim dtvDatos As New Data.DataView(dtbDatos, strCriterio, "var_IdCentroCosto ASC", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub
    Private Sub BuscarId()
        If txtIdCentroCosto.Text <> "" Then
            Dim objCentroCosto As New ALVI_LOGIC.Configuracion.CentroCosto
            objCentroCosto.IdCentroCosto = txtIdCentroCosto.Text
            If objCentroCosto.Obtener() = True Then
                'txtCentroCosto.Text = objCentroCosto.Descripcion
                'Else
                '    txtCentroCosto.Text = ""
            End If
        End If
    End Sub
    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub
    'Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
    '    BindLista()
    'End Sub
    Protected Sub txtIdCentroCosto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCentroCosto.TextChanged
        BuscarId()
    End Sub
    'Protected Sub txtCentroCosto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCentroCosto.TextChanged
    '    BindLista()
    'End Sub
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdCentroCosto.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub
End Class
