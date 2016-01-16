define([
    'app'
], function (app) {

    'use strict';

    app.factory('HolidayService', ['$resource', '$q', 'CONNECTION_CONSTANTS', function ($resource, $q, CONNECTION_CONSTANTS) {
        var _resource = $resource(CONNECTION_CONSTANTS.holidayUri + '/:id'),

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
            var localResourse = $resource(CONNECTION_CONSTANTS.holidayUri + '/ForYear');
            var deffered = $q.defer();
            localResourse.query({ year: year },
                function (responce) {
                    deffered.resolve(responce);
                },

                function (responce) {
                    deffered.reject(responce);
                }
            );

            return deffered.promise;
        };

        holidayService.removeHolidayAsync = function (holidayId) {
            var deffered = $q.defer();
            _resource.delete({ id: holidayId },
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
