using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloLinq
{
    public class MeinButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(Brushes.Lime, ClientRectangle);
            pevent.Graphics.FillEllipse(Brushes.LightYellow, ClientRectangle);
        }

    }
}
