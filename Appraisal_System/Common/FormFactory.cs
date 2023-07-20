using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System.Common
{
    public class FormFactory
    {
        private static List<Form> forms = new List<Form>();
        private static List<Type> types;

        static FormFactory()
        {
            Assembly asm = Assembly.LoadFrom("Appraisal_System.exe");
            types = asm.GetTypes().ToList();   
        }

        public static Form CreateForm(string formName)
        {
            HideAllForms();

            formName = formName == "" ? "EmptyForm" : formName;

            Form form = forms.Find(m => m.Name == formName);
            if (form == null)
            {
                Type type = types.Find(m => m.Name == formName);
                form = (Form)Activator.CreateInstance(type);
                forms.Add(form);
            }

            return form;
        }

        public static void HideAllForms()
        {
            foreach (Form form in forms)
            {
                form.Hide();
            }
        }
    }
}
