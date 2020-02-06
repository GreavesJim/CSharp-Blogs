<template>
  <div class="home">
    <h1>Welcome Home</h1>

    {{ blogs }}
  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getAllBlogs");
  },
  computed: {
    blogs() {
      return this.$store.state.blogs;
    }
  },
  methods: {}
};
</script>
