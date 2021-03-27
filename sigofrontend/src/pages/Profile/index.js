import React ,{useState} from 'react';
import {Link, useHistory} from 'react-router-dom';
import {FiPower, FiAlignJustify} from 'react-icons/fi';

import api from '../../services/api';

import './styles.css';

import logoImg from '../../assets/logo.jpeg'

function Profile() {

  const history = useHistory();

  const [active, setActive] = useState(false);
  
  const userName = localStorage.getItem('userName');
  const token = localStorage.getItem('token');
  let userRole = localStorage.getItem('userRole')

  if(token === null || userRole === null || userName === null)
    history.push('/');
  else
    userRole = userRole.substring(2, 15);  

    function handleLogout(id){
      localStorage.clear();
      history.push('/');
    }

    
    return ( 
        <div className="profile-container"  >
                         
                      <div className="sidenav" className={`${active ? 'sidenav' : 'sidenavHiden'}`}> 
                      <button className="buttonsidebar" onClick={() => { setActive(!active) }} type = 'button'   >
                        <FiAlignJustify size = {25} color = "#581919" />
                      </button>      
                        <a href="/profile">Home</a>
                        <a href="/consultorias">Consultorias</a>
                        <a href="/normas">Normas</a>
                        <a href="/gestaoindustrial">Gestão Industrial</a>
                      </div>   
            
            <header >
                  <button onClick={() => { setActive(!active) }} type = 'button'   >
                    <FiAlignJustify size = {25} color = "#581919" />
                  </button>
                  <img src = {logoImg} alt = "S.I.G.O." />
                  <button  onClick={handleLogout} type = 'button' >
                    <FiPower size = {25} color = "#581919" />
                  </button>
            </header>     

             <div className="maininfo">  
             <h1>Bem vindo,  {userName} ({userRole}) </h1>
            <Link className ="button" to="/consultorias">Consultorias</Link>
            <Link className ="button" to="/normas">Normas</Link>
            <Link className ="button" to="/gestaoindustrial">Gestão Industrial</Link>
            </div>
            </div>
      );
}

export default Profile;