<template>
  <div class="keep col-3 border rounded" v-if="keepProp.isPrivate == false">
    <div class="card" style="width: 18rem;">
      <img :src="keepProp.img" class="card-img-top" alt="Post" />

      <div class="card-body">
        <div class="card-text">
          <h5>
            <hr />
            Name: {{keepProp.name}}
            <hr />
            Description: {{keepProp.description}}
          </h5>
          <hr />
          Views: {{keepProp.views}}
          <!-- Shares: {{keepProp.shares}} -->
          Keeps: {{keepProp.keeps}}
        </div>
        <div class="card-footer">
          <span>
            <button class="btn btn-dark" @click="viewKeep()">View</button>
          </span>

          <!--FIXME TEST DROPDOWN -->
          <div class="dropdown">
            <a
              class="btn btn-secondary dropdown-toggle"
              role="button"
              id="dropdownMenuLink"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >Save Keep</a>

            <div class="dropdown-menu" aria-labelledby="dropdownMenuLink">
              <a class="dropdown-item" href="#">Select Vault</a>
              <a
                class="dropdown-item"
                v-for="vault in vaults"
                :key="vault.id"
                :value="vault.id"
                @click="AddToVault()"
              >{{vault.name}}</a>
              <!-- <a class="dropdown-item" href="#">{{vault.name}}</a> -->
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep",
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
    },
    addKeeptoVault() {
      this.$store.dispatch("addKeeptoVault", {
        vaultId: this.selectedVault,
        keepId: this.keepProp.id
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