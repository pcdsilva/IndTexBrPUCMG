import React ,{useState, useEffect} from 'react';
import {Link, Redirect, useHistory} from 'react-router-dom';
import {FiPower, FiAlignJustify, FiTrash2, FiEdit2, FiArrowLeft, FiSearch} from 'react-icons/fi';

import api from '../../services/api';

import './styles.css';

import logoImg from '../../assets/logo.jpeg'

function NormasInternas() {

  const history = useHistory();

  const [active, setActive] = useState(false);
  const [idBusca, setIdBusca] = useState(0);
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

    function handleBuscaNorma(id){
      if(id == ""){
        api.get(`https://wu63epzr79.execute-api.us-east-1.amazonaws.com//GestaoNormas//api//Normas//`, {
        headers: {
            Authorization:  'bearer ' + token
          }
          }).then(response=>{
            setNormas(response.data); })
        }   
        else{
          setNormas(normas.filter(norma=> norma.id == id)); 
        }  
    }

    async function handleDeleteNorma(id){
      try{
        await api.delete(`https://wu63epzr79.execute-api.us-east-1.amazonaws.com//GestaoNormas//api//Normas//${id}`, {
          headers:{
            Authorization:  'bearer ' + token
          }
        });
  
        setNormas(normas.filter(norma=> norma.id !== id));
      } catch(err){
        alert('Erro ao deletar norma, tente novamente')
      }
    }

    function handleEditNorma(norma){
      history.push({
        pathname: `/normasinternasedit/`,
        state: { data: norma }
      });
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
             <Link className ="buttonAdd" to="/normasinternasadd">Incluir</Link> 
             </div>
             <div className="buscariten">  
             <input onChange={e => { setIdBusca(e.target.value) }} className="inputBusca" placeholder = "Buscar ID de Norma Interna"     />
             
             <button onClick={() => handleBuscaNorma(idBusca) } className="buttonBusca" type ="button">
                      <FiSearch size = {25} color = "#581919"/>
              </button>   

             </div>             
             <ul>
             {normas.map(norma => (
                  <li  key={norma.id}> 
                  <button  onClick={() => handleEditNorma(norma) } type ="button">
                      <FiEdit2 size = {20} color = "#a8a8b3" />
                      <p>Editar</p>
                  </button>              
                  <button  onClick={() => handleDeleteNorma(norma.id) } type ="button">
                      <FiTrash2 size = {20} color = "#a8a8b3" />
                      <p>Excluir</p>
                  </button>    

                  <strong>Id:</strong>
                  <p>{norma.id}</p>

                  <strong>Nome:</strong>
                  <p>{norma.nome}</p>

                  <strong>Categoria:</strong>
                  <p>{norma.categoria}</p>

                  <strong>Ano Publicação:</strong>
                  <p>{norma.anoPublicaçao}</p>

                  <strong>Atualizada em:</strong>
                  <p>{norma.dataAtualizacao}</p>

                  <strong>Descrição:</strong>
                  <p>{norma.descricao}</p>

                  <strong>Link do Documento:</strong>
                  <div><p><a className = 'button' target="_blank" href={norma.link}>Acessar</a></p></div>
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