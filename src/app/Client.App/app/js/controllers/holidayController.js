define([
        'app',
],
    function (app) {
        'use strict';
        app.controller('HolidayController', [
            '$rootScope', '$scope', 'HolidayService', '$state',
            function ($rootScope, $scope, holidayService, $state) {
                var openDatepickerPopup = function ($event, dpModel) {
                    $event.preventDefault();
                    $event.stopPropagation();
                    dpModel.popupOpenStatus = true;
                };

                $scope.dateModel = {
                    date: null,
                    popupOpenStatus: false,
                    dateOptions: {
                        formatYear: 'yy',
                        startingDay: 1
                    },
                    togglePopUp: function ($event) {
                        openDatepickerPopup($event, this);
                    }
                };
                $scope.description = '';

                $scope.isValidHoliday = function () {
                    var isValidDate = $rootScope.isDate($scope.dateModel.date);
                    var isValidDescription = $scope.description !== '';
                    return isValidDate && isValidDescription;
                };

                $scope.submit = function () {
                    var holiday = {
                        workingDate: $scope.dateModel.date,
                        description: $scope.description
                    };
                    holidayService
                        .createHolidayAsync(holiday)
                        .then(
                        // success
                        function (res) {
                            $scope.description = '';
                            $scope.dateModel.date = null;
                        },
                        // error
                        function (res) {
                            $state.go('error');
                        });
                };
            }]); // end of controller
    }); // end of define
