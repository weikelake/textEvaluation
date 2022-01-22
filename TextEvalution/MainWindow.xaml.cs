using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace TextEvalution
{
    //Класс реализующий события в окне ввода текста
    public partial class MainWindow : Window
    {
        public ViewModel viewModel = new ViewModel();//для биндинга с формой
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel; //привязываем экзмепляр окна к экземпляру модели
        }

        //Запоминает путь к файлу для чтения и выводит его содержимое
        private void btnClickReadPath(object sender, RoutedEventArgs e)
        {
            viewModel.PathToReadFile = GetPath();
            if (viewModel.PathToReadFile != null)
            {
                StreamReader sr = new StreamReader(viewModel.PathToReadFile, Encoding.UTF8);
                viewModel.Text = sr.ReadToEnd();
                sr.Close();
            }
            return;
        }


        //Запоминает путь к файлу для записи
        private void btnClickWritePath(object sender, RoutedEventArgs e)
        {
            viewModel.PathToWriteFile = GetPath();
            return;
        }


        //Возвращает путь к выбранному файлу
        public string GetPath()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            
            dialog.CreatePrompt = true;     // Если указан несуществующий файл создать его
            dialog.OverwritePrompt = false; // При указании существующего файла не перезаписывать его
            dialog.Title = "Выберите файл"; 
            dialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*"; // Задает фильтр поиска файлов по расширению
            dialog.AddExtension = true;     // Задает расширению файлу, если оно не указано. Расширение берется из св-ва Filter
            
            if (dialog.ShowDialog() == true)
            {

                return dialog.FileName;
            }
            return null;
        }


        //кнопка на события нажатия кнопкки "Анализ"
        private void BtnClickEvaluation(object sender, RoutedEventArgs e)
        {
            string text = viewModel.Text;//весь текст
            string fileMsg = "";

            List<string> sentences = new List<string>(text.Split(new char[] {'.','?','!' })); //делим текст на предложения
            sentences.RemoveAll(t => t == String.Empty);                                      //удаляет все пустые строки (Использует лямба-выражение!)
            ObservableCollection<Word> Words = new ObservableCollection<Word>();              //коллекция всех слов

            
            //цикл для занесения слов в коллекцию Words
            for (int i = 0; i < sentences.Count; i++)
            {
                sentences[i] = sentences[i].Replace("\n", "");
                sentences[i] = sentences[i].Replace("\r", "");
                //делим предложение по пробелам, запятым, точкам с запятой, двоеточиям, скобкам, кавычкам
                List<string> wordsInSent = new List<string>(sentences[i].Split(new char[] { ' ', ',', ':', ';', '(', ')', '"', '—', '«' , '»', '\n', '\r', '\t', '-' })); // коллекция слов в i-м предложении
                wordsInSent.RemoveAll(t => t == String.Empty);   //удаляет все пустые строки (Использует лямба-выражение!)

                //приводим все слова к нижнему регистру
                for (int j = 0; j < wordsInSent.Count; j++)                                    
                    wordsInSent[j] = wordsInSent[j].ToLower();

                //цикл на добвление слова
                for (int j = 0; j < wordsInSent.Count; j++)
                {
                    bool newWord = true;                          // true - если слово встрчается впервые
                    if (Words != null)
                        for (int k = 0; k < Words.Count; k++)
                        {
                            if (Words[k].Name == wordsInSent[j])
                            {
                                Words[k].Amount++;                //Увеличиваем счетчик этого слова
                                if(Words[k].NumSentences.Last() != i)
                                Words[k].NumSentences.Add(i);     //добавляем номер i-го предложения к найденому ранее слову
                                newWord = false;                     
                                break;
                            }

                        }

                    if (newWord)
                        Words.Add(new Word(wordsInSent[j], i));

                } // end for по j
            }// end for по i
            if (Words.Count() == 0)
            {
                MessageBox.Show("Введите текст!", "Сообщение", MessageBoxButton.OK);
                return;
            }


            ObservableCollection<Word> CertainWords = new ObservableCollection<Word>();              //коллекция всех слов
            Evaluation(Words, CertainWords);




            
            this.Hide();                                                 //прячем текущее окно
            Results WResults = new Results(CertainWords, fileMsg, sentences, viewModel.PathToWriteFile);   //объявляем и инициализируем новое окно с результатми
            WResults.Owner = this;                                       // Устанавливаем, что нынешнее окно - родитель
            WResults.Show();                                             // Показываем окно результатов
        }



        //функция, которая проверяет слово на принадлежность к той или иной части речи
        void Evaluation(ObservableCollection<Word> Words, ObservableCollection<Word> CertainWords)
        {
            FindWord.Read_base();
            for (int i = 0; i < Words.Count(); i++)
            {

                if (FindWord.FindAux(Words[i].Name))
                {
                    Words[i].Aux = true;
                    if (viewModel.bAux)
                        CertainWords.Add(Words[i]);
                    continue;
                }


                if (FindWord.FindPronoun(Words[i].Name))
                {
                    Words[i].Pronoun = true;
                    if (viewModel.bAux)
                        CertainWords.Add(Words[i]);
                    continue;
                }


                if (FindWord.FindNum(Words[i].Name))
                {
                    Words[i].Num = true;
                    if (viewModel.bNum)
                        CertainWords.Add(Words[i]);
                    continue;
                }


                if (FindWord.FindAdv(Words[i].Name))
                {
                    Words[i].Adv = true;
                    if(viewModel.bAdv)
                        CertainWords.Add(Words[i]);
                    continue;
                }

                if (FindWord.FindParticiple(Words[i].Name))
                {
                    Words[i].Participle = true;
                    if(viewModel.bParticiple)
                        CertainWords.Add(Words[i]);
                    continue;
                }
                if (FindWord.FindGerund(Words[i].Name))
                {
                    Words[i].Gerund = true;
                    if(viewModel.bGerund)
                        CertainWords.Add(Words[i]);
                    continue;
                }
                if (FindWord.FindVerb(Words[i].Name))
                {
                    Words[i].Verb = true;
                    if(viewModel.bVerb)
                        CertainWords.Add(Words[i]);
                    continue;
                }
                if (FindWord.FindAdj(Words[i].Name) )
                {
                    Words[i].Adj = true;
                    if(viewModel.bAdj)
                        CertainWords.Add(Words[i]);
                }
                if (FindWord.FindNoun(Words[i].Name))
                {
                    Words[i].Noun = true;
                    if((viewModel.bNoun) && (!Words[i].Adj))
                        CertainWords.Add(Words[i]);
                }


                if (!(Words[i].Noun || Words[i].Verb || Words[i].Adj || Words[i].Participle || Words[i].Adv || Words[i].Num || Words[i].Pronoun || Words[i].Aux))
                {
                    Words[i].Remain = true;
                    if(viewModel.bRemain)
                        CertainWords.Add(Words[i]);

                }
            }
        }


    }
}
