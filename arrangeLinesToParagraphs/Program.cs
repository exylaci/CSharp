// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

List<char> text = [];
{
    string inputFilePath = ReadParameter();
    ReadFromFile(inputFilePath);
    CharacterReplace();
    DeleteUnnecessaryLineBreaks();
    //ShowLineStartsAndEnds();
    ManualCheck();
    //ShowTheFullText();
    SaveTheResult(inputFilePath);

}

string ReadParameter()
{
    if (args.Length < 1)
    {
        Console.WriteLine("Nincs megadva a forrás fájl paraméter!");
        About();
        Environment.Exit(1);
    }
    return args[0];
}

void ReadFromFile(string inputFilePath)
{
    try
    {
        // Fájl beolvasása List<char>-ba
        using (StreamReader reader = new(inputFilePath))
        {
            int currentChar;
            while ((currentChar = reader.Read()) != -1)
            {
                text.Add((char)currentChar);
            }
        }
        Console.WriteLine("A fájl sikeresen beolvasva.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Nem sikerült beolvasni. " + ex.Message);
    }
}

void About()
{
    Console.WriteLine(@"
        Ez a program újra bekezdésekbe rendez olyan pure text fájlt, ahol minden sor
            végén CR LF van. (Ilyen például egy *.pdf fájlból kimásolt szöveg is.)
        Előbb az OCR során vétett hibákat próbálja meg megtalálni és magától javítani,
        Majd a gyanús pontokon végigvezeti a felhasználót, akinek lehetősége van kézzel
            javítani, tovább/visszalépni a következő/előző gyanús helyre a PgDown és a
            PgUp gombokkal, illetve az Esc megnyomásával abbahagyni a kézi ellenőrzést.
        A legvégén pedig az eredeti fájllal azonos könyvtárban, az eredeti fájl nevéhez
            hozzáfűzött 2-sel (*2.txt) egy új fájlba elmenti az eredményt.
        A feldolgozni kívánt fájl nevét paraméterként kell megadni. Pl:
            prompt > arrangeLinesToParagraphs.exe " + '"' + "átalakítandó fájl neve.txt"
            + '"' + "◄┘");
}

/// Karakterek cseréje a teljes szövegben.
void CharacterReplace()
{
    try
    {
        for (int i = 0; i < text.Count; ++i)
        {
            // ~ csere -
            if (text.ElementAt(i) == '~') text[i] = '-';
            // — csere -  (gondolatjel -> kötőjel)
            if (text.ElementAt(i) == '—') text[i] = '-';
            // „ csere "
            if (text.ElementAt(i) == '„') text[i] = '"';
            // ” csere "
            if (text.ElementAt(i) == '”') text[i] = '"';
            // ` csere '
            if (text.ElementAt(i) == '`') text[i] = (char)39;
            // ’ csere '
            if (text.ElementAt(i) == '’') text[i] = (char)39;
        }
        for (int i = 0; i < text.Count - 1; ++i)
        {
            // dupla '' csere " -re
            if (text.ElementAt(i) == 39 && text.ElementAt(i + 1) == 39)
            {
                text.RemoveAt(i);
                text[i] = '"';
            }
            // dupla szóköz csere szimpla szóközre
            if (text.ElementAt(i) == ' ' && text.ElementAt(i + 1) == ' ')
            {
                text.RemoveAt(i);
                --i;
                continue;
            }
            // pont előli szóköz törlése
            if (text.ElementAt(i) == ' ' && text.ElementAt(i + 1) == '.')
                text.RemoveAt(i);
            // sorvégi szóköz törlése
            if (text.ElementAt(i) == ' ' && text.ElementAt(i + 1) == 13)
                text.RemoveAt(i);
        }
        Console.WriteLine("A karakter cserék sikeresen megtörténtek.");
    }
    catch (Exception e)
    {
        Console.WriteLine("Hiba történt a karakterek cseréje közben: " + e.Message);
        Environment.Exit(1);
    }
}

