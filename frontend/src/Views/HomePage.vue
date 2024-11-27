<template>
  <div>
    <!-- Header Section -->
    <header>
      <h1>Welcome to My Simple Homepage</h1>
    </header>
    <h1>User List</h1>
    <ul>
      <li v-for="user in users" :key="user.id">
        {{ user.name }} - {{ user.gender }}
      </li>
    </ul>

    <!-- Main Content Section -->
    <main>
      <p>This is a very basic homepage built with Vue.js.</p>
    </main>

    <!-- Footer Section -->
    <footer>
      <p>&copy; 2024 My Simple Homepage</p>
    </footer>
  </div>
</template>

<script>

import axios from'axios';
export default {
  name: 'HomePage',
  data() {
    return {
      users: []
    };
  },
  mounted() {
    axios.get('http://localhost:8088/api/User')
        .then(response => {
          this.users = response.data;
        })
        .catch(error => {console.erorr('There was an error fetching the data:',error);
        });
    
  }
  
};
</script>

<style scoped>
/* Basic Styles */
body {
  font-family: Arial, sans-serif;
  margin: 0;
  padding: 0;
}

header {
  background-color: #333;
  color: white;
  text-align: center;
  padding: 20px;
}

main {
  padding: 20px;
  text-align: center;
}

footer {
  background-color: #333;
  color: white;
  text-align: center;
  padding: 10px;
  position: fixed;
  width: 100%;
  bottom: 0;
}
</style>
