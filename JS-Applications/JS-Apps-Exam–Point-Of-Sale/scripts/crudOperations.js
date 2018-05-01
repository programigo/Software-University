function loginUser(ev) {
    ev.preventDefault();
    let username = $('#username-login').val();
    let password = $('#password-login').val();
    let usernameRegex = new RegExp('^[a-zA-Z]{5,}$');

    if (!usernameRegex.test(username)) {
        notify.showError('Username should be a string with at least 5 characters long.');
        $('#username-login').val('');
        $('#password-login').val('');
        return;
    }

    if (password === '') {
        notify.showError('Password should not be empty.');
        return;
    }

    auth.login(username, password)
        .then(function (res) {
            $('#username-login').val('');
            $('#password-login').val();
            auth.signInUser(res, 'Login successful.');
        }).catch(notify.handleError);
}

function registerUser(ev) {
    ev.preventDefault();
    let username = $('#username-register').val();
    let password = $('#password-register').val();
    let repeatPassword = $('#password-register-check').val();
    let usernameRegex = new RegExp('^[a-zA-Z]{5,}$');

    if (!usernameRegex.test(username)) {
        notify.showError('Username should be a string with at least 5 characters long.');
        $('#username-register').val('');
        $('#password-register').val('');
        $('#password-register-check').val('');
        return;
    }

    if (password === '' || repeatPassword === '') {
        notify.showError('Passwords input fields should not be empty.');
        return;
    }

    if (password !== repeatPassword) {
        notify.showError('Passwords do not match');
        $('#username-register').val('');
        $('#password-register').val('');
        $('#password-register-check').val('');
        return;
    }

    auth.register(username, password)
        .then(function (res) {
            $('#username-register').val('');
            $('#password-register').val('');
            $('#password-register-check').val('');
            auth.signInUser(res, 'User registration successful.');
            listActiveReceiptEntries();
        }).catch(notify.handleError);
}

function listActiveReceiptEntries() {
    remote.get('appdata', 'entries', 'kinvey')
        .then(function (res) {
            displayEntries(res);
        }).catch(notify.handleError);
}

function getReceipt() {
    let receipt = '';
    receipts.getCurrentActiveReceipt()
        .then(function (res) {
            receipt = res._id;
        });
    return receipt;
}
//
function listEntries() {
    remote.get('appdata', 'entries', 'kinvey')
        .then(function (res) {
            displayEntries(res);
        }).catch(notify.handleError);
}

function logoutUser() {
    auth.logout();
    $('#loginUsername').val('');
    $('#loginPassword').val('');

}

function displayEntries(entries) {
    let activeReceipt = getReceipt();
    console.log(activeReceipt);
    let appendDiv = $('#active-entries');
    appendDiv.empty();

    for (let entry of entries) {
        if (entry.receiptId === activeReceipt.id) {
            let divRow = $('<div class="row">')
                .append($(`<div class="col-wide">${entry.type}</div>`))
                .append($(`<div class="col-wide">${entry.qty}</div>`))
                .append($(`<div class="col-wide">${entry.price}</div>`))
                .append($(`<div class="col-wide">${entry.qty * entry.price}</div>`))
                .append($(`<div class="col-right">${entry.price}</div>`).append($('<a href="#">&#10006;</a>')));
            appendDiv.append(divRow);
        }
    }
}