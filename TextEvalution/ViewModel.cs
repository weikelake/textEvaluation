using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextEvalution
{
    //Класс, содержащий свойства для элементов управления (виджетов) окна ввода текста
    public class ViewModel : INotifyPropertyChanged
    {

        public ViewModel()
        {
            Text = "Введите текст";
            bAll = true;
        }


        //Путь файла для чтения
        private string pathToReadFile;
        public string PathToReadFile
        { get { return pathToReadFile; }
          set
            {
                pathToReadFile = value;
                this.OnPropertyChanged("PathToReadFile"); }
        }


        //Путь файла для записи
        private string pathToWriteFile;
        public string PathToWriteFile
        {
            get { return pathToWriteFile; }
            set
            {
                pathToWriteFile = value;
                this.OnPropertyChanged("PathToWriteFile");
            }
        }

        //Исходный текст
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                this.OnPropertyChanged("Text");
            }
        }


        #region Чекбоксы на выбор частей речи
        //для чекбокса "Все"
        private bool all;
        public bool bAll
        {
            get { return all; }
            set
            {
                if (value)
                {
                    bNoun = true;
                    bAdv = true;
                    bVerb = true;
                    bParticiple = true;
                    bAdj = true;
                    bGerund = true;
                    bNum = true;
                    bPronoun = true;
                    bAux = true;
                    bRemain = true;

                }
                all = value;
                this.OnPropertyChanged("bAll");
            }
        }

        //для чекбокса существительных
        private bool noun;
        public bool bNoun
        {
            get { return noun; }
            set {
                if (!value)
                    bAll = false;
                noun = value;
                this.OnPropertyChanged("bNoun");
            }
        }

        // для чекбокса наречий
        private bool adv;
        public bool bAdv
        {
            get { return adv; }
            set
            {
                if (!value)
                    bAll = false;
                adv = value;
                this.OnPropertyChanged("bAdv");
            }
        }

        //для чекбокса глаголов
        private bool verb;
        public bool bVerb
        {
            get { return verb; }
            set
            {
                if (!value)
                    bAll = false;
                verb = value;
                this.OnPropertyChanged("bVerb");
            }
        }

        // для чекбокса причастия
        private bool participle;
        public bool bParticiple
        {
            get { return participle; }
            set
            {
                if (!value)
                    bAll = false;
                participle = value;
                this.OnPropertyChanged("bParticiple");
            }
        }

        // для чекбокса прилагательных
        private bool adj;
        public bool bAdj
        {
            get { return adj; }
            set
            {
                if (!value)
                    bAll = false;
                adj = value;
                this.OnPropertyChanged("bAdj");
            }
        }

        // для чекбокса деепричастия
        private bool gerund;
        public bool bGerund
        {
            get { return gerund; }
            set
            {
                if (!value)
                    bAll = false;
                gerund = value;
                this.OnPropertyChanged("bGerund");
            }
        }


        // для чекбокса числительного 
        private bool num;
        public bool bNum
        {
            get { return num; }
            set
            {
                if (!value)
                    bAll = false;
                num = value;
                this.OnPropertyChanged("bNum");
            }
        }

        // для чекбокса местоимения 
        private bool pronoun;
        public bool bPronoun
        {
            get { return pronoun; }
            set
            {
                if (!value)
                    bAll = false;
                pronoun = value;
                this.OnPropertyChanged("bPronoun");
            }
        }

        // для чекбокса служебных частей речи
        private bool aux;
        public bool bAux
        {
            get { return aux; }
            set
            {
                if (!value)
                    bAll = false;
                aux = value;
                this.OnPropertyChanged("bAux");
            }
        }

        // для чекбокса остатка 
        private bool remain;
        public bool bRemain
        {
            get { return remain; }
            set
            {
                if (!value)
                    bAll = false;
                remain = value;
                this.OnPropertyChanged("bRemain");
            }
        }

        #endregion

        //сообщает интерфейсу об изменении значения свойства
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
