import {
   
} from "../types/types"
import axios from "axios";
import {types} from '../types'

export const userLoggedIn = (user) => async (dispatch) => {
    try {
        debugger;
        const response = await axios.post("http://localhost:59544/api/login", ({Username : user.username, Password :  user.password}),
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + sessionStorage.getItem("token")}
          });
        debugger;
        var parts = response.data.token.split('.'); // header, payload, signature
        var userInfo = JSON.parse(atob(parts[1]));
        if(user.checked){
            localStorage.setItem("token", response.data.token)
            localStorage.setItem("userId", userInfo.user_id);
            localStorage.setItem("role", userInfo.role);
            localStorage.setItem("name", userInfo.name);
        }
        sessionStorage.setItem("token", response.data.token)
        sessionStorage.setItem("userId", userInfo.user_id);
        sessionStorage.setItem("role", userInfo.role);
        sessionStorage.setItem("name", userInfo.name);
        return true;
    } catch (e) {
        console.log(e);
    }
};
