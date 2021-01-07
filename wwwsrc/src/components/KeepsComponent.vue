<template>
  <div class="keeps-component col-3">
    <div class="card  card-columns btn rounded m-2 py-3" type="button" data-toggle="modal" :data-target="'#keepModal' + keeps.id" @click.prevent="editViews()">
      <h5> {{ keeps.name }} </h5>
      <p>{{ keeps.description }}</p>
      <img :src="keeps.img" alt="" class="img-fluid">
      <img :src="keeps.creator.picture" alt="">
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
import { computed, reactive, onMounted } from 'vue'
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
    onMounted(() => vaultsService.getVaultsById(props.keepProp.creatorId))
    return {
      state,
      keeps: computed(() => props.keepProp),
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.myvaults),

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
