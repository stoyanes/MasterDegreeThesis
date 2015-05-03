define([
    'app',
    '../services/authenticationService'
],
    function (app) {

        app.controller('LoginController', [
            '$scope', 'AuthenticationService', 'SessionService',
         function ($scope, autherticationService, sessionService) {

             $scope.credentials = {
                 userName: '',
                 userPassword: ''
             };

             $scope.authenticate = function (credentials) {

                 var authenticationData = {
                     'grant_type': 'password',
                     'userName': credentials.userName,
                     'password': credentials.userPassword
                 };

                 var authPromise = autherticationService.authenticateAsync($.param(authenticationData));

                 authPromise.then(
                     function (data) {
                         console.log('ok = ', data);
                         console.log('Testing user session', sessionService.getUserSession());
                     },
                     function (data) {
                         console.log('not ok = ', data);
                     });
             };

         }]); // end of controller

    }); // end of define