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

            Console.WriteLine("Hello, World!");
            var customer = new Customer
            {
                CustomerName = "Natalia",
                CustomerLastName = "Chebanenko",
                CustomerEmail = "natalia@gmail.com",
                CustomerPhoneNr = "0793336962",
                Tickets = new List<Ticket>
                {
                    new Ticket
                    {
                        SupportComment = "ej",
                        SupportCommentRegistered = DateTime.Now,
                        TicketDescription = "Ticket discription",
                        TicketRegistered = DateTime.Now,
                    }
                }
        };

            dbContext.Add(customer);
            dbContext.SaveChanges();
            Console.ReadLine();
        }
    }
}
