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
                        url: "/",
                        templateUrl: "app/views/login.html",
                        controller: 'LoginController',
                        data: {
                            authorizedRoles: [USER_ROLES.guest]
                        }
                    })
                    .state('home', {
                        url: "/home",
                        templateUrl: "app/views/home.html",
                        controller: 'HomeController',
                        data: {
                            authorizedRoles: [USER_ROLES.admin, USER_ROLES.regular]
                        }
                    })
                    .state('admin', {
                        url: "/admin",
                        templateUrl: "app/views/admin.html",
                        data: {
                            authorizedRoles: [USER_ROLES.admin]
                        }
                    });
            }]);
    });