<template>
  <div class="main-content">
    <GoogleMap
        api-key="AIzaSyBSt_o9j2fTszmVptkfA4DeWNkhrh5AC9g"  
    style="width: 100%; height: 845px"
    :center="{ lat: 57.7016, lng: 11.9495 }"
    :zoom="15"
    >

      <Marker
          v-for="(cordinate, index) in CoordinatesList"
          :key="index"
          :options="{
          position: { lat: cordinate.lat, lng: cordinate.lng }
        }"
      />
      <Marker
          :options="{
          position: { lat: userCoordinate.lat, lng: userCoordinate.lng },
          icon: 'http://maps.google.com/mapfiles/ms/icons/blue-dot.png'
        }"/>

      <Circle
          :options="{
    center: { lat: userCoordinate.lat, lng: userCoordinate.lng },
    radius: inputStore.inputValue, 
    fillColor: '#62c2a1',
    fillOpacity: 0.3,
    strokeColor: '#62c2a1',
    strokeWeight: 1
  }"
      />


    </GoogleMap>

    
  </div>
</template>

<script>
import { GoogleMap, Marker, Circle} from "vue3-google-map";
import { useInputStore } from "@/stores/counterStore";
import axios from "axios";

export default {
  name: "MapSquare",
  components: {
    GoogleMap,
    Marker,
    Circle
  },
  setup() {
    const inputStore = useInputStore(); 

    return {
      inputStore,
    };
  },
  props: {
    activities: Array
    
  },
  mounted() {
    axios
        .get("http://localhost:8088/api/User/GetActiveUser")
        .then((response) => {
          this.user = response.data;
          if (this.user.userAdress) {
            this.getCoordinatesUser(this.user);
          }
        })
        .catch((error) => {
          console.error("There was an error fetching the data:", error);

          if (error.response) {
            console.error("Server responded with status:", error.response.status);
          }
        });
  },
  data() {
    return {
      CoordinatesList: [],
      errorMessage: '',  
      userCoordinate: Object,
      user: Object,
    };
  },
  watch: {
    
    activities: {
      handler(newActivities) {
        this.fetchCoordinatesForActivities(newActivities); 
      },
      immediate: true,  
    },
  },
  methods: {
    async fetchCoordinatesForActivities(activities) {
      
      activities.forEach((activity) => {
        if (activity.adress) {  
          this.getCoordinates(activity);  
        }
      });
    },

    async getCoordinates(activity) {
      const apikey = ''; 
      const url = `https://maps.googleapis.com/maps/api/geocode/json?address=${encodeURIComponent(activity.adress)}&key=${apikey}`;

      try {
        const response = await axios.get(url);
        const data = response.data;

        if (data.status === 'OK') {
          const location = data.results[0].geometry.location;
          this.CoordinatesList.push(location);  
          this.errorMessage = '';  
        } else {
          this.errorMessage = `Address not found for ${activity.adress}`;  
        }
      } catch (error) {
        this.errorMessage = "Error fetching coordinates.";  
        console.error(error);
      }
    },
    async getCoordinatesUser(user) {
      const apikey = '';
      const url = `https://maps.googleapis.com/maps/api/geocode/json?address=${encodeURIComponent(user.userAdress)}&key=${apikey}`;

      try {
        const response = await axios.get(url);
        const data = response.data;

        if (data.status === 'OK') {
          this.userCoordinate = data.results[0].geometry.location;
          
          this.errorMessage = '';
        } else {
          this.errorMessage = `Address not found for ${user.UserAdress}`;
        }
      } catch (error) {
        this.errorMessage = "Error fetching coordinates.";
        console.error(error);
      }
    },
  },
};
</script>

<style scoped>
.main-content {
  width: 100%;
  height: 100%;
}
</style>
