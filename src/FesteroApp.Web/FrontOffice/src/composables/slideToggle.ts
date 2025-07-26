import { slideUp } from '@/composables/slideUp';
import { slideDown } from '@/composables/slideDown';

/**
 * Alterna a visibilidade de um elemento com animação de slide.
 *
 * @param elm - Elemento HTML alvo
 * @param duration - Duração da animação em milissegundos (padrão: 300)
 */
export function slideToggle(elm: HTMLElement, duration: number = 300): void {
  const display = window.getComputedStyle(elm).display;

  if (display === 'none') {
    slideDown(elm, duration);
  } else {
    slideUp(elm, duration);
  }
}
