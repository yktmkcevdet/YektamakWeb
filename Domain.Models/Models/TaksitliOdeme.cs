namespace Models
{
    public class TaksitliOdeme
    {
        /// <summary>
        /// TaksitliOdeme tablosu primaryKey
        /// </summary>
        public int taksitliOdemeId;
        public Tutar toplamTutar;
        public Firma banka;
        public Tutar kalanTutar;
        public Tutar gecikmedekiTutar;
        public CariKart cari;
        public TaksitliOdemeTuru taksitliOdemeTuru;
        public string odemeTanimi;
        public DateTime islemTarihi;
    }
    public class TaksitOdemesi:IEntity
    {
        /// <summary>
        /// veri tabanındaki primaryKey
        /// </summary>
        public int taksitOdemesiId;
        private Tutar _tutar;
        public Tutar tutar { get { if (_tutar==null) { _tutar = new(); } return _tutar; }set { _tutar = value; } }
        public DateTime sonOdemeTarihi;
        public DateTime odemeGerceklesenTarih;
        public bool odendiMi;
        /// <summary>
        /// TaksitliOdeme tablosundaki primaryKey TaksitOdeme tablosunda ForeignKey olarak referans verilecek
        /// </summary>
        public int taksitliOdemeId;
        /// <summary>
        /// Taksit numarası
        /// </summary>
        public int taksitNo;
        public string aciklama;

    }
    public class TaksitliOdemeFiltre
    {
        /// <summary>
        /// TaksitliOdeme tablosu primaryKey
        /// </summary>
        public int taksitliOdemeId;
        public Tutar toplamTutar;
        public Firma banka;
        public Tutar kalanTutar;
        public Tutar gecikmedekiTutar;
        public CariKart cari;
        public TaksitliOdemeTuru taksitliOdemeTuru;
        public string odemeTanimi;
        public DateTime? baslangicIslemTarihi;
        public DateTime? bitisIslemTarihi;
    }

    public enum TaksitliOdemeTuru
    {
        KREDI = 1,
        KREDIKARTI = 2
    }
}
