using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal
{
    internal class Program
    {
        class Carro
        {
            // Criando o objeto do carro
            public string marca { get; protected set; }
            public string modelo { get; protected set; }
            public string cor { get; protected set; }
            public int ano { get; protected set; }

            // criando os metodos dos valores do carro
            public Carro(string marca, string modelo, string cor, int ano)
            {
                this.marca = marca;
                this.modelo = modelo;
                this.cor = cor;
                this.ano = ano;
            }
            // Criando o objeto e os atributos do mesmo 
            public string MostraObjeto()
            {
                return " - Marca: " + marca + ", Modelo: " + modelo + ", Cor: " + cor + ", Ano: " + ano;
            }
            public void DefinirMarcar(string marca){
                this.marca = marca;
            }public void DefinirModelo(string modelo){
                this.modelo = modelo;
            }public void DefinirCor(string cor){
                this.cor = cor;
            }public void DefinirAno(int ano){
                this.ano = ano;
            }
        }
        class iniciando{ // iniciando a lista já com dois modelos 
            public List<Carro> carros;

            public iniciando(){
                carros = new List<Carro>(){
                    new Carro("Bmw", "m5", "Preto", 2021),
                    new Carro("Fiat", "uno", "branco",2016)

                };
                EscrevendoMenu();
            }
            public void EscrevendoMenu(){ // menu 

                Console.WriteLine("Bem Vindo ao Sistema De Cadastro De Veiculos" + Environment.NewLine);
                Console.WriteLine("1. Ver Veiculos Já Cadastrados");
                Console.WriteLine("2. Adicionar veiculo no sistema");
                Console.WriteLine("3. Remover cadastro");
                Console.WriteLine("4. Sair" + Environment.NewLine);

                Console.WriteLine("Qual Será Sua Opção?");

                bool converter = int.TryParse(Console.ReadLine(), out int resposta); // Convertendo a resposta do usuario 

                if (converter){
                    Console.WriteLine(resposta);

                    if(resposta == 1){
                        EscrvendoTudo();
                    }else if(resposta == 2){
                        AdicionadoCarros();
                    }else if(resposta == 3){
                        RemovendoCarro();
                    }if(resposta >= 1 && resposta <= 3){
                        EscrevendoMenu();
                    }

                   // fazendo a validação e mostrando as opçoes a cada escolha

                }else{

                    MensagemDeSaida("não tem essa opção");
                    EscrevendoMenu();
                }
            }
                // essa função preincipal 
            public void EscrvendoTudo() {

                OpcaoDaFuncao("AVeiculos Cadastrado");
                // imprimindo na tela

                for (int i = 0; i < carros.Count; i++){
                    Console.WriteLine(i + 1 + carros[i].MostraObjeto());
                }

                Console.WriteLine("Ok Finalizou Aperte Enter Para Finalizar");
                Console.ReadLine ();
                Console.Clear ();

            }
            public void AdicionadoCarros(){

                OpcaoDaFuncao("Adicionar Veiculos");
                        // aqui está fazendo uma validação 
                try
                {

                    Console.WriteLine("Didite a marca do veiculo");
                    string marca = Console.ReadLine();

                    Console.WriteLine("Digite o modelo do veiculo");
                    string modelo = Console.ReadLine();

                    Console.WriteLine("Digite a cor do veiculo");
                    string cor = Console.ReadLine();

                    Console.WriteLine("Digite o ano do veiculo");
                    int ano = Convert.ToInt32(Console.ReadLine());  // No Bloco try faz a verificação primeiro 

                    if(!string.IsNullOrEmpty(marca)){
                        if (!string.IsNullOrEmpty(modelo)){   // essa verificação não deixa salvar o cadastro sem ter preenchido o campo 
                            if(!string.IsNullOrEmpty(cor)){
                                if(ano >= 0 && ano <= 2024){

                                    Carro carro = new Carro(marca, modelo, cor, ano);  // se sim salva se não da erro e terá que refazer 

                                    carros.Add(carro);
                                }
                            }else{Console.WriteLine("Você não digidou a cor"); 
                            }
                        }else{Console.WriteLine("Você não digitou o modelo"); 
                        }
                    }else{Console.WriteLine("Você não digitou a marca");
                        Console.ReadLine();
                        Console.Clear();
                        AdicionadoCarros();
                    }                  

                }catch (Exception){
                    MensagemDeSaida("Aperte o enter para tentar novamente");
                    AdicionadoCarros();
                }

                Finalizando();
            }
   
           // essa função compara i indice da lista e compara e faz a exclusão 
            public void RemovendoCarro(){
                OpcaoDaFuncao("Remover Veiculos");

                if(carros.Count == 0){
                    Console.WriteLine("Esse Veiculo Não Está No Sstema");

                }else{
                    EscrvendoTudo();

                    Console.Write("Digite um Veiculo");
                    int veiculo = Convert.ToInt32(Console.ReadLine());
                    veiculo--;

                    if (veiculo >= 0 && veiculo <= carros.Count - 1){
                        carros.RemoveAt(veiculo);
                        Console.WriteLine("Veicilo Fo Removido com Sucesso");

                        Finalizando();

                    }else{
                        OpcaoDaFuncao("Digite um Viculo Válido");
                        RemovendoCarro();
                    }
                }              
            }       // essas funções são atalho enves criar tres tres linhas eu só chamo onde eu quero 

            public void Finalizando(){

                Console.WriteLine("Voce terminou aplicação aprete enter para voltar ao menu");
                Console.ReadLine();
                Console.Clear();
            }

            public void OpcaoDaFuncao(string mensagem){
                Console.Clear();
                Console.WriteLine(mensagem + Environment.NewLine);
            }

            public void MensagemDeSaida(string mensagem){
                Console.WriteLine(mensagem + "Aperte o enter para tentar novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        // atribuindo valor ao carro
        static void Main(string[] args){
        
            iniciando iniciando = new iniciando();

            Console.ReadLine();
        }
    }
}
