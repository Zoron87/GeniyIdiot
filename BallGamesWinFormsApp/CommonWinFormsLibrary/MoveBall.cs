using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace CommonWinFormsLibrary
{
    public class MoveBall : RandomSizeAndPointBall
    {
        private Form form;
        Timer timer = new Timer();

        public MoveBall(Form form) : base(form)
        {
            this.form = form;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public bool IsMoveable()
        {
            return timer.Enabled;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Move();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
