define(
    [
        'app'
    ],
    function(app) {
        app.config(['$translateProvider', function($translateProvider) {
            $translateProvider.translations('en', {
                APP_NAME: 'Time-Off Tracking',
                LOG_OUT: 'Log-out',
                USER_MENU_MESS: 'Menu',
                HOME_BTN: 'Home',
                REQUEST_VACATION_BTN: 'Request vacation',
                MY_REQUESTS_BTN: 'My requests',
                REQUEST_TO_APPROVE_BTN: 'Requests to approve',
                WELCOME_MESS: 'Hello',
                ADMIN_MENU_MESS: 'Admin menu',
                MANAGE_NON_WORKING_DAYS_PANEL: 'Manage holidays',
                MANAGE_EMPLOYEES_PANEL: 'Manage employees',
                ERROR_TITLE: 'Error',
                ERROR_MESS: 'Something went wrong. Try again later. We logged this error and will try to fix it, as soon as possible.',
                LOG_IN_MESS: 'Please, enter you credentials.',
                LOG_IN_USR_NAME_MESS: 'Name',
                LOG_IN_USR_PASS_MESS: 'Password',
                LOG_IN_BTN: 'Log in',
                REQUEST_FROM_MESS: 'Request from',
                REQUEST_START_DATE_MESS: 'Start Date',
                REQUEST_END_DATE_MESS: 'End Date',
                REQUEST_VAC_TYPE_MESS: 'Vacation Type',
                REQUEST_DESCRIPTION_MESS: 'Description',
                REQUEST_STATUS_MESS: 'Status',
                REQUEST_APPROVE_BTN: 'Approve',
                REQUEST_REJECT_BTN: 'Reject',
                NO_REQUESTS_MESS: 'There are no requests.',
                APPROVAL_MNR: 'Approval manager',
                VACATION_STATUS: 'Vacation status',
                TAKEN_PAID_DAYS: 'Taken paid days',
                ALLOWED_PAID_DAYS: 'Allowed paid days',
                BALANCE_PAID_DAYS: 'Balance paid days',
                TAKEN_NON_PAID_DAYS: 'Taken non-paid days',
                TAKEN_SICKNESS_DAYS: 'Taken sickness days',
                TRANSF_FROM_LAST_YEAR: 'Transferred from last year',
                COMPENSASION: 'Compensasion',
                PRINT_FROM_MESS: 'From',
                PRINT_TO_MESS: 'To',
                PRINT_REQUEST_MESS: 'I would like take vacation on these days',
                PRINT_HEAD_MESS: 'R E Q U E S T',
                FAQ: 'FAQ'
            });
            $translateProvider.preferredLanguage('en');
            $translateProvider.useSanitizeValueStrategy('sanitize');
        }]);
    });