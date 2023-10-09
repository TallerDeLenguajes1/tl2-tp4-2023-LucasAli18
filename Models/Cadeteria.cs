using Cadetes;
using Pedidos;
using Clientes;
using AccesoDatos;
using System.Text;
namespace Cadeterias
{
public class Cadeteria
{
    private string? nombre;
    private string? telefono;
    private List<Cadete>? listadoCadetes;
    private List<Pedido>? listadoPedidos;
    public string? Nombre { get => nombre; set => nombre = value; }
    private static Cadeteria? instance; //evita que cualquier clase diferente a Singleton cree un objeto de tipo Singleton 

    public static Cadeteria GetInstance()
    {
        if(instance == null)
        {
            LecturaArchivos Archivo = new ArchivosCsv();
            instance = new Cadeteria();
            instance = Archivo.ArchivoCadeteria("Cadeteria.csv");
            instance!.CargarCadetes(Archivo.ArchivoCadete("Cadetes.csv")!);
        }
        return instance;
    }
    public List<Cadete> CargarCadetes(List<Cadete> listadoCadetesDatos)
    {
            this.listadoCadetes = listadoCadetesDatos;
            return listadoCadetesDatos;
    }
    public Cadeteria(string nombre, string telefono)
    {
        this.nombre=nombre;
        this.telefono=telefono;
        this.listadoCadetes=new List<Cadete>();
        this.listadoPedidos=new List<Pedido>();
    }
    public Cadeteria()
    {
        listadoCadetes = new List<Cadete>();
        listadoPedidos = new List<Pedido>();
    }
    public void AsignarPedido(int idPedido, int idCadete)
    {
        if (this.listadoPedidos!.FirstOrDefault(p=>p.ObtenerID()==idPedido)!=null)
        {
            Pedido Encontrado = new Pedido();
            Encontrado = this.listadoPedidos!.FirstOrDefault(p=>p.ObtenerID()==idPedido)!;
            if (this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!=null)
            {
                Encontrado.CadeteCargo1=this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!.Nombre;
                Encontrado = cambiarEstado(Encontrado,1);
                this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!.CantEnvios++;
            }else
            {
                Console.WriteLine("No se encontro el cadete seleccionado");
            }
        }else{
            Console.WriteLine("No se encontro el pedido");
        }
    }
    public Pedido CambiarCadetePedido(int idpedido, string nombreCadete)
    {
        (this.listadoPedidos!.FirstOrDefault(p=>p.ObtenerID()==idpedido)!).CadeteCargo1=this.listadoCadetes!.FirstOrDefault(c=>c.Nombre==nombreCadete)!.Nombre;
        return this.listadoPedidos!.FirstOrDefault(p=>p.ObtenerID()==idpedido)!;
    }
    public Pedido DarDeAlta(int numeroPedido)
    {
        string? nom, dir, referencia, observacion;
        int tel;
        Console.WriteLine("Introducir el nombre del cliente");
        nom = Console.ReadLine()!;
        Console.WriteLine("Introducir la direccion del cliente");
        dir = Console.ReadLine()!;
        Console.WriteLine("Introducir el nombre del cliente");
        int.TryParse(Console.ReadLine(),out tel);
        Console.WriteLine("Introducir una referencia de la direccion");
        referencia = Console.ReadLine()!;
        Console.WriteLine();
        Console.WriteLine("Observacion sobre el pedido");
        observacion = Console.ReadLine()!;
        Cliente nuevoCliente = new Cliente(nom,dir,tel,referencia);
        Pedido nuevoPedido = new Pedido(numeroPedido,observacion,nuevoCliente);
        this.listadoPedidos!.Add(nuevoPedido);
        return nuevoPedido;
    }
    public Pedido cambiarEstado(Pedido pedido, int num)
    {
        if (num == 3)
        {
            pedido.Estado1=EstadoPedidos.rechazado;
        }else if (num == 2)
        {
            pedido.Estado1=EstadoPedidos.pendiente;
        }else
        {
            pedido.Estado1=EstadoPedidos.aceptado;
        }
        return pedido;
    }
    public List<Cadete> EliminarCadete(Cadete cadete)
    {
        this.listadoCadetes!.Remove(cadete);
        return this.listadoCadetes!;
    }
    public List<Cadete> ObtenerCadetes()
    {
        return listadoCadetes!;
    }
      public List<Pedido> GetPedidos()
        {
            return listadoPedidos!;
        }
    public int JornalACobrar(int idCadete)
    {
        Cadete Encontrado = new Cadete();
        if (this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!=null)
            {
                Encontrado=this.listadoCadetes!.FirstOrDefault(c=>c.ObtenerID()==idCadete)!;
                return Encontrado.CantEnvios*500;
            }else
            {
                return 0;
            }
    }

}
}
