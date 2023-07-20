using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appraisal_System.Common
{
    public class FormFactory
    {
        private static EmptyForm emptyForm;
        private static UserManagerForm userManagerForm;
        private static BaseManagerForm baseManagerForm;

        private static List<Form> forms = new List<Form>();

        public static Form CreateForm(int index)
        {
            HideAllForms();
            switch (index)
            {
                case 0:
                    if (userManagerForm == null)
                    {
                        userManagerForm = new UserManagerForm();
                        forms.Add(userManagerForm);
                    }
                    return userManagerForm;
                case 1:
                    if (baseManagerForm == null)
                    {
                        baseManagerForm = new BaseManagerForm();
                        forms.Add(baseManagerForm);
                    }
                    return baseManagerForm;
                default:
                    if (emptyForm == null)
                    {
                        emptyForm = new EmptyForm();
                        forms.Add(emptyForm);
                    }
                    return emptyForm;
            }
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
