debugger;
define(['app'], function (app) {
    debugger
    app.register.controller('homeController', ['$scope', '$rootScope', '$state', '$http',
        function ($scope, $rootScope, $state, $http) {
            $scope.title = "داشبورد"
            debugger
            $scope.refresh = function (e) {
                $scope.kendoGrid.dataSource.read();
            }
            $scope.editPerson = function (e) {
                var myItem = $scope.kendoGrid.dataItem($(e.target).closest("tr"));
                $state.go("person", { profile: myItem });
                $scope.$apply();
            }

            $scope.dataSource = new kendo.data.DataSource({
                transport: {
                    read: {//You can get the current page, pageSize etc off `e`.
                        type: "GET",
                        url: "/api/Personal/Get2",
                        dataType: "json",

                    }
                },
                schema: {
                    parse: function (response) {
                        debugger;
                        return response.data;
                    },
                    data: "data",
                    total: "total"
                },
                autoSync: false,
                serverPaging: true,
                pageSize: 10,
                serverSorting: true,
                serverFiltering: true,
            });
            $scope.mainGridOptions = {
                // autoBind:false,
                dataSource: $scope.dataSource,
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
                    field: "FirstName",
                    title: "نام",
                    width: "120px"
                }, {
                    field: "LastName",
                    title: "نام خانوادگی",
                    width: "120px"
                }, {
                    field: "NationalNo",
                    title: "کد ملی",
                    width: "120px"
                }, {
                    field: "PersonalNo",
                    title: "کد پرسنلی",
                    width: "120px"
                }, {
                    command:
                        {
                            text: "ویرایش", click: $scope.editPerson
                        }
                    , title: " "
                    , width: "80px"
                }
                ]
            };
        }]);
});


