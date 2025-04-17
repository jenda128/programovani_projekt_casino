namespace Shop
{


    class ShopClass
    {
        /*generovane chatgpt:
private double balance;
private Dictionary<string, (int cena, bool vlastni)> ShopItems;

public Shop(double initialBalance)
{
    balance = initialBalance;

    // Seznam věcí, které lze koupit (název → cena, zda je hráč vlastní)
    ShopItems = new Dictionary<string, (int, bool)>
    {
        { "Baccarat", (1000, false) },
        { "Ruleta", (1200, false) },
        { "Poker", (1500, false) } // Můžeš jednoduše přidávat další věci
    };*/
        //tbh s timhle kodem mi pomohl chat gpt protoze jsem si uz vubec nepamatoval jak se pracuje se slovnikem
        //dictionary jsem delal s chatgpt
        public static Dictionary<string, (int cena, bool vlastni)> ShopItems { get; private set; } = new Dictionary<string, (int, bool)>
        {
            { "Baccarat", (1000, false) },
            { "Ruleta", (1200, false) },//tady pridejte svoje polozky ve stejnym formatu jako bacarat a ruleta
            { "Power-Up - OkoBere", (500, false) },
            { "Power-Up - Baccarat", (700, false) }


        };

        public double ViewShop(double balance)
        {
            Console.WriteLine("Vítejte v shopu");
            while (true)
            {
                /*taky chatgpt:foreach (var item in ShopItems)
                {
                    string stav = item.Value.vlastni ? "(Vlastní)" : $"- {item.Value.cena} chechtáků";
                    Console.WriteLine($"{item.Key}: {stav}");
                }*/
                foreach (var item in ShopItems)
                {
                    Console.WriteLine(item.Key + " Vlastníte: " + item.Value.vlastni + " Cena: " + item.Value.cena);
                }
                Console.WriteLine("Napište název hry nebo power-upu, který chcete koupit, nebo 'exit' pro odchod.");
                //ShopItems.ContainsKey(input)
                string input = Console.ReadLine();
                if (ShopItems.ContainsKey(input))
                {
                    var (cena, vlastni) = ShopItems[input];
                    if (vlastni == true)
                    {
                        Console.WriteLine("Tuto hru nebo power-up už vlastníte");
                    }
                    else if (balance < cena)
                    {
                        Console.WriteLine("Nemáte dostatek chechtáků");
                    }
                    else
                    {
                        balance -= cena;
                        ShopItems[input] = (cena, true);
                        Console.WriteLine("koupili jste: " + input + " zbívá vám: " + balance + " chechtáků");
                    }
                }
                else if (input == "exit")
                {
                    return balance;
                }
                else
                {
                    Console.WriteLine("Neplatný vstup zkuste znovu");
                }
            }
        }
    }
}
