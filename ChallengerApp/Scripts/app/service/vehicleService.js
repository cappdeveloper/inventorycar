//Services
app.factory('vehicleFactory', ['$http', function ($http) {

    return {
      
        saveUpdateVehicle: function (data) {
            return $http.post("/Vehicle/CreateEdit", data);
        },
       
    }

}]);
