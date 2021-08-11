import axios from "axios";
import {types} from '../types';

export const getAllCategory = () => async (dispatch) => {
    debugger;
    try {  
        const response = await axios.get("http://localhost:59544/api/category/",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + sessionStorage.getItem("token")}
          }); 
        debugger;
        dispatch({
            type: types.LOAD_ALL_CATEGORIES_SUCCESS,
            payload: response.data,
        }); 
        return response.data;
    }catch (e) {
        dispatch({
            type: types.LOAD_ALL_CATEGORIES_FAILED,
            payload: console.log(e),
        });
    }
}; 