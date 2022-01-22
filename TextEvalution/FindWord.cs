using System;

static class FindWord
{
    #region Переменные
    //файл с пронумированными предложениями
    private const String Output_numbers_sentences = @"..\..\..\Output_numbers_sentences.txt";



    //*************************************************

    private static String[] Particles;                  //Список Частиц 
    private static String[] Interjections;              //Список Междометий
    private static String[] Prepositions;               //Список Предлогов 
    private static String[] Unions;                     //Список Союзов
    private static String[] Pronouns;                   //Список Местоимения
    private static String[] Pronouns_console;           //Список Местоимений приставки
    private static String[] Pronouns_root;              //Список Местоимений корни
    private static String[] Pronouns_suffix;            //Список Местоимений суффиксы
    private static String[] Pronouns_ending;            //Список Местоимений окончания
    private static String[] Adverbs;                    //Список Наречий 
    private static String[] Nouns_ending;               //Список Существительных окончания
    private static String[] Nouns;                      //Список Существительных
    private static String[] Participle_ending;          //Список Причастий
    private static String[] Participle_suffix;          //Список Причастий
    //*************************************************
    private static String[] Verbs_postfix;              //Список Глаголов постфиксы
    private static String[] Verbs_suffix;               //Список Глаголов суффиксы
    private static String[] Verbs_ending;               //Список Глаголов окончания
    //*************************************************
    private static String[] Adjectives_ending;          //Список Прилагательных окончания
    private static String[] Adjectives_suffix_short;    //Список Прилагательных суффиксы краткой формы
    private static String[] Adjectives_ending_short;    //Список Прилагательных окончания краткой формы
    private static String[] Adjectives_suffix;          //Список Прилагательных суффиксы
    //*************************************************
    private static String[] Deerpriests_ending;         //Список Деепричастий окончания

    private static String[] Numerical;                  //Список Числительных
    /*   private static String[] Numerical_root;              //Строка Числительные корень
         private static String[] Numerical_sec_root;          //Строка Числительные второй корень
         private static String[] Numerical_additional;        //Строка Числительные добавочный корень
         private static String[] Numerical_suffix;            //Строка Числительные суффикс
         private static String[] Numerical_ending;            //Строка Числительные окончание*/

    //*************************************************


    #endregion


