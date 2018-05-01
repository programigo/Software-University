const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_rywNCRjoG';
const APP_SECRET = '26554127f9664305b82ae6ec47919c01';
const AUTH_HEADERS = {'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)};

function loginUser() {
    let username = $('#formLogin').find('[name="username"]').val();
    let password = $('#formLogin').find('[name="passwd"]').val();
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/login',
        headers: AUTH_HEADERS,
        data: {username, password}
    }).then(function (res) {
        signInUser(res, 'Login successful.');
    }).catch(handleAjaxError);
}

function registerUser() {
    let username = $('#formRegister').find('[name="username"]').val();
    let password = $('#formRegister').find('[name="passwd"]').val();
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/',
        headers: AUTH_HEADERS,
        data: {username, password}
    }).then(function (res) {
        signInUser(res, 'Registration successful.');
    }).catch(handleAjaxError);
}

function listAds() {
    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/advertisements',
        headers: {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')}
    }).then(function (res) {
        showView('viewAds');
        displayAds(res.reverse())
    }).catch(handleAjaxError);
}


function createAd() {
    let title = $('#formCreateAd').find('[name="title"]').val();
    let description = $('#formCreateAd').find('[name="description"]').val();
    let price = $('#formCreateAd').find('[name="price"]').val();
    let image = $('#formCreateAd').find('[name="createImage"]').val();
    let creationDate = new Date();
    let dd = creationDate.getDate();
    let mm = creationDate.getMonth()+1;
    let yyyy = creationDate.getFullYear();
    let datePublished = dd + '/' + mm + '/' + yyyy;
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/advertisements',
        headers: {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')},
        data: {title, description, price, image, datePublished}
    }).then(function () {
        listAds();
        showInfo('Advertisement created.');
    }).catch(handleAjaxError);
}

function deleteAd(advertisement) {
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/advertisements/' + advertisement._id,
        headers: {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')},
    }).then(function () {
        listAds();
        showInfo('Advertisement deleted.');
    }).catch(handleAjaxError);
}

function loadAdForEdit(advertisement) {
    console.log(advertisement);
    $('#viewEditAd').find('[name="id"]').val(advertisement._id);
    $('#viewEditAd').find('[name="publisher"]').val(advertisement._acl.creator);
    $('#viewEditAd').find('[name="title"]').val(advertisement.title);
    $('#viewEditAd').find('[name="description"]').val(advertisement.description);
    $('#viewEditAd').find('[name="price"]').val(advertisement.price);
    $('#viewEditAd').find('[name="editImage"]').val(advertisement.image);
    showView('viewEditAd');
}

function editAd() {
    let id = $('#viewEditAd').find('[name="id"]').val();
    let title = $('#viewEditAd').find('[name="title"]').val();
    let editDate = new Date();
    let dd = editDate.getDate();
    let mm = editDate.getMonth()+1;
    let yyyy = editDate.getFullYear();
    let datePublished = dd + '/' + mm + '/' + yyyy;
    let description = $('#viewEditAd').find('[name="description"]').val();
    let price = $('#viewEditAd').find('[name="price"]').val();
    let image = $('#viewEditAd').find('[name="editImage"]').val();
    $.ajax({
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/advertisements/' + id,
        headers: {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')},
        data: {title, description, datePublished, price, image}
    }).then(function () {
        listAds();
        showInfo('Advertisement edited.');
    }).catch(handleAjaxError);
}

function logoutUser() {
    sessionStorage.clear();
    showHomeView();
    showHideMenuLinks();
    showInfo('Logout successful.');
}

function signInUser(res, message) {
    sessionStorage.setItem('username', res.username);
    sessionStorage.setItem('authToken', res._kmd.authtoken);
    sessionStorage.setItem('userId', res._id);
    showHomeView();
    showHideMenuLinks();
    showInfo(message);
}

function displayAdvert(advertisement) {
    $('#viewDetailsAd').empty();

    let advertInfo = $('<div>').append(
        $('<br>'),
        $(`<img src="${advertisement.image}">`),
        $('<br>'),
        $('<label>').text('Title:'),
        $('<h1>').text(advertisement.title),
        $('<label>').text('Description:'),
        $('<p>').text(advertisement.description),
        $('<label>').text('Publisher:'),
        $('<div>').text(advertisement.publisher),
        $('<label>').text('Date:'),
        $('<div>').text(advertisement.datePublished));

    $('#viewDetailsAd').append(advertInfo);
}

function displayAds(advertisements) {
    $('#ads > table > tbody').empty();
    let table = $('#ads > table > tbody');
    if (advertisements.length === 0) {
        $('#ads > table').empty();
        $('#ads > p').empty();
        $('#ads').append($('<p align="center">No advertisements available.</p>'));
    }
    for (let advertisement of advertisements) {
        let tr = $('<tr>')
        table
            .append(tr
                .append($(`<td>${advertisement.title}</td>`))
                .append($(`<td>${advertisement._acl.creator}</td>`))
                .append($(`<td>${advertisement.description}</td>`))
                .append($(`<td>${advertisement.price}</td>`))
                .append($(`<td>${advertisement.datePublished}</td>`)));
        if (advertisement._acl.creator === sessionStorage.getItem('userId')) {
            tr
                .append($(`<a href="#">[Read More]</a>`).on('click', function () {
                    displayAdvert(advertisement);
                    showView('viewDetailsAd');
                }))
                .append($(`<a href="#">[Delete]</a>`).on('click', () => deleteAd(advertisement)))
                .append($(`<a href="#">[Edit]</a>`).on('click', () => loadAdForEdit(advertisement)))
        }
    }
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response);
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error.";
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description;
    showError(errorMsg);
}