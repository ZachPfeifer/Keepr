<template>
  <div class="vault col-3 border rounded" @click="viewVault()">
    <div class="card" style="width: 18rem;">
      <div class="card-header">
        <h1>Name: {{vaultProp.name}}</h1>
      </div>
      <div class="card-body">
        <p class="card-text">Description: {{vaultProp.description}}</p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vault",
  props: ["vaultProp"],
  data() {
    return {};
  },
  computed: {},
  methods: {
    viewVault() {
      this.$store.dispatch("getVaultById", this.vaultProp.id);
      // //NOTE better way to navigate programatically
      this.$router.push({
        name: "vault",
        params: { vaultId: this.vaultProp.id }
      });
      // //NOTE The OTHER way...
      // this.$router.push("/vaults/" + this.vaultProp.id);
    }
  },
  components: {}
};
</script>


<style scoped>
.bg-grey {
  background-color: darkgray;
}
</style>