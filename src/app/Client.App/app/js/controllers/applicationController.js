define([
        'app',
        '../services/authenticationService'
    ],
    function (app) {
        'use strict';
        app.controller('ApplicationController', [
            '$scope', 'AuthenticationService', 'USER_ROLES', '$state',
            function ($scope, authenticationService, USER_ROLES, $state) {

                if(!authenticationService.isAuthenticated()) {
                    $state.go('login');
                }

                $scope.currentUser = undefined;
                $scope.userRoles = USER_ROLES;
                $scope.isAuthorized = authenticationService.isAuthorized;

                $scope.setCurrentUser = function (user) {
                    $scope.currentUser = user;
                };

                $scope.isCurrentUserInRole = function (currentUser, role) {
                    if (currentUser && currentUser.userRoles) {
                        return currentUser.userRoles.indexOf(role) !== -1;
                    }
                    return false;
                };
            }]);

    }); // end of define
