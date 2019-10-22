<template>
  <div class="vault">
    <div class="card">
      <h1 class="card-title">{{vault.name}}</h1>
      <div class="card-body">
        <h5>{{vault.description}}</h5>
      </div>
      <div class="card-footer">
        <div v-if="user.id">
          <button class="btn btn-danger" @click="Delete">Delete Vault</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  data() {
    return {};
  },
  mounted() {
    let payload = {
      vaultId: this.$route.params.vaultId
    };
    this.$store.dispatch("getVaultById", payload);
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {
    Delete() {
      this.$store.dispatch("deleteVault", this.vault.id);
    }
  },
  components: {}
};
</script>


<style scoped>
img {
  height: 500px;
}
</style>