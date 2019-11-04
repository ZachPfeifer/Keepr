<template>
  <div class="dashboard container-fluid">
    <!-- Add Keep Modal -->
    <AddKeepModal />
    <button
      v-if="user.id"
      @click="addKeep()"
      data-toggle="modal"
      data-target="#create-keep-modal"
    >Create Keep</button>

    <div>
      <!--All Keeps -->
      <!-- <ViewKeepModal /> -->
      <div class="row" v-if="!user.id">
        <Keep v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
      </div>
      <div v-else>
        <KeepPrivate class="col" v-for="keep in keeps" :keepProp="keep" :key="keep.id" />
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep.vue";
import KeepPrivate from "../components/KeepPrivate";
import AddKeepModal from "../components/AddKeepModal.vue";
// import ViewKeepModal from "../components/KeepModal.vue";

export default {
  name: "dashboard",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.state.keeps;
    this.$store.dispatch("getKeepById");
    this.$store.state.vaults;
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
  components: { Keep, AddKeepModal, KeepPrivate } //, ViewKeepModal }
};
</script>