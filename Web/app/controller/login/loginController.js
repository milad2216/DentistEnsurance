debugger
define(['app'], function (app) {
    debugger
    app.register.controller('loginController', ['$scope', '$rootScope', '$state', 'dataService',
        function ($scope, $rootScope, $state, dataService) {
            debugger
            $scope.checkAuthenticate = function () {
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
                });
            }
        }]);
});


