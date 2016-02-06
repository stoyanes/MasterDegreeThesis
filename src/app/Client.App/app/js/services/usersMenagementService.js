define([
    'app'
], function (app) {

    'use strict';

    app.factory('UsersManagementService', ['$resource', '$q', 'CONNECTION_CONSTANTS', function ($resource, $q, CONNECTION_CONSTANTS) {
        var _resource = $resource(CONNECTION_CONSTANTS.usersUr + '/:id'),

            usersMenagementService = {};

        usersMenagementService.registerUserAsync = function (userDetails) {
            var deffered = $q.defer();
            var registerUserResourse = $resource(CONNECTION_CONSTANTS.usersUri + '/register');
            registerUserResourse.save(userDetails,
                function (responce) {
                    deffered.resolve(responce);
                },

                function (responce) {
                    deffered.reject(responce);
                }
                );

            return deffered.promise;
        };

        return usersMenagementService;
    }]);
});
