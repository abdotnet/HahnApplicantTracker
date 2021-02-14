import { PLATFORM } from 'aurelia-pal';
// import {home} from './components/home/home';
// import routes from 'router'
import {RouterConfiguration, Router} from 'aurelia-router';
export class App {

  message:string ;

  constructor()
  {
    this.message = 'Applicant Tracker';
  }
 
  configureRouter(config, router)
  {
    config.title ='Product Tracker App';
    config.map([
      {route:'',name:'home',moduleId:PLATFORM.moduleName("components/home/home"),nav: true ,title:'Home'},
      {route:'applicant',name:'applicant',moduleId:PLATFORM.moduleName("components/applicant/applicant"),nav: true,title:'Applicant Page'},
      {route:'applicantview/:id',name:'applicantview',moduleId:PLATFORM.moduleName("components/applicantview/applicantview"),title:'Applicant View Page'}
    ]);
  }


}
