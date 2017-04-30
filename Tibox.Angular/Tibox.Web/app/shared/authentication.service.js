(function (undefined) {

    'use stric';

    angular.module('app').factory("authenticationServive", authenticationServive);

    authenticationServive.$inject = ['$http', '$state', 'localStorageService', 'configService'];

    function authenticationServive($http, $state, localStorageService, configService) {
        var service = {};
        service.login = login;
        service.logout = logout;

        return service;

        function login(user) {
            var url =  configService.getApiUrl() + '/token';
            var data = "grant_type=password&username=" + user.userName + "&password=" + user.password;

            $http.post(url, data, {
                header: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (result) {
                console.log(result);
                $http.defaults.headers.common.Authorization = 'Bearer ' + result.data.access_token;
                localStorageService.set('userToken', {
                    token: result.data.access_token,
                    username: user.userName
                });

                configService.setLogin(true);
            });
        }

        function logout() {
            if (!configService.getLogin()) return $state.go('login');
            $http.defaults.headers.common.Authorization = '';
            localStorageService.remove('userToken');
            configService.setLogin(false);
            $state.go('home');
        }

    }

})();