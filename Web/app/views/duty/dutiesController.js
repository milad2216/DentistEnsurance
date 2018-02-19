debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('dutiesController', ['$scope', '$rootScope', '$state', '$http', 'dataService',
        function ($scope, $rootScope, $state, $http, dataService) {
            $scope.title = "سرویس‌ها"
            debugger
            $scope.services = [];
            dataService.getData('/api/Duty/GetAllService', {}).then(function (response) {
                debugger;
                $scope.duties = response.Data;
            });
            $scope.select_duty = function (duty) {

            }
        }]);
});


