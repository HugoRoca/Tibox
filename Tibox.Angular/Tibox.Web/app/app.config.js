(function (undefined) {

    'use stric';

    angular.module("app").config(config).run(run);

    function config($compileProvider) {
        $compileProvider.debugInfoEnabled(false);
    }

    function run($http, $state, localStorageService, configService) {
        var user = localStorageService.get('userToken');
        if (user && user.token) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + user.token;
            configService.setLogin(true);
            $state.go('product');
        }
        $state.go('login');
    }

})();