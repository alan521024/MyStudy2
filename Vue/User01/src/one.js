import Vue from 'vue'
import One from './two'

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#one',
  components: { One },
  template: '<One/>'
})
