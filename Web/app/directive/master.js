define(['angularAMD'], function (app) {
    debugger
    app.directive('master', ['$parse', '$state', 'dataService', function ($parse, $state, dataService) {
        return {
            restrict: 'E',
            scope: {
                buttons: "=?"
            },
            templateUrl: '/app/template/main/master.html',
            controller: function ($scope) {
                debugger
            },
            link: function (scope, $elem, $attrs) {
                scope.menus = [];
                //dataService.getData("api/Menu/GetMenu", {}).then(function (res) {
                //});
                debugger
                var userApp = {
                    FullName : "میلاد ولیمحمدی",
                    PositionName : "مدیر ارشد سیستم"
                };

                scope.userApp = userApp;

                scope.getPage = function (action) {
                    $state.go(action);
                }
            }
        };
    }]);
});