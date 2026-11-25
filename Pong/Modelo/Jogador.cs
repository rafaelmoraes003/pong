namespace Pong.Modelo
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public int Pontos { get; private set; }
        public Raquete Raquete { get; private set; }

        public Jogador(string nome, Raquete raquete)
        {
            Nome = nome;
            Raquete = raquete;
            Pontos = 0;
        }

        public void MarcarPonto()
        {
            Pontos++;
        }

        public void ZerarPontos()
        {
            Pontos = 0;
        }
    }
}
