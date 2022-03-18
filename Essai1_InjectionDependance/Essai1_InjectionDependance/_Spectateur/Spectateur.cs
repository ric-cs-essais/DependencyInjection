using System;

using Essai1_InjectionDependance.Entities;


namespace Essai1_InjectionDependance._Spectateur
{
    public class Spectateur
    {
        IAfficheur _oAfficheur;

        public Spectateur(IAfficheur poAfficheur) //Injection dépendance
        {
            this._oAfficheur = poAfficheur;
            Console.WriteLine("Dans le constructeur de Spectateur");
        }

        public void allumerAfficheur()
        {
            this._oAfficheur.display();
        }
    }
}
