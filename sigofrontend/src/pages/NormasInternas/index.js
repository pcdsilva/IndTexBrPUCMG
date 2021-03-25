import React ,{useState, useEffect} from 'react';
import {Link, useHistory} from 'react-router-dom';
import {FiPower, FiAlignJustify, FiTrash2, FiEdit2, FiArrowLeft, FiSearch} from 'react-icons/fi';

import api from '../../services/api';

import './styles.css';

import logoImg from '../../assets/logo.jpeg'

function NormasInternas() {

  const history = useHistory();

  const [active, setActive] = useState(false)
  const [normas, setNormas] = useState([]);  
  const token = localStorage.getItem('token');

  useEffect(()=>{
    api.get('https://wu63epzr79.execute-api.us-east-1.amazonaws.com//GestaoNormas//api//Normas//', {
      headers: {
        Authorization:  'bearer ' + token
      }
    }).then(response=>{
        setNormas(response.data);
    })
  }, [token]);

  if(token === null)
    history.push('/');

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

             <div className="incluiriten">  
             <h1>Normas Internas</h1>        
             <Link className ="buttonAdd" to="/normas/add">Incluir</Link> 
             </div>
             <div className="buscariten">  
             <input className="inputBusca" placeholder = "Buscar Norma Interna"     />
             
             <button className="buttonBusca" type ="button">
                      <FiSearch size = {25} color = "#581919"/>
              </button>   

             </div>             
             <ul>
             {normas.map(norma => (
                  <li  key={norma.id}> 
                  <button  type ="button">
                      <FiEdit2 size = {20} color = "#a8a8b3" />
                      <p>Editar</p>
                  </button>              
                  <button  type ="button">
                      <FiTrash2 size = {20} color = "#a8a8b3" />
                      <p>Excluir</p>
                  </button>    

                  <strong>Nome:</strong>
                  <p>{norma.nome}</p>

                  <strong>Categoria</strong>
                  <p>{norma.categoria}</p>

                  <strong>Ano Publicação:</strong>
                  <p>{norma.anoPublicaçao}</p>

                  <strong>Atualizada em::</strong>
                  <p>{norma.dataAtualizacao}</p>

                  <strong>Descrição:</strong>
                  <p>{norma.descricao}</p>

                  <strong>Link do Documento:</strong>
                  <p>{norma.link}</p>
                </li>        
                ) ) }             
            </ul>
            <Link className="back-link" to= "/normas">
                 <FiArrowLeft size={16} />
                 Voltar para normas
            </Link>
            <Link className="back-link" to= "/profile">
                 <FiArrowLeft size={16} />
                 Voltar para home
            </Link>
            </div>
      );
}

export default NormasInternas;