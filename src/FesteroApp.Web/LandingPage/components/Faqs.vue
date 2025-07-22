<template>
<!-- faqs start -->
<section class="section bg-light border-light border-top border-bottom">
  <b-container>
    <b-row class="justify-content-center mb-5">
      <b-col md="8" lg="6" class="text-center">
        <h2 class="title">Perguntas Frequentes</h2>
        <p class="text-muted fs-16">Tire suas dúvidas sobre como o Festero pode transformar a gestão da sua empresa de eventos.</p>
        <div class="title-line"></div>
      </b-col>
    </b-row>

    <b-row class="justify-content-md-center">
      <b-col sm="6" lg="5" class="mb-3" v-for="(faq,idx) in faqData" :key="idx">
        <h4 class="fs-18 fw-bold">{{ faq.question }}</h4>
        <p class="fs-16 text-muted">{{ faq.answer }}</p>
      </b-col>
    </b-row>
  </b-container>
</section>
<!-- faqs end -->
</template>

<script setup lang="ts">
type FaqType = {
  question: string
  answer: string
}

const faqData: FaqType[] = [
  {
    question: 'Preciso instalar algo para usar o Festero?',
    answer: 'Não! O Festero é totalmente online e pode ser acessado de qualquer navegador. Basta criar sua conta e começar a usar.'
  },
  {
    question: 'É possível personalizar contratos para meus clientes?',
    answer: 'Sim, você pode usar o modelo da plataforma ou criar o seu próprio contrato. O Festero também permite o envio para assinatura digital.'
  },
  {
    question: 'Consigo controlar a lista de convidados do evento?',
    answer: 'Sim! Cada cliente pode montar sua lista de convidados, adicionar preferências de comida, observações e até enviar confirmações (RSVP).'
  },
  {
    question: 'Posso conectar com o Google Agenda?',
    answer: 'Sim. A plataforma integra com o Google Agenda para sincronizar os eventos automaticamente com a equipe e os clientes.'
  },
  {
    question: 'Como funciona o plano de assinatura?',
    answer: 'Você escolhe entre planos mensais ou anuais, de acordo com as funcionalidades que precisa. Todos os planos incluem suporte e atualizações.'
  },
  {
    question: 'Meus dados estão seguros?',
    answer: 'Sim. Utilizamos criptografia e boas práticas de segurança para garantir que suas informações e as dos seus clientes estejam protegidas.'
  }
]
</script>
