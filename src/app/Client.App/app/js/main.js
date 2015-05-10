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
            deps:['angular']
        },

        'angular-ui-router': {
            deps:['angular']
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