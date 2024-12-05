<template>
  <div class="card">
    <h3>{{ activity.name }}</h3>
    <p>Adress: {{ activity.adress }}</p>
    <p>Dag: {{ activity.eventDay }}</p>
    <p>Tid: {{ activity.eventTime }}</p>
    <p>id: {{ activity.id }}</p>
    <button class = "delta-button" @click="joinActivity()">Delta</button>
    <button class = "delta-button" @click = "toggleDetails"> {{ isDetailsVisible ? 'Hide Details' : 'Show Details' }}</button>

    <div v-if="isDetailsVisible">
      
      <p>Participants: {{ activity.participants }}</p>
     
     
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
      isDetailsVisible: false, // State to toggle additional info
    };
    },
  
  methods: {

    async joinActivity() {
      try {
        
        const response = await axios.post(`http://localhost:8088/api/Activity/AddUserToActivity/${this.activity.id}/4`
       
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
.card {
  background-color: #f4f4f4;
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 15px;
  margin-bottom: 10px;
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
}

.card h3 {
  margin: 0;
  font-size: 18px;
  color: #333;
}

.card p {
  margin: 5px 0;
  color: #666;
}

.delta-button {
  padding: 10px 20px;
  background-color: #4CAF50; 
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  font-size: 16px;
}
</style>
