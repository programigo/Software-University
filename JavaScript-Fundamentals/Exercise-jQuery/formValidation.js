function validate() {
    let userNameBox = $('#username');
    let emailBox = $('#email');
    let passwordBox = $('#password');
    let confirmPasswordBox = $('#confirm-password');
    let companyCheckBox = $('#company');
    let companyNumber = $('#companyNumber');
    let companyInfo = $('#companyInfo');
    let submitBtn = $('#submit');
    let validationDiv = $('#valid');
    let allIsValid = true;

    companyCheckBox.on('change', function () {
        if (companyCheckBox.is(':checked')) {
            companyInfo.css('display', 'block');
        } else {
            companyInfo.css('display', 'none');
        }
    });

    submitBtn.on('click', function (event) {
        event.preventDefault();
        validateForm();
        validationDiv.css('display', allIsValid ? 'block' : 'none');
        allIsValid = true;
    });

    function validateForm() {
        validateInputWithRegex(userNameBox, /^[A-Za-z0-9]{3,20}$/g);
        validateInputWithRegex(emailBox, /^.*?@.*?\..*$/g);
        if (confirmPasswordBox.val() === passwordBox.val()) {
            validateInputWithRegex(passwordBox, /^\w{5,15}$/g);
            validateInputWithRegex(confirmPasswordBox, /^\w{5,15}$/g);
        } else {
            confirmPasswordBox.css('border', 'solid red');
            passwordBox.css('border', 'solid red');
            allIsValid = false;
        }
    }

    if (companyCheckBox.is(':checked')) {
        validateCompanyInfo();
    }

    function validateInputWithRegex(input, regex) {
        if (regex.test(input.val())) {
            input.css('border', 'none');
        } else {
            input.css('border', 'solid red');
            allIsValid = false;
        }
    }

    function validateCompanyInfo() {
        let numValue = +companyNumber.val();
        if (numValue >= 1000 && numValue <= 9999) {
            companyNumber.css('border', 'none');
        } else {
            companyNumber.css('border', 'solid red');
            allIsValid = false;
        }
    }
}