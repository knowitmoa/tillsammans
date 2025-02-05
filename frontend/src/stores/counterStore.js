import { defineStore } from "pinia";

export const useInputStore = defineStore("inputStore", {
    state: () => ({
        inputValue: "", 
    }),
    actions: {
     
        updateInputValue(value) {
            this.inputValue = value;
        },
    },
});