/// A szöveg automatikus átalakítása bekezdésen belüli sortörések törlése
void DeleteUnnecessaryLineBreaks()
{
    try
    {
        int columnCounter = 0;
        for (int i = 0; i < text.Count - 4; ++i)
        {
            ++columnCounter;

            //sorvégjenél karakter számlálót visszaállítja, mert az eredeti szövegben új sor kezdődik
            if (text.ElementAt(i) == 13)
            {
                columnCounter = 0;
                ++i;
                continue;
            }

            //sorvégi elválasztójel miatt következő sor elejével egybe kell írni
            if (text.ElementAt(i) == '-' && text.ElementAt(i + 1) == 13)
            {
                text.RemoveRange(i, 3);
                --i;
                columnCounter = 0;
                continue;
            }

            //ha a következő sor gondolatjellel kezdőik, akkor azt tuti új sorban kell kezdeni
            if (text.ElementAt(i + 2) == 13
                && (text.ElementAt(i + 4) == '-' || text.ElementAt(i + 4) == '~'))
            {
                i += 3;
                columnCounter = 0;
                continue;
            }

            //ha a sor végén szóköz aztán gondolat jel van, akkor az nem elválasztójel ezért ezt nem kell törölni, de ettől még a sorvégjelet törölni kell
            if (text.ElementAt(i) == ' ' && text.ElementAt(i + 1) == '-' && text.ElementAt(i + 2) == 13)
            {
                i += 2;
                text.RemoveAt(i);
                text[i++] = ' ';
                columnCounter = 0;
            }

            //ha nem rövid a sor (akkor lehet, hogy nem egy nem bekezdés vége) ezért ha kisbetűvel vagy 
            //vesszővel ér véget akkor a következő sor még ehhez bekezdésnhez tartozik
            if (columnCounter > 31
                && (char.IsLetter(text.ElementAt(i)) || text.ElementAt(i) == ',')
                && text.ElementAt(i + 1) == 13)
            {
                text.RemoveAt(++i);
                text[i++] = ' ';
                columnCounter = 0;
            }

            //ha a következő sor kisbetüvel kezdőik, akkor azt nem kell új sorban kezdeni
            if (text.ElementAt(i + 1) == 13 && char.IsLower(text.ElementAt(i + 3)))
            {
                ++i;
                text.RemoveAt(i);
                text[i] = ' ';
                columnCounter = 0;
                continue;
            }

        }
        Console.WriteLine("\nA felesleges sorvégjelek automatikus törlése sikeresen lezárult.");
    }
    catch (Exception e)
    {
        Console.WriteLine("Hiba történt az újratördelés közben: " + e.Message);
        Environment.Exit(1);
    }
}

//// felesleges sorvégjel törlések eredményének megjelenítése
void ShowLineStartsAndEnds()
{
    int columnCounter = 0;
    int first = 0;
    for (int i = 0; i < text.Count; ++i)
    {
        if (text.ElementAt(i) == 13 || i == text.Count - 1)
        {
            for (; columnCounter < 10; ++columnCounter) Console.Write('_');
            Console.Write("   ");
            for (int j = Math.Min(i - first, 10); j < 10; ++j) Console.Write('_');
            for (first = Math.Max(i - 10, first); first <= i; ++first) Console.Write(text.ElementAt(first));
            Console.WriteLine();
            columnCounter = 0;
            ++i;
            first = i + 1;
            continue;
        }
        if (columnCounter < 10)
        {
            Console.Write(text.ElementAt(i));
            ++columnCounter;
        }
    }
    Console.WriteLine("\nA szöveg végére értem.");
    Console.ReadKey();
}

bool IsSentenceEnd(int index)
{   //"x. Xx", "x. A "  jók
    if (char.IsLower(text[index])
        && (text[index + 1] == '.' || text[index + 1] == '!' || text[index + 1] == '?')
        && text[index + 2] == ' '
       )
    {
        if (char.IsUpper(text[index + 3]) && char.IsLower(text[index + 4]))
        {
            return true;
        }
        if ((text[index + 3] == 'A' || text[index + 3] == 'Ő')
            && text[index + 4] == ' '
           )
        {
            return true;
        }
    }
    return false;

}

