using Formatter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Configuration;

namespace Formatter
{
    public partial class ControlForCopy : UserControl
    {
        private string _Text = string.Empty;


        private string _AppName = string.Empty;
        private string _TxtNameFieldAutomationId = string.Empty;
        private string _TxtIDNumberieldAutomationId = string.Empty;
        private string _TxtMotherNameFieldAutomationId = string.Empty;
        private string _TxtNationalityFieldAutomationId = string.Empty;
        private string _TxtReasonFieldAutomationId = string.Empty;
       

        public ControlForCopy(string Text)
        {
            InitializeComponent();
            _FillAutomationsID();
            btnCopy.Image = Resources.copy_two_paper_sheets_interface_symbol;
            this._Text = Text;
            
            PutText();
        }


        //Put Text in ui
        private void PutText()
        {
            lblTextForCopy.Text = _Text;
        }
        private void _FillAutomationsID()
        {
            _TxtNameFieldAutomationId = ConfigurationManager.AppSettings["NameFieldAutomation"];
            _TxtIDNumberieldAutomationId = ConfigurationManager.AppSettings["IDNumberFieldAutomation"];
            _TxtMotherNameFieldAutomationId = ConfigurationManager.AppSettings["MotherNameFieldAutomation"];
            _TxtNationalityFieldAutomationId = ConfigurationManager.AppSettings["NationalityFieldAutomation"];
            _TxtReasonFieldAutomationId = ConfigurationManager.AppSettings["ReasonFieldAutomation"];
            _AppName = ConfigurationManager.AppSettings["WindowTitle"];
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_Text);

            AutomationElement appWindow = clsUIAutomationHelper.GetApplicationWindow(_AppName);
            List<AutomationElement> Elements = FindAllElements(appWindow);
            string[] Arr = _Text.Split('\t');
           
            foreach (AutomationElement element in Elements)
            {
              
                //Here we will put the automationID
                if (element.Current.AutomationId == _TxtNameFieldAutomationId)
                    //Here we will but value for set in spicefic Field
                    SetTextInField(element.Current.AutomationId, Arr[3], appWindow);

                if (element.Current.AutomationId == _TxtIDNumberieldAutomationId)
                    SetTextInField(element.Current.AutomationId, Arr[4], appWindow);

                if (element.Current.AutomationId == _TxtMotherNameFieldAutomationId)
                    SetTextInField(element.Current.AutomationId, Arr[1], appWindow);

                if (element.Current.AutomationId == _TxtNationalityFieldAutomationId)
                    SetTextInField(element.Current.AutomationId, Arr[2], appWindow);

                if (element.Current.AutomationId == _TxtReasonFieldAutomationId)
                    SetTextInField(element.Current.AutomationId, Arr[0], appWindow);
            }

            if (appWindow == null)
            {
                MessageBox.Show("Ensure name of target application","App not found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }



            btnCopy.Image = Resources.check__1_;
        }

        static List<AutomationElement> FindAllElements(AutomationElement parentElement)
        {
            AutomationElementCollection children = parentElement.FindAll(TreeScope.Children, Condition.TrueCondition);
            List<AutomationElement> Elements = new List<AutomationElement>();



            foreach (AutomationElement element in children)
            {

                Elements.Add(element);
                //string automationId = element.Current.AutomationId;
                //string name = element.Current.Name;
                //string controlType = element.Current.ControlType.ProgrammaticName;

                //Console.WriteLine($"AutomationId: {automationId}, Name: {name}, ControlType: {controlType}");

                // Recursively find child elements
               // FindAllElements(element);
            }

            return Elements;
        }

        public static void SetTextInField(string automationId, string value, AutomationElement parentElement)
        {
            // Find the text box within the parent element using the AutomationId
            AutomationElement element = parentElement.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));

            if (element != null && element.Current.IsEnabled)
            {
                // Get the ValuePattern and set the value
                ValuePattern valuePattern = element.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                if (valuePattern != null)
                {
                    valuePattern.SetValue(value);
                }
                else
                {
                   MessageBox.Show("Element does not support ValuePattern.");
                }
            }
            else
            {
                MessageBox.Show("Element not found or not enabled.");
            }
        }
    }
}
