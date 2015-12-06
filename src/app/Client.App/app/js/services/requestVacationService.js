define([
    'app',
    'angular-resource',
    '../configs/constants'
], function (app) {
    'use strict';

    app.factory('RequestVacationService', ['$resource', '$q', 'CONNECTION_CONSTANTS',
        function ($resource, $q, CONNECTION_CONSTANTS) {
            var _resource = $resource(CONNECTION_CONSTANTS.requestVacationUri),

                requestVacationService = {};

            return requestVacationService;

        }]); // end of service
}); // end of define