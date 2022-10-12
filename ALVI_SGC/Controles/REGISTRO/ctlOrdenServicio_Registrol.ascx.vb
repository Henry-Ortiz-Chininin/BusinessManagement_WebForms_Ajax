
Partial Class Controles_REGISTRO_ctlOrdenServicio_Registrol
    Inherits System.Web.UI.UserControl

    Public Event Cerrado()

    Public WriteOnly Property Orden As EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio
        Set(ByVal value As EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio)
            Dim dtmFecha As DateTime
            Dim am_pm As MKB.TimePicker.TimeSelector.AmPmSpec
            txtCodigo.Text = value.IdOrdenServicio
            txtFecha.Text = value.FechaEmision
            ddlDepartamento.SelectedValue = value.IdDepartamento
            ctlCliente.IdCliente = value.IdCliente
            ctlCliente.BuscarId()
            txtLugarOperacion.Text = value.LugarOperacion
            txtTrabSolicitado.Text = value.TrabaSolicitante
            txtTelefono.Text = value.Telefono
            txtTrabEfectuado.Text = value.TrabajoEfectuado
            txtOperador.Text = value.Operador
            txtRiger.Text = value.Riger
            txtAyudante.Text = value.Ayudante
            ddlMoneda.SelectedValue = value.IdMoneda
            ddlEstado.SelectedValue = value.Estado
            txtObservacion.Text = value.Observacion
            ddlTipoServicio.SelectedValue = value.IdTipoServicio
            txtPlacaGrua.Text = value.Placa_Grua
            '------Convierte de Int a TimeSelector Salida Base
            dtmFecha = Right(ConversionTimeSeleccte(value.HoraSalidaBase), 13)
            If dtmFecha.Hour < 12 Then
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM
            Else
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM
            End If
            timSalidaBase.SetTime(dtmFecha.Hour, dtmFecha.Minute, am_pm)

            '------Convierte de Int a TimeSelector Llegada Obra
            dtmFecha = Right(ConversionTimeSeleccte(value.HoraLlegadaObra), 13)
            If dtmFecha.Hour < 12 Then
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM
            Else
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM
            End If
            timLlegadaObra.SetTime(dtmFecha.Hour, dtmFecha.Minute, am_pm)

            '------Convierte de Int a TimeSelector Inicio Operación
            dtmFecha = ConversionTimeSeleccte(value.HoraInicioOperacion)
            If dtmFecha.Hour < 12 Then
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM
            Else
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM
            End If

            timInicioOperacion.SetTime(dtmFecha.Hour, dtmFecha.Minute, am_pm)

            '------Convierte de Int a TimeSelector Termino Operación
            dtmFecha = ConversionTimeSeleccte(value.HoraTerminoOperacion)
            If dtmFecha.Hour < 12 Then
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM
            Else
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM
            End If

            timTerminoOperacion.SetTime(dtmFecha.Hour, dtmFecha.Minute, am_pm)

            '------Convierte de Int a TimeSelector Salida Obra
            dtmFecha = ConversionTimeSeleccte(value.HoraSalidaObra)
            If dtmFecha.Hour < 12 Then
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM
            Else
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM
            End If
            timSalidaObra.SetTime(dtmFecha.Hour, dtmFecha.Minute, am_pm)

            '------Convierte de Int a TimeSelector Llegada Base
            dtmFecha = ConversionTimeSeleccte(value.HoraLlegadaBase)
            If dtmFecha.Hour < 12 Then
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM
            Else
                am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM
            End If
            timLlegoBase.SetTime(dtmFecha.Hour, dtmFecha.Minute, am_pm)

            txtTarifa.Text = value.TarifaHora

            CalcularTiempos()
        End Set
    End Property
    Private Sub MostrarMensaje(ByVal _pstrMensaje As String)
        If _pstrMensaje <> "" Then
            Parent.Page.ClientScript.RegisterStartupScript(Page.ClientScript.GetType(), "ALERTA", "<script language='javascript'>alert('" & _pstrMensaje & "');</script>")
        End If
    End Sub
    Public Function ConversionTimeSeleccte(ByVal _pintSegundos As Integer) As DateTime
        Dim strHoras As String = "0"
        Dim strMinutos As String = "0"
        Dim strAmPm As String = "0"
        Dim strFecha As String = ""
        Dim intLong As Integer = Len(CStr(Right("0000" & CStr(_pintSegundos), 4)))
        Dim strTiempo As String = CStr(Right("0000" & CStr(_pintSegundos), 4))
        If intLong > 2 Then
            strHoras = strTiempo.ToString.Substring(0, 2)
        End If
        If intLong > 4 Then
            strMinutos = strTiempo.ToString.Substring(2, 2)
        End If
        If CInt(strHoras) >= 12 Then
            strAmPm = "PM"
        Else
            strAmPm = "AM"
        End If
        strFecha = CStr(Right("00" & strHoras, 2)) & ":" & CStr(Right("00" & strMinutos, 2)) & " " & strAmPm
        Dim dt As DateTime = DateTime.Parse(Right(strFecha, 8))
        Return dt
    End Function
    Private Sub BinDepartamento(ByVal pddlAtributo As DropDownList)
        Dim LN_Departamento As New LN_ALVINET_CONTA.GENERAL.LN_Departamento

        If LN_Departamento.Listar() = True Then
            pddlAtributo.Items.Clear()

            pddlAtributo.DataTextField = "NomDepartamento"
            pddlAtributo.DataValueField = "IdDepartamento"

            pddlAtributo.DataSource = LN_Departamento.lstDepartamento
            pddlAtributo.DataBind()
        End If
        pddlAtributo.Items.Insert(0, New ListItem("Seleccionar", 0))
        pddlAtributo.ToolTip = "Seleccionar Departamento"
        pddlAtributo.SelectedIndex = 1

    End Sub
    Public Sub MostrarMensje(ByVal _pstrMensaje As String)
        If _pstrMensaje <> "" Then
            Page.ClientScript.RegisterStartupScript(GetType(ClientScriptManager), "ALERTA", "<script language='javascript'>alert('" & _pstrMensaje & "');</script>")
        End If
    End Sub
    Protected Function Registrar() As Boolean
        Dim LN_OrdenServicio As New LN_ALVINET_CONTA.OPERACION.LN_OrdenServicio
        Dim EN_OrdenServicio As New EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio
        Dim _bolValidar As Boolean = False

        EN_OrdenServicio = CalcularTiempos()
        EN_OrdenServicio.IdOrdenServicio = txtCodigo.Text.ToString.Trim()
        EN_OrdenServicio.FechaEmision = txtFecha.Text.ToString.Trim()
        EN_OrdenServicio.IdDepartamento = ddlDepartamento.SelectedValue
        EN_OrdenServicio.IdCliente = ctlCliente.IdCliente
        EN_OrdenServicio.LugarOperacion = txtLugarOperacion.Text.ToString.Trim()
        EN_OrdenServicio.TrabaSolicitante = txtTrabSolicitado.Text.ToString.Trim()
        EN_OrdenServicio.Telefono = txtTelefono.Text
        EN_OrdenServicio.TrabajoEfectuado = txtTrabEfectuado.Text.ToString.Trim()
        EN_OrdenServicio.Operador = txtOperador.Text.ToString.Trim()
        EN_OrdenServicio.Riger = txtRiger.Text.ToString.Trim()
        EN_OrdenServicio.Ayudante = txtAyudante.Text.ToString.Trim()
        EN_OrdenServicio.Observacion = txtObservacion.Text
        EN_OrdenServicio.TipoServicio = ddlTipoServicio.SelectedValue
        EN_OrdenServicio.Estado = ddlEstado.SelectedValue
        EN_OrdenServicio.Placa_Grua = txtPlacaGrua.Text.ToString.Trim()
        EN_OrdenServicio.IdMoneda = ddlMoneda.SelectedValue
        EN_OrdenServicio.Igv = 0

        LN_OrdenServicio.entDato = EN_OrdenServicio

        If LN_OrdenServicio.Registrar = True Then
            MostrarMensaje("Registro exitoso")
            If txtCodigo.Text = "" Then
                lblMensaje.Text = "Nuevo Registro Código: " & LN_OrdenServicio.entDato.IdOrdenServicio
            Else
                lblMensaje.Text = "Registro actualizado Código: " & LN_OrdenServicio.entDato.IdOrdenServicio
            End If
            limpiar()
            _bolValidar = True
        Else
            MostrarMensaje(LN_OrdenServicio.entDato.Mensaje)
        End If
        Return _bolValidar
    End Function
    Public Sub limpiar()
        txtCodigo.Text = ""
        ddlDepartamento.SelectedIndex = 0
        Horas()
        txtTiempoRecorrido.Text = ""
        txtTiempoTrabajo.Text = ""
        txtTiempoTotal.Text = ""
        txtTotalFacturar.Text = ""
        txtLugarOperacion.Text = ""
        txtTrabSolicitado.Text = ""
        txtTelefono.Text = ""
        txtTrabEfectuado.Text = ""
        txtOperador.Text = ""
        txtRiger.Text = ""
        txtAyudante.Text = ""
        txtTarifa.Text = ""
        txtObservacion.Text = ""
        txtPlacaGrua.Text = ""
        BinDepartamento(ddlDepartamento)
        ddlEstado.SelectedIndex = 0
        BindMoneda(ddlMoneda)
        ctlCliente.Limpia()
        ddlTipoServicio.SelectedIndex = 0
    End Sub
    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        limpiar()
        RaiseEvent Cerrado()
    End Sub
    Protected Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
        Registrar()
    End Sub
    Protected Sub btnTerminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTerminar.Click
        If Registrar() = True Then
            limpiar()
            RaiseEvent Cerrado()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Horas()
            BinDepartamento(ddlDepartamento)
            BindMoneda(ddlMoneda)
        End If
    End Sub
    Private Sub BindMoneda(ByRef pddlAtributos As DropDownList)
        Dim objAtributos As New ALVI_LOGIC.Maestros.Administracion.Moneda
        pddlAtributos.Items.Clear()
        If objAtributos.Listar() = True Then
            pddlAtributos.DataValueField = "var_IdMoneda"
            pddlAtributos.DataTextField = "var_DesMoneda"
            pddlAtributos.DataSource = objAtributos.Datos
            pddlAtributos.DataBind()
        End If
        pddlAtributos.Items.Insert(0, New ListItem("Seleccionar", ""))
        pddlAtributos.SelectedIndex = 0
    End Sub
    Private Sub Horas()
        Dim dt As DateTime = DateTime.Parse("00:00 AM")
        Dim am_pm As MKB.TimePicker.TimeSelector.AmPmSpec
        If dt.ToString("tt") = "AM" Then
            am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.AM
        Else
            am_pm = MKB.TimePicker.TimeSelector.AmPmSpec.PM
        End If
        timSalidaBase.SetTime(dt.Hour, dt.Minute, am_pm)
        timLlegadaObra.SetTime(dt.Hour, dt.Minute, am_pm)
        timInicioOperacion.SetTime(dt.Hour, dt.Minute, am_pm)
        timTerminoOperacion.SetTime(dt.Hour, dt.Minute, am_pm)
        timSalidaObra.SetTime(dt.Hour, dt.Minute, am_pm)
        timLlegoBase.SetTime(dt.Hour, dt.Minute, am_pm)

        txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
    End Sub
    Private Function CalcularTiempos() As EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio
        Dim EN_OrdenServicio As New EN_ALVINET_CONTA.OPERACION.EN_OrdenServicio
        Dim intSegundos As Integer = 0
        Dim intSegundosTotal As Integer = 0
        Dim intMinutos As Integer = 0
        Dim intHoras As Integer = 0
        Dim intSegundosIni As Integer = 0
        Dim intSegundosFin As Integer = 0


        '--->> Calcular Tiempo Recorrido ----------------------------------------------------------------------------------------------------
        '--->>  Salida de Obra - Salida de Base ------------------------------------------------------- 
        intSegundosIni = timSalidaBase.Minute * 60 + timSalidaBase.Hour * 3600
        intSegundosFin = timLlegadaObra.Minute * 60 + timLlegadaObra.Hour * 3600

        If intSegundosFin < intSegundosIni Then
            MostrarMensaje("La hora de llegada a la obra es incorrecta respecto a la hora de salida de la base")
            Return EN_OrdenServicio
        End If
        EN_OrdenServicio.HoraSalidaBase = intSegundosIni
        EN_OrdenServicio.HoraLlegadaObra = intSegundosFin

        intSegundos = intSegundosFin - intSegundosIni

        '--->>  Salida de Obra - Llegada a Base ------------------------------------------------------- 
        intSegundosIni = timSalidaObra.Minute * 60 + timSalidaObra.Hour * 3600
        intSegundosFin = timLlegoBase.Minute * 60 + timLlegoBase.Hour * 3600

        If intSegundosFin < intSegundosIni Then
            MostrarMensaje("La hora de llegada a la base es incorrecta respecto a la hora de salida de la obra")
            Return EN_OrdenServicio
        End If

        EN_OrdenServicio.HoraSalidaObra = intSegundosIni
        EN_OrdenServicio.HoraLlegadaBase = intSegundosFin

        intSegundos += intSegundosFin - intSegundosIni
        intSegundosTotal = intSegundos
        
        '--->> Convertir a horas y minutos

        If (intSegundos Mod 3600) < intSegundos Then
            intHoras += Int(CDec((intSegundos / 3600)))
        End If

        If (intSegundos Mod 3600) > 59 Then
            intMinutos += (intSegundos Mod 3600) / 60
        End If

        '--->> Mostrar En el Text Box -> txtTiempoRecorrido---------------------------------------------
        If intHoras > 1 Then
            If intMinutos > 1 Then
                txtTiempoRecorrido.Text = intHoras & " Horas y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoRecorrido.Text = intHoras & " Horas"
            Else
                txtTiempoRecorrido.Text = intHoras & " Horas y " & intMinutos & " Minuto"
            End If
        ElseIf intHoras = 0 Then
            If intMinutos > 1 Then
                txtTiempoRecorrido.Text = intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoRecorrido.Text = ""
            Else
                txtTiempoRecorrido.Text = intMinutos & " Minuto"
            End If
        Else
            If intMinutos > 1 Then
                txtTiempoRecorrido.Text = intHoras & " Hora y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoRecorrido.Text = intHoras & " Hora"
            Else
                txtTiempoRecorrido.Text = intHoras & " Hora y " & intMinutos & " Minuto"
            End If
        End If

        intSegundos = 0
        intHoras = 0
        intMinutos = 0
        intSegundosIni = 0
        intSegundosIni = 0

        '--->> Tiempo de Operacion-----------------------------------------------------------------------------------------------------------
        '--->>  Termino de Operación - Inicio de Operación------------------------------------------------------- 
        intSegundosIni = timInicioOperacion.Minute * 60 + timInicioOperacion.Hour * 3600
        intSegundosFin = timTerminoOperacion.Minute * 60 + timTerminoOperacion.Hour * 3600

        If intSegundosFin < intSegundosIni Then
            MostrarMensaje("La hora de termino de operación es incorrecta respecto a la hora de inicio de operación")
            Return EN_OrdenServicio
        End If
        EN_OrdenServicio.HoraInicioOperacion = intSegundosIni
        EN_OrdenServicio.HoraTerminoOperacion = intSegundosFin

        intSegundos = intSegundosFin - intSegundosIni
        intSegundosTotal += intSegundos
        '--->> Convertir a horas y minutos

        If (intSegundos Mod 3600) < intSegundos Then
            intHoras = Int(CDec((intSegundos / 3600)))
        End If

        If (intSegundos Mod 3600) > 59 Then
            intMinutos = (intSegundos Mod 3600) / 60
        End If

        '--->> Mostrar En el Text Box -> txtTiempoTrabajo---------------------------------------------
        If intHoras > 1 Then
            If intMinutos > 1 Then
                txtTiempoTrabajo.Text = intHoras & " Horas y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTrabajo.Text = intHoras & " Horas"
            Else
                txtTiempoTrabajo.Text = intHoras & " Horas y " & intMinutos & " Minuto"
            End If
        ElseIf intHoras = 0 Then
            If intMinutos > 1 Then
                txtTiempoTrabajo.Text = intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTrabajo.Text = ""
            Else
                txtTiempoTrabajo.Text = intMinutos & " Minuto"
            End If
        Else
            If intMinutos > 1 Then
                txtTiempoTrabajo.Text = intHoras & " Hora y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTrabajo.Text = intHoras & " Hora"
            Else
                txtTiempoTrabajo.Text = intHoras & " Hora y " & intMinutos & " Minuto"
            End If
        End If

        intSegundos = 0
        intHoras = 0
        intMinutos = 0
        '--->> Tiempo de Total-----------------------------------------------------------------------------------------------------------
        '--->> Convertir a horas y minutos
        If (intSegundosTotal Mod 3600) < intSegundosTotal Then
            intHoras = Int(CDec((intSegundosTotal / 3600)))
        End If

        If (intSegundosTotal Mod 3600) > 59 Then
            intMinutos = (intSegundosTotal Mod 3600) / 60
        End If

        '--->> Mostrar En el Text Box -> txtTiempoTotal---------------------------------------------
        If intHoras > 1 Then
            If intMinutos > 1 Then
                txtTiempoTotal.Text = intHoras & " Horas y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTotal.Text = intHoras & " Horas"
            Else
                txtTiempoTotal.Text = intHoras & " Horas y " & intMinutos & " Minuto"
            End If
        ElseIf intHoras = 0 Then
            If intMinutos > 1 Then
                txtTiempoTotal.Text = intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTotal.Text = ""
            Else
                txtTiempoTotal.Text = intMinutos & " Minuto"
            End If
        Else
            If intMinutos > 1 Then
                txtTiempoTotal.Text = intHoras & " Hora y " & intMinutos & " Minutos"
            ElseIf intMinutos = 0 Then
                txtTiempoTotal.Text = intHoras & " Hora"
            Else
                txtTiempoTotal.Text = intHoras & " Hora y " & intMinutos & " Minuto"
            End If
        End If
        '--->> Calcular Total a Pagar
        If txtTarifa.Text.ToString() <> "" Then
            txtTotalFacturar.Text = Format((intHoras * txtTarifa.Text) + ((intMinutos / 60) * txtTarifa.Text), "#,##0.0000")
            EN_OrdenServicio.TarifaHora = txtTarifa.Text
        End If
        Return EN_OrdenServicio
    End Function
    Protected Sub txtTarifa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTarifa.TextChanged
        CalcularTiempos()
    End Sub
End Class
