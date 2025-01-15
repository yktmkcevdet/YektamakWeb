namespace Models
{
    public class SatinalmaSiparis:IEntity
    {
        public int satinalmaSiparisId;
        public string siparisNo;
        private Proje _projeKod;
        public Proje projeKod
        {
            get { if(_projeKod==null) _projeKod=new Proje(); return _projeKod; }
            set { _projeKod = value; }
        }
        private SatinalmaFatura _satinalmaFatura;
        public SatinalmaFatura satinalmaFatura { get { if (_satinalmaFatura == null) { _satinalmaFatura = new(); } return _satinalmaFatura; } set{ _satinalmaFatura = value; } }
        /// <summary>
        /// Gün sayısı olarak termin
        /// </summary>
        public int termin;
        private Tutar _avans;
        public Tutar avans 
        {
            get { if (_avans == null) _avans = new Tutar(); return _avans; }
            set { _avans = value; }
        }
        private Tutar _tutar;
        public Tutar tutar
        {
            get { if (_tutar == null) _tutar = new Tutar(); return _tutar; }
            set { _tutar = value; }
        }
        public DateTime siparisTarihi;
        public DateTime siparisTarihiFirst;

        public int vade;
        private Firma _firma;
        public Firma firma
        {
            get { if (_firma == null) _firma = new Firma(); return _firma; }
            set { _firma = value; }
        }
        public string siparisAciklamasi;
        private KDV _kdv;
        public KDV kdv { get { if (_kdv == null) { _kdv = new(); } return _kdv; } set { _kdv = value; } }
        public TalepTip _talepTip;
        public TalepTip talepTip
        {
            get
            {
                if (_talepTip == null)
                {
                    _talepTip = new TalepTip();
                }
                return _talepTip;
            }
            set
            {
                _talepTip = value;
            }
        }
        private List<SatinalmaSiparisDetay> _satinalmaSiparisDetayList;
        public List<SatinalmaSiparisDetay> satinalmaSiparisDetayList { get { if (_satinalmaSiparisDetayList == null) { _satinalmaSiparisDetayList = new(); } return _satinalmaSiparisDetayList; } set { _satinalmaSiparisDetayList = value; } }
    }
    public class SatinalmaSiparisDetay : IEntity
    {
        public int satinalmaSiparisDetayId;
        public int satinalmaSiparisId;
        public int stokKartId;
        public float miktar;
        public float birimFiyat;
        public int dovizCinsiId;
    }
}
