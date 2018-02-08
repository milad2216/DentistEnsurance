debugger
define(['app'], function (app) {
    debugger
    app.register.controller('loginController', ['$scope', '$rootScope', '$state', 'dataService', 'blockUI',
        function ($scope, $rootScope, $state, dataService, blockUI) {
            debugger
            $scope.checkAuthenticate = function () {
                blockUI.start();
                dataService.getData('/api/Security/Login', { username: $scope.username, password: $scope.password }).then(function (response) {
                    if (response.Authenticated) {
                        $rootScope.statusforlayout = true;
                        $rootScope.statusforlogin = false;
                        $state.go("home");
                    } else {
                        $rootScope.statusforlayout = false;
                        $rootScope.statusforlogin = true;
                        $state.go("login");
                    }
                    blockUI.stop();
                });
            }
        }]);
});


