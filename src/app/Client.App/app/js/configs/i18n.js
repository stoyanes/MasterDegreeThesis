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
                MANAGE_EMPLOYEES_PANEL: 'Manage employees'
            });
            $translateProvider.preferredLanguage('en');
            $translateProvider.useSanitizeValueStrategy('sanitize');
        }]);
    });