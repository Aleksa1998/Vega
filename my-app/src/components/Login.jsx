import React, { useState } from "react"
import { userLoggedIn } from "../actions/actions"
import { connect } from "react-redux"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import  { Redirect } from 'react-router-dom'
import {withRouter} from 'react-router'

function Login(props)  {
    const [username,setUsername] = useState("");
    const [password,setPassword] = useState("");
    const [checked, setChecked] = useState(false);

    const handleChangeUsername = (event) => {
        setUsername(event.target.value);
    }
    const handleChangePassword = (event) => {
        setPassword(event.target.value);
    }
    const handleChecked = () => {
        if(checked == false) {
            setChecked(true)
        } else {
            setChecked(false)
        }
    }
    const login = async () => {
        var successful = false;
        successful = await props.userLoggedIn({username, password, checked})
        debugger;
        if(successful === true){
                props.history.push("/project");
                return;
        }
        toast.configure();
        toast.error("Unsuccessful!", {
            position: toast.POSITION.TOP_RIGHT
        });
        return;       
    }
        debugger;
        return (

                <div className="wrap bg-white pt-3 pb-3" style={{height: "100vh"}}> 
                
                    <div class="wrapper centered">
		<div class="logo-wrap">
			<a href="index.html" class="inner">
				<img src="assets/img/logo-large.png" />
			</a>
		</div>
		<div class="centered-content-wrap">
			<div class="centered-block">
				<h1>Login</h1>
				<ul>
					<li>
						<input type="text" placeholder="Email"  onChange={handleChangeUsername} class="in-text large" />
					</li>
					<li>
						<input type="password" placeholder="Password" onChange={handleChangePassword} class="in-pass large" />
					</li>
					<li class="last">
						<input type="checkbox" onChange={handleChecked}  class="in-checkbox" id="remember"/>
						<label class="in-label" for="remember">Remember me</label>
						<span class="right">
							<a href="javascript:;" class="link">Forgot password?</a>
							<a href="javascript:;" disabled={username == "" || password == ""} onClick={login}  class="btn orange">Login</a>
						</span>
					</li>
				</ul>
			</div>
		</div>
	</div>
                </div>
                



        );
   
    
}

const mapStateToProps = (state) =>

    ({  })

export default withRouter(connect(mapStateToProps, { userLoggedIn}) (Login));