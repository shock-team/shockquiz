using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace ShockQuiz.Forms
{
    class AyudanteTimer
    {
        int limitTime;
        BackgroundWorker backgroundWorker;

        public AyudanteTimer(int pTiempoLimite)
        {
            limitTime = pTiempoLimite;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.RunWorkerAsync();
        }
    }
}
