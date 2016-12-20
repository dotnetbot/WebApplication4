(function(){
    'use strict';
    angular
        .module('oergjw.layout.controllers')
        .controller('NavbarController', navbarController);

    navbarController.$inject = ['$scope', '$http', '$location', 'authenticationService', '$state'];

    function navbarController($scope, $http, $location, authenticationService, $state) {
        $scope.$state = $state;

        $scope.logOut = function () {
            authenticationService.logOut();
            $location.path('/login');
        };

        $scope.authentication = authenticationService.authentication;
    }
})();
