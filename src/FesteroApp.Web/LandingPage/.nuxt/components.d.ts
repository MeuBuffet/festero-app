
import type { DefineComponent, SlotsType } from 'vue'
type IslandComponent<T extends DefineComponent> = T & DefineComponent<{}, {refresh: () => Promise<void>}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, SlotsType<{ fallback: { error: unknown } }>>
type HydrationStrategies = {
  hydrateOnVisible?: IntersectionObserverInit | true
  hydrateOnIdle?: number | true
  hydrateOnInteraction?: keyof HTMLElementEventMap | Array<keyof HTMLElementEventMap> | true
  hydrateOnMediaQuery?: string
  hydrateAfter?: number
  hydrateWhen?: boolean
  hydrateNever?: true
}
type LazyComponent<T> = (T & DefineComponent<HydrationStrategies, {}, {}, {}, {}, {}, {}, { hydrated: () => void }>)
interface _GlobalComponents {
      'BackToTop': typeof import("../components/BackToTop.vue")['default']
    'Contact': typeof import("../components/Contact.vue")['default']
    'Counter': typeof import("../components/Counter.vue")['default']
    'Cta': typeof import("../components/Cta.vue")['default']
    'Faqs': typeof import("../components/Faqs.vue")['default']
    'Feature1': typeof import("../components/Feature1.vue")['default']
    'Feature2': typeof import("../components/Feature2.vue")['default']
    'Footer': typeof import("../components/Footer.vue")['default']
    'IndexNavbar': typeof import("../components/IndexNavbar.vue")['default']
    'Navbar': typeof import("../components/Navbar.vue")['default']
    'PricingCard': typeof import("../components/PricingCard.vue")['default']
    'ScreenSwiper': typeof import("../components/ScreenSwiper.vue")['default']
    'Testimonial': typeof import("../components/Testimonial.vue")['default']
    'Work': typeof import("../components/Work.vue")['default']
    'HerosHero': typeof import("../components/heros/Hero.vue")['default']
    'NuxtWelcome': typeof import("../node_modules/nuxt/dist/app/components/welcome.vue")['default']
    'NuxtLayout': typeof import("../node_modules/nuxt/dist/app/components/nuxt-layout")['default']
    'NuxtErrorBoundary': typeof import("../node_modules/nuxt/dist/app/components/nuxt-error-boundary.vue")['default']
    'ClientOnly': typeof import("../node_modules/nuxt/dist/app/components/client-only")['default']
    'DevOnly': typeof import("../node_modules/nuxt/dist/app/components/dev-only")['default']
    'ServerPlaceholder': typeof import("../node_modules/nuxt/dist/app/components/server-placeholder")['default']
    'NuxtLink': typeof import("../node_modules/nuxt/dist/app/components/nuxt-link")['default']
    'NuxtLoadingIndicator': typeof import("../node_modules/nuxt/dist/app/components/nuxt-loading-indicator")['default']
    'NuxtTime': typeof import("../node_modules/nuxt/dist/app/components/nuxt-time.vue")['default']
    'NuxtRouteAnnouncer': typeof import("../node_modules/nuxt/dist/app/components/nuxt-route-announcer")['default']
    'NuxtImg': typeof import("../node_modules/nuxt/dist/app/components/nuxt-stubs")['NuxtImg']
    'NuxtPicture': typeof import("../node_modules/nuxt/dist/app/components/nuxt-stubs")['NuxtPicture']
    'BAccordion': typeof import("bootstrap-vue-next")['BAccordion']
    'BAccordionItem': typeof import("bootstrap-vue-next")['BAccordionItem']
    'BAlert': typeof import("bootstrap-vue-next")['BAlert']
    'BAvatar': typeof import("bootstrap-vue-next")['BAvatar']
    'BAvatarGroup': typeof import("bootstrap-vue-next")['BAvatarGroup']
    'BBadge': typeof import("bootstrap-vue-next")['BBadge']
    'BBreadcrumb': typeof import("bootstrap-vue-next")['BBreadcrumb']
    'BBreadcrumbItem': typeof import("bootstrap-vue-next")['BBreadcrumbItem']
    'BButton': typeof import("bootstrap-vue-next")['BButton']
    'BButtonGroup': typeof import("bootstrap-vue-next")['BButtonGroup']
    'BButtonToolbar': typeof import("bootstrap-vue-next")['BButtonToolbar']
    'BCard': typeof import("bootstrap-vue-next")['BCard']
    'BCardBody': typeof import("bootstrap-vue-next")['BCardBody']
    'BCardFooter': typeof import("bootstrap-vue-next")['BCardFooter']
    'BCardGroup': typeof import("bootstrap-vue-next")['BCardGroup']
    'BCardHeader': typeof import("bootstrap-vue-next")['BCardHeader']
    'BCardImg': typeof import("bootstrap-vue-next")['BCardImg']
    'BCardSubtitle': typeof import("bootstrap-vue-next")['BCardSubtitle']
    'BCardText': typeof import("bootstrap-vue-next")['BCardText']
    'BCardTitle': typeof import("bootstrap-vue-next")['BCardTitle']
    'BCarousel': typeof import("bootstrap-vue-next")['BCarousel']
    'BCarouselSlide': typeof import("bootstrap-vue-next")['BCarouselSlide']
    'BCloseButton': typeof import("bootstrap-vue-next")['BCloseButton']
    'BCol': typeof import("bootstrap-vue-next")['BCol']
    'BCollapse': typeof import("bootstrap-vue-next")['BCollapse']
    'BContainer': typeof import("bootstrap-vue-next")['BContainer']
    'BDropdown': typeof import("bootstrap-vue-next")['BDropdown']
    'BDropdownDivider': typeof import("bootstrap-vue-next")['BDropdownDivider']
    'BDropdownForm': typeof import("bootstrap-vue-next")['BDropdownForm']
    'BDropdownGroup': typeof import("bootstrap-vue-next")['BDropdownGroup']
    'BDropdownHeader': typeof import("bootstrap-vue-next")['BDropdownHeader']
    'BDropdownItem': typeof import("bootstrap-vue-next")['BDropdownItem']
    'BDropdownItemButton': typeof import("bootstrap-vue-next")['BDropdownItemButton']
    'BDropdownText': typeof import("bootstrap-vue-next")['BDropdownText']
    'BForm': typeof import("bootstrap-vue-next")['BForm']
    'BFormCheckbox': typeof import("bootstrap-vue-next")['BFormCheckbox']
    'BFormCheckboxGroup': typeof import("bootstrap-vue-next")['BFormCheckboxGroup']
    'BFormFile': typeof import("bootstrap-vue-next")['BFormFile']
    'BFormFloatingLabel': typeof import("bootstrap-vue-next")['BFormFloatingLabel']
    'BFormGroup': typeof import("bootstrap-vue-next")['BFormGroup']
    'BFormInput': typeof import("bootstrap-vue-next")['BFormInput']
    'BFormInvalidFeedback': typeof import("bootstrap-vue-next")['BFormInvalidFeedback']
    'BFormRadio': typeof import("bootstrap-vue-next")['BFormRadio']
    'BFormRadioGroup': typeof import("bootstrap-vue-next")['BFormRadioGroup']
    'BFormRow': typeof import("bootstrap-vue-next")['BFormRow']
    'BFormSelect': typeof import("bootstrap-vue-next")['BFormSelect']
    'BFormSelectOption': typeof import("bootstrap-vue-next")['BFormSelectOption']
    'BFormSelectOptionGroup': typeof import("bootstrap-vue-next")['BFormSelectOptionGroup']
    'BFormSpinbutton': typeof import("bootstrap-vue-next")['BFormSpinbutton']
    'BFormTag': typeof import("bootstrap-vue-next")['BFormTag']
    'BFormTags': typeof import("bootstrap-vue-next")['BFormTags']
    'BFormText': typeof import("bootstrap-vue-next")['BFormText']
    'BFormTextarea': typeof import("bootstrap-vue-next")['BFormTextarea']
    'BFormValidFeedback': typeof import("bootstrap-vue-next")['BFormValidFeedback']
    'BImg': typeof import("bootstrap-vue-next")['BImg']
    'BInputGroup': typeof import("bootstrap-vue-next")['BInputGroup']
    'BInputGroupAddon': typeof import("bootstrap-vue-next")['BInputGroupAddon']
    'BInputGroupAppend': typeof import("bootstrap-vue-next")['BInputGroupAppend']
    'BInputGroupPrepend': typeof import("bootstrap-vue-next")['BInputGroupPrepend']
    'BInputGroupText': typeof import("bootstrap-vue-next")['BInputGroupText']
    'BLink': typeof import("bootstrap-vue-next")['BLink']
    'BListGroup': typeof import("bootstrap-vue-next")['BListGroup']
    'BListGroupItem': typeof import("bootstrap-vue-next")['BListGroupItem']
    'BModal': typeof import("bootstrap-vue-next")['BModal']
    'BModalOrchestrator': typeof import("bootstrap-vue-next")['BModalOrchestrator']
    'BNav': typeof import("bootstrap-vue-next")['BNav']
    'BNavForm': typeof import("bootstrap-vue-next")['BNavForm']
    'BNavItem': typeof import("bootstrap-vue-next")['BNavItem']
    'BNavItemDropdown': typeof import("bootstrap-vue-next")['BNavItemDropdown']
    'BNavText': typeof import("bootstrap-vue-next")['BNavText']
    'BNavbar': typeof import("bootstrap-vue-next")['BNavbar']
    'BNavbarBrand': typeof import("bootstrap-vue-next")['BNavbarBrand']
    'BNavbarNav': typeof import("bootstrap-vue-next")['BNavbarNav']
    'BNavbarToggle': typeof import("bootstrap-vue-next")['BNavbarToggle']
    'BOffcanvas': typeof import("bootstrap-vue-next")['BOffcanvas']
    'BOverlay': typeof import("bootstrap-vue-next")['BOverlay']
    'BPagination': typeof import("bootstrap-vue-next")['BPagination']
    'BPlaceholder': typeof import("bootstrap-vue-next")['BPlaceholder']
    'BPlaceholderButton': typeof import("bootstrap-vue-next")['BPlaceholderButton']
    'BPlaceholderCard': typeof import("bootstrap-vue-next")['BPlaceholderCard']
    'BPlaceholderTable': typeof import("bootstrap-vue-next")['BPlaceholderTable']
    'BPlaceholderWrapper': typeof import("bootstrap-vue-next")['BPlaceholderWrapper']
    'BPopover': typeof import("bootstrap-vue-next")['BPopover']
    'BProgress': typeof import("bootstrap-vue-next")['BProgress']
    'BProgressBar': typeof import("bootstrap-vue-next")['BProgressBar']
    'BRow': typeof import("bootstrap-vue-next")['BRow']
    'BSpinner': typeof import("bootstrap-vue-next")['BSpinner']
    'BTab': typeof import("bootstrap-vue-next")['BTab']
    'BTable': typeof import("bootstrap-vue-next")['BTable']
    'BTableLite': typeof import("bootstrap-vue-next")['BTableLite']
    'BTableSimple': typeof import("bootstrap-vue-next")['BTableSimple']
    'BTabs': typeof import("bootstrap-vue-next")['BTabs']
    'BTbody': typeof import("bootstrap-vue-next")['BTbody']
    'BTd': typeof import("bootstrap-vue-next")['BTd']
    'BTfoot': typeof import("bootstrap-vue-next")['BTfoot']
    'BTh': typeof import("bootstrap-vue-next")['BTh']
    'BThead': typeof import("bootstrap-vue-next")['BThead']
    'BToast': typeof import("bootstrap-vue-next")['BToast']
    'BToastOrchestrator': typeof import("bootstrap-vue-next")['BToastOrchestrator']
    'BTooltip': typeof import("bootstrap-vue-next")['BTooltip']
    'BTr': typeof import("bootstrap-vue-next")['BTr']
    'BTransition': typeof import("bootstrap-vue-next")['BTransition']
    'NuxtPage': typeof import("../node_modules/nuxt/dist/pages/runtime/page")['default']
    'NoScript': typeof import("../node_modules/nuxt/dist/head/runtime/components")['NoScript']
    'Link': typeof import("../node_modules/nuxt/dist/head/runtime/components")['Link']
    'Base': typeof import("../node_modules/nuxt/dist/head/runtime/components")['Base']
    'Title': typeof import("../node_modules/nuxt/dist/head/runtime/components")['Title']
    'Meta': typeof import("../node_modules/nuxt/dist/head/runtime/components")['Meta']
    'Style': typeof import("../node_modules/nuxt/dist/head/runtime/components")['Style']
    'Head': typeof import("../node_modules/nuxt/dist/head/runtime/components")['Head']
    'Html': typeof import("../node_modules/nuxt/dist/head/runtime/components")['Html']
    'Body': typeof import("../node_modules/nuxt/dist/head/runtime/components")['Body']
    'NuxtIsland': typeof import("../node_modules/nuxt/dist/app/components/nuxt-island")['default']
    'NuxtRouteAnnouncer': typeof import("../node_modules/nuxt/dist/app/components/server-placeholder")['default']
      'LazyBackToTop': LazyComponent<typeof import("../components/BackToTop.vue")['default']>
    'LazyContact': LazyComponent<typeof import("../components/Contact.vue")['default']>
    'LazyCounter': LazyComponent<typeof import("../components/Counter.vue")['default']>
    'LazyCta': LazyComponent<typeof import("../components/Cta.vue")['default']>
    'LazyFaqs': LazyComponent<typeof import("../components/Faqs.vue")['default']>
    'LazyFeature1': LazyComponent<typeof import("../components/Feature1.vue")['default']>
    'LazyFeature2': LazyComponent<typeof import("../components/Feature2.vue")['default']>
    'LazyFooter': LazyComponent<typeof import("../components/Footer.vue")['default']>
    'LazyIndexNavbar': LazyComponent<typeof import("../components/IndexNavbar.vue")['default']>
    'LazyNavbar': LazyComponent<typeof import("../components/Navbar.vue")['default']>
    'LazyPricingCard': LazyComponent<typeof import("../components/PricingCard.vue")['default']>
    'LazyScreenSwiper': LazyComponent<typeof import("../components/ScreenSwiper.vue")['default']>
    'LazyTestimonial': LazyComponent<typeof import("../components/Testimonial.vue")['default']>
    'LazyWork': LazyComponent<typeof import("../components/Work.vue")['default']>
    'LazyHerosHero': LazyComponent<typeof import("../components/heros/Hero.vue")['default']>
    'LazyNuxtWelcome': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/welcome.vue")['default']>
    'LazyNuxtLayout': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-layout")['default']>
    'LazyNuxtErrorBoundary': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-error-boundary.vue")['default']>
    'LazyClientOnly': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/client-only")['default']>
    'LazyDevOnly': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/dev-only")['default']>
    'LazyServerPlaceholder': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/server-placeholder")['default']>
    'LazyNuxtLink': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-link")['default']>
    'LazyNuxtLoadingIndicator': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-loading-indicator")['default']>
    'LazyNuxtTime': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-time.vue")['default']>
    'LazyNuxtRouteAnnouncer': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-route-announcer")['default']>
    'LazyNuxtImg': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-stubs")['NuxtImg']>
    'LazyNuxtPicture': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-stubs")['NuxtPicture']>
    'LazyBAccordion': LazyComponent<typeof import("bootstrap-vue-next")['BAccordion']>
    'LazyBAccordionItem': LazyComponent<typeof import("bootstrap-vue-next")['BAccordionItem']>
    'LazyBAlert': LazyComponent<typeof import("bootstrap-vue-next")['BAlert']>
    'LazyBAvatar': LazyComponent<typeof import("bootstrap-vue-next")['BAvatar']>
    'LazyBAvatarGroup': LazyComponent<typeof import("bootstrap-vue-next")['BAvatarGroup']>
    'LazyBBadge': LazyComponent<typeof import("bootstrap-vue-next")['BBadge']>
    'LazyBBreadcrumb': LazyComponent<typeof import("bootstrap-vue-next")['BBreadcrumb']>
    'LazyBBreadcrumbItem': LazyComponent<typeof import("bootstrap-vue-next")['BBreadcrumbItem']>
    'LazyBButton': LazyComponent<typeof import("bootstrap-vue-next")['BButton']>
    'LazyBButtonGroup': LazyComponent<typeof import("bootstrap-vue-next")['BButtonGroup']>
    'LazyBButtonToolbar': LazyComponent<typeof import("bootstrap-vue-next")['BButtonToolbar']>
    'LazyBCard': LazyComponent<typeof import("bootstrap-vue-next")['BCard']>
    'LazyBCardBody': LazyComponent<typeof import("bootstrap-vue-next")['BCardBody']>
    'LazyBCardFooter': LazyComponent<typeof import("bootstrap-vue-next")['BCardFooter']>
    'LazyBCardGroup': LazyComponent<typeof import("bootstrap-vue-next")['BCardGroup']>
    'LazyBCardHeader': LazyComponent<typeof import("bootstrap-vue-next")['BCardHeader']>
    'LazyBCardImg': LazyComponent<typeof import("bootstrap-vue-next")['BCardImg']>
    'LazyBCardSubtitle': LazyComponent<typeof import("bootstrap-vue-next")['BCardSubtitle']>
    'LazyBCardText': LazyComponent<typeof import("bootstrap-vue-next")['BCardText']>
    'LazyBCardTitle': LazyComponent<typeof import("bootstrap-vue-next")['BCardTitle']>
    'LazyBCarousel': LazyComponent<typeof import("bootstrap-vue-next")['BCarousel']>
    'LazyBCarouselSlide': LazyComponent<typeof import("bootstrap-vue-next")['BCarouselSlide']>
    'LazyBCloseButton': LazyComponent<typeof import("bootstrap-vue-next")['BCloseButton']>
    'LazyBCol': LazyComponent<typeof import("bootstrap-vue-next")['BCol']>
    'LazyBCollapse': LazyComponent<typeof import("bootstrap-vue-next")['BCollapse']>
    'LazyBContainer': LazyComponent<typeof import("bootstrap-vue-next")['BContainer']>
    'LazyBDropdown': LazyComponent<typeof import("bootstrap-vue-next")['BDropdown']>
    'LazyBDropdownDivider': LazyComponent<typeof import("bootstrap-vue-next")['BDropdownDivider']>
    'LazyBDropdownForm': LazyComponent<typeof import("bootstrap-vue-next")['BDropdownForm']>
    'LazyBDropdownGroup': LazyComponent<typeof import("bootstrap-vue-next")['BDropdownGroup']>
    'LazyBDropdownHeader': LazyComponent<typeof import("bootstrap-vue-next")['BDropdownHeader']>
    'LazyBDropdownItem': LazyComponent<typeof import("bootstrap-vue-next")['BDropdownItem']>
    'LazyBDropdownItemButton': LazyComponent<typeof import("bootstrap-vue-next")['BDropdownItemButton']>
    'LazyBDropdownText': LazyComponent<typeof import("bootstrap-vue-next")['BDropdownText']>
    'LazyBForm': LazyComponent<typeof import("bootstrap-vue-next")['BForm']>
    'LazyBFormCheckbox': LazyComponent<typeof import("bootstrap-vue-next")['BFormCheckbox']>
    'LazyBFormCheckboxGroup': LazyComponent<typeof import("bootstrap-vue-next")['BFormCheckboxGroup']>
    'LazyBFormFile': LazyComponent<typeof import("bootstrap-vue-next")['BFormFile']>
    'LazyBFormFloatingLabel': LazyComponent<typeof import("bootstrap-vue-next")['BFormFloatingLabel']>
    'LazyBFormGroup': LazyComponent<typeof import("bootstrap-vue-next")['BFormGroup']>
    'LazyBFormInput': LazyComponent<typeof import("bootstrap-vue-next")['BFormInput']>
    'LazyBFormInvalidFeedback': LazyComponent<typeof import("bootstrap-vue-next")['BFormInvalidFeedback']>
    'LazyBFormRadio': LazyComponent<typeof import("bootstrap-vue-next")['BFormRadio']>
    'LazyBFormRadioGroup': LazyComponent<typeof import("bootstrap-vue-next")['BFormRadioGroup']>
    'LazyBFormRow': LazyComponent<typeof import("bootstrap-vue-next")['BFormRow']>
    'LazyBFormSelect': LazyComponent<typeof import("bootstrap-vue-next")['BFormSelect']>
    'LazyBFormSelectOption': LazyComponent<typeof import("bootstrap-vue-next")['BFormSelectOption']>
    'LazyBFormSelectOptionGroup': LazyComponent<typeof import("bootstrap-vue-next")['BFormSelectOptionGroup']>
    'LazyBFormSpinbutton': LazyComponent<typeof import("bootstrap-vue-next")['BFormSpinbutton']>
    'LazyBFormTag': LazyComponent<typeof import("bootstrap-vue-next")['BFormTag']>
    'LazyBFormTags': LazyComponent<typeof import("bootstrap-vue-next")['BFormTags']>
    'LazyBFormText': LazyComponent<typeof import("bootstrap-vue-next")['BFormText']>
    'LazyBFormTextarea': LazyComponent<typeof import("bootstrap-vue-next")['BFormTextarea']>
    'LazyBFormValidFeedback': LazyComponent<typeof import("bootstrap-vue-next")['BFormValidFeedback']>
    'LazyBImg': LazyComponent<typeof import("bootstrap-vue-next")['BImg']>
    'LazyBInputGroup': LazyComponent<typeof import("bootstrap-vue-next")['BInputGroup']>
    'LazyBInputGroupAddon': LazyComponent<typeof import("bootstrap-vue-next")['BInputGroupAddon']>
    'LazyBInputGroupAppend': LazyComponent<typeof import("bootstrap-vue-next")['BInputGroupAppend']>
    'LazyBInputGroupPrepend': LazyComponent<typeof import("bootstrap-vue-next")['BInputGroupPrepend']>
    'LazyBInputGroupText': LazyComponent<typeof import("bootstrap-vue-next")['BInputGroupText']>
    'LazyBLink': LazyComponent<typeof import("bootstrap-vue-next")['BLink']>
    'LazyBListGroup': LazyComponent<typeof import("bootstrap-vue-next")['BListGroup']>
    'LazyBListGroupItem': LazyComponent<typeof import("bootstrap-vue-next")['BListGroupItem']>
    'LazyBModal': LazyComponent<typeof import("bootstrap-vue-next")['BModal']>
    'LazyBModalOrchestrator': LazyComponent<typeof import("bootstrap-vue-next")['BModalOrchestrator']>
    'LazyBNav': LazyComponent<typeof import("bootstrap-vue-next")['BNav']>
    'LazyBNavForm': LazyComponent<typeof import("bootstrap-vue-next")['BNavForm']>
    'LazyBNavItem': LazyComponent<typeof import("bootstrap-vue-next")['BNavItem']>
    'LazyBNavItemDropdown': LazyComponent<typeof import("bootstrap-vue-next")['BNavItemDropdown']>
    'LazyBNavText': LazyComponent<typeof import("bootstrap-vue-next")['BNavText']>
    'LazyBNavbar': LazyComponent<typeof import("bootstrap-vue-next")['BNavbar']>
    'LazyBNavbarBrand': LazyComponent<typeof import("bootstrap-vue-next")['BNavbarBrand']>
    'LazyBNavbarNav': LazyComponent<typeof import("bootstrap-vue-next")['BNavbarNav']>
    'LazyBNavbarToggle': LazyComponent<typeof import("bootstrap-vue-next")['BNavbarToggle']>
    'LazyBOffcanvas': LazyComponent<typeof import("bootstrap-vue-next")['BOffcanvas']>
    'LazyBOverlay': LazyComponent<typeof import("bootstrap-vue-next")['BOverlay']>
    'LazyBPagination': LazyComponent<typeof import("bootstrap-vue-next")['BPagination']>
    'LazyBPlaceholder': LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholder']>
    'LazyBPlaceholderButton': LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholderButton']>
    'LazyBPlaceholderCard': LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholderCard']>
    'LazyBPlaceholderTable': LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholderTable']>
    'LazyBPlaceholderWrapper': LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholderWrapper']>
    'LazyBPopover': LazyComponent<typeof import("bootstrap-vue-next")['BPopover']>
    'LazyBProgress': LazyComponent<typeof import("bootstrap-vue-next")['BProgress']>
    'LazyBProgressBar': LazyComponent<typeof import("bootstrap-vue-next")['BProgressBar']>
    'LazyBRow': LazyComponent<typeof import("bootstrap-vue-next")['BRow']>
    'LazyBSpinner': LazyComponent<typeof import("bootstrap-vue-next")['BSpinner']>
    'LazyBTab': LazyComponent<typeof import("bootstrap-vue-next")['BTab']>
    'LazyBTable': LazyComponent<typeof import("bootstrap-vue-next")['BTable']>
    'LazyBTableLite': LazyComponent<typeof import("bootstrap-vue-next")['BTableLite']>
    'LazyBTableSimple': LazyComponent<typeof import("bootstrap-vue-next")['BTableSimple']>
    'LazyBTabs': LazyComponent<typeof import("bootstrap-vue-next")['BTabs']>
    'LazyBTbody': LazyComponent<typeof import("bootstrap-vue-next")['BTbody']>
    'LazyBTd': LazyComponent<typeof import("bootstrap-vue-next")['BTd']>
    'LazyBTfoot': LazyComponent<typeof import("bootstrap-vue-next")['BTfoot']>
    'LazyBTh': LazyComponent<typeof import("bootstrap-vue-next")['BTh']>
    'LazyBThead': LazyComponent<typeof import("bootstrap-vue-next")['BThead']>
    'LazyBToast': LazyComponent<typeof import("bootstrap-vue-next")['BToast']>
    'LazyBToastOrchestrator': LazyComponent<typeof import("bootstrap-vue-next")['BToastOrchestrator']>
    'LazyBTooltip': LazyComponent<typeof import("bootstrap-vue-next")['BTooltip']>
    'LazyBTr': LazyComponent<typeof import("bootstrap-vue-next")['BTr']>
    'LazyBTransition': LazyComponent<typeof import("bootstrap-vue-next")['BTransition']>
    'LazyNuxtPage': LazyComponent<typeof import("../node_modules/nuxt/dist/pages/runtime/page")['default']>
    'LazyNoScript': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['NoScript']>
    'LazyLink': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Link']>
    'LazyBase': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Base']>
    'LazyTitle': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Title']>
    'LazyMeta': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Meta']>
    'LazyStyle': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Style']>
    'LazyHead': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Head']>
    'LazyHtml': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Html']>
    'LazyBody': LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Body']>
    'LazyNuxtIsland': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-island")['default']>
    'LazyNuxtRouteAnnouncer': LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/server-placeholder")['default']>
}

