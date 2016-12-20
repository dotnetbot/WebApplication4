(function(){
    'use strict';

    angular
        .module('oergjw.persons.services')
        .factory('Persons', Persons);

    Persons.$inject = ['$http'];

    function Persons($http) {
        var service = {
            all: all,
            get: get,
            findBySnils: findBySnils,
            findByPassport: findByPassport,
            findByName: findByName,
            registerClaimer: registerClaimer
        }

        return service;

        function all() {
            return $http.get('/api/claimers');
        }

        function get(id) {
            return $http.get('/api/people/' + id);
        }

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

        function registerClaimer(claimerData) {
            return $http.post('/api/registerclaimer', claimerData);
        }
    }
})();