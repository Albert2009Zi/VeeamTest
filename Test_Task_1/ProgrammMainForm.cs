// Тестовое задание на должность Junior Developer in QA
// Соискатель Альберт Зиатдинов
// Работодатель Veeam
// Дата 03.02.2022

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Test_Task_1
{
    public partial class ProgrammMainForm : Form
    {
        private string opdApp;                        //Имя запущенного через форму приложения 
        private string logFilePathName;               //Имя пути к лог-файлу
        private bool stopFlag = false;                //Нажимался ли Stop
        public ProgrammMainForm()
        {
            InitializeComponent();
        }


        // Обработчик chekbox'а записи информации в файл. Отображение других элементов формы
        // возможно только при активации данного chekbox'а (см. условия задания)
        private void ckbSaveLogFile_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSaveLogFile.Checked)                            //если выбран checkbox, то ...
            {
                elementsVisible(true);                             //включаем "видимость" элементов основной формы
                DialogResult drtLogFile = fbdLogFile.ShowDialog(); //вызов диалога выбора католога расположения создаваемого Log файла 

                if (drtLogFile == DialogResult.OK)                 //выбран путь и нажата OK
                {
                    logFilePathName = fbdLogFile.SelectedPath;     //переменная - путь к папке Log файла
                }
            }
            else                                                   //иначе ...
            {
                elementsVisible(false);                            //выключаем "видимость" элементов основной формы
            }
        }

        // Обработчик нажатия кнопки Run
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (btnRun.Text == "Run")                             //если кнопка нажата в "статусе" Run, то ...
            {
                if (stopFlag == true)                             //если Stop уже нажимали и выбранное приложение уже закрывалось, то ...
                {
                    using (Process.Start(opdApp)) { };            //запустить выбранное ранее приложение
                }
                elementsVisible(true);                            //включаем "видимость" элементов основной формы
                runTimer.Start();                                 //запуск таймера 
                runTimer.Tick += new EventHandler(runTimer_Tick); //вызов обработчика таймера
                btnRun.Text = "Stop";                             //меняем текст кнопки на Stop, "предалагаем" другое состояние кнопки
            }
            else if (btnRun.Text == "Stop")                       //иначе, если кнопка нажата в "статусе" Stop, то ...
            {
                elementsVisible(false);                           //выключаем "видимость" элементов основной формы
                runTimer.Stop();                                  //остановка таймера 
                CloseProcess(opdApp);                             //остановка приложения, запущенного из формы
                stopFlag = true;                                  //флаг в истину, т.к. кнопка была нажата  
                btnRun.Text = "Run";                              //меняем текст кнопки на Run, "предалагаем" другое состояние кнопки
            }
        }

        //Обработчик таймера формы
        private void runTimer_Tick(object sender, EventArgs e)
        {
            runTimer.Interval = (int)nudTimeSet.Value * 1000;                                            //Свойство Interval получаем с NemericUpDown элемента формы и умножаем на 1000, 
                                                                                                         //т.к. одиночный "тик" таймера - 1 миллисекунда
                                                                                                         
            pgbProcessor.Value = (int)(pfcProcessor.NextValue());                                        //Значение загрузки процессора с соответствующего PerfomanceCounter'а 
            lblProcessor.Text = "CPU Load Progress: " + pgbProcessor.Value.ToString() + "%";             //Текст для метки на groupbox'е, содержащий иформацию о работе процессоре 

            lblMemoryAvailable.Text = "Available RAM: " + ((int)pfcRam.NextValue()).ToString() + "Mb";   //Количество доступной оперативной памяти

                Process[] stsRunningProcess = Process.GetProcessesByName(opdApp);                        //создаем массив из запущенных процессов с именем opdApp

         //если процесс запущен, то выдаем в форму его параметры, указанные в задаче, то ...
            if (stsRunningProcess.Length > 0) 
                {
                    lblProcessName.Text    = "Process Name: " + (string)stsRunningProcess[0].ProcessName;
                    lblWorkingSet64.Text   = "Working Set Status: " + (int)stsRunningProcess[0].WorkingSet64 / 1024 / 1024 + "Mb";
                    lblPrivateBytes64.Text = "Pivate Bytes Status: " + (int)stsRunningProcess[0].PrivateMemorySize64 / 1024 / 1024 + "Mb";
                    lblHandleCount.Text    = "Handle Count: " + (int)stsRunningProcess[0].HandleCount;
                    LogFileWrite((int)pgbProcessor.Value, (int)stsRunningProcess[0].WorkingSet64 / 1024 / 1024, (int)stsRunningProcess[0].PrivateMemorySize64
                    / 1024 / 1024, (int)stsRunningProcess[0].HandleCount); // и пишем эти же параметры в файл
                }          
             
        }

        //обработчик выбора приложения
        private void grbAppRadiobutton_CheckedChanged(object sender, EventArgs e)
        { 
            RadioButton rbnAppSelected = (sender as RadioButton); //переменная с типом radiobutton, которой присваивается объект вызвавший обработчик
            string buttonName = (string) rbnAppSelected.Tag;      //переменной присваиваем имя тега radiobutton с главной формы
            if (rbnAppSelected.Checked)                           //если своейство checked истинно (radiobutton выбран), то ... 
            {
                switch (buttonName)                               //переключатель по имени процесса
                {
                    case "notepad":                                 
                        using (Process.Start("notepad")) { };     // запускаем блокнот
                        break;                                         
                    case "cmd":
                        using (Process.Start("cmd")) { };         // запускаем командную строку 
                        break;
                    default:                                      // по "дефолту" ничего не делаем, просто выходим из переключателя
                        break;
                }
                btnRun.Enabled = true;                            //активировалась кнопка Run
                CloseAnotherApps(grbApps);                        //закрыть другое приложение
            }             
        }

        //объект (функция) закрывает предыдущее открытое приложение, при выборе нового 
        private void CloseAnotherApps(GroupBox grbApps)
        {
            foreach (RadioButton rbnSelection in grbApps.Controls) //rbnSelection - это от "Радиобаттон селекшн". Можно какой-нибудь оупенэйр рэйв так назвать.
            {
                
                if (!rbnSelection.Checked)                         //если своейство checked ложно (radiobutton не выбран), то ... 
                {
                    CloseProcess((string) rbnSelection.Tag);       //закрываем процесс
                }
                else if (rbnSelection.Checked)                     //иначе, если своейство checked истинно (radiobutton выбран), то ...
                {
                    opdApp = (string) rbnSelection.Tag;            //присваиваем переменной opdApp значения тега выбранного radiobutton
                }
            }
        }

        //объект (функция) закрывает процесс по имени, которое в неё передали в качестве аргумента
        private void CloseProcess(string prsName)
        {
            if (opdApp != null)                                           //если opdApp не равно null
            {
                Process[] AllOpened = Process.GetProcesses();             //получаем имена всех открытых в системе процессов
               
                foreach (Process DetectedProcess in AllOpened)            //идем циклом по списку открытых процессов 
                {
                    if (DetectedProcess.ProcessName.Contains(prsName))    //если встречаем процесс, имя которого содержит значение равное имени, переданного в функцию
                                                                          //в качестве аршумента, то ...
                    {
                        DetectedProcess.Kill();                           //завершаем процесс
                    }
                }
            }
        }

        //объект (функция) записывает искомые параметры в Log файл, находящийся по пути заданном пользователем через диалог
        private void LogFileWrite(int processorLoad, int workingSet, int privateBytes, int handleCount)
        {
            string path = @logFilePathName;                             //строковая переменная path хранящая путь к файлу
            FileInfo fileInfo = new FileInfo(path);                     //переменной типа FileInfo присваиваем значения метода FileInfo с аргументом path

            if (!fileInfo.Exists)
            {
                try                                                     //try-catch используем при работе с файлами, т.к. возможны непредвиденные сбои (исключения)
                {
                    using (var strWriter = File.AppendText($"{path}logFile.txt")) //созваем файл с именем Veeam_LogFile.txt по пути заданном через диалог
                    {
                        //пишем в файл искомые данные с установленным интервалом
                        strWriter.WriteLine($"{DateTime.Now:T}" + "   " + processorLoad + "   " + workingSet + "   " + privateBytes + "   " + handleCount);
                    }
                    // хотим посмотреть, что пишется в файл из VisualStudio, "раскомментируем" строку ниже  
                    Debug.WriteLine($"{DateTime.Now:T}" + "   " + processorLoad + "   " + workingSet + "   " + privateBytes + "   " + handleCount);
                }
                catch (Exception ex)                                     //в случае исключения
                {
                    Console.WriteLine("The process failed: {0}", ex.ToString()); //пишем в консоль сообщение содержащее данное исключение
                }
            }

        }

        private void elementsVisible(bool isVisible)
        {
            if (isVisible == true)
            {
                grbApps.Visible          = true;      //виден groupbox приложения, которое можно запустить
                grbProcessorLoad.Visible = true;      //виден groupbox загрузки процессора
                grbRAMLoad.Visible       = true;      //виден groupbox доступной памяти  
                grbTestTaskParam.Visible = true;      //виден groupbox параметров задачи от Veeam
            }
            else if (isVisible == false)
            {
                //скрыть элементы отображения информации о процессах    
                grbApps.Visible          = false;
                grbProcessorLoad.Visible = false;
                grbRAMLoad.Visible       = false;
                grbTestTaskParam.Visible = false;
            }
        }
    }
}

//Спасибо за внимание.
