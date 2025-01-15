namespace Models
{
    /// <summary>
    /// Gerçek para transferinin temsili için kullanılır. Cari hesapları etkiler.
    /// </summary>
    public class CariOdeme:IEntity
    {
        public int cariOdemeId;
        private CariKart _cariKart;
        public CariKart cariKart { get { if (_cariKart == null) { _cariKart = new(); } return _cariKart; } set { _cariKart = value; } }

        private Tutar _tutar;
        public Tutar tutar { get { if (_tutar == null) { _tutar = new(); } return _tutar; } set { _tutar = value; } }
        /// <summary>
        /// Dövizli işlem karşılığı ödemelerde tutar karşılığı işlenecek dövizin karşılğını ifade eder.
        /// </summary>
        private Tutar _mahsupEdilenTutar;
        public Tutar mahsupEdilenTutar { get { if (_mahsupEdilenTutar == null) { _mahsupEdilenTutar = new(); } return _mahsupEdilenTutar; } set { _mahsupEdilenTutar = value; } }
        public DateTime odemeTarihi;
        public DateTime odemeTarihiFirst;
        public OdemeYonu odemeYonu { get; set; }
        public OdemeTuru odemeTuru { get; set; }
        public OdemeSekli odemeSekli { get; set; }
        /// <summary>
        /// Eğer çek ödemesi veya çekle ödeme ise Cek tablosundaki CekId
        /// </summary>
        private Cek _cek;
        public Cek cek {  get { if (_cek == null) { _cek = new(); } return _cek; } set { _cek = value; } }
        /// <summary>
        /// Eğer kredi kartı ödemesi ise KrediKarti tablosundaki KrediKartiId
        /// </summary>
        private KrediKarti _krediKarti;
        public KrediKarti krediKarti { get { if (_krediKarti == null) { _krediKarti = new(); } return _krediKarti; } set { _krediKarti = value; } }
        /// <summary>
        /// Eğer taksit ödemesi ise (kredi vb.) TaksitOdemesi tablosundaki TaksitOdemesiId
        /// </summary>
        private TaksitOdemesi _taksitOdemesi;
        public TaksitOdemesi taksitOdemesi { get { if (_taksitOdemesi == null) { _taksitOdemesi = new(); } return _taksitOdemesi; } set { _taksitOdemesi = value; } }
        /// <summary>
        /// Bizden başkasına veya kendi hesabımıza-kasamıza para transferi yapıyorsak paranın çıktığı hesap-kasa
        /// </summary>
        private Kasa _odemeninCiktigiKasa;
        public Kasa odemeninCiktigiKasa { get { if (_odemeninCiktigiKasa == null) { _odemeninCiktigiKasa = new(); } return _odemeninCiktigiKasa; } set { _odemeninCiktigiKasa = value; } }
        /// <summary>
        /// Bize başkasından veya kendi hesabımızdan-kasamızdan para transferi yapıyorsak paranın girdiği hesap-kasa
        /// </summary>
        private Kasa _odemeninGirdigiKasa;
        public Kasa odemeninGirdigiKasa { get { if (_odemeninGirdigiKasa == null) { _odemeninGirdigiKasa = new(); } return _odemeninGirdigiKasa; } set { _odemeninGirdigiKasa = value; } }
        /// <summary>
        /// Yapılan masrafların gruplandırılması için ödeme tanımı yapılmaktadır.
        /// </summary>
        private OdemeTanimi _odemeTanimi;
        public OdemeTanimi odemeTanimi { get { if (_odemeTanimi == null) { _odemeTanimi = new(); } return _odemeTanimi; } set { _odemeTanimi = value; } }
        /// <summary>
        /// Proje için yapılan gayrıresmi ödemeleri kayıt altına almak için.
        /// Siparişe dayalı faturalı ödemelerin proje kaydı siparişlerde oluyor.
        /// </summary>
        private Proje _projeKod;
        public Proje projeKod { get { if (_projeKod == null) { _projeKod = new(); } return _projeKod; } set { _projeKod = value; } }
        /// <summary>
        /// Eğer cari ödeme kaydı döviz işlemleri için yapılıyorsa 
        /// </summary>
        private DovizIslemi _dovizIslemi;
        public DovizIslemi dovizIslemi { get { if (_dovizIslemi == null) { _dovizIslemi = new(); } return _dovizIslemi; } set { _dovizIslemi = value; } }
        /// <summary>
        /// Virman hareketinde kullanılacak ödemenin yapıldığı hesabı temsil ediyor.
        /// </summary>
        private CariKart _odemeYapilanCariKart;
        public CariKart odemeYapilanCariKart { get { if (_odemeYapilanCariKart == null) { _odemeYapilanCariKart = new(); } return _odemeYapilanCariKart; } set { _odemeYapilanCariKart = value; } }
        public string aciklama;
    }

    /// <summary>
    /// Gelen Ödeme, Giden Ödeme, Virman
    /// </summary>
    public enum OdemeYonu
    {
        GELEN = 1,
        GIDEN = 2,
        KASAVIRMAN=3,
        HESAPVIRMAN=4,
    }
    /// <summary>
    /// Nakit, çek, havale, kredi kartı
    /// </summary>
    public enum OdemeSekli
    {
        NAKIT = 1,
        CEK = 2,
        CEKTAHSILAT = 3,
        KREDIKARTI = 4
    }
    /// <summary>
    /// Aynı döviz cinsinden, farklı döviz cinsinden
    /// </summary>
    public enum OdemeTuru
    {
        AyniDovizCinsinden = 1,
        FarkliDovizCinsinden = 2
    }
}
