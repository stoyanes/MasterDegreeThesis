define([
    'app'
],
    function (app) {
        'use strict';
        app.controller('UserRequestsController', [
            '$rootScope', '$scope', '$window',
            function ($rootScope, $scope, $window) {
                $scope.currentUserRequestToPrint = {};
                $scope.updateCurrentSelectedRequestToPrint = function (currentRequest) {
                    $scope.currentUserRequestToPrint = angular.copy(currentRequest);
                    // $rootScope.triggerDigest();
                    // $window.print();
                };
            }]); // end of controller
    }); // end of define
