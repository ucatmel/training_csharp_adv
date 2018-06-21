using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloLinq
{
    public class MeinButton : Button
    {
        //[Browsable(true)]
        public event EventHandler TrippleClick;


        int clickCount = 0;
        protected override void OnClick(EventArgs e)
        {
            //clickCount = clickCount + 1;
            //clickCount += 1;
            clickCount++;

            if (clickCount % 3 == 0)
            {
                //todo: fire  TrippleClick
                if (TrippleClick != null)
                {
                    TrippleClick.Invoke(this, new EventArgs());
                }
            }
            else
                base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(Brushes.Lime, ClientRectangle);
            pevent.Graphics.FillEllipse(Brushes.LightYellow, ClientRectangle);
        }



    }
}
