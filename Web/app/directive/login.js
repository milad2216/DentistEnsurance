define(['angularAMD'], function (app) {
    debugger
    app.directive('login', ['$parse', '$state', 'dataService', function ($parse, $state, dataService) {
        return {
            restrict: 'E',
            scope: {
                buttons: "=?"
            },
            templateUrl: '/app/views/main/login.html',
            controller: function ($scope) {
                debugger
            },
            link: function (scope, $elem, $attrs) {
                
                scope.getPage = function (action) {
                    $state.go(action);
                }

                scope.isAuthenticated = function () {
                    return true;
                }
            }
        };
    }]);
});