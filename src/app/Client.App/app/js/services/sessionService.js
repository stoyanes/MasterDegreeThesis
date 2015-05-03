define([
    'app'
], function (app) {
    'use strict';
    app.factory('SessionService', [function () {
        var userSession = {},

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

    }])
});