
Partial Class Controles_ctlElemento_Referencial_Buscar
    Inherits System.Web.UI.UserControl

    Public Event BuscarUM(ByVal _pstrIdUnidadM As String)
    Public Event LimpiarUM()

    Public Property idArticulo() As String
        Get
            Return txtIdElementoReferencial.Text
        End Get
        Set(ByVal value As String)
            txtIdElementoReferencial.Text = value
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


    Public Property Titulo() As String
        Get
            Return lblTitulo.Text
        End Get
        Set(ByVal value As String)
            lblTitulo.Text = value
        End Set
    End Property




    Public Sub Limpia()
        txtIdElementoReferencial.Text = ""
        txtNombre.Text = ""

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            'Limpia()
        End If
    End Sub


    Private Sub BindLista()
        Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo


        objArticulo.IdArticulo = ""
        objArticulo.Descripcion = ""
        If txtIdElementoReferencial.Text <> "" Then
            objArticulo.IdArticulo = txtIdElementoReferencial.Text
        ElseIf txtNombre.Text <> "" Then
            objArticulo.Descripcion = Replace(txtNombre.Text, " ", "%")
        End If

        objArticulo.Buscar1()
        Dim dtbDatos As Data.DataTable = objArticulo.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdArticulo", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
        RaiseEvent LimpiarUM()
    End Sub


    Public Sub BuscarId()
        If txtIdElementoReferencial.Text <> "" Then
            Dim objArticulo As New ALVI_LOGIC.Maestros.Articulo.Articulo
            objArticulo.IdArticulo = txtIdElementoReferencial.Text
            If objArticulo.Obtener1() = True Then
                txtNombre.Text = objArticulo.Descripcion

                RaiseEvent BuscarUM(objArticulo.IdUnidadMedida)
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


    Protected Sub txtIdElementoReferencial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdElementoReferencial.TextChanged
        txtNombre.Text = ""
        BuscarId()
    End Sub


    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        txtIdElementoReferencial.Text = ""
        BindLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdElementoReferencial.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub


End Class
