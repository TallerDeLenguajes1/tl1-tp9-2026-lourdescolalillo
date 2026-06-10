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
    }
}

