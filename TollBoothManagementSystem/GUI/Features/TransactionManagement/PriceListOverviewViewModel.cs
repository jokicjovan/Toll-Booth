using System.Collections.Generic;
using System.Collections.ObjectModel;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;
using TollBoothManagementSystem.Core.Utility.HelperClasses;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.TransactionManagement
{
    public class PriceListOverviewViewModel : ViewModelBase
    {
        public class DataTable
        {
            private double _category1ARSD;
            private double _category1RSD;
            private double _category2RSD;
            private double _category3RSD;
            private double _category4RSD;

            public double Category1A => _category1ARSD;
            public double Category1 => _category1RSD;
            public double Category2 => _category2RSD;
            public double Category3 => _category3RSD;
            public double Category4 => _category4RSD;

            public DataTable(double category1ARSD, double category1RSD, double category2, double category3, double category4)
            {
                this._category1ARSD = category1ARSD;
                this._category1RSD = category1RSD;
                this._category2RSD = category2;
                this._category3RSD = category3;
                this._category4RSD = category4;
            }
        }

        #region Attributes

        private IRoadTollService _roadTollService;
        private ISectionService _sectionService;
        private IPriceListService _priceListService;
        private Section _selectedSection;
        private TollStation _selectedStation;
        private PriceList _selectedPriceList;
        private ObservableCollection<DataTable> _dataTables;

        #endregion

        #region Properties

        public Section SelectedSection
        {
            get => _selectedSection;
            set
            {
                _selectedSection = value;
                OnPropertyChanged(nameof(SelectedSection));
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

        public PriceList SelectedPriceList
        {
            get => _selectedPriceList;
            set
            {
                _selectedPriceList = value;
                OnPropertyChanged(nameof(SelectedPriceList));
            }
        }

        #endregion

        #region Collections

        public IEnumerable<DataTable> DataTables
        {
            get => _dataTables;
        }

        #endregion

        //private void setDataTable()
        //{
        //    List<double> pList;
        //    int i = 0;
        //    foreach (var roadToll in _allRoadTolls)
        //    {
        //        ROADTOLLPRICE RTP = SERVICE.VRATI ROAD TOLL PRICE ZA roadToll i current pricelist
        //        plist.add(RTP)
        //        if i deljivo sa 5 DataTable = new datatable i doubleovi u njega. potom dodati u _dataTables
        //    }
        //}

        private void setRoadTolls()
        {
            List<RoadToll> allRT = _roadTollService.RoadTollsForSection(_selectedSection);
            foreach (var rt in allRT)
            {
                _allRoadTolls.Add(rt);
            }
            //setDataTable();

        }

        public PriceListOverviewViewModel(IRoadTollService roadTollService, ISectionService sectionService, IPriceListService priceListService)
        {
            _dataTables = new ObservableCollection<DataTable>();
            _allRoadTolls = new ObservableCollection<RoadToll>();

            _roadTollService = roadTollService;
            _sectionService = sectionService;
            _priceListService = priceListService;
            //_currentTollStation = GlobalStore.ReadObject<Administrator>("LoggedUser").TollStation;
            //_currentSection = _sectionService.GetSection(_currentTollStation);
            //_currentPriceList = _priceListService.CurrentPriceListForSection(_currentSection);

            //setRoadTolls();
        }

    }
}
