using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupportTicketSystem.Data;
using SupportTicketSystem.Data.Models;

namespace SupportTicketSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Build configuration
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            // Build service provider
            var services = new ServiceCollection()
                .AddDbContext<SupportTicketDbContext>()
                .BuildServiceProvider();

            // Resolve DbContext
            using var scope = services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SupportTicketDbContext>();

            // Ask if user is customer or support

                switch (choice)
                {
                    case "1":
                        break;

                    case "2":
                        var tickets = dbContext.Tickets
                            .Include(x => x.Customer)
                            .ToList();

                        foreach (var ticket in tickets)
                        {
                            Console.WriteLine(
                                $" Ticket id: {ticket.TicketId}, Description: {ticket.TicketDescription}, Ticket created: {ticket.TicketRegistered}");
                            Console.WriteLine(
                                "-----------------------------------------------------------------------------------------------------------");
                        }
                        Console.WriteLine("Klicka valfri tangent för att forsätta");
                        Console.ReadLine();


                            break;

                    case "3":
                        Console.WriteLine("Vänligen ange Ärende id (ticket id):");
                        var ticketId = Console.ReadLine();
                        var singleTicket = dbContext.Tickets
                            .Include(x => x.Customer)
                            .FirstOrDefault(x => x.TicketId == Convert.ToInt32(ticketId));

                        if (singleTicket == null)
                        {
                            Console.WriteLine("Hittade inte ärendet. Försök igen");
                            Console.WriteLine("Klicka valfri tangent för att forsätta");
                            Console.ReadLine();

                            }

                            Console.WriteLine(
                            $" Ticket id: {singleTicket.TicketId}, Description: {singleTicket.TicketDescription}, Ticket created: {singleTicket.TicketRegistered}");
                        Console.WriteLine(
                            "-----------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Klicka valfri tangent för att forsätta");
                        Console.ReadLine();

                            break;

                    case "4":
                        Console.WriteLine("Ange id för ärendet du vill byta status på:");
                        var ticketIdToChange = Console.ReadLine();
                        Console.WriteLine("Ange status: (EJ PÅBÖRJAD | PÅGÅENDE | AVSLUTAD");
                        var status = Console.ReadLine();
                        if (status == "EJ PÅBÖRJAD" || status == "PÅGÅENDE" || status == "AVSLUTAD")
                        {
                            var tickett = dbContext.Tickets.Find(Convert.ToInt32(ticketIdToChange));

                            if (tickett != null)
                            {
                                tickett.SupportComment = $"{status}";
                                dbContext.SaveChanges();
                                Console.WriteLine("Ärende uppdaterat");
                                Console.WriteLine("Klicka valfri tangent för att forsätta");
                                Console.ReadLine();

                                }
                            else
                            {
                                Console.WriteLine("Kunde inte hitta ärendet. Försök igen.");
                                Console.WriteLine("Klicka valfri tangent för att forsätta");
                                Console.ReadLine();

                                }

                            }
                        break;

                    case "5":
                        showMenu = false;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Välkommen kund");
                Console.WriteLine("----------------------------");

                Console.WriteLine("1. Skapa ärende");
                Console.WriteLine("2. Avsluta");
                    var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Förnamn:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Efternamn:");
                        var lastName = Console.ReadLine();
                        Console.WriteLine("Email:");
                        var email = Console.ReadLine();
                        Console.WriteLine("Tele nr:");
                        var phone = Console.ReadLine();
                        Console.WriteLine("Beskriv problemet:");
                        var problem = Console.ReadLine();

                        var customer = new Customer
                        {
                            CustomerName = firstName,
                            CustomerLastName = lastName,
                            CustomerEmail = email,
                            CustomerPhoneNr = phone,
                            Tickets = new List<Ticket>
                            {
                                new Ticket
                                {
                                    SupportComment = string.Empty,
                                    SupportCommentRegistered = DateTime.Now,
                                    TicketDescription = problem,
                                    TicketRegistered = DateTime.Now,
                                }
                            }
                        };

                        dbContext.Add(customer);
                        if (dbContext.SaveChanges() == 0)
                        {
                            Console.WriteLine("Ärende skapat! Klicka enter för att fortsätta");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Ärende misslyckades. Klicka enter för att fortsätta");
                            Console.ReadLine();


                        }

                        break;

                    case "2":
                        showMenu = false;
                        break;

                        default:
                        throw new Exception();
                }
            }
            }






            Console.WriteLine("Hello, World!");
        //    var customer = new Customer
        //    {
        //        CustomerName = "Natalia",
        //        CustomerLastName = "Chebanenko",
        //        CustomerEmail = "natalia@gmail.com",
        //        CustomerPhoneNr = "0793336962",
        //        Tickets = new List<Ticket>
        //        {
        //            new Ticket
        //            {
        //                SupportComment = "ej",
        //                SupportCommentRegistered = DateTime.Now,
        //                TicketDescription = "Ticket discription",
        //                TicketRegistered = DateTime.Now,
        //            }
        //        }
        //};

            //dbContext.Add(customer);
            //dbContext.SaveChanges();
            //Console.ReadLine();
        }
    }
}
