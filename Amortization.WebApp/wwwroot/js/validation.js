var aQFormError = function () {
    this.Name = '';
    this.Description = '';
};

var validateForm = function (formName_) {

    var reqtag = "aqreq";
    var frm = $("[aqform=" + formName_ + "]")[0];

    errorCollection_ = [];

    var elements = frm.elements;
    var errCount = 0;
    var retValue = false;

    var pass1;
    var pass1Obj;
    var pass2;

    for (var i = 0; i < elements.length; i++) {
        var input_ = elements[i];
        var $input_ = $(input_);

        if (input_.hasAttribute(reqtag)) {
            var inputvalue = $input_.val();

            if (inputvalue === '') {
                var error = new aQFormError();
                error.Name = $input_.attr('name');
                error.Description = "Empty";
                errorCollection_.push(error);

                if (input_.type === 'select-one') {
                    $input_.next().addClass('aqerr');
                    errCount++;
                } else {
                    $input_.closest('.e-input-group').addClass('aqerr');
                    errCount++;
                }
            }
            else {
                $input_.closest('.e-input-group').removeClass('aqerr');
                $input_.next().removeClass('aqerr');
            }
        }

        if (input_.hasAttribute("aqemail")) {
            inputvalue = $input_.val();
            if (validateEmail(inputvalue) === false || inputvalue === '') {
                error = new aQFormError();
                error.Name = $input_.attr('name');
                error.Description = "Invalid Email";
                errorCollection_.push(error);
                $input_.closest('.e-input-group').addClass('aqerr');
                errCount++;
            }
            else {
                $input_.closest('.e-input-group').removeClass('aqerr');
            }
        }

        if (input_.hasAttribute("aqpass1")) {
            pass1 = $input_.val();
            //pass1Obj = $input_;
            pass1Obj = $input_.closest('.e-input-group');
        }

        if (input_.hasAttribute("aqpass2")) {
            pass2 = $input_.val();
            pass2Obj = $input_.closest('.e-input-group');
            if (pass1 !== "" && pass2 !== "") {
                var lowercaseRegex = /[a-z]/;
                var uppercaseRegex = /[A-Z]/;
                var specialCharacterRegex = /[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]/;

                // Check if password meets complexity rules
                var isPasswordComplex = pass1.length >= 8 &&
                    lowercaseRegex.test(pass1) &&
                    uppercaseRegex.test(pass1) &&
                    specialCharacterRegex.test(pass1);

                if (pass1 !== pass2 || !isPasswordComplex) {
                    pass1Obj.addClass('aqerr');
                    pass2Obj.addClass('aqerr');
                    errCount++;
                }
            } else if (pass1 === "" && pass2 !== "") {
                pass1Obj.addClass('aqerr');
                pass2Obj.removeClass('aqerr');
                errCount++;
            } else if (pass2 === "" && pass1 !== "") {
                pass1Obj.removeClass('aqerr');
                pass2Obj.addClass('aqerr');
                errCount++;
            } else {
                pass1Obj.removeClass('aqerr');
                pass2Obj.removeClass('aqerr');
            }
        }
    }

    if (errCount > 0) { retValue = false; }
    else { retValue = true; }
    return retValue;
};

var validateEmail = function (email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    if (!emailReg.test(email)) {
        return false;
    } else {
        return true;
    }
};