import React, {useEffect, useState} from "react"
import { connect } from "react-redux"
import { updateTimeSheet } from "../actions/timeSheetActions"


function TimeSheetDailyItem(props)  {
    const [description, setDesription] = useState(props.timeSheet.description);
    const [time, setTime] = useState(props.timeSheet.time);
    const [overtime, setOvertime] = useState(props.timeSheet.overtime);

    const handleChangeDescription = (event) => {
        setDesription(event.target.value);
    }
    const handleChangeTime = (event) => {
        setTime(event.target.value);
    }
    const handleChangeOvertime = (event) => {
        setOvertime(event.target.value);
    }

    const edit = () =>{
        props.updateTimeSheet({
            Id : props.timeSheet.id,
            Time: time,
            Date: props.timeSheet.date,
            Overtime : overtime,
            Description: description,
            CategoryId : props.timeSheet.category.id,   
            EmployeeId: props.timeSheet.employee.id,
            ProjectId: props.timeSheet.project.id
        })
    }

    return(
                    <tr>
                            <td>
                                <select>
                                    <option>{props.timeSheet.project.client.name}</option>
                                </select>
                            </td>
                            <td>
                                <select>
                                    <option>{props.timeSheet.project.name}</option>
                                </select>
                            </td>
                            <td>
                                <select>
                                    <option>{props.timeSheet.category.name}</option>
                                </select>
                            </td>
                            <td>
                                <input type="text" onChange={handleChangeDescription} name="description" value={description} class="in-text medium" />
                            </td>
                            <td class="small">
                                <input type="text" onChange={handleChangeTime} value={time} name="time" id="time" class="in-text xsmall" />
                            </td>
                            <td class="small">
                                <input type="text" onChange={handleChangeOvertime} value={overtime} class="in-text xsmall" />
                            </td>
                            <td class="small">
                                <a href="javascript:;" class="btn green" onClick={edit}>Save</a>
                            </td>
				    </tr>	 
    );

}

const mapStateToProps = (state) =>

    ({ })

export default connect(mapStateToProps, { updateTimeSheet }) (TimeSheetDailyItem);

