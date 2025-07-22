<template>
  <!-- Como funciona -->
  <section class="section" id="como-funciona">
    <b-container>
      <b-row class="justify-content-center mb-5">
        <b-col md="8" lg="6" class="text-center">
          <h2 class="title">Como funciona?</h2>
          <p class="text-muted fs-16">
            Com a Festero, organizar eventos se torna simples, rápido e profissional. Veja como você pode transformar
            sua rotina com poucos cliques.
          </p>
          <div class="title-line"></div>
        </b-col>
      </b-row>

      <b-row>
        <b-col lg="4" v-for="(item, idx) in workData" :key="idx">
          <div class="work-box px-lg-5 text-center mb-5 mb-lg-0">
            <div class="work-icon bg-soft-primary mb-4">
              <SvgIcon :path="item.icon" size="56" type="mdi" class="text-primary" />
            </div>
            <h5 class="fw-semibold">{{ item.id }}. {{ item.title }}</h5>
            <p class="text-muted">{{ item.description }}</p>
            <img v-if="item.image" :src="item.image" alt="" class="work-arrow" />
          </div>
        </b-col>
      </b-row>
      <b-row class="justify-content-center mb-5">
        <b-col cols="12" md="10" lg="8">
          <div class="ratio ratio-16x9 mt-4">
            <iframe src="https://www.youtube.com/embed/SEU_VIDEO_ID" title="Como a Festero funciona" frameborder="0"
              allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
              allowfullscreen></iframe>
          </div>
        </b-col>
      </b-row>

    </b-container>
  </section>
</template>

<script lang="ts" setup>
import img1 from '~/assets/images/arrow-top.png'
import img2 from '~/assets/images/arrow-bottom.png'
import SvgIcon from '@jamescoyle/vue-icon'
import {
  mdiCalendarEdit,
  mdiAccountGroup,
  mdiClipboardCheckMultiple
} from '@mdi/js'

type WorkType = {
  id: number
  title: string
  description: string
  icon: string
  image?: string
}

const workData: WorkType[] = [
  {
    id: 1,
    title: 'Crie seu evento',
    description: 'Configure a data, local, tipo de evento e defina as preferências principais.',
    icon: mdiCalendarEdit,
    image: img1
  },
  {
    id: 2,
    title: 'Gerencie convidados e fornecedores',
    description: 'Adicione fornecedores, defina tarefas e envie convites automaticamente.',
    icon: mdiAccountGroup,
    image: img2
  },
  {
    id: 3,
    title: 'Acompanhe tudo em tempo real',
    description: 'Veja o andamento, confirme presença e gerencie tudo em um painel integrado.',
    icon: mdiClipboardCheckMultiple
  }
]
</script>
