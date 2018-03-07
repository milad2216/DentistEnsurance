define(['angularAMD'], function (app) {
    app.service('menuService', ['$state', '$http', '$q', function ($state, $http, $q) {
        
        return {

            ReferredMenu: function () {

                var menu = [{}];
            },

            FinancialMenu: function (url, entity, isPopup) {
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
            SecretaryMenu: function (url, entity) {
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
            }
        }
    }])
});

