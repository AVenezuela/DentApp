(function (angular, undefined) {
    "use strict";

    var app = angular
        .module('DentApp', ['ngMaterial', 'ui.router', 'angular.filter', 'ngMessages'])
        .config(function ($stateProvider, $urlRouterProvider, $mdThemingProvider, $locationProvider) {
            DefineTheme($mdThemingProvider);

            //$urlRouterProvider.otherwise('');
            $stateProvider
                .state('UserCreate', {
                    url: "/?UserCreate",
                    templateUrl: '/User/Create/',
                    controller: userCreateController
                });
        })
        .controller('homeCtrl', homeController)
    //.directive('dhxTemplate', templateDirective)

    //setDirectives(app);

    function DefineTheme($mdThemingProvider) {
        $mdThemingProvider.definePalette('amazingPaletteName', {
            '50': 'febeb5',
            '100': 'f2aba1',
            '200': 'ee9f94',
            '300': 'e79287',
            '400': 'e79287',
            '500': 'e05b49',
            '600': 'e05b49',
            '700': 'e05b49',
            '800': 'e05b49',
            '900': 'e05b49',
            'A100': 'e05b49',
            'A200': 'e05b49',
            'A400': 'e05b49',
            'A700': 'e05b49',
            'contrastDefaultColor': 'light',
            'input': 'B71C1C',
            'docs-dark': '592a0a',
            'contrastDarkColors': ['50', '100', '200', '300', '400', 'A100'],
            'contrastLightColors': undefined
        });
        $mdThemingProvider.theme('default')
            .primaryPalette('amazingPaletteName')
    }

})(angular);