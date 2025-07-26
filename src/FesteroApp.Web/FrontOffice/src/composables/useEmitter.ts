import { getCurrentInstance } from 'vue';
import type { Emitter } from 'mitt';
import type { Events } from '@/modules/auth/store/types'; 

export default function useEmitter(): Emitter<Events> {
  const internalInstance = getCurrentInstance();

  if (!internalInstance) {
    throw new Error('useEmitter must be called within setup()');
  }

  return internalInstance.appContext.config.globalProperties.emitter;
}
