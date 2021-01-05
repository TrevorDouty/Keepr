<template>
  <div class="keeps-component container-fluid card col-3 btn rounded" type="button" data-toggle="modal" data-target="#keepModal">
    <h5> {{ keeps.name }} </h5>
    <p>{{ keeps.description }}</p>
    <img :src="keeps.img" alt="">
    <img :src="keeps.profile" alt="">
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
        <h5> {{ keeps.name }} </h5>
        <p>{{ keeps.description }}</p>
        <img :src="keeps.img" alt="" class="img-fluid">
        <img :src="keeps.profile" alt="">
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
export default {
  name: 'KeepsComponent',
  props: ['keepProp'],
  setup(props) {
    const state = reactive({})
    return {
      state,
      keeps: computed(() => props.keepProp)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
