var MyApp = angular.module("ABCApp", []);
MyApp.controller("TrimesterInfoController", function ($scope, $http) {

    $http.get("/TrimesterInfo/LoadData").then(function (d) {

        $scope.Trimester = d.data;
    }, function (error) {
        alert("Faild");
    });

    $scope.btnSaveTextBatch = "Save";
    $scope.SaveData = function () {

        if ($scope.btnSaveTextBatch == "Save") {
            $scope.btnSaveTextBatch = "Saving.....";
            $http({
                method: 'POST',
                url: '/TrimesterInfo/Save_Info',
                data: $scope.TrimesterDAO
            }).success(function (a) {
                $scope.btnSaveTextBatch = "Save";
                $scope.TrimesterDAO = null;
                alert(a);
            }).error(function () {
                alert("Faild");
            });
        }
    };
});