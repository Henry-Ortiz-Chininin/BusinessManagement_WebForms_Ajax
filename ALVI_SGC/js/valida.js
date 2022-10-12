    function IsNumeric(input)
    {
        return (input - 0) == input && input.length > 0;
    }

    var matrizTelefono = "0123456789/-* ()#";
    var matrizFecha = "0123456789/:";
    var matrizNumber = ",0123456789";
	var matrizInteger = "0123456789";
	var matrizHora = "0123456789:";
	var matrizAlfa = "abcdefghijklmnopqrstuwxvyzABCDEFGHIJKLMNOPQRSTVUWXYZ_ %";
	var matrizAlfaNumerico = "abcdefghijklmnopqrstuwxvyzABCDEFGHIJKLMNOPQRSTVUWXYZ_0123456789. /-#%";
	var matrizAlfaEmpresa = "abcdefghijklmnopqrstuwxvyzABCDEFGHIJKLMNOPQRSTVUWXYZ_0123456789. /&-_#%";
	var matrizClave = "abcdefghijklmnopqrstuwxvyzABCDEFGHIJKLMNOPQRSTVUWXYZ_0123456789_";
	var matrizEmail = "abcdefghijklmnopqrstuwxvyzABCDEFGHIJKLMNOPQRSTVUWXYZ_0123456789-.@";	
	var arrKeyCode = [225,233,237,243,250,193,201,205,211,218,241,209];
	
	function isEmailAddress(theElement)
	{
		var s = theElement.value;
		var filter=/^[A-Za-z][A-Za-z0-9_.\-]*@[A-Za-z0-9_.\-]+\.[A-Za-z0-9_.]+[A-za-z]$/;
		if (s.length == 0 ) return true;
		if (filter.test(s)){
			return true;
		}else{		
			theElement.focus();
			return false;
		}

	}	

	function Valida(evt, Tipo)
	{
		var matriz = "";
		switch (Tipo)
		{
			case "INT":
				matriz = matrizInteger;
			break;
			case "ALF":
				matriz = matrizAlfa;
			break;
			case "TEL":
				matriz = matrizTelefono;
			break;
			case "ALN":
				matriz = matrizAlfaNumerico;
			break;
			case "NUM":
				matriz = matrizNumber;
			break;
			case "HOR":
				matriz = matrizHora;
			break;
			case "EMP":
				matriz = matrizAlfaEmpresa;
			break;
			case "EML":
				matriz = matrizEmail;
			break;
			case "LOG":
				matriz = matrizClave;
				break;
            case "FEC":
                matriz = matrizFecha;
                break;
		}
		
		evt = (evt) ? evt : event;
		var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : ((evt.which) ? evt.which : 0));
		var schar = String.fromCharCode(charCode);

		if(charCode<40){ return true; }
		
		if(Tipo=='ALF' || Tipo=='ALN' || Tipo=='EML' || Tipo=='EMP')
		{ 
			for(x=0;x<arrKeyCode.length;x++)
			{
				if(arrKeyCode[x]==charCode)
				{
					return true;
				}
			}
		}
		return ExistIntoMatriz(schar, matriz); 
	}
	
	function isVarType(strValue, Tipo)
	{
		var matriz = "";
		switch (Tipo)
		{
			case "INT":
				matriz = matrizInteger;
			    break;
			case "ALF":
				matriz = matrizAlfa;
			break;
			case "TEL":
				matriz = matrizTelefono;
			break;
			case "ALN":
				matriz = matrizAlfaNumerico;
			    break;
			case "HOR":
				matriz = matrizHora;
			    break;
			case "NUM":
				matriz = matrizNumber;
			break;
			    case "EMP":
				matriz = matrizAlfaEmpresa;
			    break;
			case "EML":
				matriz = matrizEmail;
			    break;
			case "LOG":
				matriz = matrizClave;
				break;
            case "FEC":
                matriz = matrizFecha;
                break;
		}
		
		for(x=0;x<strValue.length;x++)
		{
			var charCode = strValue.charAt(x).charCodeAt(0);
			if(Tipo=='ALF' || Tipo=='ALN' || Tipo=='EML' || Tipo=='EMP')
			{ 
				for(y=0;y<arrKeyCode.length;y++)
				{
					if(arrKeyCode[y]==charCode)
					{
						return true;
					}
				}
			}

			if(ExistIntoMatriz(strValue.charAt(x), matriz)==false)
			{
				return false;
			}
		}
		return true;
	}

	function ExistIntoMatriz(Valor, Matriz)
	{
		for(y=0;y<Matriz.length;y++)
		{
			if(Matriz.charAt(y)==Valor)
			{
				return true;
			}
		}
		return false;
	}

	function validadigito(obj, tipo)
	{
		if (isVarType(obj.value, tipo)==false){ obj.value=""; }
	}