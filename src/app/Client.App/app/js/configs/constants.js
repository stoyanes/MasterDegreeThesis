define(['app'],

    function (app) {
        app = app.constant('CONNECTION_CONSTANTS', {
            authenticationUri: 'http://localhost:49790/Token' 
            //authenticationUri: './api/Token'
        });

        app = app.constant('AUTH_EVENTS', {
            loginSuccess: 'auth-login-success',
            loginFailed: 'auth-login-failed',
            logoutSuccess: 'auth-logout-success',
            sessionTimeout: 'auth-session-timeout',
            notAuthenticated: 'auth-not-authenticated',
            notAuthorized: 'auth-not-authorized'
        });

        app = app.constant('USER_ROLES', {
            admin: 'admin',
            regular: 'regular'
        });
    });