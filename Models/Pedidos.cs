using Cadetes;
using Clientes;

namespace Pedidos
{
     public enum EstadoPedidos{
        aceptado,
        pendiente,
        rechazado
    }
    public class Pedido
    {
        private int Numero;
        private string? Obs;
        private string? CadeteCargo;
        private Cliente? Cliente;
        private EstadoPedidos Estado;

        public string? CadeteCargo1 { get => CadeteCargo; set => CadeteCargo = value; }
        public EstadoPedidos Estado1 { get => Estado; set => Estado = value; }

        //Constructor PEDIDO

        public Pedido(int nro, string obs, Cliente cliente)
        {
            Numero = nro;
            Obs=obs;
            Cliente =cliente;
            Estado1 = EstadoPedidos.pendiente;
            CadeteCargo = null;
        }
        public Pedido()
        {
            Numero=0;
            Obs="";
            Cliente =new Cliente();
            Estado1=EstadoPedidos.pendiente;
            CadeteCargo = null;
        }
        public string MostrarPedido()
        {
            string pedidoInfo = "--------------------------------\n";
            pedidoInfo += "---------Pedido nro: " + this.Numero + "\n";
            pedidoInfo += "---------Observacion: " + this.Obs + "\n";
            pedidoInfo += "---------Estado: " + this.Estado1 + "\n";
            if (CadeteCargo == null)
            {
                CadeteCargo = "Sin cadete";
            }
            pedidoInfo += "---------Cadete a cargo: " + this.CadeteCargo + "\n";
            pedidoInfo += "---------Cliente: \n";
            pedidoInfo += this.Cliente!.MostrarCliente();
            pedidoInfo += "--------------------------------";
            return pedidoInfo;
        }
        public string VerDireccionCliente(Cliente cliente)
        {
            return "Direccion del cliente: " + cliente.Direccion + "\n" + "Direccion del cliente: " + cliente.DatosReferenciaDireccion;
        }   
        public string VerDatosCliente(Cliente cliente)
        {
            return "Nombre del cliente: " + cliente.Nombre + "\n" + "Teléfono del cliente: " + cliente.Telefono;
        }   
        public EstadoPedidos CambiarEstado(int num)
        {
            EstadoPedidos nuevoEstado = EstadoPedidos.pendiente; // Establece un valor por defecto en caso de un número no válido

            switch (num)
            {
                case 1:
                    nuevoEstado = EstadoPedidos.aceptado;
                    break;
                case 2:
                    nuevoEstado = EstadoPedidos.rechazado;
                    break;
                case 3:
                    nuevoEstado = EstadoPedidos.pendiente;
                    break;
                default:
                    Console.WriteLine("Ingreso un número inválido");
                    break;
            }

            return nuevoEstado;
        }
        public int ObtenerID()
        {
            return this.Numero;
        }
    }
}

