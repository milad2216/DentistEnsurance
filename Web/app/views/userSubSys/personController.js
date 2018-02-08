debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('personController', ['$scope', '$rootScope', '$state', '$stateParams',
        function ($scope, $rootScope, $state, $stateParams) {
            $scope.title = "پروفایل شخصی"
            debugger
            $scope.user = $stateParams.profile;

        }]);
});


