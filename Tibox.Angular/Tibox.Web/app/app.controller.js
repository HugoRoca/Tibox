(function (undefined) {

    'use stric';

    angular.module("app").controller("applicationController", applicationController);

    function applicationController($scope, configService, authenticationServive) {
        var vm = this;

        vm.validate = validate;
        vm.logout = logout;

        $scope.init = function (url) {
            configService.setApiUrl(url);
        }

        function validate() {
            return configService.getLogin();
        }

        function logout() {
            authenticationServive.logout();
        }
    }

})();