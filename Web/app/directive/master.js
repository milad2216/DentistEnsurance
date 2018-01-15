define(['angularAMD'], function (app) {
    debugger
    app.directive('master', ['$parse', '$state', 'dataService', '$compile', '$rootScope', function ($parse, $state, dataService, $compile, $rootScope) {
        return {
            restrict: 'E',
            transclude: true,
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

                $scope.logoff = function(){

                    dataService.getData('/api/Security/LogOff', {}).then(function (response) {

                            $rootScope.statusforlayout = false;
                            $rootScope.statusforlogin = true;
                            $state.go("login");

                    });
                }

                $scope.profile = function () {
                    $state.go("profile");
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