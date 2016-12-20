(function(){
    'use strict';

    angular
        .module('oergjw.claims.services')
        .factory('RejectCauses', RejectCauses);

    RejectCauses.$inject = ['$http'];

    function RejectCauses($http) {
        var service = {
            get: get
        }

        return service;

        function get() {
            return $http.get('/api/rejectcauses');
        }
    }
})();