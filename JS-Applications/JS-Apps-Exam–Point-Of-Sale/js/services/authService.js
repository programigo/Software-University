let auth = (() => {
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
        showHomeView();
        showHideMenuLinks();
        notify.showInfo('Logout successful.');
    }

    return {
        login,
        logout,
        register,
        signInUser
    }
})();