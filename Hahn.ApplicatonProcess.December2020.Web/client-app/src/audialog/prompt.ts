import {DialogController} from 'aurelia-dialog';
import { autoinject, inject } from 'aurelia-framework';

@autoinject
export class Prompt {
  answer : string = null;
  message : string ;
   constructor(private controller : DialogController) {
      this.controller = controller;
      this.answer = null;

     // controller.settings.centerHorizontalOnly = true;
   }
   activate(message : string) : void {
      this.message = message;
   }
}
