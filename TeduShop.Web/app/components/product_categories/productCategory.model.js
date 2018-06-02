
/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('tedushop.product_categories', ['tedushop.common']).config(config);//b3

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        });
    }
})();