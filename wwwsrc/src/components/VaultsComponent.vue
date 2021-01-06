<template>
  <div class="vaults-component">
    <div class="col-4">
      <div class="card vault-card" style="width: 18rem;">
        <img class="card-img-top" :src="vaults.img" alt="Card image cap">
        <div class="card-body">
          <h5 class="card-title">
            {{ vaults.name }}
          </h5>
          <p class="card-text">
            {{ vaults.description }}
          </p>
          <a href="#" class="btn btn-primary">Look in the Vault</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'VaultsComponent',
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
