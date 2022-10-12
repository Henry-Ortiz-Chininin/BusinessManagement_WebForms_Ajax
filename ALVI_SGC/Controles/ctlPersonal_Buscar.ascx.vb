
Partial Class Controles_ctlPersonal_Buscar
    Inherits System.Web.UI.UserControl

    Public Event ControlUpdate As EventHandler

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
    Public Sub Limpia()
        txtIdPersonal.Text = ""
        txtNombre.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlLista.Visible = False
            txtIdPersonal.Text = ""
            txtNombre.Text = ""
        End If
    End Sub
    Private Sub BindLista()
        Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal
        Dim strCriterio As String = ""
        If txtIdPersonal.Text <> "" Then
            strCriterio = "var_IdPersonal LIKE '" & txtIdPersonal.Text & "%'"
        ElseIf txtNombre.Text <> "" Then
            strCriterio = "var_Nombre LIKE '%" & txtNombre.Text & "%'"
            strCriterio = Replace(strCriterio.ToUpper, " AND ", "")
            strCriterio = Replace(strCriterio.ToUpper, " OR ", "")
        End If

        objPersonal.Listar()

        Dim dtvDatos As New Data.DataView(objPersonal.Datos, strCriterio, "var_IdPersonal ASC", Data.DataViewRowState.OriginalRows)
        dtlLista.DataSource = dtvDatos
        dtlLista.DataBind()
        pnlLista.Visible = True
    End Sub
    Public Sub BuscarId()
        If txtIdPersonal.Text <> "" Then
            Dim objPersonal As New ALVI_LOGIC.Maestros.Administracion.Personal
            objPersonal.IdPersonal = txtIdPersonal.Text
            If objPersonal.Obtener() = True Then
                txtNombre.Text = objPersonal.Nombre + " " + objPersonal.ApellidoPaterno + " " + objPersonal.ApellidoMaterno
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
    Protected Sub txtIdPersonal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIdPersonal.TextChanged
        BuscarId()
    End Sub
    Protected Sub txtNombre_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        BindLista()
    End Sub
    Protected Sub dtlLista_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtlLista.ItemCommand
        If e.CommandName = "Seleccionar" Then
            txtIdPersonal.Text = e.CommandArgument.ToString
            BuscarId()
            pnlLista.Visible = False
            RaiseEvent ControlUpdate(Me, EventArgs.Empty)
        End If
    End Sub
End Class
