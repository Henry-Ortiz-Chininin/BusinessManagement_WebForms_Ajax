
Partial Class Controles_ctlCuentaGasto_Buscar
    Inherits System.Web.UI.UserControl


    Public Property IdCuentaGasto() As String
        Get
            Return txtIdCuentaGasto.Text
        End Get
        Set(ByVal value As String)
            txtIdCuentaGasto.Text = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return txtCuentaGasto.Text
        End Get
        Set(ByVal value As String)
            txtCuentaGasto.Text = value
        End Set
    End Property
    Public Sub Limpia()
        txtIdCuentaGasto.Text = ""
        txtCuentaGasto.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            txtIdCuentaGasto.Text = ""
            txtCuentaGasto.Text = ""
        End If
    End Sub

    Private Sub BindLista()
        Dim objCuentaGasto As New ALVI_LOGIC.Configuracion.CuentaGasto
        objCuentaGasto.IdCuentaGasto = txtIdCuentaGasto.Text
        objCuentaGasto.Descripcion = txtCuentaGasto.Text

        'Dim strCriterio As String = ""
        'If txtIdCuentaGasto.Text <> "" Then
        '    strCriterio = "var_IdCuentaGasto LIKE '" & txtIdCuentaGasto.Text & "%'"
        'ElseIf txtCuentaGasto.Text <> "" Then
        '    strCriterio = "var_Descripcion LIKE '%" & txtCuentaGasto.Text & "%'"
        '    strCriterio = Replace(strCriterio.ToUpper, " AND ", "")
        '    strCriterio = Replace(strCriterio.ToUpper, " OR ", "")
        'End If


        Dim objAcceso As New ALVI_Security.Accesos.AccesoPerfil
        objCuentaGasto.Buscar()
        Dim dtbDatos As Data.DataTable = objAcceso.FiltrarAccesos(objCuentaGasto.Datos, Session("IdPerfil"), "B", "var_IdCuentaGasto")

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdCuentaGasto ASC", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub

    Private Sub BuscarId()
        If txtIdCuentaGasto.Text <> "" Then
            Dim objCuentaGasto As New ALVI_LOGIC.Configuracion.CuentaGasto
            objCuentaGasto.IdCuentaGasto = txtIdCuentaGasto.Text
            If objCuentaGasto.Obtener() = True Then
                txtCuentaGasto.Text = objCuentaGasto.Descripcion
            Else
                txtCuentaGasto.Text = ""
            End If
        End If
    End Sub

    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub

    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub

    Protected Sub txtIdCuentaGasto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCuentaGasto.TextChanged
        BuscarId()
    End Sub

    Protected Sub txtCuentaGasto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCuentaGasto.TextChanged
        BindLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdCuentaGasto.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub
End Class
