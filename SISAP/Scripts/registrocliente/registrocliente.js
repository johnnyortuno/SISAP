function solonumeros(e) {
	var key = window.Event ? e.which : e.keyCode
	return (key >= 48 && key <= 57)
}
function ValidaLongitud(campo, longitudMaxima) {
	try {
		if (campo.value.length > (longitudMaxima - 1))
			return false;
		else
			return true;
	} catch (e) {
		return false;
	}
}

























//$("#btnSave").on("click", function () {

//	let codigo = $("#ctxtCodigo").value();
//	let nombre = $("#ctxtNombre").value();
//	let apellido = $("#ctxtApellido").value();


//	if (codigo == "") {

//		$("#msjcodigo").html("* El campo de codigo no debe estar vacio").css("color", "red");
//		$("#ctxtCodigo").css("border-color", "red");
//		$("#ctxtCodigo").focus();
//	} else if (nombre == "") {
//		$("#msjnombre").html("* El campo de nombre no debe estar vacio").css("color", "red");
//		$("#ctxtNombre").css("border-color", "red");
//		$("#ctxtNombre").focus();
		
//	} else if (apellido == "") {

//		$("#msjapellido").html("* El campo de nombre no debe estar vacio").css("color", "red");
//		$("#ctxtApellido").css("border-color", "red");
//		$("#ctxtApellido").focus();

//	}
	
//})
