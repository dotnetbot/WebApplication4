(function(){
    'use strict';
    angular
        .module('oergjw.claims.controllers')
        .controller('NewScansController', NewScansController);

    NewScansController.$inject = ['$scope', '$http', '$location', '$stateParams', 'authenticationService', 'FileUploader', 'localStorageService'];

    function NewScansController($scope, $http, $location, $stateParams, authenticationService, FileUploader, localStorageService) {
        var vm = this;

        if (authenticationService.authentication.isAuth !== true) {
            $location.path('/login');
            return;
        }
        var uploader = new FileUploader({
            url: "/api/scans/load/" + $stateParams.id
        });
        uploader.onBeforeUploadItem = function (item) {
            console.info('onBeforeUploadItem', item);
            var authData = localStorageService.get('authorizationData');
            item.headers.Authorization = 'Bearer ' + authData.token;
            //item.formData.push({ claimid: $stateParams.id });
        };
        uploader.onCompleteAll = function () {
            $location.path('/claimdetails/' + $stateParams.id);
        };

        vm.uploader = uploader;
    }
})();
