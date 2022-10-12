
Imports EN_ALVINET_CONTA.CONFIG
Imports LN_ALVINET_CONTA.CONFIG

Partial Class CONTROLES_BUSQUEDA_ctlVoucher_Busqueda
    Inherits System.Web.UI.UserControl
    Dim entOPeracionCuenta As New EN_OperacionesCuenta
    Dim objLNOPeracion As New LN_OperacionCuenta

    Private _strSalida As String
    Public Property Salida() As String
        Get
            Return _strSalida
        End Get
        Set(ByVal value As String)
            _strSalida = value
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

    Private _strIdCuenta As String
    Public Property IdCuenta() As String
        Get
            Return _strIdCuenta
        End Get
        Set(ByVal value As String)
            _strIdCuenta = value
        End Set
    End Property

    Public Sub BindLista()
        divVisible.Visible = True
        If Salida = "cuenta" Then
            If IsNumeric(txtDescripcion.Text) Then
                IdCuenta = txtDescripcion.Text
                txtDescripcion.Text = ""
            Else
                txtDescripcion.Text = txtDescripcion.Text
                IdCuenta = IdCuenta
            End If
        ElseIf Salida = "descripcion" Then
            If IsNumeric(txtDescripcion.Text) Then
                IdCuenta = txtDescripcion.Text
                txtDescripcion.Text = ""
            Else
                txtDescripcion.Text = txtDescripcion.Text
                IdCuenta = ""
            End If
        Else
            txtDescripcion.Text = txtDescripcion.Text
            IdCuenta = ""
        End If


        entOPeracionCuenta.IdCuentaContable = IdCuenta
        entOPeracionCuenta.CuentaContable = txtDescripcion.Text

        objLNOPeracion.entOperacionCuenta = entOPeracionCuenta
        objLNOPeracion.Buscar()

        dtlLista.DataSource = objLNOPeracion.lstOperacionCuenta
        dtlLista.DataBind()
    End Sub
    Public Sub SetLista()
        entOPeracionCuenta.IdCuentaContable = ""
        entOPeracionCuenta.CuentaContable = txtDescripcion.Text
        objLNOPeracion.entOperacionCuenta = entOPeracionCuenta
        If objLNOPeracion.Buscar() Then
            txtDescripcion.Text = objLNOPeracion.lstOperacionCuenta(0).CuentaContable
            IdCuenta = objLNOPeracion.lstOperacionCuenta(0).IdCuentaContable

            RaiseEvent cargarDatos()

        End If
    End Sub
    Public Event cargarDatos()
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtDescripcion.Text = e.CommandArgument
            SetLista()
            ' pnlLista.Visible = False

        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar.Click
        BindLista()
    End Sub



    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        divVisible.Visible = False
        RaiseEvent cargarDatos()
    End Sub
End Class
