import React, {useEffect, useState} from "react"
import { NavLink } from "react-router-dom"
import NavigationBar from "./NavigationBar"

function Header(props)  {
const [activePage,setActivePage] = useState("");
const handleClient = () =>{
    setActivePage("clients")
}
const handleProject = () =>{
    setActivePage("projects")
}
    return(
        <header class="header">
			<div class="top-bar"></div>
			<div class="wrapper">
				<a href="index.html" class="logo">
					<img src="assets/img/logo.png" alt="VegaITSourcing Timesheet" />
				</a>
				<ul class="user right">
					<li>
						<a href="javascript:;">{sessionStorage.getItem("name")}</a>
						<div class="invisible"></div>
						<div class="user-menu">
							<ul>
								<li>
									<a href="javascript:;" class="link">Change password</a>
								</li>
								<li>
									<a href="javascript:;" class="link">Settings</a>
								</li>
								<li>
									<a href="javascript:;" class="link">Export all data</a>
								</li>
							</ul>
						</div>
					</li>
					<li class="last">
                    <NavLink exact to="/">Logout</NavLink>
					</li>
				</ul>
                <NavigationBar/>
			</div>
		</header>
    );
}
export default Header