bool IsParagraphEnd(int index)
{   //"x.◄┘Xx", "x.◄┘A ", "x.◄┘- "   jók
    if (char.IsLower(text[index])
        && (text[index + 1] == '.' || text[index + 1] == '!' || text[index + 1] == '?')
        && text[index + 2] == 13
       )
    {
        if (char.IsUpper(text[index + 4]) && char.IsLower(text[index + 5]))
        {
            return true;
        }
        if ((text[index + 4] == 'A' || text[index + 4] == 'Ő')
            && text[index + 5] == ' '
           )
        {
            return true;
        }
        if (text[index + 4] == '-' && text[index + 5] == ' ')
        {
            return true;
        }
    }
    return false;
}

bool IsProperComa(int index)
{   //"x, x"  jó
    if (char.IsLower(text[index])
        && text[index + 1] == ','
        && text[index + 2] == ' '
        && char.IsLower(text[index + 3])
       )
    {
        return true;
    }
    return false;
}

bool IsProperDashInLine(int index)
{   //"x. - X"  jó
    if (char.IsLower(text[index])
        && text[index + 1] == '.'
        && text[index + 2] == ' '
        && text[index + 3] == '-'
        && text[index + 4] == ' '
        && char.IsUpper(text[index + 5])
       )
    {
        return true;
    }
    return false;
}

bool IsProperDashInSentence(int index)
{   //"x - x"  jó
    if (char.IsLower(text[index])
        && text[index + 1] == ' '
        && text[index + 2] == '-'
        && text[index + 3] == ' '
        && char.IsLower(text[index + 4])
       )
    {
        return true;
    }
    return false;
}

bool IsTripleDots(int index)
{   //"x... ", "x...◄┘"  jó
    if (char.IsLower(text[index])
        && text[index + 1] == '.'
        && text[index + 2] == '.'
        && text[index + 3] == '.'
        && (text[index + 4] == ' '
            || text[index + 4] == 13
           )
       )
    {
        return true;
    }
    return false;
}

bool IsInvalidOneLetterWord(int index)
{   //Ha nem " a ", " ő ", " s "  rossz
    if (text[index] == ' '
        && text[index + 1] != '-'
        && text[index + 1] != 'a'
        && text[index + 1] != 'A'
        && text[index + 1] != 'ő'
        && text[index + 1] != 'Ő'
        && text[index + 1] != 's'
        && text[index + 1] != 'S'
        && text[index + 2] == ' '
       )
    {
        return true;
    }
    return false;
}

bool IsLinebreakAtTitle(int index)
{   //"Mr.◄┘", "Dr.◄┘", "dr.◄┘", "Mrs.◄┘"  rossz (true)
    if ((text[index] == 'D' || text[index] == 'd' || text[index] == 'M')
        && text[index + 1] == 'r'
        && text[index + 2] == '.'
        && text[index + 3] == 13
       )
    {
        return true;
    }
    if (text[index] == 'M'
        && text[index + 1] == 'r'
        && text[index + 2] == 's'
        && text[index + 3] == '.'
        && text[index + 4] == 13
       )
    {
        return true;
    }
    return false;
}

bool IsCapitaLetterInside(int index)
{   //"xX"  rossz (true)
    if (char.IsLower(text[index])
        && char.IsUpper(text[index + 1])
       )
    {
        return true;
    }
    return false;
}

bool IsFalseLineBreakAtName(int index)
{   //" x.◄┘"  rossz (true)
    if (text[index] == ' '
        && char.IsLetter(text[index + 1])
        && text[index + 2] == '.'
        && text[index + 3] == 13
       )
    {
        return true;
    }
    return false;
}

bool IsNewConversation(int index)
{   //"x.◄┘- "   jók
    if (char.IsLower(text[index])
        && (text[index + 1] == '.' || text[index + 1] == '!' || text[index + 1] == '?')
        && text[index + 2] == 13
        && text[index + 4] == '-'
        && text[index + 5] == ' '
           )
    {
        return true;
    }
    return false;
}

