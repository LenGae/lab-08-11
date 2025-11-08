using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp8.Commands;
using WpfApp8.Entities;

namespace WpfApp8.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Aircraft> Collection { get; set; }
        public ObservableCollection<Booking> Collection2 { get; set; }
        public ObservableCollection<User> Collection3 { get; set; }
        private MyCommand? addItemCommand = null;
        public MyCommand AddItemCommand
        {
            get => addItemCommand ??= new(
                (obj) =>
                {

                },
                (obj) => false
                );
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public MyCommand AddUserCommand => new(
            (obj) =>
            {
                if (obj is AddUser addUserWindow)
                {
                    string email = addUserWindow.EmailTextBox.Text.Trim();
                    string fullName = addUserWindow.FullNameTextBox.Text.Trim();
                    string phone = addUserWindow.PhoneTextBox.Text.Trim();
                    string password = addUserWindow.PasswordBox.Password.Trim();
                    bool isActive = addUserWindow.IsActiveCheckBox.IsChecked ?? true;

                    int role = 1;
                    if (addUserWindow.RoleComboBox.SelectedItem is ComboBoxItem selectedItem)
                    {
                        role = int.Parse(selectedItem.Tag.ToString() ?? "1");
                    }
                        
                    string passwordHash = password;

                    MyCommand.AddUser(email, passwordHash, fullName, phone, role, isActive);

                    MessageBox.Show("Пользователь успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    addUserWindow.Close();
                }
            },
            (obj) => true
        );

        public MyCommand DelUserCommand => new(
            (obj) =>
            {
                if (obj is User user)
                {
                    using var context = new LeymanSe2307g1CourseworkContext();
                    context.Users.Remove(context.Users.Find(user.UserId)!);
                    context.SaveChanges();
                    Collection3.Remove(user);
                }
            },
            (obj) => obj is User
        );

        public MyCommand RegCommand => new(
            (obj) =>
            {
                if (obj is Auth addUserWindow)
                {
                    string email = addUserWindow.EmailTextBox.Text.Trim();
                    string fullName = addUserWindow.FullNameTextBox.Text.Trim();
                    string phone = addUserWindow.PhoneTextBox.Text.Trim();
                    string password = addUserWindow.PasswordBox.Password.Trim();

                    string passwordHash = password;

                    MyCommand.AddUser(email, passwordHash, fullName, phone, role: 1, isActive: true);

                    MessageBox.Show("Вы успешно зарегистрировались!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    addUserWindow.Close();
                }
            },
            (obj) => true
        );
        public ViewModel()
        {
            using var context = new LeymanSe2307g1CourseworkContext();
            var collection = context.Aircraft.ToList();
            var collectrion2 = context.Bookings.ToList();
            var collectrion3 = context.Users.ToList();
            Collection = new(collection);
            Collection2 = new(collectrion2);
            Collection3 = new(collectrion3);
        }
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
