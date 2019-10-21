import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vault: [],
    vaultKeep: []
  },
  mutations: {
    //Account
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },

    //Keeps
    setKeeps(state, payload) {
      state.keeps = payload
    }

  },
  actions: {

    //#region -- ACCOUNT --
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    //#endregion

    //#region -- KEEPS --
    async getKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async getKeepById({ commit, dispatch }, payload) {
      try {
        let res = await api.get(`/keeps/${payload}`)
        commit('setActiveKeep', res.data)
        router.push({ name: "keep" })

      } catch (error) {
        console.error(error)

      }
    },
    async addKeep({ dispatch }, payload) {
      try {
        let res = await api.post('/keeps/', payload)
        dispatch('getKeeps')

      } catch (error) {
        console.error(error)

      }
    },

    //#endregion
  }
})
