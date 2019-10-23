<template>
  <div class="vaultKeep col-3 border rounded" @click="viewKeep()">
    <div class="card" style="width: 18rem;">
      <img :src="keepProp.img" class="card-img-top" alt="Post" />
      <div class="card-body">
        <p class="card-text">
          Name: {{keepProp.name}}
          Description: {{keepProp.description}}
          Views: {{keepProp.views}}
          <!-- Shares: {{keepProp.shares}} -->
          VaultKeeps: {{keepProp.vaultKeeps}}
        </p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "vaultKeep",
  props: ["keepProp"],
  data() {
    return {};
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {
    viewKeep() {
      this.$store.dispatch("getKeepById", this.keepProp.id);
      // //NOTE better way to navigate programatically
      this.$router.push({
        name: "keep",
        params: { keepId: this.keepProp.id }
      });
      // //NOTE The OTHER way...
      // this.$router.push("/keeps/" + this.keepProp.id);
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