    public static void Read_base()
    {
        string temporary;

        #region connect

        temporary = TextEvalution.Properties.Resources.Particles.ToLower();            //понижение регистра
        Particles = temporary.Split(',');                  //разбиение считанных Частиц по запятой
  
        temporary = TextEvalution.Properties.Resources.Interjections.ToLower();            //понижение регистра
        Interjections = temporary.Split('\n');                           //разбиение считанных Междометий по запятой

        temporary = TextEvalution.Properties.Resources.Prepositions.ToLower();
        Prepositions = temporary.Split(',');                  //разбиение считанных Предлогов по запятой


        temporary = TextEvalution.Properties.Resources.Unions.ToLower();            //понижение регистра
        Unions = temporary.Split(',');                  //разбиение считанных Союзов по запятой


        temporary = TextEvalution.Properties.Resources.Pronouns.ToLower();            //понижение регистра
        Pronouns = temporary.Split(',');                  //разбиение считанных Местоимений по запятой
        Pronouns = Sortir(Pronouns);
        //*************************************************
        
            //считывание всех приставок Местоимений
            temporary = TextEvalution.Properties.Resources.Pronouns_console.ToLower();            //понижение регистра
        Pronouns_console = temporary.Split(',');        //разбиение считанных приставок Местоимений
        Pronouns_console = Sortir(Pronouns_console);
        //*************************************************
        //считывание всех корней Местоимений
        temporary = TextEvalution.Properties.Resources.Pronouns_root.ToLower();            //понижение регистра
        Pronouns_root = temporary.Split(',');           //разбиение считанных корней Местоимений
        Pronouns_root = Sortir(Pronouns_root);
        //*************************************************
           //считывание всех суффиксрв Местоимений
            temporary = TextEvalution.Properties.Resources.Pronouns_suffix.ToLower();            //понижение регистра
      
        Pronouns_suffix = temporary.Split(',');         //разбиение считанных суффиксрв Местоимений
        Pronouns_suffix = Sortir(Pronouns_suffix);
        //*************************************************
             //считывание всех окончаний Местоимений
            temporary = TextEvalution.Properties.Resources.Pronouns_ending.ToLower();            //понижение регистра
      
        Pronouns_ending = temporary.Split(',');         //разбиение считанных окончаний Местоимений
        Pronouns_ending = Sortir(Pronouns_ending);
        //*************************************************
           //считывание всех Числительных
            temporary = TextEvalution.Properties.Resources.Numerical.ToLower();            //понижение регистра
        Numerical = temporary.Split(',');                  //разбиение считанных Числительных по запятой
        //*************************************************
           //считывание всех Наречий
            temporary = TextEvalution.Properties.Resources.Adverbs.ToLower();            //понижение регистра
           
        Adverbs = temporary.Split(',');                  //разбиение считанных Наречий по запятой
        //*************************************************
            //считывание всех  постфиков Глаголов
            temporary = TextEvalution.Properties.Resources.Verbs_postfix.ToLower();            //понижение регистра
        Verbs_postfix = temporary.Split(',');                  //разбиение считанных постфиков Глаголов по запятой

            //считывание всех окончание Глаголов
            temporary = TextEvalution.Properties.Resources.Verbs_ending.ToLower();            //понижение регистра
        Verbs_ending = temporary.Split(',');                  //разбиение считанных окончаний Глаголов по запятой

            //считывание всех суффиксов Глаголов
            temporary = TextEvalution.Properties.Resources.Verbs_suffix.ToLower();            //понижение регистра
        Verbs_suffix = temporary.Split(',');                  //разбиение считанных суффиксов Глаголов по запятой
        //*************************************************
           //считывание всех существительных
            temporary = TextEvalution.Properties.Resources.Nouns.ToLower();            //понижение регистра
        Nouns = temporary.Split('\n');                  //разбиение считанных существительных по запятой

               //считывание всех окончаний существительных 
            temporary = TextEvalution.Properties.Resources.Nouns_ending.ToLower();            //понижение регистра
        Nouns_ending = temporary.Split(',');                  //разбиение считанных окончаний существительных по запятой

             //считывание всех окончание
            temporary = TextEvalution.Properties.Resources.Adjectives_ending.ToLower();            //понижение регистра
        Adjectives_ending = temporary.Split(',');                  //разбиение считанных окончаний по запятой

            //считывание всех суффиксов Прилагательных
            temporary = TextEvalution.Properties.Resources.Adjectives_suffix.ToLower();            //понижение регистра
            Adjectives_suffix = temporary.Split(',');                  //разбиение считанных суффиксов Прилагательных по запятой
           
        //считывание всех суффиксов Прилагательных кр ф
            temporary = TextEvalution.Properties.Resources.Adjectives_suffix_short.ToLower();            //понижение регистра
        Adjectives_suffix_short = temporary.Split(',');                  //разбиение считанных суффиксов Прилагательных кр ф по запятой
        
        //считывание всех окончание окончаний Прилагательных кр ф
            temporary = TextEvalution.Properties.Resources.Adjectives_ending_short.ToLower();            //понижение регистра
        Adjectives_ending_short = temporary.Split(',');                  //разбиение считанных окончаний Прилагательных кр ф по запятой


           //считывание всех окончаний Причастий 
            temporary = TextEvalution.Properties.Resources.Participle_ending.ToLower();            //понижение регистра
        Participle_ending = temporary.Split(',');                  //разбиение считанных окончаний Причастий по запятой
        
        //считывание всех суффиксоф Причастий
        temporary = TextEvalution.Properties.Resources.Participle_suffix.ToLower();            //понижение регистра
        Participle_suffix = temporary.Split(',');                  //разбиение считанных суффиксоф Причастий по запятой


           //считывание всех окончаний Деепричастий
            temporary = TextEvalution.Properties.Resources.Deerpriests_ending.ToLower();            //понижение регистра
        Deerpriests_ending = temporary.Split(',');                  //разбиение считанных  окончаний Деепричастий по запятой
        #endregion

    } //считываение массивов окончаний и т.д. из файлов

