// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import nav from '../../components/nav'
import router from '../../router'

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app-account',
  data () {
    return {
      isAccount: true
    }
  },
  router,
  components: {
    'layout-nav': nav
  }
})
