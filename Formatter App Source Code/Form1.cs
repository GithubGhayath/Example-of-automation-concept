using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.Windows.Automation;


namespace Formatter
{
    public partial class Form1 : Form
    {
        string FilePath = string.Empty;
      
        public Form1()
        {
            InitializeComponent();
           
        }

        private void _LoadDataToScreen()
        {
            using (var stream = File.Open(FilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                   

                    // Loop through all rows from the current position
                    while (reader.Read())
                    {
                        // Read values from each cell in the current row
                        string Name = reader.GetValue(0)?.ToString() ?? string.Empty;
                        string MotherName = reader.GetValue(1)?.ToString() ?? string.Empty;
                        string Nationality = reader.GetValue(2)?.ToString() ?? string.Empty;
                        string IDNumber = reader.GetValue(3)?.ToString() ?? string.Empty;
                        string Reason = reader.GetValue(4)?.ToString() ?? string.Empty;

                        // Create a formatted string for the User Control
                        string NewFormat = string.Join("\t", Reason, MotherName, Nationality, Name, IDNumber);

                        // Create an instance of the User Control
                        ControlForCopy myControl = new ControlForCopy(NewFormat);

                        // Set the width of the control to match the panel's width
                        myControl.Width = pnlContainer.Width;

                        // Set the location of the control
                        int numberOfControls = pnlContainer.Controls.Count;
                        int yPos = numberOfControls * myControl.Height; // Stack them vertically

                        myControl.Location = new Point(0, yPos);
                        myControl.Dock = DockStyle.Top;

                        // Add the User Control to the Panel
                        pnlContainer.Controls.Add(myControl);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            pnlContainer.Controls.Clear();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the filter to only allow Excel files
                openFileDialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx";
                openFileDialog.Title = "Select an Excel File";

                // Show the dialog and check if the user clicked OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    FilePath = openFileDialog.FileName;


                    _LoadDataToScreen();

                }
            }
        }

      
    }
}
