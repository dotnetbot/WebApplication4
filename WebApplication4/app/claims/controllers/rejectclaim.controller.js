(function(){
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('RejectClaimController', RejectClaimController);

    RejectClaimController.$inject = ['$uibModalInstance', 'claimid', 'RejectCauses', 'Claims'];

    function RejectClaimController($uibModalInstance, claimid, RejectCauses, Claims) {
        var vm = this;

        activate();

        function activate() {
            RejectCauses.get().then(function (response) { vm.rejectCauses = response.data; });
        }

        vm.ok = function () {
            Claims.reject({
                claimid: claimid,
                causeid: vm.reject.causeid
            }).then(function (response) {
                $uibModalInstance.close(response.data);
            });
        };

        vm.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };
    }
})();