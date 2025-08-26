using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Funcionario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public decimal Salario { get; set; }
}

class Programa
{
    static async Task Main(string[] args)
    {
        // Use apenas a URL que o servidor está escutando.
        string apiBaseUrl = "http://localhost:5014";

        HttpClient client = new HttpClient(); // Sem o handler

        Console.WriteLine("1 - Listar funcionários");
        Console.WriteLine("2 - Cadastrar novo funcionário");
        Console.Write("Escolha uma opção: ");
        var opcao = Console.ReadLine();

        try
        {
            if (opcao == "1")
            {
                var funcionarios = await client.GetFromJsonAsync<List<Funcionario>>($"{apiBaseUrl}/api/Funcionario");
                if (funcionarios != null)
                {
                    Console.WriteLine("\n--- Lista de Funcionários ---");
                    foreach (var f in funcionarios)
                    {
                        Console.WriteLine($"ID: {f.Id} | Nome: {f.Nome} | Cargo: {f.Cargo} | Salário: R${f.Salario:N2}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum funcionário encontrado.");
                }
            }
            else if (opcao == "2")
            {
                Console.Write("Nome: ");
                var nome = Console.ReadLine();
                Console.Write("Cargo: ");
                var cargo = Console.ReadLine();
                Console.Write("Salário: ");
                if (!decimal.TryParse(Console.ReadLine(), out var salario))
                {
                    Console.WriteLine("Entrada inválida para o salário. Operação cancelada.");
                    return;
                }

                var novoFuncionario = new Funcionario
                {
                    Nome = nome ?? "Nome não informado",
                    Cargo = cargo ?? "Cargo não informado",
                    Salario = salario
                };

                var resposta = await client.PostAsJsonAsync($"{apiBaseUrl}/api/Funcionario", novoFuncionario);
                resposta.EnsureSuccessStatusCode();
                Console.WriteLine("Funcionário cadastrado com sucesso!");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"\nErro ao conectar à API: {e.Message}");
            Console.WriteLine("Verifique se o servidor está em execução na URL correta.");
        }
    }
}