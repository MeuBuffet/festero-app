<template>
  <!-- footer & cta start -->
  <section class="footer bg-dark">
    <div class="py-5">
      <b-container>
        <b-row>
          <b-col lg="3" class="text-center text-lg-start">
            <div class="footer-logo mb-4">
              <a href="#">
                <img src="@/assets/images/logo-light.png" alt="Festero Logo" height="96" />
              </a>
            </div>
            <p class="footer-text text-white-50">
              O Festero é a solução completa para gerenciar sua empresa, seus clientes e seus eventos de forma moderna e eficiente.
            </p>

            <ul class="list-inline mt-4">
              <li class="list-inline-item">
                <a href="javascript:void(0);" class="footer-social-icon">
                  <SvgIcon :path="mdiFacebook" size="15" type="mdi" />
                </a>
              </li>
              <li class="list-inline-item">
                <a href="javascript:void(0);" class="footer-social-icon">
                  <SvgIcon :path="mdiTwitter" size="15" type="mdi" />
                </a>
              </li>
              <li class="list-inline-item">
                <a href="javascript:void(0);" class="footer-social-icon">
                  <SvgIcon :path="mdiLinkedin" size="15" type="mdi" />
                </a>
              </li>
              <li class="list-inline-item">
                <a href="javascript:void(0);" class="footer-social-icon">
                  <SvgIcon :path="mdiSkype" size="15" type="mdi" />
                </a>
              </li>
            </ul>
          </b-col>

          <b-col lg="9">
            <b-row>
              <b-col sm="6" md="3">
                <h5 class="fs-18 mb-3 fw-semibold text-white">Sobre o Festero</h5>
                <ul class="list-unstyled footer-nav">
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Quem Somos</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Como Funciona</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Depoimentos</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Blog</a></li>
                </ul>
              </b-col>

              <b-col sm="6" md="3">
                <h5 class="fs-18 mb-3 fw-semibold text-white">Suporte</h5>
                <ul class="list-unstyled footer-nav">
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Central de Ajuda</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Fale Conosco</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Status do Sistema</a></li>
                </ul>
              </b-col>

              <b-col sm="6" md="3">
                <h5 class="fs-18 mb-3 fw-semibold text-white">Conta</h5>
                <ul class="list-unstyled footer-nav">
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Minha Conta</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Configurações</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Assinaturas</a></li>
                </ul>
              </b-col>

              <b-col sm="6" md="3">
                <h5 class="fs-18 mb-3 fw-semibold text-white">Legal</h5>
                <ul class="list-unstyled footer-nav">
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Política de Privacidade</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />Termos de Uso</a></li>
                  <li><a href="#" class="footer-link"><SvgIcon :path="mdiPlayCircle" size="15" class="link-icon" />LGPD</a></li>
                </ul>
              </b-col>
            </b-row>
          </b-col>
        </b-row>
      </b-container>
    </div>

    <div class="footer-tagline">
      <b-container>
        <b-row class="justify-content-between py-2">
          <b-col md="6">
            <p class="text-white opacity-75 mb-0 fs-14">
              © {{ year }} Festero - Todos os direitos reservados.
            </p>
          </b-col>
          <b-col md="6" class="text-md-end">
            <a href="#" class="text-white opacity-75 fs-14">Política de Privacidade e Termos</a>
          </b-col>
        </b-row>
      </b-container>
    </div>
  </section>
</template>

<script setup lang="ts">
const year = new Date().getFullYear();
import SvgIcon from '@jamescoyle/vue-icon'
import { mdiFacebook, mdiTwitter, mdiLinkedin, mdiSkype, mdiPlayCircle } from '@mdi/js'
</script>
