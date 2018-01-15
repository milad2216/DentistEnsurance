define(['app'], function (app) {
    debugger
    app.register.controller('homeController', ['$scope', '$rootScope', '$state',
        function ($scope, $rootScope, $state) {
            $scope.title = "milad majid"
            debugger
            $scope.get = function () {
                $state.go("milad");
            }

            $scope.mainGridOptions = {
                // autoBind:false,
                dataSource: {
                    type: "odata",
                    transport: {
                        read: {
                            type: "GET",
                            url: "/api/Personal/Read",
                            dataType: "json",
                        },
                    },
                    schema: {
                        parse: function (response) {
                            debugger;
                            return response;
                        },
                        data: "data",
                        total: "total"
                    },
                    //requestEnd: function (e) {
                    //    debugger;
                    //},
                    pageSize: 5,
                    serverPaging: true,
                    serverSorting: true
                },
                sortable: true,
                pageable: true,
                dataBound: function (e) {
                    debugger
                    this.expandRow(this.tbody.find("tr.k-master-row").first());
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
                }]
            };

            $scope.detailGridOptions = function (dataItem) {
                return {
                    dataSource: {
                        type: "odata",
                        transport: {
                            read: "/api/Personal/Read"
                        },
                        serverPaging: true,
                        serverSorting: true,
                        serverFiltering: true,
                        pageSize: 5,
                        filter: { field: "EmployeeID", operator: "eq", value: dataItem.EmployeeID }
                    },
                    scrollable: false,
                    sortable: true,
                    pageable: true,
                    columns: [
                        { field: "OrderID", title: "کد خدمات", width: "56px" },
                        { field: "ShipCountry", title: "شهر ارایه دهنده", width: "110px" },
                        { field: "ShipAddress", title: "آدرس" },
                        { field: "ShipName", title: "عنوان خدمت", width: "190px" }
                    ]
                };
            };
        }]);
});


