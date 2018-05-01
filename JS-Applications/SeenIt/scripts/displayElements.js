function showView(viewName) {
    $('div > section').hide(); // Hide all views
    $('#' + viewName).show(); // Show the selected view only
}

function showHideMenuLinks() {
    if (sessionStorage.getItem('authToken') === null) { // No logged in user
        $("#loginForm").show();
        $("#registerForm").show();
        $('#menu').hide();
        $('#profile').hide();
        $('#viewCatalog').hide();
        $('#viewSubmit').hide();
        $('#viewMyPosts').hide();
        $('#viewEdit').hide();
        $('#viewComments').hide();
    } else { // We have logged in user
        $('#viewWelcome').hide();
        $("#loginForm").hide();
        $("#registerForm").hide();
        $('#menu').show();
        $('#profile').show();
        $('#viewCatalog').show();
        $('#profile > span').text(sessionStorage.getItem('username'))
    }
}


function showHomeView() {
    showView('viewWelcome');
}