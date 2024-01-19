import { Button } from '@radix-ui/themes';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { useState, useEffect } from 'react';

interface SuperPoder {
  id: number;
  superPoder: string;
  descricao?: string;
}

interface NovoHeroi {
  nome: string;
  nomeHeroi: string;
  dataNascimento?: string;
  altura?: number | null;
  peso?: number | null;
  superpoderId: number | null;
}

export default function NovoHeroi() {
  const [superpoderes, setSuperpoderes] = useState<SuperPoder[]>([]);
  const [novoHeroi, setNovoHeroi] = useState<NovoHeroi>({
    nome: '',
    nomeHeroi: '',
    dataNascimento: new Date().toISOString().split('T')[0], // Formato de data esperado
    altura: null,
    peso: null,
    superpoderId: null,
  });

  const navigate = useNavigate();

  const handleBack = () => {
    // Navegar para a tela de newHeroi
    navigate('/');
  };
  
  useEffect(() => {
    const obterSuperpoderes = async () => {
      try {
        const apiUrl = 'https://localhost:7222/Superpoderes';
        const response = await axios.get<SuperPoder[]>(apiUrl);
        setSuperpoderes(response.data);
      } catch (error) {
        console.error('Erro ao obter superpoderes:', error);
      }
    };

    obterSuperpoderes();
  }, [setSuperpoderes]);

  const handleChange = (event: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const { name, value } = event.target;
    setNovoHeroi((prevHeroi) => ({
      ...prevHeroi,
      [name]: value,
    }));
  };

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    try {
      // Formatação para o padrão esperado pela API
      const novoHeroiFormatado = {
        id: 0,
        nome: novoHeroi.nome,
        nomeHeroi: novoHeroi.nomeHeroi,
        dataNascimento: novoHeroi.dataNascimento,
        altura: novoHeroi.altura || 0,
        peso: novoHeroi.peso || 0,
        heroisSuperPoderes: [
          {
            heroiId: 0,
            heroi: novoHeroi.nomeHeroi,
            superPoderesId: novoHeroi.superpoderId || 0,
            superPoder: {
              id: 0,
              superPoder: superpoderes.find((sp) => sp.id === novoHeroi.superpoderId)?.superPoder || '',
              descricao: '', // Pode ser ajustado conforme necessário
            },
          },
        ],
      };

      // Simula o envio do formulário. Substitua pelo seu código de envio real.
      console.log('Dados do novo herói:', novoHeroiFormatado);
    } catch (error) {
      console.error('Erro ao cadastrar herói:', error);
    }
  };

  return (
    <div>
      <Button onClick={handleBack} className=" m-2 p-2 rounded-md bg-purple-300 hover:bg-purple-400 ">
        voltar
      </Button>

      <div className="max-w-2xl mx-auto mt-8 p-4 bg-gray-200 rounded">
        <form onSubmit={handleSubmit} className="space-y-4">
          <div>
            <label className="block text-gray-600">Nome:</label>
            <input
              type="text"
              name="nome"
              value={novoHeroi.nome}
              onChange={handleChange}
              className="w-full px-4 py-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
            />
          </div>

          <div>
            <label className="block text-gray-600">Nome do Herói:</label>
            <input
              type="text"
              name="nomeHeroi"
              value={novoHeroi.nomeHeroi}
              onChange={handleChange}
              className="w-full px-4 py-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
            />
          </div>

          <div>
            <label className="block text-gray-600">Data de Nascimento:</label>
            <input
              type="date"
              name="dataNascimento"
              value={novoHeroi.dataNascimento}
              onChange={handleChange}
              className="w-full px-4 py-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
            />
          </div>

          <div>
            <label className="block text-gray-600">Altura:</label>
            <input
              type="number"
              name="altura"
              value={novoHeroi.altura || ''}
              onChange={handleChange}
              className="w-full px-4 py-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
            />
          </div>

          <div>
            <label className="block text-gray-600">Peso:</label>
            <input
              type="number"
              name="peso"
              value={novoHeroi.peso || ''}
              onChange={handleChange}
              className="w-full px-4 py-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
            />
          </div>

          <div>
            <label className="block text-gray-600">Superpoder:</label>
            <select
              name="superpoderId"
              value={novoHeroi.superpoderId || ''}
              onChange={handleChange}
              className="w-full px-4 py-2 border border-gray-300 rounded focus:outline-none focus:border-blue-500"
            >
              <option value="" disabled>
                Selecione um superpoder
              </option>
              {superpoderes.map((superpoder) => (
                <option key={superpoder.id} value={superpoder.id}>
                  {superpoder.superPoder}
                </option>

              ))}
            </select>
          </div>

          <button
            type="submit"
            className="w-full bg-purple-500 hover:bg-purple-700 text-white p-3 rounded focus:outline-none"
          >
            Cadastrar Herói
          </button>
        </form>
      </div>
    </div>
  );
}