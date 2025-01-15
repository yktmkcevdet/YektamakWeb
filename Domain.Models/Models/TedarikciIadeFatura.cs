namespace Models
{
    public class TedarikciIadeFatura
    {
        public int tedarikciIadeFaturaId;
        public string tedarikciIadeFaturaNo;
        private Proje _projeKod;
        public Proje projeKod { get { if (_projeKod == null) { _projeKod = new Proje(); } return _projeKod; } set { _projeKod = value; } }
        private CariKart _cariKart;
        public CariKart cariKart { get { if (_cariKart == null) { _cariKart = new CariKart(); } return _cariKart;} set { _cariKart = value; } }
        public DateTime tedarikciIadeFaturaTarihi;
        private Tutar _tutar;
        public Tutar tedarikciIadeFaturaTutari { get { if (_tutar == null) { _tutar = new Tutar(); } return _tutar; } set { _tutar = value; } }
        private KDV _kdv;
        public KDV kdv { get { if (_kdv == null) { _kdv = new KDV(); } return _kdv; } set { _kdv = value; } }
    }
}
