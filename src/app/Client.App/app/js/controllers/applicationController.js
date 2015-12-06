define([
        'app',
        '../services/authenticationService'
    ],
    function (app) {
        'use strict';
        app.controller('ApplicationController', [
            '$scope', 'AuthenticationService', 'USER_ROLES', '$state', 'SessionService',
            function ($scope, authenticationService, USER_ROLES, $state, sessionService) {

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
            }]); // end of controller
    }); // end of define
