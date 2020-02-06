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
    teams: []
  },
  mutations: {
    setTeams(state, data) {
      state.teams = data;
    },
    addTeam(state, data) {
      state.teams.unshift(data);
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getAllTeams({ commit, dispatch }) {
      try {
        let res = await api.get("teams");
        commit("setTeams", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async createTeam({ commit, dispatch }, payload) {
      try {
        let res = await api.post("teams", payload);
        commit("addTeam", res.data);
        router.push({ name: "home" });
      } catch (error) {
        console.error(error);
      }
    }
  }
});
