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

        public async Task CreateOwner(OwnerClass pOwner)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api20180629104437.azurewebsites.net/api/");

            string newOwnerJSON = JsonConvert.SerializeObject(pOwner, Formatting.None);

            var content = new StringContent(newOwnerJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("Owners", content);

        }

        public async Task<int> GetOwnerID()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api20180629104437.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("OwnerViews");

            var content = await response.Content.ReadAsStringAsync();

            List<OwnerClass> ownerID = JsonConvert.DeserializeObject<List<OwnerClass>>(content);

            return ownerID.Max(o => o.OwnerID) + 1;
        }

        public async Task DeleteOwner(OwnerClass pOwnerToDelete)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api20180629104437.azurewebsites.net/api/");

            string ownersToDeleteJSON = JsonConvert.SerializeObject(pOwnerToDelete, Formatting.None);

            var content = new StringContent(ownersToDeleteJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.DeleteAsync("Owners/" + pOwnerToDelete.OwnerID);

        }


        public async Task UpdateOwner(OwnerClass pOwnerToUpdate)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api20180629104437.azurewebsites.net/api/");

            string ownerToUpdateJSON = JsonConvert.SerializeObject(pOwnerToUpdate, Formatting.None);

            var content = new StringContent(ownerToUpdateJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("Owners/" + pOwnerToUpdate.OwnerID, content);

        }

    }
}
