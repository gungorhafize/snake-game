using System;
using System.Collections.Generic;
using System.Drawing; // Bunu biz ekliyoruz
using System.Linq;
using System.Text;

namespace Yilan_Oyunu
{
   public class Yilan
    {
      private Rectangle[] yln ; //BURASI DAHA ÖNCEDEN PUBLİC TANIMLADIK FAKAT PRİVATE HALE GETİRİYORUZ.
       private SolidBrush firca;
       public int x, y, genislik, yukseklik;

       public Rectangle[] Yln
       {
           get { return yln; } //property özelliğinden yararlandım.
                                //burdan sonra aşağıya inip yılanın büyümesi için metod yazdım.
       }

       public Yilan()
       {
           yln = new Rectangle[3];
           firca = new SolidBrush(Color.LawnGreen);
           x = 20;
           y = 0;
           genislik = 10;
           yukseklik = 10;

           for (int i = 0; i < yln.Length; i++)
           {
               yln[i] = new Rectangle(x, y, genislik, yukseklik);
               x -= 10;
           }
       }

       public void drawsnake(Graphics kagit)
       {
           foreach (var rec in yln)
           {
               kagit.FillRectangle(firca, rec);

           }
       }

       public void drawsnake()
       {
           for (int i = yln.Length - 1; i > 0; i -- )
           {
               yln[i] = yln[i - 1];
           }
       }

       public void asagiOynat()
       {
           drawsnake();
           yln[0].Y += 10;
       }

       public void YukariOynat()
       {
           drawsnake();
           yln[0].Y -= 10;
       }
       public void sagaOynat()
       {
           drawsnake();
           yln[0].X += 10;
       }
       public void SolaOynat()
       {
           drawsnake();
           yln[0].X -= 10;
       }

       public void buyuYilan()
       {
           List<Rectangle> rec = yln.ToList(); // bu kısım dışardan bulundu :)
           rec.Add(new Rectangle(yln[yln.Length - 1].X, yln[yln.Length - 1].Y, genislik, yukseklik));
           yln = rec.ToArray();
       }
    }
}
