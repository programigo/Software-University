function attachAllEvents() {
    // Bind the navigation menu links
    $("#catalog").on('click', function () {
        listPosts();
        showView('viewCatalog');
    });
    $("#submitLink").on('click', function () {
        showView('viewSubmit');
    });
    $("#myPosts").on('click', function () {
        listMyPosts();
        showView('viewMyPosts');
    });
    //$("#linkLogin").on('click', showLoginView);
    //$("#linkRegister").on('click', showRegisterView);
    //$("#linkListAds").on('click', listAds);
    //$("#linkCreateAd").on('click', showCreateAdView);
//
    //// Bind the form submit buttons
    $("#loginForm").on('submit', loginUser);
    $("#registerForm").on('submit', registerUser);
    $('#profile > a').on('click', logoutUser);
    $('#submitForm').on('submit', createPost);
    $("#editPostForm").on('submit', editPost);
    //$("#buttonEditAd").on('click', editAd);
    $("form").on('submit', function(event) { event.preventDefault() });

    // Bind the info / error boxes
    $("#infoBox, #errorBox").on('click', function() {
        $(this).fadeOut()
    })

    // Attach AJAX "loading" event listener
    $(document).on({
        ajaxStart: function() { $("#loadingBox").show() },
        ajaxStop: function() { $("#loadingBox").hide() }
    })
}