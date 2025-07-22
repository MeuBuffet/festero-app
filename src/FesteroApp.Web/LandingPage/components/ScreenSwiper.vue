<template>
  <!-- Nossa Equipe start -->
  <section class="section overflow-hidden" id="team">
    <b-container>
      <b-row class="justify-content-center mb-5">
        <b-col md="8" lg="6" class="text-center">
          <h2 class="title">Conheça Nossa Equipe</h2>
          <p class="text-muted fs-16">Profissionais apaixonados por tecnologia e eventos, prontos para oferecer o melhor
            para o seu negócio.</p>
          <div class="title-line"></div>
        </b-col>
      </b-row>

      <b-row>
        <b-col cols="12">
          <div class="screen-slider overflow-hidden">
            <Swiper :modules="[Autoplay, Pagination]" :centeredSlides="true" :spaceBetween="24" :loop="true"
              :autoplay="{ delay: 3000, disableOnInteraction: false }"
              :pagination="{ el: '.swiper-pagination', clickable: true }" :breakpoints="{
                0: { slidesPerView: 1.2 },
                576: { slidesPerView: 2 },
                768: { slidesPerView: 3 },
                1024: { slidesPerView: 4 },
              }">
              <SwiperSlide v-for="(member, idx) in teamData" :key="idx">
                <div class="text-center p-3">
                  <img :src="member.image" alt="" class="rounded-circle shadow"
                    style="width: 120px; height: 120px; object-fit: cover;" />
                  <h5 class="mt-3 mb-1">{{ member.name }}</h5>
                  <p class="text-muted mb-0 fs-14">{{ member.role }}</p>
                </div>
              </SwiperSlide>
              <div class="swiper-pagination"></div>
            </Swiper>
          </div>
        </b-col>
      </b-row>
    </b-container>
  </section>
  <!-- Nossa Equipe end -->
</template>

<script lang="ts" setup>
import { Swiper, SwiperSlide } from "swiper/vue";
import { Autoplay, Pagination } from "swiper/modules";

// Substitua pelas imagens reais dos membros
import img1 from "@/assets/images/screen-shot/1.jpg";
import img2 from "@/assets/images/screen-shot/2.jpg";

const teamData = [
  {
    image: img1,
    name: "João Marcelo",
    role: "Fundador",
  },
  {
    image: img2,
    name: "Guilherme Lopes",
    role: "Fundador",
  },
];
</script>
