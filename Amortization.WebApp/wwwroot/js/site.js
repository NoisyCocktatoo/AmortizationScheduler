function LoadPage(link) {
    $("#holder").load(link, function () { });
}

function LoadPageModal(link, holder, func) {
    $(`#${holder}`).load(link, func);
}

$('.vmenu').click(function (e) {
    var link = $(this).attr('menuvalue');
    LoadPage(link);
})

function PostData(data, postUrl, successFunc) {
    $.ajax({
        type: "POST",
        url: postUrl,
        data: data,
        dataType: "json",
        headers: { 'RequestVerificationToken': tkn_ },
        encode: true,
        beforeSend: function () {
            $('.loading').show();
        },
        complete: function () {

        },
    }).done(function (data) {
        $('.loading').hide();
        successFunc(data);
    });
}
let tkn_ = $("input[name=__RequestVerificationToken]").val();

function DeleteData(data, postUrl, successFunc) {
    $.ajax({
        type: "POST",
        url: postUrl,
        data: data,
        dataType: "json",
        headers: { 'RequestVerificationToken': tkn_ },
        encode: true,
        beforeSend: function () {
            $('.loading').show();
        },
        complete: function () {

        },
    }).done(function (data) {
        $('.loading').hide();
        successFunc(data);
    });
}

(function () {
    $('.loading').hide();
})();
