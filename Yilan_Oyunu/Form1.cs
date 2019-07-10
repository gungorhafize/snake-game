using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Yilan_Oyunu
{
    public partial class Form1 : Form
    {
        Random ranfoood = new Random();
        Graphics kagit;
        Yilan yilann = new Yilan();
        yiyecek yck;
        bool sol = false;
        bool sag = false;
        bool asagi = false;
        bool yukari = false;

        int skor = 0;

        public Form1()
        {
            InitializeComponent();
            yck = new yiyecek(ranfoood);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e) //BU EVENT SAYESİNDE ÇİZİLİYOR YILAN YİYECEK VS.
        {
            kagit = e.Graphics;
            yck.yiyecekolusumu(kagit);
            yilann.drawsnake(kagit);

            for (int i = 0; i < yilann.Yln.Length ; i++)  // ----->>> YILANIN YİYECEĞİ YEMESİNİ SAĞLADIK
            {
                if (yilann.Yln [i].IntersectsWith(yck.foodRec))// BU KISMI KOPYALAYIP TİMERIN İÇİNE
                {                                            // KOPYALAYACAĞIM.
                    yck.yiyecekkonumu(ranfoood);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData == Keys.Down && yukari == false)
            {
                asagi = true;
                yukari = false;
                sag = false;
                sol = false;
            }
            if (e.KeyData == Keys.Up && asagi == false)
            {
                asagi = false;
                yukari = true;
                sag = false;
                sol = false;
            }
            if (e.KeyData == Keys.Right && sol == false)
            {
                asagi = false;
                yukari = false;
                sag = true;
                sol = false;
            }
            if (e.KeyData == Keys.Left && sag == false)
            {
                asagi = false;
                yukari = false;
                sag = false;
                sol = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            YilanSkoruLabel.Text = Convert.ToString(skor);


            if (asagi) { yilann.asagiOynat(); }
            if (yukari) { yilann.YukariOynat(); }
            if (sag) { yilann.sagaOynat(); }
            if (sol) { yilann.SolaOynat(); }
           
            for (int i = 0; i < yilann.Yln.Length; i++)  
            {
                if (yilann.Yln[i].IntersectsWith(yck.foodRec))
                {
                    skor += 10;
                    yilann.buyuYilan();                       
                    yck.yiyecekkonumu(ranfoood);
                }
            }
            Carptiginda();
            this.Invalidate();
            

        }

        public void Carptiginda()
        {
            for (int i = 0; i < yilann.Yln.Length; i++)
			{
                if (yilann.Yln[0].IntersectsWith(yilann.Yln[i]))
                {
                //    timer1.Enabled = false;
                //    MessageBox.Show("YILAN ÖLDÜ");
                }
			}

            if (yilann.Yln[0].X < 0 || yilann.Yln[0].X > 290) // 290 formdaki bölgesini belirliyor. sağda ve solda gidebileceği yer.
            {
                timer1.Enabled = false;
                MessageBox.Show("YILAN ÖLDÜ! * SKORUNUZ:" +" " + skor);
                
            }

            if (yilann.Yln[0].Y < 0 || yilann.Yln[0].Y > 290) // aşağıdan ve yukarıdan 290 m gidebilir eğer fazlasına gitmeye çalışırsa
                                                              // yılan ölür...      
            {
                timer1.Enabled = false;
                MessageBox.Show("YILAN ÖLDÜ! * SKORUNUZ:" + " " + skor);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      

      
    }
}
