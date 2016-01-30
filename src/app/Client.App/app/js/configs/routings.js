define(
    [
        'app',
        './constants'
    ],
    function (app) {
        'use strict';

        app.config(['$stateProvider', '$urlRouterProvider', 'USER_ROLES',
            function ($stateProvider, $urlRouterProvider, USER_ROLES) {

                // For any unmatched url, redirect to /
                $urlRouterProvider.otherwise("/");

                // Now set up the states
                $stateProvider
                    .state('login', {
                        url: '/',
                        templateUrl: 'app/views/login.html',
                        controller: 'LoginController',
                        data: {
                            authorizedRoles: [USER_ROLES.guest]
                        }
                    })
                    .state('system', {
                        url: '/system',
                        templateUrl: 'app/views/system.html',
                        controller: 'SystemController',
                        data: {
                            authorizedRoles: [USER_ROLES.admin, USER_ROLES.regular]
                        }
                    })
                    .state('admin', {
                        url: '/admin',
                        templateUrl: 'app/views/admin.html',
                        data: {
                            authorizedRoles: [USER_ROLES.admin]
                        }
                    })
                    .state('requestVacation', {
                        parent: 'system',
                        url: '/requestVacation',
                        templateUrl: 'app/views/requestVacation.html',
                        controller: 'RequestVacationController',
                        data: {
                            authorizedRoles: [USER_ROLES.admin, USER_ROLES.regular]
                        }
                    })
                    .state('userRequests', {
                        parent: 'system',
                        url: '/userRequests',
                        templateUrl: 'app/views/userRequests.html',
                        controller: 'UserRequestsController',
                        data: {
                            authorizedRoles: [USER_ROLES.admin, USER_ROLES.regular]
                        }
                    })
                    .state('requestsToApprove', {
                        parent: 'system',
                        url: '/requestsToApprove',
                        templateUrl: 'app/views/requestsToApprove.html',
                        controller: 'RequestApprovingController',
                        data: {
                            authorizedRoles: [USER_ROLES.admin, USER_ROLES.regular]
                        }
                    })
                    .state('manageHolidays', {
                        parent: 'system',
                        url: '/manageHolidays',
                        templateUrl: 'app/views/manageHolidays.html',
                        controller: 'HolidayController',
                        data: {
                            authorizedRoles: [USER_ROLES.admin]
                        }
                    })
                    .state('manageEmployees', {
                        parent: 'system',
                        url: '/manageEmployees',
                        templateUrl: 'app/views/manageEmployees.html',
                        controller: 'UserManagementController',
                        data: {
                            authorizedRoles: [USER_ROLES.admin]
                        }
                    })
                    .state('error', {
                        parent: 'system',
                        url: '/error',
                        templateUrl: 'app/views/error.html',
                        data: {
                            authorizedRoles: [USER_ROLES.admin, USER_ROLES.regular]
                        }
                    });
            }]);
    });
