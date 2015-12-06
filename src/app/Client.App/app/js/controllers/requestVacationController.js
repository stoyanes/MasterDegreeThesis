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
                }

                var startVacationDateModel = {
                    date: new Date(),
                    minDate: new Date(),
                    popupOpenStatus: false,
                    dateOptions: {
                        formatYear: 'yy',
                        startingDay: 1
                    },
                    togglePopUp: function ($event) {
                        openDatepickerPopup($event, this);
                    }
                }

                var endVacationDateModel = {
                    date: new Date(),
                    minDate: new Date(),
                    popupOpenStatus: false,
                    dateOptions: {
                        formatYear: 'yy',
                        startingDay: 1
                    },
                    togglePopUp: function ($event) {
                        openDatepickerPopup($event, this);
                    }
                }

                $scope.startVacationDateModel = startVacationDateModel;
                $scope.endVacationDateModel = endVacationDateModel;
            }]); // end of controller
    }); // end of define
