<template>
  <!-- Métricas da plataforma -->
  <section class="section cta-bg">
    <div class="bg-overlay bg-dark"></div>
    <b-container>
      <b-row id="counter">
        <b-col sm="6" lg="3" v-for="(item, idx) in counterData" :key="idx">
          <div class="text-center my-3">
            <div class="d-flex align-items-center counter-content text-start">
              <div class="flex-shrink-0">
                <SvgIcon :path="item.icon" type="mdi" size="50" class="text-white display-5" />
              </div>
              <div class="flex-grow-1 ms-4">
                <h1 class="text-white">
                  <Vue3autocounter
                    class="counter_value"
                    :startAmount="0"
                    :endAmount="item.target"
                    :duration="3"
                    suffix="+"
                    separator=""
                    :autoinit="true"
                  />
                </h1>
                <p class="counter-name text-white opacity-75 mb-0 text-uppercase">
                  {{ item.content }}
                </p>
              </div>
            </div>
          </div>
        </b-col>
      </b-row>
    </b-container>
  </section>
</template>

<script setup lang="ts">
import SvgIcon from "@jamescoyle/vue-icon";
import Vue3autocounter from "vue3-autocounter";
import {
  mdiDomain,
  mdiCalendarCheckOutline,
  mdiAccountHeartOutline,
  mdiFileDocumentEditOutline
} from "@mdi/js";

type CounterType = {
  icon: string;
  target: number;
  content: string;
};

const counterData: CounterType[] = [
  {
    icon: mdiDomain,
    target: 120,
    content: "Empresas usando Festero"
  },
  {
    icon: mdiCalendarCheckOutline,
    target: 3500,
    content: "Eventos Gerenciados"
  },
  {
    icon: mdiAccountHeartOutline,
    target: 180000,
    content: "Convidados Atendidos"
  },
  {
    icon: mdiFileDocumentEditOutline,
    target: 2800,
    content: "Contratos Assinados"
  }
];
</script>
