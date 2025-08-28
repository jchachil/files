using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Guerrier
    {
        private string name;

        public Guerrier(string name)
        {
            this.name = name;
        }

        public int Health { get; set; } = 100;
        public int Experience { get; set; } = 0;

        public void combattre(Guerrier enemy, int swings)
        {
            enemy.Health = Math.Max(0, enemy.Health - (swings * 10));
            enemy.Experience += 2;
        }
    }

    class Animal
    {
        public void HandleAnimal(Animal a)
        {

        }
    }

    class Felin : Animal
    {

        public void HandleFelin(Felin f)
        {

        }

    }

    public class Node
    {
        public Node left, right;
        public int value;

        public Node Find(int k)
        {
            if (this.Equals(null))
                return null;
            Node node = this;

            while (node != null)
            {
                if (node.value == k)
                    return node;
                else
                {
                    if (node.value > k)
                        node = node.left;
                    else if (node.value < k)
                        node = node.right;
                }
            }
            return node;
        }
    }

    class Order
    {
        public string Customer { get; set; }
        public decimal Price { get; set; }

        public Custom Custom { get; set; }
    }

    class Custom
    {
        public string Name { get; set; }
    }

    interface Imovable
    {
        void Move(int x, int y);
    }

    //interface CapablDeVoler
    //{
    //    void voler();
    //}

    //abstract class Avion : CapablDeVoler
    //{
    //    public abstract void voler();

    //}

    abstract class Avion
    {
        public abstract void voler();

    }
    abstract class Oiseau : Avion
    {

    }


    class Animation : Imovable
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public void Move(int x, int y)
        {
            Console.WriteLine("X={x}/ Y={y}");
            X = x;
            Y = y;
        }

    }

    public class Client
    {
        public string Name { get; set; }
        public BankAccount Account { get; set; }
    }
    public class BankAccount
    {
        public Decimal Balance { get; set; } = 99.9m;

    }

    public class Test
    {
        protected internal int Prop1 { get; set; }
        public decimal ExtraPrice { get; set; } = 0.25m;

    }

    delegate int NumberChanger(int n);


    public class Simple
    {
        public int x { get; set; }
        public virtual void fun()
        {
            x = 1;

        }

    }

    public class DerivedSimple : Simple
    {
        new public void fun()
        {
            base.x = 10;
            Console.WriteLine("oki");

        }
    }

    public class MyContainer<T> where T : IComparable
    {
        //
    }




    class X<T>
    {
        public static void PrintType()
        {
            Type t = typeof(X<X<T>>);
            Console.WriteLine(t);
        }
    }

    public class Parent
    {
        public string Name { get; private set; }

        public Parent(string name)
        {
            Name = name;
        }
        public Parent()
        {
        }
    }


    public partial class Question
    {
        private string pattern = @"(^|\n)(?<optionName>[a-z0-9- ]+)=(?<value>[^\r]+)";
        public Dictionary<string, string> GetOptionDictionary(string optionText)
        {
            Dictionary<string, string> options = new Dictionary<string, string>();
            //----------NE MODIFIEZ PAS LE CODE AU DESSUS DE CETTE LIGNE, IL SERA REINITIALISE LORS DE l'EXECUTION----------

            Regex expression = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            foreach (Match match in expression.Matches(optionText))
            {
                options.Add(match.Groups["optionName"].Value, match.Groups["value"].Value);
            }

            //----------NE MODIFIEZ PAS LE CODE EN DESSOUS DE CETTE LIGNE, IL SERA REINITIALISE LORS DE l'EXECUTION----------
            return options;
        }
    }

    public class Child : Parent
    {
        //----------NE MODIFIEZ PAS LE CODE AU DESSUS DE CETTE LIGNE, IL SERA REINITIALISE LORS DE l'EXECUTION----------
        public Child(string name) : base(name)
        {


        }
        //----------NE MODIFIEZ PAS LE CODE EN DESSOUS DE CETTE LIGNE, IL SERA REINITIALISE LORS DE l'EXECUTION----------
    }

    interface IVehicle
    {
        string Location { get; }
        int NumberOfSeats { get; }
        void MoveTo(string city);
    }
    //----------NE MODIFIEZ PAS LE CODE AU DESSUS DE CETTE LIGNE, IL SERA REINITIALISE LORS DE l'EXECUTION----------
    public class Car : IVehicle
    {
        public int NumberOfSeats { get; set; } = 5;

        public string Location { get; set; }
        public void MoveTo(string city)
        {
            Location = city;
        }

    }

    class Fruit { }
    class Banana : Fruit { }
    class Apple : Fruit { }

    interface IVariant<out R, in A>
    {
        R GetR();
        void SetA(A simpleArg);
        R GetRSetA(A simpleArg);
        //A GetA();// eliminer la methode GetA() pour que le code compile

    }

    class Change
    {
        public long coin2 = 0;
        public long bill5 = 0;
        public long bill10 = 0;
    }


    abstract class ShapesClass
    {
        abstract public int Area();
    }
    class Square : ShapesClass
    {
        int side = 0;

        public Square(int n)
        {
            side = n;
        }
        // Area method is required to avoid
        // a compile-time error.
        public override int Area()
        {
            return side * side;
        }
    }

    class Program
    {

        public DateTime DateOfBirth { get; set; }

        //public TimeSpan Age() => DateTime.UtcNow - this.DateOfBirth;
        //public TimeSpan Age => DateTime.UtcNow - this.DateOfBirth;


        public static bool QualifiesForDiscount(Order order)
        {

            var a = order?.Custom?.Name == "john";//OK 
                                                  //var b =  null?? order?.Custom?.Name == "john";//ne compile pas
                                                  ////var c =  order ?? order.Custom ?? order.Custom.Name == "john"; // ne compile pas 
                                                  //return order != null && order.Custom != null && order.Custom.Name == "john";

            return true;
        }
        //bool aa=  QualifiesForDiscount(new Order() { });
        // (null);
        public static int StackLine { get; set; } = 4;

        static int num = 10;
        public static int Add(int p) { return num += p; }
        public static int Multiply(int q) { return num *= q; }

        //public static bool operator ==(object i , object j)
        //{

        //    return true;

        //}

        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string FullName => $"{FirstName} {LastName}";


        public static Func<int, int> GetFunc()
        {
            var myVar = 1;
            Func<int, int> inc = delegate (int var1)
           {
               myVar = myVar + 1;
               return myVar + var1;
           };
            myVar++;
            return inc;
        }


        public static IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }

        static object DynamicMethod(int id)
        {
            var process = Process.GetCurrentProcess();

            return process.Modules;
        }

        static void TestMethode()
        {
            dynamic id = 1;
            var result = DynamicMethod(id);
            Console.WriteLine(result.Count);//affiche le nombre de process

        }

        class Element
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
            public int AtomicNumber { get; set; }


        }

        static List<Element> BuildList()
        {
            return new List<Element>
                {
                    { new Element() { Symbol="K", Name="Potassium", AtomicNumber=19}},
                    { new Element() { Symbol="Ca", Name="Calcium", AtomicNumber=20}},
                    { new Element() { Symbol="Sc", Name="Scandium", AtomicNumber=21}},
                    { new Element() { Symbol="Ti", Name="Titanium", AtomicNumber=22}},
                    { new Element() { Symbol="V", Name="Vanadium", AtomicNumber=23}},
                    { new Element() { Symbol="Cr", Name="Chromium", AtomicNumber=24}}
                };
        }

        private static void showMatch(string text, string expr)
        {
            Console.WriteLine("The Expression: " + expr);
            MatchCollection mc = Regex.Matches(text, expr);

            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
        }

        // Do not modify this method​​​​​​‌​​‌​​​​‌​​‌​​​‌​‌‌‌​​‌‌‌ signature
        public static Change OptimalChange(long s)
        {
            var resultat10 = NbrBillet10(s);
            var resultat5 = NbrBillet5(s, resultat10);
            var resutlat2 = NbrBillet2(s, resultat10, resultat5);
            if (resutlat2 == null)
            {
                Change ch = OptimalChange5(s);
                if (ch == null)
                    ch = OptimalChange2(s);
                return ch;
            }

            else
            {
                var chng = new Change
                {
                    bill10 = resultat10,
                    bill5 = resultat5,
                    coin2 = resutlat2.Value
                };

                return chng;
            }
        }
        public static Change OptimalChange5(long s)
        {


            var resultat5 = NbrBillet5(s, 0);
            var resutlat2 = NbrBillet2(s, 0, resultat5);
            if (resutlat2 == null)
                return null;
            else
            {
                var chng = new Change
                {
                    bill10 = 0,
                    bill5 = resultat5,
                    coin2 = resutlat2.Value
                };

                return chng;
            }
        }

        public static Change OptimalChange2(long s)
        {


            var resultat5 = 0;
            var resutlat2 = NbrBillet2(s, 0, resultat5);
            if (resutlat2 == null)
                return null;
            else
            {
                var chng = new Change
                {
                    bill10 = 0,
                    bill5 = resultat5,
                    coin2 = resutlat2.Value
                };

                return chng;
            }
        }

        public static long NbrBillet10(long s)
        {
            if (s < 10)
                return 0;

            var rest10 = s % 10;
            long resultat10 = s / 10;
            if (rest10 == 0)
                return resultat10;

            if (resultat10 > 0 && rest10 >= 2)
                return resultat10;

            if (rest10 < 2)
                return resultat10 - 1;

            return 0;
        }

        public static long NbrBillet5(long n, long nbr10)
        {
            long s = n - nbr10 * 10;

            //s reste 
            if (s < 5)
                return 0;

            var rest5 = s % 5;
            long resultat5 = s / 5;
            if (rest5 == 0)
                return resultat5;


            if (resultat5 > 0 && rest5 % 2 == 0)
                return resultat5;

            if (resultat5 > 0 && rest5 % 2 == 1)
                return resultat5 - 1;


            if (rest5 < 2 && resultat5 > 1)
                return resultat5 - 1;

            return 0;

        }

        public static long? NbrBillet2(long n, long nbr10, long nbr5)
        {
            long s = n - nbr10 * 10 - nbr5 * 5;

            //s reste 
            var rest2 = s % 2;
            var result2 = s / 2;
            if (rest2 == 0)
                return result2;
            else
                return null;



        }


        public static List<int> GetNbrPremiers(int nbr)
        {
            /*
             Un nombre premier est un entier naturel qui admet exactement deux diviseurs distincts entiers et positifs. Ces deux diviseurs sont 1 et le nombre considéré
             */

            var listNombre = Enumerable.Range(2, nbr - 1);
            var nbrPremier = from s in listNombre
                             where Enumerable.Range(2, s - 2).All(x => s % x != 0)
                             select s;
            return nbrPremier.ToList();


        }


        public static int Step(int n)
        {
            if (n == 0) return n;
            if (n == 1) return 1;
            if (n == 2) return -2;
            else
            {
                return Step(n - 1) - Step(n - 2);
            }

        }

        //public static int GetPositionAt(int n)
        //{
        //    if (n == 0) return 0;
        //    if (n == 1) return 1;
        //    if (n == 2) return -1;
        //    else
        //    {
        //        return GetPositionAt(n - 1) + Step(n);
        //    }

        //}

        public static int GetPositionAt(int n)
        {
            int position = -1;
            int lastStep = -2;
            int secondLastStep = 1;

            n = n % 6;
            if (n == 0 || n == 1)
                return n;

            int i = 3;
            while (i <= n)
            {
                position += lastStep - secondLastStep;
                lastStep -= secondLastStep;
                secondLastStep += lastStep;
                i++;
            }

            return position;
        }


        // The ThreadProc method is called when the thread starts.
        // It loops ten times, writing to the console and yielding
        // the rest of its time slice each time, and then ends.
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                // Yield the rest of the time slice.
                Thread.Sleep(0);
            }
        }

        static void TestThread()
        {
            Console.WriteLine("Main thread: Start a second thread.");
            // The constructor for the Thread class requires a ThreadStart
            // delegate that represents the method to be executed on the
            // thread.  C# simplifies the creation of this delegate.
            Thread t = new Thread(new ThreadStart(ThreadProc));

            // Start ThreadProc.  Note that on a uniprocessor, the new
            // thread does not get any processor time until the main thread
            // is preempted or yields.  Uncomment the Thread.Sleep that
            // follows t.Start() to see the difference.
            t.Start();
            //Thread.Sleep(0);

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            t.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");

        }

        static int Calc(int[] array, int n1, int n2)
        {
            int total = 0;
            array.ToList().GetRange(n1, n2 - n1 + 1).ForEach(x => total += x);
            return total;
        }

        static string LongestCommonEnding(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return "";

            if (s1.Length > s2.Length)
            {
                if (s1.Contains(s2))
                    return s2;
                else
                {
                    string str = s2.Substring(1, s2.Length - 1);
                    while (!string.IsNullOrEmpty(str))
                    {
                        if (s1.Contains(str))
                            return str;
                        else
                            str = str.Substring(1, str.Length - 1);

                    }
                    return "";
                }
            }

            return "";
        }

        static List<int> ExecutePermutation(List<int> values, List<int> permutations)
        {
            List<int> result = new List<int>();
            int cpt = 0;
            permutations.ForEach(elt =>
            {

                var nelt = values.Take(elt);
                var firstpart = nelt.Reverse();
                var lastPart = values.GetRange(elt, values.Count - elt);
                result = firstpart.Concat(lastPart).ToList();
                values = result;
            }
            );
            return result;

        }
        static int ComputeMultiplesum(int n)
        {
            List<int> listResult = new List<int>();

            //ici ComputeMultipleSum   3 5 7 
            List<int> listnumber = Enumerable.Range(1, n).ToList();
            listResult.AddRange(listnumber.Where(s => s % 3 == 0).ToList());
            listResult.AddRange(listnumber.Where(s => s % 5 == 0).ToList());
            listResult.AddRange(listnumber.Where(s => s % 7 == 0).ToList());

            int sum = listResult.Sum();


            return sum;

        }

        public static int ClosestToZero1(int[] ints)
        {
            //{ -1, -2, 1, 3 }
            if ((ints == null) || (ints != null && ints.Length == 0))
                return 0;
            else
            {
                Array.Sort(ints);
                int? minPositif = null;
                var listPost = ints.Where(a => a > 0);
                if (listPost != null)
                {
                    minPositif = listPost.Min();
                }

                //var maxNegatif = ints.Where(a => a < 0).Max();

                int closest = Math.Abs(ints[0]);
                for (int i = 0; i < ints.Length; i++)
                {
                    if (Math.Abs(ints[i]) < closest)
                        closest = Math.Abs(ints[i]);
                }
                return closest;
            }

        }

        static int Get(int l, int c)
        {
            if (l == c)
                return 1;
            else if (c == 0)
                return 1;
            else
                return Get(l - 1, c - 1) + Get(l - 1, c);

        }

        static int FindSmallestInterval(int[] numbers)
        {
            List<int> listDiff = new List<int>();
            var orderedList = numbers.ToList().OrderBy(a => a).ToList();
            for (int i = 1; i < orderedList.Count; i++)
            {
                listDiff.Add(orderedList[i] - orderedList[i - 1]);
            }
            int retValue = listDiff.Min();

            return retValue;
        }

        Func<int, int, int> Sum = (x, y) => x + y;

        static double CalculePIold()
        {
            double x, y; // coordonnees du point tiré au hasard
            double inCercle = 0; // nombre de points tombés dans le cercle
            double total = 1;  // nombre total de points
            double pi; // approximation de pi
            Random rnd = new Random(2);
            while (true)
            {
                x = rnd.NextDouble();
                y = rnd.NextDouble();
                if (x * x + y * y <= 1) // le point est tombé dans le cercle
                    inCercle++;
                total++;
                pi = 4 * (inCercle / total);
                return pi;
            }
        }
        static double CalculePI(int n)
        {

            //https://codes-sources.commentcamarche.net/source/100882-approximations-de-pi-methode-monte-carlo
            int k = 0;
            Random rnd = new Random();
            for (int i = 0; i < n; ++i)
            {
                double x = rnd.NextDouble(), y = rnd.NextDouble();
                if (x * x + y * y <= 1) k++;
            }
            return 4.0 * k / n;
        }

        public static bool testAnagram(string text1, string text2)
        {
            // abc et bca sont des anagrames : les meme caracteres
            /*
             *  ("wxyz", "zyxw") -> True
                ("pears", "spare") -> True
                ("stone", "tones") -> True
                ("cat", "rat") -> False
             */
            string stext1 = String.Concat(text1.ToUpper().OrderBy(c => c));
            string stext2 = String.Concat(text2.ToUpper().OrderBy(c => c));

            if (stext1 == stext2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //takes a string and reverses the words of three or more lengths in a string.
        //Return the new string. As input characters, only letters and spaces are permitted.
        public static string ReverseString(string text)
        {
            //exemple
            /*
                Original strings: The quick brown fox jumps over the lazy dog
                Reverse the words of three or more lengths of the said string:
                ehT kciuq nworb xof spmuj revo eht yzal god
             */
            return string.Join(" ", text.Split(' ').Select(x => x.Length >= 3 ? new string(x.Reverse().ToArray()) : new string(x.ToArray())));

        }

        public static int FindStringPosition(string text, string word)
        {
            /*
             *  find the position of a specified word in a given string.
                Original string: The quick brown fox jumps over the lazy dog.
                Position of the word 'fox' in the said string: 4
                Position of the word 'The' in the said string: 1
             */
            return Array.IndexOf(text.Split(' '), word) + 1;
        }

        public static int IndexOfWordOnString(string text, string word)
        {
            //  string str1 = "The quick brown fox jumps over the lazy dog.";
            //text.Substring(5);
            return Array.IndexOf(text.Split(' '), word) + 1;
        }

        public static int CountDiplicateCharacters(string text)
        {
            //count the number of duplicate characters (case sensitive) including spaces in a given string
            //("ppqrrsttuuu") -> 4
            return text.GroupBy(n => n).Count(n => n.Count() >= 2);
        }

        public static int FindParent(int processNumber)
        {
            if (processNumber == 1 || processNumber == 2)
                return 1;
            else if (processNumber == 3)
                return 2;
            else
            {

            }

            return 1;

        }


        public static int MaxProfit(int[] prices)
        {
            //[7,1,5,3,6,4]: 4+3 = 7
            //[1,2,3,4,5]:  4
            //[7,6,4,3,1]:   0

            //si les element sont ordonnes dans un ordre decroisant alors le profit est 0
            if (prices.OrderByDescending(x => x).SequenceEqual(prices))
            {
                return 0;
            }
            else
            {                        

                //le nombre max de transactions possible est prices.Count()
                /*
                 on fait une boucle sur le nombre de transactions et a a l interieur on boucle sur les jours 
                et on  calcul le profit max dans chaque jour
                 */

                int[,] profitList = new int[prices.Count() + 1, prices.Count()];

                for (int i = 1; i < prices.Count() + 1; i++)
                {
                    int maxProfil = -1;//
                    for (int day = 1; day < prices.Count(); day++)
                    {
                        maxProfil = Math.Max(maxProfil, profitList[i - 1, day - 1] - prices[day - 1]);
                        profitList[i, day] = Math.Max(profitList[i, day - 1], prices[day] + maxProfil);                        
                    }
                }

                //retourner le dernier element du tableau
                return profitList[prices.Count(), prices.Count() - 1];


            }


        }

        public static int MaxProfitWithKTransactions(int[] prices, int k)
        {
            int[,] profits = new int[k + 1, prices.Length];

            for (int t = 1; t < k + 1; t++)
            {
                int maxThusFar = -1;// Int32.MinValue;
                for (int d = 1; d < prices.Length; d++)
                {
                    maxThusFar = Math.Max(maxThusFar, profits[t - 1, d - 1] - prices[d - 1]);
                    profits[t, d] = Math.Max(profits[t, d - 1], prices[d] + maxThusFar);
                    //Console.WriteLine(profits[t, d]);
                }
            }

            return profits[k, prices.Length-1 ];
        }






        static void Main(string[] args)
        {  //         // Alt+060 (au clavier numérique) pour < ou Alt+062
           // D:\Jamal\JOB\Test 3 Mustapha\Test akka
           //https://www.dotnetforall.com/max-profit-with-k-transaction-solution-easy-explanation/

            int[] prices = new int[] { 7, 1, 5, 3, 5, 4 };// 1, 2, 3, 4, 8      7, 1, 5, 3, 6, 4 
             var aa = MaxProfitWithKTransactions(prices, 5);
            var cc = MaxProfit(prices);
            ;


            //var ninja = new Guerrier("Ninja");
            //var samurai = new Guerrier("Samurai");

            //samurai.combattre(ninja, 3);

            //Animal a = new Animal();
            //Felin f = new Felin();

            //a.HandleAnimal(f); //compile ? si non pourquoi ?

            //f.HandleFelin(a);



            string str = "fgrtr58,;";
            var charcharacters = str.Where(x => Char.IsLetter(x));
            //reverse the case
            string.Concat(str.Select(x => char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x)));


            //var ret = Check("(()[])");
            //ret = Check("([)]");
            //;
            //var test =   testAnagram("aze", "aez");
            ;

            //var aa = CalculePI(100000000);

            //List<string> maList = new List<string> { "Cat A","Cat B"};
            //var maListFiltre = maList.Select(x => x.ToLowerInvariant());
            //maList.Add("Cat C");
            //Console.WriteLine(string.Join(", ", maListFiltre)); //cat a, cat b, cat c


            //var i = 10;
            //object j = i;
            //i = 20;
            //j = (int)j + 10; //j = 20 , i = 20;
            //var isEqual = (object)i == j; //false
            //var isEqual2 = j.Equals(i);//false 
            //;

            //tournoi d echec composition des groupe:  pour n = 4 on a 6 binome
            //int p = n * (n - 1) / 2;
            //Console.WriteLine("CompinaisonPossible() => " + p);


            //var ret = GetPositionAt(3);
            //ret = GetPositionAt(4);
            //ret = GetPositionAt(5);            
            //ret = GetPositionAt(100000);


            //var files = Directory.GetFiles("/tmp/documents", "*.*", SearchOption.AllDirectories)
            //.Where(s => s.EndsWith("universe-formula")).FirstOrDefault();


            //var ret = Get(1, 0);
            //ret = Get(3, 1);
            //ret = Get(4, 2);
            //ret = Get(4, 3);
            //ret = Get(5, 3);
            //ret = Get(5, 4);

            //int ret = FindSmallestInterval(new int[] { 1, 6, 4, 8, 2 });
            //ret = FindSmallestInterval(new int[] { 1, 6, 5, 8, 10 });
            //;

            //var sd = new SortedDictionary<int, int>();
            //sd[3] = 3;
            //sd[2] = 1;
            //sd[1] = 2;
            //foreach (KeyValuePair<int, int> kvp in sd)
            //    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value); // kvp.Value:   2  1 3 


            //string s = "A";
            //s.ToLower();// s= A 




            //var ret =  ClosestToZero1(new int[] { -1, -2, 1, 3 });
            // ret =  ClosestToZero1(new int[] { -1, 2,-5, 1, 3 });

            //var aaa= ExecutePermutation(new List<int> { 2, 1, 3 }, new List<int> { 2 });
            //var result = ExecutePermutation(new List<int> { 4, 2, 1, 3 }, new List<int> { 4, 3, 2 });

            //int sum = ComputeMultiplesum(11);
            //sum = ComputeMultiplesum(12);
            //;
            //string ret = LongestCommonEnding("multiplication", "ration");
            //ret = LongestCommonEnding("potent", "tent");
            //ret = LongestCommonEnding("abderddd", "gtg");

            //List<string> str = new List<string>();
            //str.Where(s => s.StartsWith("L")).OrderBy(s => s);

            //var aaa = 2 >> 1;//1

            //var aaa = 1 << 2;//4

            //var dd = 01 | 11; //11

            //var result = Math.Round(5.5) + Math.Round(-6.5);//0

            //Cdiscount-18

            // ce block affiche ACD
            //try
            //{
            //    Console.WriteLine("A");
            //    int value = int.Parse("8A");
            //    Console.WriteLine("B");
            //}
            //catch
            //{
            //    Console.WriteLine("C");
            //    return;
            //}
            //finally
            //{
            //    Console.WriteLine("D");
            //}
            //Console.WriteLine("E");

            //calcul de PI
            //https://www.mathweb.fr/euclide/2020/02/01/determiner-une-valeur-approche-de-pi-a-laide-des-probabilites-methode-de-monte-carlo-sous-python/

            //ScanChar
            // https://www.xarg.org/puzzle/codingame/ascii-art/

            //int[] array = { 0, 1, 2, 3, 4, 5, 3 };
            //int total = Calc(array, 0, 1);//1
            //total = Calc(array, 0, 5);//15
            //total = Calc(array, 0, 0);//0


            //Struct struct1;
            //struct1.foo = 5;
            //Struct struct2 = struct1;
            //struct2.foo = 10;
            //Console.WriteLine( struct1.foo);//5
            //;

            //var hashset = new HashSet<int>();
            //hashset.Add(1);
            //hashset.Add(1);
            //hashset.Add(2);
            //var ss = hashset.Count; //2

            //TestThread();
            ;
            ////nbr premier 
            //var res = GetNbrPremiers(100);
            //foreach (var item in res)
            //    Console.WriteLine(item);

            // Enumerable.Repeat<int>(5, 10);

            //IList<int> collection1 = new List<int>() { 1, 2, 3 };
            //IList<int> collection2 = new List<int>() { 1, 5, 6, 5 };

            ////// var collection3 = collection1.Intersect(collection2);

            //var Collecion1Except = collection1.Except(collection2);
            //var Collecion2Except = collection2.Except(collection1);

            //var listSansDoublons = Collecion1Except.Union(Collecion2Except);//pas de doublons

            // foreach (var item in listSansDoublons)
            //     Console.WriteLine(item);


            //var test = new[] { "aaaa", "hhh" }.Max(c => c.Length); //4

            ////facade design pattern
            //Facade facade = new Facade();
            //facade.MethodA();
            //facade.MethodB();

            //// Configure Observer pattern
            //ConcreteSubject s = new ConcreteSubject();

            //s.Attach(new ConcreteObserver(s, "X"));
            //s.Attach(new ConcreteObserver(s, "Y"));
            //s.Attach(new ConcreteObserver(s, "Z"));

            //// Change subject and notify observers

            //s.SubjectState = "ABC";
            //s.Notify();


            //var ss = OptimalChange(6);
            //if (ss != null)
            //{
            //    Console.WriteLine(ss.bill10);
            //    Console.WriteLine(ss.bill5);
            //    Console.WriteLine(ss.coin2);
            //}
            //else
            //    Console.WriteLine("null");

            //int s = Position(3);
            //Console.WriteLine(s);

            //IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            //var newList = strList.Take(2);//prends 2 premiers elements

            ;

            //string str = "A Thousand Splendid Suns";
            //Console.WriteLine("Matching words that start with 'S': ");
            //showMatch(str, @"\bS\S*"); //Splendid  Suns



            //Func<Student, bool> isTeenAger1 = s => s.Age > 12 && s.Age < 20;

            //Expression<Func<Student, bool>> isTeenAgerExpr = s => s.Age > 12 && s.Age < 20;
            ////compile Expression using Compile method to invoke it as Delegate
            //Func<Student, bool> isTeenAger = isTeenAgerExpr.Compile();
            ////Invoke
            //bool result = isTeenAger(new Student() { StudentID = 1, StudentName = "Steve", Age = 20 });


            //ParameterExpression pe = Expression.Parameter(typeof(Student), "s");
            //MemberExpression me = Expression.Property(pe, "Age");
            //ConstantExpression constant = Expression.Constant(18, typeof(int));
            //BinaryExpression body = Expression.GreaterThanOrEqual(me, constant);
            //var ExpressionTree = Expression.Lambda<Func<Student, bool>>(body, new[] { pe });
            //Console.WriteLine("Expression Tree: {0}", ExpressionTree);
            //Console.WriteLine("Expression Tree Body: {0}", ExpressionTree.Body);
            //Console.WriteLine("Number of Parameters in Expression Tree: {0}",
            //                   ExpressionTree.Parameters.Count);
            //Console.WriteLine("Parameters in Expression Tree: {0}", ExpressionTree.Parameters[0]);



            //var list = new List<int>(2);
            //list.Add(1);
            //list.Add(1);
            //list.Add(1);
            //Console.WriteLine(list.Count());//3

            ;



            //The SequenceEqual method checks whether the number of elements, value of each element and order of elements
            //in two collections are equal or not.
            //IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };
            //IList<string> strList2 = new List<string>() { "One", "Two", "Three", "Four", "Three" };
            //bool isEqual = strList1.SequenceEqual(strList2); // returns true
            //Console.WriteLine(isEqual);

            //strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };
            //strList2 = new List<string>() { "Two", "One", "Three", "Four", "Three" };
            //isEqual = strList1.SequenceEqual(strList2); // returns false
            //Console.WriteLine(isEqual);

            //IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            //var newList = strList.Skip(2);//  "Three", "Four", "Five"

            //IList<string> strList = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            //var newList = strList.Take(2);//"One", "Two"  


            //IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
            //IList<string> strList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };
            //var result = strList1.Except(strList2);//One Two Three


            //IList<int> collection1 = new List<int>() { 1, 2, 3 };
            //IList<int> collection2 = new List<int>() { 4, 5, 6 };
            //var collection3 = collection1.Concat(collection2);
            //var intCollection = Enumerable.Range(2, 10);//2,3,4......11
            //intCollection = Enumerable.Repeat<int>(10, 10);//10,10,.....10


            //IList<Student> studentList = new List<Student>() {
            //        new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
            //        new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
            //        new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
            //        new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
            //        new Student() { StudentID = 5, StudentName = "Ron"  }
            //    };

            //IList<Standard> standardList = new List<Standard>() {
            //        new Standard(){ StandardID = 1, StandardName="Standard 1"},
            //        new Standard(){ StandardID = 2, StandardName="Standard 2"},
            //        new Standard(){ StandardID = 3, StandardName="Standard 3"}
            //    };

            //var teenAgerStudents = from s in studentList
            //                       where s.Age > 12 && s.Age < 20
            //                       select s 
            //                       into teenStudents
            //                       where teenStudents.StudentName.StartsWith("B")
            //                       select teenStudents;


            //var studentsGroupByStandard = from s in studentList
            //                              group s by s.StandardID into sg
            //                              orderby sg.Key
            //                              select new { sg.Key, sg };


            //foreach (var group in studentsGroupByStandard)
            //{
            //    Console.WriteLine("StandardID {0}:", group.Key);

            //    group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            //}



            //var innerJoin = studentList.Join(// outer sequence 
            //          standardList,  // inner sequence 
            //          student => student.StandardID,    // outerKeySelector
            //          standard => standard.StandardID,  // innerKeySelector
            //          (student, standard) => new  // result selector
            //          {
            //              StudentName = student.StudentName,
            //              StandardName = standard.StandardName
            //          });

            //var innerJoin1 = from s in studentList // outer sequence
            //                 join st in standardList //inner sequence 
            //                 on s.StandardID equals st.StandardID // key selector 
            //                 select new
            //                 { // result selector 
            //                     StudentName = s.StudentName,
            //                     StandardName = st.StandardName
            //                 };





            //var elements = BuildList();
            //var subset = from theElement in elements
            //             let specificElement = theElement.Name.ToLower()
            //             where specificElement.Contains("ca")
            //             orderby theElement.Name
            //             select theElement;


            //  var ss = String.IsInterned(null);

            //string input = "1";
            //if (int.TryParse(input, out var answer))
            //    Console.WriteLine(answer);
            //else
            //    Console.WriteLine("Could not parse input");

            //var i =  Power(2, 3).ToList();


            //List<Action> actions = new List<Action>();
            //for (int counter = 0; counter < 4; counter++)
            //{
            //    actions.Add(() => Console.Write("{0} ", counter));
            //}

            //foreach (Action action in actions)
            //{
            //    action();
            //}
            //;


            // Test t1 = new Test();

            //TestMethode();

            //string[] colors = { "blue", "brown", "green", "red" };
            //var list = new List<string>(colors);
            //var query = list.Where(e => e.Length >= 3);
            //if (query.FirstOrDefault() != null)
            //{
            //    //var t = query.FirstOrDefault();
            //    var s =  query.ToList();
            //}


            //MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            //var target = Expression.Parameter(typeof(string), "x");
            //var methodArg = Expression.Parameter(typeof(string), "y");

            //Expression[] methodArgs = new[] { methodArg };
            //Expression call = Expression.Call(target, method, methodArg);
            //var lambdaParameters = new[] { target, methodArg };
            //var lambda = Expression.Lambda<Func<string, string, bool>>(call, lambdaParameters);
            //var compiled = lambda.Compile();

            //Console.WriteLine(compiled("First", "Second"));//False
            //Console.WriteLine(compiled("First", "Fir"));//True
            //Console.WriteLine(compiled("First", "HFir"));//False

            //var elements = new List<string>() { "water air earth fire", "grass sky thunder air" };
            //var query1 = elements.SelectMany(f => f.Split(' ')).OrderBy(x => x).ToList();
            //var query = elements.SelectMany(f => f.Split(' ')).OrderBy(x => x).GroupBy(x => x).Select((x, i)
            //=> new { Element = x, Count = x.Count() });
            //var first = query.First();
            //Console.WriteLine(first.Count);//2







            //List<Banana> bananas = new List<Banana> { };
            //IEnumerable<Fruit> fruits = bananas;
            //var fruits = bananas;


            // X<X<int>>.PrintType();


            //foreach (int i in Integers())
            //{
            //    Console.WriteLine(i.ToString());
            //}




            //var a = GetFunc()(6);// 9

            //Action<Base> b = (target) => { Console.WriteLine(target.GetType().Name); };
            //Action<Derived> d = b;
            //d(new Derived());

            //Expression firstarg = Expression.Constant(2);
            //Expression secondarg = Expression.Constant(3);
            //Expression add = Expression.Add(firstarg, secondarg);
            //Func<int> getResult = Expression.Lambda<Func<int>>(add).Compile();
            //Console.WriteLine(getResult());//affiche 5



            //DerivedSimple s = new DerivedSimple();
            //s.fun();

            //object o1 = 1;
            //object o2 = 1;
            //Console.WriteLine(o1==o2);//false
            //Console.WriteLine(o1.Equals(o2));//true

            //string[] colors = {"blue", "brown", "green","red" };
            //var list = new List<string>(colors);
            //var query = list.Where(e => e.Length == 3);
            //list.Remove("red");
            //Console.WriteLine(query.Count());//0


            //string[] colors = { "blue", "brown", "green", "red" };
            //var list = new List<string>(colors);
            //var query = list.Where(e => e.Length >= 3)
            //    .Select(x => x.Length);


            //var list = new List<string> { "item1", "item2" };
            //foreach(var it in list)
            //{
            //    list.Add("item3");
            //}
            ////ce code leve une exception la collection a été modifié




            //if (string.IsNullOrEmpty(FirstName))
            //    throw new ArgumentException(message: "Cannot be blank", paramName: nameof(FirstName)); //affiche l exception {"Cannot be blank\r\nNom du paramètre : FirstName"}

            //FirstName = "abc";
            //LastName = "def";
            //FormattableString str = $"Average grade is {FullName}";
            //var gradeStr = str.ToString(new System.Globalization.CultureInfo("de-DE"));
            //Console.WriteLine(gradeStr);


            //Console.WriteLine(("?" ?? "???") == "?" ? "??" : ":::");// affiche ??

            //string s1 = "string";
            //string s2 = "string";
            //char[] cs = { 's','t','r','i','n','g'};
            //string s3 = new String(cs);
            //string s4 = new String(cs);

            //Console.WriteLine("s1==s2> {0}; s3==s4>{1}; s3.Equals(s4) {2}; s1==s4>{3}", s1==s2, s3==s4, s3.Equals(s4), s1==s4);
            ////s1==s2> True; s3==s4>True; s3.Equals(s4) True; s1==s4>True




            //int value = 2;
            //object o = value;
            //o = 3;
            //Console.WriteLine(o);// affiche 3
            //Console.WriteLine(value);// affiche 2


            //Test t = new Test();
            //Console.WriteLine($"ExtraPrice: {t.ExtraPrice}");//ExtraPrice:0.25

            //int? x= null;
            //int? y=null;
            //int? z= 4;
            //var res = x??y??z;
            //Console.WriteLine(res);// affiche 4

            //FirstName = "abc";
            //LastName = "def";
            //Console.WriteLine(FullName);// affiche: abc def


            //


            //var result = 7 / 2;
            //Console.WriteLine(result);//resulta int  =  3




            //Order order = new Order { Custom = new Custom { Name = "jamal" }, Price = 10 };
            //var ret  = QualifiesForDiscount(order);
            //Console.WriteLine(ret);

            //formattablestring https://stackoverflow.com/questions/35425899/difference-between-string-formattablestring-iformattable


            // Console.WriteLine($"{abc} aaaaa");// ne compile pas car abc n est pas declare

            //Client dilan = new Client { Name = "Dilan" };
            //Nullable<Decimal> dilanBalance = dilan?.Account?.Balance;
            //Console.WriteLine($"New client created:{dilan?.Name} with balance {dilanBalance}");
            //////New client created:Dilan with balance

            //int a = Add(5);
            //int b = Multiply(5);
            //Console.WriteLine($" value of a:{a} , value of b: {b}"); // a = 15 , b = 75

            //NumberChanger ncAgreggation;
            //NumberChanger ncAdd = new NumberChanger(Add);
            //NumberChanger ncMult = new NumberChanger(Multiply);
            //ncAgreggation = ncAdd;
            //ncAgreggation += ncMult;
            //Console.WriteLine($" value of num: {ncAgreggation(5)}");
            //value of num: 75


            //Stack<int> stack = new Stack<int>();
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(StackLine);
            //Console.WriteLine($"1 :{stack.Pop()} 2 :{stack.Peek()} 3:{stack.Pop()}"); // 1:4 2:3 3:3
            //;

            //Generic<Person> instance = new Generic<Person>();// pesron must with parameterless constructor

            //Animation bishop = new Animation();
            //bishop.Move(5, 6);
            //Console.WriteLine($"Bishop X={bishop.X} /Bishop Y={bishop.Y}  ");//affiche
            //X ={ x}/ Y ={ y}
            //Bishop X = 5 / Bishop Y = 6


            //string[] colors = { "green", "brown", "blue", "red" };
            ////var item = colors.OrderBy(c => c.Length).Single();// genere une exception car single doit retourner 1 seul elment , et dans ce cas la list color contient plusieurs elements
            //string s = "e";
            //var query = colors.Where(c => c.Contains(s));
            //s = "n";
            //query = query.Where(c => c.Contains(s));
            //Console.WriteLine(query.Count());

            //var a = Power(2, 3);   // enumerable de [2 ,4 ,8]


            //int[] values = { 1, 2, 3, 4 };
            //int counter = 0;
            //var rest = values.Where(x =>
            //{
            //    counter++;
            //    return x > 1;
            //}
            //          )
            //    .OrderBy(x =>
            //    {
            //        counter++;
            //        return -x;

            //    })
            //    .Select(x => x).Count(x =>
            //    {
            //        counter++;
            //        return x > 2;

            //    })
            //    ;
            //Console.WriteLine(counter);//10

            //int[] values = { 1, 2, 3, 4 };
            //var expr = values.AsParallel(); //	 Active la parallélisation d'une requête.
            //var result = expr.OrderByDescending(x => x).Where(x =>
            //{
            //    Console.Write(x);
            //    return x % 2 == 0;
            //}
            //).Count();
            //Console.WriteLine(result);

            //IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            //var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);
            //Console.WriteLine(commaSeperatedString);//affiche  One, Two, Three, Four, Five


            IList<Student> studentList = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
                    new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
                    new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
                    new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
                    new Student() { StudentID = 5, StudentName = "Ron"  }
                };
            //var avg = studentList.Average(x=>x.StudentID);

            //string commaSeparatedStudentNames = studentList.Aggregate<Student, string>(
            //                            "Student Names: ",  // seed value
            //                            (str, a) => str += a.StudentName + ",");
            //Console.WriteLine(commaSeparatedStudentNames);
            //Student Names: John, Moin, Bill, Ram, Ron,

            Console.ReadLine();

            //process("",false, 1);


        }
        //public static void process(string data, bool ignore = false, int moreData)
        //{

        //}



        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;
            // Console.WriteLine("tttgtgt");
            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }


        /// <returns>an enumeration of the names of "super"‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌‌ customers</returns>
        public static IEnumerable<string> GetSuperCustomers(List<Order> orders)
        {

            var q = from o in orders
                    group o by o.Customer into grp
                    where grp.Sum(x => x.Price) > 100

                    select grp.Key;

            return q;

        }



        public static int ClosestToZero(int[] ints)
        {

            if ((ints == null) || (ints != null && ints.Length == 0))
                return 0;
            else
            {
                var q = from o in ints
                        group o by Math.Abs(o) into grp
                        where grp.Count() > 1
                        select grp.Key;


                if (q.Count() > 1)
                    return q.FirstOrDefault();

                else
                    return 0;
            }
        }

        //static int GetStep(int n)
        //{
        //    int returnValue = 0;
        //    if (n == 0)
        //        returnValue = 0;
        //    else if (n == 1)
        //        returnValue = 1;
        //    else if (n == 2)
        //        returnValue = -2;
        //    else
        //    {
        //        returnValue =  GetStep(n - 1) - GetStep(n - 2);

        //    }
        //    return returnValue;

        //}

        //public static int GetPositionAt(int n)
        //{
        //    /*


        //public static int Position(int n)
        //{
        //    if (n == 0) return 0;
        //    if (n == 1) return 1;
        //    if (n == 2) return -1;
        //    else
        //    {
        //        return Position(n - 1) + Step(n);
        //    }

        //}
        //     */
        //    int returnValue = 0;
        //    if (n == 0)
        //        returnValue = 0;
        //    else if (n == 1)
        //        returnValue = 1;
        //    else if (n == 2)
        //        returnValue = -1;
        //    else
        //    {
        //        returnValue = GetPositionAt(n - 1) + GetStep(n );

        //    }

        //    return returnValue;
        //}

        public static bool Check(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;


            Stack<char> brackets = new Stack<char>();

            foreach (char c in str)
            {
                if (c == '[' || c == '{' || c == '(')
                {
                    brackets.Push(c);
                }
                else
                {

                    if (brackets.Count == 0) return false;

                    if (c == ')')
                    {
                        if (brackets.Peek() == '(')
                            brackets.Pop();
                        else return false;
                    }

                    if (c == '}')
                    {
                        if (brackets.Peek() == '{')
                            brackets.Pop();
                        else return false;
                    }

                    if (c == ']')
                    {
                        if (brackets.Peek() == '[') brackets.Pop();
                        else return false;
                    }
                }
            }

            if (brackets.Count == 0) return true;

            return false;

        }




    }

    class Base
    {
        public virtual void Foo() { }
    }
    class Bar : Base
    {
        public sealed override void Foo()
        {

        }
    }



    /// <summary>

    /// The 'Subsystem ClassA' class

    /// </summary>

    class SubSystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine(" SubSystemOne Method");
        }
    }

    /// <summary>

    /// The 'Subsystem ClassB' class

    /// </summary>

    class SubSystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine(" SubSystemTwo Method");
        }
    }

    /// <summary>

    /// The 'Subsystem ClassC' class

    /// </summary>

    class SubSystemThree
    {
        public void MethodThree()
        {
            Console.WriteLine(" SubSystemThree Method");
        }
    }

    /// <summary>

    /// The 'Subsystem ClassD' class

    /// </summary>

    class SubSystemFour
    {
        public void MethodFour()
        {
            Console.WriteLine(" SubSystemFour Method");
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class Facade
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public Facade()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            _one.MethodOne();
            _two.MethodTwo();
            _four.MethodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            _two.MethodTwo();
            _three.MethodThree();
        }
    }

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    abstract class Subject
    {
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in _observers)
            {
                o.Update();
            }
        }
    }

    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    class ConcreteSubject : Subject
    {
        private string _subjectState;

        // Gets or sets subject state

        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }
    }

    /// <summary>
    /// The 'Observer' abstract class
    /// </summary>
    abstract class Observer
    {
        public abstract void Update();
    }

    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        // Constructor

        public ConcreteObserver(
          ConcreteSubject subject, string name)
        {
            this._subject = subject;
            this._name = name;
        }

        public override void Update()
        {
            _observerState = _subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}",
              _name, _observerState);
        }

        // Gets or sets subject

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
    }


    /// <summary>
    /// 2
    /// </summary>
    public class MyClass
    {
        public delegate void EventHandler(string msg);
        public event EventHandler myEvent;
        protected void OnMyEvent(string msg)
        {
            myEvent(msg);
        }
    }

    class Person
    {
        public Person(string name)
        {
            Console.WriteLine(name);
        }
    }
    class Generic<T> where T : new()
    {
        public T Request()
        {
            return new T();
        }
    }

    interface Movable
    {
        Point Move(int xOffset, int yOffset);

    }
    struct Point : Movable
    {
        int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Print()
        {
            Console.WriteLine("x={0}, y={1}", x, y);
        }
        public Point Move(int xOffset, int yOffset)
        {
            return new Point(x + xOffset, y + yOffset);
        }

    }

    //class MyClass1<T> where T : Point  // ne compile pas car point est une constarinte non valide
    //{
    //    //public void  Print(T p) { p.Print(); }
    //}

    interface IPromotion
    {

        void promote();

    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }
        public int Age { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }

    struct Struct
    {
        public int foo;
    }
    struct Employee : IPromotion
    {

        public string Name;

        public int JobGrade;

        public void promote()
        {

            JobGrade++;

        }

        public Employee(string name, int jobGrade)
        {

            this.Name = name;

            this.JobGrade = jobGrade;

        }

        public override string ToString()
        {

            return string.Format("{0} ({1})", Name, JobGrade);

        }

    }



}
