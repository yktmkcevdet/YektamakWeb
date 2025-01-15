namespace Models
{
    public class SatisFatura:IEntity
    {
        public int satisFaturaId;
        public string faturaNo;
        private SatisSiparis _satisSiparis;
        public SatisSiparis satisSiparis { get { if (_satisSiparis == null) { _satisSiparis = new(); } return _satisSiparis; } set { _satisSiparis = value; } }
    
        public DateTime faturaTarihi;
        private Tutar _tutar;
        public Tutar tutar { get { if (_tutar == null) { _tutar = new(); } return _tutar; } set { _tutar = value; } }
        private CariKart _cariKart;
        public CariKart cariKart { get { if (_cariKart == null) { _cariKart = new(); } return _cariKart; } set { _cariKart = value; } }
        public float faturalandirilmamisTutar;
    }
}
