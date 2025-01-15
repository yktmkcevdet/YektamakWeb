namespace Models
{
    public class KrediKarti:IEntity
    {
        public int krediKartiId;
        public string kartSahibi;
        public string kartNumarasi;
        public BankaHesabi _bagliHesap;
        public BankaHesabi bagliHesap
        {
            get
            {
                if(_bagliHesap == null) _bagliHesap = new BankaHesabi();
                return _bagliHesap;
            }
            set
            {
                _bagliHesap= value; 
            }
        }
        public DovizCinsi _dovizCinsi;
        public DovizCinsi dovizCinsi
        {
            get
            {
                if (_dovizCinsi == null)
                {
                    _dovizCinsi= new DovizCinsi();
                }
                return _dovizCinsi;
            }
            set
            {
                _dovizCinsi= value;
            }
        }
        public DateTime hesapKesimTarihi;
        public DateTime sonOdemeTarihi;
        public DateTime sonKullanmaTarihi;
        public float kartLimiti;
        public float guncelKartLimiti;
        public float ekstreBorcu;
    }
}
