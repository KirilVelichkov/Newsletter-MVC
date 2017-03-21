$('#register-modal').click();

$('#modal-close-button').on('click', () => {
    $('#registerModal').modal('hide');
    $('.modal-backdrop').hide();
    window.location = "/home";
});