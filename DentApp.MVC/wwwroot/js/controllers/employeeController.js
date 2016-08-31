function employeeController($rootScope, $scope, $mdDialog, $http, $mdToast) {
    $scope.EmployeeBag = {}
    $scope.showHints = true;    

    $scope.newEmployee = function () {
        $mdDialog.show({
            scope: $scope,
            preserveScope: true,
            controller: function ($scope, $mdDialog) {
                
            },
            templateUrl: '/Employee/Action/'
        });
    }

    $scope.Phone = {
        Number: undefined,
        isNumberValid: function () {        
            var phone = $scope.employeeForm.phoneNumber;        
            return ((!phone.$valid) || (phone.$isEmpty(phone.$viewValue)));
        },
        list: $scope.EmployeeBag.Phones = $scope.EmployeeBag.Phones || [],
        add: function () {
            var phone = {
                Number: this.Number,
                isDefault: (this.list.length == 0)
            }
            this.list.push(phone)
            this.Number = undefined;
        },
        remove: function (idx) {
            this.list.splice(idx, 1);
        }
    }

    $scope.Address = {
        Info: {},
        list: $scope.EmployeeBag.Addresses = $scope.EmployeeBag.Addresses || [],
        add: function () {
            console.clear();
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
        var configMethod = ($scope.EmployeeBag._id) ? 'PUT' : 'POST';
        console.clear()
        console.log($scope.EmployeeBag)
        $http.post($scope.getAPIURL() + '/api/Employee', $scope.EmployeeBag).then(successCallback, errorCallback);
    }

    function successCallback(response) {
        $scope.EmployeeBag = response.data;
        //toast("Foi");
    }

    function errorCallback(response) {
        alert(0)
        //toast(response)
    }

    function toast(message) {
        $mdToast.show($mdToast.simple().textContent(message));
    }
}
