(function(){
    'use strict';

    angular
        .module('oergjw.persons.controllers')
        .controller('PersonsController', PersonsController);

    PersonsController.$inject = ['$location', 'Persons'];

    function PersonsController($location, Persons) {
        var vm = this;

        activate();

        function activate() {
            Persons.all().then(function (response) {
                vm.persons = response.data;
            });
        }

        vm.details = function (id) {
            $location.path('/persondetails/' + id);
        }
    }
})();