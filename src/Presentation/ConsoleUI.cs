using OOP_Workshop.Domain;
using OOP_Workshop.Domain.User;
using OOP_Workshop.Domain.Media;
using System;
using System.Linq;
using MediaType = OOP_Workshop.Domain.Media.Media;

namespace OOP_Workshop.Presentation
{
    public class ConsoleUI
    {
        private Library _library = new Library();

        public void Run()
        {
            Console.WriteLine("Welcome to the OOP-Workshop Media Library!");
            Console.WriteLine("Please identify your role:");
            Console.WriteLine("1. Borrower");
            Console.WriteLine("2. Employee");
            Console.WriteLine("3. Admin");

            int roleChoice = ReadInt("Enter role number (1-3): ", 1, 3);

            User? currentUser = null;

            string name = ReadString("Enter your name: ");
            int age = ReadInt("Enter your age: ", 1, 120);
            string ssn = ReadString("Enter your social security number: ");

            switch (roleChoice)
            {
                case 1:
                    currentUser = new Borrower(name, ssn, age);
                    BorrowerMenu((Borrower)currentUser);
                    break;
                case 2:
                    currentUser = new Employee(name, ssn, age);
                    EmployeeMenu((Employee)currentUser);
                    break;
                case 3:
                    currentUser = new Admin(name, ssn, age);
                    AdminMenu((Admin)currentUser);
                    break;
            }
        }

        #region Borrower Menu
        private void BorrowerMenu(Borrower borrower)
        {
            while (true)
            {
                Console.WriteLine("\n--- Borrower Menu ---");
                Console.WriteLine("1. List all media by type");
                Console.WriteLine("2. View media details");
                Console.WriteLine("3. Rate media");
                Console.WriteLine("4. Exit");

                int choice = ReadInt("Enter choice: ", 1, 4);

                switch (choice)
                {
                    case 1: ListMediaByType(); break;
                    case 2: ViewMediaDetails(); break;
                    case 3: RateMedia(borrower); break;
                    case 4: return;
                }
            }
        }
        #endregion

        #region Employee Menu
        private void EmployeeMenu(Employee employee)
        {
            while (true)
            {
                Console.WriteLine("\n--- Employee Menu ---");
                Console.WriteLine("1. List all media by type");
                Console.WriteLine("2. Add media to library");
                Console.WriteLine("3. Remove media from library");
                Console.WriteLine("4. Exit");

                int choice = ReadInt("Enter choice: ", 1, 4);

                switch (choice)
                {
                    case 1: ListMediaByType(); break;
                    case 2: AddMediaToLibrary(employee); break;
                    case 3: RemoveMediaFromLibrary(employee); break;
                    case 4: return;
                }
            }
        }
        #endregion

        #region Admin Menu
        private void AdminMenu(Admin admin)
        {
            while (true)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. List all media by type");
                Console.WriteLine("2. Add media to library");
                Console.WriteLine("3. Remove media from library");
                Console.WriteLine("4. Manage users");
                Console.WriteLine("5. Exit");

                int choice = ReadInt("Enter choice: ", 1, 5);

                switch (choice)
                {
                    case 1: ListMediaByType(); break;
                    case 2: AddMediaToLibrary(admin); break;
                    case 3: RemoveMediaFromLibrary(admin); break;
                    case 4: ManageUsers(admin); break;
                    case 5: return;
                }
            }
        }
        #endregion

        #region Media Actions
        private void ListMediaByType()
        {
            Console.WriteLine("\nMedia types: EBook, Movie, Song, VideoGame, App, Podcast, Image");
            string type = ReadString("Enter media type: ").ToLower();

            var items = _library.GetAllMedia()
                                .Where(m => m.GetType().Name.ToLower() == type)
                                .ToList();

            if (!items.Any())
            {
                Console.WriteLine("No media found for this type.");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Title}");
            }
        }

        private void ViewMediaDetails()
        {
            string title = ReadString("Enter media title: ");
            MediaType? media = _library.SearchByTitle(title);
            if (media == null)
            {
                Console.WriteLine("Media not found.");
                return;
            }
            Console.WriteLine(media.GetDetails());
        }

        private void RateMedia(User user)
        {
            string title = ReadString("Enter media title to rate: ");
            MediaType? media = _library.SearchByTitle(title);
            if (media == null)
            {
                Console.WriteLine("Media not found.");
                return;
            }

            int stars = ReadInt("Enter rating (1-5): ", 1, 5);
            user.RateMedia(media, stars);
            Console.WriteLine("Rating added!");
        }

        private void AddMediaToLibrary(User user)
        {
            Console.WriteLine("Select media type to add: EBook, Movie, Song, VideoGame, App, Podcast, Image");
            string type = ReadString("Type: ").ToLower();

            MediaType? media = 
            if (media != null)
            {
                if (user is Employee emp)
                    emp.AddToLibrary(_library, media);
                else if (user is Admin adm)
                    adm.AddToLibrary(_library, media);

                Console.WriteLine($"{type} added to library!");
            }
        }

        private void RemoveMediaFromLibrary(User user)
        {
            string title = ReadString("Enter media title to remove: ");
            MediaType? media = _library.SearchByTitle(title);
            if (media != null)
            {
                if (user is Employee emp)
                    emp.RemoveFromLibrary(_library, media);
                else if (user is Admin adm)
                    adm.RemoveFromLibrary(_library, media);

                Console.WriteLine("Media removed!");
            }
            else
            {
                Console.WriteLine("Media not found.");
            }
        }
        #endregion

        #region User Management (Admin)
        private void ManageUsers(Admin admin)
        {
            Console.WriteLine("User management not fully implemented. (Placeholder)");
        }
        #endregion

        #region Helper Methods
        private string ReadString(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine() ?? "";
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        private int ReadInt(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Please enter a number between {min} and {max}.");
            }
        }
        #endregion
    }
}