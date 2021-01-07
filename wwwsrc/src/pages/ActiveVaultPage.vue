<template>
  <div class="container-fluid active-vault-page">
    <div class="row">
      <div class="col">
        <h1>
          {{ vault.name }}
          <i class="fas fa-trash" @click.prevent="removeVault(vault.id)"></i>
        </h1>
      </div>
    </div>
    <div class="row">
      <vault-keeps-component v-for="keep in keeps" :key="keep.vaultKeepId" :keep-prop="keep" />
    </div>
  </div>
</template>
<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import VaultKeepsComponent from '../components/VaultKeepsComponent'
import { useRoute } from 'vue-router'
import swal from 'sweetalert'

export default {
  name: 'ActiveVaultPage',
  components: { VaultKeepsComponent },

  setup() {
    const route = useRoute()
    onMounted(() => vaultsService.getOneVault(route.params.id))
    onMounted(() => vaultsService.getVaultKeeps(route.params.id))
    return {
      profile: computed(() => AppState.profile),
      allVaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.vaultKeeps),
      vault: computed(() => AppState.activevault),

      removeVault(vaultId) {
        swal({
          title: 'Are you sure?',
          text: 'Once deleted, you will not be able to recover this imaginary file!',
          icon: 'warning',
          buttons: true,
          dangerMode: true
        })
          .then((willDelete) => {
            if (willDelete) {
              vaultsService.removeVaults(vaultId)
              swal('Poof! Your imaginary file has been deleted!', {
                icon: 'success'
              })
            } else {
              swal('Your imaginary file is safe!')
            }
          })
      }

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
