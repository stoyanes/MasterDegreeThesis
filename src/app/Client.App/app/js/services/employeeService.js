define([
    'app'
], function (app) {

    'use strict';

    app.factory('EmployeeService', ['$resource', '$q', 'CONNECTION_CONSTANTS', function ($resource, $q, CONNECTION_CONSTANTS) {
        var _resource = $resource(CONNECTION_CONSTANTS.employeeUri),

            employeeService = {};

        employeeService.getCurrentEmployeeInfo = function () {
            var deffered = $q.defer();
            var currentEmpoyeeResourse = $resource(CONNECTION_CONSTANTS.employeeUri + '/current');
            currentEmpoyeeResourse.get({},
                function (responce) {
                    deffered.resolve(responce);
                },

                function (responce) {
                    deffered.reject(responce);
                }
            );

            return deffered.promise;
        };

        return employeeService;
    }]);
});
