using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace TextEvalution
{
    //Класс, содержащий свойства для элементов управления окна результатов
    public class ViewModelR : INotifyPropertyChanged
    {
        //Статистика
        private string stText;
        public string StatisticText
        {
            get { return stText; }
            set
            {
                stText = value;
                this.OnPropertyChanged("StatisticText");
            }
        }



        //Результаты анализа
        private string rtext;
        public string RText
        {
            get { return rtext; }
            set
            {
                rtext = value;
                this.OnPropertyChanged("RText");
            }
        }

        //Коллекция слов в таблице
        private ObservableCollection<Word> words;
        public ObservableCollection<Word> ViewWords
        {
            get { return words; }
            set
            {
                words = value;
                this.OnPropertyChanged("ViewWords");
            }
        }

        //Выбранное в таблице слово
        private Word selectedWord;
        public Word SelectedWord
        {
            get { return selectedWord; }
            set
            {
                selectedWord = value;
                this.OnPropertyChanged("SelectedWord");
            }
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
