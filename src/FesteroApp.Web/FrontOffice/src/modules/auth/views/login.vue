<template>
	<div class="login login-with-news-feed">
		<div class="news-feed">
			<div class="news-image" :style="{ backgroundImage: `url(${backgroundImage})` }"></div>
			<div class="news-caption">
				<h4 class="caption-title"><b>Festero</b> Login</h4>
				<p>Organize eventos com praticidade, estilo e profissionalismo com a Festero.</p>
			</div>
		</div>

		<div class="login-container">
			<div class="login-header mb-30px">
				<div class="brand">
					<div class="d-flex align-items-center">
						<img src="@/assets/images/logo/logo.png" alt="logomarca" height="400">
					</div>
					<small>Crie sua conta e comece a gerenciar seus eventos com a Festero.</small>
				</div>
			</div>

			<div class="login-content">
				<form @submit="checkForm" method="POST" class="fs-13px">
					<div class="form-floating mb-15px">
						<input v-model="email" type="text" class="form-control h-45px fs-13px" placeholder="Seu e-mail"
							id="emailAddress" pattern="^[^\s@]+@[^\s@]+\.[^\s@]+$" required />
						<label for="emailAddress" class="d-flex align-items-center fs-13px text-gray-600">
							E-mail
						</label>
					</div>

					<div class="form-floating mb-15px position-relative">
						<input :type="showPassword ? 'text' : 'password'" class="form-control h-45px fs-13px"
							placeholder="Senha" id="password" v-model="password" required />
						<label for="password" class="d-flex align-items-center fs-13px text-gray-600">
							Senha
						</label>
						<i class="fa-solid fa-eye" :class="showPassword ? 'bi-eye-slash' : 'bi-eye'"
							@click="togglePassword"
							style="position: absolute; right: 10px; top: 50%; transform: translateY(-50%); cursor: pointer;"></i>
					</div>

					<div class="mb-15px">
						<button type="submit" class="btn btn-theme d-block h-45px w-100 btn-lg fs-14px">
							Fazer login
						</button>
					</div>

					<div class="mb-40px pb-40px text-dark">
						Não possui uma conta? <router-link to="/auth/register" class="text-success">Registre
							aqui</router-link>.
					</div>

					<hr class="bg-gray-600 opacity-2" />
					<div class="text-gray-600 text-center text-gray-500-darker mb-0">
						&copy; Festero - Todos os direitos reservados {{ new Date().getFullYear() }}
					</div>
				</form>
			</div>
		</div>
	</div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { onBeforeRouteLeave, useRouter } from 'vue-router';
import { useAppOptionStore } from '@/stores/app-option';
import { useAuthStore } from '../store';
import backgroundImage from '@/assets/images/background/login/background.png';
import { useToast } from 'vue-toast-notification';

const email = ref('');
const password = ref('');
const showPassword = ref(false);
const router = useRouter();
const toast = useToast();

const togglePassword = () => {
	showPassword.value = !showPassword.value;
};

const appOption = useAppOptionStore();
const authStore = useAuthStore();

onMounted(() => {
	appOption.appSidebarHide = true;
	appOption.appHeaderHide = true;
	appOption.appContentClass = 'p-0';
});

onBeforeRouteLeave(() => {
	appOption.appSidebarHide = false;
	appOption.appHeaderHide = false;
	appOption.appContentClass = '';
});

const checkForm = async (e: Event) => {
	e.preventDefault();
	try {
		await authStore.login({ email: email.value, password: password.value });
	} catch (error: any) {
		toast.error(error?.message || 'Falha ao fazer login.');
	}
};
</script>
