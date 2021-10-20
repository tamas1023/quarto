using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quarto_tesok
{
    public partial class Form1 : Form
    {
        static string nev1;
        static string nev2;
        static Babuk[] babu = new Babuk[16];
        static PictureBox[] kepek = new PictureBox[16];
        static int hanyadik = 0;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < babu.Length; i++)
            {
                babu[i] = new Babuk("0", "0", "0", false);
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
                    kep.Name = i + " " + j;
                    kep.Visible = true;
                    kep.Size = new System.Drawing.Size(80,110) ;
                    kep.BackColor = Color.LightBlue;
                    kep.Tag = "0";
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
                if (label5.Text==nev1)
                {
                    label5.Text = nev2;
                }
                else
                {
                    label5.Text = nev1;
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
            babu[8].Lyukas = false;

            babu[9].Szin = "feher";
            babu[9].Alak = "kör";
            babu[9].Méret = "kicsi";
            babu[9].Lyukas = true;

            babu[10].Szin = "feher";
            babu[10].Alak = "kör";
            babu[10].Méret = "nagy";
            babu[10].Lyukas = false;

            babu[11].Szin = "feher";
            babu[11].Alak = "kör";
            babu[11].Méret = "nagy";
            babu[11].Lyukas = true;

            babu[12].Szin = "feher";
            babu[12].Alak = "negyzet";
            babu[12].Méret = "kicsi";
            babu[12].Lyukas = false;

            babu[13].Szin = "feher";
            babu[13].Alak = "negyzet";
            babu[13].Méret = "kicsi";
            babu[13].Lyukas = true;

            babu[14].Szin = "feher";
            babu[14].Alak = "negyzet";
            babu[14].Méret = "nagy";
            babu[14].Lyukas = false;

            babu[15].Szin = "feher";
            babu[15].Alak = "negyzet";
            babu[15].Méret = "nagy";
            babu[15].Lyukas = true;
        }

        private void feketefeltoltes()
        {
            babu[0].Szin = "fekete";
            babu[0].Alak = "kör";
            babu[0].Méret = "kicsi";
            babu[0].Lyukas = false;

            babu[1].Szin = "fekete";
            babu[1].Alak = "kör";
            babu[1].Méret = "kicsi";
            babu[1].Lyukas = true;

            babu[2].Szin = "fekete";
            babu[2].Alak = "kör";
            babu[2].Méret = "nagy";
            babu[2].Lyukas = false;

            babu[3].Szin = "fekete";
            babu[3].Alak = "kör";
            babu[3].Méret = "nagy";
            babu[3].Lyukas = true;

            babu[4].Szin = "fekete";
            babu[4].Alak = "negyzet";
            babu[4].Méret = "kicsi";
            babu[4].Lyukas = false;

            babu[5].Szin = "fekete";
            babu[5].Alak = "negyzet";
            babu[5].Méret = "kicsi";
            babu[5].Lyukas = true;

            babu[6].Szin = "fekete";
            babu[6].Alak = "negyzet";
            babu[6].Méret = "nagy";
            babu[6].Lyukas = false;

            babu[7].Szin = "fekete";
            babu[7].Alak = "negyzet";
            babu[7].Méret = "nagy";
            babu[7].Lyukas = true;
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
                label3.Visible = true;
                label3.Text = "A tábla 4×4 egyforma mezőből áll.Az összesen 16 figura mindegyike különbözik valamiben a többitől. A figurák négy szempont alapján is két egyforma csoportra oszthatók:" +
                    "magas vagy alacsony,sötét vagy világos,kerek vagy szögletes,a teteje lyukas vagy sima.\n Kezdéskor a tábla üres. A kezdési jogot megszerzett játékos nem lép, hanem megjelöli, hogy az ellenfélnek melyik figurával kell lépnie."+
"Ezután a játékosok felváltva lépnek.A soron következő játékos az ellenfele által kijelölt figurával köteles lépni, azt a tábla valamelyik szabad mezőjére kell tennie. Ütés a játékban nincs. A lépés megtétele után ő jelöli ki, hogy az ellenfele melyik figurával lépjen. A figura kijelölése a játék lényeges eleme, és nem bírálható felül. A játékosok felváltva következnek, a játék végéig.A győzelemhez a következő szükséges: a tábla egyenesen, keresztben vagy átlósan négy egyvonalban levő mezőjén négy olyan figurának kell állnia, amelyek a felsorolt négy jellemző valamelyikét nézve egy csoportba tartoznak(például négy szögletes figura).Amelyik játékos a lépésével ezt a helyzetet létrehozta, az nyerte a partit.";
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                button2.Text = "Leírás";
                label3.Visible = false;
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
            
        }
    }
}
