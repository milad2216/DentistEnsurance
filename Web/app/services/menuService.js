define(['angularAMD'], function (app) {
    app.service('menuService', ['$state', '$http', '$q', function ($state, $http, $q) {

        return {

            ReferredMenu: function () {

                var menu = [
                            { Desc: "رزروی‌ها", uiSref: "reserveSearch({status:0})", Class: "glyphicon-inbox" },
                            { Desc: "در انتظار تایید", uiSref: "reserveSearch({status:1})", Class: "glyphicon-edit" }   ,                 
                            { Desc: "تایید نشده", uiSref: "reserveSearch({status:2})", Class: "glyphicon-trash" },
                            { Desc: "انجام شده", uiSref: "reserveSearch({status:3})", Class: "glyphicon-share" }     ,               
                            { Desc: "لغو شده", uiSref: "reserveSearch({status:4})", Class: "glyphicon-share" },
                            { Desc: "اعتبار", uiSref: "reserveSearch({status:4})", Class: "glyphicon-credit-card" },
                ];
                return menu;
            },

            FinancialMenu: function () {

                var menu = [
                            { Desc: "رزروی‌ها", uiSref: "reserveSearch({status:0})", Class: "glyphicon-inbox" },
                            { Desc: "در انتظار تایید", uiSref: "reserveSearch({status:1})", Class: "glyphicon-edit" },
                            { Desc: "تایید نشده", uiSref: "reserveSearch({status:2})", Class: "glyphicon-trash" },
                            { Desc: "انجام شده", uiSref: "reserveSearch({status:3})", Class: "glyphicon-share" }
                ];
                return menu;
            },
        SecretaryMenu: function () {

            var menu = [
                        { Desc: "در انتظار نوبت", uiSref: "notBookedSearch", Class: "glyphicon-inbox" },
                        { Desc: "رزرو شده", uiSref: "bookedSearch", Class: "glyphicon-inbox" },
                        { Desc: "انجام شده", uiSref: "doneSearch", Class: "glyphicon-share" }
            ];
            return menu;
        },
        AdminMenu: function () {

            var menu = [
                        { Desc: "رزروی‌ها", uiSref: "reserveSearch({status:0})", Class: "glyphicon-inbox" },
                        { Desc: "انجام شده", uiSref: "reserveSearch({status:3})", Class: "glyphicon-share" }
            ];
            return menu;
        }
    }
    }])
});

