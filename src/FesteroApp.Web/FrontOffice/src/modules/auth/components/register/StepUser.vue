<template>
    <div>
        <h5 class="mb-3">Dados do Usuário</h5>

        <div class="mb-3">
            <label class="mb-2 d-flex align-items-center">
                Nome
                <span class="ms-1" v-tooltip="'Informe seu primeiro nome'">
                    <i class="bi bi-info-circle"></i>
                </span>
            </label>
            <input v-model="form.firstName" type="text" class="form-control fs-13px"
                :class="{ 'is-invalid': touched && !form.firstName }" placeholder="Seu nome" required />
            <div v-if="touched && !form.firstName" class="invalid-feedback">
                O nome é obrigatório.
            </div>
        </div>

        <div class="mb-3">
            <label class="mb-2 d-flex align-items-center">
                Sobrenome
                <span class="ms-1" v-tooltip="'Informe seu sobrenome completo'">
                    <i class="bi bi-info-circle"></i>
                </span>
            </label>
            <input v-model="form.lastName" type="text" class="form-control fs-13px"
                :class="{ 'is-invalid': touched && !form.lastName }" placeholder="Seu sobrenome" required />
            <div v-if="touched && !form.lastName" class="invalid-feedback">
                O sobrenome é obrigatório.
            </div>
        </div>
        <div class="mb-3">
            <label class="mb-2">CPF</label>
            <input v-model="form.document" type="text" class="form-control fs-13px" v-mask="'###.###.###-##'" placeholder="000.000.000-00"
                :class="{ 'is-invalid': touched && !isValidCPF(form.document) }"  />
            <div v-if="touched && !isValidCPF(form.document)" class="invalid-feedback">
                CPF inválido. Formato esperado: 000.000.000-00
            </div>
        </div>

        <div class="mb-3">
            <label class="mb-2 d-flex align-items-center">
                Email
                <span class="ms-1" v-tooltip="'Informe um e-mail válido para contato'">
                    <i class="bi bi-info-circle"></i>
                </span>
            </label>
            <input v-model="form.email" type="email" class="form-control fs-13px" :class="{
                'is-invalid': touched && (!form.email || !isValidEmail(form.email))
            }" placeholder="Digite seu e-mail" required />
            <div v-if="touched && !form.email" class="invalid-feedback">
                O e-mail é obrigatório.
            </div>
            <div v-else-if="touched && form.email && !isValidEmail(form.email)" class="invalid-feedback">
                O e-mail não é válido.
            </div>
        </div>

        <div class="mb-3">
            <label class="mb-2 d-flex align-items-center">
                Repetir Email
                <span class="ms-1" v-tooltip="'Digite o mesmo e-mail para confirmação'">
                    <i class="bi bi-info-circle"></i>
                </span>
            </label>
            <input v-model="form.reEmail" type="email" class="form-control fs-13px" :class="{
                'is-invalid': touched && form.reEmail !== form.email
            }" placeholder="Digite novamente seu e-mail" required />
            <div v-if="touched && form.reEmail !== form.email" class="invalid-feedback">
                Os e-mails não coincidem.
            </div>
        </div>

        <div class="mb-3">
            <label class="mb-2 d-flex align-items-center">
                Telefone
                <span class="ms-1" v-tooltip="'Informe seu número com DDD'">
                    <i class="bi bi-info-circle"></i>
                </span>
            </label>
            <input v-model="form.phone" type="tel" class="form-control fs-13px"
                :class="{ 'is-invalid': touched && !form.phone }" placeholder="(11) 99999-9999" required />
            <div v-if="touched && !form.phone" class="invalid-feedback">
                O telefone é obrigatório.
            </div>
        </div>

        <button type="button" class="btn btn-primary" @click="handleNext">
            Próximo
        </button>
    </div>
</template>

<script setup>
import { defineProps, defineEmits, ref } from 'vue';

const props = defineProps({
    form: Object
});

const emit = defineEmits(['next']);
const touched = ref(false);

function isValidEmail(email) {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}

function handleNext() {
    touched.value = true;

    const valid =
        props.form.firstName &&
        props.form.lastName &&
        props.form.phone &&
        props.form.email &&
        isValidEmail(props.form.email) &&
        props.form.reEmail === props.form.email;

    if (valid) {
        emit('next');
    }
}

const isValidCPF = cpf => /^\d{3}\.\d{3}\.\d{3}-\d{2}$/.test(cpf);
</script>
