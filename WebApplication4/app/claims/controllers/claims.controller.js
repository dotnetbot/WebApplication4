(function(){
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('ClaimsController', claimsController);

    claimsController.$inject = ['$location', 'Claims']

    function claimsController($location, Claims) {
        var vm = this;

        activate();

        function activate() {
            Claims.get().then(function (response) {
                vm.claims = response.data
            });
        }

        vm.details = function(claimId){
            $location.path('/claimdetails/' + claimId);
        }
    }
})();