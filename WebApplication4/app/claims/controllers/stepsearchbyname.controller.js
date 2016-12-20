(function() {
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('StepSearchByNameController', StepSearchByNameController);

    StepSearchByNameController.$inject = ['$location', 'Persons', 'SearchStepsService'];

    function StepSearchByNameController($location, Persons, SearchStepsService) {
        var vm = this;
        vm.format = "dd.MM.yyyy";

        activate();

        function activate() {
            vm.snils = SearchStepsService.snils;
        }

        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = true;
        };

        vm.search = function() {
            Persons.findByName(vm.personData)
                .then(
                    function (response) {
                        vm.result = response.data;
                        vm.notFound = !response.data || !response.data.length;
                    }
                );
        };

        vm.moveNext = function () {
            SearchStepsService.setPersonData(vm.personData);
            $location.path('/newclaimer');
        };

        vm.use = function(person) {
            SearchStepsService.setPersonData(person);
            $location.path('/newclaim/');
        };
    }
})();