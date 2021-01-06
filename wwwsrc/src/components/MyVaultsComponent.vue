<template>
  <div class="my-vaults-component">
    <h5>{{ vaults }}</h5>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'MyVaultsComponent',
  props: ['VaultProp'],
  setup(props) {
    const state = reactive({})
    return {
      state,
      vaults: computed(() => props.VaultProp),
      profile: computed(() => AppState.activeProfile),
      myvaults: computed(() => AppState.myvaults)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
