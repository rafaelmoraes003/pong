using System.Drawing.Drawing2D;
using System.Threading;
using Pong.Modelo;

namespace Pong.Interface
{
    public partial class FormPrincipal : Form
    {
        private Jogo jogo;
        private Thread threadJogo;
        private object trava = new object();
        private bool rodando = false;
        private bool pausado = false;

        public FormPrincipal()
        {
            InitializeComponent();

            jogo = new Jogo(pbJogo.Width, pbJogo.Height, 5);
            lblMeta.Text = "Vence quem fizer " + jogo.PontosParaVencer + " pontos";
            AtualizarTela();
        }

        private void IniciarThread()
        {
            lock (trava)
            {
                rodando = true;
                pausado = false;
            }

            threadJogo = new Thread(LoopDoJogo);
            threadJogo.IsBackground = true;
            threadJogo.Start();
        }

        private void PararThread()
        {
            lock (trava)
            {
                rodando = false;
            }

            if (threadJogo != null)
            {
                threadJogo.Join();
                threadJogo = null;
            }
        }

        private void LoopDoJogo()
        {
            while (true)
            {
                bool acabou = false;

                lock (trava)
                {
                    if (!rodando)
                    {
                        break;
                    }

                    if (!pausado)
                    {
                        jogo.Atualizar();

                        if (jogo.Vencedor != null)
                        {
                            rodando = false;
                            acabou = true;
                        }
                    }
                }

                BeginInvoke(new Action(AtualizarTela));

                if (acabou)
                {
                    BeginInvoke(new Action(MostrarVencedor));
                    break;
                }

                Thread.Sleep(15);
            }
        }

        private void AtualizarTela()
        {
            lock (trava)
            {
                lblPontosJogador1.Text = jogo.Jogador1.Nome + ": " + jogo.Jogador1.Pontos;
                lblPontosJogador2.Text = jogo.Jogador2.Nome + ": " + jogo.Jogador2.Pontos;
            }

            pbJogo.Invalidate();
        }

        private void MostrarVencedor()
        {
            lblStatus.Text = "Fim de jogo!";
            btnPausar.Text = "Pausar";
            MessageBox.Show(jogo.Vencedor.Nome + " venceu a partida!", "Fim de jogo");
        }

        private void pbJogo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            using (Pen caneta = new Pen(Color.Gray, 2))
            {
                caneta.DashStyle = DashStyle.Dash;
                g.DrawLine(caneta, pbJogo.Width / 2, 0, pbJogo.Width / 2, pbJogo.Height);
            }

            lock (trava)
            {
                g.FillRectangle(Brushes.White, jogo.Jogador1.Raquete.ObterRetangulo());
                g.FillRectangle(Brushes.White, jogo.Jogador2.Raquete.ObterRetangulo());
                g.FillEllipse(Brushes.White, jogo.Bola.ObterRetangulo());

                if (pausado)
                {
                    using (Font fonte = new Font("Arial", 28, FontStyle.Bold))
                    {
                        g.DrawString("PAUSADO", fonte, Brushes.Yellow, pbJogo.Width / 2 - 85, 120);
                    }
                }
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            bool estaRodando;

            lock (trava)
            {
                estaRodando = rodando;
                pausado = false;
            }

            if (!estaRodando)
            {
                PararThread();

                if (jogo.Vencedor != null)
                {
                    jogo.Reiniciar();
                }

                IniciarThread();
            }

            lblStatus.Text = "Jogo em andamento";
            btnPausar.Text = "Pausar";
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            lock (trava)
            {
                if (!rodando)
                {
                    return;
                }

                pausado = !pausado;
            }

            if (pausado)
            {
                lblStatus.Text = "Jogo pausado";
                btnPausar.Text = "Continuar";
            }
            else
            {
                lblStatus.Text = "Jogo em andamento";
                btnPausar.Text = "Pausar";
            }

            pbJogo.Invalidate();
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            PararThread();
            jogo.Reiniciar();
            IniciarThread();

            AtualizarTela();
            lblStatus.Text = "Jogo em andamento";
            btnPausar.Text = "Pausar";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.W || keyData == Keys.S || keyData == Keys.Up || keyData == Keys.Down)
            {
                MudarTecla(keyData, true);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            MudarTecla(e.KeyCode, false);
        }

        private void MudarTecla(Keys tecla, bool pressionada)
        {
            lock (trava)
            {
                if (tecla == Keys.W)
                {
                    jogo.Jogador1.Raquete.Subindo = pressionada;
                }
                else if (tecla == Keys.S)
                {
                    jogo.Jogador1.Raquete.Descendo = pressionada;
                }
                else if (tecla == Keys.Up)
                {
                    jogo.Jogador2.Raquete.Subindo = pressionada;
                }
                else if (tecla == Keys.Down)
                {
                    jogo.Jogador2.Raquete.Descendo = pressionada;
                }
            }
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            PararThread();
        }
    }
}
