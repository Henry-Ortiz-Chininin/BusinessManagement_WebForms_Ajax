Imports LN_ALVINET_CONTA.CONFIG
Imports EN_ALVINET_CONTA.CONFIG
Imports System.Data
Imports System.Reflection

Partial Class CONTROLES_REGISTRO_ctlVoucher_Registro

    Inherits System.Web.UI.UserControl
    Private utility As New Utility
    Private objListENOperacionCuenta As New List(Of EN_OperacionesCuenta)
    Private objENOperacionCuenta As New EN_OperacionesCuenta
    Private dtbDatos As New DataTable
    Private drDatos As DataRow



    Public Property Mensaje() As String
        Get
            Return lblMensaje.Text
        End Get
        Set(ByVal value As String)
            lblMensaje.Text = value
        End Set
    End Property

    Public Property TotalCargo() As String
        Get
            Return txtTotalCargo.Text
        End Get
        Set(ByVal value As String)
            txtTotalCargo.Text = value
        End Set
    End Property

    Public Property TotalAbono() As String
        Get
            Return txtTotalAbono.Text
        End Get
        Set(ByVal value As String)
            txtTotalAbono.Text = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return ddlOperacion.SelectedValue
        End Get
        Set(ByVal value As String)
            ddlOperacion.SelectedValue = value
        End Set
    End Property

    Public Sub llenarComboOperacion()

        Dim objLNOperacion As New LN_Operacion
        Dim objENOperacion As New EN_Operacion

        objENOperacion.Idempresa = hdnEmpresa.Value
        objLNOperacion.entOperacion = objENOperacion

        ddlOperacion.Items.Clear()

        objLNOperacion.Listar()
        ddlOperacion.DataTextField = "Operacion"
        ddlOperacion.DataValueField = "IdOperacion"
        ddlOperacion.DataSource = objLNOperacion.lstOperacion
        ddlOperacion.DataBind()

        ddlOperacion.Items.Insert(0, New ListItem("Seleccione>>>", ""))
        ddlOperacion.SelectedIndex = 0

    End Sub
    Public Sub GetAll()

        Dim objLNOperacionCuenta As New LN_OperacionCuenta

        If objLNOperacionCuenta.ListarC() Then
            '    Dim a As String = Session("flag")
            objListENOperacionCuenta = objLNOperacionCuenta.lstOperacionCuenta

            grdVoucher.DataSource = objLNOperacionCuenta.lstOperacionCuenta
            grdVoucher.DataBind()


            'dtbDatos = New Data.DataTable
            'dtbDatos = utility.ConvertToDataTable(objLNOperacionCuenta.lstOperacionCuenta)
            'Session("Datos") = dtbDatos
            'grdVoucher.DataSource = dtbDatos
            'grdVoucher.DataBind()
        End If
        'If IsNothing(Session("flag")) Then



    End Sub

    Private _datos As List(Of EN_OperacionesCuenta)

    Public Property Datos() As List(Of EN_OperacionesCuenta)
        Get
            Return _datos
        End Get
        Set(ByVal value As List(Of EN_OperacionesCuenta))
            _datos = value
        End Set
    End Property

    Private _filas As GridViewRow

    Public Property Filas() As GridViewRow
        Get
            Return _filas
        End Get
        Set(ByVal value As GridViewRow)
            _filas = value
        End Set
    End Property

    Public Property Voucher() As String
        Get
            Return txtCodigoVoucher.Text
        End Get
        Set(ByVal value As String)
            txtCodigoVoucher.Text = value
        End Set
    End Property

    Public Property Fecha() As String
        Get
            Return txtFecha.Text
        End Get
        Set(ByVal value As String)
            txtFecha.Text = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hdnUsuario.Value = Session("Usuario")
            hdnEmpresa.Value = Session("Empresa")
            llenarComboOperacion()
            txtFecha.Text = Format(Date.Now, ("dd/MM/yyyy"))
            txtFecha.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecha.ClientID & ", 'dd/mm/yyyy');")
            btnFecha.Attributes.Add("onclick", "popUpCalendar(this, " & txtFecha.ClientID & ", 'dd/mm/yyyy');")

            GetAll()

        End If
    End Sub

    Public Function GetDatos(ByVal tabla As DataTable) As List(Of EN_OperacionesCuenta)
        Datos = New List(Of EN_OperacionesCuenta)
        For i = 0 To tabla.Rows.Count - 1
            objENOperacionCuenta.IdCuentaContable = tabla(0)("IdCuentaContable")
            objENOperacionCuenta.Operacion = tabla(0)("Operacion")
            objENOperacionCuenta.EsCargo = tabla(0)("EsCargo")
            objENOperacionCuenta.EsAbono = tabla(0)("EsAbono")
            objENOperacionCuenta.Observacion = tabla(0)("Observacion")
            Datos.Add(objENOperacionCuenta)
        Next
        Return Datos
    End Function

    Protected Sub grdVoucher_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdVoucher.RowCommand
        If e.CommandName = "AGREGAR" Then
            Dim _strIdCuenta = CType(grdVoucher.FooterRow.FindControl("txtCuentaRegistro1"), TextBox).Text
            Dim _strDescripcion = CType(grdVoucher.FooterRow.FindControl("txtDescripcionRegistro1"), TextBox).Text
            Dim _strEsCargo = CType(grdVoucher.FooterRow.FindControl("txtCargoRegistro1"), TextBox).Text
            Dim _strEsAbono = CType(grdVoucher.FooterRow.FindControl("txtAbonoRegistro1"), TextBox).Text
            Dim _strOrservacion = CType(grdVoucher.FooterRow.FindControl("txtObservacionRegistro1"), TextBox).Text

            Dim dtbDatosFinal As New DataTable
            dtbDatosFinal = Session("Datos")
            Dim objLNOperacionCuenta As New LN_OperacionCuenta
            If IsNothing(Session("Datos")) Then
                If objLNOperacionCuenta.ListarC() Then
                    dtbDatos = utility.ConvertToDataTable(objLNOperacionCuenta.lstOperacionCuenta)
                    dtbDatosFinal = dtbDatos
                End If
            End If
            If dtbDatosFinal.Rows.Count > 0 Then
                For index = 0 To dtbDatosFinal.Rows.Count - 1
                    For Each item As DataRow In dtbDatosFinal.Select("IdCuentaContable ='" & dtbDatosFinal.Rows(index)("IdCuenta") & "'")
                        If _strIdCuenta <> "" AndAlso _strDescripcion <> "" AndAlso _strEsCargo <> "" Then

                            If dtbDatosFinal.Rows(index)("IdCuentaContable") <> _strIdCuenta Then
                                Dim pkAtributos(1) As Data.DataColumn
                                'pkAtributos(0) = dtbDatosFinal.Columns("IdCuenta")
                                'dtbDatosFinal.PrimaryKey = pkAtributos
                                drDatos = dtbDatosFinal.NewRow
                                drDatos("IdCuenta") = _strIdCuenta
                                drDatos("Operacion") = _strDescripcion
                                drDatos("EsCargo") = _strEsCargo
                                drDatos("EsAbono") = _strEsAbono
                                drDatos("Observacion") = _strOrservacion
                                dtbDatosFinal.LoadDataRow(drDatos.ItemArray, True)
                                dtbDatosFinal.AcceptChanges()
                            End If
                        End If
                    Next
                Next
                Me.grdVoucher.DataSource = dtbDatosFinal
                Me.grdVoucher.DataBind()


                GetDatos(dtbDatosFinal)
                Session("datosFin") = dtbDatosFinal

            Else
                dtbDatosFinal.Columns.Add("IdCuentaContable", GetType(String))
                dtbDatosFinal.Columns.Add("Operacion", GetType(String))
                dtbDatosFinal.Columns.Add("EsCargo", GetType(Decimal))
                dtbDatosFinal.Columns.Add("EsAbono", GetType(Decimal))
                dtbDatosFinal.Columns.Add("Observacion", GetType(String))
                Dim row As GridViewRow = grdVoucher.Rows(e.CommandArgument)
                For i = 0 To grdVoucher.Rows.Count - 1
                    drDatos = dtbDatosFinal.NewRow
                    drDatos("IdCuentaContable") = HttpUtility.HtmlDecode(row.Cells(0).Text)
                    drDatos("Operacion") = HttpUtility.HtmlDecode(row.Cells(1).Text)
                    drDatos("EsCargo") = HttpUtility.HtmlDecode(row.Cells(2).Text)
                    drDatos("EsAbogo") = HttpUtility.HtmlDecode(row.Cells(3).Text)
                    drDatos("Observacion") = HttpUtility.HtmlDecode(row.Cells(4).Text)

                    'drDatos("DesOperacion") = _strDescripcion
                    'drDatos("EsCargo") = _strEsCargo
                    'drDatos("EsAbono") = _strEsAbono
                    'drDatos("Observacion") = _strOrservacion
                    dtbDatosFinal.LoadDataRow(drDatos.ItemArray, True)
                    dtbDatosFinal.AcceptChanges()

                    Session("datosFin") = dtbDatosFinal
                Next

            End If
            
        End If
        If e.CommandName = "ELIMINAR" Then
            Dim objLNOperacionCuenta As New LN_OperacionCuenta
            Dim objENOperacionCuentaa As New LN_OperacionCuenta
            objENOperacionCuenta.IdCuentaContable = e.CommandArgument.ToString
            objLNOperacionCuenta.entOperacionCuenta = objENOperacionCuenta
            objLNOperacionCuenta.Quitar()
            GetAll()
        End If
    End Sub


    Protected Sub grdVoucher_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVoucher.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim txt As TextBox = CType(e.Row.FindControl("lblCargo1"), TextBox)
            txt.Attributes.Add("onBlur", "JvfunonBlur();")
            Dim txt1 As TextBox = CType(e.Row.FindControl("lblAbono1"), TextBox)

            txt1.Attributes.Add("onBlur", "JvfunonBlur();")
        End If
    End Sub
End Class
