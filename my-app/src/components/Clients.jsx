import React, {useEffect, useState} from "react"
import { connect } from "react-redux"
import { getAllClients } from "../actions/clientActions"
import ClientItem from "./ClientItem"
import ClientModal from "./ClientModal"
import Header from "./Header"
import Footer from "./Footer"

function Clients(props)  {
	const [displayDetails,setDisplayDetails] = useState(false);
    const [showModal,setShowModal] = useState(false);
	const [searchTerm, setSearchTerm] = useState("");
	const [searchLetter,setSearchLetter] = useState("");
	const [disabledLetters, setDisabledLetters] = useState(""); //ovu korsiti useState([]);
	const [invalidLetters, setInvalidLetters] = useState([]);
	const allLetters = ["a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","v","p","q","r","s","t","u","w","x","y","z"]
	const disableLetters = []; //
	const clients = props.clientsList;
	const disable = (allClients) =>{
		if(!allClients || !allClients.length){
			return;
		}
		const validLetters = [];
		debugger;			
		for(const value of allClients){	
			validLetters.push(value.name.charAt(0).toLowerCase())
		}
		setInvalidLetters(allLetters.filter(e => !validLetters.includes(e)))
	}

	

	  useEffect(() => {
			props.getAllClients();//dodaj clients u zagradu radi auto update tabele			
	 	 }, [clients]);

	useEffect(() => {
		disable(clients);
	
	}, [clients]);
	  
    const displayModalCreate = () => {
        setShowModal(!showModal);
      }
        debugger;
        if (props.clientsList === undefined) {
            return null;
        }
	const click = (letter) =>{
		if(searchLetter == letter){
			setSearchLetter("");
		} else {
			setSearchLetter(letter);
		}
	}
	
	
    return (
            
	
        <div class="container">
		{showModal ? (
		<ClientModal
		show={showModal}
		onShowChange={displayModalCreate}
		/>
        ) : null}
		<div class="wrapper">
			<section class="content">
				<h2><i class="ico clients"></i>Clients</h2>
				<div class="grey-box-wrap reports">
                <a
                    href="javascript:;"
                    onClick={displayModalCreate}
                >
              Create new client
            </a>
					<div class="search-page">
						<input type="search" onChange={(event) => {setSearchTerm(event.target.value)}} name="search-clients" class="in-search" />
					</div>
				</div>
				<div class="new-member-wrap">
					<div id="new-member" class="new-member-inner">
						<h2>Create new client</h2>
						<ul class="form">
							<li>
								<label>Client name:</label>
								<input type="text" class="in-text" />
							</li>								
							<li>
								<label>Address:</label>
								<input type="text" class="in-text" />
							</li>
							<li>
								<label>City:</label>
								<input type="text" class="in-text" />
							</li>
							<li>
								<label>Zip/Postal code:</label>
								<input type="text" class="in-text" />
							</li>
							<li>
								<label>Country:</label>
								<select>
									<option>Select country</option>
								</select>
							</li>
						</ul>
						<div class="buttons">
							<div class="inner">
								<a href="javascript:;" class="btn green">Save</a>
							</div>
						</div>
					</div>
				</div>
				<div class="alpha">
					<ul>
						{allLetters.map((letter)=>(
							<li class={invalidLetters.includes(letter) ? "disabled" : (searchLetter == letter ? "active" : "")}>
							<a onClick={() =>click(letter)} href="javascript:;">{letter}</a>
							</li>
						))}
					</ul>
				</div>
				<div class="accordion-wrap clients">
                {clients.filter((value) => {
					if(searchLetter == ""){
						return value
					}else if (value.name.toLowerCase().startsWith(searchLetter.toLowerCase())){
						return value
						}
				}).filter((value) => {
					if(searchTerm == ""){
						return value
					} else if (value.name.toLowerCase().includes(searchTerm.toLowerCase())){
					return value
					}
				}).map((client) => (
				    <ClientItem key={client.id} id={client.id} name={client.name} city={client.city} address = {client.address} postalCode = {client.postalCode} country = {client.country}/>
				))}		
                    
				</div>
				<div class="pagination">
					<ul>
						<li>
							<a href="javascript:;">1</a>
						</li>
						<li>
							<a href="javascript:;">2</a>
						</li>
						<li>
							<a href="javascript:;">3</a>
						</li>
						<li class="last">
							<a href="javascript:;">Next</a>
						</li>
					</ul>
				</div>
			</section>			
		</div>
	</div>

					


        );
    }

  


    const mapStateToProps = (state) =>
    
        ({ clientsList: state.clientsList })
    
    export default connect(mapStateToProps, { getAllClients })(Clients);
