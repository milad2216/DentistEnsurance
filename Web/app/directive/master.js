define(['angularAMD'], function (app) {
    debugger
    app.directive('master', ['$parse', '$state', 'dataService', '$compile', '$rootScope', 'menuService', function ($parse, $state, dataService, $compile, $rootScope, menuService) {
        return {
            restrict: 'E',
            transclude: true,
            scope: {
                buttons: "=?",
                userType:"=?"
            },
            templateUrl: '/app/template/main/master.html',
            controller: function ($scope) {
                debugger
               // $scope.userType = localStorage.getItem('userType')==="0";
                $scope.menus = [];
                debugger
                var userApp ="" ;
                $scope.userApp = $rootScope.userData.user;
                $scope.userCredit = $rootScope.userData.credit;
                switch ($scope.userApp.UserType) {
                    case 0:
                        $scope.menus = menuService.AdminMenu();
                        break;
                    case 1:
                        $scope.menus = menuService.ReferredMenu();
                        break;
                    case 2:
                        $scope.menus = menuService.FinancialMenu();
                        break;
                    case 3:
                        $scope.menus = menuService.SecretaryMenu();
                        break;
                }
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