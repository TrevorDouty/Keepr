<template>
  <div class="keeps-component">
    <div class="card" type="button" data-toggle="modal" :data-target="'#keepModal' + keeps.id" @click.prevent="editViews()">
      <img :src="keeps.img" alt="" class="img-fluid avatar borderPatrol">
      <div class="card-img-overlay bottom ">
        <div class="keepName card">
          {{ keeps.name }}
        </div>
        <img :src="keeps.creator.picture"
             alt=""
             class="
        rounded-circle avatarImg"
        >
      </div>
    </div>
  </div>
  <div class="modal fade"
       :id="'keepModal' + keeps.id"
       tabindex="-1"
       role="dialog"
       aria-labelledby="myLargeModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="row justify-content-center">
          <div class="col-1">
            <i class="far fa-eye">{{ keeps.views }}</i>
          </div>
          <div class="col-1">
            <i class="fas fa-share">{{ keeps.shares }}</i>
          </div>
          <div class="col-1">
            <i class="fas fa-plus">{{ keeps.keeps }}</i>
          </div>
        </div>
        <div class="row">
          <div class="col-4">
            <img :src="keeps.img" alt="" class="img-fluid">
          </div>
          <div class="col-5">
            <div class="row">
              <div class="col">
                <h5> {{ keeps.name }} </h5>
              </div>
            </div>
            <div class="row justify-content-center">
              <div class="">
                <p>{{ keeps.description }}</p>
              </div>
            </div>
            <div class="row bottom">
              <div class="dropdown">
                <button class="btn btn-success dropdown-toggle"
                        type="button"
                        id="dropdownMenuButton"
                        data-toggle="dropdown"
                        aria-haspopup="true"
                        aria-expanded="false"
                        @click.prevent="getVaults()"
                >
                  Dropdown button
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                  <a v-for="vault in vaults" :key="vault.id" class="dropdown-item" href="#">
                    <div @click.prevent="addVaultKeep(vault.id, keeps.id), keepCount(keeps.id)">
                      <my-vaults-component :vault-prop="vault" />
                    </div>
                  </a>
                </div>
              </div>

              <button v-show="keeps.creatorId == profile.id" @click.prevent="deleteKeeps(keeps.id)" class="mx-3">
                <i class="fas fa-trash-alt"></i>
              </button>
              <!-- <div class="col-1">
                <h5>{{ keeps.creator.name }}</h5>
              </div> -->
              <router-link data-dismiss="modal" :to="{name: 'ProfileById', params:{id: keeps.creator.id}}">
                <img :src="keeps.creator.picture" alt="" class=" avatar justify-self-end img-fluid">
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import MyVaultsComponent from './MyVaultsComponent.vue'
import { vaultsService } from '../services/VaultsService'
import swal from 'sweetalert'
export default {
  components: { MyVaultsComponent },
  name: 'KeepsComponent',
  props: ['keepProp'],
  setup(props) {
    const state = reactive({

    })
    return {
      state,
      keeps: computed(() => props.keepProp),
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.vaults),

      editViews() {
        keepsService.editViews(props.keepProp.id)
      },

      addVaultKeep(vaultId, KeepId) {
        vaultsService.addVaultKeep(vaultId, KeepId)
      },

      keepCount() {
        keepsService.editKeepCount(props.keepProp.id)
      },
      getVaults() {
        vaultsService.getVaults()
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
.borderPatrol{
  border-radius: 17px;
}
.bottom{
  position: absolute;
  bottom: 1em;
}
.avatar{
  height: auto;
  width: 100%;

}

.rounded-circle{
  height: 12%;
}

.keepName{
  width: 60%;
 position: absolute;
  bottom: 0em;
  left: 0em;
}

.avatarImg{
  position: absolute;
  bottom: 0em;
  right: 1em;
}

</style>
