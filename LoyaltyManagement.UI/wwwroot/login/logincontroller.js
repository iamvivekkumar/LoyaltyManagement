﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('loginController', Controller);

    function Controller($location, $localStorage, services) {
        var vm = this;

        initController();

        function initController() {
            if ($localStorage.currentUser) {
                $location.path('/');
            }
            else {
                // reset login status
                services.logout();
            }
        };

        vm.login = function() {
            vm.loading = true;
            services.login(vm.username, vm.password, function (result) {
                if (result === true) {
                    $location.path('/');
                } else {
                    vm.error = 'Username or password is incorrect';
                    vm.loading = false;
                }
            });
        };
    }

})();