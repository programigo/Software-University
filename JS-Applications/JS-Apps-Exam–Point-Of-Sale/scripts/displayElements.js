function showView(viewName) {
    $('main > section').hide(); // Hide all views
    $('#' + viewName).show(); // Show the selected view only
}

function showHideMenuLinks() {
    if (sessionStorage.getItem('authToken') === null) { // No logged in user
        $('#profile').hide();
        $("#create-receipt-view").hide();
        $("#all-receipt-view").hide();
        $('#receipt-details-view').hide();
    } else { // We have logged in user
        $('#welcome-section').hide();
        $('#profile').show();
        $("#create-receipt-view").show();
        $("#all-receipt-view").show();
        $('#receipt-details-view').show();
        $('#cashier > a').text(sessionStorage.getItem('username'));
    }
}


function showHomeView() {
    showView('welcome-section');
}

function showLoginView() {
    showView('viewLogin');
    $('#formLogin').trigger('reset');
}

function showRegisterView() {
    $('#formRegister').trigger('reset');
    showView('viewRegister');
}

function showCreateAdView() {
    $('#formCreateAd').trigger('reset');
    showView('viewCreateAd');
}