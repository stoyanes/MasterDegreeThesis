define(
    [
        'app'
    ],

    function (app) {
        'use strict';

        app = app.constant('CONNECTION_CONSTANTS', {
            authenticationUri: './api/Token',
            requestVacationUri: './api/VacationRequests',
            leaveDaysForEmployeeByYearUri: './api/LeaveDays/AllForEmployeeByYear',
            employeeUri: './api/employees',
            holidayUri: './api/Holidays'
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
            regular: 'regular',
            guest: 'guest'
        });

        app = app.constant('GUEST_USER', {
            userName: 'Guest',
            accessToken: 'GUEST_USER_TOKEN',
        });
    });
