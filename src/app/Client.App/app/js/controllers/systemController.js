define([
        'app'
],
    function (app) {
        'use strict';
        app.controller('SystemController', [
            '$rootScope', '$scope', '$state', 'LeaveDaysService', 'EmployeeService', 'HolidayService',
            function ($rootScope, $scope, $state, leaveDaysService, employeeService, holidayService) {

                $scope.calendarData = [];
                $scope.leaveDays = [];
                $scope.currentEmployeeInfo = {};
                $rootScope.nonWorkingDays = [];

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

                $scope.getLeaveDays();
                $scope.getCurrentEmployeeInfo();
                $scope.getNonWorkingDays();
            }]); // end of controller
    }); // end of define
