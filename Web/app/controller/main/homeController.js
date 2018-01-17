define(['app'], function (app) {
    debugger
    app.register.controller('homeController', ['$scope', '$rootScope', '$state', '$http',
        function ($scope, $rootScope, $state, $http) {
            $scope.title = "milad majid"
            debugger
            $scope.refresh = function (e) {
                $scope.mainGrid.dataSource.read();
            }
            $scope.mainGridOptions = {
                // autoBind:false,
                dataSource: {
                  
                    transport: {
                        //read: function (options) {
                        //    return {
                        //        type: "POST",
                        //        url: "/api/Personal/Read",
                        //        dataType: "json",
                        //        data: {
                        //            query : options.data
                        //        }
                        //    }
                        //},
                        read:  {//You can get the current page, pageSize etc off `e`.
                            type: "GET",
                            url: "/api/Personal/Get2",
                            dataType: "json",
                           
                        },
                        //parameterMap: function (data, type) {
                        //    if (type === "read") {
                        //        // send take as "$top" and skip as "$skip"
                        //        debugger;
                        //        return {
                        //            $top: data.take,
                        //            $skip: data.skip
                        //        }
                        //    }
                        //}
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
                pageable: {
                    buttonCount: 3,
                    previousNext:  true,
                    numeric:  true,
                    refresh:  true,
                    info: true,
                    pageSizes: [15, 30, 100, 500]
                },
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
                            read: {
                                type: "GET",
                                url: "/api/Personal/ReadChildren",
                                dataType: "json",
                                data: {
                                    parentId: dataItem.ParentId
                                }
                            }
                        },
                        schema: {
                            parse: function (response) {
                                debugger;
                                return response;
                            },
                            data: "data",
                            total: "total"
                        },
                        serverPaging: true,
                        serverSorting: true,
                        serverFiltering: true,
                        pageSize: 5
                    },
                    scrollable: false,
                    sortable: true,
                    pageable: true,
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
                        field: "Relation",
                        title: "نسبت",
                        width: "120px"
                    }
                    ]
                };
            };
        }]);
});


