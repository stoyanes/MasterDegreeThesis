define([
    'app',
    'angular-resource',
    '../configs/constants'
], function (app) {

    'use strict';

    app.factory('AuthenticationService', ['$resource', '$q', 'CONNECTION_CONSTANTS', 'SessionService',
        function ($resource, $q, CONNECTION_CONSTANTS, sessionService) {

            var _resource = $resource(CONNECTION_CONSTANTS.authenticationUri),

                authenticationService = {};

            authenticationService.authenticateAsync = function (authData) {
                var deffered = $q.defer();

                _resource.save(authData,
                    function (responce) {
                        sessionService.createSession(responce.userName, responce.access_token, angular.fromJson(responce.userRoles));
                        deffered.resolve(responce);
                    },

                    function (responce) {
                        deffered.reject(responce);
                    }
                );

                return deffered.promise;
            };

            authenticationService.isAuthenticated = function () {
                return !!sessionService.getUserSession().accessToken &&
                    sessionService.getUserSession().accessToken  !== 'GUEST_TOKEN';
            };

            authenticationService.isAuthorized = function (authorizedRoles) {

                var authorizedRolesLocal = angular.copy(authorizedRoles);

                if (!angular.isArray(authorizedRoles)) {
                    authorizedRolesLocal = [authorizedRoles];
                }

                var userRoles = sessionService.getUserSession().userRoles,

                    userRolesInAuthorizedRoles = authorizedRolesLocal.filter(function (value) {
                        return userRoles.indexOf(value) !== -1;
                    });

                return userRolesInAuthorizedRoles.length > 0;
            };

            return authenticationService;

        }]); // end of service

}); // end of define