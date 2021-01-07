<template>
  <div class="container-fluid home">
    <div class="row justify-content-around img-fluid">
      <vault-keeps-component v-for="keep in vaultKeeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>
<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import VaultKeepsComponent from '../components/KeepsComponent'
import { useRoute } from 'vue-router'

export default {
  name: 'Home',
  components: { VaultKeepsComponent },
  props: ['VaultProp'],

  setup(props) {
    const route = useRoute()
    onMounted(() => vaultsService.getVaultKeeps(route.params.id))
    return {
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.myvaults),
      allVaults: computed(() => AppState.vaults),
      vaultKeeps: computed(() => props.VaultProp)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
