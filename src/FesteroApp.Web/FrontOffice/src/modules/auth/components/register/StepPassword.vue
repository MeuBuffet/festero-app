<template>
  <div>
    <h5 class="mb-3">Segurança</h5>

    <div class="mb-3">
      <label for="password" class="mb-2">
        Senha
        <span
          v-tooltip="'Use uma senha segura, com letras maiúsculas, números e símbolos'"
          class="text-muted ms-1"
        >
          <i class="fas fa-lock"></i>
        </span>
      </label>
      <input
        id="password"
        v-model="form.password"
        type="password"
        class="form-control fs-13px"
        :class="{ 'is-invalid': touched && !isPasswordValid }"
        placeholder="Digite sua senha"
        required
      />
      <div class="invalid-feedback" v-if="touched && !isPasswordValid">
        A senha não atende aos critérios mínimos.
      </div>

      <ul class="small text-muted mt-2 ps-3">
        <li :class="{ 'text-success': hasMinLength }">Mínimo de 8 caracteres</li>
        <li :class="{ 'text-success': hasUppercase }">Uma letra maiúscula</li>
        <li :class="{ 'text-success': hasLowercase }">Uma letra minúscula</li>
        <li :class="{ 'text-success': hasNumber }">Um número</li>
        <li :class="{ 'text-success': hasSpecialChar }">Um caractere especial</li>
      </ul>
    </div>

    <div class="form-check mb-4">
      <input
        v-model="form.agreement"
        class="form-check-input"
        type="checkbox"
        id="agreementCheckbox"
      />
      <label class="form-check-label" for="agreementCheckbox">
        Li e concordo com os <a href="#">Termos</a> e
        <a href="#">Política de Privacidade</a>.
      </label>
      <div
        class="text-danger small mt-1"
        v-if="touched && !form.agreement"
      >
        Você deve aceitar os termos.
      </div>
    </div>

    <div class="d-flex justify-content-between">
      <button type="button" @click="$emit('back')" class="btn btn-secondary">
        Voltar
      </button>
      <button type="button" @click="handleNext" class="btn btn-primary">
        Próximo
      </button>
    </div>
  </div>
</template>

<script setup>
import { computed, ref } from 'vue';

const props = defineProps({ form: Object });
const emit = defineEmits(['next', 'back']);
const touched = ref(false);

// Regras individuais
const hasMinLength = computed(() => props.form.password?.length >= 8);
const hasUppercase = computed(() => /[A-Z]/.test(props.form.password));
const hasLowercase = computed(() => /[a-z]/.test(props.form.password));
const hasNumber = computed(() => /[0-9]/.test(props.form.password));
const hasSpecialChar = computed(() => /[!@#$%^&*(),.?":{}|<>]/.test(props.form.password));

const isPasswordValid = computed(
  () =>
    hasMinLength.value &&
    hasUppercase.value &&
    hasLowercase.value &&
    hasNumber.value &&
    hasSpecialChar.value
);

function handleNext() {
  touched.value = true;

  if (isPasswordValid.value && props.form.agreement) {
    emit('next');
  }
}
</script>

<style scoped>
ul li {
  list-style: disc;
}
.text-success {
  color: #28a745 !important;
}
</style>
