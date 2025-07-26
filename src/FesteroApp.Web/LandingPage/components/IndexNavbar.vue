<template>
<!--Navbar Start-->
<nav class="navbar navbar-expand-lg fixed-top navbar-custom navbar-dark sticky-dark" id="navbar-sticky">
    <b-container>
      <NuxtLink class="logo text-uppercase" to="/">
        <img src="@/assets/images/logo-dark.png" alt="" class="" height="24" />
      </NuxtLink>
      <b-button class="navbar-toggler" variant="light" v-b-toggle.collapse.navbarCollapse>
        <SvgIcon :path="mdiMenu" type="mdi" size="24" class="text-secondary"></SvgIcon>
      </b-button>
      <b-collapse class="navbar-collapse" id="navbarCollapse">
        <ul class="navbar-nav mx-auto navbar-center" id="mySidenav">
          <li class="nav-item">
            <a href="#home" class="nav-link">Início</a>
          </li>
          <li class="nav-item">
            <a href="#demo" class="nav-link">Demo</a>
          </li>
        </ul>
        <ul class="navbar-nav navbar-center">
          <li class="nav-item">
            <a href="https://1.envato.market/Appoo" target="_blank" class="btn btn-sm nav-btn"> <SvgIcon :path="mdiCartOutline" size="14" type="mdi" class="align-middle"></SvgIcon> Buy Now </a>
          </li>
        </ul>
      </b-collapse>
    </b-container>
</nav>
<!-- Navbar End -->
</template>

<script setup lang="ts">
import SvgIcon from "@jamescoyle/vue-icon"
import { mdiCartOutline, mdiMenu } from "@mdi/js"
import { onMounted } from "vue"

onMounted(() => {
    function windowScroll() {
        const navbar = document.getElementById("navbar-sticky");
        if (navbar) {
            if (document.body.scrollTop >= 50 || document.documentElement.scrollTop >= 50) {
                navbar.classList.add("nav-sticky");
            } else {
                navbar.classList.remove("nav-sticky");
            }
        }
    }

    window.addEventListener("scroll", () => {
        windowScroll();
    });

    const sections = document.querySelectorAll<HTMLElement>("section[id]");
    window.addEventListener("scroll", navActive);

    function navActive() {
        const scrollY = window.scrollY;
        sections.forEach((current) => {
            const sectionHeight = current.offsetHeight,
                sectionTop = current.offsetTop - 50,
                sectionId = current.getAttribute("id");
            const anchorLink = document.querySelector(".navbar a[href*=" + sectionId + "]");
            if (scrollY > sectionTop && scrollY <= sectionTop + sectionHeight) {
                anchorLink?.classList.add("active");
            } else {
                anchorLink?.classList.remove("active");
            }
        });
    }
});
</script>
