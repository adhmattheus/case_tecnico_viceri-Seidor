import { useEffect, useState } from "react";
import { Button } from "@radix-ui/themes";
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import NovoHeroi from "./pages/NewHeroi";

interface Heroi {
  id: number;
  nome?: string;
  nomeHeroi?: string;
  dataNascimento?: Date | null;
  altura?: number | null;
  peso?: number | null;
  heroisSuperPoderes?: [] | null;
}

export function App() {
  const [dados, setDados] = useState<Heroi[] | null>(null);
  const [status, setStatus] = useState('carregando');
  const [idBusca, setIdBusca] = useState<number | string>('');
  const navigate = useNavigate();

  const handleNovoHeroiClick = () => {
    // Navegar para a tela de newHeroi
    navigate('/newHeroi');
  };

  useEffect(() => {
    const fetchData = async () => {
      try {
        setStatus('carregando...');
        const apiUrl = 'https://localhost:7222/Herois';
        const response = await axios.get<Heroi[]>(apiUrl);

        setDados(response.data);
        setStatus('concluído');
      } catch (error) {
        setStatus('erro');
        console.error('Erro na requisição:', error);
      }
    };

    fetchData();
  }, [setDados,]);

  const handleBuscarPorId = async () => {
    try {
      setStatus('carregando');

      if (idBusca) {
        const apiUrl = `https://localhost:7222/Herois/${idBusca}`;
        const response = await axios.get<{ heroi?: Heroi; errorMessage?: string }>(apiUrl);
        const { heroi, errorMessage } = response.data;

        if (errorMessage) {
          console.error('Erro na requisição:', errorMessage);
          setStatus('erro');
        } else {
          setDados(heroi ? [heroi] : []);
          setStatus('concluído');
        }
      } else {
        const apiUrl = 'https://localhost:7222/Herois';
        const response = await axios.get<Heroi[]>(apiUrl);

        setDados(response.data);
        setStatus('concluído');
      }
    } catch (error) {
      setStatus('erro');
      console.error('Erro na requisição:', error);
    }
  };

  const handleExcluir = async (id: number) => {
    try {
      setStatus('carregando');
      const confirmarExclusao = window.confirm('Deseja realmente excluir o herói?');

      if (confirmarExclusao) {
        const apiUrl = `https://localhost:7222/Herois/${id}`;
        await axios.delete(apiUrl);
        // Após a exclusão, recarrega os dados
      }
    } catch (error) {
      setStatus('erro');
      console.error('Erro na requisição:', error);
    }
  };



  if (status === 'carregando') {
    return <p>Carregando...</p>;
  }

  if (status === 'erro') {
    return <p>Ocorreu um erro durante a requisição.</p>;
  }


  return (
    <div className="flex flex-col items-center">
      <h2 className="text-xl pb-4">Dados da API</h2>


      <div className="flex justify-between">
        <div className="col-span-8">

          <input
            type="text"
            className="px-4 py-2 border rounded-md"
            placeholder="insira um id para uma ação"
            value={idBusca}
            onChange={(e) => setIdBusca(e.target.value)}
          />
        </div>
        <div className="w-80 flex justify-around">
          <Button onClick={handleBuscarPorId} className="bg-purple-300 p-2 rounded-md hover:bg-purple-400">
            buscar
          </Button>
          <Button onClick={() => handleExcluir(idBusca as number)} className="bg-purple-300 p-2 rounded-md hover:bg-purple-400 ">
            excluir
          </Button>
          <Button className="bg-purple-300 p-2 rounded-md hover:bg-purple-400 ">
            editar
          </Button>
          <Button onClick={handleNovoHeroiClick} className=" p-2 rounded-md bg-purple-300 hover:bg-purple-400 ">
            novo herói
          </Button>
        </div>
      </div>
      <div className="flex flex-wrap">
        {dados && dados.map((heroi) => (

          <div key={heroi.id} className=" rounded-md bg-zinc-50 border border-purple-300 hover:bg-purple-100 m-2 p-2 w-80 h-60">
            <h3><b>Id:</b> {heroi.id}</h3>
            <h3><b>Nome:</b> {heroi.nome}</h3>
            <h3><b>Nome do Herói: </b> {heroi.nomeHeroi}</h3>
            <h3><b>Nascimento:</b> {heroi.dataNascimento ? new Date(heroi.dataNascimento).toLocaleDateString() : 'Não disponível'}</h3>
            <h3><b>Altura:</b> {`${heroi.altura}m`}</h3>
            <h3><b>Peso:</b> {`${heroi.peso}kg`}</h3>
            <h3><b>Superpoderes:</b> {heroi.heroisSuperPoderes?.join(', ')}</h3>
          </div>
        ))}
      </div>
    </div>
  );
}