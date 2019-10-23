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
          <!-- <button class="btn btn-danger" @click="AddToVault">Save Keep</button> -->

          <!-- TEST DROPDOWN
          <div class="dropdown">
            <a
              class="btn btn-secondary dropdown-toggle"
              role="button"
              id="dropdownMenuLink"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >Save Keep</a>

            <div class="dropdown-menu" aria-labelledby="dropdownMenuLink" v-model="selectedVault">
              <a class="dropdown-item">Select Vault</a>
              <a
                class="dropdown-item"
                v-for="vault in vaults"
                :key="vault.id"
                :value="vault.id"
                @click="AddToVault()"
              >{{vault.name}}</a>
              <a class="dropdown-item" href="#">{{vault.name}}</a>
            </div>
          </div>
          END OF TEST-->
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
    let payload = {
      keepId: this.$route.params.keepId
    };
    this.$store.dispatch("getKeepById", payload);
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keep() {
      return this.$store.state.activeKeep;
    },
    vault() {
      return this.$store.state.vault;
    }
  },
  methods: {
    Delete() {
      this.$store.dispatch("deleteKeep", this.keep.id);
    },
    AddToVault() {
      this.$store.dispatch("addKeeptoVault", {
        this.keep.id,
         this.vault.id});
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