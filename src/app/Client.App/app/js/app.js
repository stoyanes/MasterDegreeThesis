define(
    [
        'angular',
        'angular-resource',
        'angular-ui-router',
        'angular-ui-calendar',
        'angular-loading-bar'
    ],
    function (angular) {
        'use strict';

        var app = angular.module('app', [
            'ngResource',
            'ui.router',
            'ui.calendar',
            'angular-loading-bar'
        ]);


        /* Adding the auth interceptor here, to check every $http request*/
        app.config(['$httpProvider', function ($httpProvider) {
            $httpProvider.interceptors.push([
              '$injector',
              function ($injector) {
                  return $injector.get('AuthInterceptor');
              }
            ]);
        }]);
        return app;
    }
); // end of define