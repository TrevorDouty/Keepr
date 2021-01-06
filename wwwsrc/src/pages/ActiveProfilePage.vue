<template>
  <div class="container-fluid">
    <div class="about text-center row justify-content-center">
      <div class="col-3 text-right">
        <img :src="profile.picture" alt="">
      </div>
      <div class="col-3 text-left">
        <h5>{{ profile.name }}</h5>
      </div>
    </div>
    <div class="row">
      <div class="col-2 text-right pt-4">
        <h1>
          Vault
          <i class="fas fa-plus fa-2x"></i>
        </h1>
      </div>
      <div class="row justify-content-center">
        <vaults-component v-for="vault in vaults" :key="vault.id" :vault-prop="vault" />
      </div>

      <div class="row justify-content-around img-fluid">
        <keeps-component v-for="keep in keeps" :key="keep.id" :keep-prop="keep" />
      </div>
    </div>
  </div>
</template>
<script>
import { computed, onMounted } from 'vue'
import { profileService } from '../services/ProfileService'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
export default {
  name: 'ActiveProfilePage',
  setup() {
    const route = useRoute()
    onMounted(() => profileService.getProfileByID(route.params.profileId))
    return {
      profile: computed(() => AppState.activeProfile)
    }
  },
  components: {}
}
</script>

  <style lang="scss" scoped>
  </style>
