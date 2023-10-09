using Pedidos;

namespace Cadetes
{
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telefono;
        public int CantEnvios;
        public float CantGanado;

        public string? Telefono { get => telefono; set => telefono = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }


        public Cadete(int id,string nombre, string dir, string telefono)
        {
            this.Id=id;
            Nombre=nombre;
            Direccion = dir;
            Telefono=telefono;
            this.CantEnvios=0;
            this.CantGanado=0;
        }
        public Cadete()
        {
            this.Id=999;
            Nombre="NN";
            Direccion = "NN";
            Telefono="999";
            this.CantEnvios=0;
            this.CantGanado=0;
        }
        public int ObtenerID()
        {
           return this.Id;
        }
    }
}