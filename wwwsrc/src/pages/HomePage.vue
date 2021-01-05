<template>
  <div class="container-fluid home">
    <div class="row justify-content-around">
      <keeps-component v-for="keep in keeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>
<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import keepsComponent from '../components/KeepsComponent'

export default {
  name: 'Home',
  components: { keepsComponent },

  setup() {
    onMounted(() => { keepsService.getKeeps() })
    return {
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps)
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
