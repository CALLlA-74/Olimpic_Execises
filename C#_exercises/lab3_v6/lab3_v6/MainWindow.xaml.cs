using System;
using System.Windows;

namespace lab3_v6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static AirCompany company;

        public MainWindow()
        {
            
            InitializeComponent();
            company = new AirCompany();
            GetDates();
            ShowTable();
            Closing += Window_Closed;
        }

        private void GetDates()
        {
            company = AirCompany.RestoreDates(company);
        }

        private void Bt_add_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd wndAdd = new WindowAdd(company);
            wndAdd.ShowDialog();
            company = wndAdd.GetCompany();
            ShowTable();
        }

        private void ShowTable()
        {
            Txt_average_weight.Text = company.GetAverageCurbWeight().ToString();
            lw_table.Items.Clear();
            int i;
            for (i = 0; i < Math.Min(5, company.GetCountOfFlights()); i++) 
            {
                lw_table.Items.Add(company.GetFlight(i)) ;
            }
            if (company.GetCountOfFlights() > 8) lw_table.Items.Add(new AirCompany.flight { number = "..."});
            if (company.GetCountOfFlights() > 5)
                for (int k = Math.Max(company.GetCountOfFlights() - 3, i); k < company.GetCountOfFlights(); k++) 
                {
                    lw_table.Items.Add(company.GetFlight(i));
                }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            AirCompany.WriteFile(company);
        }

        private void Bt_Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show(Constants.msgClearingList, Constants.headerClearingList, MessageBoxButton.YesNo);
            if (res == MessageBoxResult.No) return;
            company = new AirCompany();
            ShowTable();
            AirCompany.WriteFile(company);
        }
    }
}
