using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Quarto_tesok
{
    public partial class Form1 : Form
    {
        static string nev1;
        static string nev2;
        static Babuk[] babu = new Babuk[16];
        static Babuk[,] gametable = new Babuk[4,4];
        static PictureBox[] kepek = new PictureBox[16];
        static int hanyadik = 0;
        static string kod = "";
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < babu.Length; i++)
            {
                babu[i] = new Babuk("0", "0", "0", "0");
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gametable[i, j] = new Babuk("0", "0", "0", "");
                }
                
            }
        }

        private void palya()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox kep = new PictureBox();
                    kep.Location = new System.Drawing.Point((232 + (i * 86)), (472 - (j * 116)));
                    kep.Name = j+"";
                    kep.Visible = true;
                    kep.Size = new System.Drawing.Size(80,110) ;
                    kep.BackColor = Color.LightBlue;
                    kep.Tag = i+"";
                    Controls.Add(kep);
                    kep.BringToFront();

                    kep.Click += new System.EventHandler(this.palyaklikk);
                    //kep.MouseHover += new System.EventHandler(this.rajta);
                    //kep.MouseLeave += new System.EventHandler(this.eltunes);
                }
            }
            feher();
            fekete();
        }

        private void palyaklikk(object sender, EventArgs e)
        {
            PictureBox kapcsolt = sender as PictureBox;

            if (pictureBox1.Image==null)
            {
                MessageBox.Show("Válassz ki előtte egy elemet");
            }
            else
            {
                kapcsolt.Image = pictureBox1.Image;
                kapcsolt.Enabled = false;
                kepek[hanyadik].Visible = false;
                pictureBox1.Image = null;
                int j = Convert.ToInt32(kapcsolt.Name);
                int i = Convert.ToInt32(kapcsolt.Tag);
                gametable[i,j] = babu[hanyadik];
                //MessageBox.Show(i + " " + j + " és a hanyadik: " + hanyadik);
                if (label4.Text == "Tedd le a bábút")
                {
                    label4.Text = "Válassz ki egy bábút";
                }

                nyertes();
            }
        }

        private void nyertes()
        {
            //megnézi hogy van e nyertes
            int lyukas = 0;
            int nemlyukas = 0;
            int kor = 0;
            int negyzet = 0;
            int feher = 0;
            int fekete = 0;
            int nagy = 0;
            int kicsi = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(gametable[i,j].Lyukas=="igen")
                    {
                        lyukas++;
                    }
                    if (gametable[i, j].Lyukas =="nem")
                    {
                        nemlyukas++;
                    }
                    if (gametable[i, j].Alak == "kör")
                    {
                        kor++;
                    }
                    if (gametable[i, j].Alak == "negyzet")
                    {
                        negyzet++;
                    }
                    if (gametable[i, j].Szin == "feher")
                    {
                        feher++;
                    }
                    if (gametable[i, j].Szin == "fekete")
                    {
                        fekete++;
                    }
                    if (gametable[i, j].Méret == "kicsi")
                    {
                        kicsi++;
                    }
                    if (gametable[i, j].Méret == "nagy")
                    {
                        nagy++;
                    }

                }
                if(kicsi==4||nagy==4||fekete==4||feher==4||kor==4||negyzet==4|| lyukas==4|| nemlyukas==4)
                {
                    if(label5.Text==nev1)
                    {
                        MessageBox.Show("A nyertes: " + nev1, "A játék  vége", MessageBoxButtons.OK);
                        Application.Restart();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("A nyertes: " + nev2, "A játék  vége", MessageBoxButtons.OK);
                        Application.Restart();
                        break;
                    }
                }
                kicsi = 0;
                nagy = 0;
                fekete = 0;
                feher = 0;
                kor = 0;
                negyzet = 0;
                lyukas = 0;
                nemlyukas = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gametable[j, i].Lyukas == "igen")
                    {
                        lyukas++;
                    }
                    if (gametable[j, i].Lyukas == "nem")
                    {
                        nemlyukas++;
                    }
                    if (gametable[j, i].Alak == "kör")
                    {
                        kor++;
                    }
                    if (gametable[j, i].Alak == "negyzet")
                    {
                        negyzet++;
                    }
                    if (gametable[j, i].Szin == "feher")
                    {
                        feher++;
                    }
                    if (gametable[j, i].Szin == "fekete")
                    {
                        fekete++;
                    }
                    if (gametable[j, i].Méret == "kicsi")
                    {
                        kicsi++;
                    }
                    if (gametable[j, i].Méret == "nagy")
                    {
                        nagy++;
                    }

                }
                if (kicsi == 4 || nagy == 4 || fekete == 4 || feher == 4 || kor == 4 || negyzet == 4 || lyukas == 4 || nemlyukas == 4)
                {
                    if (label5.Text == nev1)
                    {
                        MessageBox.Show("A nyertes: " + nev1, "A játék  vége", MessageBoxButtons.OK);
                        Application.Restart();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("A nyertes: " + nev2, "A játék  vége", MessageBoxButtons.OK);
                        Application.Restart();
                        break;
                    }
                }
                kicsi = 0;
                nagy = 0;
                fekete = 0;
                feher = 0;
                kor = 0;
                negyzet = 0;
                lyukas = 0;
                nemlyukas = 0;
            }

            //átlós nézés

            lyukas = 0;
            nemlyukas = 0;
            kicsi = 0;
            nagy = 0;
            fekete = 0;
            feher = 0;
            kor = 0;
            negyzet = 0;
            for (int i = 0; i < 4; i++)
            {
                switch(gametable[i,i].Alak)
                {
                    case "kör":
                        kor++;
                        break;
                    case "negyzet":
                        negyzet++;
                        break;
                }
                switch (gametable[i, i].Szin)
                {
                    case "feher":
                        feher++;
                        break;
                    case "fekete":
                        fekete++;
                        break;
                }
                switch (gametable[i, i].Méret)
                {
                    case "kicsi":
                        kicsi++;
                        break;
                    case "nagy":
                        nagy++;
                        break;
                }
                switch (gametable[i, i].Lyukas)
                {
                    case "igen":
                        lyukas++;
                        break;
                    case "nem":
                        nemlyukas++;
                        break;
                }
            }
            if (kicsi == 4 || nagy == 4 || fekete == 4 || feher == 4 || kor == 4 || negyzet == 4||lyukas==4||nemlyukas==4)
            {
                if (label5.Text == nev1)
                {
                    MessageBox.Show("A nyertes: " + nev1, "A játék  vége", MessageBoxButtons.OK);
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("A nyertes: " + nev2, "A játék  vége", MessageBoxButtons.OK);
                    Application.Restart();
                }
            }

            // másik átló

            kicsi = 0;
            nagy = 0;
            fekete = 0;
            feher = 0;
            kor = 0;
            negyzet = 0;
            lyukas = 0;
            nemlyukas = 0;
            for (int i = 0; i < 4; i++)
            {
                switch (gametable[3-i, i].Alak)
                {
                    case "kör":
                        kor++;
                        break;
                    case "negyzet":
                        negyzet++;
                        break;
                }
                switch (gametable[3-i, i].Szin)
                {
                    case "feher":
                        feher++;
                        break;
                    case "fekete":
                        fekete++;
                        break;
                }
                switch (gametable[3-i, i].Méret)
                {
                    case "kicsi":
                        kicsi++;
                        break;
                    case "nagy":
                        nagy++;
                        break;
                }
                switch (gametable[3-i, i].Lyukas)
                {
                    case "igen":
                        lyukas++;
                        break;
                    case "nem":
                        nemlyukas++;
                        break;
                }
            }
            if (kicsi == 4 || nagy == 4 || fekete == 4 || feher == 4 || kor == 4 || negyzet == 4 || lyukas == 4 || nemlyukas == 4)
            {
                if (label5.Text == nev1)
                {
                    MessageBox.Show("A nyertes: " + nev1, "A játék  vége", MessageBoxButtons.OK);
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("A nyertes: " + nev2, "A játék  vége", MessageBoxButtons.OK);
                    Application.Restart();
                }
            }
            
        }

        private void fekete()
        {
            int db = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox kep = new PictureBox();
                    kep.Location = new System.Drawing.Point((645 + (i * 86)), (472 - (j * 116)));
                    kep.Name = ""+db;
                    kep.Visible = true;
                    kep.Size = new System.Drawing.Size(80, 110);
                    kep.BackColor = Color.LightBlue;
                    kep.Tag = "fekete";
                    Controls.Add(kep);
                    kep.BringToFront();
                    kep.Image = Image.FromFile(db+".png");
                    kepek[db]= kep;
                    db++;
                    kep.Click += new System.EventHandler(this.klikk);
                    //kep.MouseHover += new System.EventHandler(this.rajta);
                    //kep.MouseLeave += new System.EventHandler(this.eltunes);
                }
            }
        }

        private void feher()
        {
            int db = 8;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PictureBox kep = new PictureBox();
                    kep.Location = new System.Drawing.Point((2 + (i * 86)), (472 - (j * 116)));
                    kep.Name = ""+db;
                    kep.Visible = true;
                    kep.Size = new System.Drawing.Size(80, 110);
                    kep.BackColor = Color.LightBlue;
                    kep.Tag = "feher";
                    Controls.Add(kep);
                    kep.BringToFront();
                    kep.Image = Image.FromFile(db + ".png");
                    kepek[db] = kep;
                    db++;
                    kep.Click += new System.EventHandler(this.klikk);
                    //kep.MouseHover += new System.EventHandler(this.rajta);
                    //kep.MouseLeave += new System.EventHandler(this.eltunes);
                }
            }
        }

        private void klikk(object sender, EventArgs e)
        {
            PictureBox kapcsolt = sender as PictureBox;
            pictureBox1.Image = kapcsolt.Image;
            hanyadik =Convert.ToInt32(kapcsolt.Name);
            if(label4.Text == "Tedd le a bábút")
            {
            

            }
            else
            {
                if (label5.Text == nev1)
                {
                    label5.Text = nev2;
                    label4.Text = "Tedd le a bábút";

                }
                else
                {
                    label5.Text = nev1;
                    label4.Text = "Tedd le a bábút";
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // bábúk osztály, azzal jó lehet
            feketefeltoltes();
            feherfeltoltes();
        }

        private void feherfeltoltes()
        {
            babu[8].Szin = "feher";
            babu[8].Alak = "kör";
            babu[8].Méret = "kicsi";
            babu[8].Lyukas = "nem";

            babu[9].Szin = "feher";
            babu[9].Alak = "kör";
            babu[9].Méret = "kicsi";
            babu[9].Lyukas = "igen";

            babu[10].Szin = "feher";
            babu[10].Alak = "kör";
            babu[10].Méret = "nagy";
            babu[10].Lyukas = "nem";

            babu[11].Szin = "feher";
            babu[11].Alak = "kör";
            babu[11].Méret = "nagy";
            babu[11].Lyukas = "igen";

            babu[12].Szin = "feher";
            babu[12].Alak = "negyzet";
            babu[12].Méret = "kicsi";
            babu[12].Lyukas = "nem";

            babu[13].Szin = "feher";
            babu[13].Alak = "negyzet";
            babu[13].Méret = "kicsi";
            babu[13].Lyukas = "igen";

            babu[14].Szin = "feher";
            babu[14].Alak = "negyzet";
            babu[14].Méret = "nagy";
            babu[14].Lyukas = "nem";

            babu[15].Szin = "feher";
            babu[15].Alak = "negyzet";
            babu[15].Méret = "nagy";
            babu[15].Lyukas = "igen";
        }

        private void feketefeltoltes()
        {
            babu[0].Szin = "fekete";
            babu[0].Alak = "kör";
            babu[0].Méret = "kicsi";
            babu[0].Lyukas = "nem";

            babu[1].Szin = "fekete";
            babu[1].Alak = "kör";
            babu[1].Méret = "kicsi";
            babu[1].Lyukas = "igen";

            babu[2].Szin = "fekete";
            babu[2].Alak = "kör";
            babu[2].Méret = "nagy";
            babu[2].Lyukas = "nem";

            babu[3].Szin = "fekete";
            babu[3].Alak = "kör";
            babu[3].Méret = "nagy";
            babu[3].Lyukas = "igen";

            babu[4].Szin = "fekete";
            babu[4].Alak = "negyzet";
            babu[4].Méret = "kicsi";
            babu[4].Lyukas = "nem";

            babu[5].Szin = "fekete";
            babu[5].Alak = "negyzet";
            babu[5].Méret = "kicsi";
            babu[5].Lyukas = "igen";

            babu[6].Szin = "fekete";
            babu[6].Alak = "negyzet";
            babu[6].Méret = "nagy";
            babu[6].Lyukas = "nem";

            babu[7].Szin = "fekete";
            babu[7].Alak = "negyzet";
            babu[7].Méret = "nagy";
            babu[7].Lyukas = "igen";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //leírás a label3 ban
            if(button2.Text=="Leírás")
            {
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Text = "Vissza";
                this.BackColor = Color.Black;
                this.Size = new Size(700 , 550);
                label3.Size = new Size(500, 400);
                label3.Visible = true;
                label5.Text = "Quarto Játékszabályok";
                label5.Visible = true;
                label5.ForeColor = Color.DarkRed;
                
                label3.Text = "A tábla 4×4 egyforma mezőből áll.Az összesen 16 figura mindegyike különbözik valamiben a többitől. A figurák négy szempont alapján is két egyforma csoportra oszthatók:" +
                    "\n \nmagas vagy alacsony,sötét vagy világos,kerek vagy szögletes,a teteje lyukas vagy sima.\n Kezdéskor a tábla üres. A kezdési jogot megszerzett játékos nem lép, hanem megjelöli, hogy az ellenfélnek melyik figurával kell lépnie."+
"\n \nEzután a játékosok felváltva lépnek.A soron következő játékos az ellenfele által kijelölt figurával köteles lépni, azt a tábla valamelyik szabad mezőjére kell tennie. Ütés a játékban nincs. A lépés megtétele után ő jelöli ki, hogy az ellenfele melyik figurával lépjen. A figura kijelölése a játék lényeges eleme, és nem bírálható felül.\n \n A játékosok felváltva következnek, a játék végéig.A győzelemhez a következő szükséges: a tábla egyenesen, keresztben vagy átlósan négy egyvonalban levő mezőjén négy olyan figurának kell állnia, amelyek a felsorolt négy jellemző valamelyikét nézve egy csoportba tartoznak(például négy szögletes figura).Amelyik játékos a lépésével ezt a helyzetet létrehozta, az nyerte a partit.";
                button2.Enabled = false;
               
                button2.Enabled = true;
                //this.ActiveControl = Form1;
               
            }
            else
            {
                this.BackColor = Color.CornflowerBlue;
                this.Size = new Size(835, 681);
                label3.Size = new Size(700, 291);
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                button2.Text = "Leírás";
                label3.Visible = false;
                label5.Visible = false;
                label5.ForeColor = Color.Black;
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nev1 = textBox1.Text;
            nev2 = textBox2.Text;
            if(textBox1.Text!=""&&textBox2.Text!=""&&textBox2.Text!=textBox1.Text)
            {
                palya();//pálya generálása
                richTextBox1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                pictureBox1.Visible = true;
                label5.Text = nev1;
            }
            else
            {
                MessageBox.Show("Nem megfelelőek a bemeneti adatok.", "Hiba a belépésnél", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            label1.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            kod += e.KeyCode;
            if (e.KeyCode == Keys.Delete)
            {
                kod = "";
                //label3.Text = "";
            }
            label1.Focus();
            //jól kinézés miatt: label felfele csúszik (olyan hatás mintha görgetődne magától)
            //vagy valahogy máshogy megoldani
            //a label el belüli színezést hogy kell megoldani
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (button2.Text=="Vissza")
            {
                if (keyData== Keys.Enter)
                {
                    //label1.Visible = true;
                    
                    if (kod == "UPUPDOWNDOWNLEFTRIGHTLEFTRIGHTBA")
                    {
                        CreditBTN.Visible = true;
                    }
                }
                else
                {
                    //capture up arrow key
                    if (keyData == Keys.Up)
                    {
                        //MessageBox.Show("You pressed Up arrow key");
                        kod += "UP";
                        
                        
                        return true;
                    }
                    
                    //capture down arrow key
                    if (keyData == Keys.Down)
                    {
                        //MessageBox.Show("You pressed Down arrow key");
                        kod += "DOWN";
                        
                        
                        return true;
                    }
                    //capture left arrow key
                    if (keyData == Keys.Left)
                    {
                        //MessageBox.Show("You pressed Left arrow key");
                        kod += "LEFT";
                        
                        
                        return true;
                    }
                    //capture right arrow key
                    if (keyData == Keys.Right)
                    {
                        //MessageBox.Show("You pressed Right arrow key");
                        kod += "RIGHT";
                        
                        
                        return true;
                    }
                    return base.ProcessCmdKey(ref msg, keyData);
                    }
                }
                
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void CreditBTN_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
            //keszitokLBL.Visible = true;
            
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectedText += "Készítők:\n";
            richTextBox1.SelectionColor = Color.Blue;
            richTextBox1.SelectedText += "Bodnár Tamás\n";
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectedText += "Bodnár András\n";
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectedText += "A legtöbb időt ennek a funkicónak a beépítése vette el...\n";
            richTextBox1.SelectedText += ",még sok mindent akartam ezzel csinálni, de sajnos az még sokkal több munkát igényelt volna.\n";
            richTextBox1.SelectedText += "De minden esetre élveztem ennek az elkészítését!\n";
            this.InitializeTimer();
        }
        private void InitializeTimer()
        {
            //this.timer1.Interval = 1500; //1.5 seconds
            this.timer1.Interval = 1;
            this.timer1.Enabled = true; //Start
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int step = 1;
            //Limit and stop till center-x of label reaches center-x of the form's
            //if ((this.keszitokLBL.Location.X + (this.keszitokLBL.Width / 2)) < (this.ClientRectangle.Width / 2))
            //{
            //    //Move from left to right by incrementing x
            //    this.keszitokLBL.Location = new Point(this.keszitokLBL.Location.X + step, this.keszitokLBL.Location.Y);

            //}
            if (this.richTextBox1.Location.Y>=100)
            {
                this.richTextBox1.Location = new Point(this.richTextBox1.Location.X, this.richTextBox1.Location.Y-step);
            }
            else
            {
                this.timer1.Enabled = false; //Stop
            }    
        }

    }
}
