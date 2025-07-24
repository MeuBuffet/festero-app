<template>
  <div>
    <h5 class="mb-3">Dados da Empresa</h5>

    <div class="mb-3">
      <label class="mb-2" for="empresa-razao">Razão Social</label>
      <input id="empresa-razao" v-model="form.company.name" type="text" class="form-control fs-13px"
        placeholder="Razão social da empresa" :class="{ 'is-invalid': touched && form.company.name.length < 3 }" />
      <div v-if="touched && form.company.name.length < 3" class="invalid-feedback">
        Informe a razão social com ao menos 3 caracteres.
      </div>
    </div>

    <div class="mb-3">
      <label class="mb-2" for="empresa-fantasia">Nome Fantasia</label>
      <input id="empresa-fantasia" v-model="form.company.fantasyName" type="text" class="form-control fs-13px"
        placeholder="Nome fantasia" :class="{ 'is-invalid': touched && form.company.fantasyName.length < 3 }" />
      <div v-if="touched && form.company.fantasyName.length < 3" class="invalid-feedback">
        Informe um nome fantasia válido.
      </div>
    </div>

    <div class="mb-3">
      <label class="mb-2" for="empresa-cnpj">CNPJ</label>
      <input id="empresa-cnpj" v-model="form.company.cnpj" type="text" class="form-control fs-13px"
        placeholder="CNPJ da empresa" :class="{ 'is-invalid': touched && !validCNPJ(form.company.cnpj) }" v-mask="'##.###.###/####-##'" />
      <div v-if="touched && !validCNPJ(form.company.cnpj)" class="invalid-feedback">
        CNPJ inválido. Formato esperado: 00.000.000/0000-00
      </div>
    </div>

    <div class="mb-3">
      <label class="mb-2" for="empresa-segmento">
        Segmento
        <i class="bi bi-info-circle text-muted" v-tooltip="'Ex: Buffet Infantil, Casa de Festas, Decoração etc.'"></i>
      </label>
      <input id="empresa-segmento" v-model="form.company.segment" type="text" class="form-control fs-13px"
        placeholder="Setor/segmento de atuação" />
    </div>

    <div class="mb-3">
      <label class="mb-2" for="empresa-email">Email Corporativo</label>
      <input id="empresa-email" v-model="form.company.email" type="email" class="form-control fs-13px"
        placeholder="Email da empresa" :class="{ 'is-invalid': touched && !validEmail(form.company.email) }" />
      <div v-if="touched && !validEmail(form.company.email)" class="invalid-feedback">
        Informe um email válido.
      </div>
    </div>

    <div class="mb-3">
      <label class="mb-2" for="empresa-telefone">Telefone</label>
      <input id="empresa-telefone" v-model="form.company.phone" type="text" class="form-control fs-13px"
        placeholder="Telefone com DDD" />
    </div>

    <div class="d-flex justify-content-between">
      <button type="button" @click="$emit('back')" class="btn btn-secondary">Voltar</button>
      <button type="button" @click="nextStep" class="btn btn-primary">Próximo</button>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';

const props = defineProps(['form']);
const emit = defineEmits(['next', 'back']);
const touched = ref(false);

const validCNPJ = (cnpj) => {
  return /^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$/.test(cnpj);
};

const validEmail = (email) => {
  return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email);
};

function nextStep() {
  touched.value = true;

  const isValid =
    props.form.company.name.length >= 3 &&
    props.form.company.fantasyName.length >= 3 &&
    validCNPJ(props.form.company.cnpj) &&
    validEmail(props.form.company.email);

  if (isValid) emit('next');
}
</script>

<style scoped>
.is-invalid {
  border-color: #dc3545 !important;
}
</style>
