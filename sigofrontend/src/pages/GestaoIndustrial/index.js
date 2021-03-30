import React ,{useState, useEffect} from 'react';
import {Link, useHistory} from 'react-router-dom';
import {FiPower, FiAlignJustify, FiTrash2, FiEdit2, FiArrowLeft, FiSearch} from 'react-icons/fi';

import api from '../../services/api';

import './styles.css';

import logoImg from '../../assets/logo.jpeg'

function GestaoIndustrial() {

  const history = useHistory();

  const [active, setActive] = useState(false);
  const [idBusca, setIdBusca] = useState(0);
  const [processos, setProcessos] = useState([]);  
  const token = localStorage.getItem('token');

  useEffect(()=>{
    api.get('https://wu63epzr79.execute-api.us-east-1.amazonaws.com//GestaoProcessos//api//Processos//', {
      headers: {
        Authorization:  'bearer ' + token
      }
    }).then(response=>{
      setProcessos(response.data);
    })
  }, [token]);

  if(token === null)
    history.push('/');

  function handleLogout(id){
      localStorage.clear();
      history.push('/');
    }

    function handleBuscaProcesso(id){
      if(id == ""){
        api.get(`https://wu63epzr79.execute-api.us-east-1.amazonaws.com//GestaoProcessos//api//Processos//`, {
        headers: {
            Authorization:  'bearer ' + token
          }
          }).then(response=>{
            setProcessos(response.data); })
        }   
        else{
          setProcessos(processos.filter(processo=> processo.id == id)); 
        }  
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
             <h1>Módulo de Gestão do Processo Industrial</h1>        
             </div>
             <div className="buscariten">  
             <input onChange={e => { setIdBusca(e.target.value) }} className="inputBusca" placeholder = "Buscar ID de Processo Industrial"     />
             
             <button onClick={() => handleBuscaProcesso(idBusca) } button className="buttonBusca" type ="button">
                      <FiSearch size = {25} color = "#581919"/>
              </button>   

             </div>             
             <ul>
             {processos.map(processo => (
                  <li  key={processo.id}> 

                  <strong>Id:</strong>
                  <p>{processo.id}</p>
               
                  <strong>Descrição:</strong>
                  <p>{processo.descricao}</p>

                  <strong>Preço Venda:</strong>
                  <p>{processo.precoVenda.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</p>

                  <strong>Custo:</strong>
                  <p>{processo.custo.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })}</p>

                  <strong>Máquinas Utilizadas:</strong>
                  <p>{processo.qatdeMarquinasUtilizadas}</p>

                  <strong>Horas Estimadas:</strong>
                  <p>{processo.horasEstimadas}</p>

                  <strong>Norma:</strong>
                  <p>{processo.norma}</p>

                  <strong>Status:</strong>
                  <p className={`${(processo.status == 1) ? 'statusativo' : 'statusinativo'}`}>{`${(processo.status == 1) ? 'ATIVO' : 'EM FALHA'}`}</p>
                </li>        
                ) ) }             
            </ul>
            <Link className="back-link" to= "/profile">
                 <FiArrowLeft size={16} />
                 Voltar para home
            </Link>
            </div>
      );
}

export default GestaoIndustrial;