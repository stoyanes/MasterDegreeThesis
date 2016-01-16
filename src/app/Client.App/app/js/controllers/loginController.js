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
                    userName: 'admin@myemail.com', // 'employee1@myemail.com',
                    userPassword: 'Temp_123'
                };
                $scope.isLoginButtonDisabled = false;

                $scope.authenticate = function (credentials) {
                    $scope.isLoginButtonDisabled = true;
                    var authenticationData = {
                        'grant_type': 'password',
                        'userName': credentials.userName,
                        'password': credentials.userPassword
                    };

                    var authPromise = autherticationService
                                        .authenticateAsync($.param(authenticationData));

                    authPromise
                        .then(
                        function () {
                            $state.go('system');
                        },
                        function () {
                            $state.go('notAuthenticated');
                        })
                        .finally(function () {
                            $scope.isLoginButtonDisabled = false;
                        });
                };
            }]); // end of controller
    }); // end of define