// https://nuxt.com/docs/api/configuration/nuxt-config

export default defineNuxtConfig({
  ssr: true,
  devtools: { enabled: true },
  modules: ["@bootstrap-vue-next/nuxt"],
  css: ["bootstrap/dist/css/bootstrap.min.css"],
  alias: {
    assets: "/<rootDir>/assets",
    "@components": "./components/",
  },
});
