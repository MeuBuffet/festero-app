<template>
  <!--Navbar Start-->
  <nav class="navbar navbar-expand-lg fixed-top navbar-custom"
    :class="isDark ? 'navbar-dark sticky-dark' : 'navbar-light sticky-dark'" id="navbar-sticky">
    <b-container>
      <NuxtLink class="logo text-uppercase" to="/">
        <img :src="darklogo" alt="Logo escura" class="logo-dark" height="112" />
        <img :src="lightlogo" alt="Logo clara" class="logo-light" height="112" />
      </NuxtLink>

      <b-button class="navbar-toggler" variant="light" v-b-toggle.collapse.navbarCollapse>
        <SvgIcon :path="mdiMenu" size="24" type="mdi" class="text-secondary" />
      </b-button>

      <b-collapse class="navbar-collapse" id="navbarCollapse">
        <ul class="navbar-nav mx-auto text-center" id="mySidenav">
          <li class="nav-item"><a href="#features" class="nav-link">Recursos</a></li>
          <li class="nav-item"><a href="#testimonial" class="nav-link">Depoimentos</a></li>
          <li class="nav-item"><a href="#pricing" class="nav-link">Planos</a></li>
          <li class="nav-item"><a href="#contact" class="nav-link">Fale conosco</a></li>
          <li class="nav-item"><a href="#team" class="nav-link">Time Festero</a></li>
        </ul>

        <ul class="navbar-nav text-center">
          <li class="nav-item">
            <a :href="frontOfficeUrl" class="btn btn-sm btn-light" role="button">Entrar</a>
          </li>
          <li class="nav-item ms-2">
            <a href="#" class="btn btn-sm btn-light" role="button">Criar conta</a>
          </li>
        </ul>
      </b-collapse>
    </b-container>
  </nav>
  <!-- Navbar End -->
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue"
import SvgIcon from "@jamescoyle/vue-icon"
import darklogo from '~/assets/images/logo-dark.png'
import lightlogo from '~/assets/images/logo-light.png'
import { mdiMenu } from "@mdi/js"

defineProps({
  isDark: Boolean
})

const frontOfficeUrl = ref('https://app.festero.com.br')

onMounted(() => {
  const navbar = document.getElementById("navbar-sticky")

  function handleScroll() {
    if (!navbar) return

    if (window.scrollY >= 50) {
      navbar.classList.add("nav-sticky")
    } else {
      navbar.classList.remove("nav-sticky")
    }

    const sections = document.querySelectorAll<HTMLElement>("section[id]")
    sections.forEach(section => {
      const sectionTop = section.offsetTop - 50
      const sectionHeight = section.offsetHeight
      const sectionId = section.getAttribute("id")
      const navLink = document.querySelector(`.navbar a[href*="${sectionId}"]`)

      if (window.scrollY > sectionTop && window.scrollY <= sectionTop + sectionHeight) {
        navLink?.classList.add("active")
      } else {
        navLink?.classList.remove("active")
      }
    })
  }

  window.addEventListener("scroll", handleScroll)
})
</script>
