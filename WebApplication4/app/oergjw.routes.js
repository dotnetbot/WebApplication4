(function () {
    'use strict';

    angular
        .module('oergjw.routes')
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/home");

        $stateProvider.state('home', {
            url: '/home',
            templateUrl: "/app/views/home.html",
            controller: "IndexController",
            data: {
                ncyBreadcrumbLabel: 'Главная'
            },
            activetab: 'home'
        });

        $stateProvider.state('login', {
            url: '/login',
            templateUrl: "/app/views/login.html",
            controller: "LoginController",
            data: {
                ncyBreadcrumbLabel: 'Вход'
            },
            activetab: 'login'
        });

        $stateProvider.state('persons', {
            url: '/persons',
            templateUrl: "/app/views/persons.html",
            controller: "PersonsController",
            controllerAs: 'vm'
        });

        $stateProvider.state('personsdetails', {
            url: '/persondetails/:id',
            templateUrl: "/app/views/persondetails.html",
            controller: "PersonDetailsController",
            controllerAs: 'vm'
        });

        $stateProvider.state('newclaimer', {
            url: '/newclaimer',
            templateUrl: "/app/views/newclaimer.html",
            controller: "NewClaimerController",
            controllerAs: 'vm'
        });

        $stateProvider.state('newclaim', {
            url: '/newclaim/:blankid',
            templateUrl: "/app/views/newclaim.html",
            controller: "NewclaimController",
            controllerAs: 'vm'
        });

        $stateProvider.state('dpTest', {
            url: '/dp',
            templateUrl: "/app/views/dp.html",
            controller: "DatepickerPopupDemoCtrl",
            controllerAs: 'vm'
        });

        $stateProvider.state('addclaim', {
            url: '/addclaim/:personid',
            templateUrl: "/app/views/addclaim.html",
            controller: "AddclaimController",
            controllerAs: 'vm'
        });

        $stateProvider.state('claims', {
            url: '/claims',
            templateUrl: "/app/views/claims.html",
            controller: "ClaimsController",
            controllerAs: 'vm'
        });
        $stateProvider.state('rejectedclaims', {
            url: '/rejected',
            templateUrl: "/app/views/rejectedclaims.html",
            controller: "RejectedClaimsController",
            controllerAs: 'vm'
        });
        $stateProvider.state('inworkclaims', {
            url: '/inwork',
            templateUrl: "/app/views/inworkclaims.html",
            controller: "InworkClaimsController",
            controllerAs: 'vm'
        });
        
        $stateProvider.state('stepsearchbysnils', {
            url: '/stepsearchbysnils',
            templateUrl: "/app/views/stepsearchbysnils.html",
            controller: "StepSearchBySnilsController",
            controllerAs: 'vm'
        });
        
        $stateProvider.state('stepsearchbypassport', {
            url: '/stepsearchbypassport',
            templateUrl: "/app/views/stepsearchbypassport.html",
            controller: "StepSearchByPassportController",
            controllerAs: 'vm'
        });
        
        $stateProvider.state('stepsearchbyname', {
            url: '/stepsearchbyname',
            templateUrl: "/app/views/stepsearchbyname.html",
            controller: "StepSearchByNameController",
            controllerAs: 'vm'
        });

        $stateProvider.state('claimdetails', {
            url: '/claimdetails/:id',
            templateUrl: "/app/views/claimdetails.html",
            controller: "ClaimDetailsController",
            controllerAs: 'vm'
        });

        $stateProvider.state('newscans', {
            url: '/newscans/:id',
            templateUrl: "/app/views/newscans.html",
            controller: "NewScansController",
            controllerAs: 'vm'
        });
    }
})();