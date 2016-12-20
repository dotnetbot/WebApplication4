(function(){
    angular.module('oergjw', [
        'ui.bootstrap',
        'toaster',
        'ui.router',
        'ui.mask',
        'chieffancypants.loadingBar',
        'ncy-angular-breadcrumb',
        'angularFileUpload',
        'LocalStorageModule',
        'angular-underscore',
        'oergjw.config',
        'oergjw.routes',
        'oergjw.authentication',
        'oergjw.layout',
        'oergjw.persons',
        'oergjw.claims'
    ]);

    angular.module('oergjw.config', []);
    angular
        .module('oergjw.routes', []);

    angular
        .module('oergjw')
        .directive('fancybox', function ($compile, $parse) {
            return {
                restrict: 'C',
                replace: false,
                link: function ($scope, element, attrs) {
                    $scope.$watch(function () { return element.attr('openbox'); }, function (openbox) {
                        if (openbox == 'show') {
                            var options = $parse(attrs.options)($scope) || {};
                            if (!options.href && !options.content) {
                                options.content = angular.element(element.html());
                                $compile(options.content)($scope);
                            }

                            options.afterClose = function () {
                                $scope.$apply(function () {
                                    element.attr('openbox', 'hide');
                                });
                            };

                            $.fancybox(options);
                        }
                    });
                }
            };
        })
        .constant('ngAuthSettings', {
            apiServiceBaseUri: 'http://localhost:63223/',
            clientId: 'ngAuthApp',
            debug: true
        })
        .run(run);

    run.$inject = ['$rootScope', '$location', 'authenticationService'];

    function run($rootScope, $location, authenticationService) {
        authenticationService.fillAuthData();

        $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
            if (!authenticationService.authentication.isAuth) {
                $location.path('/login');
            }
        });
    }
})();