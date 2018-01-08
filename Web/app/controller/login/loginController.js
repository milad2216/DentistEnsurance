debugger
define(['app'], function (app) {
    debugger
    app.register.controller('loginController', ['$scope', '$rootScope', '$state',
        function ($scope, $rootScope, $state) {
            debugger
            $scope.checkAuthenticate = function () {
                $scope.statusforlayout = true;
                $scope.statusforlogin = false;
            }
        }]);
});


