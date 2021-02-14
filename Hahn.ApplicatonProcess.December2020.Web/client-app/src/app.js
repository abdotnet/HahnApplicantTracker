import { PLATFORM } from 'aurelia-pal';
var App = (function () {
    function App() {
        this.message = 'Applicant Tracker';
    }
    App.prototype.configureRouter = function (config, router) {
        config.title = 'Product Tracker App';
        config.map([
            { route: '', name: 'home', moduleId: PLATFORM.moduleName("components/home/home"), nav: true, title: 'Home' },
            { route: 'applicant', name: 'applicant', moduleId: PLATFORM.moduleName("components/applicant/applicant"), nav: true, title: 'Applicant Page' },
            { route: 'applicantview/:id', name: 'applicantview', moduleId: PLATFORM.moduleName("components/applicantview/applicantview"), title: 'Applicant View Page' }
        ]);
    };
    return App;
}());
export { App };
//# sourceMappingURL=app.js.map