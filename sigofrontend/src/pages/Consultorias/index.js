import React ,{useState, useEffect} from 'react';
import {Link, useHistory} from 'react-router-dom';
import {FiPower, FiAlignJustify, FiTrash2, FiEdit2, FiArrowLeft, FiSearch} from 'react-icons/fi';

import api from '../../services/api';

import './styles.css';

import logoImg from '../../assets/logo.jpeg'

function Consultorias() {

  const history = useHistory();

  const [active, setActive] = useState(false);
  const [idBusca, setIdBusca] = useState(0);
  const [consultorias, setConsultorias] = useState([]);  
  const token = localStorage.getItem('token');

  useEffect(()=>{
    api.get('https://wu63epzr79.execute-api.us-east-1.amazonaws.com//ConsultoriaAssessoria//api//Consultorias//', {
      headers: {
        Authorization:  'bearer ' + token
      }
    }).then(response=>{
        setConsultorias(response.data);
    })
  }, [token]);

  if(token === null)
    history.push('/');

  function handleLogout(id){
      localStorage.clear();
      history.push('/');
    }

    function handleBuscaConsultoria(id){
      if(id == ""){
        api.get(`https://wu63epzr79.execute-api.us-east-1.amazonaws.com//ConsultoriaAssessoria//api//Consultorias//`, {
        headers: {
            Authorization:  'bearer ' + token
          }
          }).then(response=>{
                 setConsultorias(response.data); })
        }   
        else{
          setConsultorias(consultorias.filter(consultoria=> consultoria.id == id)); 
        }  
    }

    function handleEditConsultoria(consultoria){
      history.push({
        pathname: `/consultoriaedit/`,
        state: { data: consultoria }
      });
    }

    async function handleDeleteConsultoria(id){
      try{
        await api.delete(`https://wu63epzr79.execute-api.us-east-1.amazonaws.com//ConsultoriaAssessoria//api//Consultorias//${id}`, {
          headers:{
            Authorization:  'bearer ' + token
          }
        });
  
        setConsultorias(consultorias.filter(consultoria=> consultoria.id !== id));
      } catch(err){
        alert('Erro ao deletar consultoria, tente novamente')
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
             <h1>Módulo de Consultorias e Assessorias</h1>        
             <Link className ="buttonAdd" to={
               {
                 pathname: "/consultoriaadd",
                 state: { data: null },
             }
            }>Incluir</Link> 
             </div>
             <div className="buscariten">  
             <input onChange={e => { setIdBusca(e.target.value) }} className="inputBusca"  type="text" placeholder = "Buscar ID de Consultoria" />
             
             <button onClick={() => handleBuscaConsultoria(idBusca) } className="buttonBusca" type ="button">
                      <FiSearch size = {25} color = "#581919"/>
              </button>   

             </div>             
             <ul>
             {consultorias.map(consultoria => (
                  <li  key={consultoria.id}> 
                  <button  onClick={() => handleEditConsultoria(consultoria) }type ="button">
                      <FiEdit2 size = {20} color = "#a8a8b3" />
                      <p>Editar</p>
                  </button>              
                  <button onClick={() => handleDeleteConsultoria(consultoria.id) }  type ="button">
                      <FiTrash2 size = {20} color = "#a8a8b3" />
                      <p>Excluir</p>
                  </button>    

                  <strong>Id:</strong>
                  <p>{consultoria.id}</p>

                  <strong>Departamento:</strong>
                  <p>{consultoria.departamento}</p>

                  <strong>Setor:</strong>
                  <p>{consultoria.setor}</p>

                  <strong>Razão Social:</strong>
                  <p>{consultoria.razaoSocial}</p>

                  <strong>Nome Fantasia:</strong>
                  <p>{consultoria.nomeFantasia}</p>

                  <strong>CNPJ:</strong>
                  <p>{consultoria.cnpj}</p>

                  <strong>Data Contratação:</strong>
                  <p>{consultoria.dtContratacao}</p>

                  <strong>Período Contratação:</strong>
                  <p>{consultoria.periodoContratacao}</p>

                  <strong>Em atividade:</strong>
                  <p className={`${(consultoria.ativo == 'Sim') ? 'statusativo' : 'statusinativo'}`}>{consultoria.ativo}</p>

                  <strong>Data Início:</strong>
                  <p>{consultoria.dtInicio}</p>

                  <strong>Data Término:</strong>
                  <p>{consultoria.dtTermino}</p>

                  <strong>Norma:</strong>
                  <p>{consultoria.norma}</p>
                  
                  <strong>Descrição:</strong>
                  <p>{consultoria.descricao}</p>
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

export default Consultorias;