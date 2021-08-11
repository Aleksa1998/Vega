import axios from "axios";
import {types} from '../types';

export const getAllClients = () => async (dispatch) => {
    debugger;
    try {  
        const response = await axios.get("http://localhost:59544/api/client/",
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + sessionStorage.getItem("token")}
          }); 
        debugger;
        dispatch({
            type: types.LOAD_ALL_CLIENTS_SUCCESS,
            payload: response.data,
        }); 
        return response.data;
    }catch (e) {
        dispatch({
            type: types.LOAD_ALL_CLIENTS_FAILED,
            payload: console.log(e),
        });
    }
}; 

export const createClient = (dto) => async (dispatch) => {
        try {
        debugger;
        const response = await axios.post("http://localhost:59544/api/client/",dto,
            {
            headers: {
                "Access-Control-Allow-Origin": "*",
                Authorization: "Bearer " + sessionStorage.getItem("token"),
            },
            }
        );
        debugger;
        dispatch({
            type: types.CREATE_CLIENT_SUCCESS,
            payload: response.data,
        });
        } catch (e) {
        dispatch({
            type: types.CREATE_CLIENT_FAILED,
            payload: console.log(e),
        });
        }
        getAllClients();
  };

  export const updateClient = (dto) => async (dispatch) => {
    try {
    debugger;
    const response = await axios.post("http://localhost:59544/api/client/update",dto,
        {
        headers: {
            "Access-Control-Allow-Origin": "*",
            Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
        }
    );
    debugger;
    dispatch({
        type: types.UPDATE_CLIENT_SUCCESS,
        payload: response.data,
    });
    return true;
    } catch (e) {
    dispatch({
        type: types.UPDATE_CLIENT_FAILED,
        payload: console.log(e),
    });
    }
};