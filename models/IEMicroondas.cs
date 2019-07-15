using System;
using System.Collections.Generic;
using System.Text;

namespace AppMicroondas.Models
{
    interface IEMicroondas
    {
        void DefinitionTime(DateTime time);
        void DefinitionPower(int power);

        /*
        void SetProgram();
        void Start();
        
         void Pause();
         void End();
         */
    }
}

