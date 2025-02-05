<template>
  <div class="sidebar">
    
    <CardComponent v-for="activity in activities" :key="activity.id" :activity="activity" />
  </div>
</template>

<script>


import CardComponent from "@/components/CardComponent.vue";
export default {
  name: 'LeftSideBar',
  components:{CardComponent},
  props: {
    activities: {
      type: Array,
      required: true,
    },
  },
 
}
</script>

<style scoped>
.sidebar {
  background: linear-gradient(
      130deg,
  
      #62c2a1,
      #7d80d1,
      #b6a4e0
  );
  color: white;
  width: 400px;
  height: 100vh;
  top: 0;
  left: 0;
  padding-top: 20px;
}

h2 {
  text-align: center;
  color: #fff;
  margin-bottom: 20px;
}


.cards-container .card {
  margin-bottom: 15px;
}
</style>
