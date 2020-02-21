(function () {
    'use strict';

    angular
        .module('app')
        .controller('logoutController', Controller);

    function Controller(services) {

        initController();

        function initController() {
            services.logout();
        };
    }

})();