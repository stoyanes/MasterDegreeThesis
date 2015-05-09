'use string';

define(
    [
        'angular',
        'angular-resource',
        'angular-ui-router'
    ],

    function (angular) {
        var app = angular.module('app', [
            'ngResource',
            'ui.router'
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