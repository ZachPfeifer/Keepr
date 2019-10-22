<template>
  <div id="create-vault-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create A Vault!</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addVault()">
            <div class="form-group">
              <label for="name">Name</label>
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Enter name"
                v-model="newVault.name"
                required
              />
            </div>
            <div class="form-group">
              <label for="description">Description</label>
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Enter description"
                v-model="newVault.description"
              />
            </div>
            <button type="submit" class="btn btn-primary">Add Vault</button>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "create-vault-modal",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {},
  methods: {
    addVault() {
      this.$store.dispatch("addVault", this.newVault);
      $("#close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
</style>