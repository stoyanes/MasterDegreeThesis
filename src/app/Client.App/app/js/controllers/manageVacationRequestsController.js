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
                var openDatepickerPopup = function ($event, dpModel) {
                    $event.preventDefault();
                    $event.stopPropagation();
                    dpModel.popupOpenStatus = true;
                };

                $scope.dateModel = {
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


                $scope.submit = function () {
                };

                $scope.addClickHandler = function () {
                    ngDialog.open({
                        template: '../../app/views/templates/addOrUpdateHolidayTemplate.html',
                        scope: $scope
                    });
                };

                $scope.editClickHandler = function (rowEntity) {
                    ngDialog.open({
                        template: '../../app/views/templates/addOrUpdateHolidayTemplate.html',
                        scope: $scope
                    });
                };

                $scope.removeClickHandler = function (rowEntityId) {
                };

                $scope.gridOptions = {
                    data: '',
                    columnDefs: [
                        {
                            name: '',
                            field: ''
                        },
                        {
                            name: '',
                            field: ''
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
            }]); // end of controller
    }); // end of define
