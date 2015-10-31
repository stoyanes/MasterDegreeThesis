requirejs.config({
    baseUrl: 'js',
    paths: {
        'jquery': [
            '../bower_components/jquery/dist/jquery.min'
        ],
        'angular': [
            '../bower_components/angular/angular.min'
        ],
        'angular-resource': [
            '../bower_components/angular-resource/angular-resource.min'
        ],
        'angular-route': [
            '../bower_components/angular-route/angular-route.min'
        ],

        'ui-bootstrap-tpls': [
            '../bower_components/angular-bootstrap/ui-bootstrap-tpls.min'
        ],

        'angular-ui-router': [
            '../bower_components/angular-ui-router/release/angular-ui-router.min'
        ],

        'moment': [
            '../bower_components/moment/min/moment.min'
        ],

        'angular-ui-calendar': [
            '../bower_components/angular-ui-calendar/src/calendar'
        ],

        'fullcalendar': [
            '../bower_components/fullcalendar/dist/fullcalendar.min'
        ],

        'gcal': [
            '../bower_components/fullcalendar/dist/gcal'
        ],

        'angular-loading-bar': [
            '../bower_components/angular-loading-bar/build/loading-bar.min'
        ],

        'app': [
            '../app/js/app'
        ]
    },
    shim: {
        "jquery": {
            exports: "jquery"
        },

        'angular': {
            deps: ['jquery'],
            exports: 'angular'
        },

        "angular-resource": {
            deps: ["angular"]
        },

        "angular-route": {
            deps: ["angular"]
        },

        'ui-bootstrap-tpls': {
            deps: ['angular']
        },

        'angular-ui-router': {
            deps: ['angular']
        },

        'angular-ui-calendar': {
            deps: ['angular', 'moment', 'fullcalendar', 'gcal']
        },
        'gcal': {
            deps: ['fullcalendar']
        },
        'angular-loading-bar': {
            deps: ['angular']
        }
    }
});

require(
    [
        'angular',
        'app',
        'ui-bootstrap-tpls',
        '../app/js/modulesLoader'
    ],
    function (ng) {
        'use strict';
        ng.bootstrap(document, ['app']);
    }
); // end of require