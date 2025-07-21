<template>
<!-- Depoimentos -->
<section class="section bg-light border-light border-top border-bottom" id="testimonial">
  <b-container>
    <b-row class="justify-content-center mb-5">
      <b-col md="8" lg="6" class="text-center">
        <h2 class="title">O que nossos clientes dizem</h2>
        <div class="title-line"></div>
      </b-col>
    </b-row>

    <b-row class="justify-content-center">
      <b-col lg="8">
        <div class="testimonial-box text-center">
          <h3 class="fw-light fst-italic fs-22 lh-base mb-4 pb-3">
            “A Festero revolucionou a forma como gerencio minha casa de festas. Automatizamos os contratos, organizamos os eventos com facilidade e meus clientes amam acompanhar tudo pelo painel.”
          </h3>
          <img :src="user1Img" alt="Cliente" class="shadow rounded-circle" width="70" />
          <h5 class="fs-18 fw-semibold mt-4 mb-0">Mariana Castro</h5>
          <p class="text-muted fs-14">Proprietária da Encanto Festas - SP</p>
        </div>
      </b-col>
    </b-row>

    <b-row class="mt-md-5">
      <b-col sm="6" md="3" v-for="(item,idx) in testimonialData" :key="idx">
        <div class="text-center py-3">
          <img :src="item.image" alt="Parceiro" height="40" />
        </div>
      </b-col>
    </b-row>
  </b-container>
</section>
</template>

<script setup lang="ts">
import parceiro1 from '@/assets/images/brand-logo/dribbble.png'
import parceiro2 from '@/assets/images/brand-logo/insta.png'
import parceiro3 from '@/assets/images/brand-logo/bootstrap.png'
import parceiro4 from '@/assets/images/brand-logo/jquery.png'
import user1Img from '@/assets/images/users/user-1.jpg'

const testimonialData = [
  { image: parceiro1 },
  { image: parceiro2 },
  { image: parceiro3 },
  { image: parceiro4 }
]
</script>
