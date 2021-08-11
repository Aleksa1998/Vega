import {types} from '../types';
const initialState = {
    projectsList: [],
    clientsList: [],
    countriesList: [],
    userCookie : {},
    userToken : "",
    timeSheetsList: [],
    timeSheetsForDateList: [],
    projectsForClientList: [],
    categoriesList: []
}
function reducer(state = initialState, action) {
    switch (action.type) {
        case types.LOAD_ALL_PROJECTS_SUCCESS:
            return {
                ...state,
                projectsList: action.payload
            };
        case types.LOAD_ALL_CLIENTS_SUCCESS:
            return {
                ...state,
                clientsList: action.payload
            };
        case types.LOAD_ALL_COUNTRIES_SUCCESS:
            return {
                ...state,
                countriesList: action.payload
            };
        case types.CREATE_CLIENT_SUCCESS:
            return{
                ...state,
                clientsList: state.clientsList.concat(action.payload)
            }
        case types.UPDATE_CLIENT_SUCCESS:
            return{
                ...state,
                clientsList: state.clientsList.concat(action.payload)
            }
        case types.LOAD_ALL_TIMESHEETS_SUCCESS:
            return{
                ...state,
                timeSheetsList: action.payload
            }   
        case types.LOAD_TIMESHEETS_FOR_DATE_SUCCESS:
        return{
            ...state,
            timeSheetsForDateList: action.payload
        } 
        case types.LOAD_CLIENT_PROJECTS_SUCCESS:
            return{
                ...state,
                projectsForClientList: action.payload
            } 
        case types.LOAD_ALL_CATEGORIES_SUCCESS:
            return{
                ...state,
                categoriesList: action.payload
            }     
    
        case types.USER_LOGGEDIN_SUCCESS:
            var parts = action.payload.token.split('.'); // header, payload, signature
            var user = JSON.parse(atob(parts[1]));
            return {
                ...state,
                userToken: action.payload.token,
                userCookie: user
            };
        default:
            return state;
    }
}
export default reducer;