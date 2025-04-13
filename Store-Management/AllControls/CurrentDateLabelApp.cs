using System;
using System.Windows.Forms;


namespace AllControls
{
    public class CurrentDateLabelApp : Label
    {
        public CurrentDateLabelApp()
        {
            this.Text = "Current Time:";
            this.Location = new System.Drawing.Point(10, 10);
            this.AutoSize = true;

            Timer timer = new Timer();
            timer.Interval = 1000; // Cập nhật thời gian mỗi giây
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() +
                            "/" + DateTime.Now.Year.ToString();
        }

        public static void Main()
        {
            Application.Run(new Form() { Controls = { new CurrentDateLabelApp() } });
        }
    }
}
