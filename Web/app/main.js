debugger
var urlArg = "v=1.0.0";
require.config({
    baseUrl: '',
    urlArgs: urlArg,
    paths: {
        'app': '/app/app',
        'angularAMD': '/Scripts/core/angularAMD',
        'ngload': '/Scripts/core/ngload'
    },
    waitSeconds: 0,
    deps: ['app']
});

require([
    'app',
    "/app/services/dataService.js",
    "/app/directive/master.js",
    "/app/directive/pn-combobox.js",
    //"/app/directive/login.js"
], function (app) {
    app.bootstrap();
});
