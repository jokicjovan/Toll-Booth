﻿using System.ComponentModel;
using System.Windows;
using TollBoothManagementSystem.Core.Utility.Commands;
using TollBoothManagementSystem.GUI.Features.Infrastructure;

namespace TollBoothManagementSystem.Core.Features.Infrastructure.Commands
{
    public class DeleteTollStationCommand : CommandBase
    {
        private TollStationsViewModel _viewModel;
        public DeleteTollStationCommand(TollStationsViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.SelectedTollStation))
            {
                OnCanExecuteChange();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !(_viewModel.SelectedTollStation == null) && !(_viewModel.SelectedSection.Origin.Id == _viewModel.SelectedTollStation.Id ) 
                && !(_viewModel.SelectedSection.Destination.Id == _viewModel.SelectedTollStation.Id) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (MessageBox.Show("Are you sure you want to delete this station?\nAll employess will be fired!", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var section = _viewModel.SectionService.GetSection(_viewModel.SelectedTollStation);
                section.TollStations.Remove(_viewModel.SelectedTollStation);
                _viewModel.SectionService.Update(section);

                _viewModel.TollStationService.FireAllEmployees(_viewModel.SelectedTollStation);
                _viewModel.TollStationService.Delete(_viewModel.SelectedTollStation.Id);

                _viewModel.Search();
                MessageBox.Show("TollStation deleted successfully");
            }
        }
    }
}
