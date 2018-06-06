﻿//B5
/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function (app) {

    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService'];

    function productCategoryListController($scope, apiService) {

        $scope.productCategories = [];

        $scope.getProductCategories = getProductCategories;

        function getProductCategories() {

            apiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCategories = result.data;

            }, function () {
                console.log('Load productcategory failed.');
            });
        }

        $scope.getProductCategories();//goi cho no chay controller
    }

})(angular.module('tedushop.product_categories'));