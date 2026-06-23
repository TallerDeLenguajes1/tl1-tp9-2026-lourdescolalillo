
namespace TagMP3;

public class Id3v1Tag
{
    private string header;
    private string titulo;
    private string artista;
    private string album;
    private string anio;
    private string comentario;
    private byte genero;

    public string Header
    {
        get => header;
        set => header = value;
    }

    public string Titulo
    {
        get => titulo;
        set => titulo = value;
    }
    public string Artista
    {
        get => artista;
        set => artista = value;
    }
    public string Album
    {
        get => album;
        set => album = value;
    }
    public string Anio
    {
        get => anio;
        set => anio = value;
    }
    public string Comentario
    {
        get => comentario;
        set => comentario = value;
    }
    public byte Genero
    {
        get => genero;
        set => genero = value;
    }
    public void MostrarInformacion()
    {
        Console.WriteLine($"===INFORMACION DE LA CANCION===");
        Console.WriteLine($"TITULO: {Titulo}");
        Console.WriteLine($"ARTISTA: {Artista}");
        Console.WriteLine($"ALBUM: {Album}");
        Console.WriteLine($"ANIO: {Anio}");
        Console.WriteLine();
    }
}



