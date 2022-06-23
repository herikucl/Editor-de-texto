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
            private No cabe�a;

            public Lista()
            {
                cabe�a = new No();
                cabe�a.prox = null;
            }

            public void inserir(string s)
            {
                No aux = new No();
                aux.elemento = s;
                aux.prox = cabe�a.prox;
                cabe�a.prox = aux;
            }
            public bool contem(string a)
            {
                bool tem=false;
                No aux = new No();
                if (cabe�a.prox != null)
                {
                    aux = cabe�a.prox;
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
            for (int i = 0; i < 27; i++) // Inicializando todas as listas do vetor 
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

        private void novaToolStripMenuItem_Click(object sender, EventArgs e) // Apertou o bot�o novo
        {
            richTextBox1.Text = " ";    // Apaga todo o texto 
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e) // Apertou o bot�o abrir
        {
            openFileDialog1.Filter = "Arquivos de texto |*.txt";    // Filtro para buscar apenas arquivos .txt
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text=File.ReadAllText(openFileDialog1.FileName); // Vai colocar todo o texto do arquivo no editor de texto
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e) // Apertou o bot�o salvar
        {
            saveFileDialog1.Filter = "Arquivos de texto |*.txt"; // Filtro para que o arquivo salvo seja do tipo .txt
            saveFileDialog1.FilterIndex = 2;
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text); // Vai escrever todo o conteudo do editor de texto no arquivo
            }
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)    // Apertou o bot�o desfazer
        {
            richTextBox1.Undo();    // Vai desfazer a ultima a��o (Ctrl+Z)(
        }

        private void refazerToolStripMenuItem_Click(object sender, EventArgs e)  // Apertou o bot�o refazer
        {
            richTextBox1.Redo();   //  Vai refazer a ultima a��o (Ctrl+Y)(
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)    // Apertou o bot�o recortar
        {
            richTextBox1.Cut();   // Vai recortar o bloco de texto selecionado (Ctrl+X)
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)  // Apertou o bot�o copiar
        {
            richTextBox1.Copy(); // Vai copiar o bloco de texto selecionado (Ctrl+C)
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)   // Apertou o bot�o colar
        {
            richTextBox1.Paste();       // Vai colar o bloco de texto selecionado anteriormente (Ctrl+V)
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e) // Apertou o bot�o Selecionar tudo
        {
            richTextBox1.SelectAll();   // Vai selecionar todo o conteudo do editor de texto
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)     //Apertou o botao sobre
        {
            MessageBox.Show("Editor de texto feito em C#, capaz de identificar palavras que n�o est�o presentes em um dicion�rio e destacando-as.\nFeito por: Herik Lemos e Gabriel Reis","Trabalho AED2 2022/1");
        }
        private void AtualizarDicionario()  //Fun��o que vai colocar todas as palavras do dicionario em mem�ria
        {
            char[] limitadores = new char[] { ' ', '\r', '\n', ',', '\t' };
            string txtDicionario = File.ReadAllText(caminho); // Le todo o conteudo do dicionario e salva na variavel 
            string[] palavras = txtDicionario.ToLower().Split(limitadores, StringSplitOptions.RemoveEmptyEntries);  // Quebra o conteudo do dicionario em palavras
            char a;
            for (int i = 0; i < palavras.Length; i++)
            {
                a = palavras[i][0]; // Analisa qual a primeira letra da palavra 

                if ((a >= 97) && (a <= 122)) // A primeira letra est� entre a - z, sendo a=97 e z=122  
                {
                    Alfabeto[a-97].inserir(palavras[i]); // Insere a palavra no vetor correto de acordo com sua primeira letra 
                }
                else
                {
                    Alfabeto[26].inserir(palavras[i]);  // Palavras que come�am com simbolos ou numeros
                }
            }
        }
        private void AddDicionario(string s)    //Fun��o que adiciona novas palavras selecionadas ao dicion�rio
        {
            StreamWriter Escritor;

            Escritor = File.AppendText(caminho);

            char[] limitadores = new char[] { ' ', '\r', '\n', ',', '\t' };
            string[] palavras = s.ToLower().Split(limitadores, StringSplitOptions.RemoveEmptyEntries); //Quebra o bloco do texto selecionado em palavras que ser�o adicionados ao dicionario
            for (int i = 0; i < palavras.Length; i++)
            {
                Escritor.Write(palavras[i] + " ");
            }
            Escritor.Close();
            AtualizarDicionario(); // Puxa novamente o dicion�rio para mem�ria
            MessageBox.Show("Palavra(s) adicionadas com sucesso!","Dicionario modificado");
        }
        private void Marcar(string a)   // Fun��o que marcar� as palavras que n�o est�o presentes no dicion�rio 
        {
            while (inicio < richTextBox1.TextLength)
            {
                int inicioPalavra = richTextBox1.Find(a, inicio, RichTextBoxFinds.WholeWord); // Decobrir� em qual posi��o do editor est� o come�o da palavra buscada
                if (inicioPalavra != -1)    // Palavra foi encontrada
                {
                    richTextBox1.SelectionStart = inicioPalavra;    // Seleciona o incio da palavra
                    richTextBox1.SelectionLength = a.Length;        // At� o final dela   
                    richTextBox1.SelectionBackColor = Color.Coral;  // E marca ela com a cor coral
                    inicio = inicioPalavra + a.Length;              // Para a proxima busca come�ar a partir do final da anterior
                    break;                                          // Depois de encontrar a palavra foge do while para marcar apenas uma palavra de cada vez    
                }
                else    // Palavra n�o foi encontrada
                {
                    break;                                  
                } 
            }
            richTextBox1.DeselectAll(); // Ao final da analise deseleciona qualquer texto que est� selecionado   
        }

        private void verificarToolStripMenuItem_Click(object sender, EventArgs e)   // Apertou o bot�o Verificar
        {
            inicio = 0;
            richTextBox1.SelectAll();                       // Seleciona todo o texto 
            richTextBox1.SelectionBackColor = Color.White;  // E pinta de branco para fazer a verifica��o novamente
            string txtEditor = richTextBox1.Text;           // Puxa o texto do editor de texto para a variavel 
            char[] limitadores = new char[] { ' ', '\r', '\n', ',', '\t' };
            string[] palavras = txtEditor.ToLower().Split(limitadores,StringSplitOptions.RemoveEmptyEntries);
            char a;
            for (int i = 0; i < palavras.Length; i++)
            {
                a = palavras[i][0];

                if ((a >= 97) && (a <= 122)) // A primeira letra est� entre a - z
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

        private void fonteToolStripMenuItem1_Click(object sender, EventArgs e)    //Apertou o botao fonte
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void corToolStripMenuItem_Click(object sender, EventArgs e)      //Apertou o botao cor
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void adicionarAoDicion�rioToolStripMenuItem_Click(object sender, EventArgs e)  //Selecionou um bloco de texto e pressionou o bot�o direito
        {
            AddDicionario(richTextBox1.SelectedText);
        }
    }
}