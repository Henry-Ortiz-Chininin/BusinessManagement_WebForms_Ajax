
Partial Class Controles_ctlPersonal_Buscar1
    Inherits System.Web.UI.UserControl




    Public Property IdPersonal() As String
        Get
            Return txtIdPersonal.Text
        End Get
        Set(ByVal value As String)
            txtIdPersonal.Text = value
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

    Public Property ApellidoPaterno() As String
        Get
            Return txtPaterno.Text
        End Get
        Set(ByVal value As String)
            txtPaterno.Text = value
        End Set
    End Property


    Public Property ApellidoMaterno() As String
        Get
            Return txtMaterno.Text
        End Get
        Set(ByVal value As String)
            txtMaterno.Text = value
        End Set
    End Property


    Public Sub Limpia()
        txtIdPersonal.Text = ""
        txtNombre.Text = ""
        txtMaterno.Text = ""
        txtPaterno.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            txtIdPersonal.Text = ""
            txtNombre.Text = ""
            txtMaterno.Text = ""
            txtPaterno.Text = ""
        End If
    End Sub

    Private Sub BindLista()
        Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal


        objPersonal.IdPersonal = ""
        objPersonal.Nombre = ""
        objPersonal.ApellidoPaterno = ""
        objPersonal.ApellidoMaterno = ""
        If txtIdPersonal.Text <> "" Then
            objPersonal.IdPersonal = txtIdPersonal.Text
        ElseIf txtNombre.Text <> "" Then
            objPersonal.Nombre = Replace(txtNombre.Text, " ", "%")
        ElseIf txtPaterno.Text <> "" Then
            objPersonal.ApellidoPaterno = Replace(txtPaterno.Text, " ", "%")
        ElseIf txtMaterno.Text <> "" Then

            objPersonal.ApellidoMaterno = Replace(txtMaterno.Text, " ", "%")
        End If


        objPersonal.Buscar()
        Dim dtbDatos As Data.DataTable = objPersonal.Datos

        Dim dtvDatos As New Data.DataView(dtbDatos, "", "var_IdPersonal", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub


    Public Sub BuscarId()
        If txtIdPersonal.Text <> "" Then
            Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal
            objPersonal.IdPersonal = txtIdPersonal.Text
            If objPersonal.Obtener() = True Then
                txtNombre.Text = objPersonal.Nombre

            Else
                txtNombre.Text = ""

            End If

            If objPersonal.Obtener() = True Then
                txtPaterno.Text = objPersonal.ApellidoPaterno
            Else
                txtPaterno.Text = ""
            End If

            If objPersonal.Obtener() = True Then
                txtMaterno.Text = objPersonal.ApellidoMaterno
            Else
                txtMaterno.Text = ""
            End If
        End If
    End Sub


    Protected Sub btnBuscar1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar1.Click
        BindLista()
    End Sub

    Protected Sub btnBuscar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar2.Click
        BindLista()
    End Sub


    Protected Sub btnBuscar3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar3.Click
        BindLista()
    End Sub

    Protected Sub btnBuscar4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBuscar4.Click
        BindLista()
    End Sub


    Protected Sub txtIdPersonal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdPersonal.TextChanged
        BuscarId()
    End Sub


    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        BindLista()
    End Sub


    Protected Sub txtPaterno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaterno.TextChanged
        BindLista()
    End Sub

    Protected Sub txtMaterno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaterno.TextChanged
        BindLista()
    End Sub

 


    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdPersonal.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
        End If
    End Sub

End Class
