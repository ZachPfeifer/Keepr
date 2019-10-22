<template>
  <div class="keep">
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
        <button class="btn btn-danger" @click="Delete">Delete Keep</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keep",
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
    keep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    Delete() {
      this.$store.dispatch("deleteKeep", this.keep.id);
    }
  },
  components: {}
};
</script>


<style scoped>
img {
  height: 500px;
}
</style>