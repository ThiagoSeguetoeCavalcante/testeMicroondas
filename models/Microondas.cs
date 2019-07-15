using System;
using System.Threading.Tasks;
using MicroondasApp.ViewModels;
using Prism.Navigation;

namespace AppMicroondas.Models
{
    public class Microondas : IEMicroondas, IIMicroondas
    {
        public Settings Settings { get; set; }
        public Controller Controller { get; set; }

        public Microondas()
        { 
            Settings = new Settings();
            Controller = new Controller();
        }

        public void DefinitionPower(int power)
        {
            if (power < 1)
                throw new Exception("A potência não pode ser 0");
            if (power > 10)
                throw new Exception("A potência não pode ser maior do que 10");
        }

        public void DefinitionTime(DateTime time)
        {
            var tempo = time.Minute * 60 + time.Second;
            if (tempo > 120)
                throw new Exception("O tempo não pode ser maior que 2 minutos");
            if(tempo < 1)
                throw new Exception("O tempo não pode ser menor que 1 segundo");
            if (tempo == 0)
                throw new ArgumentException();
        }

        public void ConfigureStartFast()
        {
            this.Settings.ZerarTime();
            this.Settings.AddTime(30);
            this.Settings.Power = 8;
        }

        public void Execute(Settings Settings)
        {
            this.Settings = Settings;
            if (String.IsNullOrEmpty(this.Settings.Program))
            {
                try
                {
                    DefinitionTime(this.Settings.Time);
                    DefinitionPower(this.Settings.Power);
                }
                catch (ArgumentException)
                {
                    ConfigureStartFast();
                }
            }
        }
    }
}
