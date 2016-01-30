define([
    'app',
],
    function (app) {
        'use strict';
        app.controller('HolidayController', [
            '$rootScope', '$scope', 'HolidayService', '$state', 'ngDialog',
            function ($rootScope, $scope, holidayService, $state, ngDialog) {
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

                $scope.holidayObj = {
                    holidayId: -1,
                    description: ''
                };

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
                    $scope.holidayObj.description = holiday.description;
                    $scope.holidayObj.holidayId = holiday.id;
                };

                $scope.submit = function () {
                    var holiday = {
                        workingDate: $scope.dateModel.date,
                        description: $scope.holidayObj.description,
                        id: $scope.holidayObj.holidayId
                    };

                    ngDialog.close();

                    holidayService
                        .createHolidayAsync(holiday)
                        .then(
                            // success
                            function (res) {
                                $scope.holidayObj.description = '';
                                $scope.dateModel.date = null;
                                $scope.holidayObj.holidayId = 0;
                                updateNonWorkingDays();
                            },
                            // error
                            function (res) {
                                $state.go('error');
                            });
                };

                $scope.addClickHandler = function () {
                    ngDialog.open({
                        template: '../../app/views/templates/addOrUpdateHolidayTemplate.html',
                        scope: $scope
                    });
                };

                $scope.editClickHandler = function (rowEntity) {
                    $scope.holidayObj.holidayId = rowEntity.id;
                    $scope.holidayObj.description = rowEntity.description;
                    $scope.dateModel.date = new Date(rowEntity.workingDate);

                    ngDialog.open({
                        template: '../../app/views/templates/addOrUpdateHolidayTemplate.html',
                        scope: $scope
                    });
                };

                $scope.removeClickHandler = function (rowEntity) {
                    $scope.removeHoliday(rowEntity.id);
                };

                $scope.gridOptions = {
                    data: $rootScope.nonWorkingDays,
                    columnDefs: [
                        {
                            name: 'workingDate',
                            field: 'workingDate'
                        },
                        {
                            name: 'description',
                            field: 'description'
                        },
                        {
                            name: 'Actions',
                            cellTemplate: '../../app/views/templates/gridRowActionsTemplate.html',
                            enableFiltering: false,
                            enableSorting: false,
                            enableHiding: false
                        }
                    ],

                    enableFiltering: true
                };
            }]); // end of controller
    }); // end of define
