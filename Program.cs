using System;

namespace Bulls_and_Cows
{
    class Program
    {
        // Основная часть кода, в которой заложен алгоритм игры.
        static void Main()
        {
            Console.WriteLine(Greeting());

            // Ввод числа и его проверка.

            string input = Console.ReadLine();

            // Разбиваем число придуманное компьютером, на массив, чтобы потом сравнить числа.

            int CreatedNum = RandomNumber(), Bulls = 0, k = 0;
            int[] NumbersOfRandom = new int[4];
            while (CreatedNum > 0)
            {
                NumbersOfRandom[k] = CreatedNum % 10;
                CreatedNum /= 10;
                k += 1;
            }
            // Основная часть программы, которая будет выполняться пока кол-во быков не будет 4 (условие победы).
            do
            {
                // Проверяем првильно ли игрок ввёл число

                if (!IsInputCorrect(input))
                {
                    Console.WriteLine("Incorrect input \n Попробуйте ввести еще раз");
                    input = Console.ReadLine();
                }
                else
                {
                    // Переводим число в массив чисел, чтобы сравнить цифры

                    int PlayerNum = int.Parse(input);
                    Bulls = 0;
                    int Cows = 0;
                    int[] NumbersOfPlayer = new int[4];
                    int i = 0;
                    while (PlayerNum > 0)
                    {
                        NumbersOfPlayer[i] = PlayerNum % 10;
                        PlayerNum /= 10;
                        i += 1;
                    }

                    // Ищем Количество быков и коров

                    for (i = 0; i < 4; i++)
                    {
                        if (NumbersOfPlayer[i] == NumbersOfRandom[i])
                            Bulls += 1;
                        // Вычисляем кол - во коров
                        for (int j = 0; j < 4; j++)
                        {

                            if ((i != j) && (NumbersOfPlayer[i] == NumbersOfRandom[j]))
                                Cows += 1;
                        }
                    }

                    // Вывод количества коров и быков, если 4 быка, то спрашиваем у игрока на счёт повторного выполнения программы. 

                    Console.WriteLine($"Cows: {Cows}. Bulls: {Bulls}");
                    if (Bulls == 4)
                    {
                        // Вывод при победе.

                        Console.WriteLine("УРА ПОБЕДА! \n Поздравляю, вы угалали загаданное число! \n Если хотите сыграть еще раз, нажмите введите 'Y'. \n Если Хотите выйти из игры, введите любой символ.");
                        string RepeatIndex = Console.ReadLine();
                        if ((RepeatIndex == "Y") | (RepeatIndex == "y"))
                        {
                            // Повторная генерация числа и разбитие его на массив.
                            Console.WriteLine(Greeting());
                            input = Console.ReadLine();
                            CreatedNum = RandomNumber();
                            Bulls = 0;
                            k = 0;
                            while (CreatedNum > 0)
                            {
                                NumbersOfRandom[k] = CreatedNum % 10;
                                CreatedNum /= 10;
                                k += 1;
                            }
                        }
                    }
                    else
                    {
                        // Вывод если не угадал.
                        Console.WriteLine("Почти!Попробуйте еще раз.");
                        input = Console.ReadLine();
                    }
                }
            } while (Bulls != 4);
        }
        // Этот метод проверяет, есть ли в числе повторяющиеся цифры.
        private static bool IsNumbersCorrect(int y)
        {
            int n1, n2, n3, n4;
            n1 = y / 1000;
            n2 = (y / 100) % 10;
            n3 = (y / 10) % 10;
            n4 = y % 10;
            if ((n1 == n2) | (n1 == n3) | (n1 == n4) | (n2 == n3) | (n2 == n4) | (n3 == n4))
                return false;
            else
                return true;
        }
        // Этот метод проверяет правильно ли игрок ввёл число.
        private static bool IsInputCorrect(string a)
        {
            int x;
            if (!int.TryParse(a, out x))
                return false;
            else if ((x > 999) && (x < 10000) && (IsNumbersCorrect(x)))
                return true;
            else
                return false;
        }
        // Этот метод генерирует случайное число.
        private static int RandomNumber()
        {
            int value;
            Random rand = new Random();
            do
            {
                value = rand.Next(1000, 10000);
                // Генерируем четырёхзначное число, в котором не будет повторяющихся чисел.
            } while (!IsNumbersCorrect(value));
            return value;

        }
        // Я создал отдельный метод для приветствия, чтобы не засорять основной код
        private static string Greeting()
        {
            string Greet = ("Привет! Поиграем? \n" +
            + " Игра называется 'Быки и коровы'. Суть игры проста: компьютер загадывает четырёхзначное число, состоящее из неповторяющихся чисел. \n" +
            + " После ввода числа выходит 2 значения: коровы - Cows (правильные цифры, но находящиеся не на своём месте) и быки - Bulls (правильные цифры, находящиеся на нужных местах).\n" +
            + " Удачи! ");
            return Greet;
        }

    }
}

