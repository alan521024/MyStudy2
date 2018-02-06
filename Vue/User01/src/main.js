// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.

import Merge from 'webpack-merge'
import Vue from 'vue'
import router from './router'
import accountView from './view/Account'
import AccountService from './service/AccountService'
import UserView from './view/User'

const getSetting = (() => {
  return Merge({
    el: '#app',
    router
  }, {
      components: AccountService.checkLogin() ? { accountView } : { UserView },
      template: AccountService.checkLogin() ? '<accountView/>' : '<UserView/>'
    });
});

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue(getSetting())