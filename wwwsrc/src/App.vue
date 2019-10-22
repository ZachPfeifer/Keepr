<template>
  <div id="app">
    <div>
      <span>
        <h1>Welcome Home {{user.username}}</h1>
        <!-- HOME/Keeps -->
        <router-link v-if="user.id" to="/">
          <button class="btn btn-light m-1">
            <i class="fas fa-user fa-sm"></i>
            Keeps
          </button>
        </router-link>

        <!-- VAULTs -->
        <router-link v-if="user.id" to="/Vaults">
          <button class="btn btn-light m-1">
            <i class="fas fa-user fa-sm"></i>
            Vaults
          </button>
        </router-link>
        <!-- LOGOUT -->
        <button v-if="user.id" class="btn btn-danger ml-2" @click="Logout()">
          <i class="fas fa-sign-out-alt fa-sm"></i>
          Logout
        </button>
        <!-- LOG-IN -->
        <router-link v-if="!user.id" to="/login">
          <button class="btn btn-light m-1">
            <i class="fas fa-user fa-sm"></i>
            Login/Register
          </button>
        </router-link>
      </span>
    </div>
    <!-- <button v-if="user.id" @click="logout">logout</button> -->
    <!-- <router-link v-else :to="{name: 'login'}">Login</router-link> -->
    <router-view />
  </div>
</template>

<script>
import NotificationService from "./NotificationService";

export default {
  name: "App",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    async Logout() {
      if (await NotificationService.confirmLogout()) {
        this.$store.dispatch("logout");
        location.reload();
      }
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>