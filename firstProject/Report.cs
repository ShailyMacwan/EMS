using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Drawing.Text;
using System.Collections.ObjectModel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using OfficeOpenXml;
using OfficeOpenXml.Style;



namespace firstProject
{
    public partial class Report : Form
    {

       
        public Report()
        {
            InitializeComponent();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime StartDate = startDate.Value.ToUniversalTime();
            DateTime EndDate = endDate.Value.ToUniversalTime();

            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("REINHARDTdisplay");
            var collection = database.GetCollection<BsonDocument>("DATA");

            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Gte("Timestamp", StartDate),
                Builders<BsonDocument>.Filter.Lte("Timestamp", EndDate));


            var endResult = collection.Find(filter).ToList();

            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            //worksheet.Rows[1] = " EMPLOYEE MANAGEMENT SYSTEM ";

            //ExcelPackage excel = new ExcelPackage();
            //var worksheet = excel.Workbook.Worksheets.Add("Report");

            worksheet.Cells[1, 1] = "Your Report Title";
            Excel.Range titleRange = worksheet.get_Range("A1", "C1"); // Adjust range to span across the columns needed for the title
            titleRange.Merge();
            titleRange.Font.Size = 16;
            titleRange.Font.Bold = true;
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            titleRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightBlue); // Optional background color



            worksheet.Cells["A6"].Value = "M1 ACTUAL TEMP";
            worksheet.Cells["B6"].Value = "M1 ARM 1 RECIPE";
            worksheet.Cells["C6"].Value = "M1 ARM 1 SHOTS";
            worksheet.Cells["D6"].Value = "M1 ARM 2 RECIPE";
            worksheet.Cells["E6"].Value = "M1 ARM 2 SHOTS";
            worksheet.Cells["F6"].Value = "M1 ARM 3 RECIPE";
            worksheet.Cells["G6"].Value = "M1 ARM 3 SHOTS";
            worksheet.Cells["H6"].Value = "M1 ARM 4 RECIPE";
            worksheet.Cells["I6"].Value = "M1 ARM 4 SHOTS";
            worksheet.Cells["J6"].Value = "M1 C1 TIME LEFT";
        

            int row = 7;


            foreach (var doc in endResult)
            {
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ACTUAL TEMP").ToInt32();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ARM 1 RECIPE").ToString();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ARM 1 SHOTS").ToInt32();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ARM 2 RECIPE").ToString();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ARM 2 SHOTS").ToInt32();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ARM 3 RECIPE").ToString();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ARM 3 SHOTS").ToInt32();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ARM 4 RECIPE").ToString();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 ARM 4 SHOTS").ToInt32();
                worksheet.Cells["A6"].Value = doc.GetValue("M1 C1 TIME LEFT").ToString();

                row++;
            }

            string filepath = @"D:\.Net\MyReport\Report.xlsm";




            MessageBox.Show("Your report is generated in MyReport folder");

        }
    }

}



