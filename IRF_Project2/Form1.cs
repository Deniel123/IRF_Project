using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace IRF_Project2
{
    public partial class Form1 : Form
    {
        PatientEntities context = new PatientEntities();
        List<Patient> Patients;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            Patients = context.Patients.ToList();
        }
    }
}
