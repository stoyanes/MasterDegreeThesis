/* global angular */
define([
    'app'
],
    function (app) {
        'use strict';
        app.controller('UserManagementController', [
            '$rootScope',
            '$scope',
            '$state',
            'UsersManagementService',
            'EmployeeService',
            'ngDialog',
            function ($rootScope, $scope, $state, userManagementService, employeeService, ngDialog) {
                $scope.userModel = {
                    name: '',
                    password: ''
                };

                $scope.userEditModel = {
                    id: -1,
                    userName: undefined,
                    manager: undefined
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
                        confirmPassword: $scope.userModel.password,
                        roles: ["admin"]
                    };
                    ngDialog.close();
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

                $scope.removeEmployee = function (employeeId) {
                    employeeService
                        .removeUserAsync(employeeId)
                        .then(
                            // success
                            function (res) {
                                $scope.getAllEmployees();
                            },
                            // error
                            function () {
                                $state.go('error');
                            });
                };

                $scope.updateUser = function (user) {
                    ngDialog.close();
                    
                    employeeService
                        .updateEmployee(user)
                        .then(
                            // success
                            function (res) {
                                $scope.getAllEmployees();
                            },
                            // error
                            function () {
                                $state.go('error');
                            });
                };
                $scope.addClickHandler = function () {
                    ngDialog.open({
                        template: '../../app/views/templates/addEmployeeTemplate.html',
                        scope: $scope
                    });
                };

                $scope.editClickHandler = function (rowEntity) {
                    $scope.userEditModel = angular.copy(rowEntity);
                    ngDialog.open({
                        template: '../../app/views/templates/updateEmployeeTemplate.html',
                        scope: $scope
                    });
                };

                $scope.removeClickHandler = function (rowEntity) {
                    $scope.removeEmployee(rowEntity.id);
                };
                $scope.gridOptions = {
                    data: 'allEmployees',
                    columnDefs: [
                        {
                            name: 'id',
                            field: 'id'
                        },
                        {
                            name: 'userName',
                            field: 'userName'
                        },
                        {
                            name: 'manager',
                            field: 'manager.userName'
                        },
                        {
                            name: 'Actions',
                            cellTemplate: '../../app/views/templates/gridRowActionsTemplate.html',
                            enableFiltering: false,
                            enableSorting: false,
                            enableHiding: false
                        }
                    ],

                    enableFiltering: true
                };

                $scope.getAllEmployees();
            }
        ]) // end of controller
    }); // end of define
