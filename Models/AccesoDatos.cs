using Cadeterias;
using Cadetes;
using System.Text.Json;

namespace AccesoDatos;

public abstract class LecturaArchivos
{
    public virtual List<Cadete>? ArchivoCadete(string nombreArchivo){
        return null;
    }
    public virtual Cadeteria? ArchivoCadeteria(string nombreArchivo)
    {
        return null;
    }
}

public class ArchivosCsv : LecturaArchivos
{
    public override List<Cadete>? ArchivoCadete(string nombreArchivo)
    {
        List<Cadete> ListaCadete = new List<Cadete>();
        StreamReader cadete = new StreamReader(nombreArchivo);
        string? linea;
        int a;
        while((linea = cadete.ReadLine()) != null)
        {
            string[] aux = linea.Split(",").ToArray();
            int.TryParse(aux[0], out a);
            Cadete nuevoCadete = new Cadete(a, aux[1], aux[2], aux[3]);
            ListaCadete.Add(nuevoCadete);
        }
        return ListaCadete;
    }

    public override Cadeteria? ArchivoCadeteria(string nombreArchivo)
    {
        Cadeteria nuevaCadeteria; 
        Cadeteria listaCadeteria = new Cadeteria();
        StreamReader Cadeteria = new StreamReader(nombreArchivo);
        string? linea;
        string[]? aux = null;
        while((linea = Cadeteria.ReadLine()) != null)
        {
            aux = linea.Split(",").ToArray();
        }
        if(aux != null)
        {
            nuevaCadeteria = new Cadeteria(aux[0], aux[1]);
            return listaCadeteria;
        }
        else 
        {
            return null;
        }
    }
}

public class ArchivosJson : LecturaArchivos
{
    public override List<Cadete>? ArchivoCadete(string nombreArchivo)
    {
        if(File.Exists(nombreArchivo))
        {
            string? aux = File.ReadAllText(nombreArchivo);
            List<Cadete>? listaCadete = JsonSerializer.Deserialize<List<Cadete>>(aux);
            return listaCadete;
        }
        else
        {
            return null;
        }
    }

    public override Cadeteria? ArchivoCadeteria(string nombreArchivo)
    {
        if(File.Exists(nombreArchivo))
        {
            string? aux = File.ReadAllText(nombreArchivo);
            Cadeteria? ListaCadeteria = JsonSerializer.Deserialize<Cadeteria>(aux);
            return ListaCadeteria;
        }
        else
        {
            return null;
        }
    }
}
        /* public override List<Cadete>? LeerArchivo(string rutaDeArchivo)
        {
            List<Cadete>? listaProductos;
            string documento;
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaProductos = JsonSerializer.Deserialize<List<Cadete>>(documento);
            }
            return listaProductos;
        } 
         public override void GuardarArchivo(List<Cadete> listaCadetes)
        {

            string json = JsonSerializer.Serialize(listaCadetes, new JsonSerializerOptions
            {
                WriteIndented = true // Indentar el JSON para mayor legibilidad
            });

            // Especificar la ruta del archivo donde deseas guardar el JSON
            string rutaArchivo = "personas.json";

            // Guardar el JSON en un archivo
            File.WriteAllText(rutaArchivo, json);

            Console.WriteLine("Datos guardados en el archivo JSON.");
        } */
