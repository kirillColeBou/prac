using prac.Classes.Context;
using prac.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prac.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        Partner partner;
        Context context = new Context();
        public static Add add;

        public Add(Partner _partner = null)
        {
            InitializeComponent();
            add = this;
            partner = _partner;
            if (_partner != null)
            {
                nameCompany.Text = _partner.nameCompany;
                address.Text = _partner.address;
                fioDirector.Text = _partner.fioDirector;
                email.Text = _partner.email;
                telephone.Text = _partner.telephone.ToString();
                rating.Text = _partner.rating.ToString();
            }
            foreach (var item in context.typePartner)
            {
                ComboBoxItem itemTypePartner = new ComboBoxItem();
                itemTypePartner.Tag = item.id;
                itemTypePartner.Content = item.name;
                if (_partner != null && _partner.typePartner.id == item.id) itemTypePartner.IsSelected = true;
                typePartner.Items.Add(itemTypePartner);
            }
        }

        private void addOrChange(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(nameCompany.Text))
                {
                    MessageBox.Show("Введите наименование партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (String.IsNullOrEmpty(typePartner.Text))
                {
                    MessageBox.Show("Выберите тип партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (String.IsNullOrEmpty(address.Text))
                {
                    MessageBox.Show("Введите адрес партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (String.IsNullOrEmpty(fioDirector.Text))
                {
                    MessageBox.Show("Введите ФИО директора!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (String.IsNullOrEmpty(email.Text))
                {
                    MessageBox.Show("Введите электронную почту партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (String.IsNullOrEmpty(telephone.Text))
                {
                    MessageBox.Show("Введите номер телефона партнера!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (String.IsNullOrEmpty(rating.Text) || Convert.ToInt32(rating.Text) <= 0)
                {
                    MessageBox.Show("Рейтинг партнера не введен или указано отрицательное значение!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (addBtn.Content.ToString() == "Добавить")
                {
                    Partner newPartners = new Partner()
                    {
                        nameCompany = nameCompany.Text,
                        typePartner = context.typePartner.FirstOrDefault(x => x.id == Convert.ToInt64(((ComboBoxItem)typePartner.SelectedItem).Tag)),
                        address = address.Text,
                        fioDirector = fioDirector.Text,
                        email = email.Text,
                        telephone = telephone.Text,
                        rating = Convert.ToInt32(rating.Text)
                    };
                    context.partner.Add(newPartners);
                    context.SaveChanges();
                    MessageBox.Show("Успешно добавлен новый партнер!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (addBtn.Content.ToString() == "Изменить")
                {
                    var updatePartner = context.partner.FirstOrDefault(x => x.id == partner.id);
                    if (updatePartner != null)
                    {
                        updatePartner.nameCompany = nameCompany.Text;
                        updatePartner.typePartner = context.typePartner.FirstOrDefault(x => x.id == Convert.ToInt64(((ComboBoxItem)typePartner.SelectedItem).Tag));
                        updatePartner.address = address.Text;
                        updatePartner.fioDirector = fioDirector.Text;
                        updatePartner.email = email.Text;
                        updatePartner.telephone = telephone.Text;
                        updatePartner.rating = Convert.ToInt32(rating.Text);
                    }
                    context.SaveChanges();
                    MessageBox.Show("Успешно изменен партнер!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                MainWindow.mainWindow.frame.Navigate(new Main());
            }
            catch (FormatException)
            {
                MessageBox.Show("Рейтинг должен быть числом!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void backPage(object sender, RoutedEventArgs e) => MainWindow.mainWindow.frame.Navigate(new Main());
    }
}
