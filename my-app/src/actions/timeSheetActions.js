import axios from "axios";
import {types} from '../types';

export const getAllTimeSheets = (date) => async (dispatch) => {
    debugger;                                                           //treba date
    const dto = {EmployeeId : sessionStorage.getItem("userId") , Date : date }
    //dto.EmployeeId = sessionStorage.getItem("userId");
    try {  
        const response = await axios.post("http://localhost:59544/api/timesheet/calendar/", dto,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + sessionStorage.getItem("token")}
          }); 
        debugger;
        dispatch({
            type: types.LOAD_ALL_TIMESHEETS_SUCCESS,
            payload: response.data,
        }); 
        return response.data;
    }catch (e) {
        dispatch({
            type: types.LOAD_ALL_TIMESHEETS_FAILED,
            payload: console.log(e),
        });
    }
}; 

export const getAllTimeSheetsForDate = (date) => async (dispatch) => {
    debugger;
    const dto = {Date : date }                                                    
    try {  
        const response = await axios.post("http://localhost:59544/api/timesheet/date/", dto,
        {
            headers: { "Access-Control-Allow-Origin": "*",
                       "Authorization" :  "Bearer " + sessionStorage.getItem("token")}
          }); 
        debugger;
        dispatch({
            type: types.LOAD_TIMESHEETS_FOR_DATE_SUCCESS,
            payload: response.data,
        }); 
        return response.data;
    }catch (e) {
        dispatch({
            type: types.LOAD_TIMESHEETS_FOR_DATE_FAILED,
            payload: console.log(e),
        });
    }
}; 

export const createTimeSheet = (dto) => async (dispatch) => {
    try {
    debugger;
    const response = await axios.post("http://localhost:59544/api/timesheet/",dto,
        {
        headers: {
            "Access-Control-Allow-Origin": "*",
            Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
        }
    );
    debugger;
    dispatch({
        type: types.CREATE_TIMESHEET_SUCCESS,
        payload: response.data,
    });
    } catch (e) {
    dispatch({
        type: types.CREATE_TIMESHEET_FAILED,
        payload: console.log(e),
    });
    }
    getAllTimeSheetsForDate(sessionStorage.getItem("date"));
};

export const updateTimeSheet = (dto) => async (dispatch) => {
    try {
    debugger;
    const response = await axios.post("http://localhost:59544/api/timesheet/update",dto,
        {
        headers: {
            "Access-Control-Allow-Origin": "*",
            Authorization: "Bearer " + sessionStorage.getItem("token"),
        },
        }
    );
    debugger;
    dispatch({
        type: types.UPDATE_TIMESHEET_SUCCESS,
        payload: response.data,
    });
    return true;
    } catch (e) {
    dispatch({
        type: types.UPDATE_TIMESHEET_FAILED,
        payload: console.log(e),
    });
    }
};