(function(){
    'use strict';

    angular
        .module('oergjw.persons.controllers')
        .controller('PersonDetailsController', PersonDetailsController);

    PersonDetailsController.$inject = ['$location', '$stateParams', '$uibModal', 'Persons', 'Claims'];

    function PersonDetailsController($location, $stateParams, $uibModal, Persons, Claims) {
        var vm = this;

        activate();

        function activate() {
            Persons.get($stateParams.id).then(function (response) {
                vm.persondetails = response.data;
                Claims.getByPerson(vm.persondetails.id).then(function (response) {
                    vm.persondetails.claims = response.data;
                });
            });
        }

        vm.openBrief = function (claim) {
            var modalInstance = $uibModal.open({
                //animation: $scope.animationsEnabled,
                templateUrl: 'BriefClaim.html',
                controller: 'BriefClaimController',
                controllerAs: 'vm',
                //size: size,
                resolve: {
                    claimBrief: claim
                }
            });
        };

        vm.addClaim = function (personid) {
            $location.path('/addclaim/' + personid);
        };
    }
})();