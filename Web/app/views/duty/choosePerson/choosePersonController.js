debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('choosePersonController', ['$scope', '$rootScope', '$state', '$http', '$stateParams', 'dataService', 'Notification',
        function ($scope, $rootScope, $state, $http, $stateParams, dataService, Notification) {

            $scope.duty = $stateParams.duty;
            $scope.title = "انتخاب بیمار"
            $scope.userApp = $rootScope.userData.user;
            debugger

            $scope.personalOptions = {
                autoBind: false,
                text: "FullName",
                value: "ID",
                transport: {
                    read: {
                        url: "/api/Personal/GetUserPersonals",
                        type: "GET"
                    }
                }
            };

            $scope.saveEntity = function () {
                if ($scope.choosePersonForm.$valid) {
                    dataService.addEntity('/api/Reserve/Create', { PersonalId: $scope.personalId, DutyId: $scope.duty.ID, UserId: $scope.userApp.ID, Status: 0 }).then(function (data) {
                        debugger

                        Notification.success(data.message);
                    })
                }
            }
        }]);
});


