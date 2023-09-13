import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import Company from "../views/Company";
import Supplier from "../views/Supplier";

const routes = [
  {
    path: "/",
    name: "home",
    component: HomeView,
  },
  {
    path: "/company",
    name: "company",
    component: Company,
    props: true,
  },
  {
    path: "/supplier",
    name: "supplier",
    component: Supplier,
    props: true,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
