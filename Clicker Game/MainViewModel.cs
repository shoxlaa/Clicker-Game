﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
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
        [ObservableProperty] 
        bool _startEnabled = true;
        [ObservableProperty] 
        double _avg = 0;
        double _sum = 0;
        [ObservableProperty]
        int _count = 0;
        [ICommand]
        void Start()
        {
            Thread Change = new Thread(() =>
            {
                StartEnabled = false;
                Color = Brushes.Red;
                Thread.Sleep(random.Next(1000, 5000));
                Enabled = true;
                Color = Brushes.Green;
                Begin = DateTime.Now; 
                Count++;
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
            StartEnabled = true; 

            Enabled = false;
            _sum += Dif;
            Avg =_sum/ _count; 
            
        }
    }
}
