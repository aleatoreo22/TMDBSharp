namespace TMDBSharp.Models.Response;

public class BaseList<T>
{
    public int page { get; set; }
    public List<T> results { get; set; }
    public int total_pages { get; set; }
    public int total_results { get; set; }
}