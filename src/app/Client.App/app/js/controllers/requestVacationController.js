define([
        'app'
],
    function (app) {
        'use strict';
        app.controller('RequestVacationController', [
            '$scope', '$state',
            function ($scope, $state) {

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

                $scope.startVacationDateModel = startVacationDateModel;
                $scope.endVacationDateModel = endVacationDateModel;

                $scope.vacationTypeSelectOptions = [
                    {
                        id: 0,
                        label: 'Select...'
                    },
                    {
                        id: 1,
                        label: 'Paid'
                    },
                    {
                        id: 2,
                        label: 'Unpaid'
                    },
                    {
                        id: 3,
                        label: 'Sickness'
                    }
                ];
                $scope.vacationTypeSelection = $scope.vacationTypeSelectOptions[0];


            }]); // end of controller
    }); // end of define
