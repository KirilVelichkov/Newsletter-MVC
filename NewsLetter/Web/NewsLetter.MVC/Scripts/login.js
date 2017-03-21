$('#login-modal').click();

$('#modal-close-button').on('click', () => {
    $('#loginModal').modal('hide');
    $('.modal-backdrop').hide();
    window.location = "/home";
});