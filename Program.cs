using System;

class MainClass
{

    (string Name, string LastName, int Age, bool HasPet, string[] PetsName, string[] FavColors) User;

    public static void Main(string[] args)
    {
        IsHasPet();
    }

    static (string Name, string LastName, int Age) GetUserData() 
    {
        Console.WriteLine("Введите имя");

        string name = Console.ReadLine();

        Console.WriteLine("Введите фамилию");

        string lastName = Console.ReadLine();

        Console.WriteLine("Введите ваш возраст");

        byte age = Convert.ToByte(Console.ReadLine());

        var userData = (name, lastName, age);

        return userData;
    }

    static (bool HasPet, string[] petsName) IsHasPet()
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
                pets_name = new string[num_pets];
                var res = PetsName(num_pets);
                for (int i = 0; i < res.Length; i++)
                {
                    pets_name[i] = res[i];
                }
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
}