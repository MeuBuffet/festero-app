import { defineStore } from "pinia";
import { ref } from "vue";

export const useAppStore = defineStore("app", () => {
  const isLoading = ref(false);

  const appThemePanelToggled = ref(false);
  const appThemeClass = ref<string | null>(null);
  const appDarkMode = ref(false);

  const appHeaderFixed = ref(false);
  const appHeaderInverse = ref(false);
  const appSidebarFixed = ref(false);
  const appSidebarGrid = ref(false);
  const appGradientEnabled = ref(false);
  const appRtlEnabled = ref(false);

  function showLoading() {
    isLoading.value = true;
  }

  function hideLoading() {
    isLoading.value = false;
  }

  function toggleDarkMode() {
    appDarkMode.value = !appDarkMode.value;
  }

  return {
    // loading
    isLoading,
    showLoading,
    hideLoading,

    // tema/layout
    appThemePanelToggled,
    appThemeClass,
    appDarkMode,
    appHeaderFixed,
    appHeaderInverse,
    appSidebarFixed,
    appSidebarGrid,
    appGradientEnabled,
    appRtlEnabled,

    // ações
    toggleDarkMode,
  };
});
