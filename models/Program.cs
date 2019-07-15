using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MicroondasApp.ViewModels;


namespace AppMicroondas.Models
{
    public class Program : Settings
    {
        private string _name;
        private string _description;
        private int _tempo;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public int Tempo
        {
            get
            {
                return _tempo;
            }
            set
            {
                SetProperty(ref _tempo, value);
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
            }
        }

        public Program(String Name, String Description, int Power, int Tempo, char CharHeating)
        {
            this.Name = Name;
            this.Description = Description;
            this.Power = Power;
            this.CharHeating = CharHeating;
            this.Tempo = Tempo;
            AddTime(Tempo);
        }

        public Program()
        {

        }

        public static ObservableCollection<Program> StartProgram()
        {
            ObservableCollection<Program> programs = new ObservableCollection<Program>();
            var program = new Program("Carne", "Descogelamento de Carne", 10, 120, '+');
            programs.Add(program);

            program = new Program("Pipoca", "Preparar Pipoca", 5, 45, '*');
            programs.Add(program);

            program = new Program("Arroz", "Fazer arroz ", 3, 90, '&');
            programs.Add(program);

            program = new Program("Pizza", "Pizzas Média/Grande", 7, 90, '$');
            programs.Add(program);
           

            program = new Program("Macarrão", "Fazer Macarrão", 7, 90, '=');
            programs.Add(program);

            return programs; 
        }

    }
}

