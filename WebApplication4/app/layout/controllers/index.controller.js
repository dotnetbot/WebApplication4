(function(){
    'use strict';

    angular
        .module('oergjw.layout.controllers')
        .controller('IndexController', indexController);

    indexController.$inject = ['$scope', 'authenticationService', '$location'];

    function indexController($scope, authenticationService, $location) {
        if (authenticationService.authentication.isAuth !== true) {
            $location.path('/login');
            return;
        }
    }
})();