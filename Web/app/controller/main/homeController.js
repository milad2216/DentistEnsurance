define(['app'], function (app) {
    debugger
    app.register.controller('homeController', ['$scope', '$rootScope', '$state',
        function ($scope, $rootScope, $state) {
            $scope.title="milad majid"
            debugger
            $scope.get = function () {
                $state.go("milad");
            }
        }]);
});


