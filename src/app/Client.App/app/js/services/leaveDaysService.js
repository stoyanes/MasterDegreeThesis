define([
    'app'
], function (app) {
    'use strict';
    app.factory('LeaveDaysService', ['$resource', '$q', 'CONNECTION_CONSTANTS', function ($resource, $q, CONNECTION_CONSTANTS) {
        var _resource = $resource(CONNECTION_CONSTANTS.),

            leaveDaysService = {};
    }]);
});
