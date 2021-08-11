import axios from "axios";
import {types} from '../types';

export const getAllCountries = () => async (dispatch) => {
    debugger;
    try {  
        const response = await axios.get("http://localhost:59544/api/country/",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + sessionStorage.getItem("token")}
          }); 
        debugger;
        dispatch({
            type: types.LOAD_ALL_COUNTRIES_SUCCESS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: types.LOAD_ALL_COUNTRIES_FAILED,
            payload: console.log(e),
        });
    }
}; 