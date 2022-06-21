namespace Editor_de_texto
{
    public partial class Form1 : Form
    {
        Lista[] Alfabeto = new Lista[27];
        string caminho = "Dicionario.txt";
        public class No
        {
            public string elemento;
            public No prox;
            public No()
            {
                elemento = " ";
                prox = null;
            }
        }

        class Lista
        {
            private No cabeça;

            public Lista()
            {
                cabeça = new No();
                cabeça.prox = null;
            }

            public void inserir(string s)
            {
                No aux = new No();
                aux.elemento = s;
                aux.prox = cabeça.prox;
                cabeça.prox = aux;
            }
            public bool contem(string a)
            {
                bool tem=false;
                No aux = new No();
                if (cabeça.prox != null)
                {
                    aux = cabeça.prox;
                }
                else
                {
                    aux.prox=null;
                }
                while (aux.prox != null)
                {
                    if (a == aux.elemento)
                    {
                        tem = true;
                        break;
                    }
                        tem = false;
                    aux = aux.prox;
                }
                if (a == aux.elemento)
                {
                    tem = true;
                }
                return tem;
            }

        }


        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 27; i++)
            {
                Alfabeto[i] = new Lista();
            }
            AtualizarDicionario();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Arquivos de texto |*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text=File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            richTextBox1.SaveFile(saveFileDialog1.FileName);
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void refazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editor de texto feito em c#, capaz de identificar palavras em um dicionário\nFeito por: Herik Lemos e Gabriel Reis");
        }
        private void AtualizarDicionario()
        {
            char[] limitadores = new char[] { ' ', '\r', '\n', ',', '\t' };
            string txtDicionario = File.ReadAllText(caminho);
            string[] palavras = txtDicionario.ToLower().Split(limitadores, StringSplitOptions.RemoveEmptyEntries);
            char a;
            for (int i = 0; i < palavras.Length; i++)
            {
                a = palavras[i][0];
                switch (a)
                {
                    case 'a':
                        Alfabeto[0].inserir(palavras[i]);
                        break;
                    case 'b':
                        Alfabeto[1].inserir(palavras[i]);
                        break;
                    case 'c':
                        Alfabeto[2].inserir(palavras[i]);
                        break;
                    case 'd':
                        Alfabeto[3].inserir(palavras[i]);
                        break;
                    case 'e':
                        Alfabeto[4].inserir(palavras[i]);
                        break;
                    case 'f':
                        Alfabeto[5].inserir(palavras[i]);
                        break;
                    case 'g':
                        Alfabeto[6].inserir(palavras[i]);
                        break;
                    case 'h':
                        Alfabeto[7].inserir(palavras[i]);
                        break;
                    case 'i':
                        Alfabeto[8].inserir(palavras[i]);
                        break;
                    case 'j':
                        Alfabeto[9].inserir(palavras[i]);
                        break;
                    case 'k':
                        Alfabeto[10].inserir(palavras[i]);
                        break;
                    case 'l':
                        Alfabeto[11].inserir(palavras[i]);
                        break;
                    case 'm':
                        Alfabeto[12].inserir(palavras[i]);
                        break;
                    case 'n':
                        Alfabeto[13].inserir(palavras[i]);
                        break;
                    case 'o':
                        Alfabeto[14].inserir(palavras[i]);
                        break;
                    case 'p':
                        Alfabeto[15].inserir(palavras[i]);
                        break;
                    case 'q':
                        Alfabeto[16].inserir(palavras[i]);
                        break;
                    case 'r':
                        Alfabeto[17].inserir(palavras[i]);
                        break;
                    case 's':
                        Alfabeto[18].inserir(palavras[i]);
                        break;
                    case 't':
                        Alfabeto[19].inserir(palavras[i]);
                        break;
                    case 'u':
                        Alfabeto[20].inserir(palavras[i]);
                        break;
                    case 'v':
                        Alfabeto[21].inserir(palavras[i]);
                        break;
                    case 'w':
                        Alfabeto[22].inserir(palavras[i]);
                        break;
                    case 'x':
                        Alfabeto[23].inserir(palavras[i]);
                        break;
                    case 'y':
                        Alfabeto[24].inserir(palavras[i]);
                        break;
                    case 'z':
                        Alfabeto[25].inserir(palavras[i]);
                        break;
                    default:
                        Alfabeto[26].inserir(palavras[i]);
                        break;
                }
            }
        }
        private void AddDicionario(string s)
        {
            StreamWriter Escritor;

            Escritor = File.AppendText(caminho);
            Escritor.Write(s+" ");
            Escritor.Close();
            AtualizarDicionario();
        }
        private void Marcar(string a)
        {
            int inicio = 0;
            while (inicio<richTextBox1.TextLength)
            {
                int inicioPalavra = richTextBox1.Find(a,inicio,RichTextBoxFinds.None);
                if (inicioPalavra!=-1)
                {
                    richTextBox1.SelectionStart = inicioPalavra;
                    richTextBox1.SelectionLength = a.Length;
                    richTextBox1.SelectionBackColor = Color.Coral;
                }
                else
                {
                    break;
                }
                inicio = inicioPalavra + a.Length;
            }
        }

        private void verificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
            string txtEditor = richTextBox1.Text;
            char[] limitadores = new char[] { ' ', '\r', '\n', ',', '\t' };
            string[] palavras = txtEditor.ToLower().Split(limitadores,StringSplitOptions.RemoveEmptyEntries);
            char a;
            for (int i = 0; i < palavras.Length; i++)
            {
                a = palavras[i][0];
                switch (a)
                {
                    case 'a':
                        if (!Alfabeto[0].contem(palavras[i])){ Marcar(palavras[i]); }
                        break;
                    case 'b':
                        if (!Alfabeto[1].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'c':
                        if (!Alfabeto[2].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'd':
                        if (!Alfabeto[3].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'e':
                        if (!Alfabeto[4].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'f':
                        if (!Alfabeto[5].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'g':
                        if (!Alfabeto[6].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'h':
                        if (!Alfabeto[7].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'i':
                        if (!Alfabeto[8].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'j':
                        if (!Alfabeto[9].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'k':
                        if (!Alfabeto[10].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'l':
                        if (!Alfabeto[11].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'm':
                        if (!Alfabeto[12].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'n':
                        if (!Alfabeto[13].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'o':
                        if (!Alfabeto[14].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'p':
                        if (!Alfabeto[15].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'q':
                        if (!Alfabeto[16].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'r':
                        if (!Alfabeto[17].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 's':
                        if (!Alfabeto[18].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 't':
                        if (!Alfabeto[19].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'u':
                        if (!Alfabeto[20].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'v':
                        if (!Alfabeto[21].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'w':
                        if (!Alfabeto[22].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'x':
                        if (!Alfabeto[23].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'y':
                        if (!Alfabeto[24].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    case 'z':
                        if (!Alfabeto[25].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                    default:
                        if (!Alfabeto[26].contem(palavras[i])) { Marcar(palavras[i]); }
                        break;
                }
            }
        }

        private void fonteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void corToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void adicionarAoDicionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDicionario(richTextBox1.SelectedText);
        }
    }
}