function Messagebox(title, message, successFunc) {
    var swalWithBootstrapButtons = Swal.mixin({
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: title,
        text: message,
        type: 'question',
        showCancelButton: true,
        scrollbarPadding: false,
        confirmButtonText: 'Yes',
        cancelButtonText: 'No',
        reverseButtons: true,
        allowOutsideClick: false,
        customClass: { 'confirmButton': 'btn btn-secondary rounded-4', 'cancelButton': 'btn btn-light rounded-4 me-3' }
    }).then(function (result) {
        if (result.value) {
            successFunc();
        } else if (result.dismiss === Swal.DismissReason.cancel) {

        }
    });
};

function Reloginbox(title, message, successFunc) {
    var swalWithBootstrapButtons = Swal.mixin({
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: title,
        text: message,
        type: 'question',
        scrollbarPadding: false,
        confirmButtonText: 'Relogin',
        reverseButtons: true,
        allowOutsideClick: false,
        customClass: { 'confirmButton': 'btn btn-danger rounded-4' }
    }).then(function (result) {
        if (result.value) {
            successFunc();
        } else if (result.dismiss === Swal.DismissReason.cancel) {

        }
    });
};


function ShowWarning(title, message) {
    $.aceToaster.add({
        placement: 'tr',
        body: "<div class='bgc-orange-d1 text-white px-3 pt-3'>\
                        <div class='border-2 brc-white px-3 py-25 radius-round'>\
                            <i class='fa fa-times text-150'></i>\
                        </div>\
                    </div>\
                    <div class='p-3 mb-0 flex-grow-1'>\
                        <h4 class='text-130'>"+ title + "</h4>\
                        " + message + "\
                    </div>\
                    <button data-dismiss='toast' class='align-self-start btn btn-xs btn-outline-grey btn-h-light-grey py-2px mr-1 mt-1 border-0 text-150'>&times;</button>",
        width: 420,
        delay: 2000,
        close: false,
        className: 'bgc-white-tp1 shadow border-0',
        bodyClass: 'd-flex border-0 p-0 text-dark-tp2',
        headerClass: 'd-none',
    });
};

function ShowInfo(title, message) {
    $.aceToaster.add({
        placement: 'tr',
        body: "<div class='bgc-green-d1 text-white px-3 pt-3'>\
                        <div class='border-2 brc-white px-3 py-25 radius-round'>\
                            <i class='fa fa-check text-150'></i>\
                        </div>\
                    </div>\
                    <div class='p-3 mb-0 flex-grow-1'>\
                        <h4 class='text-130'>" + title + "</h4>\
                        " + message + "\
                    </div>\
                    <button data-dismiss='toast' class='align-self-start btn btn-xs btn-outline-grey btn-h-light-grey py-2px mr-1 mt-1 border-0 text-150'>&times;</button>",
        width: 420,
        delay: 2000,
        close: false,
        className: 'bgc-white-tp1 shadow border-0',
        bodyClass: 'd-flex border-0 p-0 text-dark-tp2',
        headerClass: 'd-none',
    });
};