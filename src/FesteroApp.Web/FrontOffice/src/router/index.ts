import {
  createRouter,
  createWebHistory,
  type RouteRecordRaw,
  type NavigationGuardNext,
  type RouteLocationNormalized,
} from "vue-router";

import Register from "@/modules/auth/views/register.vue";
import moment from "moment";
import { useAuthStore } from "@/modules/auth/store/auth.store";

function isTokenExpired(expires: string): boolean {
  return moment().isAfter(moment(expires));
}

export function ifAuthenticated(
  to: RouteLocationNormalized,
  from: RouteLocationNormalized,
  next: NavigationGuardNext
) {
  const auth = useAuthStore();

  // Se ainda não carregou o estado do localStorage
  if (!auth.current) auth.loadFromStorage();

  if (
    auth.isAuthenticated &&
    auth.current &&
    !isTokenExpired(auth.current.expires)
  ) {
    next();
  } else {
    auth.logout();
    next("/auth/login");
  }
}

const routes: RouteRecordRaw[] = [
  {
    path: "/",
    name: "home",
    component: () => import("@/views/Home.vue"),
    beforeEnter: ifAuthenticated,
    meta: { requiresAuth: true },
  },
  {
    path: "/auth/login",
    name: "login",
    component: () => import("@/modules/auth/views/login.vue"),
  },
  {
    path: "/auth/register",
    name: "register",
    component: Register,
  },
  {
    path: "/:pathMatch(.*)*",
    name: "not-found",
    component: () => import("@/views/Error.vue"),
  },
];

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;
