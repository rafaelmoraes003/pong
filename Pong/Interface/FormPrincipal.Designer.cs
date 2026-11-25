namespace Pong.Interface
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblPontosJogador1 = new Label();
            lblPontosJogador2 = new Label();
            lblMeta = new Label();
            pbJogo = new PictureBox();
            btnIniciar = new Button();
            btnPausar = new Button();
            btnReiniciar = new Button();
            lblStatus = new Label();
            lblControles = new Label();
            ((System.ComponentModel.ISupportInitialize)pbJogo).BeginInit();
            SuspendLayout();
            lblPontosJogador1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPontosJogador1.ForeColor = Color.White;
            lblPontosJogador1.Location = new Point(20, 10);
            lblPontosJogador1.Name = "lblPontosJogador1";
            lblPontosJogador1.Size = new Size(300, 50);
            lblPontosJogador1.TabIndex = 0;
            lblPontosJogador1.Text = "Jogador 1: 0";
            lblPontosJogador1.TextAlign = ContentAlignment.MiddleLeft;
            lblPontosJogador2.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPontosJogador2.ForeColor = Color.White;
            lblPontosJogador2.Location = new Point(520, 10);
            lblPontosJogador2.Name = "lblPontosJogador2";
            lblPontosJogador2.Size = new Size(300, 50);
            lblPontosJogador2.TabIndex = 1;
            lblPontosJogador2.Text = "Jogador 2: 0";
            lblPontosJogador2.TextAlign = ContentAlignment.MiddleRight;
            lblMeta.Font = new Font("Segoe UI", 10F);
            lblMeta.ForeColor = Color.Silver;
            lblMeta.Location = new Point(320, 10);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(200, 50);
            lblMeta.TabIndex = 2;
            lblMeta.Text = "Vence quem fizer 5 pontos";
            lblMeta.TextAlign = ContentAlignment.MiddleCenter;
            pbJogo.BackColor = Color.Black;
            pbJogo.Location = new Point(20, 70);
            pbJogo.Name = "pbJogo";
            pbJogo.Size = new Size(800, 480);
            pbJogo.TabIndex = 3;
            pbJogo.TabStop = false;
            pbJogo.Paint += pbJogo_Paint;
            btnIniciar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIniciar.Location = new Point(20, 565);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(130, 40);
            btnIniciar.TabIndex = 4;
            btnIniciar.TabStop = false;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            btnPausar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPausar.Location = new Point(160, 565);
            btnPausar.Name = "btnPausar";
            btnPausar.Size = new Size(130, 40);
            btnPausar.TabIndex = 5;
            btnPausar.TabStop = false;
            btnPausar.Text = "Pausar";
            btnPausar.UseVisualStyleBackColor = true;
            btnPausar.Click += btnPausar_Click;
            btnReiniciar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReiniciar.Location = new Point(300, 565);
            btnReiniciar.Name = "btnReiniciar";
            btnReiniciar.Size = new Size(130, 40);
            btnReiniciar.TabIndex = 6;
            btnReiniciar.TabStop = false;
            btnReiniciar.Text = "Reiniciar";
            btnReiniciar.UseVisualStyleBackColor = true;
            btnReiniciar.Click += btnReiniciar_Click;
            lblStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Gold;
            lblStatus.Location = new Point(450, 560);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(370, 25);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Clique em Iniciar para começar";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            lblControles.Font = new Font("Segoe UI", 9F);
            lblControles.ForeColor = Color.Silver;
            lblControles.Location = new Point(450, 585);
            lblControles.Name = "lblControles";
            lblControles.Size = new Size(370, 22);
            lblControles.TabIndex = 8;
            lblControles.Text = "Jogador 1: W / S     Jogador 2: Seta Cima / Seta Baixo";
            lblControles.TextAlign = ContentAlignment.MiddleRight;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            ClientSize = new Size(840, 620);
            Controls.Add(lblControles);
            Controls.Add(lblStatus);
            Controls.Add(btnReiniciar);
            Controls.Add(btnPausar);
            Controls.Add(btnIniciar);
            Controls.Add(pbJogo);
            Controls.Add(lblMeta);
            Controls.Add(lblPontosJogador2);
            Controls.Add(lblPontosJogador1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pong";
            FormClosing += FormPrincipal_FormClosing;
            KeyUp += FormPrincipal_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pbJogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblPontosJogador1;
        private Label lblPontosJogador2;
        private Label lblMeta;
        private PictureBox pbJogo;
        private Button btnIniciar;
        private Button btnPausar;
        private Button btnReiniciar;
        private Label lblStatus;
        private Label lblControles;
    }
}
