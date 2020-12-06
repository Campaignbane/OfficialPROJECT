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
using MySql.Data.MySqlClient;


namespace OfficialProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double sizeprice = 0.00;
        private void Small_Checked(object sender, RoutedEventArgs e)
        {
            if (Small.IsChecked == true)
            {
                sizeprice += 10.99;
            }
            else
            {
                sizeprice -= 10.99;
            }
            taxes();
        }

        private void Medium_Checked(object sender, RoutedEventArgs e)
        {
            if (Medium.IsChecked == true)
            {
                sizeprice += 14.98;
            }
            else
            {
                sizeprice -= 14.98;
            }
            taxes();
        }

        private void Large_Checked(object sender, RoutedEventArgs e)
        {
            if (Large.IsChecked == true)
            {
                sizeprice = 17.99;
            }
            else
            {
                sizeprice -= 17.99;
            }
            taxes();
        }

        double crustprice = 0.00;
        private void Thin_Checked(object sender, RoutedEventArgs e)
        {
            if (Thin.IsChecked == true)
            {
                crustprice = 0.00;
            }

        }
        private void Thick_Checked(object sender, RoutedEventArgs e)
        {
            if (Thick.IsChecked == true)
            {
                crustprice = 0.00;
            }


        }

        double toppingsprice = 0.00;
        int toppingsSelected = 0;

        private void Pepperoni_Checked(object sender, RoutedEventArgs e)
        {
            if (Pepperoni.IsChecked == true)
            {
                toppingsSelected++;
                if (toppingsSelected > 2)
                {
                    toppingsprice += 0.40;
                }
            }
            else
            {
                toppingsprice -= 0.40;
            }
            taxes();
        }

        private void Sausage_Checked(object sender, RoutedEventArgs e)
        {
            if (Sausage.IsChecked == true)
            {
                toppingsSelected++;
                if (toppingsSelected > 2)
                {
                    toppingsprice += 0.40;
                }
            }
            else
            {
                toppingsprice -= 0.40;
            }
            taxes();

        }
        private void Ground_Beef_Checked(object sender, RoutedEventArgs e)
        {
            if (Ground_Beef.IsChecked == true)
            {
                toppingsSelected++;
                if (toppingsSelected > 2)
                {
                    toppingsprice += 0.40;
                }

            }
            else
            {
                toppingsprice -= 0.40;
            }
            taxes();
        }

        private void Cheese_Checked(object sender, RoutedEventArgs e)
        {
            if (Cheese.IsChecked == true)
            {
                toppingsSelected++;
                if (toppingsSelected > 2)
                {
                    toppingsprice += 0.40;
                }

            }
            else
            {
                toppingsprice -= 0.40;
            }
            taxes();
        }

        double sidesprice = 0.00;

        private void Fries_Checked(object sender, RoutedEventArgs e)
        {
            if (Fries.IsChecked == true)
            {
                sidesprice += 2.00;
            }
            else
            {
                sidesprice -= 2.00;
            }
            taxes();
        }

        private void Wedgies_Checked(object sender, RoutedEventArgs e)
        {
            if (Wedgies.IsChecked == true)
            {
                sidesprice += 2.75;
            }
            else
            {
                sidesprice -= 2.75;
            }
            taxes();
        }

        private void Poutine_Checked(object sender, RoutedEventArgs e)
        {
            if (Poutine.IsChecked == true)
            {
                sidesprice += 3.50;
            }
            else
            {
                sidesprice -= 3.50;
            }
            taxes();
        }



        public double calculate_total()
        {
            return sizeprice + crustprice + toppingsprice + sidesprice;
        }

        public void taxes()
        {
            double tax = 0.13 * Math.Round(calculate_total(), 2);
            Total.Content = Math.Round(calculate_total(), 2);
            Tax.Content = "$" + Math.Round(tax, 2);
            Grand_Total.Content = "$" + (Math.Round(calculate_total() + tax, 2));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=banehuncho30;database=pizzahuncho;";
            string query = "INSERT INTO pizzatable(`id`, `Size`, `Crust`, `Toppings`, `Sides`, `Total`, `Tax`, `Grand_Total`) VALUES (NULL, '" + Large + "', '" + Thick + "', '" + Pepperoni + "', '" + Fries + "', '" + 0.00 + "', '" + 0.00 + "', '" + 0.00 + "')";
            // Which could be translated manually to :
            // INSERT INTO user(`id`, `size`, `crust`, `toppings`, `sides`) VALUES (NULL, 'small', 'thin', 'pepperoni','fries')


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Order has been placed");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

    }

}

