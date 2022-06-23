using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothManagementSystem.Core.Features.General;
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
            var ad1 = new Administrator { FirstName = "Velibor", LastName = "Stojkovic", EmailAddress = "veliborstojkovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-40), Role = Role.Administrator, TollStation = null };
            context.Administrators.Add(ad1);

            // Manager
            var mn1 = new Manager { FirstName = "Igor", LastName = "Mirkovic", EmailAddress = "igormirkovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-34), Role = Role.Manager };

            // Referent
            var rf1 = new Referent { FirstName = "Nikola", LastName = "Petrovic", EmailAddress = "nikolapetrovic@example.com", Password = "test123", DateOfBirth = DateTime.Now.AddYears(-25), Role = Role.Referent };

            

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

            #endregion

            #region TollBooth

            var tb001 = new TollBooth { IsETC = true, IsOpen = true };
            var tb002 = new TollBooth { IsETC = true, IsOpen = false };
            var tb003 = new TollBooth { IsETC = false, IsOpen = true };
            var tb004 = new TollBooth { IsETC = false, IsOpen = false };

            var tb011 = new TollBooth { IsETC = true, IsOpen = true };
            var tb012 = new TollBooth { IsETC = true, IsOpen = false };
            var tb013 = new TollBooth { IsETC = false, IsOpen = true };
            var tb014 = new TollBooth { IsETC = false, IsOpen = false };

            var tb021 = new TollBooth { IsETC = true, IsOpen = true };
            var tb022 = new TollBooth { IsETC = true, IsOpen = false };
            var tb023 = new TollBooth { IsETC = false, IsOpen = true };
            var tb024 = new TollBooth { IsETC = false, IsOpen = false };

            var tb031 = new TollBooth { IsETC = true, IsOpen = true };
            var tb032 = new TollBooth { IsETC = true, IsOpen = false };
            var tb033 = new TollBooth { IsETC = false, IsOpen = true };
            var tb034 = new TollBooth { IsETC = false, IsOpen = false };

            var tb041 = new TollBooth { IsETC = true, IsOpen = true };
            var tb042 = new TollBooth { IsETC = true, IsOpen = false };
            var tb043 = new TollBooth { IsETC = false, IsOpen = true };
            var tb044 = new TollBooth { IsETC = false, IsOpen = false };

            var tb051 = new TollBooth { IsETC = true, IsOpen = true };
            var tb052 = new TollBooth { IsETC = true, IsOpen = false };
            var tb053 = new TollBooth { IsETC = false, IsOpen = true };
            var tb054 = new TollBooth { IsETC = false, IsOpen = false };

            var tb061 = new TollBooth { IsETC = true, IsOpen = true };
            var tb062 = new TollBooth { IsETC = true, IsOpen = false };
            var tb063 = new TollBooth { IsETC = false, IsOpen = true };
            var tb064 = new TollBooth { IsETC = false, IsOpen = false };

            var tb071 = new TollBooth { IsETC = true, IsOpen = true };
            var tb072 = new TollBooth { IsETC = true, IsOpen = false };
            var tb073 = new TollBooth { IsETC = false, IsOpen = true };
            var tb074 = new TollBooth { IsETC = false, IsOpen = false };

            var tb081 = new TollBooth { IsETC = true, IsOpen = true };
            var tb082 = new TollBooth { IsETC = true, IsOpen = false };
            var tb083 = new TollBooth { IsETC = false, IsOpen = true };
            var tb084 = new TollBooth { IsETC = false, IsOpen = false };

            var tb091 = new TollBooth { IsETC = true, IsOpen = true };
            var tb092 = new TollBooth { IsETC = true, IsOpen = false };
            var tb093 = new TollBooth { IsETC = false, IsOpen = true };
            var tb094 = new TollBooth { IsETC = false, IsOpen = false };

            var tb101 = new TollBooth { IsETC = true, IsOpen = true };
            var tb102 = new TollBooth { IsETC = true, IsOpen = false };
            var tb103 = new TollBooth { IsETC = false, IsOpen = true };
            var tb104 = new TollBooth { IsETC = false, IsOpen = false };

            var tb111 = new TollBooth { IsETC = true, IsOpen = true };
            var tb112 = new TollBooth { IsETC = true, IsOpen = false };
            var tb113 = new TollBooth { IsETC = false, IsOpen = true };
            var tb114 = new TollBooth { IsETC = false, IsOpen = false };

            var tb121 = new TollBooth { IsETC = true, IsOpen = true };
            var tb122 = new TollBooth { IsETC = true, IsOpen = false };
            var tb123 = new TollBooth { IsETC = false, IsOpen = true };
            var tb124 = new TollBooth { IsETC = false, IsOpen = false };

            var tb131 = new TollBooth { IsETC = true, IsOpen = true };
            var tb132 = new TollBooth { IsETC = true, IsOpen = false };
            var tb133 = new TollBooth { IsETC = false, IsOpen = true };
            var tb134 = new TollBooth { IsETC = false, IsOpen = false };

            var tb141 = new TollBooth { IsETC = true, IsOpen = true };
            var tb142 = new TollBooth { IsETC = true, IsOpen = false };
            var tb143 = new TollBooth { IsETC = false, IsOpen = true };
            var tb144 = new TollBooth { IsETC = false, IsOpen = false };

            var tb151 = new TollBooth { IsETC = true, IsOpen = true };
            var tb152 = new TollBooth { IsETC = true, IsOpen = false };
            var tb153 = new TollBooth { IsETC = false, IsOpen = true };
            var tb154 = new TollBooth { IsETC = false, IsOpen = false };

            var tb161 = new TollBooth { IsETC = true, IsOpen = true };
            var tb162 = new TollBooth { IsETC = true, IsOpen = false };
            var tb163 = new TollBooth { IsETC = false, IsOpen = true };
            var tb164 = new TollBooth { IsETC = false, IsOpen = false };

            var tb171 = new TollBooth { IsETC = true, IsOpen = true };
            var tb172 = new TollBooth { IsETC = true, IsOpen = false };
            var tb173 = new TollBooth { IsETC = false, IsOpen = true };
            var tb174 = new TollBooth { IsETC = false, IsOpen = false };

            var tb181 = new TollBooth { IsETC = true, IsOpen = true };
            var tb182 = new TollBooth { IsETC = true, IsOpen = false };
            var tb183 = new TollBooth { IsETC = false, IsOpen = true };
            var tb184 = new TollBooth { IsETC = false, IsOpen = false };

            var tb191 = new TollBooth { IsETC = true, IsOpen = true };
            var tb192 = new TollBooth { IsETC = true, IsOpen = false };
            var tb193 = new TollBooth { IsETC = false, IsOpen = true };
            var tb194 = new TollBooth { IsETC = false, IsOpen = false };

            var tb201 = new TollBooth { IsETC = true, IsOpen = true };
            var tb202 = new TollBooth { IsETC = true, IsOpen = false };
            var tb203 = new TollBooth { IsETC = false, IsOpen = true };
            var tb204 = new TollBooth { IsETC = false, IsOpen = false };

            var tb211 = new TollBooth { IsETC = true, IsOpen = true };
            var tb212 = new TollBooth { IsETC = true, IsOpen = false };
            var tb213 = new TollBooth { IsETC = false, IsOpen = true };
            var tb214 = new TollBooth { IsETC = false, IsOpen = false };

            var tb221 = new TollBooth { IsETC = true, IsOpen = true };
            var tb222 = new TollBooth { IsETC = true, IsOpen = false };
            var tb223 = new TollBooth { IsETC = false, IsOpen = true };
            var tb224 = new TollBooth { IsETC = false, IsOpen = false };

            var tb231 = new TollBooth { IsETC = true, IsOpen = true };
            var tb232 = new TollBooth { IsETC = true, IsOpen = false };
            var tb233 = new TollBooth { IsETC = false, IsOpen = true };
            var tb234 = new TollBooth { IsETC = false, IsOpen = false };

            var tb241 = new TollBooth { IsETC = true, IsOpen = true };
            var tb242 = new TollBooth { IsETC = true, IsOpen = false };
            var tb243 = new TollBooth { IsETC = false, IsOpen = true };
            var tb244 = new TollBooth { IsETC = false, IsOpen = false };

            #endregion

            #region TollStation

            var ts01 = new TollStation { Location = loc01, Name = loc01.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb001, tb002, tb003, tb004 } };
            tb001.TollStation = ts01;
            tb002.TollStation = ts01;
            tb003.TollStation = ts01;
            tb004.TollStation = ts01;

            var ts02 = new TollStation { Location = loc02, Name = loc02.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb011, tb012, tb013, tb014 } };
            tb011.TollStation = ts02;
            tb012.TollStation = ts02;
            tb013.TollStation = ts02;
            tb014.TollStation = ts02;

            var ts03 = new TollStation { Location = loc03, Name = loc03.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb021, tb022, tb023, tb024 } };
            tb021.TollStation = ts03;
            tb022.TollStation = ts03;
            tb023.TollStation = ts03;
            tb024.TollStation = ts03;

            var ts04 = new TollStation { Location = loc04, Name = loc04.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb031, tb032, tb033, tb034 } };
            tb031.TollStation = ts04;
            tb032.TollStation = ts04;
            tb033.TollStation = ts04;
            tb034.TollStation = ts04;

            var ts05 = new TollStation { Location = loc05, Name = loc05.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb041, tb042, tb043, tb044 } };
            tb041.TollStation = ts05;
            tb042.TollStation = ts05;
            tb043.TollStation = ts05;
            tb044.TollStation = ts05;

            var ts06 = new TollStation { Location = loc06, Name = loc06.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb051, tb052, tb053, tb054 } };
            tb051.TollStation = ts06;
            tb052.TollStation = ts06;
            tb053.TollStation = ts06;
            tb054.TollStation = ts06;

            var ts07 = new TollStation { Location = loc07, Name = loc07.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb061, tb062, tb063, tb064 } };
            tb061.TollStation = ts07;
            tb062.TollStation = ts07;
            tb063.TollStation = ts07;
            tb064.TollStation = ts07;

            var ts08 = new TollStation { Location = loc08, Name = loc08.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb071, tb072, tb073, tb074 } };
            tb071.TollStation = ts08;
            tb072.TollStation = ts08;
            tb073.TollStation = ts08;
            tb074.TollStation = ts08;

            var ts09 = new TollStation { Location = loc09, Name = loc09.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb081, tb082, tb083, tb084 } };
            tb081.TollStation = ts09;
            tb082.TollStation = ts09;
            tb083.TollStation = ts09;
            tb084.TollStation = ts09;

            var ts10 = new TollStation { Location = loc10, Name = loc10.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb091, tb092, tb093, tb094 } };
            tb091.TollStation = ts10;
            tb092.TollStation = ts10;
            tb093.TollStation = ts10;
            tb094.TollStation = ts10;

            var ts11 = new TollStation { Location = loc11, Name = loc11.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb101, tb102, tb103, tb104 } };
            tb101.TollStation = ts11;
            tb102.TollStation = ts11;
            tb103.TollStation = ts11;
            tb104.TollStation = ts11;

            var ts12 = new TollStation { Location = loc12, Name = loc12.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb111, tb112, tb113, tb114 } };
            tb111.TollStation = ts12;
            tb112.TollStation = ts12;
            tb113.TollStation = ts12;
            tb114.TollStation = ts12;

            var ts13 = new TollStation { Location = loc13, Name = loc13.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb121, tb122, tb123, tb124 } };
            tb121.TollStation = ts13;
            tb122.TollStation = ts13;
            tb123.TollStation = ts13;
            tb124.TollStation = ts13;

            var ts14 = new TollStation { Location = loc14, Name = loc14.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb131, tb132, tb133, tb134 } };
            tb131.TollStation = ts14;
            tb132.TollStation = ts14;
            tb133.TollStation = ts14;
            tb134.TollStation = ts14;

            var ts15 = new TollStation { Location = loc15, Name = loc15.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb141, tb142, tb143, tb144 } };
            tb141.TollStation = ts15;
            tb142.TollStation = ts15;
            tb143.TollStation = ts15;
            tb144.TollStation = ts15;

            var ts16 = new TollStation { Location = loc16, Name = loc16.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb151, tb152, tb153, tb154 } };
            tb151.TollStation = ts16;
            tb152.TollStation = ts16;
            tb153.TollStation = ts16;
            tb154.TollStation = ts16;

            var ts17 = new TollStation { Location = loc17, Name = loc17.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb161, tb162, tb163, tb164 } };
            tb161.TollStation = ts17;
            tb162.TollStation = ts17;
            tb163.TollStation = ts17;
            tb164.TollStation = ts17;

            var ts18 = new TollStation { Location = loc18, Name = loc18.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb171, tb172, tb173, tb174 } };
            tb171.TollStation = ts18;
            tb172.TollStation = ts18;
            tb173.TollStation = ts18;
            tb174.TollStation = ts18;

            var ts19 = new TollStation { Location = loc19, Name = loc19.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb181, tb182, tb183, tb184 } };
            tb181.TollStation = ts19;
            tb182.TollStation = ts19;
            tb183.TollStation = ts19;
            tb184.TollStation = ts19;

            var ts20 = new TollStation { Location = loc20, Name = loc20.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb191, tb192, tb193, tb194 } };
            tb191.TollStation = ts20;
            tb192.TollStation = ts20;
            tb193.TollStation = ts20;
            tb194.TollStation = ts20;

            var ts21 = new TollStation { Location = loc21, Name = loc21.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb201, tb202, tb203, tb204 } };
            tb201.TollStation = ts21;
            tb202.TollStation = ts21;
            tb203.TollStation = ts21;
            tb204.TollStation = ts21;

            var ts22 = new TollStation { Location = loc22, Name = loc22.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb211, tb212, tb213, tb214 } };
            tb211.TollStation = ts22;
            tb212.TollStation = ts22;
            tb213.TollStation = ts22;
            tb214.TollStation = ts22;

            var ts23 = new TollStation { Location = loc23, Name = loc23.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb221, tb222, tb223, tb224 } };
            tb221.TollStation = ts23;
            tb222.TollStation = ts23;
            tb223.TollStation = ts23;
            tb224.TollStation = ts23;

            var ts24 = new TollStation { Location = loc24, Name = loc24.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb231, tb232, tb233, tb234 } };
            tb231.TollStation = ts24;
            tb232.TollStation = ts24;
            tb233.TollStation = ts24;
            tb234.TollStation = ts24;

            var ts25 = new TollStation { Location = loc25, Name = loc25.Name, Boss = rf1, TollBooths = new List<TollBooth> { tb241, tb242, tb243, tb244 } };
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
            rf1.TollStation = ts01;

            context.Managers.Add(mn1);
            context.Referents.Add(rf1);

            #endregion

            #region Section

            var sec1 = new Section { Origin = ts01, Destination = ts07};
            var sec2 = new Section { Origin = ts08, Destination = ts19};
            var sec3 = new Section { Origin = ts20, Destination = ts25};

            context.Sections.Add(sec1);
            context.Sections.Add(sec2);
            context.Sections.Add(sec3);

            #endregion

            #region SectionInfo

            var secInfo01 = new SectionInfo { Section = sec1, TollStation = ts02, Distance = 12.5 };
            var secInfo02 = new SectionInfo { Section = sec1, TollStation = ts03, Distance = 25.9 };
            var secInfo03 = new SectionInfo { Section = sec1, TollStation = ts04, Distance = 46.6 };
            var secInfo04 = new SectionInfo { Section = sec1, TollStation = ts05, Distance = 60.8 };
            var secInfo05 = new SectionInfo { Section = sec1, TollStation = ts06, Distance = 79.0 };
            var secInfo06 = new SectionInfo { Section = sec1, TollStation = ts07, Distance = 84.7 };

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

            #endregion

            #region PriceList

            DateTime start = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime end = new DateTime(DateTime.Now.Year, 12, 31);

            var priceL1 = new PriceList { ActivationDate = start, ExpirationDate = end, Section = sec1 };
            var priceL2 = new PriceList { ActivationDate = start, ExpirationDate = end, Section = sec2 };
            var priceL3 = new PriceList { ActivationDate = start, ExpirationDate = end, Section = sec3 };

            #endregion

            context.SaveChanges();
        }
    }
}
