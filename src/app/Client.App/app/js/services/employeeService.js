define([
    'app'
], function (app) {
    'use strict';
    app.factory('EmployeeService', [
        '$resource',
        '$q',
        'CONNECTION_CONSTANTS',
        function ($resource, $q, CONNECTION_CONSTANTS) {
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

            employeeService.getAll = function () {
                var deffered = $q.defer();
                _resource.query({},
                    function (responce) {
                        deffered.resolve(responce);
                    },

                    function (responce) {
                        deffered.reject(responce);
                    }
                    );
                return deffered.promise;
            };

            employeeService.updateEmployee = function (employee) {
                var deffered = $q.defer();
                var localResourse = $resource(CONNECTION_CONSTANTS.employeeUri, null, {
                    update: {
                        method: 'PUT'
                    }
                });
                localResourse.update(employee,
                    function (responce) {
                        deffered.resolve(responce);
                    },

                    function (responce) {
                        deffered.reject(responce);
                    }
                    );
                return deffered.promise;
            };

            employeeService.removeUserAsync = function (userId) {
                var deffered = $q.defer();
                var currentEmpoyeeResourse = $resource(CONNECTION_CONSTANTS.employeeUri + '/:id');
                currentEmpoyeeResourse.delete({ id: userId },
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
