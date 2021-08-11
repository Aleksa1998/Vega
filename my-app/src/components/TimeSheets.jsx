import React, {useEffect, useState} from "react"
import { connect } from "react-redux"
import { getAllTimeSheets } from "../actions/timeSheetActions"
import TimeSheetItem from "./TimeSheetItem"
import Header from "./Header"
import Footer from "./Footer"
import moment from "moment";

function TimeSheets(props)  {
const [totalHours, setTotalHours] = useState(0);
const [date, setDate] = useState(new Date());
const timeSheets = props.timeSheetsList;
async function load() {
	await props.getAllTimeSheets(date);
}
const loadTotalHours = (timeSheets) => {
    debugger;
	if(!timeSheets || !timeSheets.length){
		return;
	}
	let totalHoursCounted = 0;
	for(const oneTimeSheet of timeSheets){
		totalHoursCounted += oneTimeSheet.totalHours
	}
    setTotalHours(totalHoursCounted)
}
useEffect(() => {
    props.getAllTimeSheets(date);
  }, [date]);
  useEffect(() => {
    loadTotalHours(timeSheets);
  }, [timeSheets]);

if (props.timeSheetsList === undefined) {
    return null;
}

const hours = () => loadTotalHours();
const getRows = () => {
    const numberOfRows = Math.floor(props.timeSheetsList.length / 7);
    const rows = [];
    Array.from(
      { length: numberOfRows },
      (x, i) => (rows[i] = props.timeSheetsList.slice(i * 7, (i + 1) * 7))
    );
    return rows;
  }
const rows = getRows();


  const AllDates = () => rows.map((row) => <tr>{CalendarItemsList(row)}</tr>);

  const CalendarItemsList = (row) =>
    row.map((timeSheetDay) => (
      <TimeSheetItem key={timeSheetDay} day={timeSheetDay} />
    ));
const previous = () => {
    debugger;
    const date2 = new Date(date);
    date2.setMonth(date2.getMonth() - 1);
    setDate(date2);
}
const next = () => {
    debugger;
    const date2 = new Date(date);
    date2.setMonth(date2.getMonth() + 1);
    setDate(date2);
}
    return(
        <div class="container">
		<div class="wrapper">
			<section class="content">
				<h2><i class="ico timesheet"></i>TimeSheet</h2>
				<div class="grey-box-wrap">
					<div class="top">
						<a href="javascript:;" onClick={previous} class="prev"><i class="zmdi zmdi-chevron-left" ></i>previous month</a>
						<span class="center">{moment(date).format("MM/YYYY")}</span>
						<a href="javascript:;" class="next" onClick={next}>next month<i class="zmdi zmdi-chevron-right"></i></a>
					</div>
					<div class="bottom">
						
					</div>
				</div>
				<table class="month-table">
					<tr class="head">
						<th><span>monday</span></th>
						<th>tuesday</th>
						<th>wednesday</th>
						<th>thursday</th>
						<th>friday</th>
						<th>saturday</th>
						<th>sunday</th>
					</tr>
					<tr class="mobile-head">
						<th>mon</th>
						<th>tue</th>
						<th>wed</th>
						<th>thu</th>
						<th>fri</th>
						<th>sat</th>
						<th>sun</th>
					</tr>                   
                    <AllDates/>                               
				</table>
				<div class="total">
					<span>Total hours: <em>{totalHours}</em></span>
				</div>
			</section>			
		</div>
	</div>
    );

}

const mapStateToProps = (state) =>
    
({ timeSheetsList: state.timeSheetsList })

export default connect(mapStateToProps, { getAllTimeSheets })(TimeSheets);