(function (undefined) {

    'use stric';

    angular.module('app').controller('productController', productController);

    function productController(dataService, configService, $state) {
        var apiUrl = configService.getApiUrl();
        var vm = this;

        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            list();
        }

        function list() {
            dataService.getData(apiUrl + '/product/list').then(function (result) {
                console.log(result.data);
            },
            function (error) {
                console.log(error);
            });
        }
    }

})();