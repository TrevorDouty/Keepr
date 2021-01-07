<template>
  <div class="vaults-component">
    <div class="col-4">
      <div class="card borderPatrol vault-card" style="width: 18rem;">
        <img class="card-img-top" :src="vaults.img" alt="Card image cap">
        <div class="card-body">
          <router-link data-dismiss="modal" :to="{name: 'ActiveVault', params:{id: vaults.id}}">
            <h5 class="card-title">
              {{ vaults.name }}
            </h5>
            <p class="card-text">
              {{ vaults.description }}
            </p>
          </router-link>
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

<style scoped>
.borderPatrol{
  border-radius: 17px;
}
</style>
