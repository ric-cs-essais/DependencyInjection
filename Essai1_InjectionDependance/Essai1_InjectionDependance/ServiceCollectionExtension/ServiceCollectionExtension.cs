
using Essai1_InjectionDependance.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Essai1_InjectionDependance
{
    //Principe pour ajouter une méthode à toute instance de type IServiceCollection.
    //Dés lors que le namespace de la présente classe est connu ou inclus (using).  (principe basique de la méthode d'extension).
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddAfficheurCouleurAsSingleton(this IServiceCollection poServicesCollection)
        {
            poServicesCollection.AddSingleton<IAfficheur, AfficheurCouleur>();

            return (poServicesCollection); //<< pas obligatoire, mais Juste pour que l'on puisse encore chaîner les appels (déréférencement)
        }
    }
}
