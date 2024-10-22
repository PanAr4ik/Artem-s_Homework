using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Grade: {Grade:F2}";
    }
}

class Program
{
    static List<Student> students = new List<Student>();
    const string filePath = "E:\\Projekts\\С#\\AsiCodeL_Shcool\\Lesson 19 10 2024\\students.json";

    static void Main(string[] args)
    {
        LoadFromFile();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Показать всех студентов");
            Console.WriteLine("3. Сохранить студентов в файл");
            Console.WriteLine("4. Загрузить студентов из файла");
            Console.WriteLine("5. Редактировать студента");
            Console.WriteLine("6. Удалить студента");
            Console.WriteLine("0. Выйти");

            Console.Write("\nВведите номер действия: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ShowStudents();
                    break;
                case "3":
                    SaveToFile();
                    break;
                case "4":
                    LoadFromFile();
                    break;
                case "5":
                    EditStudent();
                    break;
                case "6":
                    DeleteStudent();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();

        Console.Write("Введите возраст студента: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Введите оценку студента: ");
        double grade = double.Parse(Console.ReadLine());

        students.Add(new Student(name, age, grade));
        Console.WriteLine("Студент добавлен!");
    }

    static void ShowStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("Список студентов пуст.");
            return;
        }

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {students[i]}");
        }
    }

    static void SaveToFile()
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine("Данные сохранены в файл.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
        }
    }

    static void LoadFromFile()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            Console.WriteLine("Данные загружены из файла.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке: {ex.Message}");
        }
    }

    static void EditStudent()
    {
        ShowStudents();

        Console.Write("Введите номер студента для редактирования: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < students.Count)
        {
            Console.Write("Введите новое имя (оставьте пустым, если не нужно менять): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                students[index].Name = newName;

            Console.Write("Введите новый возраст (оставьте пустым, если не нужно менять): ");
            string newAge = Console.ReadLine();
            if (int.TryParse(newAge, out int age))
                students[index].Age = age;

            Console.Write("Введите новую оценку (оставьте пустым, если не нужно менять): ");
            string newGrade = Console.ReadLine();
            if (double.TryParse(newGrade, out double grade))
                students[index].Grade = grade;

            Console.WriteLine("Данные студента обновлены.");
        }
        else
        {
            Console.WriteLine("Некорректный номер студента.");
        }
    }

    static void DeleteStudent()
    {
        ShowStudents();

        Console.Write("Введите номер студента для удаления: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < students.Count)
        {
            students.RemoveAt(index);
            Console.WriteLine("Студент удален.");
        }
        else
        {
            Console.WriteLine("Некорректный номер студента.");
        }
    }
}
