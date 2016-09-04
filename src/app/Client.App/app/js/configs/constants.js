define(
    [
        'app'
    ],

    function (app) {
        'use strict';

        // *********************** BEGIN FOR LOCAL DEVELOPMENT *************

          app = app.constant('CONNECTION_CONSTANTS', {
             authenticationUri: './api/Token',
             requestVacationUri: './api/VacationRequests',
             leaveDaysForEmployeeByYearUri: './api/LeaveDays/AllForEmployeeByYear',
             employeeUri: './api/employees',
             holidayUri: './api/Holidays',
             usersUri: './api/Account',
          });

        // *********************** END FOR LOCAL DEVELOPMENT *************

        // ********** BEGIN FOR AZURE (CLOUD) DEVELOPMENT *****************//
        app = app.constant('CONNECTION_CONSTANTS', {
           authenticationUri: 'http://timeoffsystem-api.azurewebsites.net/Token',
           requestVacationUri: 'http://timeoffsystem-api.azurewebsites.net/VacationRequests',
           leaveDaysForEmployeeByYearUri: 'http://timeoffsystem-api.azurewebsites.net/LeaveDays/AllForEmployeeByYear',
           employeeUri: 'http://timeoffsystem-api.azurewebsites.net/employees',
           holidayUri: 'http://timeoffsystem-api.azurewebsites.net/Holidays',
           usersUri: 'http://timeoffsystem-api.azurewebsites.net/Account'
        });

        // ********** END FOR AZURE (CLOUD) DEVELOPMENT *****************//

        //app = app.constant('AUTH_EVENTS', {
        //    loginSuccess: 'auth-login-success',
        //    loginFailed: 'auth-login-failed',
        //    logoutSuccess: 'auth-logout-success',
        //    sessionTimeout: 'auth-session-timeout',
        //    notAuthenticated: 'auth-not-authenticated',
        //    notAuthorized: 'auth-not-authorized'
        //});

        app = app.constant('USER_ROLES', {
            admin: 'admin',
            regular: 'regular',
            guest: 'guest'
        });

        app = app.constant('GUEST_USER', {
            userName: 'Guest',
            accessToken: 'GUEST_USER_TOKEN'
        });
        return app;
    });
