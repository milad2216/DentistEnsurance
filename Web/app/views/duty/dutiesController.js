debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('dutiesController', ['$scope', '$rootScope', '$state', '$http', 'dataService', 'Notification',
        function ($scope, $rootScope, $state, $http, dataService, Notification) {
            $scope.title = "سرویس‌ها"
            debugger
            $scope.userApp = $rootScope.userData.user;
            $scope.userCredit = $rootScope.userData.credit;
            $scope.services = [];
            dataService.getData('/api/Duty/GetAllService', {}).then(function (response) {
                debugger;
                $scope.duties = response.Data;
            });
            $scope.select_duty = function (duty) {
                if (duty.Cost <= $scope.userCredit) {
                    dataService.addEntity('/api/Reserve/Create', { PersonalId: $scope.userApp.PersonalId, DutyId: duty.ID, UserId: $scope.userApp.ID, Status: 0 }).then(function (data) {
                        debugger

                        Notification.success(data.message);
                    })
                } else {

                }
            }
        }]);
});


