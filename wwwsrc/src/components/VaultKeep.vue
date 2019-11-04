<template>
  <div class="vaultKeep col-3 border rounded">
    <div class="card" style="width: 18rem;">
      <img :src="keepProp.img" class="card-img-top" alt="Post" />
      <div class="card-body">
        <p class="card-text">
          Name: {{keepProp.name}}
          Description: {{keepProp.description}}
          Views: {{keepProp.views}}
          <!-- Shares: {{keepProp.shares}} -->
          Keeps: {{keepProp.keeps}}
        </p>
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
            <!-- DELETE FROM VAULT -->
            <button class="btn btn-danger" @click="DeleteFromVault()">Delete from Vault</button>
          </span>
        </div>
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
  mounted() {
    this.$store.state.vaultKeeps;
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vault() {
      return this.$store.state.activeVault;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    viewKeep() {
      this.$store.dispatch("getKeepById", this.keepProp.id);
      this.$store.dispatch("ViewCount", {
        Views: (this.keepProp.views += 1),
        Shares: this.keepProp.shares,
        Keeps: this.keepProp.keeps,
        // isPrivate: this.keepProp.isPrivate,
        Id: this.keepProp.id
      });
      this.$router.push({
        name: "keep",
        params: { keepId: this.keepProp.id }
      });
    },
    DeleteFromVault() {
      this.$store.dispatch("deleteKeepFromVault", {
        vaultId: this.vault.id,
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