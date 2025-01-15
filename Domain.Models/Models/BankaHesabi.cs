namespace Models
{
    public class BankaHesabi:IEntity
    {
        public int hesapId;
        public string hesapAdi;
        public string IBAN;
        private DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi { get { if (_dovizCinsi == null) { _dovizCinsi = new(); } return _dovizCinsi; } set { _dovizCinsi = value; } }
        private Firma _firma;
        public Firma firma { get { if (_firma == null) { _firma = new(); } return _firma; } set { _firma = value; } }
        private Firma _banka;
        public Firma banka { get { if (_banka == null) { _banka = new(); } return _banka; } set { _banka = value; } }
    }
}
