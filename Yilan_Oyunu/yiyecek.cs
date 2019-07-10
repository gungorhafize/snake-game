using System;
using System.Drawing; // eklemek zorundayız çizmesi için
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yilan_Oyunu
{
  public class yiyecek
    {
      public yiyecek(Random ranfood)
      {
          x = ranfood.Next(0, 29) * 10;
          y = ranfood.Next(0, 29) * 10;
          en = 10;
          boy = 10;
          brush = new SolidBrush(Color.Red); //yiyeceğin rengi belirlendi
          foodRec = new Rectangle(x, y, en, boy); 
      }
      private int x, y, en, boy; //yiyeceğin oluşturulması için gereken değişkenler.
      public SolidBrush brush;
      public Rectangle foodRec;



      public void yiyecekkonumu(Random ranfood) //bu metot sayesinde yiyeceğin yeri randomla rastgele belirlendi.
      {
          x = ranfood.Next(0,29) * 10;
          y = ranfood.Next(0,29) * 10;
      }

      public void yiyecekolusumu(Graphics gp )
      {
          foodRec.X = x;
          foodRec.Y = y;
          gp.FillRectangle(brush,foodRec);
      } 

      //Form1de random kullanıcam
    }
    
}
