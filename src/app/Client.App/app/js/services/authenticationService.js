define([
    'app',
    'angular-resource',
    '../configs/constants'
], function (app) {

    'use strict';

    app.factory('AuthenticationService', ['$resource', '$q', 'CONNECTION_CONSTANTS',
        function ($resource, $q, CONNECTION_CONSTANTS) {

            var _resource = $resource(CONNECTION_CONSTANTS.authenticationUri),

                authenticationService = {};

            authenticationService.authenticateAsync = function (authData) {
                var deffered = $q.defer();

                _resource.save(authData,
                    function (responce) {
                        deffered.resolve(responce);
                    },

                    function (responce) {
                        deffered.reject(responce);
                    }
                );

                return deffered.promise;
            };

            return authenticationService;

        }]); // end of service

}); // end of define