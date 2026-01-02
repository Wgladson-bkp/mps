namespace mps
{
    public class ProjetoPadrao
    {
        public ProjetoPadrao(string tipo, string modelo)
        {
            Tipo = tipo;
            Modelo = modelo;
        }

        public string Tipo { get; set; }
        public string Modelo { get; set; }
    }
}
