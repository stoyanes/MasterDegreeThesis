define([
        'app'
],
    function (app) {
        'use strict';
        app.controller('RequestVacationController', [
            '$scope', '$state', 'RequestVacationService',
            function ($scope, $state, requestVacationService) {

                var openDatepickerPopup = function ($event, dpModel) {
                    $event.preventDefault();
                    $event.stopPropagation();
                    dpModel.popupOpenStatus = true;
                };

                var startVacationDateModel = {
                    date: null,
                    minDate: new Date(),
                    popupOpenStatus: false,
                    dateOptions: {
                        formatYear: 'yy',
                        startingDay: 1
                    },
                    togglePopUp: function ($event) {
                        openDatepickerPopup($event, this);
                    }
                };

                var endVacationDateModel = {
                    date: null,
                    minDate: new Date(),
                    popupOpenStatus: false,
                    dateOptions: {
                        formatYear: 'yy',
                        startingDay: 1
                    },
                    togglePopUp: function ($event) {
                        openDatepickerPopup($event, this);
                    }
                };

                $scope.description = '';
                $scope.startVacationDateModel = startVacationDateModel;
                $scope.endVacationDateModel = endVacationDateModel;

                $scope.vacationTypeSelectOptions = [
                    {
                        vacationType: 0,
                        label: 'Select...'
                    },
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
                    }
                ];
                $scope.vacationTypeSelection = $scope.vacationTypeSelectOptions[0];

                $scope.requestVacation = function () {
                    var requestVacationData = {
                        vacationType: $scope.vacationTypeSelection.vacationType,
                        startDate: $scope.startVacationDateModel.date,
                        endDate: $scope.endVacationDateModel.date,
                        description: $scope.description
                    };

                    requestVacationService
                        .requestAsync(requestVacationData)
                        .then(
                        // success callback
                        function () {
                            console.log('Cool.');
                        },
                        // error callback
                        function () {
                            console.log('Bad.')
                        });
                }

            }]); // end of controller
    }); // end of define
