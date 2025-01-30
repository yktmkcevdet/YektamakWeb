using System.Text.RegularExpressions;

namespace Models
{
    [Serializable]
    public class StokKart:IEntity
    {
        /// <summary>
        /// bu alan sanal olarak seçim yapmak için oluşturuldu, veritabanında bir karşılığı yok.
        /// </summary>
        public bool? sec;
        public int Id;
        public string kod;
        public string ad;
        public string boyut;
        public double uzunluk;
        public string aciklama;
        public double agirlik;
        public int miktar;
        public string malzeme;
        public string parcaAdi;
        public int adet;
        public int fark;
        private StokTip _stokTip;
        public StokTip stokTip { get { if (_stokTip == null) { _stokTip = new StokTip(); } return _stokTip; } set { _stokTip = value; } }
        public int profilTipId;
        public bool? isPdf;
        public bool? isDxf;
        public bool? isStep;
        public bool? isSatinalma;
        public bool? isFromExcel;
        private OlcuBirim _olcuBirim;
        public OlcuBirim olcuBirim { get { if (_olcuBirim == null) { _olcuBirim = new OlcuBirim(); } return _olcuBirim; } set { _olcuBirim = value; } }
        private ParcaGrup _parcaGrup;
        public ParcaGrup parcaGrup{get{if (_parcaGrup == null){_parcaGrup = new ParcaGrup();}return _parcaGrup;}set { _parcaGrup = value; } }
        private ParcaAltGrup _parcaAltgrup;
        public ParcaAltGrup parcaAltGrup{get{if ( _parcaAltgrup == null){_parcaAltgrup=new ParcaAltGrup();}return _parcaAltgrup;}set { _parcaAltgrup = value; } }
        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup { get { if (_malzemeGrup == null) { _malzemeGrup = new MalzemeGrup(); } return _malzemeGrup; } set { _malzemeGrup = value; } }
        private MalzemeStandart _malzemeStandart;
        public MalzemeStandart malzemeStandart { get { if (_malzemeStandart == null) { _malzemeStandart = new MalzemeStandart(); } return _malzemeStandart; } set { _malzemeStandart = value; } }
        public byte[] pdf;
        public byte[] step;
        public byte[] dxf;
        private Proje _proje;
        public Proje proje { get { if (_proje == null) _proje = new Proje(); return _proje; } set { _proje = value; } }
        public string pdfFileName() { return kod + ".pdf"; }
        public string dxfFileName()
        {   
            string dxfAd = kod + "_" + malzeme + "_" + dxfAddition() + adet + "adet" + ".dxf";
            return dxfAd;
        }
        public string stepFileName() { return kod + ".step"; }
        public string dxfAddition() 
        {
            string pattern = @"\b(\d+)\.\d+\b"; // Sayısal kısmı yakalayan desen

            // Regex ile eşleşmeyi bul
            Match match = Regex.Match(boyut, pattern);
            if (match.Success)
            {
                string result = match.Groups[1].Value+"mm_"; // Tam sayı kısmını al
                return result;
            }
            return ""; 
        }
    }
    public class ParcaGrup:IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }
    public class ParcaAltGrup:IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }
    public class StokTip : IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }
    public class ProfilTip : IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }
    public class MalzemeStandart : IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }

}
