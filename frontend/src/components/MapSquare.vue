<template>
  <div class="main-content">
      <GoogleMap
          :center="{ lat: 57.6902, lng: 11.9782 }"
          :zoom="13"
          style="width: 100%; height: 845px"
      ></GoogleMap>
      
  
    </div>
</template>

<script>
import { GoogleMap} from 'vue3-google-map';
export default {
  name: 'MapSquare',
  components: {
    GoogleMap,
   
  },
}
</script>

<style scoped>



.main-content{
  width: 100%;
  height: 100%;
  
;
}



.content-square {
  background-color: #f4f4f4;
  flex-grow: 1; 
  margin-left: 5px; 
  height: 100vh; 
  box-sizing: border-box;
  padding: 20px;
}
</style>
