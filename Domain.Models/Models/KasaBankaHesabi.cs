namespace Models
{
    public class KasaBankaHesabi : IKasa
    {
        private Tutar _tutar;
        private DateTime _sonGuncellenmeTarihi;
        public string IBAN;
        public DovizCinsi dovizCinsi;
        public Firma banka;

        public BankaHesabi bankaHesabi { get; set;}
        public int kasaId { get { return this.bankaHesabi.hesapId; } set { this.bankaHesabi.hesapId = value; } }
        public string kasaAdi { get { return this.bankaHesabi.hesapAdi; } set { this.bankaHesabi.hesapAdi= value; } }
        public DateTime sonGuncellenmeTarihi { get { return this._sonGuncellenmeTarihi; } set { this._sonGuncellenmeTarihi = value; } }

        public KasaTuru kasaTuru { get; set; }

        public Tutar bakiye { get { return this._tutar; } set { this._tutar = value; } }
    }
}
