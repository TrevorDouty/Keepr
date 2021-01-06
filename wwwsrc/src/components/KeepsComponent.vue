<template>
  <div class="keeps-component col-3">
    <div class="card  card-columns btn rounded m-2 py-3" type="button" data-toggle="modal" :data-target="'#keepModal' + keeps.id">
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
        </div>
        <div class="row">
          <div class="col-4">
            <img :src="keeps.img" alt="" class="img-fluid">
          </div>
          <div class="col-5 d-flex column">
            <h5> {{ keeps.name }} </h5>
            <p>{{ keeps.description }}</p>
            <h5>{{ keeps.creator.name }}</h5>
            <router-link data-dismiss="modal" :to="{name: 'ProfileById', params:{id: keeps.creator.id}}">
              <img :src="keeps.creator.picture" alt="" class="avatar justify-self-end">
            </router-link>
          </div>
        </div>
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
  @media (min-width: 992px) {
    .card-columns{column-count: 4;}
  }
  @media (min-width: 1200px) {
    .card-columns{column-count: 5;}
  }
}

.avatar{
  height: 10%;
  width: 50%;
  position: absolute;
  bottom: 1em;
}
</style>
