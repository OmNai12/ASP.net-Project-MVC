var MyApp = angular.module("ABCApp", []);

MyApp.controller("StudentCourseOfferController", function ($scope, $http) {

    $http.get("/StudentCourseOffer/ddlLoadTrimesterInfo").then(function (d) {
        $scope.Trimester = d.data;
    }, function (error) {
        alert("Faild");
    });

    $http.get("/StudentCourseOffer/ddlLoadStudentIdName").then(function (d) {

        $scope.StudentIDNO = d.data;
    }, function (error) {
        alert("Faild");
    });

    $http.get("/StudentCourseOffer/ddlLoadCourseInfo").then(function (d) {

        $scope.CourseInfo = d.data;

    }, function (error) {
        alert("Faild");
    });
});