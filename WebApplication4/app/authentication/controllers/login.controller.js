(function (){
    'use strict';

    angular
        .module('oergjw.authentication.controllers')
        .controller('LoginController', loginController);

    loginController.$inject = ['$scope', '$location', 'authenticationService'];

    function loginController($scope, $location, authenticationService) {
        if (authenticationService.authentication.isAuth === true) {
            $location.path('/home');
            return;
        }

        $scope.loginData = {
            userName: "",
            password: "",
            useRefreshTokens: false
        };

        $scope.message = "";

        $scope.login = function () {
            authenticationService.login($scope.loginData).then(function (response) {
                $location.path('/home');
            },
             function (err) {
                 $scope.message = err.error_description;
             });
        };

    }
})();