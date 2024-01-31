using System;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

class MainClass
{

    //(string Name, string LastName, int Age, bool HasPet, string[] PetsName, string[] FavColors) User;

    public static void Main(string[] args)
    {
        
        var user = GetUserData();
        Console.WriteLine(user);
        
    }

    static (string name, string lastName, int age/*, string[] petsName, string[] colorsName*/) GetUserData() 
    {
        Console.WriteLine("Введите имя");
        string name = CheckStringData(Console.ReadLine());

        Console.WriteLine("Введите фамилию");
        string lastName = CheckStringData(Console.ReadLine());

        Console.WriteLine("Введите ваш возраст");
        int age =Convert.ToInt32(CheckIntData(Console.ReadLine()));

        Console.Clear();
       var userData = (name, lastName, age/*, petsName,*/ );

        return userData;
    }

    static string CheckStringData(string? str) 
    {
        bool correctData = false;

        do
        {
            if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Данные не могут быть пустой строкой или состоять из пробелов\nНеобходимо заново внести данные");
                GetUserData();
            }
            else if (int.TryParse(str, out int number))
            {
                Console.WriteLine("Необходимо заново ввести тексторвые данные");
                GetUserData();
            }
            else
            {
                correctData = true;
            }
        } while (correctData == false);
        
        return str;
    }

    static int CheckIntData(string? num)
    {
        bool correctData = false;

        do
        {
            if (int.TryParse(num, out int number) && number <= 0)
            {
                Console.WriteLine("Возраст не может быть меньше или равет 0.  Необходимо заново ввести данные");
                GetUserData();
            }
            else if (!int.TryParse(num, out int is_number))
            {
                Console.WriteLine("Число не распознано, Необходимо заново ввести данные");
                GetUserData();
            }
            else
            {
                correctData = true;
            }
        } while (correctData == false);

        return Convert.ToInt32(num);
    }

    static (bool HasPet, string[] PetsName) IsHasPet()
    {
        bool hasPet = false;
        string[] pets_name = null;

        Console.WriteLine("У вас есть домашний питомец? (да/нет)");

        if (Console.ReadLine() == "да") hasPet = true;
        if (hasPet)
        {
            Console.WriteLine("Введите колличество питомцев");
            byte num_pets = Convert.ToByte(Console.ReadLine());
            if (num_pets <= 0) 
            {
                Console.WriteLine("Колличество питомцев не может быть меньше или равно нулю ");
                IsHasPet();
            }
            else
            {
                //pets_name = new string[num_pets];
                pets_name = PetsName(num_pets);
            }
        }
        var isHasPet = (hasPet, pets_name);
        return isHasPet;
    }

    static string[] PetsName(int number_pets)
    {
        string[] pets_name = new string[number_pets];

        for (int i = 0; i < pets_name.Length; i++)
        {
            Console.WriteLine("Введите имя {0} - го питомца", i+1);
            pets_name[i] = Console.ReadLine();
        }

        return pets_name;
    }

    static string[] FavColor()
    {
        Console.WriteLine("Введите колличество любимых цветов");
        byte numColors = Convert.ToByte(Console.ReadLine());

        Console.WriteLine("Введите любимые цвета пользователя");
        string[] favColors = new string[numColors];
        int counter = 0;
        while (counter < numColors)
        {
            favColors[counter] = Console.ReadLine();
            counter++;
            Console.WriteLine("Следующий цвет");
        }
        Console.WriteLine("Готово");

        return favColors;
    }

    //static (string Name, string LastName, int Age, bool HasPet, string[] PetsName, string[] FavColors) CheckNumber()
    //{
    //    (string Name, string LastName, int Age, bool HasPet, string[] PetsName, string[] FavColors) UserData;

    //    UserData.Name = GetUserData().Name;
    //    UserData.LastName = GetUserData().LastName;
    //    UserData.Age = GetUserData().Age;
    //    UserData.HasPet = IsHasPet().HasPet;
    //    UserData.PetsName = IsHasPet().PetsName;
    //    UserData.FavColors = FavColor();

    //    return UserData;
    //}
}