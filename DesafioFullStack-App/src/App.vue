<template>
  <div id="app">
    <AppNavbar :logo="logo_src" :alt="app_name" />
    <router-view />
    <AppFooter />
  </div>
</template>

<script>
import AppNavbar from "./components/AppNavbar.vue";
import AppFooter from "./components/AppFooter.vue";

export default {
  components: {
    AppNavbar,
    AppFooter,
  },
  data() {
    return {
      logo_src: "/img/logo.png",
      app_name: "Faça seu cadastro",
    };
  },
};
</script>

<style>
* {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

.main-container {
  margin: 50px;
  min-height: 590px;
}

h1 {
  text-align: center;
  font-size: 20px;
  margin-bottom: 30px;
}
</style>
