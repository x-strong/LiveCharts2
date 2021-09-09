﻿using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModelsSamples.Polar.Basic
{
    public class ViewModel : INotifyPropertyChanged
    {
        private double _sliderValue = 15;

        public IEnumerable<ISeries> Series { get; set; } = new ObservableCollection<ISeries>
        {
            new PolarLineSeries<double>
            {
                Values = new ObservableCollection<double> { 1500, 1400, 1300, 1200, 1100, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100 }
            }
        };

        public IEnumerable<IPolarAxis> RadialAxes { get; set; }
            = new IPolarAxis[]
            {
                new PolarAxis
                {
                    LabelsRotation = 0,
                    LabelsAngle = -60,
                    Labeler = v => (v * 10).ToString("N2")
                }
            };

        public IEnumerable<IPolarAxis> AngleAxes { get; set; }
            = new IPolarAxis[]
            {
                new PolarAxis
                {
                    //LabelsRotation = 90,
                    Labeler = v => (v * 1000).ToString("N2")
                }
            };

        public double SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SliderValue)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}