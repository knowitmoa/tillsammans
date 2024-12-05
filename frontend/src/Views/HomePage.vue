
<template>
  <div id = "home-page">
    <HeaderTogether/>
    <div class="main-container">
    <LeftSideBar :activities="activities"/>
    <MapSquare/>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import MapSquare from"@/components/MapSquare.vue";
import HeaderTogether from "@/components/HeaderTogether.vue";
import LeftSideBar from "@/components/LeftSideBar.vue";
export default {
  name: 'HomePage',
  components: {HeaderTogether, MapSquare, LeftSideBar},
  data() {
    return {
      activities: [],
    };
  }, 
  mounted() {
    axios
        .get("http://localhost:8088/api/Activity") // Note the use of the proxy path
        .then((response) => {
          this.activities = response.data;
        })
        .catch((error) => {
          console.error("There was an error fetching the data:", error);
          // Check for more detailed error info
          if (error.response) {
            console.error("Server responded with status:", error.response.status);
          }
        });
  },

};
</script>

<style scoped>

#home-page {
  display: flex;
  flex-direction: column;
  padding: 0;
  margin: 0;
}

.main-container {
  display: flex; /* Use flexbox for side-by-side layout */
  flex-grow: 1; /* Ensure this takes up the remaining space */
}
body {
  font-family: Arial, sans-serif;
  margin: 0;
  padding: 0;
}
header {
  background-color: #333;
  color: white;
  text-align: center;
  
 
}
</style>
