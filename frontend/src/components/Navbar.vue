<template>
  <v-app-bar app color="primary" dark>
    <div class="d-flex align-center">
      <v-img
        alt="Vuetify Logo"
        class="shrink mr-2"
        contain
        src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
        transition="scale-transition"
        width="40"
      />
    </div>

    <div class="d-flex align-center">
      <v-btn to="/" depressed color="primary">
        Home
      </v-btn>
      <v-btn to="/categories" depressed color="primary">
        Categories
      </v-btn>
    </div>
  </v-app-bar>
</template>

<script>
export default {
  name: 'Navbar',
};
</script>

<style></style>
