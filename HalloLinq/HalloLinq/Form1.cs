using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloLinq
{
    public partial class Form1 : Form
    {
        List<Person> personen = new List<Person>();
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 1000; i++)
            {
                personen.Add(new Person()
                {
                    Id = i,
                    Name = $"Fred #{i:0000}",
                    GebDatum = DateTime.Now.AddYears(-50).AddDays(i * 17)
                }
                );
            }
            int cnt = 1345;

            string strinInterpolation = $"Zahl {757}kg {cnt:C}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = personen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from p in personen
                        where p.GebDatum.DayOfWeek == DayOfWeek.Sunday ||
                              p.GebDatum.DayOfWeek == DayOfWeek.Saturday
                        select p;

            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // casting + Typprüfung
            if (e.Value is DateTime) { 
                DateTime dttt = (DateTime)e.Value; // Hartes Casting alles in den ZielTyp
            }

            
            // boxing /trycast)
            DateTime? dtt = e.Value as DateTime?;
            if (dtt !=null)
            {

            }

            //pattern matching
            if (e.Value is DateTime dt)
            {
                e.Value = dt.ToLongDateString();
            }
        }
    }
}
