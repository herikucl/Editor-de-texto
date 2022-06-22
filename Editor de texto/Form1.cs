namespace Editor_de_texto
{
    public partial class Form1 : Form
    {
        Lista[] Alfabeto = new Lista[27]; // Lista 0 a 25 para cada letra do alfabeto e a ultima lista para simbolos 
        string caminho = "Dicionario.txt";
        int inicio = 0;
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

            //Formatando Dicionario
            string txtDicionario = File.ReadAllText(caminho);
            char[] limitadores = new char[] { ' ', '\r', '\n', ',', '\t' };
            File.WriteAllText(caminho, String.Empty);
            string[] palavras = txtDicionario.ToLower().Split(limitadores, StringSplitOptions.RemoveEmptyEntries);
            StreamWriter sw;
            sw = File.AppendText(caminho);
            sw.Write(" ");
            for (int i = 0; i < palavras.Length; i++)
            {
                palavras[i] += " ";
                sw.Write(palavras[i]);
            }
            sw.Close();

        }

        private void novaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
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
            saveFileDialog1.Filter = "Arquivos de texto |*.txt";
            saveFileDialog1.FilterIndex = 2;
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
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
            MessageBox.Show("Editor de texto feito em C#, capaz de identificar palavras que não estão presentes em um dicionário e destacando-as.\nFeito por: Herik Lemos e Gabriel Reis","Trabalho AED2 2022/1");
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

                if ((a >= 97) && (a <= 122)) // A primeira letra está entre a - z
                {
                    Alfabeto[a-97].inserir(palavras[i]);
                }
                else
                {
                    Alfabeto[26].inserir(palavras[i]);
                }
            }
        }
        private void AddDicionario(string s)
        {
            StreamWriter Escritor;

            Escritor = File.AppendText(caminho);

            char[] limitadores = new char[] { ' ', '\r', '\n', ',', '\t' };
            string[] palavras = s.ToLower().Split(limitadores, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < palavras.Length; i++)
            {
                Escritor.Write(palavras[i] + " ");
            }
            Escritor.Close();
            AtualizarDicionario();
            MessageBox.Show("Palavra(s) adicionadas com sucesso!","Dicionario modificado");
        }
        private void Marcar(string a)
        {
            while (inicio < richTextBox1.TextLength)
            {
                int inicioPalavra = richTextBox1.Find(a, inicio, RichTextBoxFinds.WholeWord);
                if (inicioPalavra != -1)
                {
                    richTextBox1.SelectionStart = inicioPalavra;
                    richTextBox1.SelectionLength = a.Length;
                    richTextBox1.SelectionBackColor = Color.Coral;
                    inicio = inicioPalavra + a.Length;
                    break;
                }
                else
                {
                    break;
                } 
            }
            richTextBox1.DeselectAll();
        }

        private void verificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inicio = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
            string txtEditor = richTextBox1.Text;
            char[] limitadores = new char[] { ' ', '\r', '\n', ',', '\t' };
            string[] palavras = txtEditor.ToLower().Split(limitadores,StringSplitOptions.RemoveEmptyEntries);
            char a;
            for (int i = 0; i < palavras.Length; i++)
            {
                a = palavras[i][0];

                if ((a >= 97) && (a <= 122)) // A primeira letra está entre a - z
                {
                    if (!Alfabeto[a-97].contem(palavras[i]))
                    {
                        Marcar(palavras[i]);
                    }
                }
                else
                {
                    if (!Alfabeto[26].contem(palavras[i]))
                    {
                        Marcar(palavras[i]);
                    }
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