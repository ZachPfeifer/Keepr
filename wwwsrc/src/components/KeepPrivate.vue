<template>
  <div class="keepPrivate col-3 border rounded">
    <!-- //FIXME -->
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
          Shares: {{keepProp.shares}}
          Keeps: {{keepProp.keeps}}
          TESTING USERID:
          UserId: {{keepProp.userId}}
        </div>
        <div class="card-footer">
          <span>
            <button class="btn btn-dark" @click="viewKeep()">View</button>

            <!--FIXME TEST DROPDOWN -->
            <div class="dropdown" v-if="user.id">
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
          </span>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keepPrivate",
  props: ["keepProp"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("GetUsersKeeps"); //FIXME
    this.$store.state.vaults;
    this.$store.dispatch("getVaults");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    activeVault() {
      return this.$store.state.activeVault;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    viewKeep() {
      // debugger;
      this.$store.dispatch("getKeepById", this.keepProp.id);
      this.$store.dispatch("ViewCount", {
        Views: (this.keepProp.views += 1),
        Shares: this.keepProp.shares,
        Keeps: this.keepProp.keeps,
        // isPrivate: this.keepProp.isPrivate,
        Id: this.keepProp.id
      });
      // //NOTE better way to navigate programatically
      this.$router.push({
        name: "keep",
        params: { keepId: this.keepProp.id }
      });
    },
    addKeeptoVault(payload) {
      this.$store.dispatch("addKeeptoVault", {
        userId: this.user.id,
        vaultId: payload,
        keepId: this.keepProp.id
      });
      this.$store.dispatch("ViewCount", {
        Views: this.keepProp.views,
        Shares: this.keepProp.shares,
        Keeps: (this.keepProp.keeps += 1),
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