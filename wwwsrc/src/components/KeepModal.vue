<template>
  <div id="view-keep-modal" class="modal" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title">Full Screen!</h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <div class="card" style="width: 18rem;">
            <Keep />
          </div>
        </div>
        <div class="modal-footer">
          <button class="btn btn-danger" @click="Delete">Delete</button>
          <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import Keep from "../components/Keep.vue";

export default {
  name: "view-keep-modal",
  data() {
    return {};
  },
  mounted() {
    // let payload = {
    //   keepId: this.$route.params.keepId
    // };
    this.$store.dispatch("getKeepById", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    Delete() {
      this.$store.dispatch("deleteKeep", this.keep._id);
    }
  },
  components: { Keep }
};
</script>


<style scoped>
</style>