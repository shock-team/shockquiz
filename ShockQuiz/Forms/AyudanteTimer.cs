using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Timers;
using System.Windows.Forms;

namespace ShockQuiz.Forms
{
    public class AyudanteTimer
    {
        public static int TiempoLimite { get; set; }
        public double TiempoTranscurrido { get; set; }
        public BackgroundWorker bgWorker = new BackgroundWorker();
        private Action OnTimerFinished;
        public Action<int> OnTickTimer;

        public AyudanteTimer(int pTiempoLimite, Action pOnTimeFinishedHandler, Action<int> pOnTickTimer)
        {
            this.OnTimerFinished = pOnTimeFinishedHandler;
            this.OnTickTimer = pOnTickTimer;

            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);

            TiempoLimite = pTiempoLimite;
            bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = TiempoLimite; i > 0; i--)
            {
                if (bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                Thread.Sleep(1000);
                bgWorker.ReportProgress(i);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TiempoTranscurrido += 1;
            OnTickTimer?.Invoke(e.ProgressPercentage);
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                bgWorker.CancelAsync();
                OnTimerFinished?.Invoke();
            }
        }
    }
}
