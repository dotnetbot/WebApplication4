(function () {
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('AddclaimController', addclaimController);

    addclaimController.$inject = ['$location', '$stateParams', 'Claims', 'Persons', 'Buildings', 'RejectCauses'];

    function addclaimController($location, $stateParams, Claims, Persons, Buildings, RejectCauses) {
        var vm = this;

        activate();

        function activate() {
            Buildings.all().then(function (response) {
                vm.buildings = response.data;
            });

            vm.registration = {};

            if ($stateParams.personid) {
                Persons.get($stateParams.personid).then(function (response) {
                    vm.claimerData = response.data;
                });
            }

            RejectCauses.get().then(function (response) { vm.rejectCauses = response.data; });
        }

        vm.create = function () {
            //var claim = {
            //    //claim properties
            //    inn: vm.registration.claim.inn,
            //    regAddress: vm.registration.claim.regAddress,
            //    postAddress: vm.registration.claim.postAddress,
            //    job: vm.registration.claim.job,
            //    jobSphere: vm.registration.claim.jobSphere,
            //    position: vm.registration.claim.position,
            //    familyIncome: vm.registration.claim.familyIncome,
            //    personalIncome: vm.registration.claim.personalIncome,
            //    ownership: vm.registration.claim.ownership,
            //    email: vm.registration.claim.email,
            //    phone: vm.registration.claim.phone
            //};
            vm.claim.personid = $stateParams.personid
            Claims.create(vm.claim).then(function (response) {
                $location.path('/newscans/' + response.data);
            })
        }

        vm.openRejectCause = function () {
            var modalInstance = $uibModal.open({
                templateUrl: 'RejectCause.html',
                controller: 'RejectClaimController',
                controllerAs: 'vm',
                resolve: {
                    rejectCauses: getRejectCause
                }
            });
        };

        function getRejectCause() {
            return vm.rejectCauses;
        }
    }
})();