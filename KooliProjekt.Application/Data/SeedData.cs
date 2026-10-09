using System;
using System.Collections.Generic;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }
            var employees = new List<Employee>
            {
                new Employee { Name = "Jaan Tamm", Username = "jtamm", Password = "hashed_password_1" },
                new Employee { Name = "Kertu Saar", Username = "ksaar", Password = "hashed_password_2" },
                new Employee { Name = "Markus Kask", Username = "mkask", Password = "hashed_password_3" },
                new Employee { Name = "Mari Maasik", Username = "mmaasik", Password = "hashed_password_4" },
                new Employee { Name = "Sander Pärn", Username = "sparn", Password = "hashed_password_5" },
                new Employee { Name = "Laura Oja", Username = "loja", Password = "hashed_password_6" },
                new Employee { Name = "Rasmus Sepp", Username = "rsepp", Password = "hashed_password_7" },
                new Employee { Name = "Liisi Rebane", Username = "lrebane", Password = "hashed_password_8" },
                new Employee { Name = "Marten Ilves", Username = "milves", Password = "hashed_password_9" },
                new Employee { Name = "Anna Kaasik", Username = "akaasik", Password = "hashed_password_10" },
                new Employee { Name = "Kristjan Lepik", Username = "klepik", Password = "hashed_password_11" },
                new Employee { Name = "Kadi Luik", Username = "kluik", Password = "hashed_password_12" },
                new Employee { Name = "Martin Kuusk", Username = "mkuusk", Password = "hashed_password_13" },
                new Employee { Name = "Eveli Koppel", Username = "ekoppel", Password = "hashed_password_14" },
                new Employee { Name = "Karl Vaher", Username = "kvaher", Password = "hashed_password_15" },
                new Employee { Name = "Triin Nõmm", Username = "tnomm", Password = "hashed_password_16" },
                new Employee { Name = "Oskar Kallas", Username = "okallas", Password = "hashed_password_17" },
                new Employee { Name = "Kadri Mets", Username = "kmets", Password = "hashed_password_18" },
                new Employee { Name = "Andres Lees", Username = "alees", Password = "hashed_password_19" },
                new Employee { Name = "Sirli Pajula", Username = "spajula", Password = "hashed_password_20" },
                new Employee { Name = "Taavi Kukk", Username = "tkukk", Password = "hashed_password_21" },
                new Employee { Name = "Pille Laur", Username = "plaur", Password = "hashed_password_22" },
                new Employee { Name = "Mihkel Kangur", Username = "mkangur", Password = "hashed_password_23" },
                new Employee { Name = "Anni Raadik", Username = "araadik", Password = "hashed_password_24" },
                new Employee { Name = "Priit Kivi", Username = "pkivi", Password = "hashed_password_25" },
                new Employee { Name = "Helen Põld", Username = "hpold", Password = "hashed_password_26" },
                new Employee { Name = "Rait Rand", Username = "rrand", Password = "hashed_password_27" },
                new Employee { Name = "Katrin Roos", Username = "kroos", Password = "hashed_password_28" },
                new Employee { Name = "Robert Lepp", Username = "rlepp", Password = "hashed_password_29" },
                new Employee { Name = "Ines Hein", Username = "ihein", Password = "hashed_password_30" },
                new Employee { Name = "Reno Müür", Username = "rmuur", Password = "hashed_password_31" },
                new Employee { Name = "Berit Kross", Username = "bkross", Password = "hashed_password_32" },
                new Employee { Name = "Toomas Orav", Username = "torav", Password = "hashed_password_33" },
                new Employee { Name = "Eeva Soosaar", Username = "esoosaar", Password = "hashed_password_34" },
                new Employee { Name = "Artur Vinkel", Username = "avinkel", Password = "hashed_password_35" }
            };

            context.Employees.AddRange(employees);

            var operationTypes = new List<OperationType>
            {
                new OperationType { Name = "Mootoriõli vahetus", Description = "Mootoriõli ja õlifiltri vahetamine uue vastu." },
                new OperationType { Name = "Piduriklotside vahetus", Description = "Esimeste ja tagumiste piduriklotside kontroll ja vahetus." },
                new OperationType { Name = "Rehvide vahetus ja tasakaalustus", Description = "Hooajaline rehvivahetus koos velgede tasakaalustamisega." },
                new OperationType { Name = "Kliimaseadme täitmine", Description = "Kliimasüsteemi hermeetilisuse kontroll ja külmutusaine lisamine." },
                new OperationType { Name = "Sillastend", Description = "Esi- ja tagasilla reguleerimine arvutistendi abil." },
                new OperationType { Name = "Aku vahetus", Description = "Vana aku eemaldamine ja uue käivitusaku paigaldus." },
                new OperationType { Name = "Süüteküünalde vahetus", Description = "Süüteküünalde kontroll ja uute paigaldus." },
                new OperationType { Name = "Pidurivedeliku vahetus", Description = "Pidurivedeliku vahetus ja süsteemi õhutamine." },
                new OperationType { Name = "Amortisaatorite vahetus", Description = "Kulunud või lekkivate amortisaatorite vahetus." },
                new OperationType { Name = "Rooliotsa vahetus", Description = "Roolilati ja rooliotsa liigendite vahetus." },
                new OperationType { Name = "Generatori rihma vahetus", Description = "Lamerihma ja pinguti vahetus." },
                new OperationType { Name = "Mootori diagnostika", Description = "Veakoodide lugemine ja diagnostika testeriga." },
                new OperationType { Name = "Hammasrihma komplekti vahetus", Description = "Hammasrihma, rullikute ja veepumba vahetus." },
                new OperationType { Name = "Jahutusvedeliku vahetus", Description = "Jahutussüsteemi läbipesu ja uue antifriisi lisamine." },
                new OperationType { Name = "Tulede reguleerimine", Description = "Esi- ja udutulede viimine normidele vastavaks." },
                new OperationType { Name = "Salongifiltri vahetus", Description = "Mikrofiltri vahetus parema õhukvaliteedi tagamiseks." },
                new OperationType { Name = "Piduriketaste vahetus", Description = "Esi- või tagapiduriketaste vahetus koos puhastusega." },
                new OperationType { Name = "Summuti remont", Description = "Keevitustööd või summuti osade vahetus." },
                new OperationType { Name = "Sidurikomplekti vahetus", Description = "Siduriketta, korvi ja survelaagri vahetus." },
                new OperationType { Name = "Veelaiendi vahetus", Description = "Veelaiendi ehk pooltelje otsa või kummikatte vahetus." },
                new OperationType { Name = "Starteri remont", Description = "Käiviti vahetus või harjade/relee rekonstrueerimine." },
                new OperationType { Name = "Kütusefiltri vahetus", Description = "Bensiini- või diislikütusefiltri vahetamine." },
                new OperationType { Name = "Tehnoülevaatuse eelne kontroll", Description = "Sõiduki täielik tehniline kontroll enne riiklikku ülevaatust." },
                new OperationType { Name = "Automaatkäigukasti õlivahetus", Description = "Käigukasti õli dynamiitne või tavaline vahetus." },
                new OperationType { Name = "DPF filtri puhastus", Description = "Tahmafiltri sundregeneratsioon või pesu." },
                new OperationType { Name = "Pihustite kontroll ja vahetus", Description = "Kütusepihustite testimine ja stendimissüsteem." },
                new OperationType { Name = "Turbo vahetus", Description = "Turbokompressori vahetus ja tihendikomplekt." },
                new OperationType { Name = "Esisilla puksikomplekti vahetus", Description = "Õõtshoova pukside pressimine ja vahetus." },
                new OperationType { Name = "Rattalaagri vahetus", Description = "Kulunud või müratseva rattalaagri vahetus." },
                new OperationType { Name = "Klaasipuhastajate vahetus", Description = "Klaasipuhasti harjade vahetamine uute vastu." },
                new OperationType { Name = "Põhjakaitse paigaldus", Description = "Mootori põhjakaitse vahetus või paigaldamine." },
                new OperationType { Name = "Pidurivoolikute vahetus", Description = "Murenenud pidurivoolikute vahetamine uute vastu." },
                new OperationType { Name = "Autoelektriku tööd", Description = "Juhtmestiku ja elektriliste lisaseadmete veamääratlus." },
                new OperationType { Name = "Esiklaasi vahetus", Description = "Mõranenud või purunenud tuuleklaasi vahetamine." },
                new OperationType { Name = "Klassikaline keemiline puhastus", Description = "Auto salongi põhjalik pesu ja märgpuhastus." }
            };
            context.OperationTypes.AddRange(operationTypes);

            var cars = new List<Car>
            {
                new Car { Manufacturer = "Volkswagen", Model = "Passat", LicensePlate = "123 ABC" },
                new Car { Manufacturer = "Audi", Model = "A6", LicensePlate = "456 DEF" },
                new Car { Manufacturer = "BMW", Model = "530d", LicensePlate = "789 GHI" },
                new Car { Manufacturer = "Toyota", Model = "Avensis", LicensePlate = "101 JKL" },
                new Car { Manufacturer = "Skoda", Model = "Octavia", LicensePlate = "202 MNO" },
                new Car { Manufacturer = "Ford", Model = "Focus", LicensePlate = "303 PQR" },
                new Car { Manufacturer = "Volvo", Model = "XC90", LicensePlate = "404 STU" },
                new Car { Manufacturer = "Mercedes-Benz", Model = "E220", LicensePlate = "505 VWX" },
                new Car { Manufacturer = "Honda", Model = "Civic", LicensePlate = "606 YZA" },
                new Car { Manufacturer = "Kia", Model = "Ceed", LicensePlate = "707 BCD" },
                new Car { Manufacturer = "Hyundai", Model = "i30", LicensePlate = "808 EFG" },
                new Car { Manufacturer = "Nissan", Model = "Qashqai", LicensePlate = "909 HIJ" },
                new Car { Manufacturer = "Peugeot", Model = "508", LicensePlate = "111 KLM" },
                new Car { Manufacturer = "Renault", Model = "Megane", LicensePlate = "222 NOP" },
                new Car { Manufacturer = "Subaru", Model = "Outback", LicensePlate = "333 QRS" },
                new Car { Manufacturer = "Mazda", Model = "6", LicensePlate = "444 TUV" },
                new Car { Manufacturer = "Seat", Model = "Leon", LicensePlate = "555 WXY" },
                new Car { Manufacturer = "Opel", Model = "Insignia", LicensePlate = "666 ZAB" },
                new Car { Manufacturer = "Toyota", Model = "RAV4", LicensePlate = "777 CDE" },
                new Car { Manufacturer = "BMW", Model = "320i", LicensePlate = "888 FGH" },
                new Car { Manufacturer = "Audi", Model = "Q5", LicensePlate = "999 IJK" },
                new Car { Manufacturer = "Volkswagen", Model = "Golf", LicensePlate = "124 LMN" },
                new Car { Manufacturer = "Skoda", Model = "Superb", LicensePlate = "235 OPQ" },
                new Car { Manufacturer = "Volvo", Model = "V60", LicensePlate = "346 RST" },
                new Car { Manufacturer = "Ford", Model = "Mondeo", LicensePlate = "457 UVW" },
                new Car { Manufacturer = "Lexus", Model = "RX450h", LicensePlate = "568 XYZ" },
                new Car { Manufacturer = "Porsche", Model = "Cayenne", LicensePlate = "679 ABC" },
                new Car { Manufacturer = "Land Rover", Model = "Discovery", LicensePlate = "780 DEF" },
                new Car { Manufacturer = "Jeep", Model = "Grand Cherokee", LicensePlate = "891 GHI" },
                new Car { Manufacturer = "Alfa Romeo", Model = "Giulia", LicensePlate = "902 JKL" },
                new Car { Manufacturer = "Jaguar", Model = "XF", LicensePlate = "135 MNO" },
                new Car { Manufacturer = "Citroen", Model = "C4", LicensePlate = "246 PQR" },
                new Car { Manufacturer = "Mitsubishi", Model = "Outlander", LicensePlate = "357 STU" },
                new Car { Manufacturer = "Suzuki", Model = "Vitara", LicensePlate = "468 VWX" },
                new Car { Manufacturer = "Tesla", Model = "Model 3", LicensePlate = "579 YZA" }
            };
            context.Cars.AddRange(cars);

            context.SaveChanges();

            var operations = new List<Operation>
            {
                new Operation { Date = DateTime.Now.AddDays(-30), Status = Status.COMPLETED, Cost = 65.00m, CarId = cars[0].Id, OperationTypeId = operationTypes[0].Id, EmployeeId = employees[0].Id },
                new Operation { Date = DateTime.Now.AddDays(-29), Status = Status.COMPLETED, Cost = 120.50m, CarId = cars[1].Id, OperationTypeId = operationTypes[1].Id, EmployeeId = employees[1].Id },
                new Operation { Date = DateTime.Now.AddDays(-28), Status = Status.COMPLETED, Cost = 40.00m, CarId = cars[2].Id, OperationTypeId = operationTypes[2].Id, EmployeeId = employees[2].Id },
                new Operation { Date = DateTime.Now.AddDays(-27), Status = Status.COMPLETED, Cost = 85.00m, CarId = cars[3].Id, OperationTypeId = operationTypes[3].Id, EmployeeId = employees[3].Id },
                new Operation { Date = DateTime.Now.AddDays(-26), Status = Status.COMPLETED, Cost = 50.00m, CarId = cars[4].Id, OperationTypeId = operationTypes[4].Id, EmployeeId = employees[4].Id },
                new Operation { Date = DateTime.Now.AddDays(-25), Status = Status.COMPLETED, Cost = 110.00m, CarId = cars[5].Id, OperationTypeId = operationTypes[5].Id, EmployeeId = employees[5].Id },
                new Operation { Date = DateTime.Now.AddDays(-24), Status = Status.COMPLETED, Cost = 45.00m, CarId = cars[6].Id, OperationTypeId = operationTypes[6].Id, EmployeeId = employees[6].Id },
                new Operation { Date = DateTime.Now.AddDays(-23), Status = Status.COMPLETED, Cost = 35.00m, CarId = cars[7].Id, OperationTypeId = operationTypes[7].Id, EmployeeId = employees[7].Id },
                new Operation { Date = DateTime.Now.AddDays(-22), Status = Status.COMPLETED, Cost = 220.00m, CarId = cars[8].Id, OperationTypeId = operationTypes[8].Id, EmployeeId = employees[8].Id },
                new Operation { Date = DateTime.Now.AddDays(-21), Status = Status.COMPLETED, Cost = 75.00m, CarId = cars[9].Id, OperationTypeId = operationTypes[9].Id, EmployeeId = employees[9].Id },
                new Operation { Date = DateTime.Now.AddDays(-20), Status = Status.COMPLETED, Cost = 60.00m, CarId = cars[10].Id, OperationTypeId = operationTypes[10].Id, EmployeeId = employees[10].Id },
                new Operation { Date = DateTime.Now.AddDays(-19), Status = Status.COMPLETED, Cost = 30.00m, CarId = cars[11].Id, OperationTypeId = operationTypes[11].Id, EmployeeId = employees[11].Id },
                new Operation { Date = DateTime.Now.AddDays(-18), Status = Status.COMPLETED, Cost = 380.00m, CarId = cars[12].Id, OperationTypeId = operationTypes[12].Id, EmployeeId = employees[12].Id },
                new Operation { Date = DateTime.Now.AddDays(-17), Status = Status.COMPLETED, Cost = 45.00m, CarId = cars[13].Id, OperationTypeId = operationTypes[13].Id, EmployeeId = employees[13].Id },
                new Operation { Date = DateTime.Now.AddDays(-16), Status = Status.COMPLETED, Cost = 25.00m, CarId = cars[14].Id, OperationTypeId = operationTypes[14].Id, EmployeeId = employees[14].Id },
                new Operation { Date = DateTime.Now.AddDays(-15), Status = Status.COMPLETED, Cost = 30.00m, CarId = cars[15].Id, OperationTypeId = operationTypes[15].Id, EmployeeId = employees[15].Id },
                new Operation { Date = DateTime.Now.AddDays(-14), Status = Status.COMPLETED, Cost = 160.00m, CarId = cars[16].Id, OperationTypeId = operationTypes[16].Id, EmployeeId = employees[16].Id },
                new Operation { Date = DateTime.Now.AddDays(-13), Status = Status.COMPLETED, Cost = 90.00m, CarId = cars[17].Id, OperationTypeId = operationTypes[17].Id, EmployeeId = employees[17].Id },
                new Operation { Date = DateTime.Now.AddDays(-12), Status = Status.COMPLETED, Cost = 450.00m, CarId = cars[18].Id, OperationTypeId = operationTypes[18].Id, EmployeeId = employees[18].Id },
                new Operation { Date = DateTime.Now.AddDays(-11), Status = Status.COMPLETED, Cost = 80.00m, CarId = cars[19].Id, OperationTypeId = operationTypes[19].Id, EmployeeId = employees[19].Id },
                new Operation { Date = DateTime.Now.AddDays(-10), Status = Status.IN_PROGRESS, Cost = 130.00m, CarId = cars[20].Id, OperationTypeId = operationTypes[20].Id, EmployeeId = employees[20].Id },
                new Operation { Date = DateTime.Now.AddDays(-9), Status = Status.IN_PROGRESS, Cost = 55.00m, CarId = cars[21].Id, OperationTypeId = operationTypes[21].Id, EmployeeId = employees[21].Id },
                new Operation { Date = DateTime.Now.AddDays(-8), Status = Status.IN_PROGRESS, Cost = 40.00m, CarId = cars[22].Id, OperationTypeId = operationTypes[22].Id, EmployeeId = employees[22].Id },
                new Operation { Date = DateTime.Now.AddDays(-7), Status = Status.IN_PROGRESS, Cost = 250.00m, CarId = cars[23].Id, OperationTypeId = operationTypes[23].Id, EmployeeId = employees[23].Id },
                new Operation { Date = DateTime.Now.AddDays(-6), Status = Status.IN_PROGRESS, Cost = 120.00m, CarId = cars[24].Id, OperationTypeId = operationTypes[24].Id, EmployeeId = employees[24].Id },
                new Operation { Date = DateTime.Now.AddDays(-5), Status = Status.PENDING, Cost = 280.00m, CarId = cars[25].Id, OperationTypeId = operationTypes[25].Id, EmployeeId = employees[25].Id },
                new Operation { Date = DateTime.Now.AddDays(-4), Status = Status.PENDING, Cost = 650.00m, CarId = cars[26].Id, OperationTypeId = operationTypes[26].Id, EmployeeId = employees[26].Id },
                new Operation { Date = DateTime.Now.AddDays(-3), Status = Status.PENDING, Cost = 140.00m, CarId = cars[27].Id, OperationTypeId = operationTypes[27].Id, EmployeeId = employees[27].Id },
                new Operation { Date = DateTime.Now.AddDays(-2), Status = Status.PENDING, Cost = 115.00m, CarId = cars[28].Id, OperationTypeId = operationTypes[28].Id, EmployeeId = employees[28].Id },
                new Operation { Date = DateTime.Now.AddDays(-1), Status = Status.PENDING, Cost = 20.00m, CarId = cars[29].Id, OperationTypeId = operationTypes[29].Id, EmployeeId = employees[29].Id },
                new Operation { Date = DateTime.Now, Status = Status.PENDING, Cost = 35.00m, CarId = cars[30].Id, OperationTypeId = operationTypes[30].Id, EmployeeId = employees[30].Id },
                new Operation { Date = DateTime.Now, Status = Status.PENDING, Cost = 65.00m, CarId = cars[31].Id, OperationTypeId = operationTypes[31].Id, EmployeeId = employees[31].Id },
                new Operation { Date = DateTime.Now, Status = Status.PENDING, Cost = 95.00m, CarId = cars[32].Id, OperationTypeId = operationTypes[32].Id, EmployeeId = employees[32].Id },
                new Operation { Date = DateTime.Now, Status = Status.PENDING, Cost = 210.00m, CarId = cars[33].Id, OperationTypeId = operationTypes[33].Id, EmployeeId = employees[33].Id },
                new Operation { Date = DateTime.Now, Status = Status.PENDING, Cost = 100.00m, CarId = cars[34].Id, OperationTypeId = operationTypes[34].Id, EmployeeId = employees[34].Id }
            };
            context.Operations.AddRange(operations);

            context.SaveChanges();
        }
    }
}