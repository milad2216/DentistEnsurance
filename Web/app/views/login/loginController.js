define(['app'], function (app) {
    app.register.controller('loginController', ['$scope', '$rootScope', '$state', 'dataService', 'blockUI',
        function ($scope, $rootScope, $state, dataService, blockUI) {
            $scope.checkAuthenticate = function () {
                blockUI.start();
                dataService.getData('/api/Security/Login', { username: $scope.username, password: $scope.password }).then(function (response) {
                    if (response.Authenticated) {
                        $rootScope.statusforlayout = true;
                        $rootScope.statusforlogin = false;
                        $rootScope.userData = { credit: response.UserCredit, user: response.User };
                        $rootScope.userType = response.User.UserType;
                        $state.go("duties");
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


