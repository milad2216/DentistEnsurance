define(['angularAMD'], function (angularAMD) {
    var app = angular.module("app", [
        'ngSanitize',
        'ui.router',
        'ui.bootstrap',
        'kendo.directives',
        'blockUI',
        'ui-notification',
        'ngAnimate'
    ]);


    app.config(["NotificationProvider", function (notificationProvider) {
        notificationProvider.options.positionX = "right";
        notificationProvider.options.positionY = "top";
        //    = {
        //    delay: 5e3,
        //    startTop: 10,
        //    startRight: 10,
        //    verticalSpacing: 10,
        //    horizontalSpacing: 10,
        //    positionX: "right",
        //    positionY: "top",
        //    replaceMessage: !1,
        //    templateUrl: "angular-ui-notification.html"
        //}
        notificationProvider.setOptions(notificationProvider.options);
    }]);

    app.config(function (blockUIConfigProvider) {
        blockUIConfigProvider.message("dsfsddfsdfdsfdsfds");
        blockUIConfigProvider.delay(1);
        blockUIConfigProvider.autoBlock(false);
    });
    app.config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('duties'),
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
        .state('duties', angularAMD.route({
            url: '/duties',
            title: 'سرویس‌ها',
            controller: 'dutiesController',
            templateUrl: '/app/views/duty/duties.html',
            controllerUrl: '/app/views/duty/dutiesController.js'
        }))
        .state('notBookedSearch', angularAMD.route({
            url: '/notBookedSearch',
            title: 'رزرو نشده ها',
            controller: 'notBookedSearchController',
            templateUrl: '/app/views/Secretary/notBooked/notBookedSearch.html',
            controllerUrl: '/app/views/Secretary/notBooked/notBookedSearchController.js'
        }))
        .state('doBook', angularAMD.route({
            url: '/doBook',
            title: 'سرویس‌ها',
            controller: 'doBookController',
            templateUrl: '/app/views/Secretary/notBooked/doBook.html',
            controllerUrl: '/app/views/Secretary/notBooked/doBookController.js',
            params: {
                reserve: {}
            }
        }))
        .state('dutyDetails', angularAMD.route({
            url: '/dutyDetails',
            title: 'سرویس‌ها',
            controller: 'dutyDetailsController',
            templateUrl: '/app/views/duty/dutyDetails.html',
            controllerUrl: '/app/views/duty/dutyDetailsController.js',
            params: {
                duty: {}
            }
        }))
        .state('reserveSearch', angularAMD.route({
            url: '/reserveSearch?status',
            title: 'رزرو‌شده‌ها',
            controller: 'reserveSearchController',
            templateUrl: '/app/views/duty/reserve/reserveSearch.html',
            controllerUrl: '/app/views/duty/reserve/reserveSearchController.js',
            params: {
                status: null
            }
        }))
        .state('choosePerson', angularAMD.route({
            url: '/choosePerson',
            title: 'سرویس‌ها',
            controller: 'choosePersonController',
            templateUrl: '/app/views/duty/choosePerson/choosePerson.html',
            controllerUrl: '/app/views/duty/choosePerson/choosePersonController.js',
            params: {
                duty: {}
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

    app.run(["$browser", "$rootScope", "$state", "$stateParams", "$http", "dataService", function ($browser, $rootScope, $state, $stateParams, $http, dataService) {

        var firstLoad = true;
        $rootScope.$on("$stateChangeStart", function (event, toState, toParams, fromState, fromParams) {
            if (firstLoad) {
                firstLoad = false;
                event.preventDefault();

                dataService.postData('/api/Security/IsAuthenticated', {}).then(function (response) {
                    if (response.Authenticated) {
                        $rootScope.statusforlayout = true;
                        $rootScope.statusforlogin = false;
                        $rootScope.userData = { credit: response.UserCredit, user: response.User };
                        $rootScope.userType = response.User.UserType;
                        $state.go("duties");
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