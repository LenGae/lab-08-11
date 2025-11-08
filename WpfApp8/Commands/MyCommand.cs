using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp8.Entities;

namespace WpfApp8.Commands
{
    public class MyCommand(Action<object?> action, Func<object?, bool>? canExecute = null) : ICommand
    {
        private readonly Action<object?> action = action;
        private readonly Func<object?, bool>? canExecute = canExecute;
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
        public void Execute(object? parameter)
        {
            action(parameter);
        }

        public static void AddUser(string email, string passwordHash, string fullName, string phoneNumber, int role, bool isActive)
        {
            using var context = new LeymanSe2307g1CourseworkContext();

            var newUser = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Role = role,
                IsActive = isActive,
                CreatedAt = DateTime.Now,
                LastLogin = null
            };

            context.Users.Add(newUser);
            context.SaveChanges();
        }

        public static void DeleteUser(int userId)
        {
            using var context = new LeymanSe2307g1CourseworkContext();

            var user = context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
