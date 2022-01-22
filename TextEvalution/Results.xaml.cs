using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TextEvalution
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        //Класс реализующий события в окне результатов
        public ViewModelR viewModelr = new ViewModelR();//для биндинга с формой
        bool FlagClose = true;//если false, то закрывать окно родитель не надо
        List<string> Sentences;
        
        public Results(ObservableCollection<Word> Words, string fileMsg, List<string> sentences, string PathToWriteFile)
        {
            InitializeComponent();
            this.DataContext = viewModelr;               //привязываем экзмепляр окна к экземпляру модели
            viewModelr.ViewWords = Words;
            Sentences = sentences;
            viewModelr.RText = fileMsg;                  // выводим результаты анализа
            viewModelr.StatisticText = CalculStat(Words);
            WriteInFile(PathToWriteFile, Words);
            viewModelr.SelectedWord = Words[0];
        }

        private string CalculStat(ObservableCollection<Word> Words)
        {
            string statistic = "";
            int amWords = Words.Count();
            int amWordsWithoutRepeat = 0;
            int amNoun = 0;
            int amVerb = 0; 
            int amAdv = 0;
            int amParticiple = 0;
            int amAdj = 0;
            int amGerund = 0;
            int amNum = 0;
            int amPronoun = 0;
            int amAux = 0;
            int amRemain = 0;
            for (int i = 0; i < amWords; i++)
            {
                amWordsWithoutRepeat += Words[i].NumSentences.Count();
                if (Words[i].Noun)
                    amNoun++;
                if (Words[i].Verb)
                    amVerb++;
                if (Words[i].Adv)
                    amAdv++;
                if (Words[i].Participle)
                    amParticiple++;
                if (Words[i].Adj)
                    amAdj++;
                if (Words[i].Gerund)
                    amGerund++;
                if (Words[i].Num)
                    amNum++;
                if (Words[i].Pronoun)
                    amPronoun++;
                if (Words[i].Aux)
                    amAux++;
                if (Words[i].Remain)
                    amRemain++;
            }
            statistic = "Количество слов: " + amWords + "\nКоличество слов с повторениями: " + amWordsWithoutRepeat + 
                 "\nКоличество сущестивтельных:\t" + amNoun + "\tпроцент от общего кол-ва:" + 
                 String.Format("{0:0.##}", ((double)amNoun/ (double)amWords)*100.0) +    "% " +
                 "\nКоличество глаголов:\t\t" + amVerb + "\tпроцент от общего кол-ва: " + 
                 String.Format("{0:0.##}", ((double)amVerb / (double)amWords) * 100.0) + "% " +
                 "\nКоличество наречий:\t\t" + amAdv + "\tпроцент от общего кол-ва: " + 
                 String.Format("{0:0.##}", ((double)amAdv / (double)amWords) * 100.0) + "% " +
                 "\nКоличество причастий:\t\t" + amParticiple + "\tпроцент от общего кол-ва: " + 
                 String.Format("{0:0.##}", ((double)amParticiple / (double)amWords) * 100.0) + "% " +
                 "\nКоличество прилагательных:\t" + amAdj + "\tпроцент от общего кол-ва: " + 
                 String.Format("{0:0.##}", ((double)amAdj / (double)amWords) * 100.0) + "% " +
                 "\nКоличество деепричастий:\t" + amGerund + "\tпроцент от общего кол-ва: " +
                 String.Format("{0:0.##}", ((double)amGerund / (double)amWords) * 100.0) + "% " +
                 "\nКоличество числительных:\t" + amNum + "\tпроцент от общего кол-ва: " + 
                 String.Format("{0:0.##}", ((double)amNum / (double)amWords) * 100.0) + "% " +
                 "\nКоличество местоимений:\t" + amPronoun + "\tпроцент от общего кол-ва: " + 
                 String.Format("{0:0.##}", ((double)amPronoun / (double)amWords) * 100.0) + "% " +
                 "\nКоличество служебных ч.р.:\t" + amAux + "\tпроцент от общего кол-ва: " + 
                 String.Format("{0:0.##}", ((double)amAux / (double)amWords) * 100.0) + "% " +
                 "\nКоличество остатка:\t\t" + amRemain + "\tпроцент от общего кол-ва: " + 
                 String.Format("{0:0.##}", ((double)amRemain / (double)amWords) * 100.0) + "% ";

            return statistic;
        }

        //закрытие окна результатов при нажатии кнопки "Назад" и возврат к родительскому окну
        private void BtnClickBack(object sender, RoutedEventArgs e)
        {
            Owner.Show();
            FlagClose = false;
            this.Close();
        }

        //Закрытие окна родителя при закрытии окна результатов
        private void Window_Closed(object sender, EventArgs e)
        {
            if(FlagClose)
            Owner.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModelr.RText = "Часть речи и предложения, содержащие слово «" + viewModelr.SelectedWord.Name + "»: \n\n";
            viewModelr.RText += "Часть речи: " + viewModelr.SelectedWord.ClassWord + "\n\n";
            for (int i = 0; i < viewModelr.SelectedWord.NumSentences.Count; i++)
                viewModelr.RText += (viewModelr.SelectedWord.NumSentences[i] + 1) + ". " + Sentences[viewModelr.SelectedWord.NumSentences[i]] + ".\n\n";
        }

        void WriteInFile(string Path, ObservableCollection<Word> Words)
        {
            //если пользователь выбрал путь к записываевому файлу, то
            if (Path != null)
            {
                MessageBoxResult result = MessageBox.Show("Результаты анализа были перезаписаны в файл по пути: \n" + Path + 
                                                       "\n Текст с пронумерованными предложениями был дописан в файл Текст в текущий каталог\n"+
                                                          "Данная информация также отражена в поле Статистика", "Вывод в Файл");
                string textOfSentences = ""; //пронумерованные предложения
                string textToFile = "";      //проанализированные слова
                int longest = 0;             //максимальная длина слова для выравнивания в текстовом файле
                for (int j = 0; j < Words.Count; j++)
                {
                    if (longest < Words[j].Name.Length)
                        longest = Words[j].Name.Length;
                }
            for (int i = 0; i < Words.Count; i++)
            {
                    string Name = Words[i].Name;
                    int delta = longest - Name.Length;
                    if (Name.Length < longest)
                        for (int k = 0; k < delta; k++)
                            Name += " ";
                textToFile += Name + "\t\t\t";
                textToFile += "Часть речи: " + Words[i].ClassWord + "\t\tНомера предложений: ";                             
                for (int j = 0; j < Words[i].NumSentences.Count(); j++)
                    textToFile += Words[i].NumSentences[j] + 1 + " ";
                textToFile += "\n";

            }
                //открываем и записываем в файл результаты анализа
                StreamWriter sw = new StreamWriter(File.Open(Path, FileMode.Create), Encoding.UTF8);
                sw.Write(textToFile);
                sw.Close();
                viewModelr.StatisticText += "\nРезультаты анализа были перезаписнаы в файл по пути: " + Path + "\n\n";
                
                //записываем в файл "Текст" пронумерованные предложения текста
                    for(int j = 0; j < Sentences.Count; j++)
                       textOfSentences += (j + 1) + ". " + Sentences[j] + ".\n";
                StreamWriter swr = new StreamWriter(File.Open("Текст.txt", FileMode.Create), Encoding.UTF8);
                swr.Write(textOfSentences);
                swr.Close();
                viewModelr.StatisticText += "Текст с пронумерованными предложениями был перезаписан в файл Текст в текущем каталоге\n";
            }
        }
    }
}
