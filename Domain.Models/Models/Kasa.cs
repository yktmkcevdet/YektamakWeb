

namespace Models
{
    public class Kasa : IKasa,IEntity
    {
        public int kasaId;
        public DateTime sonGuncellemeTarihi;

        public string kasaAdi;
        private Tutar _bakiye;
        public Tutar bakiye { get { if (_bakiye == null) { _bakiye = new(); } return _bakiye; } set { _bakiye = value; } }
        private KasaTuru _kasaTuru;
        public KasaTuru kasaTuru { get => _kasaTuru; set => _kasaTuru = value; }
        private BankaHesabi _bankaHesabi;
        public BankaHesabi bankaHesabi { get { if (_bankaHesabi == null) { _bankaHesabi = new(); } return _bankaHesabi; } set { _bankaHesabi = value; } }
    }
    /// <summary>
    /// IKasa interface'i para saklanan banka hesabı, nakit kasa gibi türeleri ortak bir interface'le kullanımı için yapılmıştır.
    /// </summary>
    public interface IKasa
    {
        /// <summary>
        /// BankaHesabi için hesapId, Kasa için kasaId değeri dönecek. IKasa interface'ini uygulayan türlerde çakışık id'ler olabilir
        /// Bu değer her türün kendi tablosundaki unique id değeri olacaktır. kasaTuru'ne göre ayrışma olacaktır.
        /// </summary>
        Tutar bakiye { get; set; }
        KasaTuru kasaTuru { get; set; }
        BankaHesabi bankaHesabi{ get; set; }
    }

    public enum KasaTuru
    {
        BANKAHESABI = 1,
        NAKITKASA = 2
    }
}
