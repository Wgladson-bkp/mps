namespace mps
{
    public class ProjetoPadrao
    {
        public ProjetoPadrao(string camada, string modelo)
        {
            Camada = camada;
            Modelo = modelo;
        }

        public string Camada { get; set; }
        public string Modelo { get; set; }
    }
}
