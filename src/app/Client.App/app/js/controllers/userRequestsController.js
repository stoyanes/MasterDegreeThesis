define([
    'app'
],
    function (app) {
        'use strict';
        app.controller('UserRequestsController', [
            '$rootScope','$scope',
            function ($rootScope, $scope) {
                $scope.getStatusName = function (status) {
                    var statusName = '';
                    switch(status) {
                        case 1: statusName = 'Submitted'; break;
                        case 2: statusName = 'Approved'; break;
                        case 3: statusName = 'Rejected'; break;
                        default: statusName = 'None'; break;
                    }
                    return statusName;
                };

                $scope.getCssClass = function (userRequest) {
                    var cssClass = '';
                    switch(userRequest.status){
                        case 1: cssClass = 'list-group-item-info'; break;
                        case 2: cssClass = 'list-group-item-success'; break;
                        case 3: cssClass = 'list-group-item-danger'; break;
                        default: cssClass = 'list-group-item-warning'; break;
                    }
                    return cssClass;
                };
            }]); // end of controller
    }); // end of define
