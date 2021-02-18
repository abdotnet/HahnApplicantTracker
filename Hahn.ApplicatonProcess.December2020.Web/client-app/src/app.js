var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { autoinject } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';
import { I18N } from 'aurelia-i18n';
var App = (function () {
    function App(i18n) {
        this.i18n = i18n;
        this.i18n.setLocale('de-DE')
            .then(function () {
            console.log('Locale is ready!');
        });
        this.message = 'Applicant Tracker';
    }
    App.prototype.configureRouter = function (config, router) {
        config.title = 'Applicant Tracker ';
        config.map([
            { route: '', name: 'home', moduleId: PLATFORM.moduleName("components/home/home"), nav: true, title: 'Home' },
            { route: 'applicant', name: 'applicant', moduleId: PLATFORM.moduleName("components/applicant/applicant"), nav: true, title: 'Applicant Page' },
            { route: 'applicantview/:id', name: 'applicantview', moduleId: PLATFORM.moduleName("components/applicantview/applicantview"), title: 'Applicant View Page' }
        ]);
    };
    App = __decorate([
        autoinject,
        __metadata("design:paramtypes", [I18N])
    ], App);
    return App;
}());
export { App };
//# sourceMappingURL=app.js.map