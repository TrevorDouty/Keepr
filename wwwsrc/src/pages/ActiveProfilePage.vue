<template>
  <div class="container-fluid">
    <div class="about text-center row justify-content-start">
      <div class="col-3 text-right">
        <img :src="activeprofile.picture" alt="">
      </div>
      <div class="col-3 text-left">
        <h5>{{ activeprofile.name }}</h5>
        <h5>Keeps {{ keeps.length }}</h5>
        <h5>Vaults {{ vaults.length }}</h5>
      </div>
    </div>
    <div class="row">
      <div class="col-3 text-right m-5">
        <h1>
          Vaults
          <i class="fas fa-plus"></i>
        </h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <vaults-component v-for="vault in vaults" :key="vault.id" :vault-prop="vault" />
    </div>
    <div class="row">
      <div class="col-3 text-right m-5">
        <h1>
          Keeps
          <i class="fas fa-plus"></i>
        </h1>
      </div>
    </div>
    <div class="row justify-content-center img-fluid">
      <keeps-component v-for="keep in keeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>
<script>
import { computed, onMounted, reactive } from 'vue'
import { profileService } from '../services/ProfileService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
import VaultsComponent from '../components/VaultsComponent'
import KeepsComponent from '../components/KeepsComponent'
export default {
  name: 'ActiveProfilePage',
  setup() {
    const route = useRoute()
    onMounted(() => profileService.getProfileByID(route.params.id))
    const state = reactive({
      newVault: {},
      newKeep: {}

    })
    onMounted(() => vaultsService.getVaultsById(route.params.id))
    onMounted(() => keepsService.getKeepsById(route.params.id))
    return {
      activeprofile: computed(() => AppState.activeProfile),
      state,
      vaults: computed(() => AppState.myvaults),
      keeps: computed(() => AppState.keeps),
      profile: computed(() => AppState.profile),

      createVault(newVault) {
        vaultsService.createVault(state.newVault)
      },
      createKeep(newKeep) {
        keepsService.createKeep(state.newKeep)
      }
    }
  },
  components: { VaultsComponent, KeepsComponent }
}
</script>

  <style lang="scss" scoped>
  </style>
