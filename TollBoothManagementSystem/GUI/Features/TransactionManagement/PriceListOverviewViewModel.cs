using System.Collections.Generic;
using System.Collections.ObjectModel;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Service;
using TollBoothManagementSystem.GUI.Utility.ViewModel;

namespace TollBoothManagementSystem.GUI.Features.TransactionManagement
{
    public class PriceListOverviewViewModel : ViewModelBase
    {
        #region Attributes

        private IRoadTollService _roadTollService;
        private TollStation _currentTollStation;
        private Section _currentSection;

        #endregion

        #region Properties

        public TollStation CurrentTollStation
        {
            get => _currentTollStation;
            set
            {
                _currentTollStation = value;
                OnPropertyChanged(nameof(CurrentTollStation));
            }
        }

        #endregion

        #region Collections

        private readonly ObservableCollection<RoadToll> _allRoadTolls;
        public IEnumerable<RoadToll> AllRoadTolls => _allRoadTolls;

        #endregion

        private void setRoadTolls()
        {
            List<RoadToll> allRT = _roadTollService.RoadTollsForSection(_currentSection);
            foreach (var rt in allRT)
            {
                _allRoadTolls.Add(rt);
            }

        }

        public PriceListOverviewViewModel(IRoadTollService roadTollService)
        {
            _roadTollService = roadTollService;

            _allRoadTolls = new ObservableCollection<RoadToll>();

            setRoadTolls();
        }

    }
}
