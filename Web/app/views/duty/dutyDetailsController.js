debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('dutyDetailsController', ['$scope', '$rootScope', '$state', '$stateParams',
        function ($scope, $rootScope, $state, $stateParams) {
            $scope.title = "پروفایل شخصی"
            debugger
            $scope.duty = $stateParams.duty;

        }]);
});


