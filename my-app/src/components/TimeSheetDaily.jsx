import React, {useEffect, useState} from "react"
import { connect } from "react-redux"
import { getAllTimeSheetsForDate, createTimeSheet } from "../actions/timeSheetActions"
import TimeSheetDailyItem from "./TimeSheetDailyItem"
import { getAllProjectsForClient } from "../actions/projectActions"
import { getAllClients } from "../actions/clientActions"
import { getAllCategory } from "../actions/categoryActions"
import moment from "moment";
import {withRouter} from 'react-router'
import { NavLink } from "react-router-dom"

function TimeSheetDaily(props)  {
    const [date, setDate] = useState(sessionStorage.getItem("date"));
	const [clientId, setClientId] = useState(1);
	const [projectId, setProjectId] = useState(0); 
	const [categoryId, setCategoryId] = useState(1);
	const [description, setDescription] = useState(""); 
	const [time, setTime] = useState(0); 
	const [overtime, setOvertime] = useState(0); 
	const [date2, setDate2] = useState(new Date());
	const [dayOfWeek,setDayOfWeek] = useState((new Date(date)).getDay());
	const daysString = ["SUNDAY","MONDAY","TUESDAY","WEDNESDAY","THURSDAY","FRIDAY","SATURDAY"];

	const handleChangeClient = (event) => {
		debugger;
		setClientId(event.target.value);
	}
	const handleChangeProject = (event) => {
		debugger;
		setProjectId(event.target.value);
	}
	const handleChangeCategory = (event) => {
		debugger;
		setCategoryId(event.target.value);
	}
	const handleChangeDescription = (event) => {
        setDescription(event.target.value);
    }
    const handleChangeTime = (event) => {
        setTime(event.target.value);
    }
    const handleChangeOvertime = (event) => {
        setOvertime(event.target.value);
    }
	const save = () =>{
		props.createTimeSheet({
			Date: date,
			Time: time,
			Overtime: overtime,
			Description: description,
			CategoryId: categoryId,
			EmployeeId: sessionStorage.getItem("userId"),
			ProjectId: projectId,
	});
	setClientId(1);
	setProjectId(0);
	setCategoryId(1);
	setDescription("");
	setTime(0);
	setOvertime(0);
	}
	const handleChangeDay = (index) =>{
		const date2 = new Date(date);
		date2.setDate(date2.getDate() - ((new Date(date)).getDay()-index));
		setDate(date2);
	}
	const back = () =>{
		props.history.push("/timesheets");
	}
	const previous = () => {
		debugger;
		const date2 = new Date(date);
		date2.setDate(date2.getDate() - 7);
		setDate(date2);
	}
	const next = () => {
		debugger;
		const date2 = new Date(date);
		date2.setDate(date2.getDate() + 7);
		setDate(date2);
	}
    useEffect(()=>{
        debugger;
		props.getAllTimeSheetsForDate(date);
		props.getAllClients();
		props.getAllCategory();
	  },[props.timeSheetsForDateList, date])
	  useEffect(()=>{
        debugger;
		props.getAllProjectsForClient(clientId);
	  },[clientId])
    if(props.timeSheetsForDateList == undefined){
        return null;
    }
	if(props.clientsList == undefined){
		return null;
	}
	if(props.projectsForClientList == undefined){
		return null;
	}
	if(props.categoriesList == undefined){
		return null;
	}
    return(
        <div class="container">
		
		<div class="wrapper">
			<section class="content">
				<h2><i class="ico timesheet"></i>TimeSheet</h2>
				<div class="grey-box-wrap">
					<div class="top">
						<a href="javascript:;" onClick={previous} class="prev"><i class="zmdi zmdi-chevron-left"></i>previous week</a>
						<span class="center">{moment(date).format("DD/MM/YYYY")}</span>
						<a href="javascript:;" onClick={next} class="next">next week<i class="zmdi zmdi-chevron-right"></i></a>
					</div>
					<div class="bottom">
						<ul class="days">
							{daysString.map((dayString, index)=>(
								<li onClick={() => handleChangeDay(index)} class={(new Date(date)).getDay() == index ? "active" : ""}>
								<a href="javascript:;">
									<b>Feb 04</b>
									<span>{daysString[index]}</span>
								</a>
							</li>
							))}
						</ul>
					</div>
				</div>
				<table class="default-table">
					<tr>
						<th>
							Client <em>*</em>
						</th>
						<th>
							Project <em>*</em>
						</th>
						<th>
							Category <em>*</em>
						</th>
						<th>Description</th>
						<th class="small">
							Time <em>*</em>
						</th>
						<th class="small">Overtime</th>
					</tr>
                    {props.timeSheetsForDateList.map((timeSheet) => (
                        <TimeSheetDailyItem timeSheet={timeSheet}/>	 
                    ))}
                   	<tr>
						<td>
							<select onChange={handleChangeClient}>
								{props.clientsList.map((client)=>(
									<option value={client.id}>{client.name}</option>
								))}
							</select>
						</td>
						<td>
							<select onChange={handleChangeProject}>
								<option>Choose project</option>
								{props.projectsForClientList.map((project)=>(
									<option value={project.id}>{project.name}</option>
								))}
							</select>
						</td>
						<td>
							<select onChange={handleChangeCategory}>
								{props.categoriesList.map((category)=>(
									<option value={category.id}>{category.name}</option>
								))}
							</select>
						</td>
						<td>
							<input type="text" onChange={handleChangeDescription} value={description} class="in-text medium" />
						</td>
						<td class="small">
							<input type="text" onChange={handleChangeTime} value={time} class="in-text xsmall" />
						</td>
						<td class="small">
							<input type="text" onChange={handleChangeOvertime} value={overtime} class="in-text xsmall" />
						</td>
                        <td class="small">
							
                            <a href="javascript:;" onClick={save} class="btn green" disabled="true">Save</a>
                        </td>
					</tr>		
				</table>
				<div class="total">
					<a onClick={back}><i></i>back to monthly view</a>
					<span>Total hours: <em>7.5</em></span>
				</div>
			</section>			
		</div>
		
	</div>
    );
}


const mapStateToProps = (state) =>

    ({ timeSheetsForDateList: state.timeSheetsForDateList, projectsForClientList: state.projectsForClientList, clientsList: state.clientsList, categoriesList: state.categoriesList })

export default withRouter(connect(mapStateToProps, { getAllTimeSheetsForDate, getAllProjectsForClient, getAllClients, getAllCategory,createTimeSheet}) (TimeSheetDaily));