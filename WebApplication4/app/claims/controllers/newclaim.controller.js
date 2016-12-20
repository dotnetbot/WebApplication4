(function () {
    'use strict';

    angular
        .module('oergjw.claims.controllers')
        .controller('NewclaimController', newclaimController);

    newclaimController.$inject = ['$location', '$stateParams', '$uibModal', 'Claims', 'Persons', 'Buildings', 'RejectCauses', 'SearchStepsService'];

    function newclaimController($location, $stateParams, $uibModal, Claims, Persons, Buildings, RejectCauses, SearchStepsService) {
        var vm = this;
        vm.format = "dd.MM.yyyy";

        activate();

        function activate() {
            Buildings.all().then(function (response) {
                vm.buildings = response.data;
            });

            vm.registration = {};

            if ($stateParams.blankid) {
                Claims.get($stateParams.blankid).then(function (response) {
                    vm.registration.claim = response.data;
                    Persons.get(vm.registration.claim.personId).then(function (response) {
                        vm.registration.personData = response.data;
                        vm.registration.snils = vm.registration.personData.snils;
                    });
                });
            } else {
                vm.registration.snils = SearchStepsService.getSnils();
                vm.registration.personData = SearchStepsService.getPersonData();
                var passport = SearchStepsService.getPassport();

                if (passport) {
                    vm.registration.personData.passportSeries = passport.series;
                    vm.registration.personData.passportNumber = passport.number;
                    vm.registration.personData.passportDate = passport.date;
                }
                //TO DO: A date always is a problem!
                //passport.date = new Date(passport.date);
                ///vm.registration.passport = passport;
            }

            RejectCauses.get().then(function (response) { vm.rejectCauses = response.data; });
        }

        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = true;
        };

        vm.open1 = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened1 = true;
        };

        vm.create = function () {
            var flattenClaim = {
                //person properties
                personId: vm.registration.personData.id,
                firstName: vm.registration.personData.firstName,
                lastName: vm.registration.personData.lastName,
                middleName: vm.registration.personData.middleName,
                dateOfBirth: vm.registration.personData.dateOfBirth,
                snils: vm.registration.snils,
                passportSeries: vm.registration.personData.passportSeries,
                passportNumber: vm.registration.personData.passportNumber,
                passportDate: vm.registration.personData.passportDate,

                //claim properties
                inn: vm.registration.claim.inn,
                regAddress: vm.registration.claim.regAddress,
                postAddress: vm.registration.claim.postAddress,
                job: vm.registration.claim.job,
                jobSphere: vm.registration.claim.jobSphere,
                position: vm.registration.claim.position,
                familyIncome: vm.registration.claim.familyIncome,
                personalIncome: vm.registration.claim.personalIncome,
                ownership: vm.registration.claim.ownership,
                email: vm.registration.claim.email,
                phone: vm.registration.claim.phone
            };
            Claims.create(flattenClaim).then(function (response) {
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