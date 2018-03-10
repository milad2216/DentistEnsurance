debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('personalSearchController', ['$scope', '$rootScope', '$state', '$http', '$stateParams', 'dataService', 'Notification',
        function ($scope, $rootScope, $state, $http, $stateParams, dataService, Notification) {
            $scope.title = "لیست بیماران"
            debugger
            $scope.status = $stateParams.status;
            $scope.showFile = function (e) {
                var myItem = $scope.kendoGrid.dataItem($(e.target).closest("tr"));
                $state.go("personalFile", { personal: myItem });
            }
            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: {//You can get the current page, pageSize etc off `e`.
                        type: "GET",
                        url: "/api/Personal/GetAll",
                        dataType: "json"
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
                            ParentId: { type: "number", defaultValue: null },
                            LastName: { type: "string", defaultValue: null },
                            Relation: { type: "string", defaultValue: null },
                            NationalNo: { type: "string", defaultValue: null },
                            PersonalNo: { type: "string", editable: false },
                            FirstName: { type: "string", editable: false },
                            Unit: { type: "string", editable: false }
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
                filterable: {
                    extra: false
                },
                height: 500,
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
                    field: "FirstName",
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
                    field: "LastName",
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
                    field: "NationalNo",
                    title: "کد ملی",
                    width: "200px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "PersonalNo",
                    title: "کد پرسنلی",
                    width: "200px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    command:
                        {
                            text: "پرونده", click: $scope.showFile
                        }
                    , title: " "
                    , width: "100px"
                }
                ]
            };
        }]);
});


