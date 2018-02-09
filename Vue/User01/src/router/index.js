import Vue from 'vue'
import Router from 'vue-router'
import core from '../service/core'

Vue.use(Router)

const router = new Router({
  routes: [
    // {
    //   path: '/'
    // }
  ]
})

router.beforeEach((next) => {
  router.app.$nextTick(function () {
    if (!router.app.isAccount) {
      if (core.IsLogin()) {
        window.top.location.href = '/user.html'
      } else {
        window.top.location.href = '/account.html'
      }
    }
  })
  next()
})

export default router
