<template>
  <div class="keep col-3 border rounded" @click="viewKeep()" v-if="keepProp.isPrivate == false">
    <div class="card" style="width: 18rem;">
      <img :src="keepProp.img" class="card-img-top" alt="Post" />
      <div class="card-body">
        <p class="card-text">
          Name: {{keepProp.name}}
          Description: {{keepProp.desription}}
          {{keepProp.views}}
          {{keepProp.shares}}
          {{keepProp.keeps}}
        </p>
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
  computed: {},
  methods: {
    viewKeep() {
      this.$store.dispatch("getKeepById", this.keepProp.id);
      // //NOTE better way to navigate programatically
      // this.$router.push({
      //   name: "keep",
      //   params: { keepId: this.keepProp.id }
      // });
      // //NOTE The OTHER way...
      //   this.$router.push("/keeps/" + this.keepProp._id);
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