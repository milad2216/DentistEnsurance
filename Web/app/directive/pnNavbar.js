debugger
define(['angularAMD'], function (app) {
    debugger
    app.directive('pnNavbar', ['$parse', function ($parse) {
        return {
            restrict: 'E',
            scope: {
                buttons: "=?"
            },
            templateUrl: '/app/template/directive/pnNavbar.html',
            controller: function ($scope) {
                debugger
            },
            link: function (scope, $elem, $attrs) {
                debugger
            }
        };
    }]);
});