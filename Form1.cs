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

        AutoResetEvent lucyPieWaitHandle = new AutoResetEvent(false);
        AutoResetEvent lucyIngrWaitHandle = new AutoResetEvent(false);

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
            lucyPieWaitHandle.Set();
            listBoxOutLog.Items.Add("added a pie");
        }

        private void LucyRobotWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true) {
                updateValues();
                lucyPieWaitHandle.WaitOne();
                Pie pie;
                lock (pieStackLock) {
                    pie = pieStack.Peek();
                }
                if (!pie.IsDone) {
                    bool isWaiting = false;
                    addTextToListBox("adding ingrediants..");
                    lock (fillingLock) {
                        if (filling <= 0)
                        {
                            filling = 0;
                            conveyerTimer.Stop();
                            isWaiting = true;
                        }
                        else
                        {
                            filling -= 250;
                            System.Threading.Thread.Sleep(100);
                            addTextToListBox("added filling");
                        }
                    }
                    if (isWaiting) {
                        lucyIngrWaitHandle.WaitOne();
                        isWaiting = false;
                    }
                    lock (flavorLock)
                    {   
                        if (flavor <= 0) {
                            flavor = 0;
                            conveyerTimer.Stop();
                            isWaiting = true;
                        } else {
                            flavor -= 10;
                            System.Threading.Thread.Sleep(100);
                            addTextToListBox("added flavor");
                        }
                    }
                    if (isWaiting)
                    {
                        lucyIngrWaitHandle.WaitOne();
                        isWaiting = false;
                    }
                    lock (toppingLock)
                    {
                        if (topping <= 0) {
                            topping = 0;
                            conveyerTimer.Stop();
                            isWaiting = true;
                        } else {
                            topping -= 100;
                            System.Threading.Thread.Sleep(100);
                            addTextToListBox("added toping");
                        }
                    }
                    if (isWaiting)
                    {
                        lucyIngrWaitHandle.WaitOne();
                        isWaiting = false;
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
            while (true) {
                System.Threading.Thread.Sleep(10000);
                filling = 2000;
                conveyerTimer.Start();
                lucyIngrWaitHandle.Set();
            }
        }
    }
}
