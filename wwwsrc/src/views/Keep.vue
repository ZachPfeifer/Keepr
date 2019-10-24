<template>
  <div class="view-keep">
    <div class="card">
      <h1 class="card-title">{{keep.name}}</h1>
      <div class="card-body">
        <img :src="keep.img" class="card-img-top" alt="Post" />
        <h5>{{keep.description}}</h5>
      </div>
      <div class="card-footer">
        <h5>Views: {{keep.views}}{{keep.year}}</h5>
        <!-- <h5>Shares: {{keep.shares}}</h5> -->
        <h5>Keeps: {{keep.keeps}}</h5>
        <div v-if="user.id">
          <button class="btn btn-danger" @click="Delete">Delete Keep</button>
          <!-- DROPDOWN -->
          <li
            class="btn btn-secondary dropdown-toggle"
            role="button"
            id="dropdownMenuLink"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >Save Keep</li>

          <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
            <a class="dropdown-item" disabled>Select Vault</a>
            <a
              class="dropdown-item"
              v-for="vault in vaults"
              :key="vault.id"
              :value="vault.id"
              @click="addKeeptoVault(vault.id)"
            >{{vault.name}}</a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "view-keep",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeepById", this.$route.params.keepId);
    this.$store.state.activeKeep;
    this.$store.dispatch("getVaults");
    this.$store.state.vaults;
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keep() {
      return this.$store.state.activeKeep;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    Delete() {
      this.$store.dispatch("deleteKeep", this.keep.id);
    },
    addKeeptoVault(payload) {
      debugger;
      this.$store.dispatch("addKeeptoVault", {
        userId: this.user.id,
        vaultId: payload,
        keepId: this.keep.id
      });
    }
  },
  components: {}
};
</script>


<style scoped>
img {
  height: 25%;
}
</style>