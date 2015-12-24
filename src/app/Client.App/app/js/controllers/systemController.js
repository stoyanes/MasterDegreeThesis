define([
        'app'
],
    function (app) {
        'use strict';
        app.controller('SystemController', [
            '$scope', '$state', 'LeaveDaysService',
            function ($scope, $state, leaveDaysService) {
                $scope.calendarData = [];
                $scope.leaveDays = {};

                $scope.getLeaveDays = function () {
                    leaveDaysService
                        .getLeaveDaysAsync((new Date()).getFullYear())
                        .then(
                        // success
                        function (resultData) {
                            $scope.leaveDays = resultData;
                        },
                        // error
                        function () {
                            $state.go('error');
                        });
                };

                $scope.getLeaveDays();
            }]); // end of controller
    }); // end of define
