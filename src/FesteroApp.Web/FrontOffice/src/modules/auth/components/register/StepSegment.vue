<template>
  <div>
    <h5 class="mb-3">Qual seu papel e segmento?</h5>
    <div class="mb-4">
      <label class="form-label">Qual dessas opções melhor descreve seu cargo?</label>
      <div class="d-flex flex-wrap gap-2">
        <button v-for="option in roles" :key="option" :class="['btn btn-outline-primary', { active: form.role === option }]" @click="form.role = option" type="button">
          {{ option }}
        </button>
      </div>
      <small v-if="errors.role" class="text-danger d-block mt-2">{{ errors.role }}</small>
    </div>
    <div class="mb-4">
      <label class="form-label">Em qual segmento sua empresa atua?</label>
      <div class="d-flex flex-wrap gap-2">
        <button v-for="option in segments" :key="option" :class="['btn btn-outline-secondary', { active: form.segment === option }]" @click="form.segment = option" type="button">
          {{ option }}
        </button>
      </div>
      <small v-if="errors.segment" class="text-danger d-block mt-2">{{ errors.segment }}</small>
    </div>
    <div class="d-flex justify-content-between">
      <button type="button" @click="$emit('back')" class="btn btn-secondary">Voltar</button>
      <button type="button" @click="$emit('next')" class="btn btn-primary">Próximo</button>
    </div>
  </div>
</template>

<script setup>
const props = defineProps(['form', 'errors']);
const emit = defineEmits(['next', 'back']);
const roles = [
  'Proprietário de negócios', 'Líder de equipe', 'Membro da equipe', 'Freelancer', 'Diretor', 'Executivo', 'Vice-Presidente'
];
const segments = [
  'Casas de festas', 'Buffets', 'Decoração', 'Fotografia', 'Aluguel de materiais', 'Eventos corporativos', 'Outros'
];
</script>

<style scoped>
button.active {
  background-color: var(--bs-primary);
  color: white;
  border-color: var(--bs-primary);
}
</style>