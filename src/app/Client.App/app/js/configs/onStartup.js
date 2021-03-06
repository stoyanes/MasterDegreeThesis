﻿define(
    [
        'app',
        './constants',
        '../services/authenticationService'
    ],
    function (app) {
        'use strict';
        app.run(['$rootScope', 'AuthenticationService', 'AUTH_EVENTS', 'Idle', '$state',
            function ($rootScope, authenticationService, AUTH_EVENTS, idle, $state) {

                $rootScope.$on('$stateChangeStart', function (event, next) {
                    var authorizedRoles = next.data.authorizedRoles;
                    if (!authenticationService.isAuthorized(authorizedRoles)) {
                        event.preventDefault();
                        if (!authenticationService.isAuthenticated()) {
                            // user is not logged in
                            $rootScope.$broadcast(AUTH_EVENTS.notAuthenticated);
                        } else {
                            // user is not allowed
                            $rootScope.$broadcast(AUTH_EVENTS.notAuthorized);
                        }
                    }
                });

                idle.watch();

                $rootScope.isDefined = function (obj) {
                    return obj !== null && obj !== undefined;
                };

                $rootScope.isDate = function (date) {
                    return Object.prototype.toString.call(date) === "[object Date]";
                };

                $rootScope.triggerDigest = function () {
                    return !$rootScope.$$phase && $rootScope.$apply();
                };
            }]);
    });
