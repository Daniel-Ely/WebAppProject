$(document).ready(function(){

    $("#get-Data-Form").submit(function(e){

        var content = tinymce.get("mytextarea").getContent();

        $("#dataConteiner").html(content);

		return false;

	});

});