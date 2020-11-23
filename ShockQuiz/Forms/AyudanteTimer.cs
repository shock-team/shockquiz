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
        public System.Timers.Timer TimerActivo { get; set; }

        public BackgroundWorker bgWorker = new BackgroundWorker();

        public AyudanteTimer(int pTiempoLimite)
        {
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);

            TiempoLimite = pTiempoLimite;
            bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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

        private void bgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            TiempoTranscurrido += 1;
        }

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                List<Form> formList = new List<Form>();
                foreach (Form item in Application.OpenForms)
                {
                    formList.Add(item);
                }

                foreach (Form form in formList)
                {
                    if (form.GetType() == typeof(SesionForm))
                    {
                        bgWorker.CancelAsync();

                        ((SesionForm)form).FinTiempoLimite();
                        break;
                    }
                }
            }
        }
    }
}
