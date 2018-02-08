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
        $urlRouterProvider.otherwise('home'),
        $stateProvider
            .state('profile', angularAMD.route(
                {
                    url: '/profile',
                    title: 'داشبورد',
                    controller: 'profileController',
                    templateUrl: '/app/views/userSubSys/profile.html',
                    controllerUrl: '/app/views/userSubSys/profileController.js',

                })).state('person', angularAMD.route({
                    url: '/person',
                    title: 'کارکنان',
                    controller: 'personController',
                    templateUrl: '/app/views/userSubSys/person.html',
                    controllerUrl: '/app/views/userSubSys/personController.js',
                    params: {
                        profile: {}
                    }
                }))
            .state('home', angularAMD.route(
                {
                    url: '/home',
                    title: 'داشبورد',
                    controller: 'homeController',
                    templateUrl: '/app/views/main/home.html',
                    controllerUrl: '/app/views/main/homeController.js',

                })).state('login', angularAMD.route(
                    {
                        title: 'ورود به سیستم',
                        url: '/login',
                        controller: 'loginController',
                        controllerUrl: '/app/views/login/loginController.js',
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

    app.run(["$browser", "$rootScope", "$state", "$stateParams", "$http", function ($browser, $rootScope, $state, $stateParams, $http) {

        var firstLoad = true;
        $rootScope.$on("$stateChangeStart", function (event, toState, toParams, fromState, fromParams) {
            if (firstLoad) {
                firstLoad = false;
                event.preventDefault();

                $http.post('/api/Security/IsAuthenticated', {}).success(function (response) {
                    if (response.Authenticated) {
                        $rootScope.statusforlayout = true;
                        $rootScope.statusforlogin = false;
                        localStorage.setItem('userType', response.UserType);
                        $state.go("home");
                    } else {
                        $rootScope.statusforlayout = false;
                        $rootScope.statusforlogin = true;
                        $state.go("login");
                    }
                });
            }
        });
        $rootScope.$on("$stateChangeSuccess", function (event, toState) {

            $rootScope.applicationModule = toState.title;
        });
    }]);


    app.config(["$locationProvider", '$provide', function ($locationProvider, $provide) {


    }]);

    var indexController = function ($scope, $rootScope, $http, $state, $stateParams, $sce, blockUI) {
        debugger
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