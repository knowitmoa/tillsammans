import { createApp } from 'vue'
import App from './App.vue'
import {GoogleMap} from 'vue3-google-map';

const app = createApp(App);


app.use(GoogleMap, {
    load: {
        key: 'YOUR_GOOGLE_MAPS_API_KEY',
        libraries: 'places',
    },
});

app.mount('#app');