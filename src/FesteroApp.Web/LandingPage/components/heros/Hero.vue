<template>
    <section class="hero-6" id="home">
        <b-container>
            <b-row class="align-items-center hero-content">
                <b-col lg="6">
                    <div class="mb-5 mb-lg-0">
                        <h1 class="mt-3 fw-bold display-4">
                            Organize eventos com maestria usando a <span class="text-primary">Festero</span>.
                        </h1>
                        <p class="mt-4">
                            A plataforma perfeita para buffets, casas de festas e organizadores. Gerencie eventos,
                            clientes, orçamentos, contratos e mais — tudo em um só lugar.
                        </p>

                        <div class="d-flex align-items-center gap-2 mt-4">
                            <a href="javascript:void(0);">
                                <img :src="istoreImg" alt="Baixar na App Store" class="shadow me-1" height="52" />
                                <img :src="playstoreImg" alt="Disponível no Google Play" class="shadow me-1"
                                    height="52" />
                            </a>
                        </div>
                    </div>
                </b-col>
                <b-col lg="6" class="text-center text-lg-end">
                    <img :src="hero6Img" alt="Interface Festero" class="img-fluid" />
                </b-col>
            </b-row>
        </b-container>
    </section>

    <b-container fluid>
        <b-row>
            <b-col cols="12">
                <div class="hero-bottom-shape">
                    <img :src="hero1bottomImg" alt="Shape decorativo" class="w-100" />
                </div>
            </b-col>
        </b-row>
    </b-container>
</template>

<script setup lang="ts">
import istoreImg from '~/assets/images/i-store.png'
import playstoreImg from '~/assets/images/play-store.png'
import hero6Img from '~/assets/images/heros/hero-6-img.png'
import hero1bottomImg from '~/assets/images/heros/hero-1-bottom-shape.png'
</script>
