$('.tab').on('click', function (evt) {

    $('.tab').each(function () {
        $(this).removeClass('tab-active');
    });

    $(this).addClass('tab-active');

    let index = $('.tab').index(this);

    $('.tab-content').addClass('hidden');

    $('.tab-content').eq(index).removeClass('hidden');
});