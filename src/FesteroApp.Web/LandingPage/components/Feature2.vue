<template>
<!-- features start -->
<section class="section bg-light features-bg" id="cliente">
  <b-container>
    <b-row class="align-items-center">
      <b-col lg="5">
        <h2 class="lh-base mb-4">Área do cliente: autonomia e transparência</h2>
        <p class="text-muted mb-4">
          Após fechar contrato, o cliente recebe acesso a um painel exclusivo onde pode acompanhar cada detalhe da sua festa em tempo real.
        </p>

        <div class="d-flex align-items-center mb-3">
          <div class="flex-shrink-0">
            <span class="avatar avatar-md bg-white text-primary rounded-circle shadow-primary">
              <SvgIcon :path="mdiCheck" type="mdi" size="20" />
            </span>
          </div>
          <div class="flex-grow-1 ms-4">
            <p class="text-muted mb-0">
              <span class="text-dark fw-bold">Gestão do evento:</span> acompanhe status, cronograma, pagamentos e fornecedores vinculados.
            </p>
          </div>
        </div>

        <div class="d-flex align-items-center mb-3">
          <div class="flex-shrink-0">
            <span class="avatar avatar-md bg-white text-primary rounded-circle shadow-primary">
              <SvgIcon :path="mdiLayersOutline" type="mdi" size="20" />
            </span>
          </div>
          <div class="flex-grow-1 ms-4">
            <p class="text-muted mb-0">
              <span class="text-dark fw-bold">Cadastro de convidados:</span> liste os convidados da festa e acompanhe confirmações de presença.
            </p>
          </div>
        </div>

        <div class="d-flex align-items-center mb-3">
          <div class="flex-shrink-0">
            <span class="avatar avatar-md bg-white text-primary rounded-circle shadow-primary">
              <SvgIcon :path="mdiLockOutline" type="mdi" size="20" />
            </span>
          </div>
          <div class="flex-grow-1 ms-4">
            <p class="text-muted mb-0">
              <span class="text-dark fw-bold">Preferências e observações:</span> o cliente define o que deseja de comida, bebida, decorações e detalhes importantes.
            </p>
          </div>
        </div>

        <div class="d-flex align-items-center mb-3">
          <div class="flex-shrink-0">
            <span class="avatar avatar-md bg-white text-primary rounded-circle shadow-primary">
              <SvgIcon :path="mdiCheck" type="mdi" size="20" />
            </span>
          </div>
          <div class="flex-grow-1 ms-4">
            <p class="text-muted mb-0">
              <span class="text-dark fw-bold">Acesso seguro e exclusivo:</span> cada cliente visualiza apenas os eventos contratados e pode se comunicar diretamente com a equipe.
            </p>
          </div>
        </div>
      </b-col>

      <b-col lg="5" class="offset-lg-1">
        <img src="@/assets/images/features-2.png" alt="Área do cliente Festero" class="img-fluid d-block mx-auto ms-lg-auto" />
      </b-col>
    </b-row>
  </b-container>
</section>
<!-- features end -->
</template>

<script setup lang="ts">
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiCheck, mdiLayersOutline, mdiLockOutline } from '@mdi/js'
</script>
