<template>
  <div class="vault">
    <div class="card">
      <div class="card-title">
        <p>{{vault.id}}</p>
        <h1>{{vault.name}}</h1>
        <h5>{{vault.description}}</h5>
      </div>
      <div class="card-body">
        <VaultKeep class="col" v-for="keep in vaultKeep" :keepProp="keep" :key="keep.id" />
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
import VaultKeep from "../components/VaultKeep.vue";

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

    this.$store.dispatch("getVaultKeepByVaultId", this.$route.params.vaultId);
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vault() {
      return this.$store.state.activeVault;
    },
    vaultKeep() {
      return this.$store.state.vaultKeeps;
    }
  },
  methods: {
    Delete() {
      this.$store.dispatch("deleteVault", this.vault.id);
    }
  },
  components: { VaultKeep }
};
</script>


<style scoped>
img {
  height: 500px;
}
</style>