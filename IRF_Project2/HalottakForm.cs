using IRF_Project2.Abstractions;
using IRF_Project2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project2
{
    public partial class HalottakForm : Form
    {
        PatientEntities context = new PatientEntities();
        List<Patient> Patients;
        private List<Rajz> _rajzok = new List<Rajz>();
        private Rajz _nextRajz;
        private CandleFactory _factory;
        public CandleFactory Factory
        {
            get { return _factory; }
            set { _factory = value; DisplayNext(); }
        }
        public HalottakForm()
        {
            InitializeComponent();
            LoadData();
            Factory = new CandleFactory();
        }
        private void LoadData()
        {
            Patients = context.Patients.ToList();
            listBox1.DataSource =
                (
                    from p in context.Patients
                    where p.IsAlive == false
                    select p.Name
                ).ToList();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var candle = Factory.CreateNew();
            _rajzok.Add(candle);
            candle.Left = -candle.Width;
            panel1.Controls.Add(candle);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var candle in _rajzok)
            {
                candle.MoveRajz();
                if (candle.Left > maxPosition)
                    maxPosition = candle.Left;
            }

            if (maxPosition > 1000)
            {
                var Gyertya = _rajzok[0];
                panel1.Controls.Remove(Gyertya);
                _rajzok.Remove(Gyertya);
            }
        }
        private void DisplayNext()
        {
            if (_nextRajz != null)
                Controls.Remove(_nextRajz);
            _nextRajz = Factory.CreateNew();
            _nextRajz.Top = label1.Top + label1.Height + 20;
            _nextRajz.Left = label1.Left;
            Controls.Add(_nextRajz);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }

            else
            {
                MessageBox.Show("Válasszon ki valamit!");
            } */

        }
    }
}
