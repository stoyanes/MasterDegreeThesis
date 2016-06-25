define([
    'app'
],
    function (app) {
        'use strict';
        app.controller('RequestApprovingController', [
           '$rootScope', '$scope', '$state', 'RequestVacationService',
            function ($rootScope, $scope, $state, requestVacationService) {

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
