var app = angular.module(name, ['ui.router']);
app.config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
    $urlRouterProvider.otherwise('/');
    $stateProvider
        .state('home', {
            url: '/',
            views: {
                'body': {
                    template: '<div template>we did it</div>'
                },
                'footer': {
                    template: "<div class='vCentered'>All rights reserved</div>"
                }
            }
        });
}]);
app.directive('template', function () {
    return {
        restrict: 'EA',
        transclude: true,
        template: 'template for <ng-transclude></ng-transclude>',
        controller: function ($scope, $rootScope, $timeout, $interval) {},
        link: function(scope, element, attributes) {
            $(element).append("<div id='time'></div>");
            $('#time').load("/search");
            console.log(t);
        }
    };
});

angular.bootstrap(document, [name]);