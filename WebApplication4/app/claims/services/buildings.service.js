(function () {
    'use strict';

    angular
        .module('oergjw.claims.services')
        .factory('Buildings', buildingsService);

    buildingsService.$inject = ['$http'];

    function buildingsService($http) {
        var service = {
            all: all
        }

        return service;

        function all() {
            return $http.get('/api/buildings');
        }
    }
})();