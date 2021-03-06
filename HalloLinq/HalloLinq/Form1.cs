﻿using System;
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

            // Event Handler registrieren
            button1.MouseMove += Button1_MouseMove;
            button1.Click += ButtonClickHandler;
            //button1.Click += ButtonClickHandler;
            //button1.Click += ButtonClickHandler;
            //button1.Click += ButtonClickHandler;


            button2.Click += (s, e) => MessageBox.Show("Test");

            meinButton1.TrippleClick += MeinButton1_TrippleClick;
        }

        private void MeinButton1_TrippleClick(object sender, int clickCount)
        {
            MessageBox.Show($"TrippleClick:{clickCount}");
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = $"{e.X}x{e.Y}";
        }
        private void ButtonClickHandler(object sender, EventArgs e)
        {
            MessageBox.Show("Click Event");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // EventHandler deregistrieren
            button1.MouseMove -= Button1_MouseMove;

            dataGridView1.DataSource = personen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // linq
            var query = from p in personen
                        where p.GebDatum.DayOfWeek == DayOfWeek.Sunday ||
                              p.GebDatum.DayOfWeek == DayOfWeek.Saturday
                        orderby p.GebDatum.Month descending,
                                p.GebDatum.Year
                        select p;
            //select new { DerName = p.Name.ToUpper(), Jahr = p.GebDatum.Year };

            dataGridView1.DataSource = query.ToList();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = personen.Where(p => p.GebDatum.DayOfWeek == DayOfWeek.Sunday ||
                                                           p.GebDatum.DayOfWeek == DayOfWeek.Saturday)
                                               .OrderByDescending(x => x.GebDatum.Month)
                                               .ThenBy(x => x.GebDatum.Year)
                                               .ToList();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // casting + Typprüfung = Alt und Doof
            if (e.Value is DateTime)
            {
                DateTime dttt = (DateTime)e.Value; // Hartes Casting alles in den ZielTyp
            }


            // boxing /trycast) = Alt und Doof
            DateTime? dtt = e.Value as DateTime?;
            if (dtt != null)
            {

            }

            //pattern matching = Neu und Cool
            if (e.Value is DateTime dt)
            {
                //e.Value = dt.ToLongDateString();
                e.Value = dt.ToString("dddd, dd.MM.yyyy");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = personen.FirstOrDefault(x => x.GebDatum.Month == 5);
            //var result = personen.Single(x => x.GebDatum.Month == 5); // nur wenn es nur "ein" Ergebnis gibt funktioniert dies
            if (result != null)
                MessageBox.Show(result.Name);


        }
        private void button4_Click(object sender, EventArgs e)
        {

            // Anzahl Geburtstage im Mai
            MessageBox.Show(personen.Count(x => x.GebDatum.Month == 5).ToString());
        }
    }
}
