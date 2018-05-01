function attachEvents() {
    const URL = 'https://baas.kinvey.com/appdata/kid_HJICDDTH/';
    const USERNAME = 'Peter';
    const PASSWORD = 'p';
    const BASE_64 = btoa(USERNAME + ':' + PASSWORD);
    const AUTH = {'Authorization': 'Basic ' + BASE_64};
    const POSTS = $('#posts');
    const POSTCOMMENTS = $('#post-comments');
    let posts = {};

    $('#btnLoadPosts').on('click', getPosts);
    $('#btnViewPost').on('click', loadComments);

    function getPosts() {
        $.ajax({
            method: 'GET',
            url: URL + 'posts',
            headers: AUTH
        }).then(appendPosts);

        function appendPosts(res) {
            POSTS.empty();
            for (let post of res) {
                let newOption = $(`<option value="${post._id}">${post.title}</option>`);
                POSTS.append(newOption);
                posts[post._id] = post.body;
            }
        }
    }

    function loadComments() {
        let postId = $('#posts').find(":selected")[0];
        $('#post-title').text(postId.textContent);
        $('#post-body').text(posts[postId.value]);

        $.ajax({
            method: 'GET',
            url: URL + `comments/?query={"post_id":"${postId.value}"}`,
            headers: AUTH
        }).then(displayComments);

        function displayComments(comments) {
            POSTCOMMENTS.empty();
            for (let comment of comments) {
                let currentComment = $(`<li>${comment.text}</li>`);
                POSTCOMMENTS.append(currentComment);
            }
        }
    }
}