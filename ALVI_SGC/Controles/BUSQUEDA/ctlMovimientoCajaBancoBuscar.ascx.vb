Imports LN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA.GENERAL
Imports EN_ALVINET_CONTA

Partial Class CONTROLES_BUSQUEDA_ctlMovimientoCajaBancoBuscar
    Inherits System.Web.UI.UserControl
    Private _objLNMCajaBanco As New LN_CajaBanco
    Private _lstMCajaCajaBanco As New List(Of EN_CajaBanco)
    Private _entMCajaBanco As New EN_CajaBanco
    Private _entBase As New EN_Base

    Private _strcriterio As String = ""
    Public Property Criterio() As String
        Get
            Return _strcriterio
        End Get
        Set(ByVal value As String)
            _strcriterio = value
        End Set
    End Property

    Private _strDescripcion As String = ""
    Public Property Descripcion() As String
        Get
            Return _strDescripcion
        End Get
        Set(ByVal value As String)
            _strDescripcion = value
        End Set
    End Property
    Private _strSubParametro As String = ""
    Public Property SubParametro() As String
        Get
            Return _strSubParametro
        End Get
        Set(ByVal value As String)
            _strSubParametro = value
        End Set
    End Property


    Public Property Titulo() As String
        Get
            Return lblTitulo.Text
        End Get
        Set(ByVal value As String)
            lblTitulo.Text = value
        End Set
    End Property

    Public Event setParametro()
    Public Event cerrado()
    Public Event setSubParametro()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtDescripcion.Focus()
            bindGrid()
        End If
    End Sub

    Public Sub bindGrid()
        RaiseEvent setSubParametro()

        If txtDescripcion.Text = "" Then
            _entBase.CriterioBusqueda = ddlTipo.SelectedValue
            _entBase.Parametro = txtDescripcion.Text
            _entBase.SubParametro = SubParametro
            _objLNMCajaBanco.entBase = _entBase
            If _objLNMCajaBanco.Listar() Then
                Session("gridDatos") = _objLNMCajaBanco.lstCajaBanco
                grdDatos.DataSource = Session("gridDatos")
                grdDatos.DataBind()
            End If
        Else

            If ddlTipo.SelectedIndex <> 0 Then
                _entBase.CriterioBusqueda = ddlTipo.SelectedValue
                _entBase.Parametro = txtDescripcion.Text
                _entBase.SubParametro = SubParametro.ToString
                _objLNMCajaBanco.entBase = _entBase
                If _objLNMCajaBanco.Listar() Then
                    Session("gridDatos") = _objLNMCajaBanco.lstCajaBanco
                    grdDatos.DataSource = Session("gridDatos")
                    grdDatos.DataBind()
                End If
            Else
                grdDatos.DataSource = Nothing
                grdDatos.DataBind()

            End If


        End If



    End Sub
    Private Sub limpiar()
        ddlTipo.SelectedIndex = 0
        txtDescripcion.Text = ""
        grdDatos.DataSource = Nothing
        grdDatos.DataBind()
    End Sub
    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        bindGrid()
    End Sub

    Protected Sub grdDatos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDatos.RowCommand

        If e.CommandName = "PARTIR" Then
            Dim boton As ImageButton = CType(e.CommandSource, ImageButton)
            Dim fila As GridViewRow = CType(boton.NamingContainer, GridViewRow)
            Dim lblNombred As Label = CType(fila.FindControl("lblNopmbre"), Label)
            Descripcion = lblNombred.Text
            RaiseEvent setParametro()
            limpiar()
            RaiseEvent cerrado()

        End If

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        limpiar()
        RaiseEvent cerrado()

    End Sub

    Protected Sub grdDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDatos.PageIndexChanging
        grdDatos.PageIndex = e.NewPageIndex
        grdDatos.DataSource = Session("gridDatos")
        grdDatos.DataBind()
    End Sub
End Class
