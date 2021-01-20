var path_to_delete;
$(".Delete").click(function(e) {
        path_to_delete = $(this).data('path');});

    $('#btnContinueDelete').click(function () {
        window.location = path_to_delete;});
