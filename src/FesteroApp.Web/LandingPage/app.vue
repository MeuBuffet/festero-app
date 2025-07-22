<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script setup lang="ts">
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue-next/dist/bootstrap-vue-next.css";
import "swiper/swiper-bundle.css";
import "swiper/css/pagination";
import "@/assets/scss/style.scss";

useHead({
  titleTemplate: (pageTitle) => {
    return pageTitle
      ? `${pageTitle} | Festero - Gestão de Eventos e Festas`
      : "Festero - Plataforma para Gestão de Eventos e Festas";
  },
  meta: [
    { name: "viewport", content: "width=device-width, initial-scale=1.0" },
    { name: "author", content: "Equipe Festero" },
    {
      name: "description",
      content:
        "A Festero é a plataforma completa para buffets, casas de festas e organizadores de eventos. Gerencie seus clientes, orçamentos, fornecedores e muito mais de forma profissional.",
    },
  ],
});
</script>
