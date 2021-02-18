
import {autoinject} from "aurelia-framework";
import {DialogController} from 'aurelia-dialog';

@autoinject
export class Dialog {

    constructor(public controller: DialogController) {
      
    }
    message ="";
    activate(data:string):void {
        this.message = data;
    }
}
