<template>
  <div class="keeps-component col-3">
    <div class="card  card-columns btn rounded m-2 py-3" type="button" data-toggle="modal" data-target="#keepModal">
      <h5> {{ keeps.name }} </h5>
      <p>{{ keeps.description }}</p>
      <img :src="keeps.img" alt="">
      <img :src="profile.picture" alt="">
    </div>
  </div>
  <div class="modal fade"
       id="keepModal"
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
        </div>

        <h5> {{ keeps.name }} </h5>
        <p>{{ keeps.description }}</p>
        <img :src="keeps.img" alt="" class="img-fluid">
        <h5>{{ keeps.creator.name }}</h5>
        <router-link :to="{name: 'Profile', params:{profile: profile.id}}">
          <img :src="keeps.creator.picture" alt="">
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'KeepsComponent',
  props: ['keepProp'],
  setup(props) {
    const state = reactive({})
    return {
      state,
      keeps: computed(() => props.keepProp),
      profile: computed(() => AppState.profile)
    }
  },
  components: {}
}
</script>

<style scoped>
.card-columns {
  @include media-breakpoint-only(lg) {
    column-count: 4;
  }
  @include media-breakpoint-only(xl) {
    column-count: 5;
  }
}
</style>
