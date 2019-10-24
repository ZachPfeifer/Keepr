import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Dashboard from './views/Dashboard.vue'
// @ts-ignore
import Vaults from './views/Vaults.vue'
// @ts-ignore
// import VaultKeeps from './views/VaultKeeps.vue'

// @ts-ignore
// @ts-ignore
import Keep from './views/Keep.vue'
// @ts-ignore
// @ts-ignore
import ViewKeep from './components/KeepModal.vue'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: Dashboard
    },
    // {
    //   path: '/keeps',
    //   name: 'keeps',
    //   component: Keep
    // },
    {
      path: '/keeps/:keepId',
      name: 'keep',
      // component: Keep
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: function () {
        // @ts-ignore
        return import(/* webpackChunkName: "dashboard" */ './views/Keep.vue')
      }
    },

    // Vaults
    {
      path: '/vaults',
      name: 'vaults',
      component: Vaults
    },
    {
      path: '/vaults/:vaultId',
      name: 'vault',
      component: function () {
        // @ts-ignore
        return import(/* webpackChunkName: "vault" */ './views/Vault.vue')
      }
    },

    //Vault Keep
    // {
    //   path: '/vaultkeeps',
    //   name: 'vaultKeeps',
    //   component: VaultKeeps
    // },
    // {
    //   path: '/vaults/:vaultId',
    //   name: 'vault',
    //   component: function () {
    //     // @ts-ignore
    //     return import(/* webpackChunkName: "vault" */ './views/VaultKeep.vue')
    //   }
    // },


    //LOGIN
    {
      path: '/login',
      name: 'login',
      component: Login
    },
  ]
})
