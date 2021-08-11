import React, {useEffect, useState} from "react";
import { getAllCountries } from "../actions/countryActions"
import { updateClient } from "../actions/clientActions"
import { connect } from "react-redux"

function ClientItem(client)  {
	const [displayDetails,setDisplayDetails] = useState(false);
    const [name,setName] = useState(client.name);
    const [city,setCity] = useState(client.city);
    const [postalCode,setPostalCode] = useState(client.postalCode);
    const [address,setAddress] = useState(client.address);
    const [country,setCountry] = useState(client.country);
	const {name2, city2, postalCode2, address2} = client;
	const id = client.id;
	const open = () => {
		setDisplayDetails(!displayDetails);
	};

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
	useEffect(()=>{
		client.getAllCountries()
	  },[])
	if (client.countriesList === undefined) {
	return null;
	}
	const update = async () => {
		var successful = false;
		successful = await client.updateClient({id ,name, address, city, postalCode, country})
		debugger;
		return;       
		}
	const countries = client.countriesList;
    return (
        <div className={(displayDetails === false) ? "item" : "item open"}>
						<div className="heading" onClick={open}>
                            <span>{name}</span>
							<i>+</i>
						</div>
						<div class="details" style={{
                            overflow: "hidden",
                             display: displayDetails === false ? "none" : "block",
                        }}>
							<ul class="form">
								<li>
									<label>Client name:</label>
									<input type="text" value={name} onChange={handleChangeName} class="in-text" />
								</li>
								<li>
									<label>Zip/Postal code:</label>
									<input type="text" value={postalCode} onChange={handleChangePostalCode} class="in-text" />
								</li>
							</ul>
							<ul class="form">
								<li>
									<label>Address:</label>
									<input type="text" value={address} onChange={handleChangeAddress} class="in-text" />
								</li>
								<li>
									<label>Country:</label>
									<select onChange={handleChangeCountry}>
									{countries.map((country) => (
									<option>{country.name}</option>
                ))}
									</select>
								</li>
							</ul>
							<ul class="form last">
								<li>
									<label>City:</label>
									<input type="text" value={city} onChange={handleChangeCity} class="in-text" />
								</li>
							</ul>
							<div class="buttons">
								<div class="inner">
									<a href="javascript:;" class="btn green" onClick={update}>Save</a>
									<a href="javascript:;" class="btn red">Delete</a>
								</div>
							</div>
						</div>
					</div>
    );
}

const mapStateToProps = (state) =>
    
        ({ countriesList: state.countriesList })  

export default connect(mapStateToProps, { getAllCountries , updateClient})(ClientItem);