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
        public HalottakForm()
        {
            InitializeComponent();
            LoadData();
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
    }
}
