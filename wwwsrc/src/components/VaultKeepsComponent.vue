<template>
  <div class="vault-keeps-component col-3">
    <h1>
      hello
    </h1>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import swal from 'sweetalert'
export default {
  components: {},
  name: 'VaultKeepsComponent',
  props: ['keepProp'],
  setup(props) {
    const state = reactive({

    })
    return {
      state,
      keeps: computed(() => props.keepProp),
      profile: computed(() => AppState.profile),

      editViews() {
        keepsService.editViews(props.keepProp.id)
      },

      addVaultKeep(vaultId, KeepId) {
        vaultsService.addVaultKeep(vaultId, KeepId)
      },

      keepCount() {
        keepsService.editKeepCount(props.keepProp.id)
      },
      deleteKeeps(keepId) {
        swal({
          title: 'Are you sure?',
          text: 'Once deleted, you will not be able to recover this imaginary file!',
          icon: 'warning',
          buttons: true,
          dangerMode: true
        })
          .then((willDelete) => {
            if (willDelete) {
              keepsService.deleteKeeps(keepId)
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

<style scoped>
.card-columns {

  @media (min-width: 992px) {
    .card-columns{column-count: 4;}
  }
  @media (min-width: 1200px) {
    .card-columns{column-count: 5;}
  }
}
.bottom{
  position: absolute;
  bottom: 1em;
  justify-content: space-around;
}
.avatar{
  height: 75%;
  width: 100%;
  position: absolute;
  bottom: 1em;
}
</style>
