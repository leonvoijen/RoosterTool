using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace VollopRooster.Repository
{
    public class FileCreator
    {
        public FileCreator(Schedule schedule)
        {
            var shifts = schedule.filledShifts;

            // Creating an instance 
            // of ExcelPackage 
            ExcelPackage excel = new ExcelPackage();

            // name of the sheet 
            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

            // setting the properties 
            // of the work sheet  
            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;


            // Setting the properties 
            // of the first row 
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;

            // Header of the Excel sheet 
            workSheet.Cells[1, 1].Value = "ShiftDate";
            workSheet.Cells[1, 2].Value = "Employee";
            workSheet.Cells[1, 3].Value = "StartTime";
            workSheet.Cells[1, 4].Value = "EndTime";


            // Inserting the article data into excel 
            // sheet by using the for each loop 
            // As we have values to the first row  
            // we will start with second row 
            int recordIndex = 2;

            foreach (var shift in shifts)
            {
                workSheet.Cells[recordIndex, 1].Value = shift.Date.ToString();

                foreach (var employee in shift.Employees)
                {
                    workSheet.Cells[recordIndex, 2].Value = employee.Name;
                    workSheet.Cells[recordIndex, 3].Value = shift.StartTime.ToString();
                    workSheet.Cells[recordIndex, 4].Value = shift.EndTime.ToString();
                    recordIndex++;
                }
                recordIndex++;
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();

            string p_strPath = "C:/Users/leonv/OneDrive/Documenten/HBO_ICT  leerjaar 1(2)/Semester 2/Live performance/Ontwerpdocumenten/Test.xlsx";

            if (File.Exists(p_strPath))
                File.Delete(p_strPath);

            // Create excel file on physical disk  
            FileStream objFileStrm = File.Create(p_strPath);
            objFileStrm.Close();

            // Write content to excel file  
            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            Console.ReadKey();
        }
    }
}
