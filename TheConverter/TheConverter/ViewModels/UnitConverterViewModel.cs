using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheConverter.ViewModels
{
    class UnitConverterViewModel : ObservableObject
    {
        public ICommand ButtonConvertCommand { get; set; }

        private double _result;
        public double Opperand { get; set; }
        public double Metres { get; set; }  //Im turning everything into meters, then converting from there
        public string OpperandUnit { get; set; }

        public string ResultUnit { get; set; }
        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
        public List<string> Units { get; set; }
        private List<string> BuildOutUnitComboBoxSource()
        {
            return new List<string>() { "Inches", "Feet", "Miles", "Milimeters", "Centimeters", "Meters", "Kilometers" };
        }


        private void PerformCalculation(object obj)
        {
            switch (OpperandUnit)   //Turn into meters
            {
                case "Inches":
                    Metres = Opperand * 0.0254;  
                    break;
                case "Feet":
                    Metres = Opperand * 0.3048;
                    break;
                case "Miles":
                    Metres = Opperand * 1609.344;
                    break;
                case "Milimeters":
                    Metres = Opperand / 1000;
                    break;
                case "Centimeters":
                    Metres = Opperand / 100;
                    break;
                case "Meters":
                    Metres = Opperand;
                    break;
                case "Kilometers":
                    Metres = Opperand * 1000;
                    break;
                default:
                    break;
            }
            switch (ResultUnit)   //meters turn into whatever is desired
            {
                case "Inches":
                    Result = Metres / 0.0254;
                    break;
                case "Feet":
                    Result = Metres / 0.3048;
                    break;
                case "Miles":
                    Result = Metres / 1609.344;
                    break;
                case "Milimeters":
                    Result = Metres * 1000;
                    break;
                case "Centimeters":
                    Result = Metres * 100;
                    break;
                case "Meters":
                    Result = Metres;
                    break;
                case "Kilometers":
                    Result = Metres / 1000;
                    break;
                default:
                    break;
            }
        }
        public UnitConverterViewModel()
        {
            Opperand = 44;  //just a placeholder

            Units = BuildOutUnitComboBoxSource();
            ButtonConvertCommand = new RelayCommand(new Action<object>(PerformCalculation));

        }
    }
}

