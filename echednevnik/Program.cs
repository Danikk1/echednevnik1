class Program
{
    private static List<Note> notes;
    private static int selectedDateIndex;

    static void Main()
    {
        InitializeNotes();

        ConsoleKey key;

        do
        {
            Console.Clear();
            ShowNoteMenu();
            key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    SelectPreviousDate();
                    break;
                case ConsoleKey.RightArrow:
                    SelectNextDate();
                    break;
                case ConsoleKey.Enter:
                    ShowNoteDetails(notes[selectedDateIndex]);
                    break;
            }
        } while (key != ConsoleKey.Escape);
    }

    static void InitializeNotes()
    {
        notes = new List<Note>
        {
            new Note("Заметка 1", "Описание 1", new DateTime(2023, 10, 10)),
            new Note("Заметка 2", "Описание 2", new DateTime(2023, 10, 11)),
            new Note("Заметка 3", "Описание 3", new DateTime(2023, 10, 12)),
            new Note("Заметка 4", "Описание 4", new DateTime(2023, 10, 13)),
            new Note("Заметка 5", "Описание 5", new DateTime(2023, 10, 14)),
        };

        selectedDateIndex = 0;
    }

    static void ShowNoteMenu()
    {
        Console.WriteLine("Ежедневник\n");
        for (int i = 0; i < notes.Count; i++)
        {
            string dateLabel = i == selectedDateIndex ? ">> " : "   ";
            Console.WriteLine($"{dateLabel}{notes[i].Date:dd.MM.yyyy} - {notes[i].Title}");
        }
        Console.WriteLine("\nИспользуйте стрелки влево и вправо для навигации, Enter для просмотра деталей, Esc для выхода.");
    }

    static void SelectPreviousDate()
    {
        if (selectedDateIndex > 0)
            selectedDateIndex--;
    }

    static void SelectNextDate()
    {
        if (selectedDateIndex < notes.Count - 1)
            selectedDateIndex++;
    }

    static void ShowNoteDetails(Note note)
    {
        Console.Clear();
        Console.WriteLine($"Дата: {note.Date:dd.MM.yyyy}");
        Console.WriteLine($"Название: {note.Title}");
        Console.WriteLine($"Описание: {note.Description}");
        Console.WriteLine($"Должно быть выполнено: {note.DueDate:dd.MM.yyyy}\n");
        Console.WriteLine("Нажмите Enter, чтобы вернуться к списку заметок.");
        while (Console.ReadKey().Key != ConsoleKey.Enter) ;
    }
}

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
        DueDate = date;
    }
}
