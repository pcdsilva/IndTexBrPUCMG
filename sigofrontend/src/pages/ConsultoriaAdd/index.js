import React ,{useState} from 'react';
import {Link, useHistory} from 'react-router-dom';
import {FiPower, FiAlignJustify, FiTrash2, FiEdit2, FiArrowLeft, FiSearch} from 'react-icons/fi';
import InputFloat from 'react-floating-input';

import api from '../../services/api';

import './styles.css';

import logoImg from '../../assets/logo.jpeg'

function ConsultoriaAdd() {

  const history = useHistory();

  const [active, setActive] = useState(false);
  const [departamento, setDepartamento] = useState('');
  const [setor, setSetor] = useState('');
  const [razaoSocial, setRazaoSocial] = useState('');
  const [nomeFantasia, setNomeFantasia] = useState('');
  const [cnpj, setCnpj] = useState('');
  const [dtContratacao, setDtContratacao] = useState('');
  const [periodoContratacao, setPeriodoContratacao] = useState('');
  const [ativo, setAtivo] = useState('');
  const [dtInicio, setDtInicio] = useState('');
  const [dtTermino, setDtTermino] = useState('');
  const [norma, setNorma] = useState('');
  const [descricao, setDescricao] = useState('');

  const token = localStorage.getItem('token');

   if(token === null)
     history.push('/');

  function handleLogout(id){
      localStorage.clear();
      history.push('/');
    }

    async  function hendleAddConsultoria(e){
        e.preventDefault();

        const data = {
            departamento,
            setor,
            razaoSocial,
            nomeFantasia,
            cnpj,
            dtContratacao,
            periodoContratacao,
            ativo,
            dtInicio,
            dtTermino,
            norma,
            descricao
        };

        try{
            await api.post('https://wu63epzr79.execute-api.us-east-1.amazonaws.com//ConsultoriaAssessoria//api//Consultorias//', data, {
                headers:{
                   Authorization:  'bearer ' + token
                }
            })
            history.push('/consultorias');
        }catch(err){
            alert('Erro ao cadastrar consultoria, tente novamente.')
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
            <h1>Nova Consultoria</h1> 
            <form className="form" onSubmit = {hendleAddConsultoria}>
            <div className = "inputFloat">   
                <InputFloat clasName = "inputFloat"
                color = "#581919"
                activeColor = "#581919"                
                value={departamento}
                onChange={e=>setDepartamento(e.target.value)}
                placeholder="Departamento"/>    
                </div>       
                <div className = "inputFloat">           
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={setor}
                onChange={e=>setSetor(e.target.value)}
                placeholder="Setor"/>
                </div>  
                <div className = "inputFloat">    
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={razaoSocial}
                onChange={e=>setRazaoSocial(e.target.value)}
                placeholder="Razão Social"/>
                </div>    
                <div className = "inputFloat">  
                 <InputFloat 
                color = "#581919"
                activeColor = "#581919"                 
                value={nomeFantasia}
                onChange={e=>setNomeFantasia(e.target.value)}
                placeholder="Nome Fantasia"/>
                </div>     
                <div className = "inputFloat">                    
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={cnpj}
                onChange={e=>setCnpj(e.target.value)}
                placeholder="CNPJ"/> 
                </div>   
                <div className = "inputFloat">                                  
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"
                value={dtContratacao}
                onChange={e=>setDtContratacao(e.target.value)}
                placeholder="Data de Contratação"/>
                </div>                    
                <div className = "inputFloat">                             
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"
                value={periodoContratacao}
                onChange={e=>setPeriodoContratacao(e.target.value)}
                placeholder="Período de Contratação"/> 
                </div>                  
                <div className = "inputFloat">                
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={ativo}
                onChange={e=>setAtivo(e.target.value)}
                placeholder="Consultoria Ativa"/>    
                </div>          
                <div className = "inputFloat">    
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={dtInicio}
                onChange={e=>setDtInicio(e.target.value)}
                placeholder="Data de Início"/>      
                </div>      
                <div className = "inputFloat">   
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={dtTermino}
                onChange={e=>setDtTermino(e.target.value)}
                placeholder="Data de Término"/> 
                </div>          
                <div className = "inputFloat">    
                <InputFloat 
                color = "#581919"
                activeColor = "#581919"                
                value={norma}
                onChange={e=>setNorma(e.target.value)}
                placeholder="Norma"/>    
                </div>
                <div className = "inputFloat">           
               <InputFloat 
                color = "#581919"
                activeColor = "#581919"               
                value={descricao}
                onChange={e=>setDescricao(e.target.value)}
                placeholder="Descrição"/>      
                </div>                         

                <button className="button" type="submit">Incluir</button>
        </form>           
             
            <Link className="back-link" to= "/consultorias">
                 <FiArrowLeft size={16} />
                 Voltar para consultorias
            </Link>
            <Link className="back-link" to= "/profile">
                 <FiArrowLeft size={16} />
                 Voltar para home
            </Link>
            </div>
      );
}

export default ConsultoriaAdd;