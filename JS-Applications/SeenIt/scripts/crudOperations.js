function loginUser(ev) {
    ev.preventDefault();
    let username = $('#loginUsername').val();
    let password = $('#loginPassword').val();
    let usernameRegex = new RegExp('^[a-zA-Z]{3,}$');
    let passwordRegex = new RegExp('^\\w{6,}$');

    if (!usernameRegex.test(username)) {
        notify.showError('Username should be at least 3 characters long and should contain only english alphabet letters');
        $('#loginUsername').val('');
        $('#loginPassword').val('');
        return;
    }

    if (!passwordRegex.test(password)) {
        notify.showError('Password should be at least 6 characters long and should contain only english alphabet letters and digits');
        $('#loginUsername').val('');
        $('#loginPassword').val('');
        return;
    }

    auth.login(username, password)
        .then(function (res) {
            auth.signInUser(res, 'Login successful.');
            listPosts();
        }).catch(notify.handleError);
}

function registerUser(ev) {
    ev.preventDefault();
    let username = $('#registerUsername').val();
    let password = $('#registerPassword').val();
    let repeatPassword = $('#repeatPassword').val();
    let usernameRegex = new RegExp('^[a-zA-Z]{3,}$');
    let passwordRegex = new RegExp('^\\w{6,}$');

    if (!usernameRegex.test(username)) {
        notify.showError('Username should be at least 3 characters long and should contain only english alphabet letters');
        $('#registerUsername').val('');
        $('#registerPassword').val('');
        $('#repeatPassword').val('');
        return;
    }

    if (!passwordRegex.test(password)) {
        notify.showError('Password should be at least 6 characters long and should contain only english alphabet letters and digits');
        $('#registerUsername').val('');
        $('#registerPassword').val('');
        $('#repeatPassword').val('');
        return;
    }

    if (password !== repeatPassword) {
        notify.showError('Passwords do not match');
        $('#registerUsername').val('');
        $('#registerPassword').val('');
        $('#repeatPassword').val('');
        return;
    }

    auth.register(username, password)
        .then(function (res) {
            auth.signInUser(res, 'User registration successful.');
            listPosts();
        }).catch(notify.handleError);
}

function listPosts() {
    remote.get('appdata', 'posts', 'kinvey')
        .then(function (res) {
            displayPosts(res);
        }).catch(notify.handleError);
}

function listMyPosts() {
    remote.get('appdata', 'posts', 'kinvey')
        .then(function (res) {
            displayMyPosts(res);
        }).catch(notify.handleError);
}


function createPost() {
    let author = sessionStorage.getItem('username');
    let title = $('#submitForm').find('[name="title"]').val();
    let imageUrl = $('#submitForm').find('[name="image"]').val();
    let description = $('#submitForm').find('[name="comment"]').val();
    let url = $('#submitForm').find('[name="url"]').val();
    let linkUrlRegex = new RegExp('^(http).*$');
    let data;

    if (!linkUrlRegex.test(url)) {
        notify.showError('Link url should always start with “http”');
        return;
    }

    if (imageUrl === '' && description === '') {
        data = {author, title, url};
    } else if (imageUrl === '' && description !== '')  {
        data = {author, title, description, url};
    } else if (imageUrl !== '' && description === '')  {
        data = {author, title, imageUrl, url};
    } else {
        data = {author, title, imageUrl, description, url};
    }

    remote.post('appdata', 'posts', 'kinvey', data)
        .then(function () {
            listPosts();
            showView('viewCatalog');
            notify.showInfo('Post created.');
        }).catch(notify.handleError);
}

function deletePost(post) {
    posts.deletePost(post._id)
        .then(function () {
            listPosts();
            showView('viewCatalog');
            notify.showInfo('Post deleted.');
        }).catch(notify.handleError);
}

function loadPostForEdit(post) {
    $('#viewEdit').find('[name="id"]').val(post._id);
    $('#viewEdit').find('[name="publisher"]').val(post.author);
    $('#viewEdit').find('[name="url"]').val(post.url);
    $('#viewEdit').find('[name="title"]').val(post.title);
    $('#viewEdit').find('[name="image"]').val(post.imageUrl);
    $('#viewEdit').find('[name="description"]').val(post.description);

    showView('viewEdit');
}

function editPost() {
    alert('raboti');
    let postId = $('#viewEdit').find('[name="id"]').val();
    let author = $('#viewEdit').find('[name="publisher"]').val();
    let url = $('#viewEdit').find('[name="url"]').val();
    let title = $('#viewEdit').find('[name="title"]').val();
    let imageUrl = $('#viewEdit').find('[name="image"]').val();
    let description = $('#viewEdit').find('[name="description"]').val();
    posts.editPost(author, url, title, imageUrl, description, postId)
        .then(function () {
            listPosts();
            showView('viewCatalog');
            notify.showInfo(`Post ${title} updated.`);
        }).catch(notify.handleError);
}

