namespace Pong.Modelo
{
    public class Bola
    {
        private Random random = new Random();
        private int velocidadeInicial;
        private int velocidadeMaxima;

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Tamanho { get; private set; }
        public int VelocidadeX { get; private set; }
        public int VelocidadeY { get; private set; }

        public Bola(int tamanho, int velocidadeInicial, int velocidadeMaxima)
        {
            Tamanho = tamanho;
            this.velocidadeInicial = velocidadeInicial;
            this.velocidadeMaxima = velocidadeMaxima;
        }

        public void Mover()
        {
            X += VelocidadeX;
            Y += VelocidadeY;
        }

        public void ColocarEm(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void InverterDirecaoHorizontal()
        {
            VelocidadeX = -VelocidadeX;
        }

        public void InverterDirecaoVertical()
        {
            VelocidadeY = -VelocidadeY;
        }

        public void Rebater(Raquete raquete)
        {
            if (VelocidadeX < 0)
            {
                X = raquete.X + raquete.Largura;
            }
            else
            {
                X = raquete.X - Tamanho;
            }

            InverterDirecaoHorizontal();

            if (Math.Abs(VelocidadeX) < velocidadeMaxima)
            {
                if (VelocidadeX > 0)
                {
                    VelocidadeX++;
                }
                else
                {
                    VelocidadeX--;
                }
            }

            int centroRaquete = raquete.Y + raquete.Altura / 2;
            int centroBola = Y + Tamanho / 2;
            VelocidadeY = (centroBola - centroRaquete) / 8;
        }

        public void Centralizar(int larguraArea, int alturaArea, int direcao)
        {
            X = (larguraArea - Tamanho) / 2;
            Y = (alturaArea - Tamanho) / 2;

            VelocidadeX = velocidadeInicial * direcao;

            VelocidadeY = random.Next(2, 5);
            if (random.Next(2) == 0)
            {
                VelocidadeY = -VelocidadeY;
            }
        }

        public Rectangle ObterRetangulo()
        {
            return new Rectangle(X, Y, Tamanho, Tamanho);
        }
    }
}
