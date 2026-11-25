namespace Pong.Modelo
{
    public class Jogo
    {
        private Random random = new Random();
        private int esperaSaque;

        public int Largura { get; private set; }
        public int Altura { get; private set; }
        public int PontosParaVencer { get; private set; }

        public Jogador Jogador1 { get; private set; }
        public Jogador Jogador2 { get; private set; }
        public Bola Bola { get; private set; }
        public Jogador Vencedor { get; private set; }

        public Jogo(int largura, int altura, int pontosParaVencer)
        {
            Largura = largura;
            Altura = altura;
            PontosParaVencer = pontosParaVencer;

            Raquete raquete1 = new Raquete(20, 15, 90, 7);
            Raquete raquete2 = new Raquete(largura - 35, 15, 90, 7);

            Jogador1 = new Jogador("Jogador 1", raquete1);
            Jogador2 = new Jogador("Jogador 2", raquete2);
            Bola = new Bola(14, 5, 12);

            Reiniciar();
        }

        public void Reiniciar()
        {
            Jogador1.ZerarPontos();
            Jogador2.ZerarPontos();
            Jogador1.Raquete.Centralizar(Altura);
            Jogador2.Raquete.Centralizar(Altura);
            Vencedor = null;

            int direcao = random.Next(2) == 0 ? -1 : 1;
            NovoSaque(direcao);
        }

        public void Atualizar()
        {
            if (Vencedor != null)
            {
                return;
            }

            Jogador1.Raquete.Mover(Altura);
            Jogador2.Raquete.Mover(Altura);

            if (esperaSaque > 0)
            {
                esperaSaque--;
                return;
            }

            Bola.Mover();

            VerificarColisaoComBordas();
            VerificarColisaoComRaquetes();
            VerificarPonto();
        }

        private void VerificarColisaoComBordas()
        {
            if (Bola.Y <= 0)
            {
                Bola.ColocarEm(Bola.X, 0);
                if (Bola.VelocidadeY < 0)
                {
                    Bola.InverterDirecaoVertical();
                }
            }
            else if (Bola.Y + Bola.Tamanho >= Altura)
            {
                Bola.ColocarEm(Bola.X, Altura - Bola.Tamanho);
                if (Bola.VelocidadeY > 0)
                {
                    Bola.InverterDirecaoVertical();
                }
            }
        }

        private void VerificarColisaoComRaquetes()
        {
            Rectangle bola = Bola.ObterRetangulo();

            if (Bola.VelocidadeX < 0 && bola.IntersectsWith(Jogador1.Raquete.ObterRetangulo()))
            {
                Bola.Rebater(Jogador1.Raquete);
            }
            else if (Bola.VelocidadeX > 0 && bola.IntersectsWith(Jogador2.Raquete.ObterRetangulo()))
            {
                Bola.Rebater(Jogador2.Raquete);
            }
        }

        private void VerificarPonto()
        {
            if (Bola.X + Bola.Tamanho < 0)
            {
                Jogador2.MarcarPonto();
                DepoisDoPonto(Jogador2, -1);
            }
            else if (Bola.X > Largura)
            {
                Jogador1.MarcarPonto();
                DepoisDoPonto(Jogador1, 1);
            }
        }

        private void DepoisDoPonto(Jogador quemFezPonto, int direcaoDoSaque)
        {
            NovoSaque(direcaoDoSaque);

            if (quemFezPonto.Pontos >= PontosParaVencer)
            {
                Vencedor = quemFezPonto;
            }
        }

        private void NovoSaque(int direcao)
        {
            Bola.Centralizar(Largura, Altura, direcao);
            esperaSaque = 50;
        }
    }
}
