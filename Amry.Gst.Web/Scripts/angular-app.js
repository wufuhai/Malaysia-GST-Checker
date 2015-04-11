'use strict';

angular
    .module('gstServices', ['ngResource'])
    .factory('GstApi', ['$resource',
        function($resource) {
             return $resource('/api/:searchType/:searchText');
        }]);

angular
    .module('gstApp', ['gstServices', 'ngSanitize', 'ngAnimate', 'cgBusy'])
    .controller('GstLookupCtrl', ['$scope', 'GstApi',
        function ($scope, GstApi) {
            $scope.searchType = 'GstNo';
            $scope.searchText = '';
            $scope.promise = null;

            $scope.executeSearch = function () {
                var results = GstApi.query({
                    searchType: $scope.searchType,
                    searchText: $scope.searchText.replace(' ', '_')
                });
                $scope.results = results;

                var promise = results.$promise
                    .catch(function(e) {
                        alert(e.statusText + ': ' + e.data);
                    });
                $scope.promise = promise;
            };
        }]);