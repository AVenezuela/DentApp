(function (angular, undefined) {
    "use strict";
    var _dentApp = angular
        .module('DentApp', ['ngMaterial', 'ui.router', 'angular.filter', 'ngMessages'])
        .config(function ($stateProvider, $urlRouterProvider
            , $mdThemingProvider) {
            DefineTheme($mdThemingProvider);

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

    _dentApp.config(['$httpProvider', function ($httpProvider) {
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
        $httpProvider.defaults.headers.post['Accept'] = 'application/json, text/javascript';
        $httpProvider.defaults.headers.post['Content-Type'] = 'application/json; charset=utf-8';        
        $httpProvider.defaults.headers.common['Accept'] = 'application/json, text/javascript';
        $httpProvider.defaults.headers.common['Content-Type'] = 'application/json; charset=utf-8';        
        $httpProvider.defaults.useXDomain = true;
    }]);

    _dentApp.run(function ($rootScope, $mdDialog
        , $mdToast) {
        $rootScope.closeDialog = function () {
            $mdDialog.hide();
        };

        $rootScope.getAPIURL = function () {
            return "http://localhost:1111";
        }

        $rootScope.toastMessage = function (message) {
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