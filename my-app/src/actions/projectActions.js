import axios from "axios";
import {types} from '../types';

export const getAllProjects = () => async (dispatch) => {
    debugger;
    try {  
        const response = await axios.get("http://localhost:59544/api/project/",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + sessionStorage.getItem("token")}
          }); 
        debugger;
        dispatch({
            type: types.LOAD_ALL_PROJECTS_SUCCESS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: types.LOAD_ALL_PROJECTS_FAILED,
            payload: console.log(e),
        });
    }
}; 

export const getAllProjectsForClient = (clientId) => async (dispatch) => {
    debugger;
    const dto = {Id: clientId}
    try {  
        const response = await axios.post("http://localhost:59544/api/project/client/", dto,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + sessionStorage.getItem("token")}
          }); 
        debugger;
        dispatch({
            type: types.LOAD_CLIENT_PROJECTS_SUCCESS,
            payload: response.data,
        });
    } catch (e) {
        dispatch({
            type: types.LOAD_CLIENT_PROJECTS_FAILED,
            payload: console.log(e),
        });
    }
}; 