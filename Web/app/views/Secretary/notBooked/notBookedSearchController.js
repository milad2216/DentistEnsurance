debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('notBookedSearchController', ['$scope', '$rootScope', '$state', '$http', '$stateParams', 'dataService', 'Notification',
        function ($scope, $rootScope, $state, $http, $stateParams, dataService, Notification) {
            $scope.title = "در انتظار نوبت"
            debugger
            $scope.status = $stateParams.status;
            var items = [{ text: "رزرو شده", value: 0 }, { text: "درخواست شده", value: 1 }, { text: "تایید نشده", value: 2 }, { text: "انجام شده", value: 3 }, { text: "لغو شده", value: 4 }];
            $scope.doBooked = function (e) {
                var myItem = $scope.kendoGrid.dataItem($(e.target).closest("tr"));
                
                $state.go("doBook", { reserve: myItem });
            }
            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: {//You can get the current page, pageSize etc off `e`.
                        type: "GET",
                        url: "/api/Reserve/GetNotBooked",
                        dataType: "json",

                    }
                },
                schema: {
                    parse: function (response) {
                        debugger;
                        return response.data;
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
                            Reported: { type: "boolean", editable: false },
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
                }, {
                    command:
                        {
                            text: "نوبت دهی", click: $scope.doBooked
                        }
                    , title: " "
                    , width: "100px"
                }
                ]
            };
        }]);
});


