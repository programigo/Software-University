let auth = (() => {
    function isAuth() {
        return sessionStorage.getItem('authToken') !== null;
    }

    function signInUser(res, message) {
        sessionStorage.setItem('username', res.username);
        sessionStorage.setItem('authToken', res._kmd.authtoken);
        sessionStorage.setItem('userId', res._id);
        showHideMenuLinks();
        notify.showInfo(message);
    }


    function register (username, password) {
        let obj = { username, password };

        return remote.post('user', '', 'basic', obj);
    }

    function login(username, password) {
        let obj = { username, password };

        return remote.post('user', 'login', 'basic', obj)
    }
    
    function logout() {
        sessionStorage.clear();
        showView('viewWelcome');
        showHideMenuLinks();
        notify.showInfo('Logout successful.');
    }

    return {
        isAuth,
        login,
        logout,
        register,
        signInUser
    }
})();