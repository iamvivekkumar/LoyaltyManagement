(function () {
    'use strict';

    angular
        .module('app')
        .constant('constants', constants);

    function constants() {
        var constant = {};

        var baseUri = "http://localhost:64760/api/"; 

        constant.loginUri = baseUri + "Auth";

        constant.registrationUri = baseUri + "Registration";
        
        return constant;
       
    }

    
})();