define([
    'app'
], function (app) {
    'use strict';

    app.factory('RequestVacationService', ['$resource', '$q', 'CONNECTION_CONSTANTS',
        function ($resource, $q, CONNECTION_CONSTANTS) {
            var _resource = $resource(CONNECTION_CONSTANTS.requestVacationUri),

                requestVacationService = {};

            requestVacationService.requestAsync = function (requestData) {
                var deffered = $q.defer();

                _resource.save(requestData,
                    function (responce) {
                        deffered.resolve(responce);
                    },

                    function (responce) {
                        deffered.reject(responce);
                    }
                );

                return deffered.promise;
            };

            requestVacationService.getAllRequestsAsync = function () {
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

            return requestVacationService;
        }]); // end of service
}); // end of define
