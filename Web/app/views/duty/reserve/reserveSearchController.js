debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('reserveSearchController', ['$scope', '$rootScope', '$state', '$http', '$stateParams', 'dataService', 'Notification',
        function ($scope, $rootScope, $state, $http, $stateParams, dataService, Notification) {
            $scope.title = "رزرو شده‌ها"
            debugger
            $scope.status = $stateParams.status;
            var items = [{ text: "رزرو شده", value: 0 }, { text: "درخواست شده", value: 1 }, { text: "تایید نشده", value: 2 }, { text: "انجام شده", value: 3 }, { text: "لغو شده", value: 4 }];
            $scope.cancelReserve = function (e) {
                var myItem = $scope.kendoGrid.dataItem($(e.target).closest("tr"));
                dataService.postData('/api/Reserve/Cancel', myItem).then(function (data) {
                    $scope.kendoGrid.dataSource.read();
                    Notification.success(data.message);
                })
                $scope.$apply();
            }
            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: {//You can get the current page, pageSize etc off `e`.
                        type: "GET",
                        url: "/api/Reserve/GetReserves?status=" + $scope.status,
                        dataType: "json",

                    }
                },
                schema: {
                    parse: function (response) {
                        debugger;
                        return response;
                    },
                    data: "data",
                    total: "total",
                    model: {
                        id: "ID",
                        fields: {
                            Id: { type: "number", editable: false, nullable: true },
                            PersonalId: { type: "number", defaultValue: null },
                            DutyId: { type: "number", defaultValue: null },
                            UserId: { type: "number", defaultValue: null },
                            Status: { type: "number", defaultValue: null },
                            RequestMessage: { type: "string", editable: false },
                            Personal: { defaultValue: {} },
                            PersonalFirstName: { from: "Personal.FirstName", type: "string", editable: false, nullable: true },
                            PersonalLastName: { from: "Personal.LastName", type: "string", editable: false, nullable: true },
                            Duty: { defaultValue: {} },
                            DutyName: { from: "Duty.Name", type: "string", editable: false, nullable: true },
                            DutyCost: { from: "Duty.Cost", type: "number", editable: false, nullable: true },
                        }
                    }
                },
                autoSync: false,
                serverPaging: true,
                pageSize: 10,
                serverSorting: true,
                serverFiltering: true,
            });
            $scope.mainGridOptions = {
                // autoBind:false,
                dataSource: dataSource,
                height: 550,
                resizable: true,
                scrollable: true,
                pageSize: 10,
                selectable: "row",
                sortable: {
                    mode: "single",
                    allowUnsort: true
                },
                pageable: {
                    buttonCount: 3,
                    previousNext: true,
                    numeric: true,
                    refresh: true,
                    info: true,
                    pageSizes: [10, 20, 50, 100]
                },
                dataBound: function (e) {
                    debugger
                    //this.expandRow(this.tbody.find("tr.k-master-row").first());
                },
                columns: [{
                    field: "PersonalFirstName",
                    title: "نام",
                    width: "200px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "PersonalLastName",
                    title: "نام خانوادگی",
                    width: "200px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "DutyName",
                    title: "نام سرویس",
                    width: "200px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "DutyCost",
                    title: "هزینه سرویس",
                    width: "200px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "Status",
                    title: "وضعیت",
                    width: '200px',
                    values: items
                }
                ]
            };
            if ($scope.status == 0 || $scope.status == 1) {
                $scope.mainGridOptions.columns.push({
                    command:
                        {
                            text: "لغو", click: $scope.cancelReserve
                        }
                    , title: " "
                    , width: "80px"
                });
            }
        }]);
});


