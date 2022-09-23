
using System; ///Pour Console

using Microsoft.Extensions.DependencyInjection; //Issu du NuGet Microsoft.Extensions.DependencyInjection, et permettant de faire de l'injection de dépendances.


using Essai1_InjectionDependance.Entities;
using Essai1_InjectionDependance._Spectateur;


namespace Essai1_InjectionDependance
{
    static class Program
    {
        static void Main()
        {

            IServiceCollection oServiceCollection = new ServiceCollection();
            _defineMyInjections1(oServiceCollection);
            _defineMyInjectionsViaFactory(oServiceCollection);

            Console.ReadKey();
        }


        private static void _defineMyInjections1(IServiceCollection poServicesCollection)
        {

            Console.WriteLine("\n\n_defineMyInjections1():\n");

            //REMARQUE : pour un type donné, ce sera le dernier Add...() qui fera foi, (en cas de doublon donc)
            poServicesCollection
                .AddTransient<IAfficheur, AfficheurNoirEtBlanc>() //Sera écrasé par la ligne ci-dessous (IAfficheur)
                .AddSingleton<IAfficheur, AfficheurCouleur>() //<<<Seul le dernier Add... (pour Afficheur), fait foi

                .AddTransient<Spectateur, Spectateur>() //<<<< uniquement pour que la classe Spectateur puisse bénéficier d'une injection de dépendance (grâce à appel ci-dessous à GetService<Spectateur>())
                                                        //Parce-que Spectateur est la première classe que l'on va instancier, le point départ des autres instanciations automatiques.
                ;

            IServiceProvider oServicesProvider = poServicesCollection.BuildServiceProvider();

            
            //-----------------------

            //IAfficheur oAfficheur = oServicesProvider.GetService<IAfficheur>(); //Cas basique, peu d'intérêt ici
            //oAfficheur.display();


            Spectateur oSpectateur = oServicesProvider.GetService<Spectateur>(); //<<< à la place d'un new Spectateur(??)
            oSpectateur.allumerAfficheur();

            //Ci-dessous, ne rappellera pas le constructeur du IAfficheur, du fait du AddSingleton.
            //Par contre rappellera le constructeur de Spectateur car AddTransient.
            Spectateur oSpectateur2 = oServicesProvider.GetService<Spectateur>(); //<<< à la place d'un new Spectateur(??)
            oSpectateur2.allumerAfficheur();


            //*** Différence entre AddSingleton, AddTransient et AddScoped :
            //  AddSingleton(): il n'y aura qu'une unique instance de la classe, pour tout besoin(injection) du type en question.
            //  AddTransient(): il y aura création d'une instance différente de la classe à chaque besoin(injection)  besoin du type en question.
            //  AddScoped(): ré-instanciation que si chgt de scope (scope??), typiquement en ASP.NET, on parle de nouveau scope, à chaque nouvelle requête HTTP.
        }

        private static void _defineMyInjectionsViaFactory(IServiceCollection poServicesCollection)
        {

            Console.WriteLine("\n\n\n_defineMyInjectionsViaFactory():\n");

            //Via une Factory, on fournit directement l'instance de type IAfficheur
            poServicesCollection
                .AddSingleton(
                    (IServiceProvider poServiceProvider) =>
                        EntitiesFactory.getSingleton(MyConfig.modeActuel).getAfficheur() //IAfficheur ok
                        //new AfficheurCouleur() //<<<<fonctionne aussi tel quel :)
                )
                //.AddAfficheurCouleurAsSingleton() //<<<<< Méthode d'extension perso. . Ce Add... résultant prendrait le dessus sur le AddSingleton ci-dessus si l'on décommentait, car placé après !
                .AddSingleton<Spectateur, Spectateur>() //<<<< uniquement pour que la classe Spectateur puisse bénéficier d'une injection de dépendance (grâce à appel ci-dessous à GetService<Spectateur>())
                                                        //Parce-que Spectateur est la première classe que l'on va instancier, le point départ des autres instanciations automatiques.
                ;

            IServiceProvider oServicesProvider = poServicesCollection.BuildServiceProvider();


            //-----------------------

            Spectateur oSpectateur = oServicesProvider.GetService<Spectateur>(); //<<< à la place d'un new Spectateur(??)
            oSpectateur.allumerAfficheur();

            //Ci-dessous, ne rappellera pas le constructeur du IAfficheur, du fait du AddSingleton.
            //Idem pour le constructeur de Spectateur car AddSingleton aussi.
            Spectateur oSpectateur2 = oServicesProvider.GetService<Spectateur>(); //<<< à la place d'un new Spectateur(??)
            oSpectateur2.allumerAfficheur();


        }


    }
}
