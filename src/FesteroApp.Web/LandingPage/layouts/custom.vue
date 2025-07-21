<template>
  <slot />
  <Work />
  <Feature1 />
  <Feature2 />
  <Counter />
  <Testimonial />
  <PricingCard />
  <Faqs />
  <Cta />
  <Team />
  <Contact />
  <Footer />
  <client-only>
    <BackToTop />
  </client-only>
</template>

<script lang="ts" setup>
import Work from "@/components/Work.vue";
import Feature1 from "~/components/Feature1.vue";
import Feature2 from "~/components/Feature2.vue";
import Team from "@/components/ScreenSwiper.vue";
import PricingCard from "@/components/PricingCard.vue";
import Faqs from "@/components/Faqs.vue";
import Cta from "@/components/Cta.vue";
import Footer from "@/components/Footer.vue";
import BackToTop from "@/components/BackToTop.vue";
import Contact from "@/components/Contact.vue";
import Testimonial from "@/components/Testimonial.vue";
</script>
