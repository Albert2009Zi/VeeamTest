// Testaufgabe für die Position Developer C#
// Bewerber: Albert Ziatdinov
// Arbeitgeber: Veeam
// Datum: 03.02.2022

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Test_Task_1
{
    public partial class ProgrammMainForm : Form
    {
        private string opdApp;                        // Name der über das Formular gestarteten Anwendung
        private string logFilePathName;               // Pfad- und Dateiname der Log-Datei
        private bool stopFlag = false;                // Wurde Stop gedrückt
        public ProgrammMainForm()
        {
            InitializeComponent();
        }

        // Handler für das Checkbox-Ereignis, das das Schreiben von Informationen in eine Datei steuert.
        // Andere Formularelemente werden nur angezeigt, wenn diese Checkbox aktiviert ist (siehe Aufgabenstellung)
        private void ckbSaveLogFile_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSaveLogFile.Checked)                            // wenn Checkbox ausgewählt ist ...
            {
                elementsVisible(true);                             // zeigen wir die Elemente des Hauptformulars an
                DialogResult drtLogFile = fbdLogFile.ShowDialog(); // Öffnen des Dialogs zur Auswahl des Speicherorts der Log-Datei 

                if (drtLogFile == DialogResult.OK)                 // Pfad ausgewählt und OK gedrückt
                {
                    logFilePathName = fbdLogFile.SelectedPath;     // Variable = Pfad zum Ordner für die Log-Datei
                }
            }
            else                                                   // ansonsten ...
            {
                elementsVisible(false);                            // Elemente des Hauptformulars ausblenden
            }
        }

        // Handler für den Klick auf die Run-Schaltfläche
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (btnRun.Text == "Run")                             // wenn der Button den Status "Run" hat ...
            {
                if (stopFlag == true)                             // wenn Stop bereits gedrückt wurde und die ausgewählte App geschlossen war ...
                {
                    using (Process.Start(opdApp)) { };            // starte die zuvor ausgewählte Anwendung
                }
                elementsVisible(true);                            // Formularelemente anzeigen
                runTimer.Start();                                 // Timer starten
                runTimer.Tick += new EventHandler(runTimer_Tick); // Timer-Handler aufrufen
                btnRun.Text = "Stop";                             // Text der Schaltfläche auf Stop ändern
            }
            else if (btnRun.Text == "Stop")                       // ansonsten, wenn Button den Status "Stop" hat ...
            {
                elementsVisible(false);                           // Formularelemente ausblenden
                runTimer.Stop();                                  // Timer stoppen
                CloseProcess(opdApp);                             // gestartete Anwendung schließen
                stopFlag = true;                                  // Flag auf true setzen, da Button gedrückt wurde
                btnRun.Text = "Run";                              // Text der Schaltfläche auf Run ändern
            }
        }

        // Timer-Handler des Formulars
        private void runTimer_Tick(object sender, EventArgs e)
        {
            runTimer.Interval = (int)nudTimeSet.Value * 1000;                                            // Interval vom NumericUpDown auslesen und mit 1000 multiplizieren
                                                                                                         // da ein Timer-Tick 1 Millisekunde entspricht

            pgbProcessor.Value = (int)(pfcProcessor.NextValue());                                        // CPU-Auslastung vom PerformanceCounter
            lblProcessor.Text = "CPU Load Progress: " + pgbProcessor.Value.ToString() + "%";             // Text für Label mit CPU-Auslastung

            lblMemoryAvailable.Text = "Available RAM: " + ((int)pfcRam.NextValue()).ToString() + "Mb";   // Verfügbarer Arbeitsspeicher

            Process[] stsRunningProcess = Process.GetProcessesByName(opdApp);                             // Array der laufenden Prozesse mit Name opdApp

            // Wenn Prozess läuft, geben wir die Parameter auf dem Formular aus
            if (stsRunningProcess.Length > 0)
            {
                lblProcessName.Text = "Process Name: " + (string)stsRunningProcess[0].ProcessName;
                lblWorkingSet64.Text = "Working Set Status: " + (int)stsRunningProcess[0].WorkingSet64 / 1024 / 1024 + "Mb";
                lblPrivateBytes64.Text = "Private Bytes Status: " + (int)stsRunningProcess[0].PrivateMemorySize64 / 1024 / 1024 + "Mb";
                lblHandleCount.Text = "Handle Count: " + (int)stsRunningProcess[0].HandleCount;
                LogFileWrite((int)pgbProcessor.Value, (int)stsRunningProcess[0].WorkingSet64 / 1024 / 1024, (int)stsRunningProcess[0].PrivateMemorySize64
                / 1024 / 1024, (int)stsRunningProcess[0].HandleCount); // Parameter auch in Datei schreiben
            }
        }

        // Handler für die Auswahl der Anwendung
        private void grbAppRadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbnAppSelected = (sender as RadioButton); // Variable vom Typ RadioButton, die das auslösende Objekt erhält
            string buttonName = (string)rbnAppSelected.Tag;      // Name des Tags des RadioButtons
            if (rbnAppSelected.Checked)                           // wenn RadioButton ausgewählt ist ...
            {
                switch (buttonName)                               // Switch basierend auf Prozessname
                {
                    case "notepad":
                        using (Process.Start("notepad")) { };     // Notepad starten
                        break;
                    case "cmd":
                        using (Process.Start("cmd")) { };         // Kommandozeile starten
                        break;
                    default:                                      // default: nichts tun
                        break;
                }
                btnRun.Enabled = true;                            // Run-Button aktivieren
                CloseAnotherApps(grbApps);                        // andere Anwendungen schließen
            }
        }

        // Funktion schließt die vorherige geöffnete Anwendung, wenn eine neue ausgewählt wird
        private void CloseAnotherApps(GroupBox grbApps)
        {
            foreach (RadioButton rbnSelection in grbApps.Controls)
            {
                if (!rbnSelection.Checked)                         // wenn RadioButton nicht ausgewählt ist ...
                {
                    CloseProcess((string)rbnSelection.Tag);       // Prozess schließen
                }
                else if (rbnSelection.Checked)                     // wenn RadioButton ausgewählt ist ...
                {
                    opdApp = (string)rbnSelection.Tag;            // opdApp = Tag des ausgewählten RadioButtons
                }
            }
        }

        // Funktion schließt einen Prozess nach übergebenem Namen
        private void CloseProcess(string prsName)
        {
            if (opdApp != null)                                           // wenn opdApp nicht null ist
            {
                Process[] AllOpened = Process.GetProcesses();             // alle laufenden Prozesse abrufen

                foreach (Process DetectedProcess in AllOpened)
                {
                    if (DetectedProcess.ProcessName.Contains(prsName))    // wenn Prozessname übereinstimmt ...
                    {
                        DetectedProcess.Kill();                           // Prozess beenden
                    }
                }
            }
        }

        // Funktion schreibt die gesuchten Parameter in die Log-Datei
        private void LogFileWrite(int processorLoad, int workingSet, int privateBytes, int handleCount)
        {
            string path = @logFilePathName;
            FileInfo fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                try
                {
                    using (var strWriter = File.AppendText($"{path}logFile.txt")) // Log-Datei erstellen
                    {
                        // Daten mit Zeitstempel schreiben
                        strWriter.WriteLine($"{DateTime.Now:T}" + "   " + processorLoad + "   " + workingSet + "   " + privateBytes + "   " + handleCount);
                    }
                    // Debug-Ausgabe in Visual Studio
                    Debug.WriteLine($"{DateTime.Now:T}" + "   " + processorLoad + "   " + workingSet + "   " + privateBytes + "   " + handleCount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed: {0}", ex.ToString()); // Fehlermeldung in Konsole
                }
            }

        }

        private void elementsVisible(bool isVisible)
        {
            if (isVisible == true)
            {
                grbApps.Visible = true;      // GroupBox für auswählbare Apps sichtbar
                grbProcessorLoad.Visible = true;      // GroupBox CPU-Auslastung sichtbar
                grbRAMLoad.Visible = true;      // GroupBox RAM sichtbar
                grbTestTaskParam.Visible = true;      // GroupBox Aufgabenparameter sichtbar
            }
            else if (isVisible == false)
            {
                // Formularelemente ausblenden    
                grbApps.Visible = false;
                grbProcessorLoad.Visible = false;
                grbRAMLoad.Visible = false;
                grbTestTaskParam.Visible = false;
            }
        }
    }
}

// Danke für Ihre Aufmerksamkeit.