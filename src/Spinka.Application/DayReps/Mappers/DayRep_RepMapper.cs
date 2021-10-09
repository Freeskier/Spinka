using System;
using System.Collections.Generic;
using Spinka.Application.DayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using System.Linq;
using Spinka.Application.Utils.Helpers;

namespace Spinka.Application.DayReps.Mappers
{
    public class DayRep_RepMapper: IMapper<DayRep_RepDBRequest,List<DayRep_RepViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DayRep_RepMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public List<DayRep_RepViewModel> MapObject(DayRep_RepDBRequest entity)
        {

            List<int?> kurs = new List<int?>() { 7, 8, 9, 10 };
            List<int?> zlSzpital = new List<int?>() { 5, 31 };
            List<int?> kBw = new List<int?>() { 6 };
            List<int?> urlop = new List<int?>() { 2 };
            List<int?> ps = new List<int?>() { 4, 14 };
            List<int?> poligon = new List<int?>() { 11, 12, 13 };
            List<int?> pkw = new List<int?>() { 18 };
            List<int?> ksSps = new List<int?>() { 10, 29 };
            List<int?> odkom = new List<int?>() { 24 };
            List<int?> sluzba = new List<int?>() { 25, 30 };
            List<int?> suchy = new List<int?>() { 28 };
            List<int?> sto = new List<int?>() { 3, 20 };
            List<int?> natura = new List<int?>() { 15 };
            List<int?> sfDOz = new List<int?>() { 1, 16, 17, 19, 26 };
            List<int?> sDOwyz = new List<int?>() { 1, 16, 17, 19, 26, 25, 30 };
            List<int?> not32 = new List<int?>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 33 };
            List<int?> odkomAll = new List<int?>() { 7, 8, 9, 24 };
            List<int?> natB = new List<int?>() { 15, 16, 33 };
            List<int?> procent40 = new List<int?>() { 1, 17, 19, 26 };
            List<int?> procent20 = new List<int?>() { 1, 17, 26 };
            List<int?> procent30 = new List<int?>() { 19 };
            List<int?> procent150110 = new List<int?>() { 13, 26 };
            List<int?> woda = new List<int?>() { 1, 3, 10, 11, 12, 13, 15, 16, 17, 19, 20, 25, 26, 28, 29, 30 };
            List<int?> kursKO = new List<int?>() { 7 };
            List<int?> psz = new List<int?>() { 14 };
            List<int?> urlZwSzp = new List<int?>() { 2, 5, 31 };
            List<int?> pS = new List<int?>() { 4 };
            List<int?> rown020 = new List<int?>() { 3, 10, 29 };
            List<int?> rown030 = new List<int?>() { 20 };
            List<int?> p4 = new List<int?>() { 11 };
            List<int?> p8 = new List<int?>() { 12 };
            List<int?> wodapC = new List<int?>() { 22, 23 };
            List<int?> pp = new List<int?>() { 23 };
            List<int?> dog = new List<int?>() { 27 };
            List<int> lewaTyl = new List<int>() { 1, 3, 10, 11, 12, 13, 15, 16, 17, 19, 20, 22, 23, 25, 26, 27, 28, 29, 30, 33 };
            List<int> prawaTyl = new List<int>() { 2, 4, 5, 6, 7, 8, 9, 14, 18, 21, 24, 31, 32 };
            DateTime startDate = entity.StartDate;
            DateTime endDate = entity.EndDate;
            int groupId = entity.GroupID;
            byte numberOfDays = Convert.ToByte((endDate - startDate).TotalDays);
            var groupDetails = _unitOfWork.Repository<GroupForDayRep>()
                    .FindByIdAsync(groupId)
                    .GetAwaiter()
                    .GetResult();
            var personnelInGroup = _unitOfWork.Repository<DayRepGroupPerson>()
                .FindAllAsync(x => x.GroupForDayRepId == groupId && x.IsDeleted==false)
                .GetAwaiter()
                .GetResult().ToList();
       
