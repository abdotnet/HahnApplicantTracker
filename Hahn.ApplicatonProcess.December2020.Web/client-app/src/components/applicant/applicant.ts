import { ApplicantModel } from './../../models/applicantmodel';
import {DialogService} from 'aurelia-dialog';
import {Prompt} from '../../audialog/prompt';
import { autoinject,inject,bindable ,NewInstance ,observable} from "aurelia-framework";
import { Dialog } from "../../audialog/dialog";
import { ValidationController, ValidationRules,validateTrigger } from 'aurelia-validation';


@inject(NewInstance.of(ValidationController))
@autoinject
export class Applicant {

  @bindable
  action=()=>{};

    @bindable
    msg = "Are you sure";

    @bindable @observable
   public appForm  : ApplicantModel = new ApplicantModel();

    constructor(private  controller: ValidationController, private dlg:DialogService) {
    }

    public bind() :void{
      ValidationRules
        .ensure("FamilyName").required().minLength(5)
        .ensure("Name").required().minLength(5)
        .ensure("Address").required().minLength(10)
        .ensure("CountryOfOrigin").required()
        .ensure("Age").required().min(21).max(59)
        .on(this.appForm);
        return;
    }

    reset() : void {
     console.log(this.dlg);
     this.dlg.open({ viewModel: Dialog, model: this.msg }).then(result => {
     if (result.wasCancelled) 
     return;
    this.action();
});

 }

public submit():void{

  return;
 }

}
