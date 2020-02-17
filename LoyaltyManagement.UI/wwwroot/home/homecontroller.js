(function () {
    'use strict';

    angular
        .module('app')
        .controller('homeController', Controller);

    function Controller(services) {
        var vm = this;

        vm.logout = function () {
            services.logout();
        }
    }

})();