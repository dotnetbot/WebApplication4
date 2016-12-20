(function(){
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('RejectedClaimsController', rejectedClaimsController);

    rejectedClaimsController.$inject = ['$location', 'Claims']

    function rejectedClaimsController($location, Claims) {
        var vm = this;

        activate();

        function activate() {
            Claims.getRejected().then(function (response) {
                vm.claims = response.data
            });
        }

        vm.details = function(claimId){
            $location.path('/claimdetails/' + claimId);
        }
    }
})();