            List<DayRep_RepViewModel> viewModelPrinting = new List<DayRep_RepViewModel>();
            var dayRep_RepDBReturnGroup = new DayRep_RepDBReturnGroup();
            DayRep_RepDBReturnSingle dayRepTableDataForGroupDay = new DayRep_RepDBReturnSingle();
         DayRep_RepViewModel empty = new DayRep_RepViewModel();
            for (byte i=0; i < numberOfDays+1; i++)
            {
                DayRep_RepViewModel singleMod = new DayRep_RepViewModel();
                List<DayRep_RepDBReturnSingle> ListOfDayRepTableForGroupDay = new List<DayRep_RepDBReturnSingle>();

                DateTime currDay = startDate.AddDays(i);
                DateTime prevDay = startDate.AddDays(i-1);

                singleMod.Day = currDay;
                singleMod.GroupName = groupDetails.Name;
                singleMod.GeneratedBy = MapperHelper.HelpWithGetPersonFullName(entity.FullNameRenderingPersonId, _unitOfWork);
                singleMod.SignedBy = MapperHelper.HelpWithGetPersonFullName(entity.FullNameSigningPersonId, _unitOfWork);

                foreach(var per in personnelInGroup)
                {
                    int? cur = null;
                    int? prev = null;
                    if(_unitOfWork.Repository<DayRep>().FindByAsync(x => x.Day.Date == currDay.Date && x.DayRepGroupPersonId == per.Id).GetAwaiter().GetResult() == null)
                        {
                        cur = null;
                        }
                    else
                        {
                             cur = _unitOfWork.Repository<DayRep>()
                        .FindByAsync(x => x.Day.Date == currDay.Date  && x.DayRepGroupPersonId == per.Id)
                        .GetAwaiter()
                        .GetResult().DayRepAcronymId;
                        }
                    if (_unitOfWork.Repository<DayRep>().FindByAsync(x => x.Day.Date == prevDay.Date && x.DayRepGroupPersonId == per.Id).GetAwaiter().GetResult() == null)
                        {
                        prev = null;
                        }
                    else
                        {
                        prev = _unitOfWork.Repository<DayRep>()
                       .FindByAsync(x => x.Day.Date == prevDay.Date  && x.DayRepGroupPersonId == per.Id)
                       .GetAwaiter()
                       .GetResult().DayRepAcronymId;
                        }

                    ListOfDayRepTableForGroupDay.Add(new DayRep_RepDBReturnSingle()
                    {
                        PersonInGroupID = per.PersonId,
                        Corpus = MapperHelper.HelpWithGetPersonCorpus(per.PersonId, _unitOfWork),
                        OpNumber = MapperHelper.HelpWithOpNo(per.PersonId, _unitOfWork),
                        fullName = MapperHelper.HelpWithGetPersonFullName(per.PersonId, _unitOfWork),
                        IsDelegated = per.IsDelegated,
                        CurrentDayRepAcrID = cur,
                        PrevDayRepAcrID = prev
                    });
                   
                    
                   
                    

                   // ListOfDayRepTableForGroupDay.Add(dayRepTableDataForGroupDay);
                    //dayRepTableDataForGroupDay = null;

                }
                //stOfDayRepTableForGroupDay = ListOfDayRepTableForGroupDay;
              
                


                //stan na dzień pierwsze 4
                //(List<DayRep_RepDBReturnSingle> model , string corpus, List<int?> listOfvar ,bool delegated, bool CurrentDay )
                singleMod.A1_2 =  DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o",not32,  false,false);
                singleMod.A1_8 =  DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", not32, false, false);
                singleMod.A1_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", not32, false, false);
                singleMod.A1_14 = singleMod.A1_2 + singleMod.A1_8+ singleMod.A1_11;
                singleMod.A1_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", not32, false, false);
                singleMod.A1_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", not32, true, false);
                singleMod.A1_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", not32, true, false);
                singleMod.A1_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", not32, true, false); 
                singleMod.A1_27 = singleMod.A1_16 + singleMod.A1_21 + singleMod.A1_24;

                singleMod.A4_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o",not32,  false, true);
                singleMod.A4_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", not32, false, true);
                singleMod.A4_11 =DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", not32, false, true);
                singleMod.A4_14 = singleMod.A4_2 + singleMod.A4_8 + singleMod.A4_11;       
                singleMod.A4_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", not32, false, true);
                singleMod.A4_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", not32, true, true);
                singleMod.A4_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", not32, true, true);
                singleMod.A4_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", not32, true, true);
                singleMod.A4_27 = singleMod.A4_16 + singleMod.A4_21 + singleMod.A4_24;

                singleMod.A3_2 = singleMod.A1_2 - singleMod.A4_2 > 0 ? singleMod.A1_2 - singleMod.A4_2 : 0;
                singleMod.A3_8 = singleMod.A1_8 - singleMod.A4_8 > 0 ? singleMod.A1_8 - singleMod.A4_8 : 0;
                singleMod.A3_11 = singleMod.A1_11 - singleMod.A4_11 > 0 ? singleMod.A1_11 - singleMod.A4_11 : 0;
                singleMod.A3_14 = singleMod.A3_2 + singleMod.A3_8 + singleMod.A3_11;
                singleMod.A3_15 = singleMod.A1_15 - singleMod.A4_15 > 0 ? singleMod.A1_15 - singleMod.A4_15 : 0;
                singleMod.A3_16 = singleMod.A1_16 - singleMod.A4_16 > 0 ? singleMod.A1_16 - singleMod.A4_16 : 0; 
                singleMod.A3_21 = singleMod.A1_21 - singleMod.A4_21 > 0 ? singleMod.A1_21 - singleMod.A4_21 : 0;
                singleMod.A3_24 = singleMod.A1_24 - singleMod.A4_24 > 0 ? singleMod.A1_24 - singleMod.A4_24 : 0;
                singleMod.A3_27 = singleMod.A3_16 + singleMod.A3_21 + singleMod.A3_24;

                singleMod.A2_2 = singleMod.A4_2 - singleMod.A1_2 > 0 ? singleMod.A4_2 - singleMod.A1_2 : 0;
                singleMod.A2_8 = singleMod.A4_8 - singleMod.A1_8 > 0 ? singleMod.A4_8 - singleMod.A1_8 : 0;
                singleMod.A2_11 = singleMod.A4_11 - singleMod.A1_11 > 0 ? singleMod.A4_11 - singleMod.A1_11 : 0;
                singleMod.A2_15 = singleMod.A4_15 - singleMod.A1_15 > 0 ? singleMod.A4_15 - singleMod.A1_15 : 0;
                singleMod.A2_16 = singleMod.A4_16 - singleMod.A1_16 > 0 ? singleMod.A4_16 - singleMod.A1_16 : 0;
                singleMod.A2_21 = singleMod.A4_21 - singleMod.A1_21 > 0 ? singleMod.A4_21 - singleMod.A1_21 : 0;
                singleMod.A2_24 = singleMod.A4_24 - singleMod.A1_24 > 0 ? singleMod.A4_24 - singleMod.A1_24 : 0;
                singleMod.A2_27 = singleMod.A2_16 + singleMod.A2_21 + singleMod.A2_24;
                singleMod.A2_14 = singleMod.A2_2 + singleMod.A2_8 + singleMod.A2_11;
                //inne kurs
                singleMod.A6_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", kurs, false, true);
                singleMod.A6_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", kurs, false, true);
                singleMod.A6_11 =DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", kurs, false, true);
                singleMod.A6_15 =DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", kurs, false, true);
                singleMod.A6_16 =DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", kurs, true, true);
                singleMod.A6_21 =DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", kurs, true, true);
                singleMod.A6_24 =DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", kurs, true, true);

                singleMod.A6_14 = singleMod.A6_2 + singleMod.A6_8 + singleMod.A6_11;
                singleMod.A6_27 = singleMod.A6_16 + singleMod.A6_21 + singleMod.A6_24;
                //inne ZL Szpital
                singleMod.A7_2 =  DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", zlSzpital, false, true);
                singleMod.A7_8 =  DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", zlSzpital, false, true);
                singleMod.A7_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", zlSzpital, false, true);
                singleMod.A7_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", zlSzpital, false, true);
                singleMod.A7_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", zlSzpital, true, true);
                singleMod.A7_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", zlSzpital, true, true);
                singleMod.A7_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", zlSzpital, true, true);

                singleMod.A7_14 = singleMod.A7_2 + singleMod.A7_8 + singleMod.A7_11;
                singleMod.A7_27 = singleMod.A7_16 + singleMod.A7_21 + singleMod.A7_24;
                //inne KBW
                singleMod.A8_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o",  kBw, false, true);
                singleMod.A8_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p",  kBw, false, true);
                singleMod.A8_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", kBw, false, true);
                singleMod.A8_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", kBw, false, true);
                singleMod.A8_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", kBw, true, true);
                singleMod.A8_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", kBw, true, true);
                singleMod.A8_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", kBw, true, true);

                singleMod.A8_14 = singleMod.A8_2 + singleMod.A8_8 + singleMod.A8_11;
                singleMod.A8_27 = singleMod.A8_16 + singleMod.A8_21 + singleMod.A8_24;

                //inne Urlop
                singleMod.A9_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o",  urlop, false, true);
                singleMod.A9_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p",  urlop, false, true);
                singleMod.A9_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", urlop, false, true);
                singleMod.A9_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", urlop, false, true);
                singleMod.A9_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", urlop, true, true);
                singleMod.A9_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", urlop, true, true);
                singleMod.A9_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", urlop, true, true);

                singleMod.A9_14 = singleMod.A9_2 + singleMod.A9_8 + singleMod.A9_11;
                singleMod.A9_27 = singleMod.A9_16 + singleMod.A9_21 + singleMod.A9_24;

                //inne PS
                singleMod.A10_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", ps, false, true);
                singleMod.A10_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", ps, false, true);
                singleMod.A10_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", ps, false, true);
                singleMod.A10_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", ps, false, true);
                singleMod.A10_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", ps, true, true);
                singleMod.A10_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", ps, true, true);
                singleMod.A10_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", ps, true, true);

                singleMod.A10_14 = singleMod.A10_2 + singleMod.A10_8 + singleMod.A10_11;
                singleMod.A10_27 = singleMod.A10_16 + singleMod.A10_21 + singleMod.A10_24;
                //inne Poligon
                singleMod.A11_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", poligon, false, true);
                singleMod.A11_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", poligon, false, true);
                singleMod.A11_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", poligon, false, true);
                singleMod.A11_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", poligon, false, true);
                singleMod.A11_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", poligon, true, true);
                singleMod.A11_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", poligon, true, true);
                singleMod.A11_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", poligon, true, true);

                singleMod.A11_14 = singleMod.A11_2 + singleMod.A11_8 + singleMod.A11_11;
                singleMod.A11_27 = singleMod.A11_16 + singleMod.A11_21 + singleMod.A11_24;

                //inne PKW
                singleMod.A12_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", pkw, false, true);
                singleMod.A12_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", pkw, false, true);
                singleMod.A12_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", pkw, false, true);
                singleMod.A12_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", pkw, false, true);
                singleMod.A12_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", pkw, true, true);
                singleMod.A12_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", pkw, true, true);
                singleMod.A12_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", pkw, true, true);

                singleMod.A12_14 = singleMod.A12_2 + singleMod.A12_8 + singleMod.A12_11;
                singleMod.A12_27 = singleMod.A12_16 + singleMod.A12_21 + singleMod.A12_24;

                //inne kurs
                singleMod.A13_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", ksSps, false, true);
                singleMod.A13_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", ksSps, false, true);
                singleMod.A13_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", ksSps, false, true);
                singleMod.A13_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", ksSps, false, true);
                singleMod.A13_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", ksSps, true, true);
                singleMod.A13_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", ksSps, true, true);
                singleMod.A13_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", ksSps, true, true);

                singleMod.A13_14 = singleMod.A13_2 + singleMod.A13_8 + singleMod.A13_11;
                singleMod.A13_27 = singleMod.A13_16 + singleMod.A13_21 + singleMod.A13_24;

                //inne odkomenderowany
                singleMod.A14_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", odkom, false, true);
                singleMod.A14_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", odkom, false, true);
                singleMod.A14_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", odkom, false, true);
                singleMod.A14_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", odkom, false, true);
                singleMod.A14_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", odkom, true, true);
                singleMod.A14_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", odkom, true, true);
                singleMod.A14_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", odkom, true, true);

                singleMod.A14_14 = singleMod.A14_2 + singleMod.A14_8 + singleMod.A14_11;
                singleMod.A14_27 = singleMod.A14_16 + singleMod.A14_21 + singleMod.A14_24;

                //inne służba
                singleMod.A15_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", sluzba, false, true);
                singleMod.A15_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", sluzba, false, true);
                singleMod.A15_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", sluzba, false, true);
                singleMod.A15_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", sluzba, false, true);
                singleMod.A15_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", sluzba, true, true);
                singleMod.A15_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", sluzba, true, true);
                singleMod.A15_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", sluzba, true, true);

                singleMod.A15_14 = singleMod.A15_2 + singleMod.A15_8 + singleMod.A15_11;
                singleMod.A15_27 = singleMod.A15_16 + singleMod.A15_21 + singleMod.A15_24;

                //inne suchy
                singleMod.A16_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", suchy, false, true);
                singleMod.A16_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", suchy, false, true);
                singleMod.A16_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", suchy, false, true);
                singleMod.A16_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", suchy, false, true);
                singleMod.A16_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", suchy, true, true);
                singleMod.A16_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", suchy, true, true);
                singleMod.A16_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", suchy, true, true);

                singleMod.A16_14 = singleMod.A16_2 + singleMod.A16_8 + singleMod.A16_11;
                singleMod.A16_27 = singleMod.A16_16 + singleMod.A16_21 + singleMod.A16_24;

                //inne 020 100%
                singleMod.A17_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", sto, false, true);
                singleMod.A17_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", sto, false, true);
                singleMod.A17_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", sto, false, true);
                singleMod.A17_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", sto, false, true);
                singleMod.A17_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", sto, true, true);
                singleMod.A17_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", sto, true, true);
                singleMod.A17_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", sto, true, true);

                singleMod.A17_14 = singleMod.A17_2 + singleMod.A17_8 + singleMod.A17_11;
                singleMod.A17_27 = singleMod.A17_16 + singleMod.A17_21 + singleMod.A17_24;

                //inne natura
                singleMod.A18_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", natura, false, true);
                singleMod.A18_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", natura, false, true);
                singleMod.A18_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", natura, false, true);
                singleMod.A18_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", natura, false, true);
                singleMod.A18_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", natura, true, true);
                singleMod.A18_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", natura, true, true);
                singleMod.A18_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", natura, true, true);

                singleMod.A18_14 = singleMod.A18_2 + singleMod.A18_8 + singleMod.A18_11;
                singleMod.A18_27 = singleMod.A18_16 + singleMod.A18_21 + singleMod.A18_24;

                //Razem

                singleMod.A19_2 = singleMod.A6_2 + singleMod.A7_2 + singleMod.A8_2 + singleMod.A9_2 + singleMod.A10_2 + singleMod.A11_2 + singleMod.A12_2 + singleMod.A13_2
                               + singleMod.A14_2 + singleMod.A15_2 + singleMod.A16_2 + singleMod.A17_2 + singleMod.A18_2;
                singleMod.A19_8 = singleMod.A6_8 + singleMod.A7_8 + singleMod.A8_8 + singleMod.A9_8 + singleMod.A10_8 + singleMod.A11_8 + singleMod.A12_8 + singleMod.A13_8
                               + singleMod.A14_8 + singleMod.A15_8 + singleMod.A16_8 + singleMod.A17_8 + singleMod.A18_8;
                singleMod.A19_11 = singleMod.A6_11 + singleMod.A7_11 + singleMod.A8_11 + singleMod.A9_11 + singleMod.A10_11 + singleMod.A11_11 + singleMod.A12_11 + singleMod.A13_11
                               + singleMod.A14_11 + singleMod.A15_11 + singleMod.A16_11 + singleMod.A17_11 + singleMod.A18_11;
                singleMod.A19_14 = singleMod.A6_14 + singleMod.A7_14 + singleMod.A8_14 + singleMod.A9_14 + singleMod.A10_14 + singleMod.A11_14 + singleMod.A12_14 + singleMod.A13_14
                               + singleMod.A14_14 + singleMod.A15_14 + singleMod.A16_14 + singleMod.A17_14 + singleMod.A18_14;
                singleMod.A19_16 = singleMod.A6_16 + singleMod.A7_16 + singleMod.A8_16 + singleMod.A9_16 + singleMod.A10_16 + singleMod.A11_16 + singleMod.A12_16 + singleMod.A13_16
                               + singleMod.A14_16 + singleMod.A15_16 + singleMod.A16_16 + singleMod.A17_16 + singleMod.A18_16;
                singleMod.A19_21 = singleMod.A6_21 + singleMod.A7_21 + singleMod.A8_21 + singleMod.A9_21 + singleMod.A10_21 + singleMod.A11_21 + singleMod.A12_21 + singleMod.A13_21
                               + singleMod.A14_21 + singleMod.A15_21 + singleMod.A16_21 + singleMod.A17_21 + singleMod.A18_21;
                singleMod.A19_24 = singleMod.A6_24 + singleMod.A7_24 + singleMod.A8_24 + singleMod.A9_24 + singleMod.A10_24 + singleMod.A11_24 + singleMod.A12_24 + singleMod.A13_24
                               + singleMod.A14_24 + singleMod.A15_24 + singleMod.A16_24 + singleMod.A17_24 + singleMod.A18_24;
                singleMod.A19_27 = singleMod.A6_27 + singleMod.A7_27 + singleMod.A8_27 + singleMod.A9_27 + singleMod.A10_27 + singleMod.A11_27 + singleMod.A12_27 + singleMod.A13_27
                               + singleMod.A14_27 + singleMod.A15_27 + singleMod.A16_27 + singleMod.A17_27 + singleMod.A18_27;

                //Do zajęć
              
                singleMod.A20_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", sfDOz, false, true);
                singleMod.A20_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", sfDOz, false, true);
                singleMod.A20_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", sfDOz, false, true);
                singleMod.A20_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", sfDOz, false, true);
                singleMod.A20_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", sfDOz, true, true);
                singleMod.A20_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", sfDOz, true, true);
                singleMod.A20_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", sfDOz, true, true);

                singleMod.A20_14 = singleMod.A20_2 + singleMod.A20_8 + singleMod.A20_11;
                singleMod.A20_27 = singleMod.A20_16 + singleMod.A20_21 + singleMod.A20_24;

                //inne stan wyżywienia
                singleMod.A21_2 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", sDOwyz, false, true);
                singleMod.A21_8 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", sDOwyz, false, true);
                singleMod.A21_11 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", sDOwyz, false, true);
                singleMod.A21_15 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", sDOwyz, false, true);
                singleMod.A21_16 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "o", sDOwyz, true, true);
                singleMod.A21_21 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "p", sDOwyz, true, true);
                singleMod.A21_24 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "s", sDOwyz, true, true);

                singleMod.A21_14 = singleMod.A21_2 + singleMod.A21_8 + singleMod.A21_11;
                singleMod.A21_27 = singleMod.A21_16 + singleMod.A21_21 + singleMod.A21_24;


                // Strona B ==============================================================
                singleMod.B1_28 = singleMod.A1_14;
                singleMod.B2_28 = singleMod.A2_14;
                singleMod.B3_28 = singleMod.A3_14;
                singleMod.B4_28 = singleMod.A4_14;

                singleMod.B1_29 = singleMod.A1_27;
                singleMod.B2_29 = singleMod.A2_27;
                singleMod.B3_29 = singleMod.A3_27;
                singleMod.B4_29 = singleMod.A4_27;

                singleMod.B1_30 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", odkomAll, false,false) ;
                singleMod.B4_30 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", odkomAll, false, true);
                singleMod.B2_30 = singleMod.B4_30 - singleMod.B1_30 > 0 ? singleMod.B4_30 - singleMod.B1_30 : 0; 
                singleMod.B3_30 = singleMod.B1_30 - singleMod.B4_30 > 0 ? singleMod.B1_30 - singleMod.B4_30 : 0;

                singleMod.B1_31 = singleMod.B1_28 + singleMod.B1_29 + singleMod.B1_30;
                singleMod.B4_31 = singleMod.B4_28 + singleMod.B4_29 + singleMod.B4_30;
                singleMod.B2_31 = singleMod.B2_28 + singleMod.B2_29 + singleMod.B2_30;
                singleMod.B3_31 = singleMod.B3_28 + singleMod.B3_29 + singleMod.B3_30;

                singleMod.B1_32 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", natura, false, false);
                singleMod.B4_32 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", natura, false, true);
                singleMod.B2_32 = singleMod.B4_32 - singleMod.B1_32 > 0 ? singleMod.B4_32 - singleMod.B1_32 : 0;
                singleMod.B3_32 = singleMod.B1_32 - singleMod.B4_32 > 0 ? singleMod.B1_32 - singleMod.B4_32 : 0;

                singleMod.B1_33 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", sluzba, false, false);
                singleMod.B4_33 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", sluzba, false, true);
                singleMod.B2_33 = singleMod.B4_33 - singleMod.B1_33 > 0 ? singleMod.B4_33 - singleMod.B1_33 : 0;
                singleMod.B3_33 = singleMod.B1_33 - singleMod.B4_33 > 0 ? singleMod.B1_33 - singleMod.B4_33 : 0;

                singleMod.B1_34 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", suchy, false, false);
                singleMod.B4_34 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", suchy, false, true);
                singleMod.B2_34 = singleMod.B4_34 - singleMod.B1_34 > 0 ? singleMod.B4_34 - singleMod.B1_34 : 0;
                singleMod.B3_34 = singleMod.B1_34 - singleMod.B4_34 > 0 ? singleMod.B1_34 - singleMod.B4_34 : 0;

                singleMod.B1_35 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent40, false, false);
                singleMod.B4_35 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent40, false, true);
                singleMod.B2_35 = singleMod.B4_35 - singleMod.B1_35 > 0 ? singleMod.B4_35 - singleMod.B1_35 : 0;
                singleMod.B3_35 = singleMod.B1_35 - singleMod.B4_35 > 0 ? singleMod.B1_35 - singleMod.B4_35 : 0;

                singleMod.B1_36 = singleMod.B1_32 + singleMod.B1_33 + singleMod.B1_34 + singleMod.B1_35;
                singleMod.B4_36 = singleMod.B4_32 + singleMod.B4_33 + singleMod.B4_34 + singleMod.B4_35;
                singleMod.B2_36 = singleMod.B2_32 + singleMod.B2_33 + singleMod.B2_34 + singleMod.B2_35;
                singleMod.B3_36 = singleMod.B3_32 + singleMod.B3_33 + singleMod.B3_34 + singleMod.B3_35;

                singleMod.B1_37 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", poligon, false, false);
                singleMod.B4_37 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", poligon, false, true);
                singleMod.B2_37 = singleMod.B4_37 - singleMod.B1_37 > 0 ? singleMod.B4_37 - singleMod.B1_37 : 0;
                singleMod.B3_37 = singleMod.B1_37 - singleMod.B4_37 > 0 ? singleMod.B1_37 - singleMod.B4_37 : 0;

                singleMod.B1_38 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", kursKO, false, false);
                singleMod.B4_38 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", kursKO, false, true);
                singleMod.B2_38 = singleMod.B4_38 - singleMod.B1_38 > 0 ? singleMod.B4_38 - singleMod.B1_38 : 0;
                singleMod.B3_38 = singleMod.B1_38 - singleMod.B4_38 > 0 ? singleMod.B1_38 - singleMod.B4_38 : 0;

                singleMod.B1_39 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", psz, false, false);
                singleMod.B4_39 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", psz, false, true);
                singleMod.B2_39 = singleMod.B4_39 - singleMod.B1_39 > 0 ? singleMod.B4_39 - singleMod.B1_39 : 0;
                singleMod.B3_39 = singleMod.B1_39 - singleMod.B4_39 > 0 ? singleMod.B1_39 - singleMod.B4_39 : 0;

                singleMod.B1_40 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", urlZwSzp, false, false);
                singleMod.B4_40 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", urlZwSzp, false, true);
                singleMod.B2_40 = singleMod.B4_40 - singleMod.B1_40 > 0 ? singleMod.B4_40 - singleMod.B1_40 : 0;
                singleMod.B3_40 = singleMod.B1_40 - singleMod.B4_40 > 0 ? singleMod.B1_40 - singleMod.B4_40 : 0;

                singleMod.B1_41 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", pS, false, false);
                singleMod.B4_41 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", pS, false, true);
                singleMod.B2_41 = singleMod.B4_41 - singleMod.B1_41 > 0 ? singleMod.B4_41 - singleMod.B1_41 : 0;
                singleMod.B3_41 = singleMod.B1_41 - singleMod.B4_41 > 0 ? singleMod.B1_41 - singleMod.B4_41 : 0;

                singleMod.B1_42 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", pkw, false, false);
                singleMod.B4_42 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", pkw, false, true);
                singleMod.B2_42 = singleMod.B4_42 - singleMod.B1_42 > 0 ? singleMod.B4_42 - singleMod.B1_42 : 0;
                singleMod.B3_42 = singleMod.B1_42 - singleMod.B4_42 > 0 ? singleMod.B1_42 - singleMod.B4_42 : 0;

                singleMod.B1_43 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", rown020, false, false);
                singleMod.B4_43 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", rown020, false, true);
                singleMod.B2_43 = singleMod.B4_43 - singleMod.B1_43 > 0 ? singleMod.B4_43 - singleMod.B1_43 : 0;
                singleMod.B3_43 = singleMod.B1_43 - singleMod.B4_43 > 0 ? singleMod.B1_43 - singleMod.B4_43 : 0;


                singleMod.B1_44 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", rown030, false, false);
                singleMod.B4_44 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", rown030, false, true);
                singleMod.B2_44 = singleMod.B4_44 - singleMod.B1_44 > 0 ? singleMod.B4_44 - singleMod.B1_44 : 0;
                singleMod.B3_44 = singleMod.B1_44 - singleMod.B4_44 > 0 ? singleMod.B1_44 - singleMod.B4_44 : 0;

                singleMod.B1_45 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", kBw, false, false);
                singleMod.B4_45 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", kBw, false, true);
                singleMod.B2_45 = singleMod.B4_45 - singleMod.B1_45 > 0 ? singleMod.B4_45 - singleMod.B1_45 : 0;
                singleMod.B3_45 = singleMod.B1_45 - singleMod.B4_45 > 0 ? singleMod.B1_45 - singleMod.B4_45 : 0;

                singleMod.B1_46 = singleMod.B1_37 + singleMod.B1_38 + singleMod.B1_39 + singleMod.B1_40+ singleMod.B1_41 + singleMod.B1_42 + singleMod.B1_43 + singleMod.B1_44 + singleMod.B1_45;
                singleMod.B4_46 = singleMod.B4_37 + singleMod.B4_38 + singleMod.B4_39 + singleMod.B4_40 + singleMod.B4_41 + singleMod.B4_42 + singleMod.B4_43 + singleMod.B4_44 + singleMod.B4_45;
                singleMod.B2_46 = singleMod.B2_37 + singleMod.B2_38 + singleMod.B2_39 + singleMod.B2_40 + singleMod.B2_41 + singleMod.B2_42 + singleMod.B2_43 + singleMod.B2_44 + singleMod.B2_45;
                singleMod.B3_46 = singleMod.B3_37 + singleMod.B3_38 + singleMod.B3_39 + singleMod.B3_40 + singleMod.B3_41 + singleMod.B3_42 + singleMod.B3_43 + singleMod.B3_44 + singleMod.B3_45;

                singleMod.B1_47 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent20, false, false);
                singleMod.B4_47 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent20, false, true);
                singleMod.B2_47 = singleMod.B4_47 - singleMod.B1_47 > 0 ? singleMod.B4_47 - singleMod.B1_47 : 0;
                singleMod.B3_47 = singleMod.B1_47 - singleMod.B4_47 > 0 ? singleMod.B1_47 - singleMod.B4_47 : 0;


                singleMod.B1_48 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent30, false, false);
                singleMod.B4_48 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent30, false, true);
                singleMod.B2_48 = singleMod.B4_48 - singleMod.B1_48 > 0 ? singleMod.B4_48 - singleMod.B1_48 : 0;
                singleMod.B3_48 = singleMod.B1_48 - singleMod.B4_48 > 0 ? singleMod.B1_48 - singleMod.B4_48 : 0;

                singleMod.B1_48 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent30, false, false);
                singleMod.B4_48 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent30, false, true);
                singleMod.B2_48 = singleMod.B4_48 - singleMod.B1_48 > 0 ? singleMod.B4_48 - singleMod.B1_48 : 0;
                singleMod.B3_48 = singleMod.B1_48 - singleMod.B4_48 > 0 ? singleMod.B1_48 - singleMod.B4_48 : 0;


                singleMod.B1_49 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", p4, false, false);
                singleMod.B4_49 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", p4, false, true);
                singleMod.B2_49 = singleMod.B4_49 - singleMod.B1_49 > 0 ? singleMod.B4_49 - singleMod.B1_49 : 0;
                singleMod.B3_49 = singleMod.B1_49 - singleMod.B4_49 > 0 ? singleMod.B1_49 - singleMod.B4_49 : 0;

                singleMod.B1_50 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", p8, false, false);
                singleMod.B4_50 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", p8, false, true);
                singleMod.B2_50 = singleMod.B4_50 - singleMod.B1_50 > 0 ? singleMod.B4_50 - singleMod.B1_50 : 0;
                singleMod.B3_50 = singleMod.B1_50 - singleMod.B4_50 > 0 ? singleMod.B1_50 - singleMod.B4_50 : 0;

                singleMod.B1_51 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent150110, false, false );
                singleMod.B4_51 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", procent150110, false, true);
                singleMod.B2_51 = singleMod.B4_51 - singleMod.B1_51 > 0 ? singleMod.B4_51 - singleMod.B1_51 : 0;
                singleMod.B3_51 = singleMod.B1_51 - singleMod.B4_51 > 0 ? singleMod.B1_51 - singleMod.B4_51 : 0;

                singleMod.B1_52 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", woda, false, false);
                singleMod.B4_52 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "*", woda, false, true);
                singleMod.B2_52 = singleMod.B4_52 - singleMod.B1_52 > 0 ? singleMod.B4_52 - singleMod.B1_52 : 0;
                singleMod.B3_52 = singleMod.B1_52 - singleMod.B4_52 > 0 ? singleMod.B1_52 - singleMod.B4_52 : 0;

                singleMod.B1_53 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", wodapC, false, true);
                singleMod.B4_53 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", wodapC, false, false);
                singleMod.B2_53 = singleMod.B4_53 - singleMod.B1_53 > 0 ? singleMod.B4_53 - singleMod.B1_53 : 0;
                singleMod.B3_53 = singleMod.B1_53 - singleMod.B4_53 > 0 ? singleMod.B1_53 - singleMod.B4_53 : 0;

                singleMod.B1_54 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", pp, false, false);
                singleMod.B4_54 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "c", pp, false, true);
                singleMod.B2_54 = singleMod.B4_54 - singleMod.B1_54 > 0 ? singleMod.B4_54 - singleMod.B1_54 : 0;
                singleMod.B3_54 = singleMod.B1_54 - singleMod.B4_54 > 0 ? singleMod.B1_54 - singleMod.B4_54 : 0;

                singleMod.B1_55 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "d", dog, false, false);
                singleMod.B4_55 = DayRepHelper.Count(ListOfDayRepTableForGroupDay, "d", dog, false, true);
                singleMod.B2_55 = singleMod.B4_55 - singleMod.B1_55 > 0 ? singleMod.B4_55 - singleMod.B1_55 : 0;
                singleMod.B3_55 = singleMod.B1_55 - singleMod.B4_55 > 0 ? singleMod.B1_55 - singleMod.B4_55 : 0;

                

                foreach (var a in lewaTyl)
                {
                    if (ListOfDayRepTableForGroupDay.Select(x => x.CurrentDayRepAcrID).Contains(a))
                    {
                        singleMod.BackGains.Add(new DayRep_RepBackGainLoss {
                            DayRepAccr = _unitOfWork.Repository<DayRepAcronym>()
                                .FindByIdAsync(a)
                                .GetAwaiter()
                                .GetResult()
                                .Description,
                            ListOpNo = ListOfDayRepTableForGroupDay.Where(x => x.CurrentDayRepAcrID == a).Select(x => x.OpNumber).ToList()
                        }); 

                    }



                }
                foreach (var a in prawaTyl)
                {
                    if (ListOfDayRepTableForGroupDay.Select(x => x.CurrentDayRepAcrID).Contains(a))
                    {
                        singleMod.BackLoss.Add(new DayRep_RepBackGainLoss
                        {
                            DayRepAccr = _unitOfWork.Repository<DayRepAcronym>()
                                   .FindByIdAsync(a)
                                   .GetAwaiter()
                                   .GetResult()
                                   .Description,
                            ListOpNo = ListOfDayRepTableForGroupDay.Where(x => x.CurrentDayRepAcrID == a).Select(x => x.OpNumber).ToList()
                        });
                    }
                }


                viewModelPrinting.Add(singleMod);
                singleMod = null;
            };
            return viewModelPrinting;
        }
    }
}
