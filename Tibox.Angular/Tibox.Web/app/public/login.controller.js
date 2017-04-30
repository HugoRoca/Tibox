(function (undefined) {

    'use strict';

    angular.module('app').controller('loginController', loginController);

    loginController.$inject = ['authenticationServive', '$state']

    function loginController(authenticationServive, $state) {
        var vm = this;
        vm.user = {};
        vm.login = login;

        function login() {
            authenticationServive.login(vm.user);
            $state.go('home');
        }

    }

})();

