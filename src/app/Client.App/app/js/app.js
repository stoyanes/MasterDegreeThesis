define(
    [
        'angular',
        'angular-resource',
        'angular-ui-router',
        'angular-ui-calendar',
        'angular-loading-bar',
        'angular-animate',
        'ng-idle'
    ],
    function (angular) {
        'use strict';

        var app = angular.module('app', [
            'ngResource',
            'ui.router',
            'ui.calendar',
            'angular-loading-bar',
            'ngAnimate',
            'ngIdle'
        ]);

        /* Adding the auth interceptor here, to check every $http request*/
        app.config(['$httpProvider', 'IdleProvider', function ($httpProvider, idleProvider) {
            $httpProvider.interceptors.push([
              '$injector',
              function ($injector) {
                  return $injector.get('AuthInterceptor');
              }
            ]);

            // managing user idle
            idleProvider.idle(20 * 60); // in seconds
            idleProvider.timeout(20 * 60); // in seconds
        }]);
        return app;
    }
); // end of define