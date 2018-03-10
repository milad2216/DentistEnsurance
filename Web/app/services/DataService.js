define(['angularAMD'], function (app) {
    app.service('dataService', ['$state', '$http', '$q', '$rootScope', 'blockUI', 'Notification', function ($state, $http, $q, $rootScope, blockUI, Notification) {
        var DispatchErrReponse = function (er) {
            if (er.status === 400 || er.status === 500) {
                if (er.data.ErrorMessage) {
                    Notification.error(er.data.ErrorMessage)
                }
                angular.forEach(er.data.ModelState, function (value, key) {
                    Notification.error(value[0]);
                });
            } else
                if (er.status === 401) {
                    $state.go("main");
                }
            return er;
        }
        var DispatchReponse = function (response) {
            if (response.status === 0) {
                response["data"].message = response.message;
                return response["data"];
            } else
                if (response.status === 1) {
                    Notification.error(response.message);
                    return { status: response.status };
                }
            return response;
        }
        return {

            getData: function (url, filterInfo) {

                var then = this;
                var deferred = $q.defer();
                $http({ Method: 'GET', url: url, params: filterInfo }).then(function (response) {
                    deferred.resolve(DispatchReponse(response.data));
                    blockUI.stop();
                }, function (er) {
                    deferred.reject(DispatchErrReponse(er));
                    blockUI.stop();
                });
                return deferred.promise;
            },

            updateEntity: function (url, entity, isPopup) {
                blockUI.start();
                var deferred = $q.defer();
                var then = this;
                $http.put(url, entity).then(function (response) {
                    deferred.resolve(DispatchReponse(response.data));
                    blockUI.stop();
                }, function (er) {
                    deferred.reject(DispatchErrReponse(er));
                    blockUI.stop();
                });
                return deferred.promise;
            },
            addEntity: function (url, entity) {
                blockUI.start();
                var deferred = $q.defer();
                var then = this;
                $http.post(url, entity).then(function (response) {
                    deferred.resolve(DispatchReponse(response.data));
                    blockUI.stop();
                }, function (er) {
                    deferred.reject(DispatchErrReponse(er));
                    blockUI.stop();
                });
                return deferred.promise;
            },
            postData: function (url, data) {
                blockUI.start();
                var deferred = $q.defer();
                var then = this;
                debugger;
                $http.post(url, data, {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }).then(function (response) {
                    deferred.resolve(DispatchReponse(response.data));
                    blockUI.stop();
                }, function (er) {
                    deferred.reject(DispatchErrReponse(er));
                    blockUI.stop();
                });
                return deferred.promise;
            },
            deleteEntity: function (url, id) {
                blockUI.start();
                var deferred = $q.defer();
                var then = this;
                $http.delete(url + id).then(function (response) {
                    deferred.resolve(DispatchReponse(response.data));
                    blockUI.stop();
                }, function (er) {
                    deferred.reject(DispatchErrReponse(er));
                    blockUI.stop();
                });
                return deferred.promise;
            },
        }
    }])
});

