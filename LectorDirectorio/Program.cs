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
                FileInfo informacionDeCarpeta = new FileInfo(carpeta);
                string nombreCarpeta = informacionDeCarpeta.Name;
                Console.WriteLine($"[carpeta]{nombreCarpeta}");
            }
        }
        Console.WriteLine();
        Console.WriteLine("ARCHIVOS ENCONTRADOS");
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
                double tamanioArchivo = informacionDeArchivo.Length / 1024.0;
                Console.WriteLine($"[archivo]{informacionDeArchivo.Name} - {tamanioArchivo.ToString("0.00")} KB");
            }
        }
        Console.WriteLine();
        string rutaAlternativaCsv = $"{ruta}\\reporte_archivos.csv";
        StreamWriter escribir = new StreamWriter(rutaAlternativaCsv);
        escribir.WriteLine("Nombre del archivo;Tamaño (KB);Fecha de ultima Modificacion");
        foreach (string archivo in archivos)
        {
            FileInfo informacionDeArchivo = new FileInfo(archivo);
            double tamanioArchivo = informacionDeArchivo.Length / 1024;
            DateTime ultimaModificacion = informacionDeArchivo.LastWriteTime;
            string linea = $"{informacionDeArchivo.Name};{tamanioArchivo.ToString("0.00")};{ultimaModificacion.ToString("dd/MM/yyyy HH:mm:ss")}";
            escribir.WriteLine(linea);
        }
        escribir.Close();
        Console.WriteLine("\nEl reporte se guardo con exito");
    }
}

