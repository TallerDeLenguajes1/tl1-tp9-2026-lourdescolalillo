using System.IO;
class Program
{
    static void Main()
    {
        string ruta = " ";
        bool rutaValida = false;
        do
        {
            Console.Write("Ingrese el path del directorio que desea analizar: ");
            ruta = Console.ReadLine();
            if (Directory.Exists(ruta))
            {
                rutaValida = true;
            }
            else
            {
                Console.WriteLine("Ingrese un path valido");
            }
        } while (!rutaValida);
        Console.WriteLine();
        Console.WriteLine("SUBCARPETAS ENCONTRADAS");
        string[] carpetas = Directory.GetDirectories(ruta);
        if (carpetas.Length == 0)
        {
            Console.WriteLine("No se encontraron sub-carpetas");
        }
        else
        {
            foreach (string carpeta in carpetas)
            {
                string nombreCarpeta = Path.GetFileName(carpeta);
                Console.WriteLine($"[carperta]{nombreCarpeta}");
            }
        }
        Console.WriteLine();
        string[] archivos = Directory.GetFiles(ruta);
        if (archivos.Length == 0)
        {
            Console.WriteLine("No se encontraron archivos");
        }
        else
        {
            foreach (string archivo in archivos)
            {
                FileInfo informacionDeArchivo = new FileInfo(archivo);
                double tamanioArchivo = informacionDeArchivo.Length / 1024;
            }
        }
        Console.WriteLine();
    }
}

