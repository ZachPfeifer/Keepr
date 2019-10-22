<template>
  <div class="keeps container-fluid">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <!-- Add Keep Modal -->
    <AddKeepModal />
    <button
      v-if="user.id"
      @click="addKeep()"
      data-toggle="modal"
      data-target="#create-keep-modal"
    >Create Keep</button>

    <div class="row">
      <!--All Keeps -->
      <!-- <ViewKeepModal /> -->
      <Keep class="col" v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep.vue";
import AddKeepModal from "../components/AddKeepModal.vue";
// import ViewKeepModal from "../components/KeepModal.vue";

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
    },
    addKeep() {
      this.$store.dispatch("addKeep");
    }
  },
  components: { Keep, AddKeepModal } //, ViewKeepModal }
};
</script>