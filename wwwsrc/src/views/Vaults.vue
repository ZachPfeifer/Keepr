<template>
  <div class="vaults container-fluid">
    <!-- Add Vault Modal -->
    <AddVaultModal />
    <button
      v-if="user.id"
      @click="addVault()"
      data-toggle="modal"
      data-target="#create-vault-modal"
    >Create Vault</button>

    <div class="row">
      <!--All Vaults -->
      <!-- <ViewVaultModal /> -->
      <Vault class="col" v-for="vault in vaults" :vaultProp="vault" :key="vault.id" />
    </div>
  </div>
</template>

<script>
import Vault from "../components/Vault.vue";
import AddVaultModal from "../components/AddVaultModal.vue";
// import ViewVaultModal from "../components/VaultModal.vue";

export default {
  name: "vaults",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
    this.$store.state.vaults;
  },
  computed: {
    user() {
      return this.$store.state.user;
    },

    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    addVault() {
      this.$store.dispatch("addVault");
    }
  },
  components: { Vault, AddVaultModal } //, ViewVaultModal }
};
</script>