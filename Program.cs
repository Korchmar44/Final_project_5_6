class MainClass
{

    

    public static void Main(string[] args)
    {
        var user = GetUserData();

        Console.WriteLine($"Имя пользователя: {user.name},\nФамилия пользователя: {user.lastName},\nВозрасте пользователя: {user.age}\n");

        if (user.petsName.Length == 1)
        {
            Console.WriteLine($"У пользователя 1 питомец по кличке\n{string.Join("\n ", user.petsName)}\n");
        }
        else if ((user.petsName.Length >= 2) && (user.petsName.Length < 5))
        {
            Console.WriteLine($"У пользователя {user.petsName.Length} питомца с кличками\n{string.Join("\n", user.petsName)}\n");
        }
        else if ((user.petsName.Length >= 5))
        {
            Console.WriteLine($"У пользователя {user.petsName.Length} питомцев с кличками\n{string.Join("\n", user.petsName)}\n");
        }
        else
        {
            Console.WriteLine("У пользователя нет питомцев\n");
        }

        if (user.colorsName.Length == 1)
        {
            Console.WriteLine($"У пользователя 1 любимый цвет\n{string.Join(" ", user.colorsName)}\n");
        }
        else if ((user.colorsName.Length >= 2) && (user.colorsName.Length < 5))
        {
            Console.WriteLine($"У пользователя {user.colorsName.Length} любимых цвета\n{string.Join("\n", user.colorsName)}\n");
        }
        else if ((user.colorsName.Length >= 5))
        {
            Console.WriteLine($"У пользователя {user.colorsName.Length} любимых цветов\n{string.Join("\n", user.colorsName)}\n");
        }
        else
        {
            Console.WriteLine("У пользователя нет любимых цветов\n");
        }
    }

    static (string name, string lastName, int age, string[] petsName, string[] colorsName) GetUserData()
    {
        (string Name, string LastName, int Age, string[] PetsName, string[] FavColors) User;

        Console.WriteLine("Введите имя");
        User.Name = CheckStringData(Console.ReadLine());

        Console.WriteLine("Введите фамилию");
        User.LastName = CheckStringData(Console.ReadLine());

        Console.WriteLine("Введите ваш возраст");
        User.Age = Convert.ToInt32(CheckIntData(Console.ReadLine()));

        User.PetsName = IsHavePet();

        User.FavColors = FavColor();



        return User;
    }

    static string CheckStringData(string str) 
    {
        bool correctData = false;

        do
        {
            if (System.String.IsNullOrEmpty(str) || System.String.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Данные не могут быть пустой строкой или состоять из пробелов\nНеобходимо заново внести данные");
                CheckStringData(Console.ReadLine());
            }
            else if (int.TryParse(str, out int number))
            {
                Console.WriteLine("Необходимо заново ввести тексторвые данные");
                CheckStringData(Console.ReadLine());
            }
            else
            {
                correctData = true;
            }
        } while (correctData == false);
        
        return str;
    }

    static int CheckIntData(string num)
    {
        bool correctData = false;

        do
        {
            if (int.TryParse(num, out int number) && number <= 0)
            {
                Console.WriteLine("Возраст не может быть меньше или равет 0.  Необходимо заново ввести данные");
                CheckIntData(Console.ReadLine());
            }
            else if (!int.TryParse(num, out int is_number))
            {
                Console.WriteLine("Число не распознано, Необходимо заново ввести данные");
                CheckIntData(Console.ReadLine());
            }
            else
            {
                correctData = true;
            }
        } while (correctData == false);

        return Convert.ToInt32(num);
    }

    static string[] IsHavePet()
    {
        bool havePet = false;
        int petsNumber = 0;
        string[] petsName;

        Console.WriteLine("У вас есть домашний питомец? (да/нет)");
        if (Console.ReadLine() == "да") havePet = true;

        if (havePet)
        {
            Console.WriteLine("Введите колличество питомцев");
            petsNumber = Convert.ToByte(Console.ReadLine());
            if (petsNumber <= 0)
            {
                Console.WriteLine("Вы указали то, что у вас есть питомцы поэтому Колличество питомцев не может быть меньше или равно нулю ");
                IsHavePet();
            }
        }
        return petsName = PetsName(petsNumber);
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
        int numColors = Convert.ToByte(Console.ReadLine());

        Console.WriteLine("Введите любимые цвета пользователя");
        string[] favColors = new string[numColors];
        int counter = 0;
        while (counter < numColors)
        {
            favColors[counter] = Console.ReadLine();
            counter++;
            Console.WriteLine("Следующий цвет");
        }
        Console.WriteLine("Готово\n\n");

        Console.Clear();
        return favColors;
    }
}