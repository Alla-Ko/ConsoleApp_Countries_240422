using System.Data.Linq;


namespace ConsoleApp_Countries
{
    internal class Program

    {


        static string connectionString = @"Data Source=ALLA_KOKHANIUK;Initial Catalog=countriesdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var db = new DataContext(connectionString);
            Table<Country> countries = db.GetTable<Country>();
            //Завдання 2
            Console.WriteLine("\x1b[43m\x1b[30mВідобразити всю інформацію про країни\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            countries.ToList().ForEach(country => Console.WriteLine(country.ToString()));
            //foreach (var country in countries)
            //{
            //    Console.WriteLine($"{country.ToString()}");
            //}

            Console.WriteLine("\x1b[43m\x1b[30mВідобразити назви країн\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            countries.ToList().ForEach(country => Console.WriteLine(country.Name));
            //foreach (var country in countries)
            //{
            //    Console.WriteLine($"{country.Name}");
            //}


            Console.WriteLine("\x1b[43m\x1b[30mВідобразити назви столиць\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            countries.ToList().ForEach(country => Console.WriteLine(country.Capital));
            //foreach (var country in countries)
            //{
            //    Console.WriteLine($"{country.Capital}");
            //}

            Console.WriteLine("\x1b[43m\x1b[30mВідобразити назву усіх європейських країн\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            var europeanCountries = countries.Where(c => c.Continent.Contains("Європа")).Select(c => c.Name);
            europeanCountries.ToList().ForEach(country => Console.WriteLine(country));




            //foreach (var country in europeanCountries)
            //{
            //    Console.WriteLine(country);
            //}



            //foreach (var country in countries)
            //{
            //    if (country.Continent.Contains("Європа"))

            //        Console.WriteLine($"{country.Name}");
            //}

            Console.WriteLine("\x1b[43m\x1b[30mВідобразити назви країн з площею, більшою від певного числа\x1b[37m\x1b[40m");
            Console.WriteLine("Введіть мінімальну площу країни");
            int area = -1;
            while (area <= 0)
            {
                int.TryParse(Console.ReadLine(), out area);
                if (area > 0) break;
                Console.WriteLine("Площа повинна бути >0");
            }
            Console.WriteLine($"\u001b[43m\u001b[30mОсь країни з площею, більшою за {area}:\u001b[37m\u001b[40m");



            countries.Where(c => c.Area > area)
                     .Select(c => $"{c.Name} - {c.Area}")
                     .ToList()
                     .ForEach(Console.WriteLine);
            //foreach (var country in countries)
            //{
            //    if (country.Area > area)

            //        Console.WriteLine($"{country.Name} - {country.Area}");
            //}

            //Завдання 3
            Console.WriteLine("\x1b[43m\x1b[30mВідобразити усі країни, в назвах яких є літери ‘а’ та ‘у’\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            var countriesWithAU = countries.Where(country => country.Name.Contains("а") && country.Name.Contains("у"));
            countriesWithAU.ToList().ForEach(country => Console.WriteLine(country.Name));
            //foreach (var country in countries)
            //{
            //    if (country.Name.ToLower().Contains("а") && country.Name.ToLower().Contains("у"))
            //    {
            //        Console.WriteLine($"{country.Name}");
            //    }

            //}
            Console.WriteLine("\x1b[43m\x1b[30mВідобразити усі країни, в назвах яких є літери ‘а’\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            var countriesWithA = countries.Where(country => country.Name.Contains("а"));
            countriesWithA.ToList().ForEach(country => Console.WriteLine(country.Name));
            //foreach (var country in countries)
            //{
            //    if (country.Name.ToLower().Contains("а"))
            //    {
            //        Console.WriteLine($"{country.Name}");
            //    }

            //}
            Console.WriteLine("\x1b[43m\x1b[30mВідобразити назву країн, площа яких зазначена у вказаному діапазоні\x1b[37m\x1b[40m");
            Console.WriteLine("Введіть мінімальну площу країни");
            int minArea = -1;
            while (minArea <= 0)
            {
                int.TryParse(Console.ReadLine(), out minArea);
                if (minArea > 0) break;
                Console.WriteLine("Площа повинна бути >0");
            }
            Console.WriteLine("Введіть максимальну площу країни");
            int maxArea = -1;
            while (maxArea < minArea)
            {
                int.TryParse(Console.ReadLine(), out maxArea);
                if (maxArea >= minArea) break;
                Console.WriteLine("Площа повинна бути >0 і не менше за мінімальну площу");
            }
            var countriesInAreaRange = countries
                .Where(country => country.Area > minArea && country.Area < maxArea)
                .Select(country => $"{country.Name} - {country.Area}");
            countriesInAreaRange.ToList().ForEach(Console.WriteLine);
            //foreach (var country in countries)
            //{
            //    if (country.Area > minArea && country.Area < maxArea)

            //        Console.WriteLine($"{country.Name} - {country.Area}");
            //}

            Console.WriteLine("\x1b[43m\x1b[30mВідобразити назву країн, в яких кількість жителів більша за вказану кількість\x1b[37m\x1b[40m");
            Console.WriteLine("Введіть кількість жителів");
            int inhabitants = -1;
            while (inhabitants <= 0)
            {
                int.TryParse(Console.ReadLine(), out inhabitants);
                if (inhabitants > 0) break;
                Console.WriteLine("Введіть число >0");
            }
            var countriesWithMoreInhabitants = countries.Where(country => country.Inhabitants > inhabitants)
                .Select(country => $"{country.Name} - {country.Inhabitants}");
            countriesWithMoreInhabitants.ToList().ForEach(Console.WriteLine);
            //foreach (var country in countries)
            //{
            //    if (country.Inhabitants > inhabitants)

            //        Console.WriteLine($"{country.Name} - {country.Inhabitants}");
            //}

            //Завдання 4
            Console.WriteLine("\x1b[43m\x1b[30mПоказати Топ-5 країни за площею\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();

            var top5CountriesByArea = countries.OrderByDescending(country => country.Area)
            .Select(country => $"{country.Name} - {country.Area}")
            .Take(5);
            top5CountriesByArea.ToList().ForEach(Console.WriteLine);
            //foreach (var country in top5CountriesByArea)
            //{
            //    Console.WriteLine($"{country.Name} - {country.Area}");

            //}


            Console.WriteLine("\x1b[43m\x1b[30mПоказати Топ-5 країни за кількістю жителів\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            var top5CountriesByInhabitans = countries.OrderByDescending(country => country.Inhabitants)
                .Select(country => $"{country.Name} - {country.Inhabitants}")
                .Take(5);
            top5CountriesByInhabitans.ToList().ForEach(Console.WriteLine);
            //foreach (var country in top5CountriesByInhabitans)
            //{
            //    Console.WriteLine($"{country.Name} - {country.Inhabitants}");

            //}

            Console.WriteLine("\x1b[43m\x1b[30mПоказати країну з найбільшою площею\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();

            var rasha = top5CountriesByArea.FirstOrDefault();
            Console.WriteLine(rasha);


            Console.WriteLine("\x1b[43m\x1b[30mПоказати країну з найбільшою кількістю жителів\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            var rasha1 = top5CountriesByInhabitans.FirstOrDefault();
            Console.WriteLine(rasha1);

            Console.WriteLine("\x1b[43m\x1b[30mПоказати країну з найменшою площею в Африці\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            var smallestAreaCountryInAfrica = countries.Where(c => c.Continent == "Африка").OrderBy(c => c.Area).FirstOrDefault();
            Console.WriteLine($"Країна з найменшою площею в Африці {smallestAreaCountryInAfrica.Name} - {smallestAreaCountryInAfrica.Area}");


            Console.WriteLine("\x1b[43m\x1b[30mПоказати середню площу країн в Азії\x1b[37m\x1b[40m");
            Console.ReadKey();
            Console.WriteLine();
            var averageAreaInAsia = countries.Where(c => c.Continent == "Азія").Average(c => c.Area);

            Console.WriteLine($"Середня площа країн Азії: {averageAreaInAsia}");


            Console.ReadKey();
        }
    }
}
