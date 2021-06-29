using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //obrigatorio
using System.Net.Http; //obrigatorio
using System.Net.Http.Headers; //obrigatorio


namespace ClienteServicosWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("teste");
            Console.ReadLine();
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            var formato = new MediaTypeWithQualityHeaderValue("application/json");
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44344/");
                client.DefaultRequestHeaders.Accept.Clear(); //limpa todos padrões que tiverem setados por default
                client.DefaultRequestHeaders.Accept.Add(formato); //seta informa indica que o novo formato é esse no caso json
                var resposta = await client.GetAsync("api/Produto"); //await força esperar porque é assincrono
                string conteudo = await resposta.Content.ReadAsAsync<string>(); //se retorna string então aqui passa string, se retorna array de produto então passa array de produto depende do que a controller retorra tem que por igual aqui
                Console.WriteLine(conteudo);
            }
            Console.ReadLine();
        }


    }
}
