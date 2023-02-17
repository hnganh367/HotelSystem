var app = angular.module("Homeapp", []);
app.controller("RoomController", function ($scope, $http) {
    $scope.btnText = "Save";
    $scope.saveData = function () {
        $scope.btnText = "please wait...";
        $http({
            method: 'POST',
            url: '/Home/Add_record',
            data: $scope.Room
        }).then(function successCallBack(response) {
            $scope.btnText = "Save";
            $scope.Room = null;
            alert(response.data);
        },function errorCallBack() {
            alert('failed');
        });
    };
    $http.get("/Home/Get_Data").then(function (d) {
        $scope.Room  = d.data;
    }, function (error) {
        alert('Failed');
    });
    $scope.loadrecord = function (id) {
        $http.get("/Home/Get_DataById?id=" + id).then(function (d) {
            $scope.Room = d.data[0];
        });

    };
    $scope.updateData = function () {
        $scope.btnText = "please wait...";
        $http({
            method: 'POST',
            url: '/Home/Update_RoomHotel',
            data: $scope.Room
        }).then(function successCallBack(response) {
            $scope.btnText = "Update";
            $scope.Room = null;
            alert(response.data);
        }).error(function () {
            alert('failed');
        });
    };
    $scope.deleterecord = function (id) {
        $http.get("/Home/Delete_RoomHotel?id=" + id).then(function (d) {
            alert(d.data);
        }, function (error) {
            alert('Failed');
        });

    };


});