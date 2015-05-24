using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PieFactory
{
    public partial class Form1 : Form
    {

        private int filling = 2000; // in grams
        private int flavor = 2000;
        private int topping = 2000;

        private Object fillingLock = new Object();
        private Object flavorLock = new Object();
        private Object toppingLock = new Object();

        private Stack<Pie> pieStack = new Stack<Pie>();
        private Object pieStackLock = new Object();

        AutoResetEvent lucyWaitHandle = new AutoResetEvent(false);
        AutoResetEvent conveyerWaitHandle = new AutoResetEvent(false);

        public Form1()
        {
            InitializeComponent();
            LucyRobotWorker.RunWorkerAsync();
            JoeRobotWorker.RunWorkerAsync();
        }

        private void conveyerTimer_Tick(object sender, EventArgs e)
        {
            updateValues();
            lock (pieStackLock)
            {
                pieStack.Push(new Pie());
            }
            lucyWaitHandle.Set();
            listBoxOutLog.Items.Add("added a pie");
        }

        private void LucyRobotWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true) {
                updateValues();
                lucyWaitHandle.WaitOne();
                Pie pie;
                lock (pieStackLock) {
                    pie = pieStack.Peek();
                }
                if (!pie.IsDone) {
                    addTextToListBox("adding ingrediants..");
                    lock (fillingLock) {
                        filling -= 250;
                    }
                    lock (flavorLock)
                    {
                        flavor -= 10;
                    }
                    lock (toppingLock)
                    {
                        topping -= 100;
                    }

                    pie.IsDone = true;
                }
            }
        }

        private void addTextToListBox(String text)
        {
            BeginInvoke((Action)(() => { listBoxOutLog.Items.Add(text); }));
        }

        private void updateValues()
        {
            BeginInvoke((Action)(() =>
            {
                lock(fillingLock) {
                    labelFillingVal.Text = filling.ToString();
                }
                lock (toppingLock) {
                    labelToppingVal.Text = topping.ToString();
                }
                lock (flavorLock) {
                    labelFlavorVal.Text = flavor.ToString();
                }
            }));
        }

        private void JoeRobotWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //while (true) {

            //}
        }
    }
}
