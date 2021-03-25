import React, {useState} from 'react';
import {useHistory} from 'react-router-dom';
import qs from 'qs';

import api from '../../services/api';

import './styles.css'

import logoImg from '../../assets/logo.jpeg'

function Logon() {

    const [usuario, setUsuario] = useState('');
    const [senha, setSenha] = useState('');
    const history = useHistory();

    async function handleLogin(e){
        e.preventDefault();

        try{
            
            let data = qs.stringify({
                'username': usuario,
                'password': senha,
                'grant_type': 'password' 
               });

            let config = {
                method: 'post',
                url: 'https://wu63epzr79.execute-api.us-east-1.amazonaws.com//token',
                headers: { 
                  'Content-Type': 'application/x-www-form-urlencoded'
                },
                data : data
              };

            const response = await api(config);

            localStorage.setItem('token', response.data.access_token)
            localStorage.setItem('userName', response.data.Username);
            localStorage.setItem('userRole', response.data['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']);
            
            history.push('/profile');
        }
        catch(err){
            alert('Usuário não encontrado ou senha incorreta!');
        }
    }

    return (
    <div className="logon-container">
        <section className="form">
             <img className="logo" src = {logoImg} alt = "S.I.G.O." />
             <form onSubmit={handleLogin}>
                 <h1>Faça seu login</h1>

                 <input placeholder = "Usuário" 
                    value = {usuario}
                    onChange={e=>setUsuario(e.target.value)}
                 />

                <input placeholder = "Senha" 
                    value = {senha}
                    type = 'password'
                    onChange={e=>setSenha(e.target.value)}
                 />

                 <button className = "button" type="submit">Entrar</button>
             </form>
        </section>
    </div>
        );
    }

export default Logon;