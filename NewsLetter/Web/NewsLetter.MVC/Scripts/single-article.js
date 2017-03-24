
$('.da-image-container').on('mouseenter', function () {
    $(this).addClass('image-large');
});

$('.da-image-container').on('mouseout', function () {
    $(this).removeClass('image-large');
});



function clearForm() {
    $('#comment-box').val('');
    $('.reply-textarea').val('');
}