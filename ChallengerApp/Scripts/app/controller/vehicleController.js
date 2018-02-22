
var app = angular.module('app', []);

app.controller('vehicleController', ['$scope', '$filter', 'vehicleFactory', function ($scope, $filter, vehicleFactory) {

    $scope.AddUpdateVehicle = function () {
        $('#add_model').modal('show');
    }

    $scope.saveVehicle = function () {
        //if (!$("#VehicleForm").valid()) {
        //    return;
        //}
        debugger;
        $.blockUI({ message: '<img src="/Images/loader.gif" />' });
        $('#add_model').modal('hide');
        vehicleFactory.saveUpdateVehicle($scope.Vehicle).success(function (response) {
            debugger
            if (data.success) {
                alert(data);

                bootbox.confirm("Successfully Submitted", function (confirmed) {
                    if (confirmed) {
                        window.location.replace('/Account/Login');

                    }
                });
            }
            $.unblockUI();
        }).error(function () {
            alert(xhr.responseText);
            $(".loader").hide();
        });
    }




    var initial = function () {
        $scope.Vehicle = {};
    }

    initial();
}]);


