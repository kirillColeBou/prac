using prac.Classes.Context;
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

namespace prac.Pages
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        Context context = new Context();

        public History(int id)
        {
            InitializeComponent();
            loadItem(id);
        }

        private void loadItem(int id)
        {
            parent.Children.Clear();
            foreach (var item in context.partner_product.Where(x => x.partner.id == id))
            {
                parent.Children.Add(new Item.ItemHistory(item));
            }
        }

        private void backPage(object sender, RoutedEventArgs e) => MainWindow.mainWindow.frame.Navigate(new Main());
    }
}
