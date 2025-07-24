<script setup lang="ts">
import { useAppOptionStore } from '@/stores/app-option'
import { onMounted } from 'vue'
import { onBeforeRouteLeave } from 'vue-router'
import { Vue3Lottie } from "vue3-lottie";
import errorAnimation from '@/assets/lotties/404.json' // precisa do JSON salvo

const appOption = useAppOptionStore()

onMounted(() => {
	appOption.appSidebarHide = true
	appOption.appHeaderHide = true
	appOption.appContentClass = 'p-0'
})

onBeforeRouteLeave(() => {
	appOption.appSidebarHide = false
	appOption.appHeaderHide = false
	appOption.appContentClass = ''
})
</script>

<template>
	<div class="error-page d-flex flex-column justify-content-center align-items-center text-center p-4">
		<img src="@/assets/images/logo/logo.png" alt="Festero" class="mb-4" style="max-width: 180px" />

		<Vue3Lottie :animationData="errorAnimation" :height="600" :width="600" />


		<h1 class="display-4 mt-4 fw-bold text-danger">Página não encontrada</h1>
		<p class="text-muted mb-4">
			A página que você está procurando não existe ou foi movida.<br />
			Verifique o endereço ou volte para a página inicial.
		</p>

		<router-link to="/" class="btn btn-primary px-4 py-2">
			Voltar ao Início
		</router-link>
	</div>
</template>

<style scoped>
.error-page {
	min-height: 100vh;
	background-color: rgb(37, 37, 37);
}
</style>
