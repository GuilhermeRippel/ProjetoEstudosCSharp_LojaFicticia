using ProjetoLojaEstudos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLojaEstudos.Services
{
    internal class LojaService
    {

        public List<Produto> produtos = new List<Produto>();

        public void CadastrarProduto()
        {
            Produto produto = new Produto();
            Console.WriteLine("Digite o nome do produto à ser cadastrado:");
            string nome = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Forneça um nome válido para o produto:");
                nome = Console.ReadLine()!;
            }

            Console.WriteLine("Digite a descrição do produto à ser cadastrado:");
            string descricao = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("Forneça uma descrição válida:");
                descricao = Console.ReadLine()!;
            }

            Console.WriteLine("Digite o preço do produto à ser cadastrado");
            string preco = Console.ReadLine()!;

            while(!decimal.TryParse(preco, out decimal precoProduto))
            {
                Console.WriteLine("Digite um preço válido:");
                preco = Console.ReadLine()!;
            }

            produto.Nome = nome;
            produto.Descricao = descricao;
            produto.Preco = decimal.Parse(preco);

            produtos.Add(produto);
            Console.WriteLine("Produto cadastrado com sucesso!");
        }
    
        public void ListarProdutos()
        {
            if(produtos.Count() == 0)
            {
                Console.WriteLine("Sem produtos cadastrados para listar");
            }

            foreach (var item in produtos)
            {
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Descrição: {item.Descricao}");
                Console.WriteLine($"Preço: R$ {item.Preco}");
                Console.WriteLine("-------------------------");
            }
            ;
        }

        public void ProcurarProduto(string produtoNome)
        {
            Produto? produtoEncontrado = produtos.Find(produto => produto.Nome.Contains(produtoNome, StringComparison.OrdinalIgnoreCase));
            if (produtoEncontrado == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.WriteLine($"Nome: {produtoEncontrado.Nome}");
            Console.WriteLine($"Descrição: {produtoEncontrado.Descricao}");
            Console.WriteLine($"Preço: R$ {produtoEncontrado.Preco}");
        }
        public void AlterarProduto()
        {

            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] - {produtos[i].Nome}");
            }
            Console.WriteLine("Digite o número do produto que deseja alterar:");
            string numberOption = Console.ReadLine()!;
            if (int.TryParse(numberOption, out int option))
            {
                if (option >= 1 && option <= produtos.Count)
                {
                    Console.WriteLine("Digite o novo nome do produto:");
                    string newName = Console.ReadLine()!;
                    while(string.IsNullOrWhiteSpace(newName))
                    {
                        Console.WriteLine("Digite um nome válido:");
                        newName = Console.ReadLine()!;
                    }
                    produtos[option - 1].Nome = newName;
                    
                    Console.WriteLine("Digite a nova descrição do produto:");
                    string newDescription = Console.ReadLine()!;
                    while(string.IsNullOrWhiteSpace(newDescription))
                    {
                        Console.WriteLine("Digite uma descrição válida:");
                        newDescription = Console.ReadLine()!;
                    }
                    produtos[option - 1].Descricao = newDescription;

                    decimal newPrice;
                    while (!decimal.TryParse(Console.ReadLine(), out newPrice))
                    {
                        Console.WriteLine("Digite um preço válido:");
                    }
                    produtos[option - 1].Preco = newPrice;

                    Console.WriteLine("Produto alterado com sucesso!");
                } else
                {
                    Console.WriteLine("Opção inválida. Digite um número válido.");
                }
            } else
            {
                Console.WriteLine("Opção inválida. Digite um número válido.");
            }
        }
    }

}