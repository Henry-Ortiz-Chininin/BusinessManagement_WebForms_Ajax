
Partial Class Controles_ctlOrdenServicio
    Inherits System.Web.UI.UserControl

    Public Event ControlUpdate As EventHandler

    Public Property IdOrdenServicio() As TextBox
        Get
            Return txtIdOrdenServ
        End Get
        Set(ByVal value As TextBox)
            txtIdOrdenServ = value
        End Set
    End Property
    Public Property Placa() As TextBox
        Get
            Return txtPlaca
        End Get
        Set(ByVal value As TextBox)
            txtPlaca = value
        End Set
    End Property
    Public Property Importe() As Double
        Get
            Return CDbl(hdnImporte.Value)
        End Get
        Set(ByVal value As Double)
            hdnImporte.Value = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return hdnRazonSocial.Value
        End Get
        Set(ByVal value As String)
            hdnRazonSocial.Value = value
        End Set
    End Property
    Public Sub Limpia()
        txtIdOrdenServ.Text = ""
        txtPlaca.Text = ""
        ctlCliente_Buscar.Limpia()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            Limpia()
        End If
    End Sub
    Private Sub BindLista()
        Dim LN_OrdenServicio As New LN_ALVINET_CONTA.OPERACION.LN_OrdenServicio
        Dim EN_OrdenServicio As New EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio

        EN_OrdenServicio.IdOrdenServicio = txtIdOrdenServ.Text
        EN_OrdenServicio.Placa_Grua = txtPlaca.Text
        EN_OrdenServicio.IdCliente = ctlCliente_Buscar.IdCliente

        LN_OrdenServicio.entDato = EN_OrdenServicio
        If LN_OrdenServicio.Buscar() Then
            If LN_OrdenServicio.lstDatos.Count = 1 Then
                txtIdOrdenServ.Text = LN_OrdenServicio.lstDatos(0).IdOrdenServicio
                txtPlaca.Text = LN_OrdenServicio.lstDatos(0).Placa_Grua
                hdnImporte.Value = LN_OrdenServicio.lstDatos(0).ImporteTotal
                hdnRazonSocial.Value = LN_OrdenServicio.lstDatos(0).RazonSocial
                ctlCliente_Buscar.IdCliente = LN_OrdenServicio.lstDatos(0).IdCliente
                ctlCliente_Buscar.BuscarId()
                pnlLista.Visible = False
            Else
                dtlLista.DataSource = LN_OrdenServicio.lstDatos
                dtlLista.DataBind()
                pnlLista.Visible = True
            End If
        Else
            pnlLista.Visible = False
        End If
        
    End Sub
    Public Sub BuscarId()
        If txtIdOrdenServ.Text <> "" Then
            Dim LN_OrdenServicio As New LN_ALVINET_CONTA.OPERACION.LN_OrdenServicio
            Dim EN_OrdenServicio As New EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio

            EN_OrdenServicio.IdOrdenServicio = txtIdOrdenServ.Text
            LN_OrdenServicio.entDato = EN_OrdenServicio

            If LN_OrdenServicio.Buscar = True Then
                txtIdOrdenServ.Text = LN_OrdenServicio.lstDatos(0).IdOrdenServicio
                txtPlaca.Text = LN_OrdenServicio.lstDatos(0).Placa_Grua
                ctlCliente_Buscar.IdCliente = LN_OrdenServicio.lstDatos(0).IdCliente
                hdnImporte.Value = LN_OrdenServicio.lstDatos(0).ImporteTotal
                hdnRazonSocial.Value = LN_OrdenServicio.lstDatos(0).RazonSocial
                ctlCliente_Buscar.BuscarId()
                pnlLista.Visible = False
            Else
                Limpia()
            End If
            pnlLista.Visible = False
        End If
    End Sub
    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub
    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub
    Protected Sub txtIdOrdenServ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdOrdenServ.TextChanged
        txtPlaca.Text = ""
        If txtIdOrdenServ.Text = "" Then
            pnlLista.Visible = False
        Else
            BuscarId()
        End If
    End Sub
    Protected Sub txtPlaca_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaca.TextChanged
        txtIdOrdenServ.Text = ""
        If txtPlaca.Text = "" Then
            pnlLista.Visible = False
        Else
            BindLista()
        End If
    End Sub
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdOrdenServ.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
            RaiseEvent ControlUpdate(Me, EventArgs.Empty)
        End If
    End Sub
End Class
