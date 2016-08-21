define([
    'angular',

    './configs/constants',
    './configs/onStartup',
    './configs/routings',
    './configs/i18n',

    './controllers/loginController',
    './controllers/systemController',
    './controllers/applicationController',
    './controllers/requestVacationController',
    './controllers/userRequestsController',
    './controllers/requestApprovingController',
    './controllers/holidaysController',
    './controllers/userManagementController',
    './controllers/manageVacationRequestsController',

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
