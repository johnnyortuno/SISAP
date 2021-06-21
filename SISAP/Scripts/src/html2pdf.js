function generatePDF() {
	const element = document.getElementById("allGrilla");
	html2pdf()
		.from(element)
		.save();

}