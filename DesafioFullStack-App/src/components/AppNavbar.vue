<template>
  <nav id="nav">
    <router-link to="/" id="logo-url">
      <img :src="logo" :alt="alt" id="logo" />
    </router-link>
    <router-link to="/company">Empresa</router-link> |
    <router-link to="/supplier">Fornecedor</router-link>    
  </nav>
</template>

<script>
export default {
  name: "AppNavbar",
  props: ["logo", "alt"],
};
</script>

<style scoped>
#nav {
  background-color: #222222;
  border-bottom: 2px solid #111111;
  padding: 15px 50px;
  display: flex;
  justify-content: flex-end;
  align-items: center;
}

#nav #logo-url {
  margin: auto;
  margin-left: 0;
}

#logo {
  width: 40px;
  height: 40px;
}

#nav a {
  color: #987bad;
  text-decoration: none;
  margin: 12px;
  transition: 0.5s;
}

#nav a:hover {
  color: #ffffff;
}
</style>
