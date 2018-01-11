define(['angularAMD'], function (app) {
    app.service('dataService', ['$state', '$http', '$q', '$rootScope', 'blockUI', function ($state, $http, $q, $rootScope, blockUI) {
       
        return {
        
            getData: function (url, filterInfo) {
               
                var then = this;
                var deferred = $q.defer();
                $http({ Method: 'GET', url: url, params: filterInfo }).success(function (response) {
                    deferred.resolve(response);
                });
                return deferred.promise;
            },
           
            updateEntity: function (url, entity, isPopup) {
                blockUI.start();
                var deferred = $q.defer();
                var then = this;
                $http.put(url, entity).success(function (response) {
                    deferred.resolve(response);
                    blockUI.stop();
                });
                return deferred.promise;
            },
            addEntity: function (url, entity) {
                blockUI.start();
                var deferred = $q.defer();
                var then = this;
                $http.post(url, entity).success(function (response) {
                    deferred.resolve(response);
                });
                return deferred.promise;
            },
            postData: function (url, data) {
                blockUI.start();
                var deferred = $q.defer();
                var then = this;
                $http.post(url, data).success(function (response) {
                    deferred.resolve(response);
                    blockUI.stop();
                });
                return deferred.promise;
            },
            deleteEntity: function (url, id) {
                blockUI.start();
                var deferred = $q.defer();
                var then = this;
                $http.delete(url + id).success(function (response) {
                    deferred.resolve(response);
                });
                return deferred.promise;
            },
        }
    }])
});

