<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-3">
        <div class="modal fade"
             id="createVault"
             tabindex="-1"
             role="dialog"
             aria-labelledby="exampleModalCenterTitle"
             aria-hidden="true"
        >
          <form class="form-group" @submit.prevent="createVault">
            <div class="modal-dialog modal-dialog-centered" role="document">
              <div class="modal-content">
                <div class="modal-header">
                  <h5 class="modal-title" id="exampleModalLongTitle">
                    New Vault
                  </h5>
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="modal-body">
                  <input type="text" class="form-control" placeholder="Enter Vault Title" v-model="state.newVault.name">
                  <br>
                  <textarea type="text" class="form-control" placeholder="Enter Description" v-model="state.newVault.description">
                </textarea>
                  <br>
                  <input type="text" class="form-control" placeholder="Enter Img Url " v-model="state.newVault.Img">
                  <br>
                  <input type="checkbox"
                         id="isPrivate"
                         placeholder="Is This Vault Private"
                         v-model="state.newVault.isPrivate"
                  >
                  <label for="isPrivate" class="ml-2">Private</label>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-secondary" data-dismiss="modal">
                    Close
                  </button>
                  <button type="submit" class="btn btn-primary">
                    Create Vault
                  </button>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
    <div class="about text-center row justify-content-center">
      <div class="col-3 text-right">
        <img :src="activeprofile.picture" alt="">
      </div>
      <div class="col-3 text-left">
        <h5>{{ activeprofile.name }}</h5>
      </div>
    </div>
    <div class="row">
      <div class="col-2 text-right pt-4">
        <h1>
          Vault <button class=" btn mt-2" type="button" data-toggle="modal" data-target="#createVault">
            <i class="fas fa-plus fa-2x"></i>
          </button>
        </h1>
      </div>
    </div>
    <div class="row justify-content-center">
      <vaults-component v-for="vault in vaults" :key="vault.id" :vault-prop="vault" />
    </div>
    <div class="row">
      <div class="col-2 text-right pt-4">
        <h1>
          Keeps <button class=" btn mt-2" type="button" data-toggle="modal" data-target="#createKeep">
            <i class="fas fa-plus fa-2x"></i>
          </button>
        </h1>
      </div>
    </div>
    <div class="row justify-content-around img-fluid">
      <keeps-component v-for="keep in keeps" :key="keep.id" :keep-prop="keep" />
    </div>
    <div class="row">
      <div class="col-3">
        <div class="modal fade"
             id="createKeep"
             tabindex="-1"
             role="dialog"
             aria-labelledby="exampleModalCenterTitle"
             aria-hidden="true"
        >
          <form class="form-group" @submit.prevent="createKeep">
            <div class="modal-dialog modal-dialog-centered" role="document">
              <div class="modal-content">
                <div class="modal-header">
                  <h5 class="modal-title" id="exampleModalLongTitle">
                    Create Keep
                  </h5>
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="modal-body">
                  <input class="form-control" type="text" placeholder="Enter Keep Title" v-model="state.newKeep.name">
                  <br>
                  <input class="form-control" type="text" placeholder="Enter Keep Description" v-model="state.newKeep.description">
                  <br>
                  <input class="form-control" type="text" placeholder="Enter Keep Img Url" v-model="state.newKeep.Img">
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-secondary" data-dismiss="modal">
                    Close
                  </button>
                  <button type="submit" class="btn btn-primary">
                    Create Keep
                  </button>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
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
    onMounted(() => profileService.getProfileByID(route.params.profileId))
    const state = reactive({
      newVault: {},
      newKeep: {}

    })
    onMounted(() => vaultsService.getVaultsById(route.params.profileId))
    onMounted(() => keepsService.getKeepsById(route.params.profileId))
    return {
      activeprofile: computed(() => AppState.activeProfile),
      state,
      vaults: computed(() => AppState.vaults),
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
