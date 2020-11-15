using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace lab3_v6
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        private bool modeType = true;
        private bool typeCargo = true;
        private AirCompany company;

        public WindowAdd(AirCompany company)
        {
            InitializeComponent();
            Bt_next.IsEnabled = false;
            Txt_type.Visibility = Visibility.Visible;
            TypeList.Visibility = Visibility.Visible;
            this.company = company;
        }

        private void Bt_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (modeType)Close();
            else 
            {
                Bt_next.Content = "Далее";
                Bt_cancel.Content = "Отмена";
                Txt_type.Visibility = Visibility.Visible;
                TypeList.Visibility = Visibility.Visible;
                modeType = true;
                Txt_flight.Visibility = Visibility.Collapsed;
                Tb_flight.Visibility = Visibility.Collapsed;
                Txt_count_or_weight.Visibility = Visibility.Collapsed;
                Tb_count_or_weight.Visibility = Visibility.Collapsed;
                Txt_aircrew.Visibility = Visibility.Collapsed;
                Txt_pilot1.Visibility = Visibility.Collapsed;
                Tb_pilot1.Visibility = Visibility.Collapsed;
                Txt_pilot2.Visibility = Visibility.Collapsed;
                Tb_pilot2.Visibility = Visibility.Collapsed;
                Txt_stuard1.Visibility = Visibility.Collapsed;
                Tb_stuard1.Visibility = Visibility.Collapsed;
                Txt_stuard2.Visibility = Visibility.Collapsed;
                Tb_stuard2.Visibility = Visibility.Collapsed;
            }
        }

        private void Bt_next_Click(object sender, RoutedEventArgs e)
        {
            if (modeType) 
            {
                Bt_next.Content = "Добавить";
                Bt_cancel.Content = "Назад";
                Txt_type.Visibility = Visibility.Collapsed;
                TypeList.Visibility = Visibility.Collapsed;
                modeType = false;
                Txt_flight.Visibility = Visibility.Visible;
                Tb_flight.Visibility  = Visibility.Visible;
                Tb_count_or_weight.Visibility = Visibility.Visible;
                Txt_count_or_weight.Visibility = Visibility.Visible;
                Txt_aircrew.Visibility = Visibility.Visible;
                Txt_pilot1.Visibility = Visibility.Visible;
                Tb_pilot1.Visibility = Visibility.Visible;
                Txt_pilot2.Visibility = Visibility.Visible;
                Tb_pilot2.Visibility = Visibility.Visible;
                if (typeCargo) Txt_count_or_weight.Text = Constants.str_curb_weight;
                else 
                {
                    Txt_count_or_weight.Text = Constants.str_count_of_borarding_seats;
                    Txt_stuard1.Visibility = Visibility.Visible;
                    Tb_stuard1.Visibility = Visibility.Visible;
                    Txt_stuard2.Visibility = Visibility.Visible;
                    Tb_stuard2.Visibility = Visibility.Visible;
                }
            }
            else 
            {
                if (typeCargo) 
                {
                    int flightNumber = 0;
                    double curbWeight = 0;
                    string members = "";
                    try 
                    {
                        flightNumber = Convert.ToInt32(Tb_flight.Text);
                        curbWeight = Convert.ToDouble(Tb_count_or_weight.Text);

                        if (Tb_pilot1.Text.Equals("") || Tb_pilot1.Text.Equals(" ") || Tb_pilot2.Text.Equals("") || Tb_pilot2.Text.Equals("")) {
                            ErrorCallback("Не все поля заполнены!!!");
                            return;
                        }
                        members += (Tb_pilot1.Text + " : Пилот №1\n");
                        members += (Tb_pilot2.Text + " : Пилот №2");
                    }
                    catch 
                    {
                        ErrorCallback("ОШИБКА!!!");
                        return;
                    }
                    if (!company.AddCargoFlight(flightNumber, curbWeight, members)) 
                    {
                        ErrorCallback("Рейс с таким номером уже существует!!!");
                        return;
                    }
                }
                else
                {
                    int flightNumber = 0;
                    int countOfSeats = 0;
                    string members = "";
                    try {
                        flightNumber = Convert.ToInt32(Tb_flight.Text);
                        countOfSeats = Convert.ToInt32(Tb_count_or_weight.Text);

                        if (Tb_pilot1.Text.Equals("") || Tb_pilot1.Text.Equals(" ") || Tb_pilot2.Text.Equals(" ") || Tb_pilot2.Text.Equals("") || Tb_stuard1.Text.Equals(" ") || Tb_stuard1.Text.Equals("") || Tb_stuard2.Text.Equals(" ") || Tb_stuard2.Text.Equals("")) {
                            ErrorCallback("Не все поля заполнены!!!");
                            return;
                        }

                        members += (Tb_pilot1.Text + " : Пилот №1\n");
                        members += (Tb_pilot2.Text + " : Пилот №2\n");
                        members += (Tb_stuard1.Text + " : борт.проводник №1\n");
                        members += (Tb_stuard2.Text + " : борт.проводник №2");
                    }
                    catch {
                        ErrorCallback("ОШИБКА!!!");
                        return;
                    }
                    if (!company.AddPassengerFlight(flightNumber, countOfSeats, members)) 
                    {
                        ErrorCallback("Рейс с таким номером уже существует!!!");
                        return;
                    }
                }
                Close();
            }

        }

        private void ErrorCallback(String errorWarning)
        {
            Wnd_Add.Title = errorWarning;
            TimerCallback clb = new TimerCallback(error);
            System.Threading.Timer tmp = new System.Threading.Timer(clb, null, 500, 0);
        }

        public AirCompany GetCompany()
        {
            return company;
        }

        private void error(object obj)
        {
            Dispatcher.Invoke(new Action(() => Wnd_Add.Title = "Добавление рейса"));
        }

        private void TypeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeList.SelectedItem != null) Bt_next.IsEnabled = true;
            else Bt_next.IsEnabled = false;

            if (TypeList.SelectedIndex == 0) typeCargo = true;
            if (TypeList.SelectedIndex == 1) typeCargo = false;
        }
    }
}
