(function() {
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('StepSearchByPassportController', StepSearchByPassportController);

    StepSearchByPassportController.$inject = ['$location', 'Persons', 'SearchStepsService'];

    function StepSearchByPassportController($location, Persons, SearchStepsService) {
        var vm = this;
        vm.format = "dd.MM.yyyy";
        
        activate();
        
        function activate() {
            //vm.snils = SearchStepsService.snils;
        }

        vm.open = function($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = true;
        };

        vm.search = function() {
            SearchStepsService.setPassport(vm.passport);
            Persons.findByPassport(vm.passport)
                .then(
                    function (response) {
                        vm.result = response.data;
                        vm.notFound = !response.data || !response.data.length;
                    },
                    function (response) {
                        vm.notFound = response.status == 404;
                    });
        };

        vm.use = function(person) {
            SearchStepsService.setPersonData(person);
            $location.path('/newclaim/');
        };

        vm.moveNext = function () {
            SearchStepsService.setPassport(vm.passport);
            $location.path('/stepsearchbyname');
        };
    }
})();