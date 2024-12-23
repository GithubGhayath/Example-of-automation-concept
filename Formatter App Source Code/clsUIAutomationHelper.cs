using System;
using System.Windows.Automation;

namespace Formatter
{
    public static class clsUIAutomationHelper
    {


        public static AutomationElement GetApplicationWindow(string windowTitle)
        {
            // Find the window with the specified title
            return AutomationElement.RootElement.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.NameProperty, windowTitle));
        }
    }

}