int action(int index)
{
    ConsoleKeyInfo a;
    do
    {
        if (index < 0) index = 0;
        if (index < text.Count && text[index] == 10) ++index;
        if (index > text.Count) index = text.Count;
        PrintText(index);

        a = Console.ReadKey();
        //Console.WriteLine("\n" + (int)a.KeyChar + " " + (int)a.Key);
        //Console.ReadKey();

        if (a.KeyChar == 0)
        {
            //pg up     0 33
            //pg down   0 34
            //balra     0 37
            //fel       0 38
            //jobbra    0 39
            //le        0 40
            //delete    0 46
            switch ((int)a.Key)
            {
                case 33: { index = FindBackward(index); break; }
                case 34: { return index; }
                case 37:
                    {
                        --index;
                        if (index > 0 && text[index] == 10) --index;
                        break;
                    }
                case 39: { ++index; break; }
                case 46: torles(index); break;
            }
            continue;
        }
        else
        {
            //backspace 8
            //enter     13
            //Esc       27 7 
            switch ((int)a.Key)
            {
                case 8: { --index; index = torles(index); continue; }
                case 13:
                    {
                        text.Insert(index, (char)10);
                        text.Insert(index, (char)13);
                        index += 2;
                        continue;
                    }
                case 27: { return text.Count; }
            }
            if (index > text.Count) index = text.Count;
            text.Insert(index, a.KeyChar);
            ++index;
        }
    } while (true);
}

void PrintText(int index)
{
    Console.Clear();
    ProgressBar(index);
    ShowInOneLine(index);
    ShowMoreLines(index);
}

