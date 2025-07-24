<script setup lang="ts">
import { useAppOptionStore } from '@/stores/app-option';
import { useAppVariableStore, generateVariables } from '@/stores/app-variable';
import { onMounted } from 'vue';
import { Tooltip } from 'bootstrap';
import useEmitter from '@/composables/useEmitter';

const appOption = useAppOptionStore();
const appVariable = useAppVariableStore();
const emitter = useEmitter();

var themeList = [
	{ name: 'Festero Laranja', bgClass: 'bg-warning', themeClass: 'theme-warning' },
	{ name: 'Festero Azul', bgClass: 'bg-primary', themeClass: 'theme-primary' },
	{ name: 'Festero Preto', bgClass: 'bg-dark', themeClass: 'theme-dark' },
	{ name: 'Festero Verde', bgClass: 'bg-success', themeClass: 'theme-success' },
	{ name: 'Padrão', bgClass: 'bg-teal', themeClass: 'theme-teal' }
];

function reloadVariable() {
	var newVariables = generateVariables();
	appVariable.font = newVariables.font;
	appVariable.color = newVariables.color;
}

function appThemePanelToggled(event) {
	event.preventDefault();

	appOption.appThemePanelToggled = (appOption.appThemePanelToggled) ? '' : true;
	if (localStorage) {
		localStorage.appThemePanelToggled = appOption.appThemePanelToggled;
	}
}

function toggleTheme(event, themeClass) {
	event.preventDefault();

	appOption.appThemeClass = themeClass;

	if (localStorage) {
		localStorage.appThemeClass = appOption.appThemeClass;
	}
	setThemeClass(localStorage.appThemeClass);
}

function setThemeClass(themeClass) {
	for (var x = 0; x < document.body.classList.length; x++) {
		var targetClass = document.body.classList[x];
		if (targetClass.search('theme-') > -1) {
			document.body.classList.remove(targetClass);
		}
	}
	document.body.classList.add(themeClass);
	appVariable.color.theme = (getComputedStyle(document.body).getPropertyValue('--bs-app-theme')).trim();
	appVariable.color.themeRgb = (getComputedStyle(document.body).getPropertyValue('--bs-app-theme-rgb')).trim();

	emitter.emit('theme-reload', true);
}

function toggleDarkMode() {
	if (localStorage) {
		localStorage.appDarkMode = appOption.appDarkMode;
	}
	setDarkMode(localStorage.appDarkMode);
}

function setDarkMode(darkMode) {
	if (darkMode == 'true') {
		document.querySelector('html').setAttribute('data-bs-theme', 'dark');
	} else {
		document.querySelector('html').removeAttribute('data-bs-theme');
	}
	reloadVariable();
	emitter.emit('theme-reload', true);
}

function toggleHeaderFixed() {
	if (!appOption.appHeaderFixed && appOption.appSidebarFixed) {
		appOption.appSidebarFixed = false;
		localStorage.appSidebarFixed = appOption.appSidebarFixed;
		alert('Default Header with Fixed Sidebar option is not supported. Proceed with Default Header with Default Sidebar.');
	}
	if (localStorage) {
		localStorage.appHeaderFixed = appOption.appHeaderFixed;
	}
}

function toggleHeaderInverse() {
	if (localStorage) {
		localStorage.appHeaderInverse = appOption.appHeaderInverse;
	}
}

function toggleSidebarFixed() {
	if (!appOption.appHeaderFixed && appOption.appSidebarFixed) {
		appOption.appHeaderFixed = true;
		localStorage.appHeaderFixed = appOption.appHeaderFixed;
		alert('Default Header with Fixed Sidebar option is not supported. Proceed with Fixed Header with Fixed Sidebar.');
	}
	if (localStorage) {
		localStorage.appSidebarFixed = appOption.appSidebarFixed;
	}
}

function toggleSidebarGrid() {
	if (localStorage) {
		localStorage.appSidebarGrid = appOption.appSidebarGrid;
	}
}

