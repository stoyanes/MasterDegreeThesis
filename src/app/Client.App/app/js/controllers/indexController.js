define([
    'app',
    '../services/authenticationService'
],
    function (app) {

        app.controller('IndexController', [
            '$scope', 'AuthenticationService',
         function ($scope, autherticationService) {

             $scope.userName = '';
             $scope.userPassword = '';

             $scope.authenticate = function () {
                 var authenticationData = {
                     'grant_type': 'password',
                     'userName': $scope.userName,
                     'password': $scope.userPassword
                 };

                 var authPromise = autherticationService.authenticateAsync($.param(authenticationData));

                 authPromise.then(
                     function (data) {
                         console.log('ok = ', data)
                     },
                     function (data) {
                         console.log('not ok = ', data)
                     });
             }

         }]); // end of controller

    }); // end of define