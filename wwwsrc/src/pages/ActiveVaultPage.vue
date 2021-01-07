<template>
  <div class="container-fluid active-vault-page">
    <div class="row">
      <keeps-component v-for="keep in keeps" :key="keep.vaultKeepId" :keep-prop="keep" />
    </div>
  </div>
</template>
<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import KeepsComponent from '../components/KeepsComponent'
import { useRoute } from 'vue-router'

export default {
  name: 'ActiveVaultPage',
  components: { KeepsComponent },
  props: ['VaultProp'],

  setup(props) {
    const route = useRoute()
    onMounted(() => vaultsService.getVaultKeeps(route.params.id))
    return {
      profile: computed(() => AppState.profile),
      allVaults: computed(() => AppState.vaults),
      vaultKeeps: computed(() => props.VaultProp),
      keeps: computed(() => AppState.vaultKeeps)

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
