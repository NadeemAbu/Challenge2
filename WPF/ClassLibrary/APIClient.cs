using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ClassLibrary
{
    public class APIClient
    {
        public async Task<List<ProcedureClass>> GetProcedures()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api20180629104437.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("ProcedureViews");

            var content = await response.Content.ReadAsStringAsync();

            List<ProcedureClass> procedures = JsonConvert.DeserializeObject<List<ProcedureClass>>(content);

            return procedures;
        }

        public async Task<List<TreatmentClass>> GetTreatments()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api20180629104437.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("TreatmentViews");

            var content = await response.Content.ReadAsStringAsync();

            List<TreatmentClass> treatment = JsonConvert.DeserializeObject<List<TreatmentClass>>(content);

            return treatment;
        }

        public async Task<List<PetClass>> GetPets()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api20180629104437.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("PetViews");

            var content = await response.Content.ReadAsStringAsync();

            List<PetClass> pet = JsonConvert.DeserializeObject<List<PetClass>>(content);

            return pet;
        }

        public async Task<List<OwnerClass>> GetOwners()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api20180629104437.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("OwnerViews");

            var content = await response.Content.ReadAsStringAsync();

            List<OwnerClass> owner = JsonConvert.DeserializeObject<List<OwnerClass>>(content);

            return owner;
        }
    }
}
