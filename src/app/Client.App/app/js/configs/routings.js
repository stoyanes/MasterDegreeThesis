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
                    .state('notAuthenticated', {
                        url: "/",
                        templateUrl: "app/views/login.html",
                        data: {
                            authorizedRoles: [USER_ROLES.guest]
                        }
                    })
                    .state('home', {
                        url: "/home",
                        templateUrl: "app/views/home.html",
                        data: {
                            authorizedRoles: [USER_ROLES.admin, USER_ROLES.regular]
                        }
                    });
                //.state('state2', {
                //    url: "/state2",
                //    templateUrl: "templates/state2.html",
                //    data: {
                //        authorizedRoles: [USER_ROLES.admin, USER_ROLES.regular]
                //    }
                //})
                //.state('adminState', {
                //    url: "/adminState",
                //    templateUrl: "templates/adminState.html",
                //    data: {
                //        authorizedRoles: [USER_ROLES.admin]
                //    }
                //})

            }]);
    });