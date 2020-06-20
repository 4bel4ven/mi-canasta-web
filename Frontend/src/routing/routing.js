import Router from "vue-router";
import Vue from "vue";
import LayoutPage from "../app/layout/components/layout/LayoutPage.vue";
import LayoutLogin from "../app/layout/components/layout/LayoutLogin.vue";
import LoginPage from "../app/modules/login/login.page.vue";
import HomePage from "../app/modules/home/home.page.vue";
import SolicitudPage from "../app/modules/solicitud/solicitud.page.vue";
import HomeFamilyPage from "../app/modules/home-family/home-family.page.vue";
import DealersPage from "../app/modules/home-dealers/home-dealers.page.vue";
import SharedPageComponent from "../app/modules/shared-componentes/shared-components.page.vue";
import RequestsSentPage from "../app/modules/request-sent/requests-sent.page.vue";
import RequestReceived from "../app/modules/requests-received/requests-received.page.vue";
import SalePage from "../app/modules/sale/sale.page.vue";
import UserPage from "../app/modules/user/user.page.vue";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      redirect: "/login",
    },
    {
      path: "/login",
      name: "LayoutLogin",
      component: LayoutLogin,
      children: [
        {
          path: "/",
          name: "LoginPage",
          component: LoginPage,
        },
      ],
    },
    {
      path: "/home",
      name: "LayoutPage",
      component: LayoutPage,
      children: [
        { path: "/home", name: "HomePage", component: HomePage },
        { path: "family", name: "FamilyPage", component: HomeFamilyPage },
        { path: "dealers", name: "DealersPage", component: DealersPage },
        {
          path: "solicitudes",
          name: "SolicitudPage",
          component: SolicitudPage,
        },
        { path: "family/:id", name: "FamilyPage", component: HomeFamilyPage },
        {
          path: "requests-sent",
          name: "RequestsSentPage",
          component: RequestsSentPage,
        },
        {
          path: "requests-received/:idFam",
          name: "RequestReceived",
          component: RequestReceived,
        },
        { path: "sell", name: "SalePage", component: SalePage },
        { path: "user", name: "UserPage", component: UserPage },
      ],
    },
    {
      path: "/componentes",
      name: "SharedPageComponent",
      component: SharedPageComponent,
    },
  ],
});
