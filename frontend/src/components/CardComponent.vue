<template>
  <div class="card">
    <h3>{{ activity.name }}</h3>
    <p>Adress: {{ activity.adress.split(",")[0] }}</p>
    <p>Dag: {{ activity.eventDay }}</p>
    <p>Tid: {{ activity.eventTime }}</p>
    <button class = "delta-button" @click="joinActivity()">Delta</button>
    <button class = "delta-button" @click = "toggleDetails"> {{ isDetailsVisible ? 'Dölj Deltagare' : 'Visa Deltagare' }}</button>

    <div v-if="isDetailsVisible">
      
      <p>Deltagare: </p>
      
      <p v-for = "user in activity.participants" :key="user.id"> {{ user.name }}: {{ user.age }} år</p>
     
     
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: 'CardComponent',
  props: {
    activity: {
      type: Object,
      required: true,
    },
  },
  data() {
    return {
      isDetailsVisible: false, 
    
    };
    },
  
  methods: {

    async joinActivity() {
      try {
        
        const response = await axios.post(`http://localhost:8088/api/Activity/AddUserToActivity/${this.activity.id}`
       
        );
        
        alert(response.data.message);  

      
      } catch (error) {
        console.error('Error adding user to activity:', error);
        alert('There was an error adding you to the activity.');
      }
    },
    toggleDetails() {
      // Toggle the visibility of additional information
      this.isDetailsVisible = !this.isDetailsVisible;
    },
     
    
  },
  
};
</script>

<style scoped>

@font-face {
  font-family: 'Bagoss-small';
  src: url('C:\Users\moaahl\source\repos\Together2.0\frontend\public\fonts\Bagoss-Regular.ttf') format('truetype');
  font-weight: normal;
  font-style: normal;
}
.card {
  background-color: #f4f4f4;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 15px;
  margin-bottom: 10px;
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
  font-family: "Bagoss-small";
  text-align: left;
  
}

.card h3 {
  margin: 0;
  font-size: 18px;
  color: #333;
}

.card p {
  
  color: #333;
}

.delta-button {
  padding: 10px 20px;
  background-color: #62c2a1; 
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
  font-family: 'Bagoss-small';
}
</style>
;