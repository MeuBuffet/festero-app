<template>
    <section class="section" id="pricing">
        <b-container>
            <b-row class="justify-content-center mb-5">
                <b-col md="8" lg="6" class="text-center">
                    <h2 class="title">Planos</h2>
                    <p class="text-muted fs-16">Escolha o plano ideal para o seu negócio.</p>
                    <div class="title-line"></div>
                </b-col>
            </b-row>
            <!-- Toggle between mensal/anual -->
            <b-row>
                <b-col cols="12">
                    <Swiper :modules="[Navigation, Pagination]" :spaceBetween="24" :loop="false" :slidesPerView="1"
                        :breakpoints="{
                            768: { slidesPerView: 2 },
                            1024: { slidesPerView: 3 }
                        }" navigation pagination class="pricing-swiper">
                        <SwiperSlide v-for="(item, idx) in pricingData" :key="idx">
                            <div class="pricing-box h-100">
                                <span v-if="item.badge" class="pricing-badge">Mais Popular</span>
                                <div class="text-center mb-4 bg-light p-4 rounded">
                                    <h5>{{ item.tag }}</h5>
                                    <p class="text-muted small mb-0">{{ item.hint }}</p>
                                    <h1 class="mt-3 mb-1 text-primary">
                                        R$ {{ item.monthly }}
                                        <span class="text-muted fs-16 fw-normal"> /mês</span>
                                    </h1>
                                    <p class="text-muted mb-0" style="font-size: 14px;">
                                        ou <strong>R$ {{ item.annual }}</strong> por ano (economize até
                                        <span v-if="(item.monthly * 12 - item.annual) > 0">R$ {{ (item.monthly * 12 -
                                            item.annual).toFixed(2) }}</span>)
                                    </p>

                                </div>
                                <ul class="list-unstyled text-secondary mb-5 pt-2">
                                    <li v-for="(feature, i) in item.features" :key="i" class="my-3">
                                        <SvgIcon :path="mdiCheck" size="15" type="mdi" class="me-1" />
                                        {{ feature }}
                                    </li>
                                </ul>
                                <a href="javascript:void(0);" class="btn btn-primary w-100">Escolher plano</a>
                            </div>
                        </SwiperSlide>
                    </Swiper>
                </b-col>
            </b-row>


        </b-container>
    </section>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { Swiper, SwiperSlide } from 'swiper/vue'
import { Navigation, Pagination } from 'swiper/modules'
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiCheck } from '@mdi/js'

type PricingType = {
    tag: string
    monthly: number
    annual: number
    hint: string
    badge?: boolean
    features: string[]
}

const isAnnual = ref(false)

const pricingData: PricingType[] = [
    {
        tag: 'Básico',
        monthly: 49.99,
        annual: 399.90,
        hint: 'Ideal para empresas pequenas',
        features: [
            '5 usuários',
            '1 evento ativo',
            'Geração de orçamento manual (PDF)',
            'Cadastro de clientes e leads',
            'Suporte por e-mail (até 48h)',
        ],
    },
    {
        tag: 'Standard',
        monthly: 159.99,
        annual: 1499.90,
        hint: 'Ideal para empresas médias',
        badge: true,
        features: [
            '10 usuários',
            'Até 10 eventos simultâneos',
            'Integração com Google Agenda',
            'Contrato com assinatura digital',
            'Orçamento automático para leads',
            'Briefing digital para o cliente',
            'Gestão financeira simples',
            'Suporte por WhatsApp e e-mail (até 12h)',
        ],
    },
    {
        tag: 'Enterprise',
        monthly: 499.99,
        annual: 4499.90,
        hint: 'Ideal para grandes empresas',
        features: [
            'Usuários ilimitados',
            'Eventos ilimitados',
            'Dashboard com métricas gerenciais',
            'Envio automático de notas fiscais (NFS-e)',
            'Personalização total da plataforma',
            'Controle de acesso por perfil',
            'Gestão de estoque e fornecedores',
            'Check-in de convidados no evento',
            'Gerente dedicado e suporte prioritário',
        ],
    },
]

</script>

<style>
/* Se desejar ajustes para o swiper */
.pricing-swiper .swiper-button-prev,
.pricing-swiper .swiper-button-next {
    color: #000;
}
</style>
