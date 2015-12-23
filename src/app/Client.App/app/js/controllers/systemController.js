define([
        'app'
    ],
    function (app) {
        'use strict';
        app.controller('SystemController', [
            '$scope', '$state',
            function ($scope, $state) {
                $scope.eventsData = [];

                //$scope.showNestedView = function () {
                //    return $state.current.name === 'requestVacation' || $state.current.name === 'userRequests';
                //};
                $scope.showCalendar = function () {
                    return $state.current.name === 'system';
                };
            }]); // end of controller
    }); // end of define
