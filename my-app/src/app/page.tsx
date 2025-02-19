"use client";

import Image from "next/image";
import React from "react";
import axios from "axios";

export default function Home() {
  return (
    <main>
      
      <PessoasTabela></PessoasTabela>
    </main>
  );
}

export function Botao() {

  let [contador, setContador] = React.useState(0);

  console.log("qualquer coisa", contador);

  React.useEffect(() => {console.log("contador mudou")}, [contador]);
  React.useEffect(() => {console.log("componente criado")}, []);

  function Clicar()
  {
    setContador(contador + 1);
  }

  return (
    <button onClick={() => Clicar()}>Aperte {contador}</button>
  )
}

export function PessoasTabela()
{
  let [pessoas, setPessoas] = React.useState([]);
  React.useEffect(() => {
    
    let resultado = axios.get("http://localhost:5112/api/Pessoa/Listar");
    resultado.then((response) => setPessoas(response.data.dados));
    }, []);

  console.log(pessoas);
  if(pessoas.length == 0 )
  {
    return <div>Carregando...</div>
  }
  return <div>{pessoas.map((elemento) => <div key={elemento.id}>{elemento.nome}</div>)}</div>
}

