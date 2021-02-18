import { autoinject } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';
import {I18N} from 'aurelia-i18n';
// import {home} from './components/home/home';
// import routes from 'router'
import {RouterConfiguration, Router} from 'aurelia-router';

@autoinject
export class App {

  message:string ;
 
  constructor(private i18n : I18N)
  {
    this.i18n.setLocale('de-DE')
    .then( () => {
       console.log('Locale is ready!');
    });

    this.message = 'Applicant Tracker';
  }
 
  configureRouter(config : RouterConfiguration, router : Router) :void
  {
    config.title ='Applicant Tracker ';
    config.map([
      {route:'',name:'home',moduleId:PLATFORM.moduleName("components/home/home"),nav: true ,title:'Home'},
      {route:'applicant',name:'applicant',moduleId:PLATFORM.moduleName("components/applicant/applicant"),nav: true,title:'Applicant Page'},
      {route:'applicantview/:id',name:'applicantview',moduleId:PLATFORM.moduleName("components/applicantview/applicantview"),title:'Applicant View Page'}
    ]);
  }


}
