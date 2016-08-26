function employeeController($scope, $mdDialog) {
    $scope.EmployeeBag = {
        Login : {
            UserName: "",
            Password: ""
        }
    }

    $scope.phone = {
        Number: ""
    }

    $scope.newEmployee = function () {
        $mdDialog.show({
            scope: $scope,
            preserveScope: true,
            controller: function ($scope, $mdDialog) {
                $scope.addBolo = function () {
                    //$boloService.add($scope.Bolo)
                    $scope.EmployeeBag = {}
                }

                $scope.closeDialog = function () {
                    $scope.EmployeeBag = {}
                    $mdDialog.hide();
                };
            },
            templateUrl: '/Employee/Action/'
        });
    }

    $scope.isPhoneNumberValid = function () {
        return !$scope.phone.Number.$valid
    }
}
