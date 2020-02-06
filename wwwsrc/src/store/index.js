import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    blogs: []
  },
  mutations: {
    setBlogs(state, data) {
      state.blogs = data;
    },
    addBlogToBlogs(state, data) {
      state.blogs.unshift(data);
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getAllBlogs({ commit, dispatch }) {
      try {
        let res = await api.get("blogs");
        commit("setBlogs", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async createBlog({ commit, dispatch }, payload) {
      try {
        let res = await api.post("blogs", payload);
        commit("addBlogToBlogs", res.data);
        router.push({ name: "home" });
      } catch (error) {
        console.error(error);
      }
    }
  }
});
