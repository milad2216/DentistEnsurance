define(['angularAMD'], function (app) {
    debugger
    app.directive('master', ['$parse', '$state', 'dataService', '$compile', function ($parse, $state, dataService, $compile) {
        return {
            restrict: 'E',
            scope: {
                buttons: "=?"
            },
            templateUrl: '/app/template/main/master.html',
            controller: function ($scope) {
                debugger
                $scope.menus = [];
                //dataService.getData("api/Menu/GetMenu", {}).then(function (res) {
                //});
                debugger
                var userApp ="" ;

                $scope.userApp = {
                    FullName: "میلاد ولیمحمدی",
                    PositionName: "مدیر ارشد سیستم"
                };

                $scope.getPage = function (action) {
                    $state.go(action);
                }
            },
            compile: function (tElem, tAttrs) {
                debugger
               
                return {
                    pre: function (scope, iElem, iAttrs) {
                       
                    },
                    post: function (scope, iElem, iAttrs) {
                        $('[data-toggle="popover"]').popover({ animation: true, html: true, trigger: 'manual' }).click(function (e) {
                            debugger
                            $(this).popover('toggle');
                            e.stopPropagation();
                        });
                        $('html').click(function (e) {
                            $('[data-toggle="popover"]').popover('hide');
                        });
                       
                    }
                }
            }
        };
    }]);
});