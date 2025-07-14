
using Data.Access.Layer.Config;
using Data.Access.Layer.Models;


using var customerDb = DbContextFactory.CreateDbContext();

Console.WriteLine("=======================================================");
Console.WriteLine("================CREATE CUSTOMER========================");
Console.WriteLine("=======================================================");
CreateCustomer();
Console.WriteLine("=======================================================");
Console.WriteLine("=================CUSTOMERS=============================");
Console.WriteLine("=======================================================");
DisplayCustomers();
Console.WriteLine("=======================================================");
Console.WriteLine("=================UPDATE A CUSTOMER=====================");
Console.WriteLine("=======================================================");
UpdateCustomer();
Console.WriteLine("=======================================================");
Console.WriteLine("=================CUSTOMERS=============================");
Console.WriteLine("=======================================================");
DisplayCustomers();
Console.WriteLine("=======================================================");
Console.WriteLine("=================DELETE A CUSTOMER=====================");
Console.WriteLine("=======================================================");
DeleteCustomer();
Console.WriteLine("=======================================================");
Console.WriteLine("=================CUSTOMERS=============================");
Console.WriteLine("=======================================================");
DisplayCustomers();
void CreateCustomer()
{

    var customer = new Customer();

    Console.WriteLine("Please enter full names:");
    customer.Name = Console.ReadLine();
    Console.WriteLine("Please email:");
    customer.Email = Console.ReadLine();
    Console.WriteLine("Phone number:");
    customer.PhoneNumber = Console.ReadLine();

    customerDb.Customers.Add(customer);
    customerDb.SaveChanges();
    Console.WriteLine("Customer added.");

}


void DisplayCustomers()
{

    var allCustomers = customerDb.Customers.ToList();

   
        Console.WriteLine("All customers:");
        foreach (var customer in allCustomers)
        {
            Console.WriteLine($"ID: {customer.CustomerID}, Name: {customer.Name}, Email: {customer.Email},Phone number: {customer.PhoneNumber}");
        }
    Console.WriteLine();
}

void UpdateCustomer()
{
    Console.WriteLine("Enter ID to update:");
    int id = int.Parse(Console.ReadLine());

    var customer = customerDb.Customers.FirstOrDefault(c => c.CustomerID == id);
    if (customer != null)
    {
        Console.WriteLine("Enter new name:");
        customer.Name = Console.ReadLine();

        Console.WriteLine("Enter new email:");
        customer.Email = Console.ReadLine();

        customerDb.SaveChanges();

        Console.WriteLine("Customer details are updated.");
    }
    else
    {
        Console.WriteLine("The ID does not exist.");
    }
}
void DeleteCustomer()
{
    Console.WriteLine("Enter ID to delete:");
    int id = int.Parse(Console.ReadLine());

    var customer = customerDb.Customers.FirstOrDefault(c => c.CustomerID == id);
    if (customer != null)
    {
        customerDb.Customers.Remove(customer);
        customerDb.SaveChanges();

        Console.WriteLine("Customer sucessful deleted.");
    }
    else
    {
        Console.WriteLine("Customer doesn't exist");
    }
}