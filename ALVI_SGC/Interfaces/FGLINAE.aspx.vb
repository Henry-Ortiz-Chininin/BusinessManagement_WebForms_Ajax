
Partial Class Interfaces_FGLINAE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            btnFechaEmisionInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaEmisionFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEmisionFinal.ClientID & ", 'dd/mm/yyyy');")


            btnFechaEntregaInicio.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEntregaInicio.ClientID & ", 'dd/mm/yyyy');")
            btnFechaEntregaFinal.Attributes.Add("onclick", "popUpCalendar(this, " & txtFechaEntregaFinal.ClientID & ", 'dd/mm/yyyy');")

            BindDocumento()
            rbtTipo.RepeatDirection = RepeatDirection.Horizontal
            CalcularFecha()
        End If
    End Sub
    Public Sub CalcularFecha()
        Dim _strFechaEmisionInicio As String = ""
        Dim _strFechaEmisionFin As String = ""
        Dim _strFechaEntregaInicio As String = ""
        Dim _strFechaEntregaFin As String = ""

        '******************Fecha de Emision
        If Not txtFechaEmisionFinal.Text <> "" Then

            Dim intDia As Integer = Now.Day
            Dim intMes As Integer = Now.Month
            Dim intAnio As Integer = Now.Year

            Dim dtmF1 As New DateTime(intAnio, intMes, intDia)
            '***FECHA DE EMISION FIN***
            Dim dtmF11 As DateTime = dtmF1.AddDays(-1)
            '***FECHA DE EMISION EMISION *****
            Dim dtmF12 As DateTime = dtmF11.AddDays(-6)
            Dim dtmF2 As DateTime = dtmF12.AddMonths(-1)

            txtFechaEmisionFinal.Text = Format(dtmF11, "dd/MM/yyyy")
            txtFechaEmisionInicio.Text = Format(dtmF2, "dd/MM/yyyy")
        Else
            Dim intDia As Integer = Format(CType(txtFechaEmisionFinal.Text, Date), "dd")
            Dim intMes As Integer = Format(CType(txtFechaEmisionFinal.Text, Date), "MM")
            Dim intAnio As Integer = Format(CType(txtFechaEmisionFinal.Text, Date), "yyyy")

            Dim dtmF1 As New DateTime(intAnio, intMes, intDia)
            Dim dtmF12 As DateTime = dtmF1.AddDays(-6)
            Dim dtmF2 As DateTime = dtmF12.AddMonths(-1)

            txtFechaEmisionInicio.Text = Format(dtmF2, "dd/MM/yyyy")
        End If
        '****************Fecha de Entrega
        If Not txtFechaEntregaFinal.Text <> "" Then

            Dim intDia As Integer = Now.Day
            Dim intMes As Integer = Now.Month
            Dim intAnio As Integer = Now.Year

            Dim dtmF1 As New DateTime(intAnio, intMes, intDia)
            '***FECHA DE EMISION EMISION *****
            Dim dtmF12 As DateTime = dtmF1.AddDays(-6)
            Dim dtmF2 As DateTime = dtmF12.AddMonths(-1)

            txtFechaEntregaFinal.Text = Format(dtmF1, "dd/MM/yyyy")
            txtFechaEntregaInicio.Text = Format(dtmF2, "dd/MM/yyyy")
        Else
            Dim intDia As Integer = Format(CType(txtFechaEmisionFinal.Text, Date), "dd")
            Dim intMes As Integer = Format(CType(txtFechaEmisionFinal.Text, Date), "MM")
            Dim intAnio As Integer = Format(CType(txtFechaEmisionFinal.Text, Date), "yyyy")

            Dim dtmF1 As New DateTime(intAnio, intMes, intDia)
            Dim dtmF2 As DateTime = dtmF1.AddMonths(-1)

            txtFechaEntregaInicio.Text = Format(dtmF2, "dd/MM/yyyy")
        End If
    End Sub
    Private Sub BindDocumento()
        Dim objTipoDocumento As New ALVI_LOGIC.Maestros.Administracion.TipoDocumento


        ddlTipo.Items.Clear()


        If objTipoDocumento.Listar1 = True Then
            ddlTipo.DataSource = objTipoDocumento.Datos
            ddlTipo.DataTextField = "var_Descripcion"
            ddlTipo.DataValueField = "chr_IdTipoDocumento"
            ddlTipo.DataBind()

        End If
        ddlTipo.Items.Insert(0, New ListItem("Selecionar", ""))
        ddlTipo.SelectedIndex = 0

    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click

        If txtFechaEmisionInicio.Text <> "" AndAlso txtFechaEmisionFinal.Text <> "" AndAlso txtFechaEntregaFinal.Text <> "" AndAlso txtFechaEntregaInicio.Text <> "" Then
            BindGrid()

        Else
            ClientScript.RegisterStartupScript(ClientScript.GetType, "ALERTA", "<script language='javascript'>alert('Ingrese fecha de inicio y de fin'); </script>")
        End If
    End Sub

    Private Sub BindGrid()
        Dim _objCompra As New ALVI_LOGIC.Maestros.Logistica.Compra

        _objCompra.IdOrdenCompra = txtCodigo.Text
        _objCompra.IdTipoDocumento = ddlTipo.Text
        _objCompra.IdTipoOperacion = rbtTipo.Text
        _objCompra.NumeroDocumento = txtNumeroDocumento.Text
        _objCompra.IdProveedor = ctlProveedor_Buscar1.IdProveedor
        _objCompra.IdArticulo = ctlElementoReferencial_Buscar1.idArticulo
        _objCompra.Buscar(txtFechaEmisionInicio.Text, txtFechaEmisionFinal.Text, txtFechaEntregaInicio.Text, txtFechaEntregaFinal.Text)

        grdDatos.DataSource = _objCompra.Datos
        grdDatos.DataBind()

    End Sub


    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand
        If e.CommandName = "Modificar" Then

        End If

    End Sub


End Class