declare module 'vue' {
  export interface GlobalComponents extends _GlobalComponents { }
}

export const BackToTop: typeof import("../components/BackToTop.vue")['default']
export const Contact: typeof import("../components/Contact.vue")['default']
export const Counter: typeof import("../components/Counter.vue")['default']
export const Cta: typeof import("../components/Cta.vue")['default']
export const Faqs: typeof import("../components/Faqs.vue")['default']
export const Feature1: typeof import("../components/Feature1.vue")['default']
export const Feature2: typeof import("../components/Feature2.vue")['default']
export const Footer: typeof import("../components/Footer.vue")['default']
export const IndexNavbar: typeof import("../components/IndexNavbar.vue")['default']
export const Navbar: typeof import("../components/Navbar.vue")['default']
export const PricingCard: typeof import("../components/PricingCard.vue")['default']
export const ScreenSwiper: typeof import("../components/ScreenSwiper.vue")['default']
export const Testimonial: typeof import("../components/Testimonial.vue")['default']
export const Work: typeof import("../components/Work.vue")['default']
export const HerosHero: typeof import("../components/heros/Hero.vue")['default']
export const NuxtWelcome: typeof import("../node_modules/nuxt/dist/app/components/welcome.vue")['default']
export const NuxtLayout: typeof import("../node_modules/nuxt/dist/app/components/nuxt-layout")['default']
export const NuxtErrorBoundary: typeof import("../node_modules/nuxt/dist/app/components/nuxt-error-boundary.vue")['default']
export const ClientOnly: typeof import("../node_modules/nuxt/dist/app/components/client-only")['default']
export const DevOnly: typeof import("../node_modules/nuxt/dist/app/components/dev-only")['default']
export const ServerPlaceholder: typeof import("../node_modules/nuxt/dist/app/components/server-placeholder")['default']
export const NuxtLink: typeof import("../node_modules/nuxt/dist/app/components/nuxt-link")['default']
export const NuxtLoadingIndicator: typeof import("../node_modules/nuxt/dist/app/components/nuxt-loading-indicator")['default']
export const NuxtTime: typeof import("../node_modules/nuxt/dist/app/components/nuxt-time.vue")['default']
export const NuxtRouteAnnouncer: typeof import("../node_modules/nuxt/dist/app/components/nuxt-route-announcer")['default']
export const NuxtImg: typeof import("../node_modules/nuxt/dist/app/components/nuxt-stubs")['NuxtImg']
export const NuxtPicture: typeof import("../node_modules/nuxt/dist/app/components/nuxt-stubs")['NuxtPicture']
export const BAccordion: typeof import("bootstrap-vue-next")['BAccordion']
export const BAccordionItem: typeof import("bootstrap-vue-next")['BAccordionItem']
export const BAlert: typeof import("bootstrap-vue-next")['BAlert']
export const BAvatar: typeof import("bootstrap-vue-next")['BAvatar']
export const BAvatarGroup: typeof import("bootstrap-vue-next")['BAvatarGroup']
export const BBadge: typeof import("bootstrap-vue-next")['BBadge']
export const BBreadcrumb: typeof import("bootstrap-vue-next")['BBreadcrumb']
export const BBreadcrumbItem: typeof import("bootstrap-vue-next")['BBreadcrumbItem']
export const BButton: typeof import("bootstrap-vue-next")['BButton']
export const BButtonGroup: typeof import("bootstrap-vue-next")['BButtonGroup']
export const BButtonToolbar: typeof import("bootstrap-vue-next")['BButtonToolbar']
export const BCard: typeof import("bootstrap-vue-next")['BCard']
export const BCardBody: typeof import("bootstrap-vue-next")['BCardBody']
export const BCardFooter: typeof import("bootstrap-vue-next")['BCardFooter']
export const BCardGroup: typeof import("bootstrap-vue-next")['BCardGroup']
export const BCardHeader: typeof import("bootstrap-vue-next")['BCardHeader']
export const BCardImg: typeof import("bootstrap-vue-next")['BCardImg']
export const BCardSubtitle: typeof import("bootstrap-vue-next")['BCardSubtitle']
export const BCardText: typeof import("bootstrap-vue-next")['BCardText']
export const BCardTitle: typeof import("bootstrap-vue-next")['BCardTitle']
export const BCarousel: typeof import("bootstrap-vue-next")['BCarousel']
export const BCarouselSlide: typeof import("bootstrap-vue-next")['BCarouselSlide']
export const BCloseButton: typeof import("bootstrap-vue-next")['BCloseButton']
export const BCol: typeof import("bootstrap-vue-next")['BCol']
export const BCollapse: typeof import("bootstrap-vue-next")['BCollapse']
export const BContainer: typeof import("bootstrap-vue-next")['BContainer']
export const BDropdown: typeof import("bootstrap-vue-next")['BDropdown']
export const BDropdownDivider: typeof import("bootstrap-vue-next")['BDropdownDivider']
export const BDropdownForm: typeof import("bootstrap-vue-next")['BDropdownForm']
export const BDropdownGroup: typeof import("bootstrap-vue-next")['BDropdownGroup']
export const BDropdownHeader: typeof import("bootstrap-vue-next")['BDropdownHeader']
export const BDropdownItem: typeof import("bootstrap-vue-next")['BDropdownItem']
export const BDropdownItemButton: typeof import("bootstrap-vue-next")['BDropdownItemButton']
export const BDropdownText: typeof import("bootstrap-vue-next")['BDropdownText']
export const BForm: typeof import("bootstrap-vue-next")['BForm']
export const BFormCheckbox: typeof import("bootstrap-vue-next")['BFormCheckbox']
export const BFormCheckboxGroup: typeof import("bootstrap-vue-next")['BFormCheckboxGroup']
export const BFormFile: typeof import("bootstrap-vue-next")['BFormFile']
export const BFormFloatingLabel: typeof import("bootstrap-vue-next")['BFormFloatingLabel']
export const BFormGroup: typeof import("bootstrap-vue-next")['BFormGroup']
export const BFormInput: typeof import("bootstrap-vue-next")['BFormInput']
export const BFormInvalidFeedback: typeof import("bootstrap-vue-next")['BFormInvalidFeedback']
export const BFormRadio: typeof import("bootstrap-vue-next")['BFormRadio']
export const BFormRadioGroup: typeof import("bootstrap-vue-next")['BFormRadioGroup']
export const BFormRow: typeof import("bootstrap-vue-next")['BFormRow']
export const BFormSelect: typeof import("bootstrap-vue-next")['BFormSelect']
export const BFormSelectOption: typeof import("bootstrap-vue-next")['BFormSelectOption']
export const BFormSelectOptionGroup: typeof import("bootstrap-vue-next")['BFormSelectOptionGroup']
export const BFormSpinbutton: typeof import("bootstrap-vue-next")['BFormSpinbutton']
export const BFormTag: typeof import("bootstrap-vue-next")['BFormTag']
export const BFormTags: typeof import("bootstrap-vue-next")['BFormTags']
export const BFormText: typeof import("bootstrap-vue-next")['BFormText']
export const BFormTextarea: typeof import("bootstrap-vue-next")['BFormTextarea']
export const BFormValidFeedback: typeof import("bootstrap-vue-next")['BFormValidFeedback']
export const BImg: typeof import("bootstrap-vue-next")['BImg']
export const BInputGroup: typeof import("bootstrap-vue-next")['BInputGroup']
export const BInputGroupAddon: typeof import("bootstrap-vue-next")['BInputGroupAddon']
export const BInputGroupAppend: typeof import("bootstrap-vue-next")['BInputGroupAppend']
export const BInputGroupPrepend: typeof import("bootstrap-vue-next")['BInputGroupPrepend']
export const BInputGroupText: typeof import("bootstrap-vue-next")['BInputGroupText']
export const BLink: typeof import("bootstrap-vue-next")['BLink']
export const BListGroup: typeof import("bootstrap-vue-next")['BListGroup']
export const BListGroupItem: typeof import("bootstrap-vue-next")['BListGroupItem']
export const BModal: typeof import("bootstrap-vue-next")['BModal']
export const BModalOrchestrator: typeof import("bootstrap-vue-next")['BModalOrchestrator']
export const BNav: typeof import("bootstrap-vue-next")['BNav']
export const BNavForm: typeof import("bootstrap-vue-next")['BNavForm']
export const BNavItem: typeof import("bootstrap-vue-next")['BNavItem']
export const BNavItemDropdown: typeof import("bootstrap-vue-next")['BNavItemDropdown']
export const BNavText: typeof import("bootstrap-vue-next")['BNavText']
export const BNavbar: typeof import("bootstrap-vue-next")['BNavbar']
export const BNavbarBrand: typeof import("bootstrap-vue-next")['BNavbarBrand']
export const BNavbarNav: typeof import("bootstrap-vue-next")['BNavbarNav']
export const BNavbarToggle: typeof import("bootstrap-vue-next")['BNavbarToggle']
export const BOffcanvas: typeof import("bootstrap-vue-next")['BOffcanvas']
export const BOverlay: typeof import("bootstrap-vue-next")['BOverlay']
export const BPagination: typeof import("bootstrap-vue-next")['BPagination']
export const BPlaceholder: typeof import("bootstrap-vue-next")['BPlaceholder']
export const BPlaceholderButton: typeof import("bootstrap-vue-next")['BPlaceholderButton']
export const BPlaceholderCard: typeof import("bootstrap-vue-next")['BPlaceholderCard']
export const BPlaceholderTable: typeof import("bootstrap-vue-next")['BPlaceholderTable']
export const BPlaceholderWrapper: typeof import("bootstrap-vue-next")['BPlaceholderWrapper']
export const BPopover: typeof import("bootstrap-vue-next")['BPopover']
export const BProgress: typeof import("bootstrap-vue-next")['BProgress']
export const BProgressBar: typeof import("bootstrap-vue-next")['BProgressBar']
export const BRow: typeof import("bootstrap-vue-next")['BRow']
export const BSpinner: typeof import("bootstrap-vue-next")['BSpinner']
export const BTab: typeof import("bootstrap-vue-next")['BTab']
export const BTable: typeof import("bootstrap-vue-next")['BTable']
export const BTableLite: typeof import("bootstrap-vue-next")['BTableLite']
export const BTableSimple: typeof import("bootstrap-vue-next")['BTableSimple']
export const BTabs: typeof import("bootstrap-vue-next")['BTabs']
export const BTbody: typeof import("bootstrap-vue-next")['BTbody']
export const BTd: typeof import("bootstrap-vue-next")['BTd']
export const BTfoot: typeof import("bootstrap-vue-next")['BTfoot']
export const BTh: typeof import("bootstrap-vue-next")['BTh']
export const BThead: typeof import("bootstrap-vue-next")['BThead']
export const BToast: typeof import("bootstrap-vue-next")['BToast']
export const BToastOrchestrator: typeof import("bootstrap-vue-next")['BToastOrchestrator']
export const BTooltip: typeof import("bootstrap-vue-next")['BTooltip']
export const BTr: typeof import("bootstrap-vue-next")['BTr']
export const BTransition: typeof import("bootstrap-vue-next")['BTransition']
export const NuxtPage: typeof import("../node_modules/nuxt/dist/pages/runtime/page")['default']
export const NoScript: typeof import("../node_modules/nuxt/dist/head/runtime/components")['NoScript']
export const Link: typeof import("../node_modules/nuxt/dist/head/runtime/components")['Link']
export const Base: typeof import("../node_modules/nuxt/dist/head/runtime/components")['Base']
export const Title: typeof import("../node_modules/nuxt/dist/head/runtime/components")['Title']
export const Meta: typeof import("../node_modules/nuxt/dist/head/runtime/components")['Meta']
export const Style: typeof import("../node_modules/nuxt/dist/head/runtime/components")['Style']
export const Head: typeof import("../node_modules/nuxt/dist/head/runtime/components")['Head']
export const Html: typeof import("../node_modules/nuxt/dist/head/runtime/components")['Html']
export const Body: typeof import("../node_modules/nuxt/dist/head/runtime/components")['Body']
export const NuxtIsland: typeof import("../node_modules/nuxt/dist/app/components/nuxt-island")['default']
export const NuxtRouteAnnouncer: typeof import("../node_modules/nuxt/dist/app/components/server-placeholder")['default']
export const LazyBackToTop: LazyComponent<typeof import("../components/BackToTop.vue")['default']>
export const LazyContact: LazyComponent<typeof import("../components/Contact.vue")['default']>
export const LazyCounter: LazyComponent<typeof import("../components/Counter.vue")['default']>
export const LazyCta: LazyComponent<typeof import("../components/Cta.vue")['default']>
export const LazyFaqs: LazyComponent<typeof import("../components/Faqs.vue")['default']>
export const LazyFeature1: LazyComponent<typeof import("../components/Feature1.vue")['default']>
export const LazyFeature2: LazyComponent<typeof import("../components/Feature2.vue")['default']>
export const LazyFooter: LazyComponent<typeof import("../components/Footer.vue")['default']>
export const LazyIndexNavbar: LazyComponent<typeof import("../components/IndexNavbar.vue")['default']>
export const LazyNavbar: LazyComponent<typeof import("../components/Navbar.vue")['default']>
export const LazyPricingCard: LazyComponent<typeof import("../components/PricingCard.vue")['default']>
export const LazyScreenSwiper: LazyComponent<typeof import("../components/ScreenSwiper.vue")['default']>
export const LazyTestimonial: LazyComponent<typeof import("../components/Testimonial.vue")['default']>
export const LazyWork: LazyComponent<typeof import("../components/Work.vue")['default']>
export const LazyHerosHero: LazyComponent<typeof import("../components/heros/Hero.vue")['default']>
export const LazyNuxtWelcome: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/welcome.vue")['default']>
export const LazyNuxtLayout: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-layout")['default']>
export const LazyNuxtErrorBoundary: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-error-boundary.vue")['default']>
export const LazyClientOnly: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/client-only")['default']>
export const LazyDevOnly: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/dev-only")['default']>
export const LazyServerPlaceholder: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/server-placeholder")['default']>
export const LazyNuxtLink: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-link")['default']>
export const LazyNuxtLoadingIndicator: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-loading-indicator")['default']>
export const LazyNuxtTime: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-time.vue")['default']>
export const LazyNuxtRouteAnnouncer: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-route-announcer")['default']>
export const LazyNuxtImg: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-stubs")['NuxtImg']>
export const LazyNuxtPicture: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-stubs")['NuxtPicture']>
export const LazyBAccordion: LazyComponent<typeof import("bootstrap-vue-next")['BAccordion']>
export const LazyBAccordionItem: LazyComponent<typeof import("bootstrap-vue-next")['BAccordionItem']>
export const LazyBAlert: LazyComponent<typeof import("bootstrap-vue-next")['BAlert']>
export const LazyBAvatar: LazyComponent<typeof import("bootstrap-vue-next")['BAvatar']>
export const LazyBAvatarGroup: LazyComponent<typeof import("bootstrap-vue-next")['BAvatarGroup']>
export const LazyBBadge: LazyComponent<typeof import("bootstrap-vue-next")['BBadge']>
export const LazyBBreadcrumb: LazyComponent<typeof import("bootstrap-vue-next")['BBreadcrumb']>
export const LazyBBreadcrumbItem: LazyComponent<typeof import("bootstrap-vue-next")['BBreadcrumbItem']>
export const LazyBButton: LazyComponent<typeof import("bootstrap-vue-next")['BButton']>
export const LazyBButtonGroup: LazyComponent<typeof import("bootstrap-vue-next")['BButtonGroup']>
export const LazyBButtonToolbar: LazyComponent<typeof import("bootstrap-vue-next")['BButtonToolbar']>
export const LazyBCard: LazyComponent<typeof import("bootstrap-vue-next")['BCard']>
export const LazyBCardBody: LazyComponent<typeof import("bootstrap-vue-next")['BCardBody']>
export const LazyBCardFooter: LazyComponent<typeof import("bootstrap-vue-next")['BCardFooter']>
export const LazyBCardGroup: LazyComponent<typeof import("bootstrap-vue-next")['BCardGroup']>
export const LazyBCardHeader: LazyComponent<typeof import("bootstrap-vue-next")['BCardHeader']>
export const LazyBCardImg: LazyComponent<typeof import("bootstrap-vue-next")['BCardImg']>
export const LazyBCardSubtitle: LazyComponent<typeof import("bootstrap-vue-next")['BCardSubtitle']>
export const LazyBCardText: LazyComponent<typeof import("bootstrap-vue-next")['BCardText']>
export const LazyBCardTitle: LazyComponent<typeof import("bootstrap-vue-next")['BCardTitle']>
export const LazyBCarousel: LazyComponent<typeof import("bootstrap-vue-next")['BCarousel']>
export const LazyBCarouselSlide: LazyComponent<typeof import("bootstrap-vue-next")['BCarouselSlide']>
export const LazyBCloseButton: LazyComponent<typeof import("bootstrap-vue-next")['BCloseButton']>
export const LazyBCol: LazyComponent<typeof import("bootstrap-vue-next")['BCol']>
export const LazyBCollapse: LazyComponent<typeof import("bootstrap-vue-next")['BCollapse']>
export const LazyBContainer: LazyComponent<typeof import("bootstrap-vue-next")['BContainer']>
export const LazyBDropdown: LazyComponent<typeof import("bootstrap-vue-next")['BDropdown']>
export const LazyBDropdownDivider: LazyComponent<typeof import("bootstrap-vue-next")['BDropdownDivider']>
export const LazyBDropdownForm: LazyComponent<typeof import("bootstrap-vue-next")['BDropdownForm']>
export const LazyBDropdownGroup: LazyComponent<typeof import("bootstrap-vue-next")['BDropdownGroup']>
export const LazyBDropdownHeader: LazyComponent<typeof import("bootstrap-vue-next")['BDropdownHeader']>
export const LazyBDropdownItem: LazyComponent<typeof import("bootstrap-vue-next")['BDropdownItem']>
export const LazyBDropdownItemButton: LazyComponent<typeof import("bootstrap-vue-next")['BDropdownItemButton']>
export const LazyBDropdownText: LazyComponent<typeof import("bootstrap-vue-next")['BDropdownText']>
export const LazyBForm: LazyComponent<typeof import("bootstrap-vue-next")['BForm']>
export const LazyBFormCheckbox: LazyComponent<typeof import("bootstrap-vue-next")['BFormCheckbox']>
export const LazyBFormCheckboxGroup: LazyComponent<typeof import("bootstrap-vue-next")['BFormCheckboxGroup']>
export const LazyBFormFile: LazyComponent<typeof import("bootstrap-vue-next")['BFormFile']>
export const LazyBFormFloatingLabel: LazyComponent<typeof import("bootstrap-vue-next")['BFormFloatingLabel']>
export const LazyBFormGroup: LazyComponent<typeof import("bootstrap-vue-next")['BFormGroup']>
export const LazyBFormInput: LazyComponent<typeof import("bootstrap-vue-next")['BFormInput']>
export const LazyBFormInvalidFeedback: LazyComponent<typeof import("bootstrap-vue-next")['BFormInvalidFeedback']>
export const LazyBFormRadio: LazyComponent<typeof import("bootstrap-vue-next")['BFormRadio']>
export const LazyBFormRadioGroup: LazyComponent<typeof import("bootstrap-vue-next")['BFormRadioGroup']>
export const LazyBFormRow: LazyComponent<typeof import("bootstrap-vue-next")['BFormRow']>
export const LazyBFormSelect: LazyComponent<typeof import("bootstrap-vue-next")['BFormSelect']>
export const LazyBFormSelectOption: LazyComponent<typeof import("bootstrap-vue-next")['BFormSelectOption']>
export const LazyBFormSelectOptionGroup: LazyComponent<typeof import("bootstrap-vue-next")['BFormSelectOptionGroup']>
export const LazyBFormSpinbutton: LazyComponent<typeof import("bootstrap-vue-next")['BFormSpinbutton']>
export const LazyBFormTag: LazyComponent<typeof import("bootstrap-vue-next")['BFormTag']>
export const LazyBFormTags: LazyComponent<typeof import("bootstrap-vue-next")['BFormTags']>
export const LazyBFormText: LazyComponent<typeof import("bootstrap-vue-next")['BFormText']>
export const LazyBFormTextarea: LazyComponent<typeof import("bootstrap-vue-next")['BFormTextarea']>
export const LazyBFormValidFeedback: LazyComponent<typeof import("bootstrap-vue-next")['BFormValidFeedback']>
export const LazyBImg: LazyComponent<typeof import("bootstrap-vue-next")['BImg']>
export const LazyBInputGroup: LazyComponent<typeof import("bootstrap-vue-next")['BInputGroup']>
export const LazyBInputGroupAddon: LazyComponent<typeof import("bootstrap-vue-next")['BInputGroupAddon']>
export const LazyBInputGroupAppend: LazyComponent<typeof import("bootstrap-vue-next")['BInputGroupAppend']>
export const LazyBInputGroupPrepend: LazyComponent<typeof import("bootstrap-vue-next")['BInputGroupPrepend']>
export const LazyBInputGroupText: LazyComponent<typeof import("bootstrap-vue-next")['BInputGroupText']>
export const LazyBLink: LazyComponent<typeof import("bootstrap-vue-next")['BLink']>
export const LazyBListGroup: LazyComponent<typeof import("bootstrap-vue-next")['BListGroup']>
export const LazyBListGroupItem: LazyComponent<typeof import("bootstrap-vue-next")['BListGroupItem']>
export const LazyBModal: LazyComponent<typeof import("bootstrap-vue-next")['BModal']>
export const LazyBModalOrchestrator: LazyComponent<typeof import("bootstrap-vue-next")['BModalOrchestrator']>
export const LazyBNav: LazyComponent<typeof import("bootstrap-vue-next")['BNav']>
export const LazyBNavForm: LazyComponent<typeof import("bootstrap-vue-next")['BNavForm']>
export const LazyBNavItem: LazyComponent<typeof import("bootstrap-vue-next")['BNavItem']>
export const LazyBNavItemDropdown: LazyComponent<typeof import("bootstrap-vue-next")['BNavItemDropdown']>
export const LazyBNavText: LazyComponent<typeof import("bootstrap-vue-next")['BNavText']>
export const LazyBNavbar: LazyComponent<typeof import("bootstrap-vue-next")['BNavbar']>
export const LazyBNavbarBrand: LazyComponent<typeof import("bootstrap-vue-next")['BNavbarBrand']>
export const LazyBNavbarNav: LazyComponent<typeof import("bootstrap-vue-next")['BNavbarNav']>
export const LazyBNavbarToggle: LazyComponent<typeof import("bootstrap-vue-next")['BNavbarToggle']>
export const LazyBOffcanvas: LazyComponent<typeof import("bootstrap-vue-next")['BOffcanvas']>
export const LazyBOverlay: LazyComponent<typeof import("bootstrap-vue-next")['BOverlay']>
export const LazyBPagination: LazyComponent<typeof import("bootstrap-vue-next")['BPagination']>
export const LazyBPlaceholder: LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholder']>
export const LazyBPlaceholderButton: LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholderButton']>
export const LazyBPlaceholderCard: LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholderCard']>
export const LazyBPlaceholderTable: LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholderTable']>
export const LazyBPlaceholderWrapper: LazyComponent<typeof import("bootstrap-vue-next")['BPlaceholderWrapper']>
export const LazyBPopover: LazyComponent<typeof import("bootstrap-vue-next")['BPopover']>
export const LazyBProgress: LazyComponent<typeof import("bootstrap-vue-next")['BProgress']>
export const LazyBProgressBar: LazyComponent<typeof import("bootstrap-vue-next")['BProgressBar']>
export const LazyBRow: LazyComponent<typeof import("bootstrap-vue-next")['BRow']>
export const LazyBSpinner: LazyComponent<typeof import("bootstrap-vue-next")['BSpinner']>
export const LazyBTab: LazyComponent<typeof import("bootstrap-vue-next")['BTab']>
export const LazyBTable: LazyComponent<typeof import("bootstrap-vue-next")['BTable']>
export const LazyBTableLite: LazyComponent<typeof import("bootstrap-vue-next")['BTableLite']>
export const LazyBTableSimple: LazyComponent<typeof import("bootstrap-vue-next")['BTableSimple']>
export const LazyBTabs: LazyComponent<typeof import("bootstrap-vue-next")['BTabs']>
export const LazyBTbody: LazyComponent<typeof import("bootstrap-vue-next")['BTbody']>
export const LazyBTd: LazyComponent<typeof import("bootstrap-vue-next")['BTd']>
export const LazyBTfoot: LazyComponent<typeof import("bootstrap-vue-next")['BTfoot']>
export const LazyBTh: LazyComponent<typeof import("bootstrap-vue-next")['BTh']>
export const LazyBThead: LazyComponent<typeof import("bootstrap-vue-next")['BThead']>
export const LazyBToast: LazyComponent<typeof import("bootstrap-vue-next")['BToast']>
export const LazyBToastOrchestrator: LazyComponent<typeof import("bootstrap-vue-next")['BToastOrchestrator']>
export const LazyBTooltip: LazyComponent<typeof import("bootstrap-vue-next")['BTooltip']>
export const LazyBTr: LazyComponent<typeof import("bootstrap-vue-next")['BTr']>
export const LazyBTransition: LazyComponent<typeof import("bootstrap-vue-next")['BTransition']>
export const LazyNuxtPage: LazyComponent<typeof import("../node_modules/nuxt/dist/pages/runtime/page")['default']>
export const LazyNoScript: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['NoScript']>
export const LazyLink: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Link']>
export const LazyBase: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Base']>
export const LazyTitle: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Title']>
export const LazyMeta: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Meta']>
export const LazyStyle: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Style']>
export const LazyHead: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Head']>
export const LazyHtml: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Html']>
export const LazyBody: LazyComponent<typeof import("../node_modules/nuxt/dist/head/runtime/components")['Body']>
export const LazyNuxtIsland: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/nuxt-island")['default']>
export const LazyNuxtRouteAnnouncer: LazyComponent<typeof import("../node_modules/nuxt/dist/app/components/server-placeholder")['default']>

export const componentNames: string[]
