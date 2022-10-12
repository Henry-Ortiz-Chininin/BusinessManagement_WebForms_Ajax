
Partial Class Controles_ctlAvanceOP
    Inherits System.Web.UI.UserControl

    Private _strIdOrden As String

    Public Property IdOrden As String
        Get
            Return _strIdOrden
        End Get
        Set(ByVal value As String)
            _strIdOrden = value
        End Set
    End Property

    Public Sub Build()
        Dim objResultado As New ALVI_LOGIC.Resultado.Produccion

        Dim objUtiles As New Utilitarios
        objResultado.Avance_OP(_strIdOrden)
        Dim dblAvance As Double = 0
        Dim dblLargo As Double = 0

        For Each dtrItem As Data.DataRow In objResultado.Datos.Rows
            dblAvance = dblAvance + (dtrItem("num_AvanceEsperado") * dtrItem("num_Porcentaje"))
            dblLargo = dblLargo + (4 * dtrItem("num_AvanceEsperado"))
            Dim imgAvance As New Image
            imgAvance.ImageUrl = "../Controles/imgAsiento.aspx?Proc=" & _
                                    (4 * dtrItem("num_AvanceEsperado")) & _
                                    "&Titulo=" & dtrItem("var_Proceso") & _
                                    "&Por=" & dtrItem("num_Porcentaje")
            pnlImagen.Controls.Add(imgAvance)

        Next

        Dim imgTotal As New Image
        imgTotal.ImageUrl = "../Controles/imgAsiento.aspx?Proc=25" & _
                                "&Titulo=" & dblAvance & "%" & _
                                "&Por=1"
        pnlImagen.Controls.Add(imgTotal)
        pnlImagen.Width = dblLargo + 25

    End Sub

End Class
