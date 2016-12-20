(function(){
    'use strict';

    angular
        .module('oergjw.persons.controllers')
        .controller('BriefClaimController', BriefClaimController);

    BriefClaimController.$inject = ['$uibModalInstance', '$location', 'claimBrief'];

    function BriefClaimController($uibModalInstance, $location, claimBrief) {
        var vm = this;
        vm.claimBrief = claimBrief;

        vm.ok = function () {
            $uibModalInstance.close();
        };

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };

        vm.go = function () {
            $uibModalInstance.close();
            $location.path('/claimdetails/' + vm.claimBrief.id);
        };

        vm.useAsBlank = function () {
            $uibModalInstance.close();
            $location.path('/newclaim/' + vm.claimBrief.id);
        }
    }

})();