    public static bool FindAux(string SomeWord)
    {   //проверка совпадение с Частицой
        for (int i = 0; i < Particles.Length; i++)
        {
            if (Particles[i] == SomeWord)
            {
                return true;
            }
        }
        //проверка совпадение с Междометием
        for (int i = 0; i < Interjections.Length; i++)
        {
            if (Interjections[i] == SomeWord)
            {
                return true;
            }
        }
        //проверка совпадение с Предлогом
        for (int i = 0; i < Prepositions.Length; i++)
        {
            if (Prepositions[i] == SomeWord)
            {
                return true;
            }
        }
        //проверка совпадение с Союзом
        for (int i = 0; i < Unions.Length; i++)
        {
            if (Unions[i] == SomeWord)
            {
                return true;
            }
        }

        return false;
    }

    public static bool FindPronoun(string SomeWord)
    {   //проверка совпадение с Местоимением
        bool Check = false;
        for (int i = 0; i < Pronouns.Length; i++)
        {
            if (Pronouns[i] == SomeWord)
            {
                Check = true;
                return true;
            }
        }
        if (!Check)
        {
            for (int i = 0; i < Pronouns_console.Length; i++) //цикл по приставкам
            {
                if (SomeWord.Length > Pronouns_console[i].Length) //длина слова больше длины приставки
                {
                    if (SomeWord.Substring(0, Pronouns_console[i].Length) == Pronouns_console[i]) //приставка совпадает
                    {
                        for (int j = 0; j < Pronouns_root.Length; j++) //цикл по корням
                        {
                            if (SomeWord.Length > Pronouns_console[i].Length + Pronouns_root[j].Length) //корень и приставка меньше слова
                            {
                                if (SomeWord.Substring(Pronouns_console[i].Length, Pronouns_root[j].Length) == Pronouns_root[j]) //корень совпадает
                                {
                                    for (int k = 0; k < Pronouns_suffix.Length; k++) //цикл по суффиксам
                                    {
                                        if (SomeWord.Length > Pronouns_console[i].Length + Pronouns_root[j].Length + Pronouns_suffix[k].Length) //корень, приставка, суффикс меньше слова
                                        {
                                            if (SomeWord.Substring(Pronouns_console[i].Length + Pronouns_root[j].Length, Pronouns_suffix[k].Length) == Pronouns_suffix[k]) //суффикс совпадает
                                            {
                                                for (int l = 0; l < Pronouns_ending.Length; l++) //цикл по окончаниям
                                                {
                                                    if (SomeWord.Length == Pronouns_console[i].Length + Pronouns_root[j].Length + Pronouns_suffix[k].Length + Pronouns_ending[l].Length) //корень, приставка, суффикс, окончание равно длине слова
                                                    {
                                                        if (SomeWord.Substring(Pronouns_console[i].Length + Pronouns_root[j].Length + Pronouns_suffix[k].Length) == Pronouns_ending[l]) //окончание совпадает
                                                        {
                                                            return true;
                                                        }
                                                        else continue;
                                                    }
                                                    else continue;
                                                }
                                            }
                                        }
                                        else continue;
                                    }
                                    for (int l = 0; l < Pronouns_ending.Length; l++) //цикл по окончаниям
                                    {
                                        if (SomeWord.Length == Pronouns_console[i].Length + Pronouns_root[j].Length + Pronouns_ending[l].Length) //корень, приставка, окончание равно длине слова
                                        {
                                            if (SomeWord.Substring(Pronouns_console[i].Length + Pronouns_root[j].Length) == Pronouns_ending[l]) //окончание совпадает
                                            {
                                                return true;
                                            }
                                            else continue;
                                        }
                                        else continue;
                                    }
                                }
                                else continue;
                            }
                            else continue;
                        }   //end for
                    }
                    else continue;
                }
                else continue;//длина приставки больше или равна длине местоимения 
            }
            for (int j = 0; j < Pronouns_root.Length; j++) //цикл по корням
            {
                if (SomeWord.Length > Pronouns_root[j].Length) //корень  меньше слова
                {
                    if (SomeWord.Substring(0, Pronouns_root[j].Length) == Pronouns_root[j]) //корень совпадает
                    {
                        for (int k = 0; k < Pronouns_suffix.Length; k++) //цикл по суффиксам
                        {
                            if (SomeWord.Length > Pronouns_root[j].Length + Pronouns_suffix[k].Length) //корень, суффикс меньше слова
                            {
                                if (SomeWord.Substring(Pronouns_root[j].Length, Pronouns_suffix[k].Length) == Pronouns_suffix[k]) //суффикс совпадает
                                {
                                    for (int l = 0; l < Pronouns_ending.Length; l++) //цикл по окончаниям
                                    {
                                        if (SomeWord.Length == Pronouns_root[j].Length + Pronouns_suffix[k].Length + Pronouns_ending[l].Length) //корень, суффикс, окончание равно длине слова
                                        {
                                            if (SomeWord.Substring(Pronouns_root[j].Length + Pronouns_suffix[k].Length) == Pronouns_ending[l]) //окончание совпадает
                                            {
                                                return true;
                                            }
                                            else continue;
                                        }
                                        else continue;
                                    }
                                }
                            }
                            else continue;
                        }
                        for (int l = 0; l < Pronouns_ending.Length; l++) //цикл по окончаниям
                        {
                            if (SomeWord.Length == Pronouns_root[j].Length + Pronouns_ending[l].Length) //корень, окончание равно длине слова
                            {
                                if (SomeWord.Substring(Pronouns_root[j].Length) == Pronouns_ending[l]) //окончание совпадает
                                {
                                    return true;
                                }
                                else continue;
                            }
                            else continue;
                        }
                    }
                    else continue;
                }
                else continue;
            }   //end for
        }
        return false;
    }

