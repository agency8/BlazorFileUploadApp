using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BlazorFileUpload.Client.Services.FilesManager
{
    public class FilesManager :IFilesManager
    {
        HttpClient _http;
        public FilesManager(HttpClient http)
        {
            _http = http;
        } //FilesManager


        public async Task<bool> UploadFileChunk(FileChunkDto fileChunkDto)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/Files/UploadFileChunk", fileChunkDto);
                result.EnsureSuccessStatusCode();
                string responseBody = await result.Content.ReadAsStringAsync();
                return Convert.ToBoolean(responseBody);
            }
            catch (Exception ex)
            {
                return false;
            }
        } //UploadFileChunk


        public async Task<List<string>> GetFileNames()
        {
            try
            {
                var response = await _http.GetAsync("api/Files/GetFiles");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(responseBody);
            }
            catch (Exception ex)
            {
                return null;
            }
        } //GetFileNames


    }
}
