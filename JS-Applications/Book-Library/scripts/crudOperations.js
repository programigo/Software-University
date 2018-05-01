const BASE_URL = 'https://baas.kinvey.com/';
const APP_KEY = 'kid_SkOtEt5jG';
const APP_SECRET = 'ae215ccad194463db6c549365b6705eb';
const AUTH_HEADERS = {'Authorization': "Basic " + btoa(APP_KEY + ":" + APP_SECRET)};
const BOOKS_PER_PAGE = 10;

function loginUser() {
    let username = $('#formLogin').find('[name="username"]').val();
    let password = $('#formLogin').find('[name="passwd"]').val();

    $.ajax({
        method: 'POST',
        url: BASE_URL + 'user/' + APP_KEY + '/login',
        headers: AUTH_HEADERS,
        data: {username, password}
    }).then(function (res) {
        signInUser(res, 'Login successful.')
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

function listBooks() {
    $('#books > table > tbody').empty();
    $.ajax({
        method: 'GET',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
        headers: {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')}
    }).then(function (res) {
        showView('viewBooks');
        displayPaginationAndBooks(res.reverse());
    }).catch(handleAjaxError);
}


function createBook() {
    let title = $('#formCreateBook').find('[name="title"]').val();
    let author = $('#formCreateBook').find('[name="author"]').val();
    let description = $('#formCreateBook').find('[name="description"]').val();
    $.ajax({
        method: 'POST',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books',
        headers: {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')},
        data: {title, author, description}
    }).then(function (res) {
        listBooks();
        showInfo('Book created.');
    }).catch(handleAjaxError);
}

function deleteBook(book) {
    $.ajax({
        method: 'DELETE',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + book._id,
        headers: {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')}
    }).then(function () {
        listBooks();
        showInfo('Book deleted.');
    }).catch(handleAjaxError);
}

function loadBookForEdit(book) {
    showView('viewEditBook');
    $('#formEditBook').find('[name="id"]').val(book._id);
    $('#formEditBook').find('[name="title"]').val(book.title);
    $('#formEditBook').find('[name="author"]').val(book.author);
    $('#formEditBook').find('[name="description"]').val(book.description);
}

function editBook() {
    let id = $('#formEditBook').find('[name="id"]').val();
    let title = $('#formEditBook').find('[name="title"]').val();
    let author = $('#formEditBook').find('[name="author"]').val();
    let description = $('#formEditBook').find('[name="description"]').val();
    $.ajax({
        method: 'PUT',
        url: BASE_URL + 'appdata/' + APP_KEY + '/books/' + id,
        headers: {'Authorization': "Kinvey " + sessionStorage.getItem('authToken')},
        data: {title, author, description}
    }).then(function () {
        listBooks();
        showInfo('Book edited.')
    }).catch(handleAjaxError);
}

function logoutUser() {
    sessionStorage.clear();
    showHomeView();
    showInfo('Logout successful.');
    showHideMenuLinks();
}

function signInUser(res, message) {
    showHomeView();
    showInfo(message);
    sessionStorage.setItem('username', res.username);
    sessionStorage.setItem('authToken', res._kmd.authtoken);
    sessionStorage.setItem('userId', res._id);
    showHideMenuLinks();
}

function displayPaginationAndBooks(books) {
    let pagination = $('#pagination-demo');
    let table = $('#books > table');
    if(pagination.data("twbs-pagination")){
        pagination.twbsPagination('destroy')
    }
    pagination.twbsPagination({
        totalPages: Math.ceil(books.length / BOOKS_PER_PAGE),
        visiblePages: 5,
        next: 'Next',
        prev: 'Prev',
        onPageClick: function (event, page) {
            // TODO remove old page books
            let startBook = (page - 1) * BOOKS_PER_PAGE
            let endBook = Math.min(startBook + BOOKS_PER_PAGE, books.length)
            $(`a:contains(${page})`).addClass('active')
            for (let i = startBook; i < endBook; i++) {
                let tr = $('<tr>');
                let title = $(`<td>${books[i].title}</td>`);
                let author = $(`<td>${books[i].author}</td>`);
                let description = $(`<td>${books[i].description}</td>`);
                let actions = $('<td>');
                let deleteButton = $(`<a href="#" value="${books[i]._id}">[Delete]</a>`).on('click', function () {
                    deleteBook(books[i]);
                });
                let editButton = $(`<a href="#" value="${books[i]._id}">[Edit]</a>`).on('click', function () {
                    loadBookForEdit(books[i]);
                });
                if (books[i]._acl.creator === sessionStorage.getItem('userId')) {
                    actions.append(deleteButton);
                    actions.append(editButton);
                }
                tr.append(title);
                tr.append(author);
                tr.append(description);
                tr.append(actions);
                table.append(tr);
            }
        }
    })
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response)
    if (response.readyState === 0)
        errorMsg = "Cannot connect due to network error."
    if (response.responseJSON && response.responseJSON.description)
        errorMsg = response.responseJSON.description
    showError(errorMsg)
}