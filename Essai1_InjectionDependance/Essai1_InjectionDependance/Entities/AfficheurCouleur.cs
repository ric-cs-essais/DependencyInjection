

using System;

namespace Essai1_InjectionDependance.Entities
{
    public class AfficheurCouleur: IAfficheur
    {
        public AfficheurCouleur()
        {

            Console.WriteLine("Dans le constructeur de AfficheurCouleur");

        }

        public void display()
        {

            Console.WriteLine("J'affiche en COULEURS !!");

        }
    }
}
