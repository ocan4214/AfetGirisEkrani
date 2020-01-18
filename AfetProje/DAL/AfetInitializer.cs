using AfetProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfetProje.DAL
{
    public class AfetInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AfetContext>
    {
        protected override void Seed(AfetContext context)
        {
            var Afets = new List<Afet>
            {
                new Afet{ID ="1",GlideNo = "1",FirstSeen=DateTime.Parse("2002-09-11"),
                    LastSeen = DateTime.Parse("2002-09-12"), DaysLast = 0, Province ="Uzak",
                    Borough="ilce", Village="Koy", Neighborhood="Mahalle", BeldeMevki = "Yok", ReasonofDisaster="Kundak",
                    Latitude="98", Longitude="102", ReasonDetails = "Bilinmiyor", EffectedAreas="Bulunamadı", Source = " Sigara",Status = ApprovalStatus.Pending },

                 new Afet{ID ="2",GlideNo = "2",FirstSeen=DateTime.Parse("2005-09-11"),
                    LastSeen = DateTime.Parse("2005-09-13"), DaysLast = 0, Province ="Uzak",
                    Borough="ilce", Village="Koy", Neighborhood="Mahalle", BeldeMevki = "Yok", ReasonofDisaster="Kundak",
                    Latitude="98", Longitude="102", ReasonDetails = "Bilinmiyor", EffectedAreas="Bulunamadı", Source = " Sigara",Status = ApprovalStatus.Pending }


            };


            Afets.ForEach(a => context.Afets.Add(a));
            context.SaveChanges();




        }

    }
}