using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.TransactionManagement
{
    public class RoadTollPaymentViewModel : ViewModelBase
    {
        #region Atributes
        private readonly ICurrencyService _currencyService;
        private readonly ITollStationService _tollStationService;
        private Currency _selectedCurrency;
        private TollStation _selectedStation;
        private readonly TollStation _currentStation;
        private double _price;
        private double _amountPayed;
        private double _change;
        #endregion

        #region Properties
        public ICurrencyService CurrencyService => _currencyService;
        public ITollStationService TollStationService => _tollStationService;

        public double Change
        {
            get => _change;
            set
            {
                _change = value;
                OnPropertyChanged(nameof(Change));
            }
        }
        public double AmountPayed
        {
            get => _amountPayed;
            set
            {
                _amountPayed = value;
                OnPropertyChanged(nameof(AmountPayed));
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public TollStation CurrentStation => _currentStation;
        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged(nameof(SelectedCurrency));
            }
        }
        public TollStation SelectedStation
        {
            get => _selectedStation;
            set
            {
                _selectedStation = value;
                OnPropertyChanged(nameof(SelectedStation));
            }
        }
        #endregion

        #region Collections
        private readonly ObservableCollection<Currency> _currencies;
        public IEnumerable<Currency> Currencies => _currencies;

        private readonly ObservableCollection<TollStation> _tollStations;
        public IEnumerable<TollStation> TollStations => _tollStations;


        #endregion
        public RoadTollPaymentViewModel(ICurrencyService currencyService, ITollStationService tollStationService)
        {
            _currencyService = currencyService;
            _tollStationService = tollStationService;
        }
    }
}
