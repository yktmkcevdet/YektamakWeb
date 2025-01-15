namespace Models
{
    public class SatinalmaFatura:IEntity
    {
        public int satinalmaFaturaId;
        public string faturaNo;
        private List<SatinalmaSiparis> _siparisIdList;
        public List<SatinalmaSiparis> siparisIdList { get { if (_siparisIdList == null) { _siparisIdList = new List<SatinalmaSiparis>(); } return _siparisIdList; } set { _siparisIdList = value; } }//Veritabanında json olarak tutulacak        
        public DateTime faturaTarihi; 
        public DateTime faturaTarihiFirst;
        private Tutar _tutar;
        /// <summary>
        /// siparisNo property'si atandığında otomatik gelmeli. Farklı bir tutar girilirse fark sebebi de istenmeli (arayüzde ayarlanacak)
        /// </summary>
        public Tutar tutar
        {
            get { if (_tutar == null) _tutar = new Tutar(); return _tutar; }
            set { _tutar = value; }
        }
        private KDV _kdv;
        public KDV kdv
        {
            get { if (_kdv == null) _kdv = new KDV(); return _kdv; }
            set { _kdv = value; }
        }
        public string siparisVeFaturaArasindakiFarkSebebi;
        private CariKart _cariKart;
        public CariKart cariKart
        {
            get { if (_cariKart == null) _cariKart = new CariKart(); return _cariKart; }
            set { _cariKart = value; }
        }
        private FaturaResim _faturaResim;
        public FaturaResim faturaResim
        {
            get { if (_faturaResim == null) _faturaResim = new FaturaResim(); return _faturaResim; }
            set { _faturaResim = value; }
        }
        public GiderTuru _giderTuru;
        public GiderTuru giderTuru{ get { if (_giderTuru == null) { _giderTuru = new GiderTuru(); } return _giderTuru; } set { _giderTuru = value; } }
        private Tevkifat _tevkifat;
        public Tevkifat tevkifat { get { if (_tevkifat == null) { _tevkifat = new Tevkifat(); } return _tevkifat; } set { _tevkifat = value; } }
    }

    [Serializable]
    public class FaturaResim
    {
        public int id;
        public byte[] resimData;
        public int satinalmaFaturaId;
        public string imageFormat;
    }
    public class Tevkifat
    {
        public int tevkifatId;
        public float tevkifatOrani;
        public string tevkifatAciklama;
    }
}
