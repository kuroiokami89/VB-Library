// using System;
// using System.Collections.Generic;
// using System.Linq;
// using LibApp.Models;

// namespace LibApp.Services
// {
//     public class ClientService
//     {
//         // Store clients in memory
//         private static List<Client> clients = new List<Client>();
//         private static int nextId = 1;

//         // Add sample data when app starts
//         static ClientService()
//         {
//             clients.Add(new Client
//             {
//                 Id = nextId++,
//                 Name = "John Doe",
//                 Email = "john@example.com",
//                 Phone = "555-0100",
//                 RegistrationDate = DateTime.Now.AddMonths(-6)
//             });

//             clients.Add(new Client
//             {
//                 Id = nextId++,
//                 Name = "Jane Smith",
//                 Email = "jane@example.com",
//                 Phone = "555-0101",
//                 RegistrationDate = DateTime.Now.AddMonths(-3)
//             });
//         }

//         // Get all clients
//         public List<Client> GetAllClients()
//         {
//             return clients;
//         }

//         // Get one client by ID
//         public Client GetClientById(int id)
//         {
//             return clients.FirstOrDefault(c => c.Id == id);
//         }

//         // Add new client
//         public void AddClient(Client client)
//         {
//             client.Id = nextId++;
//             client.RegistrationDate = DateTime.Now;
//             clients.Add(client);
//         }

//         // Update client
//         public void UpdateClient(Client client)
//         {
//             var existingClient = clients.FirstOrDefault(c => c.Id == client.Id);
//             if (existingClient != null)
//             {
//                 existingClient.Name = client.Name;
//                 existingClient.Email = client.Email;
//                 existingClient.Phone = client.Phone;
//             }
//         }

//         // Delete client
//         public void DeleteClient(int id)
//         {
//             var client = clients.FirstOrDefault(c => c.Id == id);
//             if (client != null)
//             {
//                 clients.Remove(client);
//             }
//         }

//         // Search clients
//         public List<Client> SearchClients(string searchTerm)
//         {
//             if (string.IsNullOrEmpty(searchTerm))
//                 return clients;

//             return clients.Where(c =>
//                 c.Name.ToLower().Contains(searchTerm.ToLower()) ||
//                 c.Email.ToLower().Contains(searchTerm.ToLower())
//             ).ToList();
//         }
//     }
// }
