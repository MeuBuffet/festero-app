<template>
    <div>
        <h5 class="mb-3">Confirmação</h5>
        <p class="mb-4">Revise os dados abaixo antes de finalizar o cadastro:</p>
        <div class="mb-4">
            <h6 class="text-theme">Dados Pessoais</h6>
            <ul class="list-unstyled fs-13px">
                <li><strong>Nome:</strong> {{ form.firstName }} {{ form.lastName }}</li>
                <li><strong>Email:</strong> {{ form.email }}</li>
            </ul>
        </div>
        <div class="mb-4">
            <h6 class="text-theme">Dados da Empresa</h6>
            <ul class="list-unstyled fs-13px">
                <li><strong>Razão Social:</strong> {{ form.company.name }}</li>
                <li><strong>Nome Fantasia:</strong> {{ form.company.fantasyName }}</li>
                <li><strong>CNPJ:</strong> {{ form.company.cnpj }}</li>
                <li><strong>Segmento:</strong> {{ form.company.segment }}</li>
                <li><strong>Email:</strong> {{ form.company.email }}</li>
                <li><strong>Telefone:</strong> {{ form.company.phone }}</li>
            </ul>
        </div>

        <div class="d-flex justify-content-between">
            <button type="button" @click="$emit('back')" class="btn btn-secondary">Voltar</button>
            <button type="submit" class="btn btn-success">Finalizar Cadastro</button>
        </div>
    </div>
</template>

<script setup>
const props = defineProps(['form'])
const emit = defineEmits(['back'])
</script>
