(function(){
    'use strict';

    angular
        .module('oergjw.persons.controllers')
        .controller('NewClaimerController', newclaimerController);

    newclaimerController.$inject = ['$location', '$stateParams', '$uibModal', 'Persons', 'SearchStepsService'];

    function newclaimerController($location, $stateParams, $uibModal, Persons, SearchStepsService) {
        var vm = this;
        vm.format = "dd.MM.yyyy";

        activate();

        function activate() {
            vm.claimerData = {};

            var snils = SearchStepsService.getSnils();
            if (snils)
                vm.claimerData.snils = snils;

            var personData = SearchStepsService.getPersonData();
            if (personData) {
                vm.claimerData.firstName = personData.firstName;
                vm.claimerData.lastName = personData.lastName;
                vm.claimerData.middleName = personData.middleName;
                vm.claimerData.dateOfBirth = personData.dateOfBirth;
            }

            var passport = SearchStepsService.getPassport();
            if (passport) {
                vm.claimerData.passportSeries = passport.series;
                vm.claimerData.passportNumber = passport.number;
                vm.claimerData.passportDate = passport.date;
            }
        }

        vm.create = function () {
            //var claimerData = {                
            //    firstName: vm.registration.personData.firstName,
            //    lastName: vm.registration.personData.lastName,
            //    middleName: vm.registration.personData.middleName,
            //    dateOfBirth: vm.registration.personData.dateOfBirth,
            //    snils: vm.registration.snils,
            //    passportSeries: vm.registration.personData.passportSeries,
            //    passportNumber: vm.registration.personData.passportNumber,
            //    passportDate: vm.registration.personData.passportDate                
            //};
            Persons.registerClaimer({claimerData: vm.claimerData}).then(function (response) {
                $location.path('/addclaim/' + response.data);
            })
        }

        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = true;
        };

        vm.open1 = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened1 = true;
        };
    }
})();