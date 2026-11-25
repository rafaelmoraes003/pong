namespace Pong.Modelo
{
    public class Raquete
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Largura { get; private set; }
        public int Altura { get; private set; }
        public int Velocidade { get; private set; }

        public bool Subindo { get; set; }
        public bool Descendo { get; set; }

        public Raquete(int x, int largura, int altura, int velocidade)
        {
            X = x;
            Largura = largura;
            Altura = altura;
            Velocidade = velocidade;
        }

        public void Mover(int alturaArea)
        {
            if (Subindo)
            {
                Y -= Velocidade;
            }

            if (Descendo)
            {
                Y += Velocidade;
            }

            if (Y < 0)
            {
                Y = 0;
            }

            if (Y + Altura > alturaArea)
            {
                Y = alturaArea - Altura;
            }
        }

        public void Centralizar(int alturaArea)
        {
            Y = (alturaArea - Altura) / 2;
            Subindo = false;
            Descendo = false;
        }

        public Rectangle ObterRetangulo()
        {
            return new Rectangle(X, Y, Largura, Altura);
        }
    }
}
