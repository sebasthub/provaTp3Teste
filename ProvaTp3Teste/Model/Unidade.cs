namespace ProvaTp3Teste.Model
{
    public class Unidade
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public String Localização { get; set; }

        public ICollection<Bloco> Blocos { get; set; }
    }
}
