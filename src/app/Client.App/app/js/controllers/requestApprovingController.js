define([
    'app'
],
    function (app) {
        'use strict';
        app.controller('RequestApprovingController', [
           '$rootScope', '$scope', '$state', 'RequestVacationService',
            function ($rootScope, $scope, $state, requestVacationService) {

                $scope.getVacationTypeName = function (vacationType) {
                    var vacationTypeName = '';
                    switch (vacationType) {
                        case 1: vacationTypeName = 'Paid'; break;
                        case 2: vacationTypeName = 'Unpaid'; break;
                        case 3: vacationTypeName = 'Sickness'; break;
                        default: vacationTypeName = 'None'; break;
                    }
                    return vacationTypeName;
                };

                $scope.getStatusName = function (status) {
                    var statusName = '';
                    switch (status) {
                        case 1: statusName = 'Submitted'; break;
                        case 2: statusName = 'Approved'; break;
                        case 3: statusName = 'Rejected'; break;
                        default: statusName = 'None'; break;
                    }
                    return statusName;
                };

                $scope.getCssClass = function (userRequest) {
                    var cssClass = '';
                    switch (userRequest.status) {
                        case 1: cssClass = 'list-group-item-info'; break;
                        case 2: cssClass = 'list-group-item-success'; break;
                        case 3: cssClass = 'list-group-item-danger'; break;
                        default: cssClass = 'list-group-item-warning'; break;
                    }
                    return cssClass;
                };

                $scope.requestsToApprove = [];

                $scope.getRequestsToApprove = function () {
                    requestVacationService
                        .getRequestsToApprove()
                        .then(
                        // success
                        function (resultData) {
                            $scope.requestsToApprove = resultData;
                        },
                        // error
                        function () {
                            $state.go('error');
                        });
                };

                var getVacationRequestById = function (vacationReqs, vaqReqId) {
                    var resVaqReq;
                    vacationReqs.forEach(function (currRequest, index) {
                        if (currRequest.id === vaqReqId) {
                            resVaqReq = currRequest;
                            return;
                        }
                    });
                    return resVaqReq;
                };

                $scope.approveRequest = function (requestId) {
                    var vaqReqToUpdate = getVacationRequestById($scope.requestsToApprove, requestId);

                    if (vaqReqToUpdate) {
                        vaqReqToUpdate.status = 2;
                        requestVacationService
                            .updateVacationRequest(vaqReqToUpdate)
                            .then(
                            // success
                            function (resultData) {
                                $scope.getRequestsToApprove();
                            },
                            // error
                            function () {
                                $state.go('error');
                            });
                    }
                };

                $scope.rejectRequest = function (requestId) {
                    var vaqReqToUpdate = getVacationRequestById($scope.requestsToApprove, requestId);

                    if (vaqReqToUpdate) {
                        vaqReqToUpdate.status = 3;
                        requestVacationService
                            .updateVacationRequest(vaqReqToUpdate)
                            .then(
                            // success
                            function (resultData) {
                                $scope.getRequestsToApprove();
                            },
                            // error
                            function () {
                                $state.go('error');
                            });
                    }
                };

                $scope.getRequestsToApprove();
            }]); // end of controller
    }); // end of define
