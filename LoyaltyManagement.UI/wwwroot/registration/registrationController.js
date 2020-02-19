(function () {
    'use strict';

    angular
        .module('app')
        .controller('registrationController', Controller);

    function Controller(services) {
        var vm = this;
        

        vm.registration = function () {
            vm.loading = true;
            var data = {
                name: vm.name,
                email: vm.email,
                password: vm.password,
                role: vm.role,
                contactnumber: vm.contactnumber,
                address: vm.address
            }
            services.registration(data, function (result,data) {
                if (result === true) {
                    vm.success = 'User created successfully with id '+ data.id;
                    vm.loading = false;
                } else {
                    vm.error = 'something happened wrong';
                    vm.loading = false;
                }
            });
        };

        vm.logout = function () {
            services.logout();
        }
    }

})();