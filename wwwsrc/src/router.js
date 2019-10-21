import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Keeps from './views/Keeps.vue'
// @ts-ignore
import Login from './views/Login.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'keeps',
      component: Keeps
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    }
  ]
})
