(function () {
    angular.module('app').config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
            templateUrl: '/Scripts/views/index.html',
            controller: 'indexController'
        })

        .otherwise({ redirectTo: "/" });
    }]);
})();