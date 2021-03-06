using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Spinka.Application.Reports.Ammo.Models;
using Spinka.Application.Reports.OrderPoints.Models;
using Spinka.Application.Reports.Trainings.Models;

namespace Spinka.Application.Reports
{
    public static class TemplateGenerator
    {
         public static string GenerateTrainingReport(List<DataModelForTraining> dataForReport)
         { 
             var repeatData = dataForReport.GroupBy(x => x.StartTime.Date)
                 .Select(x => new
                     {
                         Date = x.Key,
                         Count = x.Count(),
                     }
                 ).OrderBy(x => x.Date)
                 .ToList();

             var sb = new StringBuilder();
             sb.Append(@"
                        <!DOCTYPE html>
                            <html lang=""pl-PL"">
                                <head>
                                    <meta charset=""UTF-8"">
                                    <style>
                                        table {
                                            border-collapse: collapse;
                                            width: 100%;
                                        }

                                        td { 
                                            border: 1px solid black; 
                                            margin: 0;
                                            text-align: center;
                                            height: fit-content;
                                            font-family: sans-serif;
                                            font-size: 11px;
                                            padding-top: 15px;
                                            padding-bottom: 15px;
                                        }

                                        .head {
                                            border: 1px solid black; 
                                            margin: 0;
                                            text-align: center;
                                            height: 70px;
                                            background-color: #cccccc;
                                            font-family: sans-serif;
                                            font-size: 11px;
                                            font-weight: bold;
                                        }

                                        tr {
                                            page-break-inside: avoid
                                        }
                                    </style>
                                </head>
                            <body>
                                <table>
                                    <tr>
                                        <td rowspan=""2"" class=""head"">Data</td> 
                                        <td colspan=""2"" class=""head"">Grupy szkoleniowe <br> Czas od - do</td>
                                        <td rowspan=""2"" class=""head"">Przedmiot</td>
                                        <td rowspan=""2"" class=""head"">Numer i nazwa tematu <br> (zamierzenie)</td>
                                        <td rowspan=""2"" class=""head"">Miejsce</td>
                                        <td rowspan=""2"" class=""head"">Prowadz??cy zaj??cia <br> Odpowiedzialny za realizacj?? <br> zamierzenia</td>
                                        <td rowspan=""2"" class=""head"">Sprz??t i ??rodki bojowe, techniczne ??rodki materia??owe i ??rodki materia??owe; <br>
                                        <u>w liczniku - planowane,</u> <br> w mianowniku - wykorzystane</td>
                                        <td rowspan=""2"" class=""head"">Adnotacje <br> o realizacji</td>
                                    </tr>
                                    <tr>
                                        <td colspan=""2"" class=""head"">KURS DZIA??A?? SPECJANYCH</td>
                                    </tr>");
             
             foreach (var item in repeatData)
             {
                 if (item.Count > 1)
                 {
                     sb.AppendFormat(@"<tr>
                                        <td rowspan=""{0}"">{1:dd.MM.yyyy}</td>", item.Count, item.Date);
                 }

                 else
                 {
                     sb.AppendFormat(@"<tr>
                                    <td>{0:dd.MM.yyyy}</td>", item.Date);
                 }
                 
                 foreach (var data in dataForReport)
                 {
                     if (item.Count > 1 && item.Date == data.StartTime.Date)
                     {
                         sb.AppendFormat(@"<td>{0:H:mm}</td>
                                        <td>{1:H:mm}</td>
                                        <td>{2}</td>
                                        <td>{3}</td>
                                        <td>{4}</td>
                                        <td>{5}</td>
                                        <td>{6}</td>
                                        <td>{7}</td>
                                    </tr>", data.StartTime, data.EndOn, data.TrainingArea, data.Subject, 
                             data.Place.Replace(",", "<br>"), data.MainInstructor, 
                             data.Ammo.Replace(",", "<br>"), "Brak uwag");
                     }

                     else if (item.Date != data.StartTime.Date)
                     {
                         continue;
                     }
                     
                     else
                     {
                         sb.AppendFormat(@"<td>{0:H:mm}</td>
                                    <td>{1:H:mm}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>
                                    <td>{7}</td>
                                  </tr>", data.StartTime, data.EndOn, data.TrainingArea, data.Subject, 
                             data.Place.Replace(",", "<br>"), data.MainInstructor, 
                             data.Ammo.Replace(",", "<br>"), "Brak uwag");
                     }
                 }
             }

             sb.Append(@"
                                </table>
                            </body>
                        </html>");
 
             return sb.ToString();
         }

         public static string GenerateOrderPoint(DataModelForOrder data)
         {
             var sb = new StringBuilder();
             sb.Append(@"
                        <!DOCTYPE html>
                            <html lang=""pl-PL"">
                                <head>
                                    <meta charset=""UTF-8"">
                                    <style>
                                        body {
                                          font-family: Sans-Serif;
                                          font: 18px Arial;
                                          text-align: justify;    
                                        }
                                    </style>
                                </head>
                            <body>");
             
             sb.AppendFormat(@"  
                    <br>W dniu <b>{0:dd.MM.yyyy}</b> r. w godzinach {1:H:mm} - {2:H:mm} polecam przeprowadzi?? zaj??cia z {3} z {4}. 
                    <br>Temat zaj????: {5}
                    <br>Miejsce: {6}
                    <br>Kierownik zaj????: <b>{7}</b>", data.StartTime, data.StartTime, data.EndOn, data.Area, data.Groups,
                        data.Subject, data.Place, data.MainInstructor);

             if (data.HelperInstructors.Any())
             {
                 sb.Append(@"<br>Instruktorzy pomocniczy:");
                 
                 foreach (var item in data.HelperInstructors)
                 {
                     sb.AppendFormat(@"<br>{0}", item.Display);
                 }
             }

             if (data.ShootingInstructor != null)
             {
                 sb.AppendFormat(@"
                    <br>Kierownik strzelania: {0}", data.ShootingInstructor);
             }

             if (data.AmmoManger != null)
             {
                 sb.AppendFormat(@"
                    <br>Kierownik Punktu Amunicyjnego: {0}", data.AmmoManger);
             }
             
             if (data.MedicalStaff.Any())
             {
                 sb.Append(@"<br>Zabezpieczenie medyczne:");
                 
                 foreach (var item in data.MedicalStaff)
                 {
                     sb.AppendFormat(@"<br>{0}", item.Display);
                 }
             }
                
             if (data.Ammo.Any())
             {
                 sb.Append(@"<br>??rodki bojowe do zabezpieczenia zaj????:");
                 
                 foreach (var item in data.Ammo)
                 {
                     sb.AppendFormat(@"<br>{0}", item.Display);
                 }
             }
             
             sb.AppendFormat(@"
                    <br>Szef Sekcji ??rodk??w Bojowych wyda?? amunicj?? zgodnie z zapotrzebowaniem.
                    <br>Kierownika zaj???? czyni?? odpowiedzialnym za prawid??owy przebieg zaj????, przestrzeganie zasad BHP, porz??dku i dyscypliny na zaj??ciach.
                    <br>Magazynier wyda?? bro?? osobist?? dla uczestnik??w szkolenia.
                    <br>Na czas trwania konwoju amunicj?? pobra?? od oficera dy??urnego JW 2305 po 15 szt. 9 mm nb. do broni s??u??bowej:
                    <br>{0} - dow??dca pojazdu/konwoju,
                    <br>{1} - kierowca pojazdu/konwojent, celem w??a??ciwego zabezpieczenia przewo??onej amunicji.
                    <br>Konw??j polecam odby?? pojazdem s??u??bowym {2} na trasie JW 2305 - {3} - JW 2305.", data.DriverOne, 
                        data.DriverTwo, data.Vehicle, data.TargetPlace);
             
             sb.Append(@"</body>
                        </html>");    
             
             return sb.ToString();
         }

         // public static string GenerateOrderPoint(DataModelForAmmo data)
         public static string GenerateAmmoReport(DataModelForAmmo data)
         {
             var sb = new StringBuilder();
             sb.Append(@"
                        <!DOCTYPE html>
                          <html lang=""pl-PL"">
                            <head>
                              <meta charset=""utf-8"" />
                              <style>
                                * {
                                  padding: 0px;
                                  margin: 0px;
                                  border: solid black 0px;
                                  text-decoration: none;
                                  box-sizing: border-box;
                                  font-family: Arial, Helvetica, sans-serif;
                                }

                                .first-page {
                                  float: left;
                                  width: 100%;
                                  height: 920px;
                                  margin: 0;
                                  padding: 0;
                                  justify-content: center;
                                  align-items: center;
                                }

                                .second-page {
                                  float: left;
                                  width: 100%;
                                  height: 100%;
                                  margin: 0;
                                  padding: 0;
                                  justify-content: center;
                                  align-items: center;
                                }

                                .content {
                                  width: 98%;
                                  height: 98%;
                                }

                                .head {
                                  width: 100%;
                                }

                                .r1 {
                                  float: left;
                                  width: 100%;
                                  margin-bottom: 3mm;
                                }

                                .r1_1 {
                                  float: left;
                                  width: 15%;
                                }

                                .r1_2 {
                                  float: left;
                                  width: 70%;
                                }

                                .r1_3 {
                                  float: left;
                                  width: 15%;
                                }

                                .r2 {
                                  float: left;
                                  width: 80%;
                                  margin-bottom: 10px;
                                }

                                .r2_1 {
                                  float: left;
                                  width: 15%;
                                  margin-top: 10px;
                                }

                                .r2_2 {
                                  float: left;
                                  width: 85%;
                                  margin-top: 10px;
                                  text-align: center;
                                }

                                .r3 {
                                  float: right;
                                  width: 20%;
                                  height: 60px;
                                  padding-top: 5px;
                                }

                                .r4 {
                                  float: left;
                                  width: 80%;
                                  margin-bottom: 15px;
                                  text-align: center;
                                }

                                .r5 {
                                  float: left;
                                  width: 100%;
                                  margin-bottom: 15px;
                                }

                                .r5_1 {
                                  float: left;
                                  width: 40%;
                                  text-align: center;
                                }

                                .r5_2 {
                                  float: left;
                                  width: 60%;
                                }

                                table {
                                  border: 1px solid black;
                                  font-weight: normal;
                                  border-collapse: collapse;
                                  font-size: 12px;
                                  white-space: nowrap;
                                  margin: 0 auto;
                                  text-align: center;
                                }
                                
                                th, td, tr {
                                  border: 1px solid black;
                                  font-weight: normal;
                                  border-collapse: collapse;
                                  font-size: 12px;
                                  white-space: nowrap;
                                  margin: 0 auto;
                                  text-align: center;
                                  padding: 4px 4px 4px 4px;
                                }
                                
                                .sameWidth {
                                  width: 40px;
                                }

                                .r6 {
                                  position: relative;
                                  width: 98%;
                                  margin-bottom: 15px;
                                }
                                
                                .r6_table {
                                  display: inline-block;
                                  margin-left: 20px;
                                }

                                .r6_table td {
                                  height: 20px;
                                  width: 200px;
                                }

                                .r6_table_two { 
                                  margin-left: 31px;
                                  margin-right: 31px;
                                  display: inline-block;       
                                }

                                .r6_table_two tbody td {
                                  height: 12px;
                                }

                                .r6_table_three {
                                  display: inline-block;
                                }

                                .r7 {
                                  float: left;
                                  width: 98%;
                                }

                                .verticalTableHeader {
                                  writing-mode: vertical-rl;
                                  text-orientation: sideways-right;
                                  transform: rotate(180deg);
                                }

                                .r_1 {
                                  float: left;
                                  width: 15%;
                                }

                                .noBottomBorder {
                                  border-bottom: solid 1px #fff !important ;
                                }

                                .noTopBorder {
                                  border-top: solid 1px #fff !important ;
                                }

                                .approveHeader {
                                  font-weight: bold;
                                  margin-left: 20px;
                                  float: left;
                                  font-size: 12px;
                                }

                                .signatureHeader {
                                  border-top: 1px dotted;
                                  margin-top: 3mm;
                                  margin-left: 3mm;
                                  float: left;
                                  font-size: 8px;
                                }

                                .titleHeader {
                                  margin-top: 3mm;
                                  text-align: center;
                                  font-weight: bold;
                                }

                                .r1_3_L {
                                  float: left;
                                  width: 50%;
                                  font-size: 10px;
                                  margin-top: 5px;
                                }

                                .r1_3_R {
                                  float: left;
                                  width: 42%;
                                  height: 26px;
                                  border: 3px solid black;
                                }

                                .k1{  
                                  float: left; 
                                  width: 98%;
                                  margin-left: 3mm;
                                }
                                .rr1{
                                  float: left;
                                  width: 85%;
                                  margin-bottom: 3mm;
                                }
                                .rr2{
                                  float: right;
                                  width: 15%;
                                  margin-bottom: 3mm;
                                }
                                .rr3{
                                  float: left;
                                  width: 100%;
                                  margin-bottom: 3mm;
                                }
                                .rr4{
                                  float: left;
                                  width: 98%;
                                  /* border: 1px solid red; */
                                  margin-left: 3mm;
                                  text-align: center;
                                }

                                .kk1{
                                  float: left;
                                  width: 25%;
                                  text-align: center;
                                  font-size: 10px;
                                }
                              </style>
                            </head>
                            <body>
                              <div class=""first-page"">
                                <div class=""content"">
                                  <div class=""head"">
                                    <div class=""r1"">
                                      <div class=""r1_1"">
                                        <p class=""approveHeader"">""ZATWIERDZAM""</p>
                                        <br />
                                        <p class=""signatureHeader"">PODPIS DOW??DCY LUB SZEFA</p>
                                      </div>
                                      <div class=""r1_2"">
                                        <p class=""titleHeader"">
                                          ZAPOTRZEBOWANIE -PROTOK???? ZU??YCIA NR.......
                                        </p>
                                      </div>
                                      <div class=""r1_3"">
                                        <div class=""r1_3_L"">
                                          <p style=""text-decoration: underline"">Uzbr - zp/23</p>
                                        </div>
                                        <div class=""r1_3_R"">
                                          <p
                                            style=""
                                              font-size: 12px;
                                              text-align: center;
                                              vertical-align: middle;
                                              line-height: 20px;"">
                                            WZS 20
                                          </p>
                                        </div>
                                      </div>
                                    </div>
                                    <div class=""r2"">
                                      <div class=""r2_1"">
                                        <p style=""font-weight: bold; font-size: 12px; margin-left: 20px"">
                                          Dnia ............. 2020r
                                        </p>
                                      </div>
                                      <div class=""r2_2"">
                                        <p>
                                          <span style=""font-weight: bold; font-size: 12px""
                                            >Sporz??dzono w
                                          </span>");
             
                          sb.AppendFormat(@"
                                          <span style=""font-weight: bold; font-size: 20px""
                                            >JW 2305 - {0}
                                          </span>
                                          <span style=""font-weight: bold; font-size: 12px"">dnia </span>
                                          <span style=""font-weight: bold; font-size: 15px"">{1}</span>
                                        </p>
                                      </div>
                                    </div>
                                    <div class=""r3"">
                                      <p style=""font-size: 10px; text-align: center"">Egz. nr. ...</p>
                                      <br />
                                      <p
                                        style=""
                                          font-size: 14px;
                                          font-weight: bold;
                                          text-decoration: underline;
                                          text-align: center;
                                          margin-top: -10px;"">
                                        CZ?????? R
                                      </p>
                                    </div>
                                    <div class=""r4"">
                                      <p>
                                        <span style=""font-weight: bold; font-size: 15px""
                                          >Kierownik zaj????:
                                        </span>
                                        <span
                                          style=""
                                            font-weight: bold;
                                            font-size: 15px;
                                            border-bottom: 1px dotted;"">{2}
                                        </span>
                                      </p>
                                    </div>
                                    <div class=""r5"">
                                      <div class=""r5_1"">
                                        <p>
                                          <span style=""font-weight: bold; font-size: 15px"">Dotyczy</span>
                                          <span
                                            style=""
                                              font-weight: bold;
                                              font-size: 15px;
                                              border-bottom: 1px dotted;"">
                                            zu??ycia amunicji i ??b {3:dd.MM.yyyy}r.
                                        </span>
                                        </p>
                                        <p style=""font-weight: bold; font-size: 8px"">RODZAJ MIENIA</p>
                                      </div>
                                      <div class=""r5_2"">
                                        <p>
                                          <span
                                            style=""font-weight: bold; font-size: 15px; margin-right: 10px""
                                            >Podstawa:
                                          </span>
                                          <span
                                            style=""
                                              font-weight: bold;
                                              font-size: 15px;
                                              border-bottom: 1px dotted;
                                              margin-right: 10px;
                                            "">
                                            R-z D-cy JW 2305 Nr {4}
                                          </span >
                                          <span
                                            style=""
                                              font-size: 15px;
                                              border-bottom: 1px dotted;
                                              margin-right: 10px;"">z dnia
                                          </span>
                                          <span
                                            style=""
                                              font-weight: bold;
                                              font-size: 15px;
                                              border-bottom: 1px dotted;"">{5:dd.MM.yyyy}
                                          </span>
                                        </p>
                                      </div>
                                    </div>
                                    <div class=""r6"">
                                      <table class=""r6_table"">
                                        <thead>
                                          <tr>
                                            <td class=""noBottomBorder"">Upowa??niony odbiorca</td>
                                            <td class=""noBottomBorder"">Zapotrzebowanie akceptuj??</td>
                                            <td class=""noBottomBorder"">WYDA??</td>
                                          </tr>
                                        </thead>
                                        <tbody>
                                          <tr style=""border-top: none"">
                                            <td class=""noBottomBorder""><b>{6}</b></td>
                                            <td class=""noBottomBorder""></td>
                                            <td class=""noBottomBorder""></td>
                                          </tr>
                                          <tr>
                                            <td><p style=""font-size: 8px"">STOPIE??, NAZWISKO</p></td>
                                            <td>
                                              <p style=""border-top: 1px dotted; font-size: 8px"">PODPIS</p>
                                            </td>
                                            <td>
                                              <p style=""border-top: 1px dotted; font-size: 8px"">
                                                PODPIS SZEFA S??U??BY UZBR. I EL.
                                              </p>
                                            </td>
                                          </tr>
                                        </tbody>
                                      </table>
                                      <table class=""r6_table_two"">
                                        <thead>
                                          <tr>
                                            <th colspan=""2"" rowspan=""2"">Rodz.<br />dok.</th>
                                            <th colspan=""4"" rowspan=""2"">Nr<br />dokumentu</th>
                                            <th class=""noBottomBorder"" colspan=""6"">Data dokumentu</th>
                                          </tr>
                                          <tr>
                                            <td class=""sameWidth"" colspan=""2"">Dzie??</td>
                                            <td class=""sameWidth"" colspan=""2"">M-c</td>
                                            <td class=""sameWidth"" colspan=""2"">Rok</td>
                                          </tr>
                                        </thead>
                                        <tbody>
                                          <tr>
                                            <td class=""noBottomBorder"" colspan=""2""></td>
                                            <td class=""noBottomBorder"" colspan=""4""></td>
                                            <td class=""noBottomBorder"" colspan=""2""></td>
                                            <td class=""noBottomBorder"" colspan=""2""></td>
                                            <td class=""noBottomBorder"" colspan=""2""></td>
                                          </tr>
                                          <tr>
                                            <td><b>0</b></td>
                                            <td><b>2</b></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                          </tr>
                                        </tbody>
                                      </table>
                                      <table class=""r6_table_three"">
                                        <thead>
                                          <tr>
                                            <th colspan=""7"">Nr oddz. gospodarczego</th>
                                            <th colspan=""2"" rowspan=""2"">Podod.<br />w??asn.</th>
                                            <th colspan=""7"">
                                              Jedn. przydzielone&nbsp;&nbsp;&nbsp;&nbsp;Nr<br />J.W
                                            </th>
                                          </tr>
                                          <tr>
                                            <td class=""noTopBorder"" colspan=""5""></td>
                                            <td colspan=""2"">LK.</td>
                                            <td class=""noTopBorder"" colspan=""5""></td>
                                            <td colspan=""2"">LK.</td>
                                          </tr>
                                        </thead>
                                        <tbody>
                                          <tr>
                                            <td class=""noBottomBorder"" colspan=""5""></td>
                                            <td class=""noBottomBorder"" colspan=""2""></td>
                                            <td class=""noBottomBorder"" colspan=""2""></td>
                                            <td class=""noBottomBorder"" colspan=""5""></td>
                                            <td class=""noBottomBorder"" colspan=""2""></td>
                                          </tr>
                                          <tr>
                                            <td><b>9</b></td>
                                            <td><b>0</b></td>
                                            <td><b>2</b></td>
                                            <td><b>3</b></td>
                                            <td><b>0</b></td>
                                            <td><b>5</b></td>
                                            <td><b>0</b></td>
                                            <td></td>
                                            <td></td>
                                            <td>1</td>
                                            <td>2</td>
                                            <td>3</td>
                                            <td>4</td>
                                            <td>5</td>
                                            <td></td>
                                            <td></td>
                                          </tr>
                                        </tbody>
                                      </table>
                                    </div>
                                    <div class=""r7"">
                                      <table style=""width: 98%; margin-left: 20px"">
                                        <thead>
                                          <tr>
                                            <th rowspan=""2"">Lp.</th>
                                            <th rowspan=""2"">Nazwa materia??u</th>
                                            <th rowspan=""2"">
                                              <span class=""verticalTableHeader"">
                                                Kierunek <br />oper.przych.<br />rozch.
                                              </span>
                                            </th>
                                            <th colspan=""2"">Indeks materia??u</th>
                                            <th rowspan=""2"">J.M.</th>
                                            <th rowspan=""2"">
                                              <span class=""verticalTableHeader"">Rodz. zapas.</span>
                                            </th>
                                            <th>Zapotrze-<br />bowane materia??y</th>
                                            <th colspan=""2"">Wydano materia??y</th>
                                            <th colspan=""2"">
                                              Zu??yto<br />materia??y zgod.<br />z przeznacz.
                                            </th>
                                            <th colspan=""2"">Zwr??cono<br />materia??y<br />niewykorz.</th>
                                            <th colspan=""2"">
                                              Informacje uzupe??niaj??ce lub uwagi o<br />amunicji
                                            </th>
                                            <th rowspan=""2"">
                                              <span class=""verticalTableHeader""
                                                >Wyr????nik<br />zu??yc.</span
                                              >
                                            </th>
                                          </tr>
                                          <tr style=""height: 10px"">
                                            <td>Symbol indexu</td>
                                            <td>LK</td>
                                            <td>Ilo????</td>
                                            <td>Ilo????</td>
                                            <td>Kat</td>
                                            <td>Ilo????</td>
                                            <td>Kat</td>
                                            <td>Ilo????</td>
                                            <td>Kat</td>
                                            <td>Dane kpl.nb.</td>
                                            <td>Partia zap. rok prod. zak??</td>
                                          </tr>
                                        </thead>
                                        <tbody>
                                          <tr style=""height: 10px"">
                                            <td>1</td>
                                            <td>2</td>
                                            <td>3</td>
                                            <td>4</td>
                                            <td>5</td>
                                            <td>6</td>
                                            <td>7</td>
                                            <td>-</td>
                                            <td>8</td>
                                            <td>9</td>
                                            <td>10</td>
                                            <td>11</td>
                                            <td>12</td>
                                            <td>13</td>
                                            <td>14</td>
                                            <td>15</td>
                                            <td>16</td>
                                          </tr>", data.UnitDepartment, DateTime.Now.ToString("dd MMMM yyyy", 
                              new CultureInfo("pl-PL")), data.MainInstructor, data.EduBlockDate,
                            data.OrderNumber, data.OrderDate, data.AmmoManager);

                        if (data.Ammo.Any())
                        {
                            foreach (var item in data.Ammo)
                            {
                                  sb.AppendFormat(@"  
                                            <tr style=""height: 30px"">
                                              <td>{0}</td>
                                              <td>{1}</td>
                                              <td>{2}</td>
                                              <td>{3}</td>
                                              <td></td>
                                              <td>{4}</td>
                                              <td></td>
                                              <td><b>{5}</b></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td>{6}</td>
                                            </tr>", item.Idx, item.Name, item.OperationCode, item.AmmoIdx, item.Measure,
                                    item.Quantity, item.IdForSecondPage);
                            }
                        }
                          
                        sb.AppendFormat(@"
                                          <tr>
                                            <td
                                              colspan=""10""
                                              style=""
                                                border-left: 1px solid #fff;
                                                border-bottom: 1px solid #fff;
                                                vertical-align: initial;"">
                                              <p>
                                                <b><br />Wydanie materia????w - kolumny 2-9<br /><br /></b>
                                              </p>
                                              <p style=""text-align: left; margin-left: 50px"">
                                                <b>Razem pozycji ................... s??ownie
                                                  ................................................................................................<br /><br/></b>
                                              </p>
                                              <p style=""text-align: left; margin-left: 95px"">
                                                <span><b>Wydaj??cy materia??y</b></span>
                                                <span style=""margin-left: 200px""><b>Pobieraj??cy materia??y</b></span >
                                              </p>
                                              <p style=""text-align: left; margin-left: 400px"">
                                                {0}<br />
                                              </p>
                                              <p style=""text-align: left; margin-left: 95px"">
                                                <span><b>..................................</b></span
                                                ><span style=""margin-left: 200px""
                                                  ><b>.......................................</b></span
                                                ><br /><br />
                                              </p>
                                              <p style=""text-align: left; margin-left: 395px"">
                                                <b>Dnia ............................ 2020</b><br />
                                              </p>
                                            </td>
                                            <td
                                              colspan=""7""
                                              style=""
                                                border-right: 1px solid #fff;
                                                border-bottom: 1px solid #fff;
                                                vertical-align: initial;
                                              "">
                                              <p>
                                                <b><br />Rozliczenie zu??ytych materia????w - kolumny 10-13<br /><br/></b>
                                              </p>
                                              <p style=""margin-left: 5px"">
                                                <span><b>Razem ilo???? poz. materia????w zwr??conych</b></span>
                                                <span style=""margin-left: 20px"">
                                                  <b>.......................<br /><br /></b>
                                                </span>
                                              </p>
                                              <p style=""margin-left: 5px"">
                                                <span><b>s??ownie</b></span>
                                                <span style=""margin-left: 20px"">
                                                  <b>................................................................................<br /><br /></b>
                                                </span>
                                              </p>
                                              <p style=""text-align: left; margin-left: 30px"">
                                                <span><b>Rozliczaj??cy si?? z materia????w</b></span>
                                                <span style=""margin-left: 150px"">
                                                <b>Przyjmuj??cy rozliczenie</b></span>
                                              </p>
                                              <p style=""text-align: left; margin-left: 30px"">
                                                {1}<br />
                                              </p>
                                              <p style=""text-align: left; margin-left: 50px"">
                                                <span><b>............................................</b></span>
                                                <span style=""margin-left: 155px""><b>.......................................</b></span>
                                                <br /><br />
                                              </p>
                                              <p style=""text-align: left; margin-left: 340px"">
                                                <b>Dnia ............................ 2020</b><br />
                                              </p>
                                            </td>
                                          </tr>
                                        </tbody>
                                      </table>
                                    </div>
                                  </div>
                                </div>
                              </div>
                              <div class=""second-page"">
                                <div class=""content"">
                                    <div class=""head"">
                                      <div class=""k1"">
                                      <div class=""rr1"">
                                        <p style=""font-size: 9px;"">Z materia????w wypisanych w kolumnie 10 cz????ci R zu??yto do zabezpieczenia szkolenia bojowego na przestrzeliwanie broni na pr??by tech. materia??y wykazane ni??ej w kolumnach 8,9,10. Z ilo??ci ""szkolenie programowe"" kol.8 <br>
                                        rozliczono materia??y wg limit??w na tematy jak kol. 4-7</p>
                                      </div>
                                      <div class=""rr2"">
                                        <p style=""font-size: 14px; font-weight: bold; text-decoration: underline; text-align: center;"">CZ?????? Z</p>
                                      </div>
                                    </div>
                                      <div class=""rr3"">
                                        <table style=""width: 98%;"">
                                          <thead>
                                            <tr>
                                              <th rowspan=""2""><span class=""verticalTableHeader"">Lp. wyr????n.<br>zy??ycia kol. 16-R</span></th>
                                              <th rowspan=""2"">Nazwa zamierzenia</th>
                                              <th rowspan=""2""><span class=""verticalTableHeader"">Kierunek operacji</span></th>
                                              <th colspan=""3"">Data</th>
                                              <th colspan=""4"">Szkolenie programowe i ??wiczenia wojsk</th>
                                              <th colspan=""3"">Og??lna ilo???? oddanych strz.<br>(wybuch??w)</th>
                                              <th colspan=""2"">Ilo???? szkolonych (ilo????<br>bior??cych udzia??)</th>
                                              <th colspan=""4"">Ilo???? uzyskanych ocen</th>
                                              <th rowspan=""2""><span class=""verticalTableHeader"">Procent wykonania</span></th>
                                              <th rowspan=""2""><span class=""verticalTableHeader"">Ocena</span></th>
                                            </tr>
                                            <tr>
                                              <td><span class=""verticalTableHeader"">Dzie??</span></td>
                                              <td><span class=""verticalTableHeader"">M-C</span></td>
                                              <td><span class=""verticalTableHeader"">Rok</span></td>
                                              <td>Symb. Progr.</td>
                                              <td>Temat przed.</td>
                                              <td>??wicz. temat</td>
                                              <td>Zaj???? ??wicz.</td>
                                              <td><span class=""verticalTableHeader"">Na<br>szkol.</span></td>
                                              <td><span class=""verticalTableHeader"">Prze-<br>strzel.</span></td>
                                              <td><span class=""verticalTableHeader"">Inne<br>cele</span></td>
                                              <td><span class=""verticalTableHeader"">Podo.<br>za??ogi.ze<br>sp</span>.</td>
                                              <td><span class=""verticalTableHeader"">Indywi-<br>dualnie</span></td>
                                              <td><span class=""verticalTableHeader"">bdb</span></td>
                                              <td><span class=""verticalTableHeader"">db</span></td>
                                              <td><span class=""verticalTableHeader"">dst</span></td>
                                              <td><span class=""verticalTableHeader"">ndst</span></td>
                                            </tr>
                                          </thead>
                                          <tbody>
                                            <tr>
                                              <td>1</td>
                                              <td>2</td>
                                              <td>3</td>
                                              <td>4</td>
                                              <td>5</td>
                                              <td>6</td>
                                              <td>7</td>
                                              <td>8</td>
                                              <td>9</td>
                                              <td>10</td>
                                              <td>11</td>
                                              <td>12</td>
                                              <td>13</td>
                                              <td>14</td>
                                              <td>15</td>
                                              <td>16</td>
                                              <td>17</td>
                                              <td>18</td>
                                              <td>19</td>
                                              <td>20</td>
                                              <td>21</td>
                                            </tr>", data.AmmoManager, data.AmmoManager);
                        foreach (var item in data.Ammo)
                        {
                            sb.AppendFormat(@"                    
                                            <tr>
                                              <td>{0}</td>
                                              <td>{1}</td>
                                              <td>{2}</td>
                                              <td>{3}</td>
                                              <td>{4}</td>
                                              <td>{5}</td>
                                              <td>{6}</td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                            </tr>", item.IdForSecondPage, data.EduBlockSubject, item.OperationCode, 
                              data.Day, data.Month, data.Year, data.EduBlockSubjectCode);
                        }
                        
                        sb.AppendFormat(@"                   
                                            </tbody>
                                          </table>
                                      </div>
                                      <div class=""rr4"">
                                        <p style=""font-size: 10px;"">
                                          <span>Razem pozycji w cz????ci</span>
                                          <span style=""font-weight: bold;"">Z</span>
                                          <span style=""font-weight: bold; margin-left: 20px;"">{0}</span>
                                          <span style=""margin-left: 20px;"">s??ownie</span>
                                          <span style=""font-weight: bold; margin-left: 100px;"">.................................................</span>
                                          <br>
                                          <br>
                                        </p>
                                      </div>
                                      <div class=""k1"">
                                        <div class=""rr1"">
                                          <p style=""font-size: 9px; text-align: center;"">
                                            W zu??ytych podczas strzela?? (??wicze??) w dniach i na tematy jak wykazano w cz????ci Z zapasach amunicji i materia????w wybuchowych stwierdzono nast??puj??ce dzia??anie
                                          </p>
                                        </div>
                                        <div class=""rr2"">
                                          <p style=""font-size: 14px; font-weight: bold; text-decoration: underline; text-align: center;"">CZ?????? K</p>
                                        </div>
                                      </div>
                                      <div class=""rr3"">
                                        <table style=""width: 98%;"">
                                          <thead>
                                            <tr style=""height: 30px;"">
                                              <th rowspan=""2""><span class=""verticalTableHeader"">Lp. wyr????n.<br>zu??ycia</span></th>
                                              <th colspan=""6"">Zamunicji i materia????w wybuchowych zuzytych na zamierzenia z cz. Z by??y sk??adowane jak ni??ej</th>
                                              <th colspan=""8"">Wyniki dzia??ania amunicji podczas strzela?? szkolno bojowych i innych</th>
                                              <th rowspan=""2""></th>
                                              <th rowspan=""2""></th>
                                            </tr>
                                            <tr>
                                              <td>w sta??ym<br>magazynie</td>
                                              <td>samoch. i wozach<br>boj gara??o-mag.</td>
                                              <td>w wolnym<br> powietrzu</td>
                                              <td>na wozach<br>bojowych w<br>intens.Ekspl.</td>
                                              <td></td>
                                              <td>w innych<br> warunkach</td>
                                              <td>dzia??anie<br>prawid??.</td>
                                              <td><span class=""verticalTableHeader"">niewypa??-<br>y</span></td>
                                              <td><span class=""verticalTableHeader"">niewy-<br>buchy</span></td>
                                              <td><span class=""verticalTableHeader"">niedoloty</span></td>
                                              <td><span class=""verticalTableHeader"">zagwo-<br>??d??one</span></td>
                                              <td><span class=""verticalTableHeader"">inne</span></td>
                                              <td></td>
                                              <td>Razem suma<br>kol. 10 cz????ci<br>R</td>
                                            </tr>
                                          </thead>
                                          <tbody>
                                            <tr>
                                              <td>1</td>
                                              <td>2</td>
                                              <td>3</td>
                                              <td>4</td>
                                              <td>5</td>
                                              <td>6</td>
                                              <td>7</td>
                                              <td>8</td>
                                              <td>9</td>
                                              <td>10</td>
                                              <td>11</td>
                                              <td>12</td>
                                              <td>13</td>
                                              <td>14</td>
                                              <td>15</td>
                                              <td>16</td>
                                              <td>17</td>
                                            </tr>", data.Ammo.Count);
                        
                        foreach (var item in data.Ammo)
                        {
                            sb.AppendFormat(@"                    
                                            <tr>
                                              <td>{0}</td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                              <td></td>
                                            </tr>", item.IdForSecondPage);
                        }
                       
                        
                        sb.AppendFormat(@"                  
                                            </tbody>
                                          </table>
                                      </div>
                                      <div class=""k1"">
                                        <div class=""kk1"">
                                          Strzelaj??cy <br><br>
                                          {0}
                                        </div>
                                        <div class=""kk1"">
                                          Kierownik strzelania (??wiczenia)<br><br>
                                          {1}
                                        </div>
                                        <div class=""kk1"">
                                          Dow??dca pododdzia??u<br><br>
                                          ........................................
                                        </div>
                                        <div class=""kk1"">
                                          <br><br>
                                          <p style=""text-align: right;"">
                                            <span>Dnia</span><span style="" margin-left: 25px;"">...................</span>
                                            <span style=""margin-left: 25px;"">2020</span>
                                          </p>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                            </body>
                          </html>", data.UnitDepartment, data.ShootingInstructor);
             
             return sb.ToString();
         }
    }
}