using System;

namespace TicketSystem
{
    internal class Program
    {
        public static int TotalCreated10 = 0;
        public static int TotalSold10 = 0;
        public static int TotalCreated20 = 0;
        public static int TotalSold20 = 0;
        public static int TotalCreated30 = 0;
        public static int TotalSold30 = 0;

        public static void Main(string[] args)
        {
            bool isAlive = true;
           
            while (isAlive)
            {
                Console.WriteLine("1 Pirkti Bilietus");
                Console.WriteLine("2 Kurti Bilietus");
                Console.WriteLine("3 Kiek sukusta ir kiek parduota biletų");

                if (Int32.TryParse(Console.ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case 1:
                            BuyTickets();
                            break;
                        case 2:
                            CreateTickets();
                            break;
                        case 3:
                            TiketReport();
                            break;
                        default:
                            Console.WriteLine("No such selection");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You entered not the number !!!!");
                }

               

            }
            static void TiketReport()
            {
                Console.Clear();
                Console.WriteLine("Bilietų pardavimų ataskaita");
                Console.WriteLine($" sukurta 10e bilietų : {TotalCreated10}");
                Console.WriteLine($" Parduota 10e bilietų: {TotalSold10}");
                Console.WriteLine($" Napanaudoti 10e bilietai {TotalCreated10 - TotalSold10}");
                Console.WriteLine($" sukurta 20e bilietų : {TotalCreated20}");
                Console.WriteLine($" Parduota 20e bilietų: {TotalSold20}");
                Console.WriteLine($" Napanaudoti 20e bilietai {TotalCreated20 - TotalSold20}");
                Console.WriteLine($" sukurta 30e bilietų : {TotalCreated30}");
                Console.WriteLine($" Parduota 30e bilietų: {TotalSold30}");
                Console.WriteLine($" Napanaudoti 30e bilietai {TotalCreated30 - TotalSold30}");
                Console.ReadLine();
            }
        }

        private static void CreateTickets()
        {
            Console.Clear();
            Console.WriteLine("Pasirinkite bil. Tipą: [1] Po 10€, [2] Po 20€, [3] Po 30€");

            if (Int32.TryParse(Console.ReadLine(), out int ticketType))
            {
                Console.WriteLine("Kiek tokių bilietų norėsite sukurti?");
                if (Int32.TryParse(Console.ReadLine(), out int ticketsAmount))
                {
                    switch (ticketType)
                    {
                        case 1:
                            TotalCreated10 = TicketCreted(ticketsAmount, TotalCreated10);
                            break;
                        case 2:
                            TotalCreated20 = TicketCreted(ticketsAmount, TotalCreated20);
                            break;
                        case 3:
                            TotalCreated30 = TicketCreted(ticketsAmount, TotalCreated30);
                            break;
                        default:
                            Console.WriteLine("No such selection");
                            CreateTickets();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You entered not the number !!!!");
                }
            }
            else
            {
                Console.WriteLine("You entered not the number !!!!");
                CreateTickets();
            }
        }

        private static int TicketSold(int ticketsAmount, int ticketTypeSoldAmount, int ticketTypeCreatedAmount)
        {
            if (ticketTypeCreatedAmount - ticketTypeSoldAmount >= ticketsAmount)
            {
                return ticketTypeSoldAmount += ticketsAmount;

            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Mes tik turime {ticketTypeCreatedAmount - ticketTypeSoldAmount}");
                Console.WriteLine();
                return TotalSold10;
            }
          
        }

        private static int TicketCreted(int ticketsAmount, int ticketTypeAmount)
        {
            
            return ticketTypeAmount += ticketsAmount;
        }

        private static void BuyTickets()
        {
            Console.Clear();  
            Console.WriteLine("Pasirinkite bil. Tipą: [1] Po 10€, [2] Po 20€, [3] Po 30€, kuriuos norėsite pirkti");
                      
            if (Int32.TryParse(Console.ReadLine(), out int ticketType))
            {
                Console.WriteLine("Kiek tokių bilietų norėsite pirkti?");
                if (Int32.TryParse(Console.ReadLine(), out int ticketsAmount))
                {
                    switch (ticketType)
                    {
                        case 1:
                            TotalSold10 = TicketSold(ticketsAmount, TotalSold10, TotalCreated10); 
                            break;
                        case 2:
                            TotalSold20 = TicketSold(ticketsAmount, TotalSold20, TotalCreated20);
                            break;
                        case 3:
                            TotalSold30 = TicketSold(ticketsAmount, TotalSold30, TotalCreated30);
                            break;

                        default:
                            Console.WriteLine("No such selection");
                            BuyTickets();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("You entered not the number !!!!");
                }
            }
            else
            {
                Console.WriteLine("You entered not the number !!!!");
                BuyTickets();
            }
            
        }
    }
}
