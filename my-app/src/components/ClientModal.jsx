import React, {useEffect, useState} from "react"
import { connect } from "react-redux"
import { getAllCountries } from "../actions/countryActions"
import { createClient } from "../actions/clientActions"
import "../css/App.css"
import { Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import {withRouter} from 'react-router'

function ClientModal(props)  {
    const [name,setName] = useState("");
    const [city,setCity] = useState("");
    const [postalCode,setPostalCode] = useState("");
    const [address,setAddress] = useState("");
    const [countryId,setCountry] = useState("");
    const [showModal,setShowModal] = useState(props.show);

    useEffect(()=>{
		props.getAllCountries()
	  },[])

    const handleChangeName = (event) => {
        setName(event.target.value);
    }
    const handleChangeCity = (event) => {
        setCity(event.target.value);
    }
    const handleChangePostalCode = (event) => {
        setPostalCode(event.target.value);
    }
    const handleChangeAddress = (event) => {
        setAddress(event.target.value);
    }
    const handleChangeCountry = (event) => {
        debugger;
        setCountry(event.target.value);
      };
    
    const create = async () => {
    var successful = false;
    successful = await props.createClient({name, address, city, postalCode, countryId})
    toggle();
    debugger;
    return;       
    }
  
    const toggle = () => {
        setShowModal(false);
        props.onShowChange();
      }
      if (props.countriesList === undefined) {
        return null;
    }
    return (
        <Modal isOpen={showModal} centered={true}>
        <ModalHeader toggle={toggle}></ModalHeader>
        <ModalBody>
        <div id="new-member" className="new-member-inner">
						<h2>Create new client</h2>
						<ul className="form">
							<li>
								<label>Client name:</label>
								<input type="text" onChange={handleChangeName} className="in-text" />
							</li>								
							<li>
								<label>Address:</label>
								<input type="text" onChange={handleChangeAddress} className="in-text" />
							</li>
							<li>
								<label>City:</label>
								<input type="text" onChange={handleChangeCity} className="in-text" />
							</li>
							<li>
								<label>Zip/Postal code:</label>
								<input type="text" onChange={handleChangePostalCode} className="in-text" />
							</li>
							<li>
								<label>Country:</label>
								<select onChange={handleChangeCountry}>
                {props.countriesList.map((country) => (
									<option value={country.id}>{country.name}</option>
                ))}	
								</select>
							</li>
						</ul>
        </div>
        </ModalBody>
        <ModalFooter>
						<div className="buttons">
							<div className="inner">
								<a href="javascript:;" onClick={create} className="btn green">Save</a>
							</div>
						</div>
					
        </ModalFooter>       
      </Modal>
    );
}

const mapStateToProps = (state) =>
    
        ({ countriesList: state.countriesList })
    
export default withRouter(connect(mapStateToProps, { getAllCountries, createClient })(ClientModal));