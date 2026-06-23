using System.IO;
using TagMP3;

class Program
{
    static void Main()
    {
        Console.Write("ingrese la ruta del archivo MP3: ");
        string nombreDelArchivo = Console.ReadLine();
        Console.WriteLine();
        if (File.Exists(nombreDelArchivo))
        {
            FileStream miArchivo = new FileStream(nombreDelArchivo, FileMode.Open);
            miArchivo.Seek(-128, SeekOrigin.End);
            byte[] buffer = new byte[128];
            int bytesLeidos = miArchivo.Read(buffer, 0, 128);
            Id3v1Tag tagInfo = new Id3v1Tag();
            Encoding codificacion = Encoding.GetEncoding("latin1");
            tagInfo.Header = codificacion.GetString(buffer, 0, 3).Trim();
            if (tagInfo.Header == "TAG")
            {
                tagInfo.Titulo = codificacion.GetString(buffer, 3, 30).Trim();
                tagInfo.Artista = codificacion.GetString(buffer, 33, 30).Trim();
                tagInfo.Album = codificacion.GetString(buffer, 63, 30).Trim();
                tagInfo.Anio = codificacion.GetString(buffer, 93, 4).Trim();
                tagInfo.Comentario = codificacion.GetString(buffer, 97, 30).Trim();
                tagInfo.Genero = buffer[127];
                tagInfo.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("el archivo no contiene un tag valido");
            }
            miArchivo.Close();
        }
        else
        {
            Console.WriteLine("error. El archivo no existe");
        }
        Console.WriteLine("\nPresione enter para salir...");
        Console.ReadLine();
    }
}
