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

                //$scope.setCurrentUser = function (user) {
                //    $scope.currentUser = user;
                //};

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
            }]);

    }); // end of define
