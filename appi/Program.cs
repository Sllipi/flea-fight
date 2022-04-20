using System;
using System.Threading;

namespace appi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int hpSpider = rnd.Next(300, 500);
            int damageSpider;
            int hpPlayer = rnd.Next(150, 350);
            int manaPlayer = rnd.Next(100, 400);
            bool startGame = true;
            string castspell;

while (startGame && startGame == true)
            {
                Console.Clear();
                Console.WriteLine(@"Мульти-блоха нападает приготовьтесь к бою!!!!!!

Выберите заклинания для атаки или лечения: 
1. Спрей - наносит 50 урона, отнимает 15 единиц маны.
2. Востанавливает игроку  20 здоровья, отнимает 30 единиц маны.
3. Электро разряд - наносит 100 урона, отнимает 50 единиц маны.
4. Огненый дождь - наносит 35 урона каждую секунду, отнимает 120 единиц маны.
5. Прилив маны - восстанавливет 25 едениц манны каждую секунду, но увиличивает урон Мульти-блохи в 2 раза.
6. Выход.");

                if (manaPlayer <= 15)
                {
                    startGame = false;
                    Console.WriteLine("\nИгра окончена, недостаточно маны для продолжения битвы");
                }
                else if (hpSpider <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nМульти-блоха погибла");
                }
                else if (hpPlayer <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nИгрок погиб");
                }
                else
                {
                    damageSpider = rnd.Next(20, 85);
                    Console.WriteLine($"\nСтатистика Мульти-блохи: \n Здоровье: {hpSpider} , Урон: {damageSpider} " +
                        $"\n\nСтатистика игрока: \n Здоровье: {hpPlayer} , Мана: {manaPlayer} \n");
                    Console.Write("Введите заклинание: ");
                    castspell = Console.ReadLine();

                    switch (castspell)
                    {
                        case "1":
                            if (manaPlayer >= 15)
                            {
                                hpSpider -= 40;
                                Console.WriteLine("\nМульти-блоха потеряла 50 единиц здоровья");
                                manaPlayer -= 15;
                                hpPlayer -= damageSpider;
                                Console.Write($"\nМульти-блоха атаковала ядом игрок потерял {damageSpider} здоровья\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "2":
                            if (manaPlayer >= 30)
                            {
                                manaPlayer -= 30;
                                hpPlayer += 20;
                                Console.WriteLine($"\nВаше текущее здоровье равно: {hpPlayer}");
                            }
                            else if (hpPlayer >= 349)
                            {
                                Console.WriteLine("\nУ вас полный запас здоровья");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "3":
                            if (manaPlayer >= 50)
                            {
                                Console.WriteLine("\nМульти-блоха потеряла 100 единиц здоровья");
                                hpSpider -= 100;
                                manaPlayer -= 50;
                                hpPlayer -= damageSpider;
                                Console.Write($"\nМульти-блоха выпустила маленьких блох которые нанесли {damageSpider} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "4":
                            if (manaPlayer >= 120)
                            {
                                int rockrain = 0;
                                for (int i = 1; i < 6; i++)
                                {
                                    rockrain += 35;
                                    Thread.Sleep(1000);
                                    hpSpider -= 35;
                                    Console.Write($"Атака огненым дождем наносит урон мульте-блохе {rockrain}:  \nПродолжительность атаки {i} секунды");
                                    Console.WriteLine();
                                }
                                Console.WriteLine("\nМульти-блоха потеряла после атаки 175 единиц здоровья");
                                manaPlayer -= 40;
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        case "5":
                            int mp = 0;
                            for (int i = 1; i < 4; i++)
                            {
                                mp += 25;
                                Thread.Sleep(1000);
                                Console.Write($"Вы восстановили себе {mp} едениц манны:  \nПродолжительность атаки {i} секунды");
                                Console.WriteLine();
                            }
                            Console.WriteLine($"\nВы восстановили 75 едениц манны и получили {damageSpider * 2}");
                            manaPlayer += 75;
                            hpPlayer -= damageSpider * 2;
                            break;
                        case "6":
                            startGame = false;
                            Console.WriteLine("Всего дброго!");
                            break;
                    }

                }
                Console.Write("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();

            }
        }
    }
}
