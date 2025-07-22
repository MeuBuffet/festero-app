<template>
  <!-- features start -->
  <section class="section border-light border-top" id="features">
    <b-container>
      <b-row class="align-items-center">
        <b-col lg="6">
          <img :src="feature1" alt="Recursos Festero" class="img-fluid d-block mx-auto ms-lg-auto" />
        </b-col>
        <b-col lg="5" class="offset-lg-1">
          <h2 class="lh-base mb-4">Recursos poderosos para gestão de eventos e empresas</h2>
          <p class="text-muted mb-4">
            Automatize processos, facilite o atendimento ao cliente e tenha total controle sobre sua operação.
            A Festero foi pensada para ser a espinha dorsal da sua empresa.
          </p>

          <div
            v-for="(feature, index) in features.slice(0, 4)"
            :key="index"
            class="d-flex align-items-start mb-3"
          >
            <div class="flex-shrink-0">
              <span class="avatar avatar-md bg-white text-primary rounded-circle shadow-primary mt-1">
                <SvgIcon :path="feature.icon" size="20" type="mdi" class="fs-20" />
              </span>
            </div>
            <div class="flex-grow-1 ms-4">
              <p class="text-muted mb-0">
                <span class="text-dark fw-bold">{{ feature.title }}:</span> {{ feature.description }}
              </p>
            </div>
          </div>

          <b-button variant="primary" @click="showModal = true" class="mt-3">
            Ver todas as funcionalidades
          </b-button>
        </b-col>
      </b-row>
    </b-container>

    <!-- Modal de funcionalidades -->
    <b-modal v-model="showModal" title="Todas as funcionalidades do sistema" size="lg" hide-footer scrollable>
      <div v-for="category in categories" :key="category" class="mb-4">
        <h5 class="text-primary border-bottom pb-1">{{ category }}</h5>
        <ul class="list-unstyled mt-3">
          <li
            v-for="feature in groupedFeatures[category]"
            :key="feature.title"
            class="mb-3 d-flex align-items-start"
          >
            <SvgIcon :path="feature.icon" size="20" type="mdi" class="me-2 mt-1 text-primary" />
            <div>
              <strong>{{ feature.title }}</strong>: {{ feature.description }}
            </div>
          </li>
        </ul>
      </div>
    </b-modal>
  </section>
  <!-- features end -->
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'
import feature1 from '~/assets/images/features-1.png'
import SvgIcon from '@jamescoyle/vue-icon'
import {
  mdiCheck,
  mdiLayersOutline,
  mdiLockOutline,
  mdiBankTransfer,
  mdiFileDocumentEdit,
  mdiCalendarAccount,
  mdiChartTimelineVariant
} from '@mdi/js'

const showModal = ref(false)

const features = [
  {
    category: 'Comercial',
    title: 'Gestão de leads',
    description: 'Monitore todos os contatos recebidos, histórico e status das oportunidades de venda.',
    icon: mdiChartTimelineVariant
  },
  {
    category: 'Comercial',
    title: 'Orçamentos automáticos para leads',
    description: 'Leads que preencherem seu formulário recebem uma proposta personalizada em minutos.',
    icon: mdiCheck
  },
  {
    category: 'Comercial',
    title: 'Briefing digital para o cliente',
    description: 'Colete preferências, estilos e expectativas através de formulários digitais personalizados.',
    icon: mdiLayersOutline
  },
  {
    category: 'Comercial',
    title: 'Assinatura digital de contratos',
    description: 'Envie documentos para assinatura com segurança e validade jurídica via Clicksign.',
    icon: mdiFileDocumentEdit
  },
  {
    category: 'Eventos',
    title: 'Integração com Google Agenda',
    description: 'Sincronize eventos automaticamente com o calendário do Google.',
    icon: mdiCalendarAccount
  },
  {
    category: 'Eventos',
    title: 'Controle de acesso nos eventos',
    description: 'Emita QR Codes para entrada, valide em tempo real e registre presenças.',
    icon: mdiLockOutline
  },
  {
    category: 'Financeiro',
    title: 'Gestor financeiro com conciliação bancária',
    description: 'Importe extratos, vincule receitas e despesas, e acompanhe a saúde financeira da empresa.',
    icon: mdiBankTransfer
  }
]

const categories = computed(() => {
  return [...new Set(features.map(f => f.category))]
})

const groupedFeatures = computed(() => {
  return categories.value.reduce((acc, category) => {
    acc[category] = features.filter(f => f.category === category)
    return acc
  }, {} as Record<string, typeof features>)
})
</script>
