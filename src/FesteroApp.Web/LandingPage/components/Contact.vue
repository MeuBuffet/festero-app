<template>
  <!-- contact start -->
  <section class="section bg-light" id="contact">
    <b-container>
      <b-row class="justify-content-center mb-5">
        <b-col md="8" lg="6" class="text-center">
          <h2 class="title">Fale com a equipe Festero</h2>
          <p class="text-muted fs-16">
            Tem alguma dúvida, sugestão ou deseja conhecer melhor a plataforma? Estamos prontos para te ouvir.
          </p>
          <div class="title-line"></div>
        </b-col>
      </b-row>

      <b-row>
        <!-- Formulário -->
        <b-col lg="7">
          <b-form>
            <b-row>
              <b-col md="6">
                <div class="mb-3">
                  <label for="formFirstName" class="form-label">Nome</label>
                  <b-form-input id="formFirstName" placeholder="Digite seu nome" required />
                </div>
              </b-col>
              <b-col md="6">
                <div class="mb-3">
                  <label for="formLastName" class="form-label">Sobrenome</label>
                  <b-form-input id="formLastName" placeholder="Digite seu sobrenome" required />
                </div>
              </b-col>
              <b-col cols="12">
                <div class="mb-3">
                  <label for="formEmail" class="form-label">E-mail</label>
                  <b-form-input type="email" id="formEmail" placeholder="Digite seu e-mail" required />
                </div>
              </b-col>
              <b-col cols="12">
                <div class="mb-3">
                  <label for="formSubject" class="form-label">Assunto</label>
                  <b-form-input id="formSubject" placeholder="Qual o assunto?" required />
                </div>
              </b-col>
              <b-col cols="12">
                <div class="mb-4">
                  <label for="formMessages" class="form-label">Mensagem</label>
                  <b-form-textarea id="formMessages" rows="4" placeholder="Escreva sua mensagem aqui..." required />
                </div>
              </b-col>
            </b-row>
            <b-button type="submit" variant="danger">
              Enviar Mensagem
              <SvgIcon :path="mdiSend" size="15" type="mdi" class="ms-1" />
            </b-button>
          </b-form>
        </b-col>

        <!-- Informações de contato -->
        <b-col lg="4" class="offset-lg-1">
          <div class="mb-4">
            <div class="d-flex align-items-center mb-3">
              <div class="flex-shrink-0">
                <div class="contact-icon bg-soft-primary text-primary">
                  <SvgIcon :path="mdiEmail" size="25" type="mdi" />
                </div>
              </div>
              <div class="flex-grow-1 ms-3">
                <p class="mb-0">
                  <a href="mailto:contato@festero.com.br" class="text-secondary">contato@festero.com.br</a>
                </p>
              </div>
            </div>
          </div>

          <div class="mb-4">
            <div class="d-flex mb-3">
              <div class="flex-shrink-0">
                <div class="contact-icon bg-soft-primary text-primary">
                  <SvgIcon :path="mdiPhone" size="25" type="mdi" />
                </div>
              </div>
              <div class="flex-grow-1 ms-3">
                <p class="mb-1">
                  <a href="tel:+5511999999999" class="text-secondary">+55 (11) 99999-9999</a>
                </p>
              </div>
            </div>
          </div>

          <div class="d-flex align-items-center mb-3">
            <div class="flex-shrink-0">
              <div class="contact-icon bg-soft-primary text-primary">
                <SvgIcon :path="mdiGoogleMaps" size="25" type="mdi" />
              </div>
            </div>
            <div class="flex-grow-1 ms-3">
              <h5 class="fs-16 mb-2 text-secondary">São Paulo:</h5>
              <p class="text-muted lh-base">
                Av. Paulista, 1000 – Bela Vista<br />
                São Paulo – SP, 01310-100
              </p>
            </div>
          </div>
        </b-col>
      </b-row>
    </b-container>
  </section>
  <!-- contact end -->
</template>

<script setup lang="ts">
import { mdiSend, mdiEmail, mdiPhone, mdiGoogleMaps } from "@mdi/js";
import SvgIcon from "@jamescoyle/vue-icon";
</script>
