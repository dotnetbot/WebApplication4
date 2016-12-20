(function(){
    'use strict';

    angular
        .module('oergjw.claims.services')
        .factory('Claims', Claims);

    Claims.$inject = ['$http'];

    function Claims($http) {
        var Claims = {
            get: get,
            getRejected: getRejected,
            getInwork: getInwork,
            getByPerson: getByPerson,
            create: create,
            reject: reject,
            goInwork: goInwork
        }

        return Claims;

        function create(claim) {
            return $http.post('/api/registerclaim', claim);
        }

        function getRejected() {
            return $http.get('/api/claims/getrejected');
        }

        function getInwork() {
            return $http.get('/api/claims/getinwork');
        }

        function get(id){
            return $http.get('/api/claims', { params: { id: id } });
        }

        function getByPerson(personId) {
            return $http.get('/api/claims/getbyperson/' + personId);
        }

        function reject(rejectData) { 
            return $http.post('/api/claims/reject', rejectData);
        }

        function goInwork(claimid) {
            return $http.post('/api/claims/goinwork', { claimid: claimid });
        }
    }
})();