    public static bool FindNum(string SomeWord)
    {   //проверка совпадение с Числительным
        bool Check = false;
        for (int i = 0; i < Numerical.Length; i++)
        {
            if (Numerical[i] == SomeWord)
            {
                Check = true;
                break;
            }
        }
        return Check;
    }

    public static bool FindAdv(string SomeWord)
    {   //проверка совпадение с Наречием
        bool Check = false;
        for (int i = 0; i < Adverbs.Length; i++)
        {
            if (Adverbs[i] == SomeWord)
            {
                Check = true;
                break;
            }
        }
        return Check;
    }

    public static bool FindVerb(string SomeWord)
    {   //проверка совпадение с постфиксом глагола
        bool Check = false;

        for (int j = 0; j < Verbs_postfix.Length; j++)
        {
            if (SomeWord.Length > Verbs_postfix[j].Length)
            {
                if (SomeWord.Substring(SomeWord.Length - Verbs_postfix[j].Length) == Verbs_postfix[j])
                {
                    Check = true;     //поднятие флага 
                    break;           // выход из итерации цикла
                }
            }
        }
        //проверка совпадение с Окончанием+суф глагола
        if (Check == false)
        {
            for (int j = 0; j < Verbs_ending.Length; j++)
            {
                if (SomeWord.Length > Verbs_ending[j].Length)
                {
                    if (SomeWord.Substring(SomeWord.Length - Verbs_ending[j].Length) == Verbs_ending[j])
                    {
                        for (int k = 0; k < Verbs_suffix.Length; k++)
                        {
                            if (SomeWord.Length > (Verbs_ending[j].Length + Verbs_suffix[k].Length))
                            {
                                if (SomeWord.Substring(SomeWord.Length - (Verbs_ending[j].Length + Verbs_suffix[k].Length), Verbs_suffix[k].Length) == Verbs_suffix[k])
                                {
                                    Check = true;     //поднятие флага 
                                    break;           // выход из итерации цикла
                                }
                            }
                        }
                    }
                }
            }
        }

        return Check;
    }

    public static bool FindGerund(string SomeWord)
    {
        //проверка совпадение с окончанием Деепричастия
        bool Check = false;
        for (int j = 0; j < Deerpriests_ending.Length; j++)
        {
            if (SomeWord.Length > Deerpriests_ending[j].Length)
            {
                if (SomeWord.Substring(SomeWord.Length - Deerpriests_ending[j].Length) == Deerpriests_ending[j])
                {
                    Check = true;     //поднятие флага 
                    break;           // выход из итерации цикла
                }
            }
        }
        return Check;

    }

