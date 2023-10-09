namespace Clientes
{
    public class Cliente
    {
        private string? nombre;
        private string? direccion;
        private int telefono;
        private string? datosReferenciaDireccion;

        public string? Nombre { get => Nombre; set => Nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        //Constructor de cliente
        public Cliente(string nombre, string dir, int tel, string referencia)
        {
            this.nombre=nombre;
            Direccion=dir; 
            Telefono=tel;
            DatosReferenciaDireccion = referencia;
        }
        public Cliente()
        {
            nombre="";
            Direccion="";
            Telefono=0;
            DatosReferenciaDireccion = "";
        }
        public string MostrarCliente()
        {
            string clienteInfo = $"---------Nombre: {this.nombre}\n";
            clienteInfo += $"---------Direccion: {this.direccion}\n";
            clienteInfo += $"---------Telefono: {this.telefono}\n";
            clienteInfo += $"---------DatosReferenciaDireccion: {this.datosReferenciaDireccion}";
            
            return clienteInfo;
        }
    }
}
