using System;
using System.Collections.Generic;
using TollBoothManagementSystem.Core.Features.General.Model;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;

namespace TollBoothManagementSystem.Core.Persistence
{
    public class DatabaseContextSeed
    {
        public static void Seed(DatabaseContext context)
        {
            #region Users

            // Administrator
            var ad1 = new Administrator { FirstName = "Velibor", LastName = "Stojkovic", EmailAddress = "veliborstojkovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-40), Role = Role.Administrator };
            context.Users.Add(ad1);

            // Manager
            var mn1 = new Manager { FirstName = "Igor", LastName = "Mirkovic", EmailAddress = "igormirkovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-34), Role = Role.Manager };
            var mn2 = new Manager { FirstName = "Gordana", LastName = "Milicic", EmailAddress = "gordanamilicic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-34), Role = Role.Manager };
            var mn3 = new Manager { FirstName = "Veljko", LastName = "Veljkovic", EmailAddress = "veljkoveljkovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-34), Role = Role.Manager };
            context.Users.Add(mn1);
            
            // Referent
            var rf1 = new Referent { FirstName = "Nikola", LastName = "Petrovic", EmailAddress = "nikolapetrovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };
            var rf2 = new Referent { FirstName = "Marko", LastName = "Markovic", EmailAddress = "markomarkovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };
            var rf3 = new Referent { FirstName = "Petar", LastName = "Petrovic", EmailAddress = "petarpetrovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };

            var rf4 = new Referent { FirstName = "Zlatibor", LastName = "Jankovic", EmailAddress = "zlatiborjankovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };
            var rf5 = new Referent { FirstName = "Darko", LastName = "Djuricic", EmailAddress = "darkodjuricic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };
            var rf6 = new Referent { FirstName = "Nebojsa", LastName = "Stojanovic", EmailAddress = "nebojsastojanovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };

            var rf7 = new Referent { FirstName = "Zlatko", LastName = "Babic", EmailAddress = "zlatkobabic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };
            var rf8 = new Referent { FirstName = "Marko", LastName = "Lazic", EmailAddress = "markolazic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };
            var rf9 = new Referent { FirstName = "Rastko", LastName = "Glogovac", EmailAddress = "rastkoglogovac@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };

            context.Users.Add(rf1);
            context.Users.Add(rf2);
            context.Users.Add(rf3);
            context.Users.Add(rf4);
            context.Users.Add(rf5);
            context.Users.Add(rf6);
            context.Users.Add(rf7);
            context.Users.Add(rf8);
            context.Users.Add(rf9);

            context.SaveChanges();
            #endregion

            #region Locations

            var loc01 = new Location { PostalCode = 22310, Name = "Simanovci" };
            var loc02 = new Location { PostalCode = 22410, Name = "Pecinci" };
            var loc03 = new Location { PostalCode = 22400, Name = "Ruma" };
            var loc04 = new Location { PostalCode = 22000, Name = "Sremska Mitrovica" };
            var loc05 = new Location { PostalCode = 22223, Name = "Kuzmin" };
            var loc06 = new Location { PostalCode = 22244, Name = "Adasevci" };
            var loc07 = new Location { PostalCode = 22240, Name = "Sid" };

            var loc08 = new Location { PostalCode = 22300, Name = "Stara Pazova" };
            var loc09 = new Location { PostalCode = 22320, Name = "Indjija" };
            var loc10 = new Location { PostalCode = 22327, Name = "Maradik" };
            var loc11 = new Location { PostalCode = 22324, Name = "Beska" };
            var loc12 = new Location { PostalCode = 21243, Name = "Kovilj" };
            var loc13 = new Location { PostalCode = 21000, Name = "Novi Sad" };
            var loc14 = new Location { PostalCode = 21213, Name = "Zmajevo" };
            var loc15 = new Location { PostalCode = 21460, Name = "Vrbas" };
            var loc16 = new Location { PostalCode = 24323, Name = "Feketic" };
            var loc17 = new Location { PostalCode = 24300, Name = "Backa Topola" };
            var loc18 = new Location { PostalCode = 24224, Name = "Zednik" };
            var loc19 = new Location { PostalCode = 24000, Name = "Subotica" };

            var loc20 = new Location { PostalCode = 11500, Name = "Obrenovac" };
            var loc21 = new Location { PostalCode = 14210, Name = "Ub" };
            var loc22 = new Location { PostalCode = 14224, Name = "Lajkovac" };
            var loc23 = new Location { PostalCode = 14240, Name = "Ljig" };
            var loc24 = new Location { PostalCode = 32304, Name = "Takovo" };
            var loc25 = new Location { PostalCode = 32212, Name = "Preljina" };

            context.Locations.Add(loc01);
            context.Locations.Add(loc02);
            context.Locations.Add(loc03);
            context.Locations.Add(loc04);
            context.Locations.Add(loc05);
            context.Locations.Add(loc06);
            context.Locations.Add(loc07);
            context.Locations.Add(loc08);
            context.Locations.Add(loc09);
            context.Locations.Add(loc10);
            context.Locations.Add(loc11);
            context.Locations.Add(loc12);
            context.Locations.Add(loc13);
            context.Locations.Add(loc14);
            context.Locations.Add(loc15);
            context.Locations.Add(loc16);
            context.Locations.Add(loc17);
            context.Locations.Add(loc18);
            context.Locations.Add(loc19);
            context.Locations.Add(loc20);
            context.Locations.Add(loc21);
            context.Locations.Add(loc22);
            context.Locations.Add(loc23);
            context.Locations.Add(loc24);
            context.Locations.Add(loc25);

            context.SaveChanges();

            #endregion

            #region TollBooth

            var tb001 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb002 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb003 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb004 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb011 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb012 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb013 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb014 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb021 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb022 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb023 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb024 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb031 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb032 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb033 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb034 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb041 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb042 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb043 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb044 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb051 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb052 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb053 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb054 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb061 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb062 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb063 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb064 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb071 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb072 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb073 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb074 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb081 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb082 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb083 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb084 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb091 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb092 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb093 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb094 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb101 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb102 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb103 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb104 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb111 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb112 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb113 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb114 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb121 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb122 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb123 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb124 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb131 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb132 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb133 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb134 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb141 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb142 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb143 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb144 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb151 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb152 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb153 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb154 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb161 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb162 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb163 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb164 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb171 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb172 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb173 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb174 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb181 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb182 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb183 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb184 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb191 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb192 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb193 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb194 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb201 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb202 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb203 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb204 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb211 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb212 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb213 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb214 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb221 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb222 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb223 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb224 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb231 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb232 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb233 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb234 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            var tb241 = new TollBooth { Code = "a1", IsETC = true, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb242 = new TollBooth { Code = "b1", IsETC = true, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb243 = new TollBooth { Code = "c1", IsETC = false, IsOpen = true, IsTrafficLightFunctional = true, IsTollGateFunctional = true };
            var tb244 = new TollBooth { Code = "d1", IsETC = false, IsOpen = false, IsTrafficLightFunctional = true, IsTollGateFunctional = true };

            context.SaveChanges();

            #endregion

            #region TollStation

            var ts01 = new TollStation { OrderNumber = 1, Location = loc01, Name = loc01.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb001, tb002, tb003, tb004 }, Employees = new List<Employee> { rf1, rf2, rf3, mn1 } };
            tb001.TollStation = ts01;
            tb002.TollStation = ts01;
            tb003.TollStation = ts01;
            tb004.TollStation = ts01;

            var ts02 = new TollStation { OrderNumber = 2, Location = loc02, Name = loc02.Name, Boss = null, TollBooths = new List<TollBooth> { tb011, tb012, tb013, tb014 }};
            tb011.TollStation = ts02;
            tb012.TollStation = ts02;
            tb013.TollStation = ts02;
            tb014.TollStation = ts02;

            var ts03 = new TollStation { OrderNumber = 3, Location = loc03, Name = loc03.Name, Boss = null, TollBooths = new List<TollBooth> { tb021, tb022, tb023, tb024 }};
            tb021.TollStation = ts03;
            tb022.TollStation = ts03;
            tb023.TollStation = ts03;
            tb024.TollStation = ts03;

            var ts04 = new TollStation { OrderNumber = 4, Location = loc04, Name = loc04.Name, Boss = rf4, TollBooths = new List<TollBooth> { tb031, tb032, tb033, tb034 }, Employees = new List<Employee> { rf4, rf5, rf6, mn2 } };
            tb031.TollStation = ts04;
            tb032.TollStation = ts04;
            tb033.TollStation = ts04;
            tb034.TollStation = ts04;

            var ts05 = new TollStation { OrderNumber = 5, Location = loc05, Name = loc05.Name, Boss = null, TollBooths = new List<TollBooth> { tb041, tb042, tb043, tb044 } };
            tb041.TollStation = ts05;
            tb042.TollStation = ts05;
            tb043.TollStation = ts05;
            tb044.TollStation = ts05;

            var ts06 = new TollStation { OrderNumber = 6, Location = loc06, Name = loc06.Name, Boss = null, TollBooths = new List<TollBooth> { tb051, tb052, tb053, tb054 } };
            tb051.TollStation = ts06;
            tb052.TollStation = ts06;
            tb053.TollStation = ts06;
            tb054.TollStation = ts06;

            var ts07 = new TollStation { OrderNumber = 7, Location = loc07, Name = loc07.Name, Boss = rf7, TollBooths = new List<TollBooth> { tb061, tb062, tb063, tb064 }, Employees = new List<Employee> { rf7, rf8, rf9, mn3 }};
            tb061.TollStation = ts07;
            tb062.TollStation = ts07;
            tb063.TollStation = ts07;
            tb064.TollStation = ts07;

            var ts08 = new TollStation { OrderNumber = 1, Location = loc08, Name = loc08.Name, Boss = null, TollBooths = new List<TollBooth> { tb071, tb072, tb073, tb074 } };
            tb071.TollStation = ts08;
            tb072.TollStation = ts08;
            tb073.TollStation = ts08;
            tb074.TollStation = ts08;

            var ts09 = new TollStation { OrderNumber = 2, Location = loc09, Name = loc09.Name, Boss = null, TollBooths = new List<TollBooth> { tb081, tb082, tb083, tb084 } };
            tb081.TollStation = ts09;
            tb082.TollStation = ts09;
            tb083.TollStation = ts09;
            tb084.TollStation = ts09;

            var ts10 = new TollStation { OrderNumber = 3, Location = loc10, Name = loc10.Name, Boss = null, TollBooths = new List<TollBooth> { tb091, tb092, tb093, tb094 } };
            tb091.TollStation = ts10;
            tb092.TollStation = ts10;
            tb093.TollStation = ts10;
            tb094.TollStation = ts10;

            var ts11 = new TollStation { OrderNumber = 4, Location = loc11, Name = loc11.Name, Boss = null, TollBooths = new List<TollBooth> { tb101, tb102, tb103, tb104 } };
            tb101.TollStation = ts11;
            tb102.TollStation = ts11;
            tb103.TollStation = ts11;
            tb104.TollStation = ts11;

            var ts12 = new TollStation { OrderNumber = 5, Location = loc12, Name = loc12.Name, Boss = null, TollBooths = new List<TollBooth> { tb111, tb112, tb113, tb114 } };
            tb111.TollStation = ts12;
            tb112.TollStation = ts12;
            tb113.TollStation = ts12;
            tb114.TollStation = ts12;

            var ts13 = new TollStation { OrderNumber = 6, Location = loc13, Name = loc13.Name, Boss = null, TollBooths = new List<TollBooth> { tb121, tb122, tb123, tb124 } };
            tb121.TollStation = ts13;
            tb122.TollStation = ts13;
            tb123.TollStation = ts13;
            tb124.TollStation = ts13;

            var ts14 = new TollStation { OrderNumber = 7, Location = loc14, Name = loc14.Name, Boss = null, TollBooths = new List<TollBooth> { tb131, tb132, tb133, tb134 } };
            tb131.TollStation = ts14;
            tb132.TollStation = ts14;
            tb133.TollStation = ts14;
            tb134.TollStation = ts14;

            var ts15 = new TollStation { OrderNumber = 8, Location = loc15, Name = loc15.Name, Boss = null, TollBooths = new List<TollBooth> { tb141, tb142, tb143, tb144 } };
            tb141.TollStation = ts15;
            tb142.TollStation = ts15;
            tb143.TollStation = ts15;
            tb144.TollStation = ts15;

            var ts16 = new TollStation { OrderNumber = 9, Location = loc16, Name = loc16.Name, Boss = null, TollBooths = new List<TollBooth> { tb151, tb152, tb153, tb154 } };
            tb151.TollStation = ts16;
            tb152.TollStation = ts16;
            tb153.TollStation = ts16;
            tb154.TollStation = ts16;

            var ts17 = new TollStation { OrderNumber = 10, Location = loc17, Name = loc17.Name, Boss = null, TollBooths = new List<TollBooth> { tb161, tb162, tb163, tb164 } };
            tb161.TollStation = ts17;
            tb162.TollStation = ts17;
            tb163.TollStation = ts17;
            tb164.TollStation = ts17;

            var ts18 = new TollStation { OrderNumber = 11, Location = loc18, Name = loc18.Name, Boss = null, TollBooths = new List<TollBooth> { tb171, tb172, tb173, tb174 } };
            tb171.TollStation = ts18;
            tb172.TollStation = ts18;
            tb173.TollStation = ts18;
            tb174.TollStation = ts18;

            var ts19 = new TollStation { OrderNumber = 12, Location = loc19, Name = loc19.Name, Boss = null, TollBooths = new List<TollBooth> { tb181, tb182, tb183, tb184 } };
            tb181.TollStation = ts19;
            tb182.TollStation = ts19;
            tb183.TollStation = ts19;
            tb184.TollStation = ts19;

            var ts20 = new TollStation { OrderNumber = 1, Location = loc20, Name = loc20.Name, Boss = null, TollBooths = new List<TollBooth> { tb191, tb192, tb193, tb194 } };
            tb191.TollStation = ts20;
            tb192.TollStation = ts20;
            tb193.TollStation = ts20;
            tb194.TollStation = ts20;

            var ts21 = new TollStation { OrderNumber = 2, Location = loc21, Name = loc21.Name, Boss = null, TollBooths = new List<TollBooth> { tb201, tb202, tb203, tb204 } };
            tb201.TollStation = ts21;
            tb202.TollStation = ts21;
            tb203.TollStation = ts21;
            tb204.TollStation = ts21;

            var ts22 = new TollStation { OrderNumber = 3, Location = loc22, Name = loc22.Name, Boss = null, TollBooths = new List<TollBooth> { tb211, tb212, tb213, tb214 } };
            tb211.TollStation = ts22;
            tb212.TollStation = ts22;
            tb213.TollStation = ts22;
            tb214.TollStation = ts22;

            var ts23 = new TollStation { OrderNumber = 4, Location = loc23, Name = loc23.Name, Boss = null, TollBooths = new List<TollBooth> { tb221, tb222, tb223, tb224 } };
            tb221.TollStation = ts23;
            tb222.TollStation = ts23;
            tb223.TollStation = ts23;
            tb224.TollStation = ts23;

            var ts24 = new TollStation { OrderNumber = 5, Location = loc24, Name = loc24.Name, Boss = null, TollBooths = new List<TollBooth> { tb231, tb232, tb233, tb234 } };
            tb231.TollStation = ts24;
            tb232.TollStation = ts24;
            tb233.TollStation = ts24;
            tb234.TollStation = ts24;

            var ts25 = new TollStation { OrderNumber = 6, Location = loc25, Name = loc25.Name, Boss = null, TollBooths = new List<TollBooth> { tb241, tb242, tb243, tb244 } };
            tb241.TollStation = ts25;
            tb242.TollStation = ts25;
            tb243.TollStation = ts25;
            tb244.TollStation = ts25;

            context.TollBooths.Add(tb001);
            context.TollBooths.Add(tb002);
            context.TollBooths.Add(tb003);
            context.TollBooths.Add(tb004);

            context.TollBooths.Add(tb011);
            context.TollBooths.Add(tb012);
            context.TollBooths.Add(tb013);
            context.TollBooths.Add(tb014);

            context.TollBooths.Add(tb021);
            context.TollBooths.Add(tb022);
            context.TollBooths.Add(tb023);
            context.TollBooths.Add(tb024);

            context.TollBooths.Add(tb031);
            context.TollBooths.Add(tb032);
            context.TollBooths.Add(tb033);
            context.TollBooths.Add(tb034);

            context.TollBooths.Add(tb041);
            context.TollBooths.Add(tb042);
            context.TollBooths.Add(tb043);
            context.TollBooths.Add(tb044);

            context.TollBooths.Add(tb051);
            context.TollBooths.Add(tb052);
            context.TollBooths.Add(tb053);
            context.TollBooths.Add(tb054);

            context.TollBooths.Add(tb061);
            context.TollBooths.Add(tb062);
            context.TollBooths.Add(tb063);
            context.TollBooths.Add(tb064);

            context.TollBooths.Add(tb071);
            context.TollBooths.Add(tb072);
            context.TollBooths.Add(tb073);
            context.TollBooths.Add(tb074);

            context.TollBooths.Add(tb081);
            context.TollBooths.Add(tb082);
            context.TollBooths.Add(tb083);
            context.TollBooths.Add(tb084);

            context.TollBooths.Add(tb091);
            context.TollBooths.Add(tb092);
            context.TollBooths.Add(tb093);
            context.TollBooths.Add(tb094);

            context.TollBooths.Add(tb101);
            context.TollBooths.Add(tb102);
            context.TollBooths.Add(tb103);
            context.TollBooths.Add(tb104);

            context.TollBooths.Add(tb111);
            context.TollBooths.Add(tb112);
            context.TollBooths.Add(tb113);
            context.TollBooths.Add(tb114);

            context.TollBooths.Add(tb121);
            context.TollBooths.Add(tb122);
            context.TollBooths.Add(tb123);
            context.TollBooths.Add(tb124);

            context.TollBooths.Add(tb131);
            context.TollBooths.Add(tb132);
            context.TollBooths.Add(tb133);
            context.TollBooths.Add(tb134);

            context.TollBooths.Add(tb141);
            context.TollBooths.Add(tb142);
            context.TollBooths.Add(tb143);
            context.TollBooths.Add(tb144);

            context.TollBooths.Add(tb151);
            context.TollBooths.Add(tb152);
            context.TollBooths.Add(tb153);
            context.TollBooths.Add(tb154);

            context.TollBooths.Add(tb161);
            context.TollBooths.Add(tb162);
            context.TollBooths.Add(tb163);
            context.TollBooths.Add(tb164);

            context.TollBooths.Add(tb171);
            context.TollBooths.Add(tb172);
            context.TollBooths.Add(tb173);
            context.TollBooths.Add(tb174);

            context.TollBooths.Add(tb181);
            context.TollBooths.Add(tb182);
            context.TollBooths.Add(tb183);
            context.TollBooths.Add(tb184);

            context.TollBooths.Add(tb191);
            context.TollBooths.Add(tb192);
            context.TollBooths.Add(tb193);
            context.TollBooths.Add(tb194);

            context.TollBooths.Add(tb201);
            context.TollBooths.Add(tb202);
            context.TollBooths.Add(tb203);
            context.TollBooths.Add(tb204);

            context.TollBooths.Add(tb211);
            context.TollBooths.Add(tb212);
            context.TollBooths.Add(tb213);
            context.TollBooths.Add(tb214);

            context.TollBooths.Add(tb221);
            context.TollBooths.Add(tb222);
            context.TollBooths.Add(tb223);
            context.TollBooths.Add(tb224);

            context.TollBooths.Add(tb231);
            context.TollBooths.Add(tb232);
            context.TollBooths.Add(tb233);
            context.TollBooths.Add(tb234);

            context.TollBooths.Add(tb241);
            context.TollBooths.Add(tb242);
            context.TollBooths.Add(tb243);
            context.TollBooths.Add(tb244);


            context.TollStations.Add(ts01);
            context.TollStations.Add(ts02);
            context.TollStations.Add(ts03);
            context.TollStations.Add(ts04);
            context.TollStations.Add(ts05);
            context.TollStations.Add(ts06);
            context.TollStations.Add(ts07);
            context.TollStations.Add(ts08);
            context.TollStations.Add(ts09);
            context.TollStations.Add(ts10);
            context.TollStations.Add(ts11);
            context.TollStations.Add(ts12);
            context.TollStations.Add(ts13);
            context.TollStations.Add(ts14);
            context.TollStations.Add(ts15);
            context.TollStations.Add(ts16);
            context.TollStations.Add(ts17);
            context.TollStations.Add(ts18);
            context.TollStations.Add(ts19);
            context.TollStations.Add(ts20);
            context.TollStations.Add(ts21);
            context.TollStations.Add(ts22);
            context.TollStations.Add(ts23);
            context.TollStations.Add(ts24);
            context.TollStations.Add(ts25);

            mn1.TollStation = ts01;
            mn2.TollStation = ts04;
            mn3.TollStation = ts07;

            rf1.TollStation = ts01;
            rf2.TollStation = ts01;
            rf3.TollStation = ts01;
            rf4.TollStation = ts04;
            rf5.TollStation = ts04;
            rf6.TollStation = ts04;
            rf7.TollStation = ts07;
            rf8.TollStation = ts07;
            rf9.TollStation = ts07;

            context.Users.Update(mn1);
            context.Users.Update(rf1);
            context.Users.Update(rf2);
            context.Users.Update(rf3);
            context.Users.Update(rf4);

            context.SaveChanges();

            #endregion

            #region Section

            var sec1 = new Section { Origin = ts01, Destination = ts07, TollStations = new List<TollStation> { ts01, ts02, ts03, ts04, ts05, ts06, ts07 } };
            var sec2 = new Section { Origin = ts08, Destination = ts19, TollStations = new List<TollStation> { ts08, ts09, ts10, ts11, ts12, ts13, ts14, ts15, ts16, ts17, ts18, ts19} };
            var sec3 = new Section { Origin = ts20, Destination = ts25, TollStations = new List<TollStation> { ts20, ts21, ts22, ts23, ts24, ts25 } };

            context.Sections.Add(sec1);
            context.Sections.Add(sec2);
            context.Sections.Add(sec3);

            

            context.SaveChanges();


            #endregion

            #region SectionInfo

            var secInfo1X = new SectionInfo { Section = sec1, TollStation = ts01, Distance = 0 };
            var secInfo01 = new SectionInfo { Section = sec1, TollStation = ts02, Distance = 12.5 };
            var secInfo02 = new SectionInfo { Section = sec1, TollStation = ts03, Distance = 25.9 };
            var secInfo03 = new SectionInfo { Section = sec1, TollStation = ts04, Distance = 46.6 };
            var secInfo04 = new SectionInfo { Section = sec1, TollStation = ts05, Distance = 60.8 };
            var secInfo05 = new SectionInfo { Section = sec1, TollStation = ts06, Distance = 79.0 };
            var secInfo06 = new SectionInfo { Section = sec1, TollStation = ts07, Distance = 84.7 };

            var secInfo2X = new SectionInfo { Section = sec2, TollStation = ts08, Distance = 0 };
            var secInfo07 = new SectionInfo { Section = sec2, TollStation = ts09, Distance = 10.5 };
            var secInfo08 = new SectionInfo { Section = sec2, TollStation = ts10, Distance = 19.5 };
            var secInfo09 = new SectionInfo { Section = sec2, TollStation = ts11, Distance = 26.0 };
            var secInfo10 = new SectionInfo { Section = sec2, TollStation = ts12, Distance = 31.9 };
            var secInfo11 = new SectionInfo { Section = sec2, TollStation = ts13, Distance = 47.5 };
            var secInfo12 = new SectionInfo { Section = sec2, TollStation = ts14, Distance = 68.2 };
            var secInfo13 = new SectionInfo { Section = sec2, TollStation = ts15, Distance = 81.1 };
            var secInfo14 = new SectionInfo { Section = sec2, TollStation = ts16, Distance = 91.1 };
            var secInfo15 = new SectionInfo { Section = sec2, TollStation = ts17, Distance = 112.0 };
            var secInfo16 = new SectionInfo { Section = sec2, TollStation = ts18, Distance = 124.0 };
            var secInfo17 = new SectionInfo { Section = sec2, TollStation = ts19, Distance = 139.0 };

            var secInfo3X = new SectionInfo { Section = sec3, TollStation = ts20, Distance = 0 };
            var secInfo18 = new SectionInfo { Section = sec3, TollStation = ts21, Distance = 24.6 };
            var secInfo19 = new SectionInfo { Section = sec3, TollStation = ts22, Distance = 37.8 };
            var secInfo20 = new SectionInfo { Section = sec3, TollStation = ts23, Distance = 61.8 };
            var secInfo21 = new SectionInfo { Section = sec3, TollStation = ts24, Distance = 84.2 };
            var secInfo22 = new SectionInfo { Section = sec3, TollStation = ts25, Distance = 102.0 };

            context.SectionInfos.Add(secInfo01);
            context.SectionInfos.Add(secInfo02);
            context.SectionInfos.Add(secInfo03);
            context.SectionInfos.Add(secInfo04);
            context.SectionInfos.Add(secInfo05);
            context.SectionInfos.Add(secInfo06);
            context.SectionInfos.Add(secInfo07);
            context.SectionInfos.Add(secInfo08);
            context.SectionInfos.Add(secInfo09);
            context.SectionInfos.Add(secInfo10);
            context.SectionInfos.Add(secInfo11);
            context.SectionInfos.Add(secInfo12);
            context.SectionInfos.Add(secInfo13);
            context.SectionInfos.Add(secInfo14);
            context.SectionInfos.Add(secInfo15);
            context.SectionInfos.Add(secInfo16);
            context.SectionInfos.Add(secInfo17);
            context.SectionInfos.Add(secInfo18);
            context.SectionInfos.Add(secInfo19);
            context.SectionInfos.Add(secInfo20);
            context.SectionInfos.Add(secInfo21);
            context.SectionInfos.Add(secInfo22);

            context.SectionInfos.Add(secInfo1X);
            context.SectionInfos.Add(secInfo2X);
            context.SectionInfos.Add(secInfo3X);

            context.SaveChanges();

            #endregion

            #region PriceList

            DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime end = new DateTime(DateTime.Now.Year, 12, 31);

            var priceL1 = new PriceList { ActivationDate = start, ExpirationDate = end, Section = sec1 };
            var priceL2 = new PriceList { ActivationDate = start, ExpirationDate = end, Section = sec2 };
            var priceL3 = new PriceList { ActivationDate = start, ExpirationDate = end, Section = sec3 };

            context.PriceLists.Add(priceL1);
            context.PriceLists.Add(priceL2);
            context.PriceLists.Add(priceL3);

            context.SaveChanges();

            #endregion

            #region Currency

            var cur1 = new Currency { Code = "RSD", Name = "Serbian dinar" };
            var cur2 = new Currency { Code = "EUR", Name = "Euro" };

            context.Currencies.Add(cur1);
            context.Currencies.Add(cur2);

            context.SaveChanges();

            #endregion

            #region RoadToll

            var rt001 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt002 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt003 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt004 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt005 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt006 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt007 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt008 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt009 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt010 = new RoadToll { TollStation = ts01, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt011 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt012 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt013 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt014 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt015 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt016 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt017 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt018 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt019 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt020 = new RoadToll { TollStation = ts02, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt021 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt022 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt023 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt024 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt025 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt026 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt027 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt028 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt029 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt030 = new RoadToll { TollStation = ts03, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt031 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt032 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt033 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt034 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt035 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt036 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt037 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt038 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt039 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt040 = new RoadToll { TollStation = ts04, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt041 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt042 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt043 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt044 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt045 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt046 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt047 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt048 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt049 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt050 = new RoadToll { TollStation = ts05, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt051 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt052 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt053 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt054 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt055 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt056 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt057 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt058 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt059 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt060 = new RoadToll { TollStation = ts06, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt061 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt062 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt063 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt064 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt065 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt066 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt067 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt068 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt069 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt070 = new RoadToll { TollStation = ts07, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt071 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt072 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt073 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt074 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt075 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt076 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt077 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt078 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt079 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt080 = new RoadToll { TollStation = ts08, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt081 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt082 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt083 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt084 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt085 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt086 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt087 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt088 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt089 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt090 = new RoadToll { TollStation = ts09, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt091 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt092 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt093 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt094 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt095 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt096 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt097 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt098 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt099 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt100 = new RoadToll { TollStation = ts10, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt101 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt102 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt103 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt104 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt105 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt106 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt107 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt108 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt109 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt110 = new RoadToll { TollStation = ts11, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt111 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt112 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt113 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt114 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt115 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt116 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt117 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt118 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt119 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt120 = new RoadToll { TollStation = ts12, VehicleType = VehicleType.Category4, Currency = cur2 };
        
            var rt121 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt122 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt123 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt124 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt125 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt126 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt127 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt128 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt129 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt130 = new RoadToll { TollStation = ts13, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt131 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt132 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt133 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt134 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt135 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt136 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt137 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt138 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt139 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt140 = new RoadToll { TollStation = ts14, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt141 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt142 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt143 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt144 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt145 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt146 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt147 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt148 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt149 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt150 = new RoadToll { TollStation = ts15, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt151 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt152 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt153 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt154 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt155 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt156 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt157 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt158 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt159 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt160 = new RoadToll { TollStation = ts16, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt161 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt162 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt163 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt164 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt165 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt166 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt167 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt168 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt169 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt170 = new RoadToll { TollStation = ts17, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt171 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt172 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt173 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt174 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt175 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt176 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt177 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt178 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt179 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt180 = new RoadToll { TollStation = ts18, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt181 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt182 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt183 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt184 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt185 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt186 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt187 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt188 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt189 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt190 = new RoadToll { TollStation = ts19, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt191 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt192 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt193 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt194 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt195 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt196 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt197 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt198 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt199 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt200 = new RoadToll { TollStation = ts20, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt201 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt202 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt203 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt204 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt205 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt206 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt207 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt208 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt209 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt210 = new RoadToll { TollStation = ts21, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt211 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt212 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt213 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt214 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt215 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt216 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt217 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt218 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt219 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt220 = new RoadToll { TollStation = ts22, VehicleType = VehicleType.Category4, Currency = cur2 };
        
            var rt221 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt222 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt223 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt224 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt225 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt226 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt227 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt228 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt229 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt230 = new RoadToll { TollStation = ts23, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt231 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt232 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt233 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt234 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt235 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt236 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt237 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt238 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt239 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt240 = new RoadToll { TollStation = ts24, VehicleType = VehicleType.Category4, Currency = cur2 };

            var rt241 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category1A, Currency = cur1 };
            var rt242 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category1, Currency = cur1 };
            var rt243 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category2, Currency = cur1 };
            var rt244 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category3, Currency = cur1 };
            var rt245 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category4, Currency = cur1 };
            var rt246 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category1A, Currency = cur2 };
            var rt247 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category1, Currency = cur2 };
            var rt248 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category2, Currency = cur2 };
            var rt249 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category3, Currency = cur2 };
            var rt250 = new RoadToll { TollStation = ts25, VehicleType = VehicleType.Category4, Currency = cur2 };

            context.RoadTolls.Add(rt001);
            context.RoadTolls.Add(rt002);
            context.RoadTolls.Add(rt003);
            context.RoadTolls.Add(rt004);
            context.RoadTolls.Add(rt005);
            context.RoadTolls.Add(rt006);
            context.RoadTolls.Add(rt007);
            context.RoadTolls.Add(rt008);
            context.RoadTolls.Add(rt009);
            context.RoadTolls.Add(rt010);
            context.RoadTolls.Add(rt011);
            context.RoadTolls.Add(rt012);
            context.RoadTolls.Add(rt013);
            context.RoadTolls.Add(rt014);
            context.RoadTolls.Add(rt015);
            context.RoadTolls.Add(rt016);
            context.RoadTolls.Add(rt017);
            context.RoadTolls.Add(rt018);
            context.RoadTolls.Add(rt019);
            context.RoadTolls.Add(rt020);
            context.RoadTolls.Add(rt021);
            context.RoadTolls.Add(rt022);
            context.RoadTolls.Add(rt023);
            context.RoadTolls.Add(rt024);
            context.RoadTolls.Add(rt025);
            context.RoadTolls.Add(rt026);
            context.RoadTolls.Add(rt027);
            context.RoadTolls.Add(rt028);
            context.RoadTolls.Add(rt029);
            context.RoadTolls.Add(rt030);
            context.RoadTolls.Add(rt031);
            context.RoadTolls.Add(rt032);
            context.RoadTolls.Add(rt033);
            context.RoadTolls.Add(rt034);
            context.RoadTolls.Add(rt035);
            context.RoadTolls.Add(rt036);
            context.RoadTolls.Add(rt037);
            context.RoadTolls.Add(rt038);
            context.RoadTolls.Add(rt039);
            context.RoadTolls.Add(rt040);
            context.RoadTolls.Add(rt041);
            context.RoadTolls.Add(rt042);
            context.RoadTolls.Add(rt043);
            context.RoadTolls.Add(rt044);
            context.RoadTolls.Add(rt045);
            context.RoadTolls.Add(rt046);
            context.RoadTolls.Add(rt047);
            context.RoadTolls.Add(rt048);
            context.RoadTolls.Add(rt049);
            context.RoadTolls.Add(rt050);
            context.RoadTolls.Add(rt051);
            context.RoadTolls.Add(rt052);
            context.RoadTolls.Add(rt053);
            context.RoadTolls.Add(rt054);
            context.RoadTolls.Add(rt055);
            context.RoadTolls.Add(rt056);
            context.RoadTolls.Add(rt057);
            context.RoadTolls.Add(rt058);
            context.RoadTolls.Add(rt059);
            context.RoadTolls.Add(rt060);
            context.RoadTolls.Add(rt061);
            context.RoadTolls.Add(rt062);
            context.RoadTolls.Add(rt063);
            context.RoadTolls.Add(rt064);
            context.RoadTolls.Add(rt065);
            context.RoadTolls.Add(rt066);
            context.RoadTolls.Add(rt067);
            context.RoadTolls.Add(rt068);
            context.RoadTolls.Add(rt069);
            context.RoadTolls.Add(rt070);
            context.RoadTolls.Add(rt071);
            context.RoadTolls.Add(rt072);
            context.RoadTolls.Add(rt073);
            context.RoadTolls.Add(rt074);
            context.RoadTolls.Add(rt075);
            context.RoadTolls.Add(rt076);
            context.RoadTolls.Add(rt077);
            context.RoadTolls.Add(rt078);
            context.RoadTolls.Add(rt079);
            context.RoadTolls.Add(rt080);
            context.RoadTolls.Add(rt081);
            context.RoadTolls.Add(rt082);
            context.RoadTolls.Add(rt083);
            context.RoadTolls.Add(rt084);
            context.RoadTolls.Add(rt085);
            context.RoadTolls.Add(rt086);
            context.RoadTolls.Add(rt087);
            context.RoadTolls.Add(rt088);
            context.RoadTolls.Add(rt089);
            context.RoadTolls.Add(rt090);
            context.RoadTolls.Add(rt091);
            context.RoadTolls.Add(rt092);
            context.RoadTolls.Add(rt093);
            context.RoadTolls.Add(rt094);
            context.RoadTolls.Add(rt095);
            context.RoadTolls.Add(rt096);
            context.RoadTolls.Add(rt097);
            context.RoadTolls.Add(rt098);
            context.RoadTolls.Add(rt099);
            context.RoadTolls.Add(rt100);
            context.RoadTolls.Add(rt101);
            context.RoadTolls.Add(rt102);
            context.RoadTolls.Add(rt103);
            context.RoadTolls.Add(rt104);
            context.RoadTolls.Add(rt105);
            context.RoadTolls.Add(rt106);
            context.RoadTolls.Add(rt107);
            context.RoadTolls.Add(rt108);
            context.RoadTolls.Add(rt109);
            context.RoadTolls.Add(rt110);
            context.RoadTolls.Add(rt111);
            context.RoadTolls.Add(rt112);
            context.RoadTolls.Add(rt113);
            context.RoadTolls.Add(rt114);
            context.RoadTolls.Add(rt115);
            context.RoadTolls.Add(rt116);
            context.RoadTolls.Add(rt117);
            context.RoadTolls.Add(rt118);
            context.RoadTolls.Add(rt119);
            context.RoadTolls.Add(rt120);
            context.RoadTolls.Add(rt121);
            context.RoadTolls.Add(rt122);
            context.RoadTolls.Add(rt123);
            context.RoadTolls.Add(rt124);
            context.RoadTolls.Add(rt125);
            context.RoadTolls.Add(rt126);
            context.RoadTolls.Add(rt127);
            context.RoadTolls.Add(rt128);
            context.RoadTolls.Add(rt129);
            context.RoadTolls.Add(rt130);
            context.RoadTolls.Add(rt131);
            context.RoadTolls.Add(rt132);
            context.RoadTolls.Add(rt133);
            context.RoadTolls.Add(rt134);
            context.RoadTolls.Add(rt135);
            context.RoadTolls.Add(rt136);
            context.RoadTolls.Add(rt137);
            context.RoadTolls.Add(rt138);
            context.RoadTolls.Add(rt139);
            context.RoadTolls.Add(rt140);
            context.RoadTolls.Add(rt141);
            context.RoadTolls.Add(rt142);
            context.RoadTolls.Add(rt143);
            context.RoadTolls.Add(rt144);
            context.RoadTolls.Add(rt145);
            context.RoadTolls.Add(rt146);
            context.RoadTolls.Add(rt147);
            context.RoadTolls.Add(rt148);
            context.RoadTolls.Add(rt149);
            context.RoadTolls.Add(rt150);
            context.RoadTolls.Add(rt151);
            context.RoadTolls.Add(rt152);
            context.RoadTolls.Add(rt153);
            context.RoadTolls.Add(rt154);
            context.RoadTolls.Add(rt155);
            context.RoadTolls.Add(rt156);
            context.RoadTolls.Add(rt157);
            context.RoadTolls.Add(rt158);
            context.RoadTolls.Add(rt159);
            context.RoadTolls.Add(rt160);
            context.RoadTolls.Add(rt161);
            context.RoadTolls.Add(rt162);
            context.RoadTolls.Add(rt163);
            context.RoadTolls.Add(rt164);
            context.RoadTolls.Add(rt165);
            context.RoadTolls.Add(rt166);
            context.RoadTolls.Add(rt167);
            context.RoadTolls.Add(rt168);
            context.RoadTolls.Add(rt169);
            context.RoadTolls.Add(rt170);
            context.RoadTolls.Add(rt171);
            context.RoadTolls.Add(rt172);
            context.RoadTolls.Add(rt173);
            context.RoadTolls.Add(rt174);
            context.RoadTolls.Add(rt175);
            context.RoadTolls.Add(rt176);
            context.RoadTolls.Add(rt177);
            context.RoadTolls.Add(rt178);
            context.RoadTolls.Add(rt179);
            context.RoadTolls.Add(rt180);
            context.RoadTolls.Add(rt181);
            context.RoadTolls.Add(rt182);
            context.RoadTolls.Add(rt183);
            context.RoadTolls.Add(rt184);
            context.RoadTolls.Add(rt185);
            context.RoadTolls.Add(rt186);
            context.RoadTolls.Add(rt187);
            context.RoadTolls.Add(rt188);
            context.RoadTolls.Add(rt189);
            context.RoadTolls.Add(rt190);
            context.RoadTolls.Add(rt191);
            context.RoadTolls.Add(rt192);
            context.RoadTolls.Add(rt193);
            context.RoadTolls.Add(rt194);
            context.RoadTolls.Add(rt195);
            context.RoadTolls.Add(rt196);
            context.RoadTolls.Add(rt197);
            context.RoadTolls.Add(rt198);
            context.RoadTolls.Add(rt199);
            context.RoadTolls.Add(rt200);
            context.RoadTolls.Add(rt201);
            context.RoadTolls.Add(rt202);
            context.RoadTolls.Add(rt203);
            context.RoadTolls.Add(rt204);
            context.RoadTolls.Add(rt205);
            context.RoadTolls.Add(rt206);
            context.RoadTolls.Add(rt207);
            context.RoadTolls.Add(rt208);
            context.RoadTolls.Add(rt209);
            context.RoadTolls.Add(rt210);
            context.RoadTolls.Add(rt211);
            context.RoadTolls.Add(rt212);
            context.RoadTolls.Add(rt213);
            context.RoadTolls.Add(rt214);
            context.RoadTolls.Add(rt215);
            context.RoadTolls.Add(rt216);
            context.RoadTolls.Add(rt217);
            context.RoadTolls.Add(rt218);
            context.RoadTolls.Add(rt219);
            context.RoadTolls.Add(rt220);
            context.RoadTolls.Add(rt221);
            context.RoadTolls.Add(rt222);
            context.RoadTolls.Add(rt223);
            context.RoadTolls.Add(rt224);
            context.RoadTolls.Add(rt225);
            context.RoadTolls.Add(rt226);
            context.RoadTolls.Add(rt227);
            context.RoadTolls.Add(rt228);
            context.RoadTolls.Add(rt229);
            context.RoadTolls.Add(rt230);
            context.RoadTolls.Add(rt231);
            context.RoadTolls.Add(rt232);
            context.RoadTolls.Add(rt233);
            context.RoadTolls.Add(rt234);
            context.RoadTolls.Add(rt235);
            context.RoadTolls.Add(rt236);
            context.RoadTolls.Add(rt237);
            context.RoadTolls.Add(rt238);
            context.RoadTolls.Add(rt239);
            context.RoadTolls.Add(rt240);
            context.RoadTolls.Add(rt241);
            context.RoadTolls.Add(rt242);
            context.RoadTolls.Add(rt243);
            context.RoadTolls.Add(rt244);
            context.RoadTolls.Add(rt245);
            context.RoadTolls.Add(rt246);
            context.RoadTolls.Add(rt247);
            context.RoadTolls.Add(rt248);
            context.RoadTolls.Add(rt249);
            context.RoadTolls.Add(rt250);

            context.SaveChanges();

            #endregion

            #region RoadTollPrice

            var rtp001 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt001, Price = 0};
            var rtp002 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt002, Price = 0};
            var rtp003 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt003, Price = 0};
            var rtp004 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt004, Price = 0};
            var rtp005 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt005, Price = 0};
            var rtp006 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt006, Price = 0};
            var rtp007 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt007, Price = 0};
            var rtp008 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt008, Price = 0};
            var rtp009 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt009, Price = 0};
            var rtp010 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt010, Price = 0};

            var rtp011 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt011, Price = 50 };
            var rtp012 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt012, Price = 90 };
            var rtp013 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt013, Price = 120 };
            var rtp014 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt014, Price = 250 };
            var rtp015 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt015, Price = 500 };
            var rtp016 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt016, Price = 0.5 };
            var rtp017 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt017, Price = 1 };
            var rtp018 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt018, Price = 1.5 };
            var rtp019 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt019, Price = 2.5 };
            var rtp020 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt020, Price = 4.5 };

            var rtp021 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt021, Price = 80 };
            var rtp022 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt022, Price = 150 };
            var rtp023 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt023, Price = 220 };
            var rtp024 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt024, Price = 450 };
            var rtp025 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt025, Price = 880 };
            var rtp026 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt026, Price = 1 };
            var rtp027 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt027, Price = 1.5 };
            var rtp028 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt028, Price = 2 };
            var rtp029 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt029, Price = 4 };
            var rtp030 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt030, Price = 7.5 };

            var rtp031 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt031, Price = 110 };
            var rtp032 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt032, Price = 210 };
            var rtp033 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt033, Price = 330 };
            var rtp034 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt034, Price = 630 };
            var rtp035 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt035, Price = 1250 };
            var rtp036 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt036, Price = 1 };
            var rtp037 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt037, Price = 2 };
            var rtp038 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt038, Price = 3 };
            var rtp039 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt039, Price = 5.5 };
            var rtp040 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt040, Price = 11 };

            var rtp041 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt041, Price = 160 };
            var rtp042 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt042, Price = 320 };
            var rtp043 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt043, Price = 490 };
            var rtp044 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt044, Price = 960 };
            var rtp045 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt045, Price = 1900 };
            var rtp046 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt046, Price = 1.5 };
            var rtp047 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt047, Price = 3 };
            var rtp048 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt048, Price = 4.5 };
            var rtp049 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt049, Price = 8.5 };
            var rtp050 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt050, Price = 16.5 };

            var rtp051 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt051, Price = 200 };
            var rtp052 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt052, Price = 390 };
            var rtp053 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt053, Price = 590 };
            var rtp054 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt054, Price = 1150 };
            var rtp055 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt055, Price = 2300 };
            var rtp056 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt056, Price = 2 };
            var rtp057 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt057, Price = 3.5 };
            var rtp058 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt058, Price = 5 };
            var rtp059 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt059, Price = 10 };
            var rtp060 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt060, Price = 19.5 };

            var rtp061 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt061, Price = 210 };
            var rtp062 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt062, Price = 420 };
            var rtp063 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt063, Price = 650 };
            var rtp064 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt064, Price = 1290 };
            var rtp065 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt065, Price = 2580 };
            var rtp066 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt066, Price = 2 };
            var rtp067 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt067, Price = 4 };
            var rtp068 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt068, Price = 5.5 };
            var rtp069 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt069, Price = 11 };
            var rtp070 = new RoadTollPrice { PriceList = priceL1, RoadToll = rt070, Price = 22 };

            var rtp071 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt071, Price = 0 };
            var rtp072 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt072, Price = 0 };
            var rtp073 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt073, Price = 0 };
            var rtp074 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt074, Price = 0 };
            var rtp075 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt075, Price = 0 };
            var rtp076 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt076, Price = 0 };
            var rtp077 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt077, Price = 0 };
            var rtp078 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt078, Price = 0 };
            var rtp079 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt079, Price = 0 };
            var rtp080 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt080, Price = 0 };

            var rtp081 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt081, Price = 40 };
            var rtp082 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt082, Price = 80 };
            var rtp083 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt083, Price = 110 };
            var rtp084 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt084, Price = 220 };
            var rtp085 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt085, Price = 450 };
            var rtp086 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt086, Price = 0.5 };
            var rtp087 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt087, Price = 1 };
            var rtp088 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt088, Price = 1 };
            var rtp089 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt089, Price = 2 };
            var rtp090 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt090, Price = 4 };

            var rtp091 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt091, Price = 50 };
            var rtp092 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt092, Price = 90 };
            var rtp093 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt093, Price = 130 };
            var rtp094 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt094, Price = 270 };
            var rtp095 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt095, Price = 570 };
            var rtp096 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt096, Price = 0.5 };
            var rtp097 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt097, Price = 1 };
            var rtp098 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt098, Price = 1.5 };
            var rtp099 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt099, Price = 2.5 };
            var rtp100 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt100, Price = 5 };

            var rtp101 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt101, Price = 60 };
            var rtp102 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt102, Price = 110 };
            var rtp103 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt103, Price = 160 };
            var rtp104 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt104, Price = 350 };
            var rtp105 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt105, Price = 660 };
            var rtp106 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt106, Price = 1 };
            var rtp107 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt107, Price = 1 };
            var rtp108 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt108, Price = 1.5 };
            var rtp109 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt109, Price = 3 };
            var rtp110 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt110, Price = 6 };

            var rtp111 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt111, Price = 80 };
            var rtp112 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt112, Price = 160 };
            var rtp113 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt113, Price = 250 };
            var rtp114 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt114, Price = 490 };
            var rtp115 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt115, Price = 990 };
            var rtp116 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt116, Price = 1 };
            var rtp117 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt117, Price = 1.5 };
            var rtp118 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt118, Price = 2.5 };
            var rtp119 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt119, Price = 4.5 };
            var rtp120 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt120, Price = 8.5 };

            var rtp121 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt121, Price = 120 };
            var rtp122 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt122, Price = 240 };
            var rtp123 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt123, Price = 370 };
            var rtp124 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt124, Price = 720 };
            var rtp125 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt125, Price = 1430 };
            var rtp126 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt126, Price = 1.5 };
            var rtp127 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt127, Price = 2.5 };
            var rtp128 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt128, Price = 3.5 };
            var rtp129 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt129, Price = 6.5 };
            var rtp130 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt130, Price = 12.5 };

            var rtp131 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt131, Price = 160 };
            var rtp132 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt132, Price = 310 };
            var rtp133 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt133, Price = 470 };
            var rtp134 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt134, Price = 930 };
            var rtp135 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt135, Price = 1840 };
            var rtp136 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt136, Price = 1.5 };
            var rtp137 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt137, Price = 3 };
            var rtp138 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt138, Price = 4 };
            var rtp139 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt139, Price = 8 };
            var rtp140 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt140, Price = 16 };

            var rtp141 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt141, Price = 190 };
            var rtp142 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt142, Price = 370 };
            var rtp143 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt143, Price = 550 };
            var rtp144 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt144, Price = 1080 };
            var rtp145 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt145, Price = 2170 };
            var rtp146 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt146, Price = 2 };
            var rtp147 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt147, Price = 3.5 };
            var rtp148 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt148, Price = 5 };
            var rtp149 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt149, Price = 9.5 };
            var rtp150 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt150, Price = 18.5 };

            var rtp151 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt151, Price = 210 };
            var rtp152 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt152, Price = 410 };
            var rtp153 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt153, Price = 600 };
            var rtp154 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt154, Price = 1210 };
            var rtp155 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt155, Price = 2410 };
            var rtp156 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt156, Price = 2 };
            var rtp157 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt157, Price = 3.5 };
            var rtp158 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt158, Price = 5.5 };
            var rtp159 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt159, Price = 10.5 };
            var rtp160 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt160, Price = 20.5 };

            var rtp161 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt161, Price = 250 };
            var rtp162 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt162, Price = 490 };
            var rtp163 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt163, Price = 740 };
            var rtp164 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt164, Price = 1470 };
            var rtp165 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt165, Price = 2930 };
            var rtp166 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt166, Price = 2.5 };
            var rtp167 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt167, Price = 4.5 };
            var rtp168 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt168, Price = 6.5 };
            var rtp169 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt169, Price = 12.5 };
            var rtp170 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt170, Price = 25 };

            var rtp171 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt171, Price = 280 };
            var rtp172 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt172, Price = 550 };
            var rtp173 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt173, Price = 820 };
            var rtp174 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt174, Price = 1620 };
            var rtp175 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt175, Price = 3240 };
            var rtp176 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt176, Price = 2.5 };
            var rtp177 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt177, Price = 5 };
            var rtp178 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt178, Price = 7 };
            var rtp179 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt179, Price = 14 };
            var rtp180 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt180, Price = 27.5 };

            var rtp181 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt181, Price = 320 };
            var rtp182 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt182, Price = 640 };
            var rtp183 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt183, Price = 960 };
            var rtp184 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt184, Price = 1900 };
            var rtp185 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt185, Price = 3810 };
            var rtp186 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt186, Price = 3 };
            var rtp187 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt187, Price = 5.5 };
            var rtp188 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt188, Price = 8.5 };
            var rtp189 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt189, Price = 16.5 };
            var rtp190 = new RoadTollPrice { PriceList = priceL2, RoadToll = rt190, Price = 32.5 };

            var rtp191 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt191, Price = 0 };
            var rtp192 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt192, Price = 0 };
            var rtp193 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt193, Price = 0 };
            var rtp194 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt194, Price = 0 };
            var rtp195 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt195, Price = 0 };
            var rtp196 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt196, Price = 0 };
            var rtp197 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt197, Price = 0 };
            var rtp198 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt198, Price = 0 };
            var rtp199 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt199, Price = 0 };
            var rtp200 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt200, Price = 0 };

            var rtp201 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt201, Price = 60 };
            var rtp202 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt202, Price = 110 };
            var rtp203 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt203, Price = 160 };
            var rtp204 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt204, Price = 320 };
            var rtp205 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt205, Price = 650 };
            var rtp206 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt206, Price = 1 };
            var rtp207 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt207, Price = 1 };
            var rtp208 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt208, Price = 1.5 };
            var rtp209 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt209, Price = 3 };
            var rtp210 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt210, Price = 5.5 };

            var rtp211 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt211, Price = 80 };
            var rtp212 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt212, Price = 160 };
            var rtp213 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt213, Price = 240 };
            var rtp214 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt214, Price = 480 };
            var rtp215 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt215, Price = 960 };
            var rtp216 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt216, Price = 1 };
            var rtp217 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt217, Price = 1.5 };
            var rtp218 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt218, Price = 2.5 };
            var rtp219 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt219, Price = 4.5 };
            var rtp220 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt220, Price = 8.5 };

            var rtp221 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt221, Price = 120 };
            var rtp222 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt222, Price = 240 };
            var rtp223 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt223, Price = 370 };
            var rtp224 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt224, Price = 730 };
            var rtp225 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt225, Price = 1470 };
            var rtp226 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt226, Price = 1.5 };
            var rtp227 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt227, Price = 2.5 };
            var rtp228 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt228, Price = 3.5 };
            var rtp229 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt229, Price = 6.5 };
            var rtp230 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt230, Price = 12.5 };

            var rtp231 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt231, Price = 180 };
            var rtp232 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt232, Price = 350 };
            var rtp233 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt233, Price = 530 };
            var rtp234 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt234, Price = 1060 };
            var rtp235 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt235, Price = 2130 };
            var rtp236 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt236, Price = 2 };
            var rtp237 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt237, Price = 3 };
            var rtp238 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt238, Price = 4.5 };
            var rtp239 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt239, Price = 9 };
            var rtp240 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt240, Price = 18.8 };

            var rtp241 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt241, Price = 220 };
            var rtp242 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt242, Price = 430 };
            var rtp243 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt243, Price = 640 };
            var rtp244 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt244, Price = 1270 };
            var rtp245 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt245, Price = 2560 };
            var rtp246 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt246, Price = 2 };
            var rtp247 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt247, Price = 4 };
            var rtp248 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt248, Price = 5.5 };
            var rtp249 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt249, Price = 11 };
            var rtp250 = new RoadTollPrice { PriceList = priceL3, RoadToll = rt250, Price = 22 };

            context.RoadTollPrices.Add(rtp001);
            context.RoadTollPrices.Add(rtp002);
            context.RoadTollPrices.Add(rtp003);
            context.RoadTollPrices.Add(rtp004);
            context.RoadTollPrices.Add(rtp005);
            context.RoadTollPrices.Add(rtp006);
            context.RoadTollPrices.Add(rtp007);
            context.RoadTollPrices.Add(rtp008);
            context.RoadTollPrices.Add(rtp009);
            context.RoadTollPrices.Add(rtp010);
            context.RoadTollPrices.Add(rtp011);
            context.RoadTollPrices.Add(rtp012);
            context.RoadTollPrices.Add(rtp013);
            context.RoadTollPrices.Add(rtp014);
            context.RoadTollPrices.Add(rtp015);
            context.RoadTollPrices.Add(rtp016);
            context.RoadTollPrices.Add(rtp017);
            context.RoadTollPrices.Add(rtp018);
            context.RoadTollPrices.Add(rtp019);
            context.RoadTollPrices.Add(rtp020);
            context.RoadTollPrices.Add(rtp021);
            context.RoadTollPrices.Add(rtp022);
            context.RoadTollPrices.Add(rtp023);
            context.RoadTollPrices.Add(rtp024);
            context.RoadTollPrices.Add(rtp025);
            context.RoadTollPrices.Add(rtp026);
            context.RoadTollPrices.Add(rtp027);
            context.RoadTollPrices.Add(rtp028);
            context.RoadTollPrices.Add(rtp029);
            context.RoadTollPrices.Add(rtp030);
            context.RoadTollPrices.Add(rtp031);
            context.RoadTollPrices.Add(rtp032);
            context.RoadTollPrices.Add(rtp033);
            context.RoadTollPrices.Add(rtp034);
            context.RoadTollPrices.Add(rtp035);
            context.RoadTollPrices.Add(rtp036);
            context.RoadTollPrices.Add(rtp037);
            context.RoadTollPrices.Add(rtp038);
            context.RoadTollPrices.Add(rtp039);
            context.RoadTollPrices.Add(rtp040);
            context.RoadTollPrices.Add(rtp041);
            context.RoadTollPrices.Add(rtp042);
            context.RoadTollPrices.Add(rtp043);
            context.RoadTollPrices.Add(rtp044);
            context.RoadTollPrices.Add(rtp045);
            context.RoadTollPrices.Add(rtp046);
            context.RoadTollPrices.Add(rtp047);
            context.RoadTollPrices.Add(rtp048);
            context.RoadTollPrices.Add(rtp049);
            context.RoadTollPrices.Add(rtp050);
            context.RoadTollPrices.Add(rtp051);
            context.RoadTollPrices.Add(rtp052);
            context.RoadTollPrices.Add(rtp053);
            context.RoadTollPrices.Add(rtp054);
            context.RoadTollPrices.Add(rtp055);
            context.RoadTollPrices.Add(rtp056);
            context.RoadTollPrices.Add(rtp057);
            context.RoadTollPrices.Add(rtp058);
            context.RoadTollPrices.Add(rtp059);
            context.RoadTollPrices.Add(rtp060);
            context.RoadTollPrices.Add(rtp061);
            context.RoadTollPrices.Add(rtp062);
            context.RoadTollPrices.Add(rtp063);
            context.RoadTollPrices.Add(rtp064);
            context.RoadTollPrices.Add(rtp065);
            context.RoadTollPrices.Add(rtp066);
            context.RoadTollPrices.Add(rtp067);
            context.RoadTollPrices.Add(rtp068);
            context.RoadTollPrices.Add(rtp069);
            context.RoadTollPrices.Add(rtp070);
            context.RoadTollPrices.Add(rtp071);
            context.RoadTollPrices.Add(rtp072);
            context.RoadTollPrices.Add(rtp073);
            context.RoadTollPrices.Add(rtp074);
            context.RoadTollPrices.Add(rtp075);
            context.RoadTollPrices.Add(rtp076);
            context.RoadTollPrices.Add(rtp077);
            context.RoadTollPrices.Add(rtp078);
            context.RoadTollPrices.Add(rtp079);
            context.RoadTollPrices.Add(rtp080);
            context.RoadTollPrices.Add(rtp081);
            context.RoadTollPrices.Add(rtp082);
            context.RoadTollPrices.Add(rtp083);
            context.RoadTollPrices.Add(rtp084);
            context.RoadTollPrices.Add(rtp085);
            context.RoadTollPrices.Add(rtp086);
            context.RoadTollPrices.Add(rtp087);
            context.RoadTollPrices.Add(rtp088);
            context.RoadTollPrices.Add(rtp089);
            context.RoadTollPrices.Add(rtp090);
            context.RoadTollPrices.Add(rtp091);
            context.RoadTollPrices.Add(rtp092);
            context.RoadTollPrices.Add(rtp093);
            context.RoadTollPrices.Add(rtp094);
            context.RoadTollPrices.Add(rtp095);
            context.RoadTollPrices.Add(rtp096);
            context.RoadTollPrices.Add(rtp097);
            context.RoadTollPrices.Add(rtp098);
            context.RoadTollPrices.Add(rtp099);
            context.RoadTollPrices.Add(rtp100);
            context.RoadTollPrices.Add(rtp101);
            context.RoadTollPrices.Add(rtp102);
            context.RoadTollPrices.Add(rtp103);
            context.RoadTollPrices.Add(rtp104);
            context.RoadTollPrices.Add(rtp105);
            context.RoadTollPrices.Add(rtp106);
            context.RoadTollPrices.Add(rtp107);
            context.RoadTollPrices.Add(rtp108);
            context.RoadTollPrices.Add(rtp109);
            context.RoadTollPrices.Add(rtp110);
            context.RoadTollPrices.Add(rtp111);
            context.RoadTollPrices.Add(rtp112);
            context.RoadTollPrices.Add(rtp113);
            context.RoadTollPrices.Add(rtp114);
            context.RoadTollPrices.Add(rtp115);
            context.RoadTollPrices.Add(rtp116);
            context.RoadTollPrices.Add(rtp117);
            context.RoadTollPrices.Add(rtp118);
            context.RoadTollPrices.Add(rtp119);
            context.RoadTollPrices.Add(rtp120);
            context.RoadTollPrices.Add(rtp121);
            context.RoadTollPrices.Add(rtp122);
            context.RoadTollPrices.Add(rtp123);
            context.RoadTollPrices.Add(rtp124);
            context.RoadTollPrices.Add(rtp125);
            context.RoadTollPrices.Add(rtp126);
            context.RoadTollPrices.Add(rtp127);
            context.RoadTollPrices.Add(rtp128);
            context.RoadTollPrices.Add(rtp129);
            context.RoadTollPrices.Add(rtp130);
            context.RoadTollPrices.Add(rtp131);
            context.RoadTollPrices.Add(rtp132);
            context.RoadTollPrices.Add(rtp133);
            context.RoadTollPrices.Add(rtp134);
            context.RoadTollPrices.Add(rtp135);
            context.RoadTollPrices.Add(rtp136);
            context.RoadTollPrices.Add(rtp137);
            context.RoadTollPrices.Add(rtp138);
            context.RoadTollPrices.Add(rtp139);
            context.RoadTollPrices.Add(rtp140);
            context.RoadTollPrices.Add(rtp141);
            context.RoadTollPrices.Add(rtp142);
            context.RoadTollPrices.Add(rtp143);
            context.RoadTollPrices.Add(rtp144);
            context.RoadTollPrices.Add(rtp145);
            context.RoadTollPrices.Add(rtp146);
            context.RoadTollPrices.Add(rtp147);
            context.RoadTollPrices.Add(rtp148);
            context.RoadTollPrices.Add(rtp149);
            context.RoadTollPrices.Add(rtp150);
            context.RoadTollPrices.Add(rtp151);
            context.RoadTollPrices.Add(rtp152);
            context.RoadTollPrices.Add(rtp153);
            context.RoadTollPrices.Add(rtp154);
            context.RoadTollPrices.Add(rtp155);
            context.RoadTollPrices.Add(rtp156);
            context.RoadTollPrices.Add(rtp157);
            context.RoadTollPrices.Add(rtp158);
            context.RoadTollPrices.Add(rtp159);
            context.RoadTollPrices.Add(rtp160);
            context.RoadTollPrices.Add(rtp161);
            context.RoadTollPrices.Add(rtp162);
            context.RoadTollPrices.Add(rtp163);
            context.RoadTollPrices.Add(rtp164);
            context.RoadTollPrices.Add(rtp165);
            context.RoadTollPrices.Add(rtp166);
            context.RoadTollPrices.Add(rtp167);
            context.RoadTollPrices.Add(rtp168);
            context.RoadTollPrices.Add(rtp169);
            context.RoadTollPrices.Add(rtp170);
            context.RoadTollPrices.Add(rtp171);
            context.RoadTollPrices.Add(rtp172);
            context.RoadTollPrices.Add(rtp173);
            context.RoadTollPrices.Add(rtp174);
            context.RoadTollPrices.Add(rtp175);
            context.RoadTollPrices.Add(rtp176);
            context.RoadTollPrices.Add(rtp177);
            context.RoadTollPrices.Add(rtp178);
            context.RoadTollPrices.Add(rtp179);
            context.RoadTollPrices.Add(rtp180);
            context.RoadTollPrices.Add(rtp181);
            context.RoadTollPrices.Add(rtp182);
            context.RoadTollPrices.Add(rtp183);
            context.RoadTollPrices.Add(rtp184);
            context.RoadTollPrices.Add(rtp185);
            context.RoadTollPrices.Add(rtp186);
            context.RoadTollPrices.Add(rtp187);
            context.RoadTollPrices.Add(rtp188);
            context.RoadTollPrices.Add(rtp189);
            context.RoadTollPrices.Add(rtp190);
            context.RoadTollPrices.Add(rtp191);
            context.RoadTollPrices.Add(rtp192);
            context.RoadTollPrices.Add(rtp193);
            context.RoadTollPrices.Add(rtp194);
            context.RoadTollPrices.Add(rtp195);
            context.RoadTollPrices.Add(rtp196);
            context.RoadTollPrices.Add(rtp197);
            context.RoadTollPrices.Add(rtp198);
            context.RoadTollPrices.Add(rtp199);
            context.RoadTollPrices.Add(rtp200);
            context.RoadTollPrices.Add(rtp201);
            context.RoadTollPrices.Add(rtp202);
            context.RoadTollPrices.Add(rtp203);
            context.RoadTollPrices.Add(rtp204);
            context.RoadTollPrices.Add(rtp205);
            context.RoadTollPrices.Add(rtp206);
            context.RoadTollPrices.Add(rtp207);
            context.RoadTollPrices.Add(rtp208);
            context.RoadTollPrices.Add(rtp209);
            context.RoadTollPrices.Add(rtp210);
            context.RoadTollPrices.Add(rtp211);
            context.RoadTollPrices.Add(rtp212);
            context.RoadTollPrices.Add(rtp213);
            context.RoadTollPrices.Add(rtp214);
            context.RoadTollPrices.Add(rtp215);
            context.RoadTollPrices.Add(rtp216);
            context.RoadTollPrices.Add(rtp217);
            context.RoadTollPrices.Add(rtp218);
            context.RoadTollPrices.Add(rtp219);
            context.RoadTollPrices.Add(rtp220);
            context.RoadTollPrices.Add(rtp221);
            context.RoadTollPrices.Add(rtp222);
            context.RoadTollPrices.Add(rtp223);
            context.RoadTollPrices.Add(rtp224);
            context.RoadTollPrices.Add(rtp225);
            context.RoadTollPrices.Add(rtp226);
            context.RoadTollPrices.Add(rtp227);
            context.RoadTollPrices.Add(rtp228);
            context.RoadTollPrices.Add(rtp229);
            context.RoadTollPrices.Add(rtp230);
            context.RoadTollPrices.Add(rtp231);
            context.RoadTollPrices.Add(rtp232);
            context.RoadTollPrices.Add(rtp233);
            context.RoadTollPrices.Add(rtp234);
            context.RoadTollPrices.Add(rtp235);
            context.RoadTollPrices.Add(rtp236);
            context.RoadTollPrices.Add(rtp237);
            context.RoadTollPrices.Add(rtp238);
            context.RoadTollPrices.Add(rtp239);
            context.RoadTollPrices.Add(rtp240);
            context.RoadTollPrices.Add(rtp241);
            context.RoadTollPrices.Add(rtp242);
            context.RoadTollPrices.Add(rtp243);
            context.RoadTollPrices.Add(rtp244);
            context.RoadTollPrices.Add(rtp245);
            context.RoadTollPrices.Add(rtp246);
            context.RoadTollPrices.Add(rtp247);
            context.RoadTollPrices.Add(rtp248);
            context.RoadTollPrices.Add(rtp249);
            context.RoadTollPrices.Add(rtp250);

            context.SaveChanges();

            #endregion

        }
    }
}
