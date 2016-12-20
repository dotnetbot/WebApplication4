(function() {
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('StepSearchBySnilsController', StepSearchBySnilsController);

    StepSearchBySnilsController.$inject = ['$location', 'Persons', 'SearchStepsService'];

    function StepSearchBySnilsController($location, Persons, SearchStepsService) {
        var vm = this;
        
        activate();

        function activate() {
            
        }

        vm.search = function() {
            Persons.findBySnils(vm.snils).then(
                function (response) {
                    vm.findedPerson = response.data;
                },
                function (response) {
                    if (response.status == 404) {
                        vm.notFound = true;
                    }
                });
        };

        vm.moveNext = function () {
            SearchStepsService.snils = vm.snils;
            $location.path('/stepsearchbypassport');
        };

        vm.use = function() {
            SearchStepsService.setSnils(vm.findedPerson.snils);
            //SearchStepsService.setPassport(vm.findedPerson.passport);
            //SearchStepsService.setPersonData({
            //    id: vm.findedPerson.id,
            //    firstName: vm.findedPerson.firstName,
            //    lastName: vm.findedPerson.lastName,
            //    middleName: vm.findedPerson.middleName,
            //    dateOfBirth: vm.findedPerson.dateOfBirth
            //});
            SearchStepsService.setPersonData(vm.findedPerson);
            $location.path('/newclaim/');
        };
    }
})();