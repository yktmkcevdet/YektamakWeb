using BlazorApp1.Features.Commands.Account.Login;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models;
using System.Data;
using ApiService;
using Utilities.Common;

namespace YektamakWeb
{
    public class ProgramConst
    {
        public static string NavMenuCssClass { get; set; } = "default-class";
        
        private readonly UserSession _userSession;
        /// <summary>
        /// Kendi firmamızın id'si
        /// </summary>
        public static int kendiFirmaId;

        public ProgramConst( UserSession userSession) 
        {
            _userSession = userSession;
        }

        public async Task<List<Menu>> AnaMenuList ()
        {
            DataSet dataSetGlobalData = ConvertHelper.JsonStringToDataSet(await WebMethods.GetAsyncMethod("GetGlobalData"));
            List<Menu> anaMenuList = new List<Menu>();
            foreach (DataRow dr in dataSetGlobalData.Tables[9].Select($"rolId={_userSession.rolId}"))
            {
                Menu menu = new();
                menu.Id = int.Parse(dr["Id"].ToString()??"");
                menu.ad = dr["ad"].ToString()??"";
                menu.icon = dr["icon"].ToString()??"";
                anaMenuList.Add(menu);
            }
            return anaMenuList;
        }
        public async Task<List<Yetki>> YetkiList()
        {
            DataSet dataSetGlobalData = ConvertHelper.JsonStringToDataSet(await WebMethods.GetAsyncMethod("GetGlobalData"));
            List<Yetki> yetkiList = new List<Yetki>();
            foreach (DataRow dr in dataSetGlobalData.Tables[10].Select($"rolId={_userSession.rolId}"))
            {
                Yetki yetki = new();
                yetki.yetkiId = int.Parse(dr["yetkiId"].ToString()??"");
                yetki.menu.Id = string.IsNullOrWhiteSpace(dr["menuId"].ToString()) ? 0 : int.Parse(dr["menuId"].ToString()??"");
                yetki.menu.ad = dr["menu"].ToString()??"";
                yetki.menu.icon = dr["Icon"].ToString()??"";
                yetki.ekran.ekranId = int.Parse(dr["ekranId"].ToString()??"");
                yetki.ekran.ekranAdi = dr["ekranAdi"].ToString()??"";
                yetki.ekran.formAdi = dr["formAdi"].ToString()??"";
                yetkiList.Add(yetki);
            }
            return yetkiList;
        }
        public List<Proje> Projes()
        {
            Proje proje = new();
            proje.personel.Id = Cache.kullanici.personel.Id;
            List<Proje> projeKod = new List<Proje>();
            string jsonString = WebMethods.GetProjeKodByUserId(proje);
            DataSet dataSet = ConvertHelper.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Proje proje1;
                proje1 = ConvertHelper.DataRowToModel<Proje>(dataRow);
                projeKod.Add(proje1);
            }
            return projeKod;
        }
        public List<ParcaGrup> ParcaGrup(ParcaGrup parcaGrup)
        {
            List<ParcaGrup> parcaGrups = new List<ParcaGrup>();
            string jsonString = WebMethods.GetParcaGrup(parcaGrup);
            DataSet dataSet = ConvertHelper.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                ParcaGrup parcaGrup1;
                parcaGrup1 = ConvertHelper.DataRowToModel<ParcaGrup>(dataRow);
                parcaGrups.Add(parcaGrup1);
            }
            return parcaGrups;
        }
        public List<MalzemeGrup> MalzemeGrup(MalzemeGrup malzemeGrup)
        {
            List<MalzemeGrup> malzemeGrups = new List<MalzemeGrup>();
            string jsonString = WebMethods.GetMalzemeGrup(malzemeGrup);
            DataSet dataSet = ConvertHelper.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                MalzemeGrup malzemeGrup1;
                malzemeGrup1 = ConvertHelper.DataRowToModel<MalzemeGrup>(dataRow);
                malzemeGrups.Add(malzemeGrup1);
            }
            return malzemeGrups;
        }
    }
}
