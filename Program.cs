using ProjetoLojaEstudos.Services;
using System;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("=================================\r\n      SISTEMA DA RIPPEL's STORE\r\n=================================\r\n\r\n" +
    "1 - Cadastrar produto\r\n" +
    "2 - Listar produtos\r\n" +
    "3 - Buscar produto\r\n" +
    "4 - Alterar produto\r\n" +
    "5 - Remover produto\r\n" +
    "6 - Criar venda\r\n" +
    "7 - Listar vendas\r\n" +
    "8 - Ver estoque\r\n" +
    "0- Sair\r\n\r\n" +
    "Escolha uma opção:");

string userOption = Console.ReadLine()!;
bool primeiraEscolha = true;
LojaService lojaService = new LojaService();

while (!int.TryParse(userOption, out int option))
{
    Console.WriteLine("Digite o número da opção desejada");
    userOption = Console.ReadLine()!;
}

while (int.Parse(userOption) != 0) {

    if (!primeiraEscolha)
    {
        Console.WriteLine("Digite o número da opção desejada");
        userOption = Console.ReadLine()!;
    }

    switch (int.Parse(userOption))
    {
        case 1:
            lojaService.CadastrarProduto();
            break;
        case 2:
            lojaService.ListarProdutos();
            break;
        case 3:
            Console.WriteLine("Digite o nome do produto que deseja buscar:");
            string produtoBuscado = Console.ReadLine()!;
            lojaService.ProcurarProduto(produtoBuscado);
            break;
        case 4:
            lojaService.AlterarProduto();
            break;
    }
    primeiraEscolha = false;
}