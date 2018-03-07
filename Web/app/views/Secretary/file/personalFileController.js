define(['app'], function (app) {
    app.register.controller('personalFileController', ['$scope', '$rootScope', '$state', '$http', '$stateParams', 'dataService', 'Notification',
        function ($scope, $rootScope, $state, $http, $stateParams, dataService, Notification) {
            $scope.title = "نوبت دهی";
            $scope.personal = $stateParams.personal;
            


            $scope.saveEntity = function () {
                if ($scope.doBookForm.$valid) {
                    dataService.postData('/api/Reserve/SaveTurn', { ID: $scope.reserveItem.ID, TurnDateTime: $scope.ReserveDateTime }).then(function (data) {
                        Notification.success(data.message);
                        $state.go("notBookedSearch");
                    })
                }
            }
        }]);
});


