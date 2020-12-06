using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Fun
{
    //stores data
    public class Rate
    {
        //stores Currency code
        public string Currency { get; set; }
        //stores value in relation to Euro
        public float Value { get; set; }
        //parameterless constructor
        public Rate()
        {

        }
        //constructor to set name and value
        public Rate(string currency_name, float value_var)
        {
            Currency = currency_name;
            Value = value_var;
        }
    }

    public class Program
    {
        //serves as a serializible collection of Rate objects
        [XmlRoot("Rate_List")]
        public class RateList
        {
            //parameterless constructor
            public RateList()
            {
                Items = new List<Rate>();
            }
            [XmlElement("Rate")]
            //List to store objects
            public List<Rate> Items { get; set; }
        }

        //class to use api
        class CurrencyConverter
        {
            /// Gets all available currency tags
            public static string[] GetCurrencyTags()
            {

                // Hardcoded currency tags neccesairy to parse the ecb xml's
                return new string[] {"usd", "jpy", "bgn", "czk", "dkk", "gbp", "huf", "lvl"
            , "pln", "ron", "sek", "chf", "nok", "hrk", "rub", "try", "aud", "brl", "cad", "cny", "hkd", "idr", "ils"
            , "inr", "krw", "mxn", "myr", "nzd", "php", "sgd", "zar"};
            }

            /// Get currency exchange rate in euro's 
            public static float GetCurrencyRateInEuro(string currency)
            {
                if (currency.ToLower() == "")
                    throw new ArgumentException("Invalid Argument! currency parameter cannot be empty!");
                if (currency.ToLower() == "eur")
                    throw new ArgumentException("Invalid Argument! Cannot get exchange rate from EURO to EURO");

                try
                {
                    // Create with currency parameter, a valid RSS url to ECB euro exchange rate feed
                    string rssUrl = string.Concat("http://www.ecb.int/rss/fxref-", currency.ToLower() + ".html");

                    // Create & Load New Xml Document
                    XmlDocument doc = new XmlDocument();
                    doc.Load(rssUrl);

                    // Create XmlNamespaceManager for handling XML namespaces.
                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                    nsmgr.AddNamespace("rdf", "http://purl.org/rss/1.0/");
                    nsmgr.AddNamespace("cb", "http://www.cbwiki.net/wiki/index.php/Specification_1.1");

                    // Get list of daily currency exchange rate between selected "currency" and the EURO
                    XmlNodeList nodeList = doc.SelectNodes("//rdf:item", nsmgr);

                    // Loop Through all XMLNODES with daily exchange rates
                    foreach (XmlNode node in nodeList)
                    {
                        // Create a CultureInfo, this is because EU and USA use different sepperators in float (, or .)
                        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        ci.NumberFormat.CurrencyDecimalSeparator = ".";

                        try
                        {
                            // Get currency exchange rate with EURO from XMLNODE
                            float exchangeRate = float.Parse(
                                node.SelectSingleNode("//cb:statistics//cb:exchangeRate//cb:value", nsmgr).InnerText,
                                NumberStyles.Any,
                                ci);

                            return exchangeRate;
                        }
                        catch { }
                    }

                    // currency not parsed!! 
                    // return default value
                    return 0;
                }
                catch
                {
                    // currency not parsed!! 
                    // return default value
                    return 0;
                }
            }
        }

        //prints user menu
        void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Input commands in English");
            Console.WriteLine("Commands: ");
            Console.WriteLine("'e' - exit                            'a' - add record");
            Console.WriteLine("'d' - delete record                   'p' - print all records");
            Console.WriteLine("'c' - change record                   'f' - find record");
            Console.WriteLine("'s' - save record as a text file");
            Console.WriteLine("Input command: ");
        }

        //handles input
        int HandleInput(string input,RateList list,XmlSerializer serializer)
        {
            int exit = 0;
            //saves the file and exits the app 
            if(input == "e")
            {
                Stream fs = new FileStream("save.xml", FileMode.Create);
                serializer.Serialize(fs, list);
                Console.WriteLine("File saved");
                exit = 1;
            }
            //adds Rate object to the collection
            if (input == "a")
            {
                string name = "";
                float value;
                for (; ; )
                {
                    Console.WriteLine("Input currency code (3 symbols):");
                    name = Console.ReadLine();
                    if (name.Length == 3)
                        break;
                }
                for (; ; )
                {
                    Console.WriteLine("Input value in relation to 1 EUR: ");
                    if(float.TryParse(Console.ReadLine(), out value))
                        break;
                }
                list.Items.Add(new Rate(name, value));
            }

            //removes Rate object from the collection
            if (input == "d")
            {
                int index;
                for (; ; )
                {
                    Console.WriteLine("Input currency index:");
                    if(int.TryParse(Console.ReadLine(), out index)&&index<=list.Items.Count)
                        break;
                }
                list.Items.RemoveAt(index);
            }
            //prints all Rate objects
            if (input == "p")
            {
                foreach (Rate elem in list.Items)
                {
                    Console.WriteLine($"{elem.Currency} : {elem.Value}");
                }
                Console.WriteLine();
            }
            //Changes Rate object at the specified index
            if (input == "c")
            {
                int index;
                string name = "";
                float value;
                for (; ; )
                {
                    Console.WriteLine("Input currency index:");
                    if (int.TryParse(Console.ReadLine(), out index)&&index<=list.Items.Count)
                        break;
                }
                for (; ; )
                {
                    Console.WriteLine("Input currency code (3 symbols):");
                    name = Console.ReadLine();
                    if (name.Length == 3)
                        break;
                }
                for (; ; )
                {
                    Console.WriteLine("Input value in relation to 1 EUR: ");
                    if (float.TryParse(Console.ReadLine(), out value))
                        break;
                }
                list.Items[index].Currency = name;
                list.Items[index].Value = value;
            }
            //searches the collection by specified field
            if (input == "f")
            {
                int searchtype;
                for (; ; )
                {
                    Console.WriteLine("Input '1' to seatch by currency code or '2' to search by it's value:");
                    if (int.TryParse(Console.ReadLine(), out searchtype) && (searchtype == 1)||(searchtype==2))
                        break;
                }
                //search by code
                if (searchtype == 1)
                {
                    string name;
                    for (; ; )
                    {
                        Console.WriteLine("Input currency code (3 symbols):");
                        name = Console.ReadLine();
                        if (name.Length == 3)
                            break;
                    }
                    int index = 0;
                    foreach (Rate elem in list.Items)
                    {
                        if(elem.Currency == name)
                        {
                            Console.WriteLine($"Item found at index {index}");
                            break;
                        }
                        index++;
                    }
                    if (index == list.Items.Count && list.Items[index - 1].Currency != name)
                        Console.WriteLine("There is no such element in collection");
                }
                //seatch by value
                if (searchtype == 2)
                {
                    float value;
                    for (; ; )
                    {
                        Console.WriteLine("Input value in relation to 1 EUR: ");
                        if (float.TryParse(Console.ReadLine(), out value))
                            break;
                    }
                    int index = 0;
                    foreach (Rate elem in list.Items)
                    {
                        if (elem.Value == value)
                        {
                            Console.WriteLine($"Item found at index {index}");
                            break;
                        }
                        index++;
                    }
                    if (index == list.Items.Count && list.Items[index - 1].Value != value)
                        Console.WriteLine("There is no such element in collection");
                }

            }
            //saves a txt file with cillection info
            if (input == "s")
            {
                string res = "";
                Console.WriteLine("Input save path or onput 'i' to save in default folder:");
                string path = Console.ReadLine();
                if (path == "i")
                {
                    foreach (Rate elem in list.Items)
                    {
                        res += $"{elem.Currency} : {elem.Value}";
                        res += "\n";
                    }
                    res = res.Trim();
                    File.WriteAllText("text.txt", res);
                    Console.WriteLine("File saved");
                }
                else {
                    try
                    {
                        FileInfo test = new FileInfo(path);
                        foreach (Rate elem in list.Items)
                        {
                            res += $"{elem.Currency} : {elem.Value}";
                            res += "\n";
                        }
                        res = res.Trim();
                        if (!path.Contains(".txt"))
                            path += "/text.txt";
                        File.WriteAllText(path, res);
                        Console.WriteLine("File saved");
                    }
                    catch
                    {
                        Console.WriteLine("Unable to access folder");
                    }
                }
            }
            return exit;
        }

        //creates save.xml file to store serialized data
        void CreateFile(XmlSerializer ser, RateList rates)
        {
                Stream fs = new FileStream("save.xml", FileMode.Create);
                // Get all available currency tags
                string[] availableCurrency = CurrencyConverter.GetCurrencyTags();

                rates.Items.Add(new Rate("EUR", 1));
                Console.WriteLine("Loading...");
                foreach (string currency in availableCurrency)
                {
                    Rate tmp = new Rate(currency.ToUpper(), CurrencyConverter.GetCurrencyRateInEuro(currency));
                    rates.Items.Add(tmp);
                }

                foreach (Rate elem in rates.Items)
                {
                    Console.WriteLine($"{elem.Currency} : {elem.Value}");
                }
                ser.Serialize(fs, rates);
                Console.WriteLine("\nFile 'save.xml' created");
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            XmlSerializer ser = new XmlSerializer(typeof(RateList));
            RateList rates = new RateList();
            //creates file if it doesnt exist
            if (!File.Exists("save.xml"))
                p.CreateFile(ser, rates);
            else
            {
                //overwrites file if it is empty
                if (new FileInfo("save.xml").Length == 0)
                {
                    Console.WriteLine("File is empty");
                    Console.WriteLine("Overwriting the file...");
                    p.CreateFile(ser, rates);
                }
                else
                {
                    Console.WriteLine("File exists");
                    using (var reader = new StreamReader("save.xml"))
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(List<Rate>),
                            new XmlRootAttribute("Rate_List"));
                        try
                        {
                            rates.Items = (List<Rate>)deserializer.Deserialize(reader);
                        }
                        //overwrites the file if it is corrupted
                        catch
                        {
                            Console.WriteLine("Unable to read\nOverwriting the file...");
                            p.CreateFile(ser, rates);
                        }
                    }
                    Console.WriteLine("Reading...\n");
                    foreach (Rate elem in rates.Items)
                    {
                        Console.WriteLine($"{elem.Currency} : {elem.Value}");
                    }
                }
            }
            //main menu cycle
            for (; ; )
            {
                p.PrintMenu();
                string input = Console.ReadLine();
                int exit = p.HandleInput(input, rates, ser);
                if (exit == 1)
                    break;
            }
        }
    }
}
