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
        Excel.Application xlApp;
        Excel.Workbook xlWB;
        Excel.Worksheet xlSheet;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            Patients = context.Patients.ToList();
            dataGridView1.DataSource = Patients;
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;

                CreateTable();

                xlApp.Visible = true;
                xlApp.UserControl = true;
            }
            catch (Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }
        private void CreateTable()
        {
            string[] headers = new string[] {
                "Azonosító",
                "Beteg neve",
                "Neme",
                "Életkora",
                "Fertőzött-e",
                "Kórterem",
                "Életben van", };

            for (int i = 0; i < headers.Length; i++)
            {
                xlSheet.Cells[1, 1 + i] = headers[i];
            }
            object[,] values = new object[Patients.Count, headers.Length];
            int counter = 0;
            foreach (Patient p in Patients)
            {
                values[counter, 0] = p.Code;
                values[counter, 1] = p.Name;
                values[counter, 2] = p.Gender;
                values[counter, 3] = p.Age;
                values[counter, 4] = p.Covid;
                values[counter, 5] = p.Ward;
                values[counter, 6] = p.IsAlive;
                counter++;
            }
            xlSheet.get_Range(
            GetCell(2, 1),
            GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
            Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
            headerRange.Font.Bold = true;
            headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            headerRange.EntireColumn.AutoFit();
            headerRange.RowHeight = 30;
            headerRange.Interior.Color = Color.Fuchsia;
            headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
        }
        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
        private void Frissites()
        {
            var frissites = from x in context.Patients
                            select x;
            dataGridView1.DataSource = frissites.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dynamic aktualis = dataGridView1.SelectedRows;
            int rid = aktualis.ID;
            var torlendo = (from x in context.Patients
                            where x.ID == rid
                            select x).FirstOrDefault();
            context.Patients.Remove(torlendo);
            context.SaveChanges();
            Frissites();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HalottakForm hf = new HalottakForm();
            hf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateExcel();
        }
    }
}

