using Newtonsoft.Json;
using PersonInterestClient.Models;
using System.Text;

namespace PersonInterestClient.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("My API Client");
        }

        //Hämta alla Persons
        public async Task<List<Person>> GetPersonsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("persons");
                if (response.IsSuccessStatusCode)
                {
                    var myJsonResult = await response.Content.ReadAsStringAsync();
                    var persons = JsonConvert.DeserializeObject<List<Person>>(myJsonResult);
                    return persons;
                }
                else
                {
                    return new List<Person>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Skapa ny person
        public async Task AddPersonAsync(Person person)
        {
            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("persons", data);
            response.EnsureSuccessStatusCode();
        }
        //Uppdatera en befintlig person
        public async Task UpdatePersonAsync(int id, Person person)
        {
            var json = JsonConvert.SerializeObject(person);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"persons/{id}", data);
            response.EnsureSuccessStatusCode();
        }
        //Skapa ny Person och intresse
        public async Task<bool> AddPersonWithInterestAsync(PersonWithInterestModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("person/interest", data);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Hämta alla Persons med intressen och länkar
        public async Task<List<AllPersonInfo>> GetAllPersonInfosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("allpersoninfo");
                if (response.IsSuccessStatusCode)
                {
                    var myJsonResult = await response.Content.ReadAsStringAsync();
                    var personInfos = JsonConvert.DeserializeObject<List<AllPersonInfo>>(myJsonResult);
                    return personInfos;
                }
                else
                {
                    return new List<AllPersonInfo>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
