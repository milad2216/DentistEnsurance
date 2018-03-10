define(['app'], function (app) {
    app.register.controller('personalFileController', ['$scope', '$rootScope', '$state', '$http', '$stateParams', 'dataService', 'Notification',
        function ($scope, $rootScope, $state, $http, $stateParams, dataService, Notification) {
            $scope.title = "نوبت دهی";
            $scope.personal = $stateParams.personal;
            $scope.file = {};
            if ($scope.personal.Files.length > 0)
                $scope.file = $scope.personal.Files[0];
            else {
                $scope.file.PersonalId = $scope.personal.ID;
                $scope.file.ID = 0;
            }



            $scope.saveEntity = function () {
                if ($scope.PersonalFileForm.$valid) {
                    dataService.postData('/api/PersonalFile/Save', $scope.file).then(function (data) {
                        Notification.success(data.message);
                        if (data.ID) {
                            $scope.file.ID = data.ID;
                            $state.go("personalSearch");
                        }
                    })
                }
            }


            var dataSource = new kendo.data.DataSource({
                transport: {
                    read: {//You can get the current page, pageSize etc off `e`.
                        type: "GET",
                        url: "/api/TreatmentPlan/GetByFileId?fileId=" + $scope.file.ID,
                        dataType: "json",

                    },
                    update: {
                        dataType: "json",
                        type: "PUT",
                        url: "/api/TreatmentPlan/Edit",

                        beforeSend: function (request) {
                            debugger
                        },
                        complete: function (jqXhr, textStatus) {
                            $scope.mainGridOptions.dataSource.read();
                        }

                    },
                    destroy: {
                        type: "DELETE",
                        url: function (options) {
                            return "/api/TreatmentPlan/Delete/" + options.ID;
                        },
                        dataType: "json",
                        complete: function (jqXhr, textStatus) {
                            $scope.mainGridOptions.dataSource.read();
                        }
                    },
                    create: {
                        type: "POST",
                        url: "/api/TreatmentPlan/Create",
                        dataType: "json",
                        complete: function (jqXhr, textStatus) {
                            $scope.mainGridOptions.dataSource._page = 1;
                            $scope.mainGridOptions.dataSource._skip = 0;
                            $scope.mainGridOptions.dataSource.read();
                        }
                    }
                },
                //parameterMap: function (data, type) {
                //    debugger
                //    if (type != "read") {
                //        data.FileId = $scope.file.ID;
                //    }
                //    return data;

                //},
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
                            FileId: { type: "number", defaultValue: $scope.file.ID },
                            Date: { type: "date", nullable: false },
                            Cost: { type: "number", nullable: false },
                            Description: { type: "string", nullable: false },
                            File: { defaultValue: {} }
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
                height: 200,
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
                toolbar: [{ name: "create", text: "اضافه کردن طرح درمان" }],
                editable: "inline",
                columns: [{
                    field: "Date",
                    title: "تاریخ",
                    template: "#= moment(Date).format('jYYYY/jMM/jDD')#",
                    width: "200px"
                }, {
                    field: "Description",
                    title: "توضیح",
                    width: "400px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "Cost",
                    title: "هزینه تقریبی",
                    width: "200px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    command: [
                        {
                            text: "ویرایش", name: "edit"
                        }, {
                            text: "حذف", name: "delete"
                        }
                    ]
                    , title: " "
                    , width: "200px"
                }
                ]
            };

            var treatmentDescriptionDataSource = new kendo.data.DataSource({
                transport: {
                    read: {//You can get the current page, pageSize etc off `e`.
                        type: "GET",
                        url: "/api/TreatmentDescription/GetByFileId?fileId=" + $scope.file.ID,
                        dataType: "json",

                    },
                    update: {
                        dataType: "json",
                        type: "PUT",
                        url: "/api/TreatmentDescription/Edit",

                        beforeSend: function (request) {
                            debugger
                        },
                        complete: function (jqXhr, textStatus) {
                            $scope.mainGridOptions.dataSource.read();
                        }

                    },
                    destroy: {
                        type: "DELETE",
                        url: function (options) {
                            return "/api/TreatmentDescription/Delete/" + options.ID;
                        },
                        dataType: "json",
                        complete: function (jqXhr, textStatus) {
                            $scope.mainGridOptions.dataSource.read();
                        }
                    },
                    create: {
                        type: "POST",
                        url: "/api/TreatmentDescription/Create",
                        dataType: "json",
                        complete: function (jqXhr, textStatus) {
                            $scope.mainGridOptions.dataSource._page = 1;
                            $scope.mainGridOptions.dataSource._skip = 0;
                            $scope.mainGridOptions.dataSource.read();
                        }
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
                            FileId: { type: "number", defaultValue: $scope.file.ID },
                            Date: { type: "date", nullable: false },
                            Cost: { type: "number", nullable: false },
                            Description: { type: "string", nullable: false },
                            Received: { type: "number", defaultValue: null },
                            Remainder: { type: "number", nullable: false },
                            Reported: { type: "boolean", editable: false },
                            File: { defaultValue: {} }
                        }
                    }
                },
                autoSync: false,
                serverPaging: true,
                pageSize: 10,
                serverSorting: true,
                serverFiltering: true,
            });
            $scope.treatmentDescriptionGridOptions = {
                // autoBind:false,
                dataSource: treatmentDescriptionDataSource,
                filterable: {
                    extra: false
                },
                height: 200,
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
                },
                toolbar: [{ name: "create", text: "اضافه کردن درمان" }],
                editable: "inline",
                columns: [{
                    field: "Date",
                    title: "تاریخ",
                    template: "#= moment(Date).format('jYYYY/jMM/jDD')#",
                    width: "200px"
                }, {
                    field: "Description",
                    title: "توضیح",
                    width: "200px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "Cost",
                    title: "هزینه درمان",
                    width: "100px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "Received",
                    title: "پیش پرداخت",
                    width: "100px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    field: "Remainder",
                    title: "باقی مانده",
                    width: "100px",
                    filterable:
                    {
                        cell:
                        {
                            dataSource: {},
                        }
                    }
                }, {
                    command: [
                        {
                            text: "ویرایش", name: "edit"
                        }, {
                            text: "حذف", name: "delete"
                        }
                    ]
                    , title: " "
                    , width: "150px"
                }
                ]
            };
        }]);
});


