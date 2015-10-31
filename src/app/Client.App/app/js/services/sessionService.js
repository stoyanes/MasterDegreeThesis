define([

    'app',
    '../configs/constants'

], function (app) {
    'use strict';

    app.factory('SessionService', ['USER_ROLES', 'GUEST_USER', function (USER_ROLES, GUEST_USER) {
        var userSession = {
                userName: GUEST_USER.userName,
                accessToken: GUEST_USER.accessToken,
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
            userSession.userName = GUEST_USER.userName;
            userSession.accessToken = GUEST_USER.accessToken;
            userSession.userRoles = [USER_ROLES.guest];
        };

        return sessionService;
    }]);
});