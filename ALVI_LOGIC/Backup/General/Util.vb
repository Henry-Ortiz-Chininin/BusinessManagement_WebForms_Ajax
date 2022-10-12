Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Text

Namespace General

    Public Class Util
        Public Function GeneraXML(ByVal dtbDatos As Data.DataTable) As String
            Dim strBuilder As New stringbuilder
            strBuilder.AppendLine("<root>")
            For Each dtrItem As Data.DataRow In dtbDatos.Rows
                strBuilder.Append("<item>")
                For Each colItem As Data.DataColumn In dtrItem.Table.Columns
                    strBuilder.Append("<" & colItem.ColumnName & ">" & dtrItem(colItem.ColumnName) & "</" & colItem.ColumnName & ">")
                Next
                strBuilder.AppendLine("</item>")
            Next
            strBuilder.AppendLine("</root>")

            Return strBuilder.ToString
        End Function

        Public Function NombreMes(ByVal pint_IdMes As Int16) As String
            Dim strNombreMes() As String = {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"}

            Return strNombreMes(pint_IdMes - 1)
        End Function

        Public Function NombreNumero(ByVal pdblNumero As Double) As String
            Dim strUnidades() As String = {"", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE"}
            Dim strDecenas() As String = {"", "DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA"}
            Dim strCientos() As String = {"", "CIEN", "DOCIENTOS", "TRECIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS"}
            Dim strMiles() As String = {"", "MIL", "DOS MIL", "TRES MIL", "CUATRO MIL", "CINCO MIL", "SEIS MIL", "SIETE MIL", "OCHO MIL", "NUEVE MIL"}

            Dim strNumero() As String = pdblNumero.ToString.Split(".")
            Dim strDecimal As String = Format(CInt(strNumero(1)), "00")
            Dim strNombreNumero As String = " CON " & strDecimal & "/100 NUEVOS SOLES"

            Dim intPosicion As Int16 = 0
            For Indice As Int16 = Len(strNumero(0)) - 1 To 0 Step -1
                Dim strNumeral As String = strNumero(0).Substring(Indice, 1)

                If strNumeral > 0 AndAlso intPosicion = 0 Then
                    strNombreNumero = " Y " & strUnidades(strNumeral) & " " & strNombreNumero
                End If
                If strNumeral > 0 AndAlso intPosicion = 1 Then
                    strNombreNumero = strDecenas(strNumeral) & " " & strNombreNumero
                End If
                If strNumeral > 0 AndAlso intPosicion = 2 Then
                    strNombreNumero = strCientos(strNumeral) & " " & strNombreNumero
                End If
                If strNumeral > 0 AndAlso intPosicion = 3 Then
                    strNombreNumero = strMiles(strNumeral) & " " & strNombreNumero
                End If

                intPosicion = intPosicion + 1
            Next

            Return strNombreNumero

        End Function
    End Class
End Namespace