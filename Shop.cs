namespace Shop
{
    

class Shop {
            /*generovane chatgpt:
    private double balance;
    private Dictionary<string, (int cena, bool vlastni)> items;

    public Shop(double initialBalance)
    {
        balance = initialBalance;

        // Seznam věcí, které lze koupit (název → cena, zda je hráč vlastní)
        items = new Dictionary<string, (int, bool)>
        {
            { "Baccarat", (1000, false) },
            { "Ruleta", (1200, false) },
            { "Poker", (1500, false) } // Můžeš jednoduše přidávat další věci
        };*/
        //tbh s timhle kodem mi pomohl chat gpt protoze jsem si uz vubec nepamatoval jak se pracuje se slovnikem
        public double balance;
        //dictionary jsem delal s chatgpt
        public static Dictionary<string, (int cena, bool vlastni)> items { get; public set; } = new Dictionary<string, (int, bool)>
        {
            { "Baccarat", (1000, false) },
            { "Ruleta", (1200, false) },//tady pridejte svoje polozky ve stejnym formatu jako bacarat a ruleta



        };

    public double Shop (double inputBalance){
        Console.WriteLine("Vítejte v shopu");
        balance = inputBalance;
        while (true)
        {            
            /*taky chatgpt:foreach (var item in items)
            {
                string stav = item.Value.vlastni ? "(Vlastní)" : $"- {item.Value.cena} chechtáků";
                Console.WriteLine($"{item.Key}: {stav}");
            }*/
            foreach (var item in items)
            {
                Console.WriteLine(item.Key + "Vlastníte: " + item.Value.vlastni + " Cena: " + item.Value.cena); 
            }
            Console.WriteLine("Napište název hry, kterou chcete koupit, nebo 'exit' pro odchod.");
            //items.ContainsKey(input)
            string input = Console.ReadLine();
            if(items.ContainsKey(input)) 
            {
                var (cena, vlastni) = items[input];
                if (vlastni == true) 
                {
                    Console.WriteLine("Tuto hru už vlastníte");
                }
                else if (balance < cena)
                {
                    Console.WriteLine("Nemáte dostatek chechtáků");
                }
                else 
                {
                    balance -= cena;
                    items[input] = (cena, true);
                    Console.WriteLine("koupili jste: " + input + "zbívá vám: " + balance + " chechtáků");
                }
            }
            else if (input == "exit")
            {
                return(balance);
            }
            else
            {
                Console.WriteLine("Neplatný vstup zkuste znovu");
            }
        }

    }





}
}