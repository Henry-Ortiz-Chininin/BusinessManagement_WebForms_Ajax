
Partial Class Controles_ctlUnidadMedida_Buscar
    Inherits System.Web.UI.UserControl


    Public Property IdUnidadMedida() As String
        Get
            Return txtIdUnidadMedida.Text
        End Get
        Set(ByVal value As String)
            txtIdUnidadMedida.Text = value
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
        txtIdUnidadMedida.Text = ""
        txtNombre.Text = ""

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            'txtIdUnidadMedida.Text = ""
            'txtNombre.Text = ""
        End If
    End Sub


    Private Sub BindLista()
        Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
        Dim srtCriterio As String = ""

        objUnidadMedida.IdUnidadMedida = ""
        objUnidadMedida.Descripcion = ""
        If txtIdUnidadMedida.Text <> "" Then
            objUnidadMedida.IdUnidadMedida = txtIdUnidadMedida.Text
        ElseIf txtNombre.Text <> "" Then
            objUnidadMedida.Descripcion = Replace(txtNombre.Text, " ", "%")
        End If

        objUnidadMedida.Buscar()
        Dim dtbDatos As Data.DataTable = objUnidadMedida.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdUnidadMedida", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub


    Public Sub BuscarId()
        If txtIdUnidadMedida.Text <> "" Then
            Dim objUnidadMedida As New ALVI_LOGIC.Configuracion.UnidadMedida
            objUnidadMedida.IdUnidadMedida = txtIdUnidadMedida.Text
            If objUnidadMedida.Obtener1() = True Then
                txtNombre.Text = objUnidadMedida.Descripcion

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


    Protected Sub txtIdUnidadMedida_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdUnidadMedida.TextChanged
        BuscarId()
    End Sub


    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        BindLista()
    End Sub

    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdUnidadMedida.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub

End Class
