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
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.TransactionManagement
{
    public class GlobalIncomeReportViewModel : ViewModelBase
    {
        public class DataTableDTO
        {
            private string _name;
            private double _incomeRSD;
            private double _incomeEUR;
            public string Name => _name;
            public double IncomeRSD => _incomeRSD;
            public double IncomeEUR => _incomeEUR;
            public DataTableDTO(string name, double incomeRSD, double incomeEUR)
            {
                _name = name;
                _incomeRSD = incomeRSD;
                _incomeEUR = incomeEUR;
            }
        }
        #region Atributes
        private ObservableCollection<DataTableDTO> _tollStationsDTO;
        private DateTime _startDate;
        private DateTime _endDate;
        private readonly ITollStationService _tollStationService;
        private readonly IRoadTollPaymentService _paymentService;
        private readonly IEnumerable<TollStation> _tollStations;
        private Currency _eurCode;
        private Currency _rsdCode;
        #endregion

        #region Properties
        public IEnumerable<DataTableDTO> TollStations => _tollStationsDTO;
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
        public GlobalIncomeReportViewModel(ITollStationService tollStationService, ICurrencyService currencyService)
        {
            _rsdCode = currencyService.GetCurrencyByCode("rsd");
            _eurCode = currencyService.GetCurrencyByCode("eur");
            _tollStationService = tollStationService;
            _startDate = DateTime.Now;
            _endDate = DateTime.Now;
            _tollStations = _tollStationService.ReadAll();
            LoadData();
        }

        private void LoadData()
        {
            _tollStationsDTO = new ObservableCollection<DataTableDTO>();
            double totalRSD = 0;
            double totalEUR = 0;
            foreach(var tollStation in _tollStations)
            {
                double incomeRSD = _tollStationService.GetIncome(tollStation, StartDate, EndDate, _rsdCode);
                totalRSD += incomeRSD;
                double incomeEUR = _tollStationService.GetIncome(tollStation, StartDate, EndDate, _eurCode);
                totalEUR += incomeEUR;
                DataTableDTO obj = new DataTableDTO(tollStation.Name, incomeRSD, incomeEUR);
                _tollStationsDTO.Add(obj);
            }
            _tollStationsDTO.Add(new DataTableDTO("TOTAL", totalRSD, totalEUR));
            OnPropertyChanged(nameof(TollStations));
        }
    }
}
