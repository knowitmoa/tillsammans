<template>
  <header class="header">
    <h1 class="title">Tillsammans</h1>
    <div class="right-content">
      <p>Välkommen {{ users.name }}</p>
      <p1>Fyll i önskat avstånd till dina aktiviteter</p1>
      <input type="number" class="square-input" v-model="inputValue" placeholder="500" min="500" step="250" />
    </div>
  </header>
</template>

<script>
import { useInputStore } from "@/stores/counterStore";
import { computed } from "vue";

export default {
  name: 'HeaderTogether',
  setup() {
    const inputStore = useInputStore();

    const inputValue = computed({
      get: () => inputStore.inputValue,
      set: (newValue) => inputStore.updateInputValue(newValue),
    });

    return {
      inputValue,
    };
  },

  props: {
    users: Object,
  },
};
</script>

<style scoped>
@font-face {
  font-family: 'Bagoss';
  src: url('C:\Users\moaahl\source\repos\Together2.0\frontend\public\fonts\Bagoss-Bold.ttf') format('truetype');
  font-weight: normal;
  font-style: normal;
}

.header {
  background: linear-gradient(135deg, #62c2a1, #7d80d1, #b6a4e0);
  font-family: 'Bagoss';
  padding: 20px;
  font-size: 24px;
  transition: background 1s ease;
  display: flex;
  justify-content: space-between;
  align-items: center; 
}



.right-content {
  display: flex;
  flex-direction: column;
  align-items: flex-end; 
}

.right-content p1 {
  font-size: 18px;
}

.square-input {
  width: 75px;
  height: 30px;
  border: 2px solid #7d80d1;
  border-radius: 5px;
  text-align: center;
  font-size: 16px;
  margin-top: 10px;
}


</style>
