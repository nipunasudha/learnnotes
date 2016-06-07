@use formatting 'Javascript'
@Theme Bespin


Angular Notes

################## PART 1 #################################
My first app
	1)First create a module.
	--------var myApp=angular.module('myApp',[]);
	2)Then add app 'directive' to the html
	--------<html ng-app="myApp">
	3) Create 'controller' ---> it manages app DATA
	--------myApp.controller('mainController',['$scope',function($scope){
				$scope.getname="Hello World";
			}])
	4) set directive for the controller
	--------<div class="" ng-controller="mainController">
	5) and use the 'expression' {{ title }} to access the data from the controller.
	in laravel please use @{{}} convension, to avoid conflicts.
	--------<h1>{{getname}}</h1>

Angular filters
	{{varItemCost | currency}}
	currency
	date
	uppercase
	lowercase
	number
	limitTo
	orderBy
	
Let's do a quick review:
	A 'module' contains the different components of an AngularJS app
	A 'controller' manages the app's data
	An 'expression' displays values on the page
	A 'filter' formats the value of an expression
	
Attaching events & functions
1) in the controller, create a new property, a function.
		$scope.plusOne=function($index){
			$scope.products[$index]++;
		}
2) in the view, create an event
		<p class="likes" ng-click="plusOne($index)">{{product.likes}}</p> 


Summary

	1)A user visits the AngularJS app.
	2)The view presents the app's data through the use of expressions, 
		filters, and directives. Directives bind new behavior HTML elements.
	3)A user clicks an element in the view. If the element has a directive, 
		AngularJS runs the function.
	4)The function in the controller updates the state of the data.
	5)The view automatically changes and displays the updated data. 
		The page doesn't need to reload at any point.

################## PART 2 #################################






















