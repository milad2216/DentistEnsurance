define(['app'], function (app) {
    debugger
    app.register.controller('profileController', ['$scope', '$rootScope', '$state', '$http', 'blockUI', 'dataService',
        function ($scope, $rootScope, $state, $http, blockUI, dataService) {
            $scope.title = "پروفایل شخصی"
            debugger
            blockUI.start();
            dataService.getData('/api/Personal/GetLoginUser', { }).then(function (response) {
                $scope.user = response;
                blockUI.stop();
            });

        }]);
});


