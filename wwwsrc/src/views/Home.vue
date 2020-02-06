<template>
  <div class="home">
    <h1>Welcome Home</h1>
    {{ teams }}
  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getAllTeams");
  },
  computed: {
    teams() {
      return this.$store.state.teams;
    }
  },
  methods: {}
};
</script>
