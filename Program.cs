using System;
using static AsposeMoneyBank;

namespace folderCS
{
    class Program
    {
        static void Main(string[] args)
        {
            /* / Task 1:
            Change sumaDisponibila = new Change(200, 200, 200, 200, 200);
            Change restulCerut;
            double sumaCeruta = 233.46;
            int sumaInCenti = Convert.ToInt32(sumaCeruta * 100);

            Console.WriteLine(sumaInCenti + " cents.\n");
            sumaDisponibila.printChange(sumaDisponibila);
            Console.WriteLine(sumaDisponibila.ChangeInCents(sumaDisponibila));

            restulCerut = getChange(sumaInCenti, sumaDisponibila);
            Console.WriteLine("Rest:");
            restulCerut.printChange(restulCerut);
            /*
            functia primeste o suma ce trebuie sa o dea dret rest, asta e singura ei sarcina
            rezultatul returnat e reprezentat in format obiect
            */

            // Task 2:
            



        }
    }
}

//start the program: >dotnet run

public class AsposeMoneyBank
{
    
    public static Change getChange(int cents, Change availableChange)
    {
        Change rest = new Change(0, 0, 0, 0, 0);
        int _availableChange = availableChange.ChangeInCents(availableChange);
        int nrDivizat;

        //M-am inspirat din Metoda Greedy, incompleta
        while (cents > 0) //atata timp cat suma ce trebuie returnata este mai mare decat zero o actiune trebuie luata
        {
            if (cents < _availableChange)
            {
                /*foreach( int element in banknotesOrCoins)
                {
                    rest.MultipleSet(nrDivizat = Math.DivRem(cents, element, out nrDivizat), element);
                    cents -= nrDivizat * element;
                }*/
                rest.setDollars(nrDivizat = Math.DivRem(cents, 100, out nrDivizat));
                cents -= nrDivizat * 100;
                rest.setQuarters(nrDivizat = Math.DivRem(cents, 25, out nrDivizat));
                cents -= nrDivizat * 25;
                rest.setDimes(nrDivizat = Math.DivRem(cents, 10, out nrDivizat));
                cents -= nrDivizat * 10;
                rest.setNickels(nrDivizat = Math.DivRem(cents, 5, out nrDivizat));
                cents -= nrDivizat * 5;
                rest.setCents(nrDivizat = Math.DivRem(cents, 1, out nrDivizat));
                cents -= nrDivizat * 1;
                
                Console.WriteLine(cents);
                Console.WriteLine(_availableChange);
                if (cents == 0) // daca suma este livrata complet se incheie programul 
                {
                    _availableChange -= cents; //suma ramasa in atm
                    return rest;
                }
            }
            else
            { 
                // in caz in care suma nu este livrata, actiunea se intrerupe.
                Console.WriteLine("Suma indisponibila!");
                break;
            }
        }
        
        throw new NotImplementedException();

        /** This method should take two parameters                
         1.cents as an Integer, and                 
         2.availableChange as a Change object (see below)
         * It should return the same amount, or the maximum amount possible,  in dollars and coins given what change is available in the availableChange parameter.  
         * It should use the minimum number of coins possible,  given what is available in availableChange. For example: 164 cents = 1 dollar, 2 quarters, 1 dime and 4 cents.              
         * Return null if the parameter is negative. 
        */
    }

    // Please do not change this class         
    public class Change
    {
        private int _dollars; // 100 cents             
        private int _quarters; //25 cents            
        private int _dimes; // 10 cents             
        private int _nickels; // 5 cents             
        private int _cents; // 1 cent  
        public Change(int dollars, int quarters, int dimes, int nickels, int cents)
        {
            _dollars = dollars;
            _quarters = quarters;
            _dimes = dimes;
            _nickels = nickels;
            _cents = cents;
        }
        public int getDollars() { return _dollars; }
        public int getQuarters() { return _quarters; }
        public int getDimes() { return _dimes; }
        public int getNickels() { return _nickels; }
        public int getCents() { return _cents; }
        public void setDollars(int dollars) { _dollars = dollars; }
        public void setQuarters(int quarters) { _quarters = quarters; }
        public void setDimes(int dimes) { _dimes = dimes; }
        public void setNickels(int nickels) { _nickels = nickels; }
        public void setCents(int cents) { _cents = cents; }
        public void MultipleSet(int valoare, int element)
        {
            if(element==100){setDollars(valoare);}
            if(element==100){setQuarters(valoare);}
            if(element==100){setDimes(valoare);}
            if(element==100){setNickels(valoare);}
            if(element==100){setCents(valoare);}
        }
        enum banknotesOrCoins //valorile sunt reprezentate in centi
        {   
            __dollars = 100,
            __quarters = 25,
            __dimes = 10,
            __nickels = 5,
            __cents = 1
        }
        public void printChange(Change change)
        {
            Console.Write("###Suma: " +
            change.getDollars() + " dollars," +
            change.getQuarters() + " quarters," +
            change.getDimes() + " dimes," +
            change.getNickels() + " nickels," +
            change.getCents() + " cents.\n");
        }
        public int ChangeInCents(Change change)
        {
            int sum;
            return sum =
            change.getDollars() * 100 +
            change.getQuarters() * 25 +
            change.getDimes() * 10 +
            change.getNickels() * 5 +
            change.getCents() * 1;
        }
        /*public Change SetArrayToChange(Change change, Array array)
        {
            return change = change(setDollars(array[0]));
        }*/
    }

}
/*
Timpul in care s-a realizat: 3:30 - 4:00 ore
https://www.includehelp.com/dot-net/make-a-simple-atm-machine.aspx
https://stackoverflow.com/questions/14728422/c-sharp-importing-class-into-another-class-doesnt-work
https://www.w3schools.com/cs/cs_method_parameters.php
https://www.tutorialspoint.com/chash-program-to-convert-a-double-to-an-integer-value
*! Cursurile si temele pe acasa date de la facultate. PCLP2 cursurile si examenul.
*/