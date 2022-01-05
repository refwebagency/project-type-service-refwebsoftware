using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProjectTypeService.Dtos;

namespace ProjectTypeService.SyncDataServices.Http
{
    public class HttpTemplateDataClient : ITemplateDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public HttpTemplateDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        /* Méthode pour permettre d'envoyer de manière asynchrone
           un objet ProjectType de ProjectTypeService vers TemplateService
        */
        public async Task SendProjectTypeToTemplate(ProjectTypeReadDto projectType)
        {
            // httpContent contient l'objet serializé, afin de pouvoir utiliser un protocole de transfert
            var httpContent = new StringContent(
                JsonSerializer.Serialize(projectType),
                Encoding.UTF8,
                "application/json");

                // response recupere comme valeur la requete post en async vers l'autre service
                var response = await _httpClient.PostAsync($"{_configuration["TemplateService"]}", httpContent);

                // condition par rapport au resultat du post en async
                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine(" Requete POST envoyée vers TemplateService");
                }
                else
                {
                    Console.WriteLine(" Erreur: Requete POST non envoyée");
                }
        }
    }
}