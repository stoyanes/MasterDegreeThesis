define([
        'app',
        '../services/authenticationService'
    ],
    function (app) {
        'use strict';
        app.controller('ApplicationController', [
            '$rootScope', '$scope', 'AuthenticationService', 'USER_ROLES', '$state', 'SessionService',
            function ($rootScope, $scope, authenticationService, USER_ROLES, $state, sessionService) {

                if(!authenticationService.isAuthenticated()) {
                    $state.go('login');
                }

                $scope.currentUser = sessionService.getUserSession();
                $scope.userRoles = USER_ROLES;
                $scope.isAuthorized = authenticationService.isAuthorized;

                $scope.isCurrentUserInRole = function (currentUser, role) {
                    if (currentUser && currentUser.userRoles) {
                        return currentUser.userRoles.indexOf(role) !== -1;
                    }
                    return false;
                };

                $scope.getMess = function() {
                    return timeOffSystemLang.appName;
                };
                $scope.logOut = function () {
                    sessionService.destroySession();
                    $state.go('login');
                };

                $scope.$on('IdleStart', function () {
                    // the user appears to have gone idle
                    if (!$scope.isCurrentUserInRole($scope.currentUser, $scope.userRoles.guest)) {
                        $scope.logOut();
                    }
                });

                $rootScope.getVacationTypeName = function (vacationType) {
                    var vacationTypeName = '';
                    switch (vacationType) {
                        case 1: vacationTypeName = 'Paid'; break;
                        case 2: vacationTypeName = 'Unpaid'; break;
                        case 3: vacationTypeName = 'Sickness'; break;
                        case 4: vacationTypeName = 'Marriage'; break;
                        case 5: vacationTypeName = 'BloodDonation'; break;
                        case 6: vacationTypeName = 'Death'; break;
                        case 7: vacationTypeName = 'Motherhood'; break;
                        case 8: vacationTypeName = 'Other'; break;
                        default: vacationTypeName = 'None'; break;
                    }
                    return vacationTypeName
                };

                $rootScope.getStatusName = function (status) {
                    var statusName = '';
                    switch (status) {
                        case 1: statusName = 'Submitted'; break;
                        case 2: statusName = 'Approved'; break;
                        case 3: statusName = 'Rejected'; break;
                        default: statusName = 'None'; break;
                    }
                    return statusName;
                };

                $rootScope.getCssClass = function (userRequest) {
                    var cssClass = '';
                    switch (userRequest.status) {
                        case 1: cssClass = 'list-group-item-info'; break;
                        case 2: cssClass = 'list-group-item-success'; break;
                        case 3: cssClass = 'list-group-item-danger'; break;
                        default: cssClass = 'list-group-item-warning'; break;
                    }
                    return cssClass;
                };
            }]); // end of controller
    }); // end of define
