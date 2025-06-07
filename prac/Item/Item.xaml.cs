using prac.Classes.Context;
using prac.Classes.Model;
using prac.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace prac.Item
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        Partner partner;
        Context context;
        public Item(Partner _partner = null)
        {
            InitializeComponent();
            partner = _partner;
            context = new Context();
            typeAndName.Content = context.typePartner.ToList().Find(x => x.id == _partner.typePartner.id).name + " | " + _partner.nameCompany;
            discount.Content = GetDiscount(_partner.id) + "%";
            director.Content = _partner.fioDirector;
            telephone.Content = _partner.telephone;
            rating.Content = "Рейтинг: " + _partner.rating;
        }

        public int GetDiscount(int id)
        {
            var partner_product = context.partner_product.Where(x => x.partner.id == partner.id).ToList();
            double totalProducts = 0;
            foreach(var price in partner_product)
            {
                totalProducts += price.countProduct;
            }
            if (totalProducts < 10000) return 0;
            else if (totalProducts >= 10000 && totalProducts < 50000) return 5;
            else if (totalProducts >= 50000 && totalProducts < 300000) return 10;
            else return 15;
        }

        private void updatePartner(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.mainWindow.frame.Navigate(new Add(partner));
            Add.add.header.Content = "Изменение партнера";
            Add.add.addBtn.Content = "Изменить";
        }

        private void historyProduct(object sender, System.Windows.RoutedEventArgs e) { } //=> MainWindow.mainWindow.frame.Navigate(new History(partners.id));
    }
}
