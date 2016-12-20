(function () {
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('ClaimDetailsController', ClaimDetailsController);

    ClaimDetailsController.$inject = ['$stateParams', '$location', '$uibModal', 'Claims'];

    function ClaimDetailsController($stateParams, $location, $uibModal, Claims) {
        var vm = this;

        activate();

        function activate() {
            Claims.get($stateParams.id).then(function (response) {
                vm.claimdetails = response.data;
                _.each(vm.claimdetails.scans, function (value) {
                    value.ext = value.originalName.split('.').pop();
                    if (value.ext)
                        value.ext = value.ext.toLowerCase();
                });
            });
        }

        vm.addscans = function () {
            $location.path('/newscans/' + vm.claimdetails.id);
        }

        //$scope.boxId = 'fancypdf';

        function roundShift(original, index) {
            var a = new Array(original.length);
            for (var i = 0; i < original.length; i++) {
                a[i] = original[(i + index) % original.length];
            }
            return a;
        }

        vm.openBox = function (originalName, scanId, index) {
            var imgObjs = _.map(roundShift(vm.claimdetails.scans, index), function (value) {
                var type = 'image';
                if (value.ext == 'pdf' || value.ext == 'doc' || value.ext == 'docx' || value.ext == 'tif') {
                    type = 'iframe';
                }
                return {
                    href: '/images/get/' + value.id,
                    type: type
                };
            });

            $.fancybox.open(imgObjs, {
                scrollOutside: true
            });
        };

        vm.openRejectCause = function () {
            var modalInstance = $uibModal.open({
                templateUrl: 'RejectCause.html',
                controller: 'RejectClaimController',
                controllerAs: 'vm',
                resolve: {
                    claimid: function () { return vm.claimdetails.id }
                }
            });
        };

        vm.goInwork = function () {
            Claims.goInwork(vm.claimdetails.id).then(function (response) {
                vm.claimdetails = response.data;
            });
        };
    }
})();