///előrehaladás megjelenítése
void ProgressBar(int index)
{
    var originalColor = Console.ForegroundColor;
    Console.Write("Teljes méret: ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"{text.Count}");
    Console.ForegroundColor = originalColor;
    Console.Write("  Aktuális pozíció: ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{index}");
    Console.ForegroundColor = originalColor;
    Console.Write("  Haladás: ");

    int i = index * 40;
    i /= text.Count;
    ++i;
    i /= 2;
    Console.ForegroundColor = ConsoleColor.Green;
    for (int j = i; j > 0; --j)
    {
        Console.Write('█');
    }
    Console.ForegroundColor = ConsoleColor.Red;
    for (; i < 20; ++i)
    {
        Console.Write('░');
    }

    Console.ForegroundColor = originalColor;
    Console.WriteLine($" {index * 100 / text.Count}%\n");
}

///egy sorban egy kis részlet megjelenítése
void ShowInOneLine(int index)
{
    for (int i = index - 40; i < index; ++i)
        OneCharacterInFirstLine(i);
    var originalColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    OneCharacterInFirstLine(index);
    Console.ForegroundColor = originalColor;
    for (int i = index + 1; i < index + 40 && i < text.Count; ++i)
        OneCharacterInFirstLine(i);
    Console.WriteLine("\n\n______________________________________________________");
}

void OneCharacterInFirstLine(int index)
{
    if (index >= 0 && index < text.Count)
    {
        if (text[index] == 13 || text[index] == 10)
        {
            var originalColor = Console.ForegroundColor;
            if (originalColor != ConsoleColor.Red)
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(text[index] == 13 ? '◄' : '┘');
            Console.ForegroundColor = originalColor;
        }
        else if (text[index] == ' ' && Console.ForegroundColor == ConsoleColor.Red)
            Console.Write("█");
        else
            Console.Write(text[index]);
    }
    else
        Console.Write('░');
}

///nagyobb részlet megjelenítése
void ShowMoreLines(int index)
{
    for (int i = Math.Max(0, index - 300); i < index; ++i)
        Console.Write(text[i]);

    var originalColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    if (index < text.Count)
    {

        if (text[index] == 13)
            Console.WriteLine("◄┘");
        else if (text[index] == ' ')
            Console.Write('█');
        else if (text[index] != 10)
            Console.Write(text[index]);

        Console.ForegroundColor = originalColor;
        for (int i = index + 1; i < index + 300 && i < text.Count; ++i)
            Console.Write(text[i]);
    }
    else
        Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░VÉGE░░░░░░░░░░░░░░░░░░░░░░░");
    Console.ForegroundColor = originalColor;
}

int torles(int index)
{
    if (index < 0) index = 0;
    if (index >= text.Count) index = text.Count - 1;
    if (text[index] == 10 && index > 0)
        --index;
    if (text[index] == 13)
        text.RemoveRange(index, 2);
    else
        text.RemoveAt(index);
    return index;
}

int FindBackward(int index)
{
    try
    {
        for (int i = index - 1; i > 5; --i)
        {
            if (text[i] == 10) continue;
            if (IsCapitaLetterInside(i - 1))
            {
                return i;
            }
            if (IsInvalidOneLetterWord(i - 2))
            {
                return i - 1;
            }
            if (IsFalseLineBreakAtName(i - 5))
            {
                return i - 4;
            }
            if (IsLinebreakAtTitle(i - 5))
            {
                return i - 4;
            }
            if (i > text.Count - 5)
            {
                continue;
            }
            if (IsProperComa(i - 1))
            {
                continue;
            }
            if (IsProperDashInSentence(i - 2))
            {
                --i;
                continue;
            }
            if (IsProperDashInLine(i - 3))
            {
                i -= 2;
                continue;
            }
            if (IsNewConversation(i - 4))
            {
                i -= 3;
                continue;
            }
            if (IsParagraphEnd(i - 2))
            {
                --i;
                continue;
            }
            if (IsTripleDots(i - 4))
            {
                i -= 3;
                continue;
            }
            if (IsSentenceEnd(i - 1))
            {
                continue;
            }
            if (char.IsLetter(text[i])
                || text[i] == ' '
                || text[i] == 10)
                continue;
            return i;
        }
    }
    catch { }
    return 0;
}

/// A teljes szövegben gyanus helyek kézi átvizsgálása
void ManualCheck()
{
    try
    {
        for (int i = 0; i < text.Count - 5; ++i)
        {
            if (IsInvalidOneLetterWord(i)
                || IsLinebreakAtTitle(i)
                || IsCapitaLetterInside(i)
                || IsFalseLineBreakAtName(i)
               )
            {
                i = action(i + 1);
                continue;
            }
            if (IsProperComa(i))
            {
                ++i;
                continue;
            }
            if (IsSentenceEnd(i)
                || IsProperDashInSentence(i))
            {
                i += 2;
                continue;
            }
            if (IsProperDashInLine(i))
            {
                i += 3;
                continue;
            }
            if (IsTripleDots(i)
                || IsParagraphEnd(i))
            {
                i += 4;
                continue;
            }
            if (char.IsLetter(text[i])
                || text[i] == ' '
                || text[i] == 10)
                continue;
            i = action(i);
        }
        action(Math.Max(0, text.Count - 5));
        action(text.Count);
        Console.WriteLine("\nA fájl kézi átvizsgálása lezárult.");

    }
    catch (Exception e)
    {
        Console.WriteLine("Hiba történt a kézi átvizsgálás közben: " + e.Message);
    }
}

void ShowTheFullText()
{
    foreach (var c in text)
    {
        Console.Write(c);
    }
}

///Eredmény kiírása egy másik fájlba
void SaveTheResult(string inputFilePath)
{
    string outputFilePath = inputFilePath[..^4] + "2.txt";
    try
    {
        using (StreamWriter writer = new(outputFilePath))
        {
            foreach (char c in text)
            {
                writer.Write(c);
            }
        }
        Console.WriteLine($"A korrigált szöveg sikeresen kiírva ebbe az új fájlba:\n  {outputFilePath}");
    }
    catch (Exception e)
    {
        Console.WriteLine("Nem sikerült a fájlba mentés: " + e.Message);
    }
}

