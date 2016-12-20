(function () {
    'use strict';

    angular
        .module('oergjw.claims.services')
        .factory('PersonsService', PersonsService);

    PersonsService.$inject = ['$http', '$q'];

    function PersonsService($http, $q) {
        var service = {
            findBySnils: findBySnils,
            findByPassport: findByPassport,
            findByName: findByName
            
        };

        return service;

        function findBySnils(snils) {

            return $http.get('/api/people/getbysnils', {
                params: { snils: snils }
            });
        }
        
        function findByPassport(passport) {

            return $http.get('/api/people/getbypassport', {
                params: {
                    series: passport.series,
                    number: passport.number,
                    date: passport.date
                }
            });
        }
        
        function findByName(person) {

            return $http.get('/api/people/getbyname', {
                params: {
                    firstName: person.firstName,
                    lastName: person.lastName,
                    middleName: person.middleName
                } 
            });
        }
    }
})();