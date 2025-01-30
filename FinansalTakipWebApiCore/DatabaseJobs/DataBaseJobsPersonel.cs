using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Api.Business;

namespace Api.DatabaseJobs
{
    public static partial class DataBaseJobsPersonel
    {
        public static string SavePersonel(Personel personel)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(personel, "spSavePersonel");
        }
        public static string DeletePersonel(Personel personel)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(personel, "spDeletePersonel");
        }
        public static string GetPersonel(Personel personel)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(personel, "spGetPersonel");
        }
        public static string GetPersonelResim(PersonelResim personelResim)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(personelResim, "spGetPersonelResim");
        }
        public static string GetPersonelAndPicture(Personel personel)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(personel, "spGetPersonelAndPicture");
        }
    }
}