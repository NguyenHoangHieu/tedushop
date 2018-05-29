/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module("myModel", []);

myApp.controller("myController", myController);

myApp.service("Click_Event", Click_Event); //b2: khai bao su kien

myController.$inject = ['$scope', 'Click_Event'];//b3: goi

function myController($scope, Click_Event) {//b4 thuc thi dung controller goi ham`
    //Click_Event.CheckNume(2);
    $scope.CheckNume111 = function () {
        $scope.message1 = Click_Event.CheckNume(2);
    }
}

function Click_Event($window) { //b1: tao 1 su kien
    return {
        CheckNume: CheckNume
    }
    function CheckNume(value) {
        if (value % 2 == 0) {
            //$window.alert("so " + value + " chia het cho 2");
            return 'so chia het cho 2';
        } else {
            //$window.alert("so " + value + " khong chia het cho 2");
            return 'so khong chia het cho 2';
        }
    }
}


