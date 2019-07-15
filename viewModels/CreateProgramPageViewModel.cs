using AppMicroondas.Models;
using AppMicroondas.Utils;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppMicroondas.ViewModels
{
	public class CreateProgramPageViewModel : BindableBase
	{
        
        private string _nameProgram;
        private string _descriptionProgram;
        private int _timeProgram;
        private int _powerProgram;
        private char _charSpecialProgram;

        private INavigationService _navigationService;
        Program _program = new Program();
        public DelegateCommand SaveCommand { get; private set; }


        public string NameProgram
        {
            get
            {
                return _nameProgram;
            }
            set
            {
                SetProperty(ref _nameProgram, value);
            }
        }

        public string DescriptionProgram
        {
            get
            {
                return _descriptionProgram;
            }
            set
            {
                if (_descriptionProgram != value)
                {
                    _descriptionProgram = value;
                }
            }
        }

        public int TimeProgram
        {
            get
            {
                return _timeProgram;
            }
            set
            {
                if (_timeProgram != value)
                {
                    _timeProgram = value;
                }
            }
        }

        public int PowerProgram
        {
            get
            {
                return _powerProgram;
            }
            set
            {
                if (_powerProgram != value)
                {
                    _powerProgram = value;
                }
            }
        }

        public char CharSpecial
        {
            get
            {
                return _charSpecialProgram;
            }
            set
            {
                if (_charSpecialProgram != value)
                {
                    _charSpecialProgram = value;
                }
            }
        }


        public CreateProgramPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SaveCommand = new DelegateCommand(ExecuteSave);
        }

        private void ExecuteSave()
        {
            try
            {
                ValidaTempo();
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Alerta", "Parametro do Tempo fora do limite", "OK");
                return;
            }
            try
            {
                ValidaPotencia();
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Alerta", "Parametro da Potência fora do limite", "OK");
                return;
            }
            try
            {
                ValidaPrograma();
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Alerta", "Programa com nome já existente", "OK");
                return;
            }
          

            DataBase.getInstance().Programs.Add(new Program(NameProgram, DescriptionProgram, TimeProgram, PowerProgram, CharSpecial));
            _navigationService.GoBackToRootAsync();
        }

        private void ValidaTempo()
        {          
            if (TimeProgram > 120)
                    throw new Exception();
            if (TimeProgram < 1)
                throw new Exception();
        }

        private void ValidaPotencia()
        {
            if (PowerProgram > 10)
                throw new Exception();
            if (PowerProgram < 1)
                throw new Exception();
        }

        private void ValidaPrograma()
        {
            var searchResults = (from a in DataBase.getInstance().Programs
                                 where a.Name == NameProgram
                                 select a).FirstOrDefault();
            if (searchResults != null)
                throw new Exception();
        }
    }
}
