(function () {
    angular.module('app').controller('indexController', ['$scope','$resource','$log', function ($scope, $resource, $log) {
        $scope.title = 'Welcome!';
        $scope.students = [];
        $scope.courses = [];
        $scope.values = [];

        var studentResource = $resource('api/students?testing=:id', {
            id: '@id'
        });

        var courseResource = $resource('api/course?testing=:id', {
            id: '@id'
        });

        var valuesResource = $resource('api/values?testing=:id', {
            id: '@id'
        });
        //var resource = $resource('api/students', {}, { query: { method: 'GET', isArray: true, headers: { 'If-None-Match': "\"51ab6e3c36d84633af5edf6dde35ca1b\"" } } });

        studentResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.students = result;
        });

        courseResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.courses = result;
        });

        valuesResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.values = result;
        });

        studentResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.students = result;
        });

        courseResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.courses = result;
        });

        studentResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.students = result;
        });

        courseResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.courses = result;
        });

        studentResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.students = result;
        });

        courseResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.courses = result;
        });

        studentResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.students = result;
        });

        valuesResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.values = result;
        });

        courseResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.courses = result;
        });

        studentResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.students = result;
        });

        courseResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.courses = result;
        });

        studentResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.students = result;
        });

        courseResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.courses = result;
        });

        studentResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.students = result;
        });

        courseResource.query({ id: 1 }).$promise.then(function (result) {
            $scope.courses = result;
        });
    }]);
})();