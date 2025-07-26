<script setup lang="ts">
import { ref } from 'vue';

const year = ref(new Date().getFullYear());
</script>

<template>
  <!-- BEGIN #footer -->
  <div id="footer" class="app-footer">
    &copy; {{ year }} FesteroApp Todos os direitos reservados
  </div>
  <!-- END #footer -->
</template>
