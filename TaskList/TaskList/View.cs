using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList
{
    public class View
    {
        private static Controller controller;
        public static void start()
        {
                Console.WriteLine("Starting...");
                controller = new Controller();
                controller.start();
                do
                {
                    Menu();
                    try
                    {
                        switch (int.Parse(Console.ReadLine() ?? string.Empty))
                        {
                            case 1:
                                add();
                                break;
                            case 2:
                                update();
                                break;
                            case 3:
                                get();
                                break;
                            case 4:
                                filterPrio();
                                break;
                            case 5:
                                filterTime();
                                break;
                            case 6:
                                remove();
                                break;

                            case 9:
                                System.Environment.Exit(1);
                                break;

                            default:
                                Console.WriteLine("Ein Fehler ist aufgetretten bitte versuche es nochmal!");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e + " Ein Fehler ist aufgetretten. Wir retten Sie zurück ins Menu!");
                    }
                } while (true);

        }

        public static void Menu()
        {
            Console.WriteLine("------------Menu----------------");
            Console.WriteLine("Geben Sie eine Zahl ein");
            Console.WriteLine("1: Hinzufügen");
            Console.WriteLine("2: Updaten");
            Console.WriteLine("3: Alle Anzeigen");
            Console.WriteLine("4: Filter: Prioritaet");
            Console.WriteLine("5: Filter: Faelligkeitsdatum"); 
            Console.WriteLine("6: Loeschen");
            Console.WriteLine("9: Shutdown");
            Console.WriteLine("-------------------------------");

        }

        private static void add()
        {
            try
            {
                add:
                Task t = new Task();
                Console.WriteLine("Faehilkeitsdatum der Task? (Tag.Monat.Jahr)");
                t.dueTime = DateTime.Parse(Console.ReadLine());
                if (t.dueTime < DateTime.Now)
                    goto add;
                Console.WriteLine("Name der Task?");
                t.name = Console.ReadLine();
                Console.WriteLine("Prioritaet der Task?");
                t.priority = int.Parse(Console.ReadLine());
                if (controller.add(t))
                    Console.WriteLine("Task wurde hinzugefügt!");
                else
                    Console.WriteLine("Task konnte nicht hinzugefügt werden! Sie werden ins Menu umgeleitet!");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e+" Ein Fehler ist aufgetretten. Wir retten Sie zurück ins Menu!");
            }
        }

        private static void update()
        {
            try
            {
                Console.WriteLine("Welche ID hat die Task?");
                Task t = new Task();
                t.id = int.Parse(Console.ReadLine());
                update:
                Console.WriteLine("Faehilkeitsdatum der Task? (Tag.Monat.Jahr)");
                t.dueTime = DateTime.Parse(Console.ReadLine());
                if (t.dueTime < DateTime.Now)
                    goto update;
                Console.WriteLine("Name der Task?");
                t.name = Console.ReadLine();
                Console.WriteLine("Prioritaet der Task?");
                t.priority = int.Parse(Console.ReadLine());

                if (controller.update(t))
                    Console.WriteLine("Task wurde geupdatet!");
                else
                    Console.WriteLine("Task konnte nicht geupdatet werden! Sie werden ins Menu umgeleitet!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e+" Ein Fehler ist aufgetretten. Wir retten Sie zurück ins Menu!");
            }
        }

        private static void remove()
        {
            try
            {
                Console.WriteLine("Welche ID hat die Task?");
                Task t = new Task();
                t.id = int.Parse(Console.ReadLine());

                if (controller.delete(t))
                    Console.WriteLine("Task wurde Geloescht!");
                else
                    Console.WriteLine("Task konnte nicht Geloescht werden! Sie werden ins Menu umgeleitet!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Ein Fehler ist aufgetretten. Wir retten Sie zurück ins Menu!");
            }
        }

        private static void get()
        {
            try
            {
                foreach (Task task in controller.get())
                {
                    Console.WriteLine(task.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Ein Fehler ist aufgetretten. Wir retten Sie zurück ins Menu!");
            }
        }

        private static void filterPrio()
        {
            try
            {
                foreach (Task task in controller.filterPriority())
                {
                    Console.WriteLine(task.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Ein Fehler ist aufgetretten. Wir retten Sie zurück ins Menu!");
            }
        }

        private static void filterTime()
        {
            try
            {
                foreach (Task task in controller.filterTime())
                {
                    Console.WriteLine(task.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e + " Ein Fehler ist aufgetretten. Wir retten Sie zurück ins Menu!");
            }
        }
    }
}
