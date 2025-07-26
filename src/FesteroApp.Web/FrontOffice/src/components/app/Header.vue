<script setup lang="ts">
import { ref, onMounted, computed } from "vue";
import { useAppOptionStore } from "@/stores/app-option";
import { RouterLink } from "vue-router";
import { slideToggle } from "@/composables/slideToggle.ts";
import AppHeaderMegaMenu from "@/components/app/HeaderMegaMenu.vue";
import type { AuthUser, Notification } from "@/modules/auth/store/types";
import utils from "@/utils/helpers";
import { useAuthStore } from '@/modules/auth/store/index';

const appOption = useAppOptionStore();
const notificationData = ref<Notification[]>([]);
const user = ref<AuthUser | null>(null);
const auth = useAuthStore();

const translatedRole = computed(() => {
  const role = user.value?.roles?.[0]?.Role;
  return utils.helpers.translateRole(role);
});

function toggleAppSidebarCollapsed() {
	if (appOption.appSidebarCollapsed) {
		appOption.appSidebarToggled = !appOption.appSidebarToggled;
	} else if (appOption.appSidebarToggled) {
		appOption.appSidebarToggled = !appOption.appSidebarToggled;
	}
	appOption.appSidebarCollapsed = !appOption.appSidebarCollapsed;
};

function toggleAppSidebarMobileToggled(_event?: MouseEvent) {
  appOption.appSidebarMobileToggled = !appOption.appSidebarMobileToggled;
}

function toggleAppSidebarEndToggled() {
  appOption.appSidebarEndToggled = !appOption.appSidebarEndToggled;
}

function toggleAppSidebarEndMobileToggled() {
  appOption.appSidebarEndMobileToggled = !appOption.appSidebarEndMobileToggled;
}

function toggleAppHeaderSearch(event: Event) {
  event.preventDefault();
  appOption.appHeaderSearchToggled = !appOption.appHeaderSearchToggled;
}

function toggleAppTopMenuMobileToggled(event: Event) {
  event.preventDefault();
  slideToggle(document.querySelector(".app-top-menu") as HTMLElement);
}

function handleWindowResize() {
  window.addEventListener("resize", () => {
    const elm = document.querySelector(".app-top-menu");
    if (elm) elm.removeAttribute("style");
  });
}

function checkForm(event: Event) {
  event.preventDefault();
  // router.push({ path: "/extra/search" }); — useRouter pode ser utilizado aqui
}

onMounted(() => {
  handleWindowResize();

  const userData = localStorage.getItem("user");

  if (userData) {
    try {
      user.value = JSON.parse(userData);
    } catch (e) {
      console.error("Erro ao ler usuário:", e);
    }
  }
});
</script>

<template>
  <div
    id="header"
    class="app-header"
    :data-bs-theme="appOption.appHeaderInverse ? 'dark' : ''"
  >
    <!-- BEGIN navbar-header -->
    <div class="navbar-header">
      <button
        type="button"
        class="navbar-mobile-toggler"
        v-if="appOption.appSidebarTwo"
        @click="toggleAppSidebarEndMobileToggled"
      >
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <RouterLink to="/" class="navbar-brand">
        <span class="navbar-logo"></span> <b>FesteroApp</b> Admin
      </RouterLink>

      <button
        type="button"
        class="navbar-mobile-toggler"
        v-if="
          appOption.appTopMenu &&
          appOption.appSidebarHide &&
          !appOption.appSidebarTwo
        "
        @click="toggleAppTopMenuMobileToggled($event)"
      >
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>

      <button
        type="button"
        class="navbar-mobile-toggler"
        v-if="!appOption.appSidebarHide"
        @click="toggleAppSidebarMobileToggled($event)"
      >
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
    </div>
    <!-- END navbar-header -->

    <app-header-mega-menu v-if="appOption.appHeaderMegaMenu" />

    <!-- BEGIN header-nav -->
    <div class="navbar-nav">
      <div class="navbar-item navbar-form">
        <form action="" method="POST" name="search" @submit="checkForm">
          <div class="form-group">
            <input
              type="text"
              class="form-control"
              placeholder="Enter keyword"
            />
            <button type="submit" class="btn btn-search">
              <i class="fa fa-search"></i>
            </button>
          </div>
        </form>
      </div>

      <div class="navbar-item dropdown">
        <a
          href="javascript:;"
          data-bs-toggle="dropdown"
          class="navbar-link dropdown-toggle icon"
        >
          <i class="fa fa-bell"></i>
          <span class="badge">{{ notificationData.length }}</span>
        </a>
        <div class="dropdown-menu media-list dropdown-menu-end">
          <div class="dropdown-header">
            NOTIFICATIONS ({{ notificationData.length }})
          </div>
          <template v-if="notificationData.length">
            <a
              href="javascript:;"
              class="dropdown-item media"
              v-for="(notification, index) in notificationData"
              :key="index"
            >
              <div class="media-left">
                <i v-if="notification.icon" :class="notification.icon"></i>
                <i
                  v-if="notification.iconMedia"
                  :class="notification.iconMedia"
                ></i>
                <img
                  v-if="notification.img"
                  :src="notification.img"
                  class="media-object"
                  alt=""
                />
              </div>
              <div class="media-body">
                <h6 class="media-heading" v-html="notification.title"></h6>
                <p v-if="notification.desc" v-html="notification.desc"></p>
                <div class="text-muted fs-10px">{{ notification.time }}</div>
              </div>
            </a>
          </template>
          <template v-else>
            <div class="text-center w-300px py-3">No notification found</div>
          </template>
          <div class="dropdown-footer text-center">
            <a href="javascript:;" class="text-decoration-none">View more</a>
          </div>
        </div>
      </div>

      <div class="navbar-item navbar-user dropdown">
        <a
          href="#"
          class="navbar-link dropdown-toggle d-flex align-items-center"
          data-bs-toggle="dropdown"
        >
          <div class="image image-icon bg-gray-800 text-gray-600">
            <i class="fa fa-user"></i>
          </div>
          <span>
            <span class="d-none d-md-inline fw-bold" v-if="user">
              {{ user?.name }}
            </span>
            <b class="caret"></b>
          </span>
        </a>
        <div class="dropdown-menu dropdown-menu-end me-1">
          <a href="javascript:;" class="dropdown-item">Editar Perfil</a>
          <a
            href="javascript:;"
            class="dropdown-item d-flex align-items-center"
          >
            Caixa de entrada
            <span class="badge bg-danger rounded-pill ms-auto pb-4px">2</span>
          </a>
          <a href="javascript:;" class="dropdown-item">Calendário</a>
          <a href="javascript:;" class="dropdown-item">Configurações</a>
          <div class="dropdown-divider"></div>
          <a href="javascript:;" class="dropdown-item" @click="auth.logout()">Sair</a>
        </div>
      </div>
    </div>
    <!-- END header-nav -->
  </div>
</template>
