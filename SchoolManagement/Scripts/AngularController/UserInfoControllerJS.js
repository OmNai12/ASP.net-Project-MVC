var MyApp = angular.module("ABCApp", []);

MyApp.controller("UserInfoController", function ($scope, $http) {

    $scope.btnSaveTextBatch = "Save";
    $scope.SaveData = function () {

        if ($scope.btnSaveTextBatch == "Save") {
            $scope.btnSaveTextBatch = "Saving.....";
            $http({
                method: 'POST',
                url: '/UserInfo/Save_Info',
                data: $scope.UserDAO
            }).success(function (a) {
                $scope.btnSaveTextBatch = "Save";
                $scope.UserDAO = null;
                alert(a);
            }).error(function () {
                alert("Faild");
            });
        }
    }


    $http.get("/UserInfo/LoadData").then(function (d) {

        $scope.UserInfo = d.data;
    }, function (error) {
        alert("Faild");
    });
});