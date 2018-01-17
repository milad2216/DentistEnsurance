define(['angularAMD'], function (angularAMD) {
    var app = angular.module("app", [
        'ngSanitize',
        'ui.router',
        'ui.bootstrap',
        'kendo.directives',
        'blockUI'
    ]);

    app.config(function (blockUIConfigProvider) {
        blockUIConfigProvider.message("dsfsddfsdfdsfdsfds");
        blockUIConfigProvider.delay(1);
        blockUIConfigProvider.autoBlock(false);
    });
    app.config(function ($stateProvider, $urlRouterProvider) {
        app._stateProvider = $stateProvider;
        $urlRouterProvider.otherwise('login');
        $stateProvider
            
            .state('home', angularAMD.route(
                {
                    url: '/home',
                    title: 'تست',
                    controller: 'homeController',
                    templateUrl: '/app/views/main/home.html',
                    controllerUrl: '/app/controller/main/homeController.js',

                })).state('login', angularAMD.route(
                    {
                        title: 'تست',
                        url: '/login',
                        controller: 'loginController',
                        controllerUrl: '/app/controller/login/loginController.js',
                        views: {
                            'login': {
                                templateUrl: '/app/views/login/login.html',
                            },
                        }
                    }))
    });

    app.config(["$locationProvider", '$provide', function ($locationProvider, $provide) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
        $locationProvider.hashPrefix('!');
    }]);

    app.run(["$browser", "$rootScope", "$state", "$stateParams", function ($browser, $rootScope, $state, $stateParams) {

        $rootScope.$on("$stateChangeStart", function (event, toState, toParams, fromState, fromParams) {

        });
        $rootScope.$on("$stateChangeSuccess", function (event, toState) {

            $rootScope.applicationModule = toState.title;
        });
    }]);


    app.config(["$locationProvider", '$provide', function ($locationProvider, $provide) {


    }]);

    var indexController = function ($scope, $rootScope, $http, $state, $stateParams, $sce, blockUI) {
        debugger
        blockUI.start();
        $http.post('/api/Security/IsAuthenticated', {}).success(function (response) {
            if (response.Authenticated)
            {
                $rootScope.statusforlayout = true;
                $rootScope.statusforlogin = false;
            } else {
                $rootScope.statusforlayout = false;
                $rootScope.statusforlogin = true;
            }
            blockUI.stop();
        });
        if ($rootScope.statusforlayout)
            $state.go("home");
        else if ($rootScope.statusforlogin)
            $state.go("login");
        $scope.initializeController = function () {

        }
    };

    indexController.$inject = ['$scope', '$rootScope', '$http', '$state', '$stateParams', '$sce', 'blockUI'];

    app.controller("indexController", indexController);

    app.bootstrap = function () {
        angularAMD.bootstrap(app, false);
    };
    return app;
});