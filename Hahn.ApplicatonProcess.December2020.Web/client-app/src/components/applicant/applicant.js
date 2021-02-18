var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { ApplicantModel } from './../../models/applicantmodel';
import { DialogService } from 'aurelia-dialog';
import { autoinject, inject, bindable, NewInstance, observable } from "aurelia-framework";
import { Dialog } from "../../audialog/dialog";
import { ValidationController, ValidationRules } from 'aurelia-validation';
var Applicant = (function () {
    function Applicant(controller, dlg) {
        this.controller = controller;
        this.dlg = dlg;
        this.action = function () { };
        this.msg = "Are you sure";
        this.appForm = new ApplicantModel();
    }
    Applicant.prototype.bind = function () {
        ValidationRules
            .ensure("FamilyName").required().minLength(5)
            .ensure("Name").required().minLength(5)
            .ensure("Address").required().minLength(10)
            .ensure("CountryOfOrigin").required()
            .ensure("Age").required().min(21).max(59)
            .on(this.appForm);
        return;
    };
    Applicant.prototype.reset = function () {
        var _this = this;
        console.log(this.dlg);
        this.dlg.open({ viewModel: Dialog, model: this.msg }).then(function (result) {
            if (result.wasCancelled)
                return;
            _this.action();
        });
    };
    Applicant.prototype.submit = function () {
        return;
    };
    __decorate([
        bindable,
        __metadata("design:type", Object)
    ], Applicant.prototype, "action", void 0);
    __decorate([
        bindable,
        __metadata("design:type", Object)
    ], Applicant.prototype, "msg", void 0);
    __decorate([
        bindable,
        observable,
        __metadata("design:type", ApplicantModel)
    ], Applicant.prototype, "appForm", void 0);
    Applicant = __decorate([
        inject(NewInstance.of(ValidationController)),
        autoinject,
        __metadata("design:paramtypes", [ValidationController, DialogService])
    ], Applicant);
    return Applicant;
}());
export { Applicant };
//# sourceMappingURL=applicant.js.map