//B5
/// <reference path="/Assets/admin/libs/angular/angular.js" />

//(function (app) {

//    app.controller('productCategoryListController', productCategoryListController);

//    productCategoryListController.$inject = ['$scope', 'apiService'];

//    function productCategoryListController($scope, apiService) {

//        $scope.productCategories = [];

//        $scope.getProductCategories = getProductCategories;

//        function getProductCategories() {

//            apiService.get('/api/productcategory/getall', null, function (result) {
//                $scope.productCategories = result.data;

//            }, function () {
//                console.log('Load productcategory failed.');
//            });
//        }

//        $scope.getProductCategories();//goi cho no chay controller
//    }

//})(angular.module('tedushop.product_categories'));

// sau khi dung phan trang
(function (app) {

    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCategoryListController($scope, apiService, notificationService) {

        $scope.productCategories = [];

        //phan trang
        $scope.page = 0;
        $scope.pageCounts = 0;//het
        
        $scope.getProductCategories = getProductCategories;
        //bai 26 - tim kiem
        $scope.keywork = '';
        $scope.serch = serch;
        function serch() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            //phan trang
            var config = {
                params: {
                    keywork: $scope.keywork,
                    page: page,
                    pageSize: 6 // dung de chinh sua phan trang
                }
            }//het

            apiService.get('/api/productcategory/getall', config, function (result) {

                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản nghi nào');
                } else {
                    notificationService.displaySuccess('Đã tìm thấy thông tin bản nghi');
                }

                $scope.productCategories = result.data.Items;

                //phan trang
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;  //het
              

            }, function () {
                console.log('Load productcategory failed.');
            });
        }

        $scope.getProductCategories();//goi cho no chay controller
    }

})(angular.module('tedushop.product_categories'));