
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextEvalution
{
    //Класс слова. Содержит поля 
    public class Word:  INotifyPropertyChanged
    {
        private string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }

        //Нужно для вывода части речи в таблицу
        private string classWord;
        public string ClassWord { get { return classWord; }set { classWord = value; OnPropertyChanged("ClassWord"); } }

        //коллекция номеров предложений в которых встрчается слово
        private ObservableCollection<int> numSentences = new ObservableCollection<int>(); 
        public ObservableCollection<int> NumSentences { get { return numSentences; } set { numSentences = value; } }

        public int Amount { get; set; } //сколько раз повторяется в тексте

        #region переменные и свойства частей речи
        private bool noun;
        private bool verb;
        private bool adv;
        private bool participle;
        private bool adj;
        private bool gerund;
        private bool num;
        private bool pronoun;
        private bool aux;
        private bool remain;

        // Эти св-ва показывают к какой части речи принадлежит слово
        public bool Noun { get { return noun; } set {  noun = value; SetClassWords(); } }                         // существительное
        public bool Verb { get { return verb; } set { verb = value; SetClassWords(); } }                          // глагол
        public bool Adv { get { return adv; } set { adv = value; SetClassWords(); } }                             // нарчение
        public bool Participle { get { return participle; } set { participle = value; SetClassWords(); } }        // причастие
        public bool Adj { get { return adj; } set { adj = value; SetClassWords(); } }                             // прилагательное
        public bool Gerund { get { return gerund; } set { gerund = value; SetClassWords(); } }                    // деепричастие
        public bool Num { get { return num; } set { num = value; SetClassWords(); } }                             // числительное
        public bool Pronoun { get { return pronoun; } set { pronoun = value; SetClassWords(); } }                 // местоимение
        public bool Aux { get { return aux; } set { aux = value; SetClassWords(); } }                             // служебная часть речи
        public bool Remain { get { return remain; } set { remain = value; SetClassWords(); } }                    // остаток
        #endregion
        private void SetClassWords()
        {
            if (Noun && Adj)
            { ClassWord = "Имя существительное, прилагательное"; return; }
            if (Noun)
            { ClassWord = "Имя существительное\t\t\t\t"; return; }
            if (Verb)
            { ClassWord = "Глагол\t\t\t\t\t\t\t"; return; }
            if (Adv)
            { ClassWord = "Наречие\t\t\t\t\t\t\t"; return; }
            if (Participle)
            { ClassWord = "Причастие\t\t\t\t\t\t"; return; }
            if (Adj)
            { ClassWord = "Прилагательное\t\t\t\t\t"; return; }
            if (Gerund)
            { ClassWord = "Деепричастие\t\t\t\t\t"; return; }
            if (Num)
            { ClassWord = "Числительное\t\t\t\t\t"; return; }
            if (Pronoun)
            { ClassWord = "Местоимение\t\t\t\t\t\t"; return; }
            if (Aux)
            { ClassWord = "Служебная часть речи\t\t\t"; return; }
            if (Remain)
            { ClassWord = "Не определено\t\t\t\t\t"; return; }


        }

        //конструктор
        public Word(string name, int numSent)//имя слово и номер предложения
        {
            Name = name;
            NumSentences = new ObservableCollection<int>();
            NumSentences.Add(numSent);
            Amount = 0;
            //Remain = true;
        }

        //сообщает интерфейсу об изменении значения свойства
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
