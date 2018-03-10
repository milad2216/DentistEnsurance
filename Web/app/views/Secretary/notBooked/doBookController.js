define(['app'], function (app) {
    app.register.controller('doBookController', ['$scope', '$rootScope', '$state', '$http', '$stateParams', 'dataService', 'Notification',
        function ($scope, $rootScope, $state, $http, $stateParams, dataService, Notification) {
            $scope.title = "نوبت دهی";
            $scope.reserveItem = $stateParams.reserve;
            var items = [{ text: "رزرو شده", value: 0 }, { text: "درخواست شده", value: 1 }, { text: "تایید نشده", value: 2 }, { text: "انجام شده", value: 3 }, { text: "لغو شده", value: 4 }];
            $scope.model = {};
            $scope.kendoDateOptions = {
                change: function () {
                    debugger
                    var val = this.value();
                    if (val && val.gregoriandate)
                        $scope.model.ReserveDate = moment(val.gregoriandate).format('YYYY-MM-DD');
                    else
                        $scope.model.ReserveDate = val;
                }
            }



            $scope.saveEntity = function () {
                if ($scope.doBookForm.$valid) {
                    dataService.postData('/api/Reserve/SaveTurn', { ID: $scope.reserveItem.ID, TurnDate: $scope.model.ReserveDate, TurnTime: $scope.model.ReserveTime }).then(function (data) {
                        Notification.success(data.message);
                        $state.go("notBookedSearch");
                    })
                }
            }
        }]);
});


