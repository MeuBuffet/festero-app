<template>
	<div class="register register-with-news-feed">
		<div class="news-feed">
			<div class="news-image" :style="{ backgroundImage: `url(${backgroundImage})` }"></div>
			<div class="news-caption">

				<h4 class="caption-title"><b>Festero</b> Registro</h4>
				<p>Organize seus eventos com eficiência e profissionalismo com a Festero.</p>
			</div>
		</div>

		<div class="register-container">
			<img src="@/assets/images/logo/logo.png" alt="logomarca" height="400">
			<div class="register-header mb-25px h1">
				<div class="mb-1">Criar Conta</div>
				<small class="d-block fs-15px lh-16">Preencha os dados abaixo para começar.</small>
			</div>

			<div class="register-content">
				<form @submit="submitForm" method="POST" class="fs-13px">
					<transition name="fade" mode="out-in">
						<component :is="currentStepComponent" :form="form" :errors="errors" @next="nextStep"
							@back="previousStep" />
					</transition>

					<div class="mb-4 pb-5 mt-4">
						Já possui conta? <router-link to="/auth/login">Clique aqui para entrar</router-link>.
					</div>
					<hr class="bg-gray-600 opacity-2" />
					<p class="text-center text-gray-600">© Festero - Todos os direitos reservados 2025</p>
				</form>
			</div>
		</div>
	</div>
</template>

<script>
import StepUser from '../components/register/StepUser.vue';
import StepPassword from '../components/register/StepPassword.vue';
import StepSegment from '../components/register/StepSegment.vue';
import StepCompany from '../components/register/StepCompany.vue';
import StepConfirmation from '../components/register/StepConfirmation.vue';
import backgroundImage from '@/assets/images/background/login/background.png';

import { useAppOptionStore } from '@/stores/app-option';

export default {
	components: {
		StepUser,
		StepPassword,
		StepSegment,
		StepCompany,
		StepConfirmation
	},
	data() {
		return {
			backgroundImage,
			step: 1,
			form: {
				firstName: '',
				lastName: '',
				email: '',
				reEmail: '',
				phone: '',
				password: '',
				document: '',
				agreement: false,
				role: '',
				segment: '',
				company: {
					name: '',
					fantasyName: '',
					cnpj: '',
					email: '',
					phone: ''
				}
			},
			errors: {}
		};
	},
	computed: {
		currentStepComponent() {
			return [
				null,
				'StepUser',
				'StepPassword',
				'StepSegment',
				'StepCompany',
				'StepConfirmation'
			][this.step];
		}
	},
	mounted() {
		const appOption = useAppOptionStore();
		appOption.appSidebarHide = true;
		appOption.appHeaderHide = true;
		appOption.appContentClass = 'p-0';
	},
	beforeRouteLeave(to, from, next) {
		const appOption = useAppOptionStore();
		appOption.appSidebarHide = false;
		appOption.appHeaderHide = false;
		appOption.appContentClass = '';
		next();
	},
	methods: {
		validateStep() {
			const e = {};
			if (this.step === 1) {
				if (!this.form.firstName) e.firstName = 'Informe o nome';
				if (!this.form.lastName) e.lastName = 'Informe o sobrenome';
				if (!this.form.email) e.email = 'Informe o e-mail';
				if (this.form.email !== this.form.reEmail) e.reEmail = 'Os e-mails não coincidem';
			}
			if (this.step === 2) {
				if (!this.form.password || this.form.password.length < 6) e.password = 'Senha fraca';
				if (!this.form.agreement) e.agreement = 'Aceite os termos';
			}
			if (this.step === 3) {
				if (!this.form.role) e.role = 'Selecione um cargo';
				if (!this.form.segment) e.segment = 'Selecione um segmento';
			}
			if (this.step === 4) {
				if (!this.form.company.name) e.companyName = 'Informe a razão social';
				if (!this.form.company.cnpj) e.cnpj = 'Informe o CNPJ';
				if (!this.form.company.email) e.companyEmail = 'Informe o email da empresa';
			}
			this.errors = e;
			return Object.keys(e).length === 0;
		},
		nextStep() {
			if (this.validateStep()) this.step++;
		},
		previousStep() {
			if (this.step > 1) this.step--;
		},
		submitForm(e) {
			e.preventDefault();
			if (this.validateStep()) {
				console.log('Dados enviados:', this.form);
				this.$router.push({ path: '/dashboard/v3' });
			}
		}
	}
};
</script>
