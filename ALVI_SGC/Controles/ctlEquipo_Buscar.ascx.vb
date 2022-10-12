
Partial Class Controles_ctlEquipo_Buscar
    Inherits System.Web.UI.UserControl

    Public Event ControlUpdate As EventHandler

    Public Property IdEquipo() As String
        Get
            Return txtIdEquipo.Text
        End Get
        Set(ByVal value As String)
            txtIdEquipo.Text = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return txtDescripcion.Text
        End Get
        Set(ByVal value As String)
            txtDescripcion.Text = value
        End Set
    End Property
    Public Sub Limpia()
        txtIdEquipo.Text = ""
        txtDescripcion.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            txtDescripcion.Text = ""
            txtIdEquipo.Text = ""
        End If
    End Sub
    Private Sub BindLista()
        Dim objMaquina As New ALVI_LOGIC.Maestros.Produccion.Maquina
        Dim strCriterio As String = ""
        If txtIdEquipo.Text <> "" Then
            strCriterio = "var_IdMaquina LIKE '" & txtIdEquipo.Text & "%'"
        ElseIf txtDescripcion.Text <> "" Then
            strCriterio = "var_Descripcion LIKE '%" & txtDescripcion.Text & "%'"
            strCriterio = Replace(strCriterio.ToUpper, " AND ", "")
            strCriterio = Replace(strCriterio.ToUpper, " OR ", "")
        End If

        objMaquina.Listar()

        Dim dtvDatos As New Data.DataView(objMaquina.Datos, strCriterio, "var_Descripcion ASC", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub
    Public Sub BuscarId()
        If txtIdEquipo.Text <> "" Then
            Dim objMaquina As New ALVI_LOGIC.Maestros.Ventas.Cliente
            objMaquina.IdCliente = txtIdEquipo.Text
            If objMaquina.Obtener() = True Then
                txtDescripcion.Text = objMaquina.Descripcion
            Else
                txtDescripcion.Text = ""
            End If
        End If
    End Sub
    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub
    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub
    Protected Sub txtIdEquipo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdEquipo.TextChanged
        BuscarId()
    End Sub
    Protected Sub txtDescripcion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        BindLista()
    End Sub
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdEquipo.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
            RaiseEvent ControlUpdate(Me, EventArgs.Empty)
        End If
    End Sub
End Class