function toggleGradientEnabled() {
	if (localStorage) {
		localStorage.appGradientEnabled = appOption.appGradientEnabled;
	}
}

function toggleRtlEnabled() {
	if (appOption.appRtlEnabled) {
		document.documentElement.setAttribute('dir', 'rtl');
	} else {
		document.documentElement.removeAttribute('dir');
	}

	if (localStorage) {
		localStorage.appRtlEnabled = appOption.appRtlEnabled;
	}
}

onMounted(() => {
	var elm = document.querySelectorAll('[data-bs-toggle="tooltip"]');

	for (var i = 0; i < elm.length; i++) {
		new Tooltip(elm[i]);
	}

	if (localStorage) {
		if (typeof localStorage.appThemePanelToggled !== 'undefined') {
			appOption.appThemePanelToggled = localStorage.appThemePanelToggled;
		}
		if (typeof localStorage.appThemeClass !== 'undefined') {
			appOption.appThemeClass = localStorage.appThemeClass;
			setThemeClass(localStorage.appThemeClass);
		}
		if (typeof localStorage.appDarkMode !== 'undefined') {
			appOption.appDarkMode = localStorage.appDarkMode;
			setDarkMode(appOption.appDarkMode);
		}
		if (typeof localStorage.appHeaderInverse !== 'undefined') {
			appOption.appHeaderInverse = localStorage.appHeaderInverse;
		}
		if (typeof localStorage.appHeaderFixed !== 'undefined') {
			appOption.appHeaderFixed = localStorage.appHeaderFixed;
		}
		if (typeof localStorage.appSidebarFixed !== 'undefined') {
			appOption.appSidebarFixed = localStorage.appSidebarFixed;
		}
		if (typeof appSidebarGrid.appHeaderInverse !== 'undefined') {
			appOption.appSidebarGrid = localStorage.appSidebarGrid;
		}
		if (typeof localStorage.appGradientEnabled !== 'undefined') {
			appOption.appGradientEnabled = localStorage.appGradientEnabled;
		}
		if (typeof localStorage.appRtlEnabled !== 'undefined') {
			appOption.appRtlEnabled = localStorage.appRtlEnabled === 'true';
			toggleRtlEnabled();
		}
	}
});

