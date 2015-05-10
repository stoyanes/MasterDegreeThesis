define([

    'app',
    '../configs/constants'

], function (app) {

    'use strict';

    app.factory('SessionService', ['USER_ROLES', function (USER_ROLES) {
        var userSession = {
                userName: 'Guest',
                accessToken: 'GUEST_TOKEN',
                userRoles: [USER_ROLES.guest]

            },

            sessionService = {};

        sessionService.getUserSession = function () {
            return userSession;
        };

        sessionService.createSession = function (userName, accessToken, userRoles) {
            userSession.userName = userName;
            userSession.accessToken = accessToken;
            userSession.userRoles = userRoles;
        };

        sessionService.destroySession = function () {
            userSession.userName = undefined;
            userSession.accessToken = undefined;
            userSession.userRoles = undefined;
        };

        return sessionService;

    }]);
});