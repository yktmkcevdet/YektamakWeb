namespace Models
{
    [Serializable]
    public class SatisSiparis:IEntity
    {
        /// <summary>
        /// SatisSiparis tablosu indeksi
        /// </summary>
        public int siparisId;
        public string siparisNo;
        private SatisProje _satisProje;
        public SatisProje satisProje { get { if (_satisProje == null) { _satisProje = new(); } return _satisProje; } set { _satisProje= value; } }
       
        public DateTime siparisTarihi;
        public DateTime siparisTarihiFirst;
        /// <summary>
        /// Gün sayısı olarak siparişten itibaren teslim süresi
        /// </summary>
        public int teslimVadesi;
        private Tutar _satisTutari;
        public Tutar satisTutari { get { if (_satisTutari == null) { _satisTutari = new(); } return _satisTutari; } set { _satisTutari = value; } }

        private Tutar _ongoruMaliyeti;
        public Tutar ongoruMaliyeti { get { if (_ongoruMaliyeti == null) { _ongoruMaliyeti = new(); } return _ongoruMaliyeti; } set { _ongoruMaliyeti = value; } }
        /// <summary>
        /// 0,1,8,18 değerleri alabilir
        /// </summary>
        private KDV _kdv;
        public KDV kdv { get { if (_kdv == null) { _kdv = new(); } return _kdv; } set { _kdv = value; } }
        private TahsilatPlani _tahsilatPlani;
        public TahsilatPlani tahsilatPlani { get { if (_tahsilatPlani == null) { _tahsilatPlani = new(); } return _tahsilatPlani; } set { _tahsilatPlani = value; } }
        /// <summary>
        /// TahsilatPlani tablosu indeksi
        /// </summary>
        public int tahsilatPlaniId;
    }
}
