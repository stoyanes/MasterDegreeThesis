'use string';

define(
    [
        'angular',
        'angular-resource'
    ],

    function (angular) {
        var app = angular.module('app', [
            'ngResource'
        ]);
        return app;
    }
); // end of define