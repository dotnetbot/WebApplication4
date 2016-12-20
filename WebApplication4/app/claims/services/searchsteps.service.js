(function() {
    'use strict';

    angular
        .module('oergjw.claims.services')
        .factory('SearchStepsService', searchStepsService);
    
    function searchStepsService() {

        var service = {
            setPassport: setPassport,
            getPassport: getPassport,
            setPersonData: setPersonData,
            getPersonData: getPersonData,
            getSnils: getSnils,
            setSnils: setSnils
        };
        
        return service;

        function getSnils() {
            return this.snils;
        }
        
        function setSnils(snils) {
            this.snils = snils;
        }
        
        function setPassport(passport) {
            this.passport = passport;
        }
        
        function getPassport() {
            return this.passport;
        }
        
        function setPersonData(personData) {
            this.personData = personData;
        }
        
        function getPersonData() {
            return this.personData;
        }
    }
})();