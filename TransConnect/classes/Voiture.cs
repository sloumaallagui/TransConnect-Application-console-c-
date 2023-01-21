
using System;
using interfaces;
public class Voiture : Vehicule, ISerialisable
{   public static  double PRIX = 400;
    public Voiture(int nbPassager)
    {
        NbPassager = nbPassager;
    }
    public int NbPassager { get; set; }
    public override string ToString()
    {
        return $"Voiture,{NbPassager}";
    }
   
}