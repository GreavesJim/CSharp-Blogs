<template>
  <div class="dashboard">
    <h1>Welcome to the dashboard</h1>

    <form @submit.prevent="createBlog">
      <input type="text" placeholder="Title" v-model="newBlog.title" />
      <textarea placeholder="Body" v-model="newBlog.body"> </textarea>
      <button type="submit" class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "Dashboard",
  data() {
    return {
      newBlog: {
        title: "",
        body: ""
      }
    };
  },
  methods: {
    createBlog() {
      let blog = { ...this.newBlog };
      this.$store.dispatch("createBlog", blog);
      this.newBlog.title = "";
      this.newBlog.body = "";
    }
  }
};
</script>

<style></style>
