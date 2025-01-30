using ApiService;
using Models;
using Models.DTO;
using System.Data;

namespace Utilities.Common
{
    public class Cache
    {
        private static Kullanici _kullanici;
        public static Kullanici kullanici
        {
            get
            {
                if (_kullanici == null)
                {
                    _kullanici = new Kullanici();
                }
                return _kullanici;
            }
            set
            {
                _kullanici = ConvertHelper.DataRowToModel<Kullanici>(ConvertHelper.JsonStringToDataSet(WebMethods.GetKullanici(value)).Tables[0].Rows[0]);
            }
        }
        private static AnaMenu anaMenu
        {
            get
            {
                return new AnaMenu { rolId = kullanici.rolId };
            }
        }

        private static List<AnaMenu> _anaMenuList;
        public static List<AnaMenu> ananaMenuList
        {
            get
            {
                if (_anaMenuList == null)
                {
                    _anaMenuList = GetModelList(WebMethods.GetAnaMenu,anaMenu);
                }
                return _anaMenuList;
            }
        }
        private static Yetki yetki
        {
            get{ return new Yetki { rolId = kullanici.rolId }; }
        }
        private static List<Yetki> _yetkiList;
        public static List<Yetki> yetkiList
        {
            get
            {
                if (_yetkiList == null)
                {
                    _yetkiList = GetModelList(WebMethods.GetYetki, yetki);
                }
                return _yetkiList;
            }
        }

        private static List<ParcaGrup> _parcaGrups;
        public static List<ParcaGrup> parcaGrups
        {
            get
            {
                if (_parcaGrups == null)
                {
                    _parcaGrups = GetModelList(WebMethods.GetParcaGrup,new ParcaGrup());
                }
                return _parcaGrups;
            }
        }
        private static List<StokTip> _stokTip;
        public static List<StokTip> stokTip
        {
            get
            {
                if (_stokTip == null)
                {
                    _stokTip = GetModelList(WebMethods.GetStokTip,new StokTip());
                }
                return _stokTip;
            }
        }
        private static List<ProfilTip> _profilTip;
        public static List<ProfilTip> profilTip
        {
            get
            {
                if (_profilTip == null)
                {
                    _profilTip = GetModelList(WebMethods.GetProfilTip, new ProfilTip());
                }
                return _profilTip;
            }
        }
        private static List<OlcuBirim> _olcuBirim;
        public static List<OlcuBirim> olcuBirim
        {
            get
            {
                if (_olcuBirim == null)
                {
                    _olcuBirim = GetModelList(WebMethods.GetOlcuBirim, new OlcuBirim());
                }
                return _olcuBirim;
            }
        }
        private static List<MalzemeGrup> _malzemeGrup;
        public static List<MalzemeGrup> malzemeGrup
        {
            get
            {
                if (_malzemeGrup == null)
                {
                    _malzemeGrup = GetModelList(WebMethods.GetMalzemeGrup, new MalzemeGrup());
                }
                return _malzemeGrup;
            }
        }
        private static List<MalzemeStandart> _malzemeStandart;
        public static List<MalzemeStandart> malzemeStandart
        {
            get
            {
                if (_malzemeStandart == null)
                {
                    _malzemeStandart = GetModelList(WebMethods.GetMalzemeStandart, new MalzemeStandart());
                }
                return _malzemeStandart;
            }
        }
        private static List<Proje> _proje;
        public static List<Proje> proje
        {
            get
            {
                if (_proje == null)
                {
                    _proje = GetModelList(WebMethods.GetProje,new Proje()).Where(x=>x.personel.Id==kullanici.personel.Id).ToList();
                }
                return _proje;
            }
        }
        private static List<Sektor> _sektorList;
        public static List<Sektor> sektorList
        {
            get
            {
                if (_sektorList == null)
                {
                    _sektorList = GetModelList(WebMethods.GetSektor, new Sektor());
                }
                return _sektorList;
            }
        }
        public static List<T> GetModelList<T>(Func<T,string> fetchFunction, T t) where T : IEntity, new()
        {
            DataTable dataTable = ConvertHelper.JsonStringToDataSet(fetchFunction.Invoke(t)).Tables[0];
            List<T> list = ConvertHelper.ToList<T>(dataTable.AsEnumerable().ToList());
            return list;
        }
    }
}
