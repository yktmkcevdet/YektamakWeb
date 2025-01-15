namespace Models
{
    [Serializable]
    public class SatisProje:IEntity
    {
        public int projeId;
        private Proje _projeKod;
        public Proje projeKod 
        { 
            get
            {
                if (_projeKod == null)
                {
                    _projeKod = new Proje();
                }
                return _projeKod;
            }
            set
            {
                _projeKod = value;
            }
        }
        public string projeAd;
        public string projeAciklama;
        private Firma _musteri;
        public Firma musteri 
        { 
            get
            {
                if (_musteri == null)
                {
                    _musteri = new Firma();
                }
                return _musteri;
            }
            set 
            {
                _musteri = value; 
            }
        }
        private List<ProjeSafha> _projeSafhalar;
        public List<ProjeSafha> projeSafhalar { get { if (_projeSafhalar == null) { _projeSafhalar = new List<ProjeSafha>();  } return _projeSafhalar; } set{ _projeSafhalar = value; }  }
        
        private Personel _satisSorumlusu;
        public Personel satisSorumlusu
        {
            get
            {
                if (_satisSorumlusu == null)
                {
                    _satisSorumlusu = new Personel();
                }
                return _satisSorumlusu;
            }
            set
            {
                _satisSorumlusu= value;
            }
        }
    }
}
