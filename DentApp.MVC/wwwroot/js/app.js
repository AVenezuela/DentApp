(function (angular, undefined) {
    "use strict";
    var _dentApp = angular
        .module('DentApp', ['ngMaterial', 'ui.router', 'angular.filter', 'ngMessages'])
        .config(function ($stateProvider, $urlRouterProvider
                          , $mdThemingProvider, $httpProvider) {
            DefineTheme($mdThemingProvider);

            //$urlRouterProvider.otherwise('');
            $stateProvider
             .state('EmployeeCreate', {
                    url: "/EmployeeCreate",
                    templateUrl: '/Employee/Action/',
                    controller: employeeController
                })
             .state('Employee', {
                url: "/Employee",
                templateUrl: '/Employee/Index/',
                controller: employeeController
             });
        })
        .controller('homeCtrl', homeController);

    _dentApp.run(function ($rootScope, $mdDialog
                          , $mdToast) {
        $rootScope.closeDialog = function () {
            $mdDialog.hide();
        };

        $rootScope.getAPIURL = function(){
            return "http://localhost:1111";
        }

        $rootScope.toastMessage = function(message) {
            $mdToast.show($mdToast.simple().textContent(message));
        }
    });

    //.directive('dhxTemplate', templateDirective)

    //setDirectives(app);

    function DefineTheme($mdThemingProvider) {
        $mdThemingProvider.theme('default')
            .primaryPalette('indigo');
    }

})(angular);