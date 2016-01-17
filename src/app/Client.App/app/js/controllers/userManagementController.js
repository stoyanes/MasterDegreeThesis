define([
    'app'
],
    function (app) {
        'use strict';
        app.controller('UserManagementController', [
           '$rootScope', '$scope', '$state', 'UsersManagementService', 'EmployeeService',
            function ($rootScope, $scope, $state, userManagementService, employeeService) {
                $scope.userModel = {
                    name: '',
                    password: ''
                };

                $scope.allEmployees = [];

                $scope.isValidUserDetails = function () {
                    var isValidUserName = $scope.userModel.name !== '';
                    var isValidUserPass = $scope.userModel.password !== '';
                    return isValidUserName && isValidUserPass;
                };

                $scope.registerUser = function () {
                    var userToRegister = {
                        // TODO move this to configuration
                        email: $scope.userModel.name + '@company.com',
                        password: $scope.userModel.password,
                        confirmPassword: $scope.userModel.password
                    };

                    userManagementService
                        .registerUserAsync(userToRegister)
                        .then(
                        // success
                        function () {
                            $state.go($state.current, {}, { reload: true });
                        },
                        // error
                        function () {
                            $state.go('error')
                        });
                };

                $scope.getAllEmployees = function () {
                    employeeService
                        .getAll()
                        .then(
                        // success
                        function (res) {
                            $scope.allEmployees = res;
                        },
                        // error
                        function () {
                            $state.go('error');
                        });
                };

                $scope.updateUserManager = function (user, selectedManager) {
                    if (selectedManager) {
                        user.manager = selectedManager;
                        employeeService
                        .updateEmployee(user)
                        .then(
                        // success
                        function () {
                            $state.go($state.current, {}, { reload: true });
                        },
                        // error
                        function () {
                            $state.go('error');
                        });
                    }

                };

                $scope.getAllEmployees();
            }
        ]) // end of controller
    }); // end of define
