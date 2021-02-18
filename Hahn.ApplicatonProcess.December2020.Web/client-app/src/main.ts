import {Aurelia} from 'aurelia-framework';
import * as environment from '../config/environment.json';
import {PLATFORM} from 'aurelia-pal';
import XHR from 'i18next-xhr-backend';

export function configure(aurelia: Aurelia): void {
  aurelia.use
    .standardConfiguration()
    .feature(PLATFORM.moduleName('resources/index'));

  aurelia.use.developmentLogging(environment.debug ? 'debug' : 'warn');

  aurelia.use.plugin(PLATFORM.moduleName('aurelia-dialog'), config =>{
    config.useDefaults();
    config.settings.lock = true;
    config.settings.centerHorizontalOnly = false;
    config.settings.startingZIndex = 5;
    config.settings.keyboard = true;
  });

  aurelia.use.plugin(PLATFORM.moduleName('aurelia-i18n'), (instance) => {
    // register backend plugin
    instance.i18next.use(XHR);

    instance.setup({
       backend: {                                  
          loadPath: '/locales/{{lng}}/{{ns}}.json',
       },
       lng : 'de',
       attributes : ['t','i18n'],
       fallbackLng : 'en',
       debug : false
    });
 });

 aurelia.use.plugin( PLATFORM.moduleName('aurelia-validation'))
  .plugin( PLATFORM.moduleName('aurelia-validatejs'));

  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
  }
  if (environment.debug) {
    aurelia.use.developmentLogging();
  }

  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}