    public static bool FindAdj(string SomeWord)
    {
        bool Check = false;
        //проверка совпадение с окончанием+суффиксом прилагательного
        for (int j = 0; j < Adjectives_ending.Length; j++)
        {
            if (SomeWord.Length > Adjectives_ending[j].Length)
            {
                if (SomeWord.Substring(SomeWord.Length - Adjectives_ending[j].Length) == Adjectives_ending[j])
                {
                    for (int k = 0; k < Adjectives_suffix.Length; k++)
                    {
                        if (SomeWord.Length > (Adjectives_ending[j].Length + Adjectives_suffix[k].Length))
                        {
                            if (SomeWord.Substring(SomeWord.Length - (Adjectives_ending[j].Length + Adjectives_suffix[k].Length), Adjectives_suffix[k].Length) == Adjectives_suffix[k])
                            {
                                Check = true;     //поднятие флага 
                                break;           // выход из итерации цикла
                            }
                        }
                    }
                }
            }
        }
        //проверка совпадение с окончанием+суффиксом прилагательного кр ф
        if (Check == false)
        {
            for (int j = 0; j < Adjectives_suffix_short.Length; j++)
            {
                if (SomeWord.Length > Adjectives_suffix_short[j].Length)
                {
                    if (SomeWord.Substring(SomeWord.Length - Adjectives_suffix_short[j].Length) == Adjectives_suffix_short[j])
                    {
                        Check = true;     //поднятие флага (другая часть речи)
                        break;           // выход из итерации цикла
                    }
                }
            }
            if (Check == false)
            {
                for (int j = 0; j < Adjectives_ending_short.Length; j++)
                {
                    if (SomeWord.Length > Adjectives_ending_short[j].Length)
                    {
                        if (SomeWord.Substring(SomeWord.Length - Adjectives_ending_short[j].Length) == Adjectives_ending_short[j])
                        {
                            for (int k = 0; k < Adjectives_suffix_short.Length; k++)
                            {
                                if (SomeWord.Length > (Adjectives_ending_short[j].Length + Adjectives_suffix_short[k].Length))
                                {
                                    if (SomeWord.Substring(SomeWord.Length - (Adjectives_ending_short[j].Length + Adjectives_suffix_short[k].Length), Adjectives_suffix_short[k].Length) == Adjectives_suffix_short[k])
                                    {
                                        Check = true;     //поднятие флага 
                                        break;           // выход из итерации цикла
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (SomeWord.Length > 4)
                    {
                        if (((SomeWord.Substring(SomeWord.Length - 4) == "ание"))|(SomeWord.Substring(SomeWord.Length - 4) == "ение")|(SomeWord.Substring(SomeWord.Length - 4) == "еля"))
                        { Check = false; }
                    }
        return Check;
    }

    public static bool FindParticiple(string SomeWord)
    {
        bool Check = false;
        //проверка совпадения с окончанием+суффиксом причастия
        for (int j = 0; j < Participle_ending.Length; j++)
        {
            if (SomeWord.Length > Participle_ending[j].Length)
            {
                if (SomeWord.Substring(SomeWord.Length - Participle_ending[j].Length) == Participle_ending[j])
                {
                    for (int k = 0; k < Participle_suffix.Length; k++)
                    {
                        if (SomeWord.Length > (Participle_ending[j].Length + Participle_suffix[k].Length))
                        {
                            if (SomeWord.Substring(SomeWord.Length - (Participle_ending[j].Length + Participle_suffix[k].Length), Participle_suffix[k].Length) == Participle_suffix[k])
                            {
                                Check = true;     //поднятие флага 
                                break;           // выход из итерации цикла
                            }
                        }
                    }
                }
            }
        }

        return Check;
    }

    public static bool FindNoun(string SomeWord)
    {//проверка совпадение с существительным
        bool Check = false;
        for (int i = 0; i < Nouns.Length; i++)
        {
            if (Nouns[i] == SomeWord)
            {
                Check = true;
                break;
            }
        }
        if (!Check)
        {//проверка совпадение с окончанием+суффиксом существительного
            for (int j = 0; j < Nouns_ending.Length; j++)
            {
                if (SomeWord.Length > Nouns_ending[j].Length)
                {
                    if (SomeWord.Substring(SomeWord.Length - Nouns_ending[j].Length) == Nouns_ending[j])
                    //при совпадении окончаний
                    {
                        Check = true;     //поднятие флага 
                        break;           // выход из итерации цикла
                    }
                }
            }

        }
        return Check;
    }

    private static String[] Sortir(String[] Mass)
    {
        for (int i = 1; i < Mass.Length; i++)
        {
            int cur = Mass[i].Length;
            string curr = Mass[i];
            int j = i;
            while (j > 0 && cur > Mass[j - 1].Length)
            {
                Mass[j] = Mass[j - 1];
                j--;
            }
            Mass[j] = curr;
        }
        return Mass;
    }
}

