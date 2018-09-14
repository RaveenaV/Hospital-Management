//$("#menus .menu").click(function (evt) {
//	switch (evt.target.id) {
//		case "addStaff":
//			$("#menuContent").load('/Staff/Create');
//			break;
//		case "addPatient": 
//			$("#menuContent").load('/Patient/Create');
//			break;
//		case "patientAppointment":
//			$("#menuContent").load('/Patient/PatientAppointment');
//			break;
//		case "patientSearch":
//			$("#menuContent").load('/Patient/PatientSearch');
//			break;
//		default: $("#menuContent").load('/Patient/PatientSearch');
//		}
//});
$("#PatientKey").change(function () {
	if ($('#PatientKey').val() !== "") {
		$("#PatientName").prop("disabled", true);
		$("#PatientLastName").prop("disabled", true);
	}
	else {
		$("#PatientName").prop("disabled", false);
		$("#PatientLastName").prop("disabled", false);}
});
$("#PatientName , #PatientLastName").change(function () {
	if ($('#PatientName').val() !== "" || $('#PatientLastName').val() !== "") {
		$("#PatientKey").prop("disabled",true);
	}
	else {
		$("#PatientSKey").prop("disabled", false);
	}
});

$('.nav-pills a').click(function (e) {
	e.preventDefault();
	$(this).tab('show');
	//$(this).addClass('active');
});

//$('#' + '@ViewBag.ActiveMenu').addClass('active');