<template>
  <div>
    <a href="#" class="back-to-top-btn btn btn-primary align-item-center justify-content-center" :style="`display: ${buttonVisible ? 'block' : 'none'};`" id="back-to-top"><SvgIcon :path="mdiChevronUp" size="20" type="mdi"></SvgIcon></a>
  </div>
</template>

<script setup lang="ts">
import {onMounted, ref} from "vue";
import SvgIcon from "@jamescoyle/vue-icon";
import {mdiChevronUp} from "@mdi/js";

const buttonVisible = ref(window.scrollY >= 120);

onMounted(() => {
  document.addEventListener("scroll", () => {
    buttonVisible.value = window.scrollY >= 120;
  });
});
</script>
