using System;


namespace Essai1_InjectionDependance.Entities
{
    public class AfficheurNoirEtBlanc: IAfficheur
    {
        public AfficheurNoirEtBlanc()
        {
            Console.WriteLine("Dans le constructeur de AfficheurNoirEtBlanc");
        }

        public void display()
        {

            Console.WriteLine("J'affiche en Noir et Blanc.");

        }
    }
}
