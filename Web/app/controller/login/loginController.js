debugger
define(['app'], function (app) {
    debugger
    app.register.controller('loginController', ['$scope', '$rootScope', '$state',
        function ($scope, $rootScope, $state) {
            debugger
            $scope.checkAuthenticate = function () {
                //
                debugger
                $rootScope.statusforlayout = true;
                $rootScope.statusforlogin = false;
                $state.go("home");
            }
        }]);
});