</script>
<template>
	<!-- BEGIN theme-panel -->
	<div class="theme-panel" v-bind:class="{ 'active': appOption.appThemePanelToggled }">
		<a href="javascript:;" v-on:click="appThemePanelToggled" class="theme-collapse-btn"><i
				class="fa fa-cog"></i></a>
		<perfect-scrollbar class="theme-panel-content h-100">
			<h5>Configurações da Aplicação</h5>

			<!-- BEGIN theme-list -->
			<div class="theme-list">
				<div class="theme-list-item"
					v-bind:class="{ 'active': appOption.appThemeClass == theme.themeClass || (!appOption.appThemeClass && theme.name == 'Default') }"
					v-for="theme in themeList">
					<a href="javascript:;" class="theme-list-link" v-bind:class="theme.bgClass"
						v-on:click="(event) => toggleTheme(event, theme.themeClass)" data-bs-toggle="tooltip"
						data-bs-trigger="hover" data-bs-container="body" v-bind:data-bs-title="theme.name">&nbsp;</a>
				</div>
			</div>
			<!-- END theme-list -->

			<div class="theme-panel-divider"></div>

			<div class="row mt-10px">
				<div class="col-8 control-label text-dark fw-bold">
					<div class="d-flex">Dark Mode
					</div>
					<div class="lh-14">
						<small class="text-dark opacity-50">
							Ajuste a aparência para reduzir o brilho e dar um descanso aos seus olhos.
						</small>
					</div>
				</div>
				<div class="col-4 d-flex">
					<div class="form-check form-switch ms-auto mb-0">
						<input type="checkbox" class="form-check-input" v-on:change="toggleDarkMode()"
							v-model="appOption.appDarkMode" true-value="true" false-value="" />
						<label class="form-check-label" for="appThemeDarkMode">&nbsp;</label>
					</div>
				</div>
			</div>

			<div class="theme-panel-divider"></div>

			<!-- BEGIN theme-switch -->
			<div class="row mt-10px align-items-center">
				<div class="col-8 control-label text-dark fw-bold">Header Fixed</div>
				<div class="col-4 d-flex">
					<div class="form-check form-switch ms-auto mb-0">
						<input type="checkbox" class="form-check-input" id="appHeaderFixed"
							v-on:change="toggleHeaderFixed()" v-model="appOption.appHeaderFixed" true-value="true"
							false-value="" />
						<label class="form-check-label" for="appHeaderFixed">&nbsp;</label>
					</div>
				</div>
			</div>
			<div class="row mt-10px align-items-center">
				<div class="col-8 control-label text-dark fw-bold">Header Inverse</div>
				<div class="col-4 d-flex">
					<div class="form-check form-switch ms-auto mb-0">
						<input type="checkbox" class="form-check-input" id="appHeaderInverse"
							v-on:change="toggleHeaderInverse()" v-model="appOption.appHeaderInverse" true-value="true"
							false-value="" />
						<label class="form-check-label" for="appHeaderInverse">&nbsp;</label>
					</div>
				</div>
			</div>
			<div class="row mt-10px align-items-center">
				<div class="col-8 control-label text-dark fw-bold">Sidebar Fixed</div>
				<div class="col-4 d-flex">
					<div class="form-check form-switch ms-auto mb-0">
						<input type="checkbox" class="form-check-input" id="appSidebarFixed"
							v-on:change="toggleSidebarFixed()" v-model="appOption.appSidebarFixed" true-value="true"
							false-value="" />
						<label class="form-check-label" for="appSidebarFixed">&nbsp;</label>
					</div>
				</div>
			</div>
			<div class="row mt-10px align-items-center">
				<div class="col-8 control-label text-dark fw-bold">Sidebar Grid</div>
				<div class="col-4 d-flex">
					<div class="form-check form-switch ms-auto mb-0">
						<input type="checkbox" class="form-check-input" id="appSidebarGrid"
							v-on:change="toggleSidebarGrid()" v-model="appOption.appSidebarGrid" true-value="true"
							false-value="" />
						<label class="form-check-label" for="appSidebarGrid">&nbsp;</label>
					</div>
				</div>
			</div>
			<div class="row mt-10px align-items-center">
				<div class="col-md-8 control-label text-dark fw-bold">Gradient Enabled</div>
				<div class="col-md-4 d-flex">
					<div class="form-check form-switch ms-auto mb-0">
						<input type="checkbox" class="form-check-input" id="appGradientEnabled"
							v-on:change="toggleGradientEnabled()" v-model="appOption.appGradientEnabled"
							true-value="true" false-value="" />
						<label class="form-check-label" for="appGradientEnabled">&nbsp;</label>
					</div>
				</div>
			</div>
			<div class="row mt-10px align-items-center">
				<div class="col-md-8 control-label text-dark fw-bold d-flex">RTL Enabled <span
						class="badge bg-primary ms-1 position-relative d-flex align-items-center">Novo</span></div>
				<div class="col-md-4 d-flex">
					<div class="form-check form-switch ms-auto mb-0">
						<input type="checkbox" class="form-check-input" id="appRtlEnabled"
							v-on:change="toggleRtlEnabled()" v-model="appOption.appRtlEnabled" true-value="true"
							false-value="" />
						<label class="form-check-label" for="appRtlEnabled">&nbsp;</label>
					</div>
				</div>
			</div>
			<!-- END theme-switch -->
		</perfect-scrollbar>
	</div>
	<!-- END theme-panel -->
</template>
