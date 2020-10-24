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
        public int TiempoTranscurrido { get; set; }
        public System.Timers.Timer TimerActivo { get; set; }

        public AyudanteTimer(int pTiempoLimite)
        {
            int INTERVALO_DE_TIEMPO = 1000;
            TiempoLimite = pTiempoLimite;  
            TimerActivo = new System.Timers.Timer(INTERVALO_DE_TIEMPO);
            TimerActivo.Elapsed += OnTimedEvent;
            TimerActivo.Start();
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            TiempoTranscurrido++;
            if ((TiempoLimite - TiempoTranscurrido) <= 0)
            {
                TimerActivo.Stop();
                var formActiva = Application.OpenForms.Cast<SesionForm>().Last();
                formActiva.FinTiempoLimite();
            }
        }
    }
}
