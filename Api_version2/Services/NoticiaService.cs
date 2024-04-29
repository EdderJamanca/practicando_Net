
namespace Api_version2.Services;

public class NoticiaService {
    
static readonly HttpClient client = new HttpClient();

 public async Task<List> listarNoticia(string palabra)
    {
        var response = await client.GetAsync($"https://newsapi.org/v2/everything?q={palabra}&apiKey=e49db7002d114162b716e554eeeb5621");
        
        response.EnsureSuccessStatusCode(); // Lanzará una excepción si la solicitud no es exitosa

        var content = await response.Content.ReadAsStringAsync();
        
        // Deserializar el contenido JSON en una lista de objetos Noticia
        var noticias = JsonConvert.DeserializeObject<NoticiaResponse>(content)?.Articles;

        return noticias;
    }

}