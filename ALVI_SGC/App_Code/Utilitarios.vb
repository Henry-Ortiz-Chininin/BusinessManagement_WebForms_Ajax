Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Utilitarios

    Public Function BuildAvance(ByVal intLargo As Integer,
                                 ByVal strTitulo As String,
                                 ByVal dblPorcentaje As Double) As Bitmap

        Dim objBitmap As New Bitmap(intLargo, 20)
        objBitmap.SetResolution(72, 72)
        Dim objGrafico As Graphics
        objGrafico = Graphics.FromImage(objBitmap)
        objGrafico.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        objGrafico.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        objGrafico.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality


        objGrafico.FillRectangle(Brushes.LightSalmon, 0, 0, intLargo, 20)
        objGrafico.FillRectangle(Brushes.LightGreen, 0, 0, CInt(intLargo * dblPorcentaje), 20)
        objGrafico.DrawString(strTitulo, New Font("Arial", 9), Brushes.Black, 2, 2, StringFormat.GenericDefault)
        objGrafico.DrawLine(Pens.Black, New Point(intLargo - 1, 0), New Point(intLargo - 1, 20))


        Return objBitmap

    End Function

    Public Function CreateCell(ByVal strTexto As String, ByVal strTipo As String, _
                                 ByVal strAlign As String, ByVal intCols As Int16, ByVal intRows As Int16) As TableCell
        Dim celItem As New TableCell
        celItem.Text = strTexto
        celItem.ColumnSpan = intCols
        celItem.RowSpan = intRows
        Select Case strTipo
            Case "Head"
                celItem.CssClass = "GridHeader"
            Case "Foot"
                celItem.CssClass = "GridFooter"
            Case "Item"
                celItem.CssClass = "GridItem"
            Case "Alt"
                celItem.CssClass = "GridAltItem"
            Case "TIT"
                celItem.CssClass = "Titulo"
        End Select
        Select Case strAlign
            Case "L"
                celItem.HorizontalAlign = HorizontalAlign.Left
            Case "R"
                celItem.HorizontalAlign = HorizontalAlign.Right
            Case "C"
                celItem.HorizontalAlign = HorizontalAlign.Center
            Case "J"
                celItem.HorizontalAlign = HorizontalAlign.Justify
        End Select
        Return celItem
    End Function

    Public Function CreateCell(ByVal strTexto As String, ByVal strTipo As String, _
                                 ByVal strAlign As String, ByVal intCols As Int16, ByVal intRows As Int16, ByVal intWidth As Int16) As TableCell
        Dim celItem As New TableCell
        celItem.Text = strTexto
        celItem.ColumnSpan = intCols
        celItem.RowSpan = intRows
        celItem.Width = New Unit(intWidth, UnitType.Pixel)
        Select Case strTipo
            Case "Head"
                celItem.CssClass = "GridHeader"
            Case "Foot"
                celItem.CssClass = "GridFooter"
            Case "Item"
                celItem.CssClass = "GridItem"
            Case "Alt"
                celItem.CssClass = "GridAltItem"
            Case "TIT"
                celItem.CssClass = "Titulo"
        End Select
        Select Case strAlign
            Case "L"
                celItem.HorizontalAlign = HorizontalAlign.Left
            Case "R"
                celItem.HorizontalAlign = HorizontalAlign.Right
            Case "C"
                celItem.HorizontalAlign = HorizontalAlign.Center
            Case "J"
                celItem.HorizontalAlign = HorizontalAlign.Justify
        End Select
        Return celItem
    End Function
End Class
