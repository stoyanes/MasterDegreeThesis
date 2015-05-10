define([
        'app',
        '../services/authenticationService'
    ],
    function (app) {
        'use strict';
        app.controller('LoginController', [
            '$scope', 'AuthenticationService', 'SessionService', '$state',
            function ($scope, autherticationService, sessionService, $state) {

                $scope.credentials = {
                    userName: 'admin@myemail.com',
                    userPassword: 'Temp_123'
                };

                $scope.authenticate = function (credentials) {

                    var authenticationData = {
                        'grant_type': 'password',
                        'userName': credentials.userName,
                        'password': credentials.userPassword
                    };

                    var authPromise = autherticationService.authenticateAsync($.param(authenticationData));

                    authPromise.then(
                        function () {
                            $scope.setCurrentUser(sessionService.getUserSession());
                            $state.go('home');
                        },
                        function () {
                            $state.go('notAuthenticated');
                        });
                };

            }]); // end of controller

    }); // end of define