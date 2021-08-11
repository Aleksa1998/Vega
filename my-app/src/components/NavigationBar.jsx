import React, {useEffect, useState} from "react"
import { NavLink } from "react-router-dom"


function NavigationBar(props)  {
    const [activePage,setActivePage] = useState("");
    const handleClient = () =>{
        setActivePage("clients")
    }
    const handleProject = () =>{
        setActivePage("projects")
    }
	const handleTimeSheet = () =>{
        setActivePage("timesheets")
    }
    return(
        <nav>
					<ul class="menu">
						<li>
                            <NavLink exact to="/timesheets" onClick={handleTimeSheet} className={activePage == "timesheets" ? "btn nav active" : "btn nav "}>TimeSheet</NavLink>
						</li>
						<li>
							<NavLink exact to="/clients" onClick={handleClient} className={activePage == "clients" ? "btn nav active" : "btn nav "}>Clients</NavLink>
						</li>
						<li>
                            <NavLink exact to="/project" onClick={handleProject} className={activePage == "projects" ? "btn nav active" : "btn nav "}>Projects</NavLink>
						</li>
						<li>
							<a href="categories.html" class="btn nav">Categories</a>
						</li>
						<li>
							<a href="team-members.html" class="btn nav">Team members</a>
						</li>
						<li class="last">
							<a href="reports.html" class="btn nav">Reports</a>
						</li>
					</ul>
					<div class="mobile-menu">
						<a href="javascript:;" class="menu-btn">
							<i class="zmdi zmdi-menu"></i>
						</a>
						<ul>
							<li>
								<a href="javascript:;" onClick={handleTimeSheet} >TimeSheet</a>
							</li>
							<li>
								<a href="javascript:;" onClick={handleClient} >Clients</a>
							</li>
							<li>
								<a href="javascript:;" onClick={handleProject}>Projects</a>
							</li>
							<li>
								<a href="javascript:;">Categories</a>
							</li>
							<li>
								<a href="javascript:;">Team members</a>
							</li>
							<li class="last">
								<a href="javascript:;">Reports</a>
							</li>
						</ul>
					</div>					
					<span class="line"></span>
				</nav>
    );
}

export default NavigationBar