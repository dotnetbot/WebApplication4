(function () {
    'use strict';

    angular
      .module('oergjw.config')
      .config(config);

    config.$inject = ['$httpProvider'];

    function config($httpProvider) {
        $httpProvider.interceptors.push('authinterceptorService');
    }
})()