using Essai1_InjectionDependance.Entities;


namespace Essai1_InjectionDependance
{
    public class EntitiesFactory
    {
        private readonly MyModeEnum _myMode;

        public static EntitiesFactory getSingleton(MyModeEnum myMode)
        {
            return new EntitiesFactory(myMode);
        }
        private EntitiesFactory(MyModeEnum myMode)
        {
            this._myMode = myMode;
        }

        public IAfficheur getAfficheur()
        {
            IAfficheur oAfficheur = (this._myMode == MyModeEnum.couleur) ?
                new AfficheurCouleur() : new AfficheurNoirEtBlanc();

            return (oAfficheur);
        }
    }
}
