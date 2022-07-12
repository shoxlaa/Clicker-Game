using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;


namespace Clicker_Game
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
    {
        DateTime Begin;
        readonly Random random = new();
        [ObservableProperty]
        double _dif;
        [ObservableProperty]
        Brush _color = Brushes.Aqua;
        [ObservableProperty] 
        bool _enabled = false;
        [ICommand]
        void Start()
        {
            Thread Change = new Thread(() =>
            {
                Color = Brushes.Red;
                Thread.Sleep(random.Next(2000, 7000));
                Enabled = true;
                Color = Brushes.Green;
                Begin = DateTime.Now;
            })
            {
                IsBackground = true
            };
            Change.Start();
        }
        [ICommand]
        void ClickMe()
        {
            Dif = (DateTime.Now - Begin).TotalSeconds;
            Color = Brushes.Aqua;
            Enabled = false;
        }
    }
}
