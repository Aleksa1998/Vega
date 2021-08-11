import React, {useEffect, useState} from "react"
import moment from "moment";
import {withRouter} from 'react-router'

function TimeSheetItem(timeSheet)  {
    const dailyTimeSheet = () =>{
        sessionStorage.setItem("date", timeSheet.day.date);
        timeSheet.history.push("/daily");
    }
    return(
        <td class="positive previous">
            <div class="date">
                <span>{moment(timeSheet.day.date).format("DD")}</span>
            </div>
            <div class="hours">
                <a onClick={dailyTimeSheet}>
                    Hours: <span>{timeSheet.day.totalHours}</span>
                </a>
            </div>
        </td>  
    );
}

export default  withRouter(TimeSheetItem);