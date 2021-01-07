<template>
  <div class="my-vaults-component">
    <h5>
      {{ vaults.name }}
    </h5>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'MyVaultsComponent',
  props: ['vaultProp'],
  setup(props) {
    const state = reactive({})
    return {
      state,
      profile: computed(() => AppState.profile),
      vaults: computed(() => props.vaultProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
