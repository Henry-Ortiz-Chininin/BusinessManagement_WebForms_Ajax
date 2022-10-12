
Partial Class Controles_ctlCargo_Buscar
    Inherits System.Web.UI.UserControl

    Public Property IdCargo() As String
        Get
            Return txtIdCargo.Text
        End Get
        Set(ByVal value As String)
            txtIdCargo.Text = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return txtNombre.Text
        End Get
        Set(ByVal value As String)
            txtNombre.Text = value
        End Set
    End Property


    Public Property IdSubFamilia() As String
        Get
            Return hdnIdSubFamilia.Value
        End Get
        Set(ByVal value As String)
            hdnIdSubFamilia.Value = value
        End Set
    End Property

    Public Sub Limpia()
        txtIdCargo.Text = ""
        txtNombre.Text = ""
        
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            'Limpia()
        End If
    End Sub


    Private Sub BindLista()
        Dim objCargo As New ALVI_LOGIC.Maestros.Compras.Cargo


        objCargo.IdCargo = ""
        objCargo.Descripcion = ""
        If txtIdCargo.Text <> "" Then
            objCargo.IdCargo = txtIdCargo.Text
        ElseIf txtNombre.Text <> "" Then
            objCargo.Descripcion = Replace(txtNombre.Text, " ", "%")
        End If

        objCargo.Buscar()
        Dim dtbDatos As Data.DataTable = objCargo.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdCargo", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub


    Public Sub BuscarId()
        If txtIdCargo.Text <> "" Then
            Dim objCargo As New ALVI_LOGIC.Maestros.Compras.Cargo
            objCargo.IdCargo = txtIdCargo.Text
            If objCargo.Obtener() = True Then
                txtNombre.Text = objCargo.Descripcion

            Else
                txtNombre.Text = ""

            End If
        End If
    End Sub

    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub

    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub


    Protected Sub txtIdCargo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdCargo.TextChanged
        BuscarId()
    End Sub


    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        BindLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdCargo.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub







End Class
