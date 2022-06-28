using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.General.Service;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Service;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.TransactionManagement
{
    public class StationIncomeReportViewModel : ViewModelBase
    {
        public class DataTableDTO
        {
            private string _code;
            private double _incomeRSD;
            private double _incomeEUR;
            public string Code => _code;
            public double IncomeRSD => _incomeRSD;
            public double IncomeEUR => _incomeEUR;
            public DataTableDTO(string code, double incomeRSD, double incomeEUR)
            {
                _code = code;
                _incomeRSD = incomeRSD;
                _incomeEUR = incomeEUR;
            }
        }

        #region Attributes

        private ObservableCollection<DataTableDTO> _tollBoothsDTO;
        private readonly IEnumerable<TollBooth> _tollBooths;
        private DateTime _startDate;
        private DateTime _endDate;
        private ICurrencyService _currencyService;
        private ITollBoothService _tollBoothService;
        private Currency _currRSD;
        private Currency _currEUR;

        #endregion

        #region Properties

        public IEnumerable<DataTableDTO> TollBooths => _tollBoothsDTO;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                LoadData();
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                LoadData();
            }
        }

        #endregion

        #region Methods

        private void LoadCurrencies()
        {
            _currRSD = _currencyService.GetCurrencyByCode("rsd");
            _currEUR = _currencyService.GetCurrencyByCode("eur");
        }

        private void LoadData()
        {
            _tollBoothsDTO = new ObservableCollection<DataTableDTO>();
            double totalRSD = 0;
            double totalEUR = 0;
            foreach (var tollBooth in _tollBooths)
            {
                double incomeRSD = _tollBoothService.GetIncome(tollBooth, StartDate, EndDate, _currRSD);
                double incomeEUR = _tollBoothService.GetIncome(tollBooth, StartDate, EndDate, _currEUR);
                DataTableDTO obj = new DataTableDTO(tollBooth.Code, incomeRSD, incomeEUR);
                totalRSD += incomeRSD;
                totalEUR += incomeEUR;
                _tollBoothsDTO.Add(obj);    
            }
            _tollBoothsDTO.Add(new DataTableDTO("TOTAL", totalRSD, totalEUR));
            OnPropertyChanged(nameof(TollBooths));
        }

        #endregion

        public StationIncomeReportViewModel(ICurrencyService currencyService, ITollBoothService tollBoothService, TollStation tollStation)
        {
            _currencyService = currencyService;
            _tollBoothService = tollBoothService;
            LoadCurrencies();
            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
            _tollBooths = tollStation.TollBooths;
            LoadData();
        }

    }
}
