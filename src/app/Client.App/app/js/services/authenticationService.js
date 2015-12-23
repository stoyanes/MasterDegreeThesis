define([
    'app'
], function (app) {
    'use strict';

    app.factory('AuthenticationService', ['$resource', '$http', '$q', 'CONNECTION_CONSTANTS', 'SessionService', 'GUEST_USER',
        function ($resource, $http, $q, CONNECTION_CONSTANTS, sessionService, GUEST_USER) {
            var _resource = $resource(CONNECTION_CONSTANTS.authenticationUri),

                authenticationService = {};

            var setDefaultToken = function (token) {
                // outh token will be send with every request
                $http.defaults.headers.common.Authorization = 'Bearer ' + token;
            };

            authenticationService.authenticateAsync = function (authData) {
                var deffered = $q.defer();

                _resource.save(authData,
                    function (responce) {
                        sessionService.createSession(responce.userName, responce.access_token, angular.fromJson(responce.userRoles));
                        setDefaultToken(responce.access_token);
                        deffered.resolve(responce);
                    },

                    function (responce) {
                        deffered.reject(responce);
                    }
                );

                return deffered.promise;
            };

            authenticationService.isAuthenticated = function () {
                var userAccessToken = sessionService.getUserSession().accessToken;

                return !!userAccessToken && userAccessToken !== GUEST_USER.accessToken;
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
