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
                $scope.holidayId = 0;

                $scope.isValidHoliday = function () {
                    var isValidDate = $rootScope.isDate($scope.dateModel.date);
                    var isValidDescription = $scope.description !== '';
                    return isValidDate && isValidDescription;
                };

                var updateNonWorkingDays = function () {
                    holidayService
                        .getHolidaysForYear((new Date()).getFullYear())
                        .then(function (res) {
                            $rootScope.nonWorkingDays = res;
                        }, function () {
                            $state.go('error');
                        });
                };

                $scope.removeHoliday = function (holiday) {
                    holidayService
                        .removeHolidayAsync(holiday.id)
                        .then(
                        // success
                        function () {
                            updateNonWorkingDays();
                        },
                        // error
                        function () {
                            $state.go('error');
                        });

                };

                $scope.updateHoliday = function (holiday) {
                    $scope.dateModel.date = new Date(holiday.workingDate);
                    $scope.description = holiday.description;
                    $scope.holidayId = holiday.id;
                };

                $scope.submit = function () {
                    var holiday = {
                        workingDate: $scope.dateModel.date,
                        description: $scope.description,
                        id: $scope.holidayId
                    };
                    holidayService
                        .createHolidayAsync(holiday)
                        .then(
                        // success
                        function (res) {
                            $scope.description = '';
                            $scope.dateModel.date = null;
                            $scope.holidayId = 0;
                            updateNonWorkingDays();
                        },
                        // error
                        function (res) {
                            $state.go('error');
                        });
                };
            }]); // end of controller
    }); // end of define
