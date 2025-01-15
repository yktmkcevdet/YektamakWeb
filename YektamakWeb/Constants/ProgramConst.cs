using BlazorApp1.Features.Commands.Account.Login;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models;
using System.Data;
using Requests;
using Utilities;
using System.Collections.Generic;

namespace YektamakWeb
{
    public class ProgramConst
    {
        public static string NavMenuCssClass { get; set; } = "default-class";
        private readonly IConfiguration _configuration;
        
        private readonly ProtectedLocalStorage _localStorage;
        private readonly UserSession _userSession;

        /// <summary>
        /// Kendi firmamızın id'si
        /// </summary>
        public static int kendiFirmaId;

        public ProgramConst(IConfiguration configuration, ProtectedLocalStorage localStorage, UserSession userSession)
        {
            _configuration = configuration;
            _localStorage = localStorage;
            _userSession = userSession;
        }
        
        public async Task<List<Menu>> AnaMenuList ()
        {
            DataSet dataSetGlobalData = GlobalData.JsonStringToDataSet(await WebMethods.GetAsyncMethod("GetGlobalData"));
            List<Menu> anaMenuList = new List<Menu>();
            foreach (DataRow dr in dataSetGlobalData.Tables[9].Select($"rolId={_userSession.rolId}"))
            {
                Menu menu = new();
                menu.menuId = int.Parse(dr["menuId"].ToString()??"");
                menu.menuAdi = dr["menu"].ToString()??"";
                menu.icon = dr["Icon"].ToString()??"";
                anaMenuList.Add(menu);
            }
            return anaMenuList;
        }
        public async Task<List<Yetki>> YetkiList()
        {
            DataSet dataSetGlobalData = GlobalData.JsonStringToDataSet(await WebMethods.GetAsyncMethod("GetGlobalData"));
            List<Yetki> yetkiList = new List<Yetki>();
            foreach (DataRow dr in dataSetGlobalData.Tables[10].Select($"rolId={_userSession.rolId}"))
            {
                Yetki yetki = new();
                yetki.yetkiId = int.Parse(dr["yetkiId"].ToString()??"");
                yetki.menu.menuId = string.IsNullOrWhiteSpace(dr["menuId"].ToString()) ? 0 : int.Parse(dr["menuId"].ToString()??"");
                yetki.menu.menuAdi = dr["menu"].ToString()??"";
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
            proje.kullanici.Id = _userSession.Id;
            List<Proje> projeKod = new List<Proje>();
            string jsonString = WebMethods.GetProjeKodByUserId(proje);
            DataSet dataSet = GlobalData.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                Proje proje1;
                proje1 = GlobalData.DataRowToModel<Proje>(dataRow);
                projeKod.Add(proje1);
            }
            return projeKod;
        }
        public List<ParcaGrup> ParcaGrup()
        {
            ParcaGrup parcaGrup= new();
            List<ParcaGrup> parcaGrups = new List<ParcaGrup>();
            string jsonString = WebMethods.GetParcaGrup(parcaGrup);
            DataSet dataSet = GlobalData.JsonStringToDataSet(jsonString);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                ParcaGrup parcaGrup1;
                parcaGrup1 = GlobalData.DataRowToModel<ParcaGrup>(dataRow);
                parcaGrups.Add(parcaGrup1);
            }
            return parcaGrups;
        }
    }
}
