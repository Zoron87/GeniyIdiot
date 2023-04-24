using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWinFormsLibrary
{
    public class MoveBall : RandomSizeAndPointBall
    {
        private Form form;

        public MoveBall(Form form) : base(form)
        {
            this.form = form;
        }
    }
}
