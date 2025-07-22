<template>
  <Navbar :is-dark="true" />
  <Index />
</template>

<script lang="ts" setup>
definePageMeta({
  layout: "custom",
});

useHead({
});

import Index from "~/components/heros/Hero.vue";
import Navbar from "@/components/Navbar.vue";
</script>
