define([
    'app',
],
    function (app) {
        'use strict';
        
        app.controller('ManageVacationRequestsController', [
            '$rootScope',
            '$scope',
            'RequestVacationService',
            '$state',
            'ngDialog',

            function ($rootScope, $scope, requestVacationService, $state, ngDialog) {

                $scope.allRequests = [];

                $scope.currentVacationRequest = {
                    id: -1,
                    employeeID: -1,
                    employeeUserName: '',
                    startDate: '',
                    endDate: '',
                    description: '',
                    status: -1,
                    vacationType: -1
                };

                $scope.getAllRequests = function () {
                    requestVacationService
                        .getAllRequestsAsync()
                        .then(
                        // success
                        function (res) {
                            $scope.allRequests = res;
                        },
                        // error
                        function () {
                            $state.go('error');
                        });
                }

                var openDatepickerPopup = function ($event, dpModel) {
                    $event.preventDefault();
                    $event.stopPropagation();
                    dpModel.popupOpenStatus = true;
                };

                $scope.startDateModel = {
                    date: null,
                    popupOpenStatus: false,
                    dateOptions: {
                        formatYear: 'yy',
                        startingDay: 1
                    },
                    togglePopUp: function ($event) {
                        openDatepickerPopup($event, this);
                    }
                };

                $scope.endDateModel = {
                    date: null,
                    popupOpenStatus: false,
                    dateOptions: {
                        formatYear: 'yy',
                        startingDay: 1
                    },
                    togglePopUp: function ($event) {
                        openDatepickerPopup($event, this);
                    }
                };

                $scope.statusOptions = [
                    {
                        status: 1,
                        label: 'Submitted'
                    },
                    {
                        status: 2,
                        label: 'Approved'
                    },
                    {
                        status: 3,
                        label: 'Rejected'
                    }
                ];

                $scope.vacationTypeSelectOptions = [
                    {
                        vacationType: 1,
                        label: 'Paid'
                    },
                    {
                        vacationType: 2,
                        label: 'Unpaid'
                    },
                    {
                        vacationType: 3,
                        label: 'Sickness'
                    },
                    {
                        vacationType: 4,
                        label: 'Marriage'
                    },
                    {
                        vacationType: 5,
                        label: 'BloodDonation'
                    },
                    {
                        vacationType: 6,
                        label: 'Death'
                    },
                    {
                        vacationType: 7,
                        label: 'Other'
                    }
                ];

                $scope.getVacationTypeName = function (vacationType) {
                    var res = '';

                    switch (vacationType) {
                        case 1:
                            res = 'Paid';
                            break;
                        case 2:
                            res = 'Unpaid';
                            break;
                        case 3:
                            res = 'Sickness';
                            break;
                        case 4:
                            res = 'Marriage';
                            break;
                        case 5:
                            res = 'Blooddonation';
                            break;
                        case 6:
                            res = 'Death';
                            break;

                        default:
                            break;
                    }

                    return res;
                };

                $scope.submit = function () {

                    ngDialog.close();

                    $scope.currentVacationRequest.status = $scope.currentSelectedStatus.value.status || 0;
                    $scope.currentVacationRequest.vacationType = $scope.currentSelectedVacationType.value.vacationType || 0;

                    requestVacationService
                        .updateVacationRequest($scope.currentVacationRequest)
                        .then(
                        // success
                        function (res) {
                            $scope.currentVacationRequest = {
                                id: -1,
                                employeeID: -1,
                                employeeUserName: '',
                                startDate: '',
                                endDate: '',
                                description: '',
                                status: -1,
                                vacationType: -1
                            };
                            $state.go($state.current, {}, { reload: true });
                        },
                        // error
                        function (res) {
                            $state.go('error');
                        });
                };

                $scope.getDefaultOption = function (option) {

                    var filtered = $scope.statusOptions.filter(function (element) {
                        return element.status === option;
                    })[0];
                    return filtered;
                };

                $scope.editClickHandler = function (rowEntity) {

                    $scope.currentVacationRequest.id = rowEntity.id;
                    $scope.currentVacationRequest.employeeID = rowEntity.employeeID;
                    $scope.currentVacationRequest.employeeUserName = rowEntity.employeeUserName;
                    $scope.currentVacationRequest.startDate = rowEntity.startDate;
                    $scope.currentVacationRequest.endDate = rowEntity.endDate;
                    $scope.currentVacationRequest.status = rowEntity.status;
                    $scope.currentVacationRequest.vacationType = rowEntity.vacationType;
                    $scope.currentSelectedStatus = { value: rowEntity.status };
                    $scope.currentSelectedVacationType = { value: rowEntity.vacationType };

                    ngDialog.open({
                        template: '../../app/views/templates/updateVacationRequestTemplate.html',
                        scope: $scope
                    });
                };

                $scope.removeClickHandler = function (rowEntity) {
                    requestVacationService
                        .deleteAsync(rowEntity.id)
                        .then(
                        // success
                        function (res) {
                            $scope.currentVacationRequest = {
                                id: -1,
                                employeeID: -1,
                                employeeUserName: '',
                                startDate: '',
                                endDate: '',
                                description: '',
                                status: -1,
                                vacationType: -1
                            };
                            $state.go($state.current, {}, { reload: true });
                        },
                        // error
                        function (res) {
                            $state.go('error');
                        });
                };

                $scope.gridOptions = {
                    data: 'allRequests',
                    columnDefs: [
                        {
                            name: 'id',
                            field: 'id'
                        },
                        {
                            name: 'User Name',
                            field: 'employeeUserName'
                        },
                        {
                            name: 'Start Date',
                            field: 'startDate'
                        },
                        {
                            name: 'End Date',
                            field: 'endDate'
                        },
                        {
                            name: 'Description',
                            field: 'description'
                        },
                        {
                            name: 'Status',
                            field: 'status',
                            cellTemplate: '<span>{{ grid.appScope.getStatusName(row.entity.status)}}</span>'
                        },
                        {
                            name: 'Vacation Type',
                            field: 'vacationType',
                            cellTemplate: '<span> {{ grid.appScope.getVacationTypeName(row.entity.vacationType) }} </span>'
                        },
                        {
                            name: 'Actions',
                            cellTemplate: '../../app/views/templates/gridRowActionsTemplate.html',
                            enableFiltering: false,
                            enableSorting: false,
                            enableHiding: false
                        }
                    ],

                    enableFiltering: true
                };

                $scope.getAllRequests();

            }]); // end of controller
    }); // end of define
