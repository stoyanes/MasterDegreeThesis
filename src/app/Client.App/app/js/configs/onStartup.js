define(
    [
        'app',
        './constants',
        '../services/authenticationService'
    ],
    function (app) {
        "use strict";
        app.run(['$rootScope', 'AuthenticationService', 'AUTH_EVENTS',
            function ($rootScope, authenticationService, AUTH_EVENTS) {

                $rootScope.$on('$stateChangeStart', function (event, next) {
                    var authorizedRoles = next.data.authorizedRoles;
                    if (!authenticationService.isAuthorized(authorizedRoles)) {
                        event.preventDefault();
                        if (authenticationService.isAuthenticated()) {
                            // user is not allowed
                            $rootScope.$broadcast(AUTH_EVENTS.notAuthorized);
                        } else {
                            // user is not logged in
                            $rootScope.$broadcast(AUTH_EVENTS.notAuthenticated);
                        }
                    }
                });
            }]);
    });