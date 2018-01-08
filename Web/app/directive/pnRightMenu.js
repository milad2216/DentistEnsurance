debugger
define(['angularAMD'], function (app) {
    debugger
    app.directive('pnRightMenu', ['$parse', '$state', 'dataService', function ($parse, $state, dataService) {
        return {
            restrict: 'E',
            scope: {
                buttons:"=?"
            },
            templateUrl: '/app/template/directive/pnRightMenu.html',
            controller: function ($scope) {
                debugger
            },
            link: function (scope, $elem, $attrs) {
                scope.menus = [];
                dataService.getData("api/Menu/GetMenu", {}).then(function (res) {
                    debugger
                    scope.menus = res.menus;
                    scope.shortcutMenus = res.shortcutMenus;
                });

                scope.getPage = function (action) {
                    $state.go(action);
                }
            }
        };
    }]);
});