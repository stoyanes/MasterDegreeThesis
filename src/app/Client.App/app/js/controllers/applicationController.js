define([
    'app',
    '../services/authenticationService'
],
    function (app) {

        app.controller('ApplicationController', [
            '$scope', 'AuthenticationService', 'USER_ROLES',
         function ($scope, authenticationService, USER_ROLES) {

             $scope.currentUser;
             $scope.userRoles = USER_ROLES;
             $scope.isAuthorized = authenticationService.isAuthorized;

             $scope.setCurrentUser = function (user) {
                 $scope.currentUser = user;
             };
         }]);

    }); // end of define
