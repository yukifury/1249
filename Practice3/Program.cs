using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Practice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<note> Notelist = new List<note>();
            IEnumerable<note> CurrentNoteList = new List<note>();
            note note1 = new note();
            note1.Name = "Вскрыть вены";
            note1.Date = DateTime.Today;
            note1.Descrtiption = "Просто сдохнуть";
            Notelist.Add(note1);
            DateTime dateTime = DateTime.Today;
            dateTime = dateTime.AddDays(1);
            note note2 = new note();
            note2.Name = "TestNote";
            note2.Date = dateTime;
            note2.Descrtiption = "тестируем";
            Notelist.Add(note2);
            note note3 = new note();
            note3.Date = dateTime;
            note3.Name = "ok";
            note3.Descrtiption = "okuu";
            Notelist.Add(note3);

            int day = 1;
            int returnint = 0;
            int position = 1;
            int countnote = 1;
            note selectedNote = null;
            DateTime Time = DateTime.Today; 
            CurrentNoteList = Day(DateTime.Today, Notelist);
            string TimeScreen1 = Time.ToShortDateString();
            selectedNote = CurrentNoteList.ElementAtOrDefault(position - 1);

            Console.WriteLine($"{TimeScreen1}");
            foreach (var note in CurrentNoteList)
            {
                Console.WriteLine($"   {countnote}.{note.Name}");
            }
            countnote = 1;
            Console.WriteLine("\n\n   Нажмите G чтобы добавить заметку.");
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            selectedNote = CurrentNoteList.ElementAtOrDefault(position - 1);
            while (true)
            {

                ConsoleKeyInfo key = Console.ReadKey();
                
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (selectedNote != null)
                    {
                        Console.WriteLine("-----------------\n");
                        Console.WriteLine(selectedNote.Descrtiption);
                        Console.WriteLine("\n----------------");
                        
                        Thread.Sleep(500);

                        Console.WriteLine("\nНажмите на Esc для продолжения..");
                        position = 1;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                        Console.ReadKey();
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    position++;
                    Console.Clear();
                    Time = Time;
                    CurrentNoteList = Day(Time, Notelist);
                    string TimeScreen = Time.ToShortDateString();
                    Console.WriteLine(TimeScreen);
                    foreach (var note in CurrentNoteList)
                    {
                        Console.WriteLine($"   {countnote}.{note.Name}");
                        countnote++;
                    }
                    countnote = 1;
                    Console.WriteLine("\n\n   Нажмите G чтобы добавить заметку.");
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    selectedNote = CurrentNoteList.ElementAtOrDefault(position - 1);
                }
                else if (key.Key == ConsoleKey.UpArrow & position != 1)
                {
                    position--;
                    Console.Clear();
                    Time = Time;
                    CurrentNoteList = Day(Time, Notelist);
                    string TimeScreen = Time.ToShortDateString();
                    Console.WriteLine(TimeScreen);
                    foreach (var note in CurrentNoteList)
                    {
                        Console.WriteLine($"   {countnote}.{note.Name}");
                        countnote++;
                    }
                    countnote = 1;

                    Console.WriteLine("\n\n   Нажмите G чтобы добавить заметку.");
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    selectedNote = CurrentNoteList.ElementAtOrDefault(position - 1);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.Clear();
                    day++;
                    Time = Time.AddDays(1);
                    CurrentNoteList = Day(Time, Notelist);
                    string TimeScreen = Time.ToShortDateString();
                    Console.WriteLine(TimeScreen);
                    foreach (var note in CurrentNoteList)
                    {
                        Console.WriteLine($"   {countnote}.{note.Name}");
                        countnote++;
                    }
                    countnote = 1;
                    Console.WriteLine("\n\n   Нажмите G чтобы добавить заметку.");
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    selectedNote = CurrentNoteList.ElementAtOrDefault(position - 1);
                    position = 1;
                    


                }
                else if (key.Key == ConsoleKey.LeftArrow & Time != DateTime.Today)
                {
                    Console.Clear();
                    day--;
                    Time = Time.AddDays(-1);
                    CurrentNoteList = Day(Time, Notelist);
                    string TimeScreen = Time.ToShortDateString();
                    Console.WriteLine(TimeScreen);
                    foreach (var note in CurrentNoteList)
                    {
                        Console.WriteLine($"   {countnote}.{note.Name}");
                        countnote++;
                    }
                    countnote = 1;
                    Console.WriteLine("\n\n    Нажмите G чтобы добавить заметку.");
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    selectedNote = CurrentNoteList.ElementAtOrDefault(position - 1);
                    position = 1;
                    


                }
                else if (key.Key == ConsoleKey.G)
                {
                    Console.Clear();
                    Console.WriteLine("Введите название заметки:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите основной текст заметки:");
                    string text = Console.ReadLine();
                    Notelist.Add(new note() { Date = Time, Name = name, Descrtiption = text });
                    position = 1;
                    Console.WriteLine("Нажмите Esc для продолжения..");
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Time = Time;
                    CurrentNoteList = Day(Time, Notelist);
                    string TimeScreen = Time.ToShortDateString();
                    Console.WriteLine(TimeScreen);
                    foreach (var note in CurrentNoteList)
                    {
                        Console.WriteLine($"   {countnote}.{note.Name}");
                        countnote++;
                    }
                    countnote = 1;
                    Console.WriteLine("\n\n   Нажмите G чтобы добавить заметку.");
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    selectedNote = CurrentNoteList.ElementAtOrDefault(position - 1);
                    position = 1;
                }
                else
                {
                    Console.Clear();
                    Time = Time;
                    CurrentNoteList = Day(Time, Notelist);
                    string TimeScreen = Time.ToShortDateString();
                    Console.WriteLine(TimeScreen);
                    foreach (var note in CurrentNoteList)
                    {
                        Console.WriteLine($"   {countnote}.{note.Name}");
                        countnote++;
                    }
                    countnote = 1;
                    Console.WriteLine("\n\n   Нажмите G чтобы добавить заметку.");
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    selectedNote = CurrentNoteList.ElementAtOrDefault(position - 1);
                    position = 1;
                    
                }
            }
        }

        static IEnumerable<note> Day(DateTime Date, List<note> NoteList)
        {
            var DaysNotes =
              from note in NoteList
              where note.Date == Date
              select note;


            return DaysNotes;
            
        }

    }
}
