Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Reflection
Imports System.Collections.Generic
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class Utility
    Inherits System.Web.UI.Page
    Dim objReporte As New ReportDocument()
    Dim reporteExport As New ReportDocument
    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim dt As New DataTable()
        Dim propiedades As PropertyInfo() = GetType(T).GetProperties
        For Each p As PropertyInfo In propiedades
            dt.Columns.Add(p.Name, p.PropertyType)
        Next

        If list.Count > 0 Then



            For Each item As T In list
                Dim row As DataRow = dt.NewRow
                For Each p As PropertyInfo In propiedades
                    row(p.Name) = p.GetValue(item, Nothing)
                Next
                dt.Rows.Add(row)
            Next
        End If
        Return dt
    End Function

    Public Function GenerarReporte(Of T)(ByVal ruta As String, ByVal list As IList(Of T), Optional ByVal formato As String = "") As ReportDocument
        Try
            Dim strRutaBase As String = Server.MapPath(ruta)

            objReporte.Load(strRutaBase)

            objReporte.SetDataSource(list)
            objReporte.Refresh()

            If formato = "X" Then
                objReporte.ExportToHttpResponse(ExportFormatType.Excel, Response, False, "")
            ElseIf formato = "P" Then
                objReporte.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, "")
            End If

            Return objReporte

        Catch ex As Exception

        End Try
    End Function

    Public Function NombreMes(ByVal pint_IdMes As Int16) As String
        Dim strNombreMes() As String = {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"}

        Return strNombreMes(pint_IdMes - 1)
    End Function

    Public Function NombreNumero(ByVal pdblNumero As Double, ByVal pstrMoneda As String) As String
        Dim strUnidades() As String = {"", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE"}
        Dim strDecenas0() As String = {"DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISÉIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE"}
        Dim strDecenas1() As String = {"", "DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA"}
        Dim strCentena() As String = {"", "CIEN", "DOCIENTOS", "TRECIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS"}
        Dim strMiles() As String = {"", "MIL"}
        Dim strMillones() As String = {"MILLÓN", "MILLONES"}
        Dim strBillones() As String = {"BILLÓN", "BILLONES"}
        'Dim strMiles() As String = {"", "MIL", "DOS MIL", "TRES MIL", "CUATRO MIL", "CINCO MIL", "SEIS MIL", "SIETE MIL", "OCHO MIL", "NUEVE MIL", "DIEZ MIL", "ONCE MIL", "DOCE MIL", "TRECE MIL", "CATORCE MIL", "QUINCE MIL", "DIECISÉIS MIL", "DIECISIETE MIL", "DIECIOCHO MIL", "DIECINUEVE MIL"}
        Dim strNombreNumero As String = ""
        Dim strNumero0 As String = pdblNumero.ToString.Trim()
        strNumero0 = Replace(strNumero0, ",", ".")

        Dim strNumero() As String = strNumero0.ToString.Split(".")
        Try
            Dim strDecimal As String = ""
            If CInt(strNumero(1)) > 0 And CInt(strNumero(1)) <= 9 Then
                strDecimal = Format(CInt(strNumero(1)) * 10, "00")
            Else
                strDecimal = Format(CInt(strNumero(1)), "00")
            End If
            strNombreNumero = " CON " & strDecimal & "/100 " & pstrMoneda
        Catch ex As Exception
            strNombreNumero = " CON 00/100 " & pstrMoneda
        End Try

        Dim strNumeros As String = ""
        Dim intPosicion As Int16 = 0
        Dim intDigitos As Integer = Len(strNumero(0))
        For Indice As Int16 = Len(strNumero(0)) - 1 To 0 Step -1
            Dim strNumeral As String = strNumero(0).Substring(Indice, 1)
            strUnidades(1) = "UNO"
            strUnidades(2) = "DOS"
            strUnidades(3) = "TRES"
            strUnidades(6) = "SEIS"
            'strNumeros = CStr(strNumeral) & strNumeros

            '*********************************************************************************************************************
            '-------UNIDAD
            If CInt(strNumeral) > 0 And intPosicion = 0 Then
                If intDigitos > 1 Then

                    Dim int1 As Int16 = strNumero(0).Substring(Indice - 1, 1)
                    Dim int2 As Int16 = CInt(strNumeral)

                    strUnidades(int2) = IIf(int1 = 2 And int2 = 2, "DÓS", strUnidades(int2))
                    strUnidades(int2) = IIf(int1 = 2 And int2 = 3, "TRÉS", strUnidades(int2))
                    strUnidades(int2) = IIf(int1 = 2 And int2 = 6, "SÉIS", strUnidades(int2))

                    If int1 > 2 Then
                        strNombreNumero = " Y " & strUnidades(int2) & strNombreNumero
                    ElseIf int1 = 2 Then
                        strNombreNumero = strUnidades(int2) & strNombreNumero
                    ElseIf int1 <> 1 Then
                        If intDigitos > 2 Then
                            strNombreNumero = " " & strUnidades(int2) & strNombreNumero
                        Else
                            strNombreNumero = " Y " & strUnidades(int2) & strNombreNumero
                        End If
                    End If
                Else
                    strNombreNumero = " " & strUnidades(strNumeral) & strNombreNumero
                End If
            End If
            '*********************************************************************************************************************
            '-------DECENA
            If CInt(strNumeral) > 0 And intPosicion = 1 Then

                Dim int1 As Int16 = CInt(strNumeral)
                Dim int2 As Int16 = strNumero(0).Substring(Indice + 1, 1)

                If int1 > 1 Then
                    strDecenas1(int1) = IIf(int1 = 2 And int2 > 0, "VEINTI", IIf(int1 = 2, "VEINTE", strDecenas1(int1)))
                    strNombreNumero = " " & strDecenas1(int1) & strNombreNumero
                Else
                    strNombreNumero = " " & strDecenas0(int2) & strNombreNumero
                End If
            End If
            '*********************************************************************************************************************
            '-------CENTENA
            If CInt(strNumeral) > 0 And intPosicion = 2 Then
                Dim int1 As Int16 = CInt(strNumeral)
                Dim int2 As Int16 = strNumero(0).Substring(Indice + 1, 1)
                Dim int3 As Int16 = strNumero(0).Substring(Indice + 2, 1)

                strCentena(int1) = IIf(int1 = 1 And (int2 + int3) > 0, "CIENTO", IIf(int1 = 1, "CIEN", strCentena(int1)))
                strNombreNumero = " " & strCentena(int1) & strNombreNumero
            End If
            '*********************************************************************************************************************
            '-------UNIDADES DE MILES
            If CInt(strNumeral) > 0 And intPosicion = 3 Then

                Dim int2 As Int16 = CInt(strNumeral)

                If intDigitos > 4 Then
                    Dim int1 As Int16 = strNumero(0).Substring(Indice - 1, 1)
                    strUnidades(int2) = IIf(int2 = 1, "UN", strUnidades(int2))
                    strUnidades(int2) = IIf(int1 = 2 And int2 = 2, "DÓS", strUnidades(int2))
                    strUnidades(int2) = IIf(int1 = 2 And int2 = 3, "TRÉS", strUnidades(int2))
                    strUnidades(int2) = IIf(int1 = 2 And int2 = 6, "SÉIS", strUnidades(int2))
                    If int1 > 2 Then
                        strNombreNumero = " Y " & strUnidades(int2) & " MIL" & strNombreNumero
                    ElseIf int1 = 2 Then
                        strNombreNumero = strUnidades(int2) & " MIL" & strNombreNumero
                    End If
                Else
                    If int2 > 1 Then
                        strNombreNumero = " " & strUnidades(int2) & " MIL" & strNombreNumero
                    Else
                        strNombreNumero = " MIL" & strNombreNumero
                    End If
                End If
            End If
            '*********************************************************************************************************************
            '-------DECENA DE MILES
            If CInt(strNumeral) > 0 And intPosicion = 4 Then
                Dim int1 As Int16 = CInt(strNumeral)
                Dim int2 As Int16 = strNumero(0).Substring(Indice + 1, 1)

                If int1 > 1 Then
                    strDecenas1(int1) = IIf(int1 = 2 And int2 > 0, "VEINTI", IIf(int1 = 2, "VEINTE", strDecenas1(int1)))
                    If int2 > 0 Then
                        strNombreNumero = " " & strDecenas1(int1) & strNombreNumero
                    Else
                        strNombreNumero = " " & strDecenas1(int1) & " MIL" & strNombreNumero
                    End If
                Else
                    strNombreNumero = " " & strDecenas0(int2) & " MIL" & strNombreNumero
                End If

            End If
            '*********************************************************************************************************************
            '-------CENTENA DE MILES
            If CInt(strNumeral) > 0 And intPosicion = 5 Then
                Dim int1 As Int16 = CInt(strNumeral)
                Dim int2 As Int16 = strNumero(0).Substring(Indice + 1, 1) ' CENTENA MILES
                Dim int3 As Int16 = strNumero(0).Substring(Indice + 2, 1) ' UNIDAD MILES

                strCentena(int1) = IIf(int1 = 1 And (int2 + int3) > 0, "CIENTO", IIf(int1 = 1, "CIEN", strCentena(int1)))

                If int2 > 0 Or int3 > 0 Then
                    strNombreNumero = " " & strCentena(int1) & strNombreNumero
                Else
                    strNombreNumero = " " & strCentena(int1) & " MIL" & strNombreNumero
                End If
            End If
            '*********************************************************************************************************************
            '-------UNIDAD DE MILLÓN
            If CInt(strNumeral) > 0 And intPosicion = 6 Then
                Dim UM As String = " MILLONES"
                Dim int2 As Int16 = CInt(strNumeral)
                If int2 = 1 Then
                    UM = " MILLÓN"
                End If
                strUnidades(int2) = IIf(int2 = 1, "UN", strUnidades(int2))

                If intDigitos > 7 Then
                    Dim int1 As Int16 = strNumero(0).Substring(Indice - 1, 1) ' DECENA DE MILLÓN
                    If int2 = 1 Then
                        UM = " MILLONES"
                    End If
                    strUnidades(int2) = IIf(int1 = 2 And int2 = 2, "DÓS", strUnidades(int2))
                    strUnidades(int2) = IIf(int1 = 2 And int2 = 3, "TRÉS", strUnidades(int2))
                    strUnidades(int2) = IIf(int1 = 2 And int2 = 6, "SÉIS", strUnidades(int2))
                    If int1 > 2 Then
                        strNombreNumero = " Y " & strUnidades(int2) & UM & strNombreNumero
                    ElseIf int1 = 2 Then
                        strNombreNumero = strUnidades(int2) & UM & strNombreNumero
                    End If
                Else
                    strNombreNumero = " " & strUnidades(int2) & UM & strNombreNumero
                End If
            End If
            '*********************************************************************************************************************
            '-------DECENA DE MILLÓN
            If CInt(strNumeral) > 0 And intPosicion = 7 Then
                Dim DM As String = " MILLONES"
                Dim int1 As Int16 = CInt(strNumeral)
                Dim int2 As Int16 = strNumero(0).Substring(Indice + 1, 1) ' UNIDAD DE MILLÓN
                If int1 > 1 Then
                    strDecenas1(int1) = IIf(int1 = 2 And int2 > 0, "VEINTI", IIf(int1 = 2, "VEINTE", strDecenas1(int1)))
                    If int2 > 0 Then
                        strNombreNumero = " " & strDecenas1(int1) & strNombreNumero
                    Else
                        strNombreNumero = " " & strDecenas1(int1) & DM & strNombreNumero
                    End If
                Else
                    strNombreNumero = " " & strDecenas0(int2) & DM & strNombreNumero
                End If
            End If
            '*********************************************************************************************************************
            '-------CENTENA DE MILLÓN
            If CInt(strNumeral) > 0 And intPosicion = 8 Then
                Dim CM As String = " MILLONES"
                Dim int1 As Int16 = CInt(strNumeral)
                Dim int2 As Int16 = strNumero(0).Substring(Indice + 1, 1) ' CENTENA MILLÓN
                Dim int3 As Int16 = strNumero(0).Substring(Indice + 2, 1) ' UNIDAD MILLÓN
                strCentena(int1) = IIf(int1 = 1 And (int2 + int3) > 0, "CIENTO", IIf(int1 = 1, "CIEN", strCentena(int1)))

                If int2 > 0 Or int3 > 0 Then
                    strNombreNumero = " " & strCentena(int1) & strNombreNumero
                Else
                    strNombreNumero = " " & strCentena(int1) & CM & strNombreNumero
                End If
            End If
            intPosicion = intPosicion + 1
        Next
        Return Right(strNombreNumero, Len(strNombreNumero) - 1)

    End Function

    Private _strIdcuenta As String
    Private _strNomCuenta As String
    Public Property NomCuenta() As String
        Get
            Return _strNomCuenta
        End Get
        Set(ByVal value As String)
            _strNomCuenta = value
        End Set
    End Property

    Public Property IdCuenta() As String
        Get
            Return _strIdcuenta
        End Get
        Set(ByVal value As String)
            _strIdcuenta = value
        End Set
    End Property

    Private _strTipoOp As String
    Public Property TipoOp() As String
        Get
            Return _strTipoOp
        End Get
        Set(ByVal value As String)
            _strTipoOp = value
        End Set
    End Property

End Class
