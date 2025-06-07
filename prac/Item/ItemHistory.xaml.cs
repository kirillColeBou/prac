using prac.Classes.Context;
using prac.Classes.Model;
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
    /// Логика взаимодействия для ItemHistory.xaml
    /// </summary>
    public partial class ItemHistory : UserControl
    {
        Context context = new Context();

        public ItemHistory(PartnerProduct partner_product)
        {
            InitializeComponent();
            product.Content = context.product.ToList().Find(x => x.id == partner_product.product.id).name;
            partner.Content = context.partner.ToList().Find(x => x.id == partner_product.partner.id).nameCompany;
            countProduct.Content += partner_product.countProduct.ToString();
            dateSell.Content += partner_product.dateSell.ToString("dd.MM.yyyy");
        }
    }
}
