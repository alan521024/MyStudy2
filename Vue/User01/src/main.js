// The vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import merge from 'webpack-merge'
import vue from 'vue'
import router from './router'
import accountView from './view/Account'
import accountService from './service/accountService'
import userView from './view/User'

function getSetting(){
  let isLogin = accountService.checkLogin();
  return merge({
    el: '#app',
    router,
    components: { accountView, userView },
  }, {
      template: isLogin ? '<accountView/>' : '<userView/>'
    });
};

vue.config.productionTip = false

/* eslint-disable no-new */
new vue(getSetting())