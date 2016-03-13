define([
        'app'
],
    function (app) {
        'use strict';
        app.controller('RequestVacationController', [
            '$rootScope','$scope', '$state', 'RequestVacationService',
            function ($rootScope, $scope, $state, requestVacationService) {

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
                    },
                    {
                        vacationType: 4,
                        label: 'Other'
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
                            $state.transitionTo('system', null, { reload: true });
                        },
                        // error callback
                        function () {
                            $state.go('error');
                        });
                };

                $scope.isVacationRequestValid = function () {
                    var isValid = true;
                    if (!$rootScope.isDate($scope.startVacationDateModel.date)) {
                        isValid = false;
                    }
                    if (!$rootScope.isDate($scope.endVacationDateModel.date)) {
                        isValid = false;
                    }
                    if ($scope.vacationTypeSelection.vacationType === $scope.vacationTypeSelectOptions[0].vacationType) {
                        isValid = false;
                    }
                    if($scope.vacationTypeSelection.vacationType === $scope.vacationTypeSelectOptions[4].vacationType &&
                        $scope.description === ''){
                        isValid = false;
                    }
                    return isValid;
                };

                $scope.$watch('startVacationDateModel', function () {
                    $scope.endVacationDateModel.minDate = $scope.startVacationDateModel.date;
                }, true);

            }]); // end of controller
    }); // end of define
