define([
    'angular',

    './configs/constants',
    './configs/onStartup',
    './configs/routings',

    './controllers/loginController',
    './controllers/systemController',
    './controllers/applicationController',
    './controllers/requestVacationController',
    './controllers/userRequestsController',
    './controllers/requestApprovingController',
    './controllers/holidaysController',
    './controllers/userManagementController',

    './services/authenticationService',
    './services/sessionService',
    './services/authInterceptor',
    './services/requestVacationService',
    './services/leaveDaysService',
    './services/employeeService',
    './services/holidayService',
    './services/usersMenagementService'
], function (ng) {

});
