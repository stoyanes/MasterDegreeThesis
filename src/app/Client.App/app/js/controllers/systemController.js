define([
    'app'
],
    function (app) {
        'use strict';
        app.controller('SystemController', [
            '$rootScope', '$scope', '$state', 'LeaveDaysService', 'EmployeeService', 'HolidayService', 'RequestVacationService',
            function ($rootScope, $scope, $state, leaveDaysService, employeeService, holidayService, requestVacationService) {

                $scope.leaveDays = [];
                $scope.currentEmployeeInfo = {};
                $rootScope.nonWorkingDays = [];
                $rootScope.userRequests = [];

                $rootScope.calendarOptions = {
                    events: [],
                    eventOverlap: false
                };

                $scope.getNonWorkingDays = function () {
                    holidayService
                        .getHolidaysForYear((new Date()).getFullYear())
                        .then(
                            // success
                            function (resultData) {
                                $rootScope.nonWorkingDays = resultData;
                            },
                            // error
                            function () {
                                $state.go('error');
                            });
                };

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

                $scope.getCurrentEmployeeInfo = function () {
                    employeeService
                        .getCurrentEmployeeInfo()
                        .then(
                            // success
                            function (resultData) {
                                $scope.currentEmployeeInfo = resultData;
                            },
                            // error
                            function () {
                                $state.go('error');
                            });
                };

                $scope.getApprovalManagerName = function () {
                    var managerName = 'You have no approval manager.';

                    if ($scope.currentEmployeeInfo.manager) {
                        managerName = $scope.currentEmployeeInfo.manager.userName;
                    }

                    return managerName;
                };

                $scope.getUserRequests = function () {
                    requestVacationService
                        .getAllRequestsForCurrentUserAsync()
                        .then(
                            // success
                            function (resultData) {
                                $rootScope.userRequests = resultData;
                            },
                            // error
                            function () {
                                $state.go('error');
                            });
                };

                $scope.getUserRequests();
                $scope.getLeaveDays();
                $scope.getCurrentEmployeeInfo();
                $scope.getNonWorkingDays();

                var mapNonWorkingDateToEventDate = function (nonWorkingDates) {
                    var eventMappedCalendarDates = $rootScope.nonWorkingDays.map(function (val, index) {
                        return {
                            start: new Date(val.workingDate),
                            title: val.description,
                            allDay: true
                        };
                    });
                    return eventMappedCalendarDates;
                };

                var mapUserRequestsToEventDate = function () {
                    var eventMappedUserRequests = $rootScope.userRequests.map(function (val, index) {
                        return {
                            start: new Date(val.startDate),
                            end: new Date(val.endDate),
                            title: 'Vacation: ' + val.description,
                            allDay: true
                        };
                    });
                    return eventMappedUserRequests;
                };

                var updateCalendarEvents = function () {
                    var eventMappedCalendarDates = mapNonWorkingDateToEventDate();
                    var eventMappedUserRequests = mapUserRequestsToEventDate();
                    $rootScope.calendarOptions.events = [];
                    $rootScope.calendarOptions.events = $rootScope.calendarOptions.events.concat(eventMappedCalendarDates);
                    $rootScope.calendarOptions.events = $rootScope.calendarOptions.events.concat(eventMappedUserRequests);
                };
                $rootScope.$watch('userRequests', function (newValue, oldValue) {
                    if (newValue !== oldValue) {
                        updateCalendarEvents();
                    }

                });

                $rootScope.$watch('nonWorkingDays', function (newValue, oldValue) {
                    if (newValue !== oldValue) {
                        updateCalendarEvents();
                    }
                });
            }]); // end of controller
    }); // end of define
