<template>
  <div id="app">
    <div class="BG container-fluid">
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
  color: #305880;
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
.BG {
  background-color: white;
  background-image: url(https://cdn2.vectorstock.com/i/1000x1000/51/66/metal-background-polished-chrome-surface-vector-7815166.jpg);
  box-shadow: 10px 10px;
  border-radius: 0px 0px 25px 25px;
  background-position: left top;
  background-repeat: repeat;
  padding: 20px;
  width: 100%;
  height: 100%;
}
/* TITLE */
h1 {
  color: white;
  text-shadow: 2px 2px 4px #000000;
}
</style>