function logoutUser() {
    auth.logout();
    $('#loginUsername').val('');
    $('#loginPassword').val('');

}

function calcTime(dateIsoFormat) {
    let diff = new Date - (new Date(dateIsoFormat));
    diff = Math.floor(diff / 60000);
    if (diff < 1) return 'less than a minute';
    if (diff < 60) return diff + ' minute' + pluralize(diff);
    diff = Math.floor(diff / 60);
    if (diff < 24) return diff + ' hour' + pluralize(diff);
    diff = Math.floor(diff / 24);
    if (diff < 30) return diff + ' day' + pluralize(diff);
    diff = Math.floor(diff / 30);
    if (diff < 12) return diff + ' month' + pluralize(diff);
    diff = Math.floor(diff / 12);
    return diff + ' year' + pluralize(diff);
    function pluralize(value) {
        if (value !== 1) return 's';
        else return '';
    }
}

function displayPosts(posts) {
    let postsContainer = $('#viewCatalog > div');
    postsContainer.empty();
    let postRank = 1;
    for (let post of posts) {
        let article = $('<article class="post">');
        let divColRank = $('<div class="col rank">');
        let span = $(`<span>${postRank}</span>`);
        divColRank.append(span);
        article.append(divColRank);
        let colThumbnail = $('<div class="col thumbnail">');
        let urlAnchor = $(`<a href="${post.url}">`);
        let imageUrl = $(`<img src="${post.imageUrl}">`);
        urlAnchor.append(imageUrl);
        colThumbnail.append(urlAnchor);
        article.append(colThumbnail);
        let postContent = $('<div class="post-content">');
        let divTitle = $(`<div class="title"><a href="${post.url}">${post.title}</a></div>`);
         postContent.append(divTitle);
        let detailsDiv = $('<div class="details">');
        let infoDiv = $(`<div class="info">submitted ${calcTime(post._kmd.ect)} ago by ${post.author}</div>`);
        let controlsDiv = $('<div class="controls">');
        let ul = $('<ul>')
            .append('<li class="action"><a class="commentsLink" href="#">comments</a></li>');
        if (post.author === sessionStorage.getItem('username')) {
            ul
                .append(
                    $('<li class="action"><a class="editLink" href="#">edit</a></li>').on('click', () => loadPostForEdit(post)))
                .append(
                    $('<li class="action"><a class="deleteLink" href="#">delete</a></li>').on('click', () => deletePost(post)));
        }
        controlsDiv.append(ul);
        detailsDiv.append(infoDiv);
        detailsDiv.append(controlsDiv);
        postContent.append(detailsDiv);
        article.append(postContent);
        postsContainer.append(article);

        postRank++;
    }
}

function displayMyPosts(posts) {
    let postsContainer = $('#viewMyPosts').find('[class="posts"]');
    postsContainer.empty();
    let postRank = 1;
    for (let post of posts) {
        if (post.author === sessionStorage.getItem('username')) {
            let article = $('<article class="post">');
            let divColRank = $('<div class="col rank">');
            let span = $(`<span>${postRank}</span>`);
            divColRank.append(span);
            article.append(divColRank);
            let colThumbnail = $('<div class="col thumbnail">');
            let urlAnchor = $(`<a href="${post.url}">`);
            let imageUrl = $(`<img src="${post.imageUrl}">`);
            urlAnchor.append(imageUrl);
            colThumbnail.append(urlAnchor);
            article.append(colThumbnail);
            let postContent = $('<div class="post-content">');
            let divTitle = $(`<div class="title"><a href="${post.url}">${post.title}</a></div>`);
            postContent.append(divTitle);
            let detailsDiv = $('<div class="details">');
            let infoDiv = $(`<div class="info">submitted ${calcTime(post._kmd.ect)} ago by ${post.author}</div>`);
            let controlsDiv = $('<div class="controls">');
            let ul = $('<ul>')
                .append('<li class="action"><a class="commentsLink" href="#">comments</a></li>')
                .append($('<li class="action"><a class="editLink" href="#">edit</a></li>').on('click', () => loadPostForEdit(post)))
                .append($('<li class="action"><a class="deleteLink" href="#">delete</a></li>').on('click', () => deletePost(post)));

            controlsDiv.append(ul);
            detailsDiv.append(infoDiv);
            detailsDiv.append(controlsDiv);
            postContent.append(detailsDiv);
            article.append(postContent);
            postsContainer.append(article);

            postRank++;
        }
    }
}