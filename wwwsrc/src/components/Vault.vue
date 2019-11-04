<template>
  <div class="vault col-3 border rounded" @click="viewVault()">
    <div class="card" style="width: 18rem;">
      <div class="card-header">
        <h1>{{vaultProp.name}}</h1>
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
  mounted() {
    this.$store.state.activeVault;
  },
  computed: {},
  methods: {
    viewVault() {
      this.$store.dispatch("getVaultById", this.vaultProp.id);
      this.$router.push({
        name: "vault",
        params: { vaultId: this.vaultProp.id }
      });
      this.$store.dispatch("ViewCount", {
        Views: (this.keepProp.views += 1),
        Shares: this.keepProp.shares,
        Keeps: this.keepProp.keeps,
        // isPrivate: this.keepProp.isPrivate,
        Id: this.keepProp.id
      });
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