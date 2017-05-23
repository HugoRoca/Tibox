(function () {
    'use strict';
    
    angular.module('app')
    .config(routeConfig);

    routeConfig.$inject = ['$stateProvider','$urlRouterProvider'];

    function routeConfig($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("home", {
                url: "/home",
                templateUrl: 'app/home.html'
            })
            .state("login", {
                url: "/login",
                templateUrl: 'app/public/login.html'
            })
            .state("product", {
                url: "/product",
                templateUrl: 'app/private/product/index.html'
            })
            .state("supplier", {
                url: "/supplier",
                templateUrl: 'app/private/supplier/index.html'
            })
            .state("otherwise", {
                url: '*path',
                templateUrl: 'app/home.html'
            });
    }

})();