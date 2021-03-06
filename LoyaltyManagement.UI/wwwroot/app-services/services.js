﻿(function () {
    'use strict';

    angular
        .module('app')
        .factory('services', services);

    function services($http, $localStorage, $location, constants) {
        var service = {};

        service.login = function (username, password, callback) {
            $http.post(constants().loginUri, { email: username, password: password })
                .then(function (response) {
                    // login successful if there's a token in the response
                    if (response.data.token) {
                        // store username and token in local storage to keep user logged in between page refreshes
                        $localStorage.currentUser = { username: username, token: response.data.token };

                        // add jwt token to auth header for all requests made by the $http service
                        $http.defaults.headers.common.Authorization = 'Bearer ' + response.data.token;

                        // execute callback with true to indicate successful login
                        callback(true);
                    } else {
                        // execute callback with false to indicate failed login
                        callback(false);
                    }
                },
                    function (err) {
                        callback(false);
                    }
            );
        }

        service.registration = function (data, callback) {
            $http.post(constants().registrationUri, data)
                .then(function (response) {
                    if (response.status == 201) {
                       
                        callback(true, response.data);
                    } else {
                        callback(false);
                    }
                },
                    function (err) {
                        callback(false);
                    }
                );
        }

        service.logout = function () {
            // remove user from local storage and clear http auth header
            delete $localStorage.currentUser;
            $http.defaults.headers.common.Authorization = '';
            $location.path('/login');
        }

        return service;
    }
})();