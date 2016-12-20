(function(){
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('InworkClaimsController', inworkClaimsController);

    inworkClaimsController.$inject = ['$location', 'Claims']

    function inworkClaimsController($location, Claims) {
        var vm = this;

        activate();

        function activate() {
            Claims.getInwork().then(function (response) {
                vm.claims = response.data
            });
        }

        vm.details = function(claimId){
            $location.path('/claimdetails/' + claimId);
        }
    }
})();