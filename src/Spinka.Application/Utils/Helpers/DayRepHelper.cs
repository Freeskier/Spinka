using Spinka.Application.DayReps.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Spinka.Application.Utils.Helpers
{
    public static class DayRepHelper
    {
        public static int? Count (List<DayRep_RepDBReturnSingle> model , string corpus, List<int?> listOfvar,bool delegated, bool CurrentDay )
        {
        int? result = 0;
            if (CurrentDay)
            {
                if (corpus == "*")
                {
                    result = model.Where(x => x.Corpus != "c" && x.Corpus != "d"  && listOfvar.Contains(x.CurrentDayRepAcrID)).Select(x => x.PersonInGroupID).Count();

                }
                else if(corpus=="**")
                {
                    result = model.Where(x=> listOfvar.Contains(x.CurrentDayRepAcrID)).Select(x => x.PersonInGroupID).Count();
                }
                else
                {
                    result = model.Where(x => x.Corpus == corpus && listOfvar.Contains(x.CurrentDayRepAcrID) && x.IsDelegated==delegated).Select(x => x.PersonInGroupID).Count();
                }
              
            }
            else
            {
                if (corpus == "*")
                {
                    result = model.Where(x => x.Corpus != "c" && x.Corpus != "d" && listOfvar.Contains(x.PrevDayRepAcrID)).Select(x => x.PersonInGroupID).Count();

                }
                else if (corpus == "**")
                {
                    result = model.Where(x => listOfvar.Contains(x.PrevDayRepAcrID)).Select(x => x.PersonInGroupID).Count();
                }
             
                else
                {
                    result = model.Where(x => x.Corpus == corpus && listOfvar.Contains(x.PrevDayRepAcrID) && x.IsDelegated==delegated).Select(x => x.PersonInGroupID).Count();
                }
              
            }


            //result = result == null ? 0 : result;
            return result;
        }
    }
}
