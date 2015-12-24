define([
    'app'
], function (app) {
    'use strict';
    app.factory('LeaveDaysService', ['$resource', '$q', 'CONNECTION_CONSTANTS', function ($resource, $q, CONNECTION_CONSTANTS) {
        var _resource = $resource(CONNECTION_CONSTANTS.leaveDaysForEmployeeByYearUri + '/:year'),

            leaveDaysService = {};

        leaveDaysService.getLeaveDaysAsync = function (year) {
            var deffered = $q.defer();

            _resource.get({ year: year },
                function (responce) {
                    deffered.resolve(responce);
                },

                function (responce) {
                    deffered.reject(responce);
                }
            );

            return deffered.promise;
        };

        return leaveDaysService;
    }]);
});
