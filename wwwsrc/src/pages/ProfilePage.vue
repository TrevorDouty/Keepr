<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-3">
       <button type="button" class="btn btn-success" data-toggle="modal" data-target="#createVault">
  Create Vault
</button>
<div class="modal fade" id="createVault" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
      </div>
    </div>
    <div class="about text-center row justify-content-center">
      <div class="col-4">
        <h1>{{ profile.name }}</h1>
        <img :src="profile.picture" alt="">
      </div>
      <div class="row justify-content-center">
        <vaults-component v-for="vault in vaults" :key="vault.id" :vault-prop="vault" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { vaultsService } from '../services/VaultsService'
import VaultsComponent from '../components/VaultsComponent'
export default {
  name: 'Profile',
  components: { VaultsComponent },
  setup() {
    onMounted(() => vaultsService.getVaults())
    return {
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.vaults),

    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
