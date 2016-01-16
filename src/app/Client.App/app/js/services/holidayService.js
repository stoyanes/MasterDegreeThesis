define([
    'app'
], function (app) {

    'use strict';

    app.factory('HolidayService', ['$resource', '$q', 'CONNECTION_CONSTANTS', function ($resource, $q, CONNECTION_CONSTANTS) {
        var _resource = $resource(CONNECTION_CONSTANTS.holidayUri),

            holidayService = {};

        holidayService.createHolidayAsync = function (holiday) {
            var deffered = $q.defer();
            _resource.save(holiday,
                function (responce) {
                    deffered.resolve(responce);
                },

                function (responce) {
                    deffered.reject(responce);
                }
            );

            return deffered.promise;
        };

        holidayService.getHolidaysForYear = function (year) {
            var deffered = $q.defer();
            _resource.query({ year: year },
                function (responce) {
                    deffered.resolve(responce);
                },

                function (responce) {
                    deffered.reject(responce);
                }
            );

            return deffered.promise;
        };

        return holidayService;
    }]);
});
