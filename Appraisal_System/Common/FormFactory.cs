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
        private static UserManagerForm userManagerForm;
        private static BaseManagerForm baseManagerForm;

        public static Form CreateForm(int index)
        {
            HideAllForms();
            switch (index)
            {
                case 0:
                    if (userManagerForm == null)
                    {
                        userManagerForm = new UserManagerForm();
                    }
                    return userManagerForm;
                case 1:
                    if (baseManagerForm == null)
                    {
                        baseManagerForm = new BaseManagerForm();
                    }
                    return baseManagerForm;
                default:
                    return null;
            }
        }

        public static void HideAllForms()
        {
            userManagerForm?.Hide();
            baseManagerForm?.Hide();
        }
    }
}
