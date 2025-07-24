import {
  createRouter,
  createWebHistory,
  type RouteRecordRaw,
  type NavigationGuardNext,
  type RouteLocationNormalized,
} from "vue-router";

import moment from "moment";
import { useAuthStore } from "@/modules/auth/store";

function isTokenExpired(expires: Date): boolean {
  return moment().isAfter(moment(expires));
}

export function ifAuthenticated(
  to: RouteLocationNormalized,
  from: RouteLocationNormalized,
  next: NavigationGuardNext
) {
  const auth = useAuthStore();

  if (
    auth.isAuthenticated &&
    auth.current &&
    !isTokenExpired(auth.current.expireIn!)
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
    component: () => import("@/modules/auth/views/register.vue"),
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
