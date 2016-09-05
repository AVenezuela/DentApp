function employeeController($rootScope, $scope, $mdDialog, $http, $mdToast) {
    $scope.EmployeeBag = {}    
    $scope.showHints = true;    

    $scope.newEmployee = function () {
        $mdDialog.show({
            scope: $scope,
            preserveScope: true,
            controller: function ($scope, $mdDialog) {},
            templateUrl: '/Employee/Action/'
        });
    }

    $scope.Phone = {
        number: undefined,
        isNumberValid: function () {
            if($scope.employeeForm)
            {                    
                var phone = $scope.employeeForm.phoneNumber;        
                return ((!phone.$valid) || (phone.$isEmpty(phone.$viewValue)));
            }
        },
        list: $scope.EmployeeBag.phones = $scope.EmployeeBag.phones || [],
        add: function () {
            var phone = {
                number: this.number,
                isdefault: (this.list.length == 0)
            }
            this.list.push(phone)
            this.number = undefined;
        },
        remove: function (idx) {
            this.list.splice(idx, 1);
        }
    }

    $scope.Address = {
        Info: {},
        list: $scope.EmployeeBag.addresses = $scope.EmployeeBag.addresses || [],
        add: function () {
            console.clear();
            this.Info.isdefault = (this.list.length == 0);
            console.log('info', this.Info);
            this.list.push(this.Info)
            this.Info = {};
        },
        remove: function (idx) {
            this.list.splice(idx, 1);
        },
        isFormValid: function () {
            return $scope.addressForm.$invalid;
        }
    }

    $scope.Save = function () {        
        $http.defaults.useXDomain = true;
        var func = ($scope.EmployeeBag.id)? $http.put : $http.post;
         
        func($scope.getAPIURL() + '/api/Employee', $scope.EmployeeBag)
             .then(successCallback, errorCallback);
    }

    function successCallback(response) {
        $scope.EmployeeBag = response.data || {};
        $scope.toastMessage("Sucesso!");
    }

    function errorCallback(response) {      
        alert(1)  
        $scope.toastMessage(response);
    }
}
