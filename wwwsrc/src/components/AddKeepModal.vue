<template>
  <div id="create-keep-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Create A Keep!</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="addKeep()">
            <div class="form-group">
              <label for="name">Name</label>
              <input
                type="text"
                class="form-control"
                id="name"
                placeholder="Enter name"
                v-model="newKeep.name"
                required
              />
              <div class="form-group">
                <label for="img">Image Url</label>
                <input
                  type="text"
                  class="form-control"
                  id="img"
                  placeholder="Enter imgurl"
                  v-model="newKeep.img"
                />
              </div>
            </div>
            <div class="form-group">
              <label for="description">Description</label>
              <input
                type="text"
                class="form-control"
                id="description"
                placeholder="Enter description"
                v-model="newKeep.description"
              />
            </div>
            <div class="form-group">
              <span>
                <label for="isPrivate">Show:</label>
                <input
                  type="checkbox"
                  value="isPrivate"
                  class="form-control"
                  id="isPrivate"
                  v-model="newKeep.isPrivate"
                /> Private
              </span>
            </div>
            <button type="submit" class="btn btn-primary">Add Keep</button>
          </form>
        </div>
        <div class="modal-footer">
          <button id="close" type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "create-keep-modal",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {},
  methods: {
    addKeep() {
      this.$store.dispatch("addKeep", this.newKeep);
      // this.newKeep = {};
      $("#close").click();
    }
  },
  components: {}
};
</script>


<style scoped>
</style>