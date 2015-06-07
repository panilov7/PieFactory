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
        private int pieNum = 0;
        private bool shouldStop = false;

        private System.Threading.Timer conveyerTimer; 

        private Object fillingLock = new Object();
        private Object flavorLock = new Object();
        private Object toppingLock = new Object();

        private Stack<Pie> pieStack = new Stack<Pie>();
        private Object pieStackLock = new Object();

        private AutoResetEvent lucyPieWaitHandle = new AutoResetEvent(false);
        private AutoResetEvent lucyIngrWaitHandle = new AutoResetEvent(false);
        private ManualResetEvent conveyerTimerStopHandle = new ManualResetEvent(false);

        public Form1()
        {
            InitializeComponent();
        }

        private void conveyerTimer_Tick(object StateObj)
        {
            conveyerTimerStopHandle.WaitOne();
            updateValues();
            Pie pie = new Pie(pieNum++);
            lock (pieStackLock)
            {
                pieStack.Push(pie);
            }
            lucyPieWaitHandle.Set();
            addTextToListBox("added a pie: " + pie.num);
        }

        private void LucyRobotWorker_DoWork()
        {
            while (true) {
                updateValues();
                lucyPieWaitHandle.WaitOne();
                if (shouldStop)
                {
                    break;
                }
                else {
                    Pie pie;
                    lock (pieStackLock) {
                        pie = pieStack.Peek();
                    }
                    if (!pie.isDone)
                    {
                        bool isWaiting = false;
                        addTextToListBox("adding ingrediants to pie: " + pie.num);
                        lock (fillingLock)
                        {
                            if (filling <= 0)
                            {
                                filling = 0;
                                conveyerTimerStopHandle.Reset();
                                isWaiting = true;
                            }
                            else
                            {
                                filling -= 250;
                                System.Threading.Thread.Sleep(10);
                                addTextToListBox("filling added to pie: " + pie.num);
                            }
                        }
                        if (isWaiting)
                        {
                            lucyIngrWaitHandle.WaitOne();
                            isWaiting = false;
                        }
                        lock (flavorLock)
                        {
                            if (flavor <= 0)
                            {
                                flavor = 0;
                                conveyerTimerStopHandle.Reset();
                                isWaiting = true;
                            }
                            else
                            {
                                flavor -= 10;
                                System.Threading.Thread.Sleep(10);
                                addTextToListBox("flavor to pie: " + pie.num );
                            }
                        }
                        if (isWaiting)
                        {
                            lucyIngrWaitHandle.WaitOne();
                            isWaiting = false;
                        }
                        lock (toppingLock)
                        {
                            if (topping <= 0)
                            {
                                topping = 0;
                                conveyerTimerStopHandle.Reset();
                                isWaiting = true;
                            }
                            else
                            {
                                topping -= 100;
                                System.Threading.Thread.Sleep(10);
                                addTextToListBox("toping added to pie: " + pie.num);
                            }
                        }
                        if (isWaiting)
                        {
                            lucyIngrWaitHandle.WaitOne();
                            isWaiting = false;
                        }
                        pie.isDone = true;
                        addTextToListBox("pie: " + pie.num + " is done");
                    }
                }
            }
            addTextToListBox("Lucy terminated");
        }

        private void JoeRobotWorker_DoWork()
        {
            while (true)
            {
                if (shouldStop)
                {
                    break;
                }
                lock (fillingLock)
                {
                    if (filling <= 100)
                    {
                        addTextToListBox("adding filling...");
                        while (filling <= 1900)
                        {
                            filling += 100;
                            System.Threading.Thread.Sleep(10);
                        }
                        lucyIngrWaitHandle.Set();
                    }
                }
                lock (flavorLock)
                {
                    if (flavor <= 0 && flavor <= 1900)
                    {
                        while (flavor <= 1900)
                        {
                            flavor += 100;
                            System.Threading.Thread.Sleep(10);
                        }
                        lucyIngrWaitHandle.Set();
                    }
                }
                lock (toppingLock)
                {
                    if (topping <= 0 && topping <= 1900)
                    {
                        while (topping <= 1900)
                        {
                            topping += 100;
                            System.Threading.Thread.Sleep(10);
                        }
                        lucyIngrWaitHandle.Set();
                    }
                }
            }
            addTextToListBox("Joe terminated");
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            conveyerTimer = new System.Threading.Timer(conveyerTimer_Tick, null, 50, 50);
            shouldStop = false;
            Thread lucy = new Thread(LucyRobotWorker_DoWork);
            Thread joe = new Thread(JoeRobotWorker_DoWork);
            lucy.Start();
            joe.Start();
            conveyerTimerStopHandle.Set();
            bStart.Enabled = false;
            bStop.Enabled = true;
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            conveyerTimer.Dispose();
            shouldStop = true;
            lucyPieWaitHandle.Set();
            bStop.Enabled = false;
            bStart.Enabled = true;
            conveyerTimerStopHandle.Reset();
        }

        private void addTextToListBox(String text)
        {
            Invoke((Action)(() => { listBoxOutLog.Items.Add(text);
                                         listBoxOutLog.SelectedIndex = listBoxOutLog.Items.Count - 1;
                                    }));
        }

        private void updateValues()
        {
            int fillingVal;
            int toppingVal;
            int flavorVal;
            lock(fillingLock) {
                fillingVal = filling;
            }
            lock (toppingLock) {
                toppingVal = topping;
            }
            lock (flavorLock) {
                flavorVal = flavor;
            }
            BeginInvoke((Action)(() =>
            {
                labelFillingVal.Text = fillingVal.ToString();

                labelToppingVal.Text = toppingVal.ToString();

                labelFlavorVal.Text = flavorVal.ToString();
            }));
        }
    }
}
