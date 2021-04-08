import React ,{useState} from 'react';
import {Link, useHistory} from 'react-router-dom';
import {FiPower, FiAlignJustify, FiTrash2, FiEdit2, FiArrowLeft, FiSearch} from 'react-icons/fi';
import InputFloat from 'react-floating-input';

import api from '../../services/api';

import './styles.css';

import logoImg from '../../assets/logo.jpeg'

function NormasInternasAdd() {

  const history = useHistory();

  const [active, setActive] = useState(false);
  const [nome, setNome] = useState('');
  const [categoria, setCategoria] = useState('');
  const [anoPublicaçao, setAnoPublicaçao] = useState('');
  const [dataAtualizacao, setDataAtualizacao] = useState('');
  const [descricao, setDescricao] = useState('');
  const [link, setLink] = useState('');
 
  const token = localStorage.getItem('token');

   if(token === null)
     history.push('/');

  function handleLogout(id){
      localStorage.clear();
      history.push('/');
    }

    async  function hendleAddNormaInterna(e){
        e.preventDefault();

        const data = {
          nome,
          categoria,
          anoPublicaçao,
          dataAtualizacao,
          descricao,
          link
        };

        try{
            await api.post('https://wu63epzr79.execute-api.us-east-1.amazonaws.com//GestaoNormas//api//Normas//', data, {
                headers:{
                   Authorization:  'bearer ' + token
                }
            })
            history.push('/normasinternas');
        }catch(err){
            alert('Erro ao cadastrar norma, tente novamente.')
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
            <h1>Nova Norma Interna</h1> 
            <form className="form" onSubmit = {hendleAddNormaInterna}>
            <div className = "inputFloat">   

                <InputFloat clasName = "inputFloat"
                color = "#581919"
                activeColor = "#581919"                
                value={nome}
                onChange={e=>setNome(e.target.value)}
                placeholder="Nome"/>    
                </div>       
                <div className = "inputFloat">           
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={categoria}
                onChange={e=>setCategoria(e.target.value)}
                placeholder="Categoria"/>
                </div>  
                <div className = "inputFloat">    
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={anoPublicaçao}
                onChange={e=>setAnoPublicaçao(e.target.value)}
                placeholder="Ano Publicação"/>
                </div>    
                <div className = "inputFloat">  
                 <InputFloat 
                color = "#581919"
                activeColor = "#581919"                 
                value={dataAtualizacao}
                onChange={e=>setDataAtualizacao(e.target.value)}
                placeholder="Atualizada em"/>
                </div>     
                <div className = "inputFloat">                    
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={descricao}
                onChange={e=>setDescricao(e.target.value)}
                placeholder="Descrição"/> 
                </div>   
                <div className = "inputFloat">                                  
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"
                value={link}
                onChange={e=>setLink(e.target.value)}
                placeholder="Link do Documento"/>
                </div>                    
                <button className="button" type="submit">Incluir</button>
        </form>           
             
            <Link className="back-link" to= "/normasinternas">
                 <FiArrowLeft size={16} />
                 Voltar para normas internas
            </Link>
            <Link className="back-link" to= "/profile">
                 <FiArrowLeft size={16} />
                 Voltar para home
            </Link>
            </div>
      ); 
}

export default NormasInternasAdd;