<template>
  <div class="keeps container-fluid">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <AddKeepModal />
    <button v-if="user.id" @click="addKeep">Create Keep</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>

    <div class="row">
      <Keep class="col" v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep.vue";
import AddKeepModal from "../components/AddKeepModel.vue";

export default {
  name: "keeps",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },

    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: { Keep, AddKeepModal }
};
</script>