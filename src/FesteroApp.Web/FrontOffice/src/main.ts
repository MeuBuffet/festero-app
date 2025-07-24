import { createApp } from "vue";
import { createPinia } from "pinia";
import { Vue3ProgressPlugin } from "@marcoschulte/vue3-progress";
import { PerfectScrollbarPlugin } from "vue3-perfect-scrollbar";
import { mask } from 'vue-the-mask';
import ToastPlugin from 'vue-toast-notification';
import Vue3Lottie from 'vue3-lottie'
import mitt from "mitt";
import "vue3-perfect-scrollbar/style.css";
import "@fortawesome/fontawesome-free/scss/fontawesome.scss";
import "@fortawesome/fontawesome-free/scss/regular.scss";
import "@fortawesome/fontawesome-free/scss/solid.scss";
import "@fortawesome/fontawesome-free/scss/brands.scss";
import "@fortawesome/fontawesome-free/scss/v4-shims.scss";
import 'vue-toast-notification/dist/theme-bootstrap.css';
import "bootstrap";
import "./assets/scss/vue.scss";
import App from "./App.vue";
import router from "./router";

import Panel from "@/components/bootstrap/Panel.vue";
import PanelBody from "@/components/bootstrap/PanelBody.vue";
import PanelHeader from "@/components/bootstrap/PanelHeader.vue";
import PanelTitle from "@/components/bootstrap/PanelTitle.vue";
import PanelFooter from "@/components/bootstrap/PanelFooter.vue";
import PanelToolbar from "@/components/bootstrap/PanelToolbar.vue";

import VCalendar from "v-calendar";
import "v-calendar/dist/style.css";

const emitter = mitt();
const app = createApp(App);

app.directive('mask', mask);
app.component("Panel", Panel);
app.component("PanelBody", PanelBody);
app.component("PanelHeader", PanelHeader);
app.component("PanelFooter", PanelFooter);
app.component("PanelToolbar", PanelToolbar);
app.component("PanelTitle", PanelTitle);
app.use(createPinia());
app.use(router);
app.use(Vue3ProgressPlugin);
app.use(PerfectScrollbarPlugin);
app.use(VCalendar);
app.use(Vue3Lottie)
app.use(ToastPlugin);


app.config.globalProperties.emitter = emitter;
app.mount("#app");
