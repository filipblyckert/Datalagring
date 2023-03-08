using _01_EFC.Models;
using _01_EFC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_EFC.Services;

internal class MenuService
{
    

    




        public async Task CreateNewContactAsync()
        {
            var customer = new Customer();

            Console.Write("Förnamn:");
            customer.FirstName = Console.ReadLine() ?? "";
            Console.Write("Efternamn:");
            customer.LastName = Console.ReadLine() ?? "";
            Console.Write("E-postadress:");
            customer.Email = Console.ReadLine() ?? "";
            Console.Write("Telefonnummer:");
            customer.PhoneNumber = Console.ReadLine() ?? "";
            Console.Write("Gatuadress:");
            customer.StreetName = Console.ReadLine() ?? "";
            Console.Write("Postnummer:");
            customer.PostalCode = Console.ReadLine() ?? "";
            Console.Write("Stad:");
            customer.City = Console.ReadLine() ?? "";


            //save customer to databse

            await CustomerService.SaveAsync(customer);

        }

        public async Task ListAllContactsAsync()
        {
            //get all customers + address from database
            var customers = await CustomerService.GetAllAsync();

        if (customers.Any())
        {
          foreach (Customer customer in customers)
                    {
                        Console.WriteLine($"Kundnummer{customer.Id}");
                        Console.WriteLine($"Namn:{customer.FirstName} {customer.LastName}");
                        Console.WriteLine($"E-postadress:{customer.Email}");
                        Console.WriteLine($"Telefonnummer:{customer.PhoneNumber}");
                        Console.WriteLine($"Adress:{customer.StreetName}, {customer.PostalCode}, {customer.City}");

                        Console.WriteLine("");
                    }
        }else
        {
            Console.WriteLine("inga kunder finns i databasen");
            Console.WriteLine("");
        }

          

        }
        public async Task ListSpecificContactAsync()
        {
            // get specific customer+adress from database


            Console.WriteLine("Ange e-postadress på kunden:");
            var email = Console.ReadLine();
            var customer = await CustomerService.GetAsync(email);

            if (customer != null)
            {
                Console.WriteLine($"Kundnummer{customer.Id}");
                Console.WriteLine($"Namn:{customer.FirstName} {customer.LastName}");
                Console.WriteLine($"E-postadress:{customer.Email}");
                Console.WriteLine($"Telefonnummer:{customer.PhoneNumber}");
                Console.WriteLine($"Adress:{customer.StreetName}, {customer.PostalCode}, {customer.City}");


            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Ingen kund med det angivna e-postadressen{email} hittades");
                Console.WriteLine("");
            }

        }


        public async Task UpdateSpecificContactAsync()
        {



            Console.WriteLine("Ange e-postadress på kunden:");
            var email = Console.ReadLine();


            if (!string.IsNullOrEmpty(email))
            {



                var customer = await CustomerService.GetAsync(email);
            if (customer != null)
            {

                Console.WriteLine("Skriv information på de fält som du vill uppdatera.\n");

                Console.Write("Förnamn:");
                customer.FirstName = Console.ReadLine() ?? null!;
                Console.Write("Efternamn:");
                customer.LastName = Console.ReadLine() ?? null!;
                Console.Write("E-postadress:");
                customer.Email = Console.ReadLine() ?? null!;
                Console.Write("Telefonnummer:");
                customer.PhoneNumber = Console.ReadLine() ?? null!;
                Console.Write("Gatuadress:");
                customer.StreetName = Console.ReadLine() ?? null!;
                Console.Write("Postnummer:");
                customer.PostalCode = Console.ReadLine() ?? null!;
                Console.Write("Stad:");
                customer.City = Console.ReadLine() ?? null!;
            

                //update specific customer from database
                await CustomerService.UpdateAsync(customer);
            }

            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Ingen e-post angiven");
                Console.WriteLine("");
            }

        }


        public async Task DeleteSpecificContactAsync()
        {



            Console.WriteLine("Ange e-postadress på kunden:");
            var email = Console.ReadLine();


            if (!string.IsNullOrEmpty(email))
            {
                await CustomerService.DeleteAsync(email);

            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Ingen e-post angiven");
                Console.WriteLine("");
            }

        }
    }





