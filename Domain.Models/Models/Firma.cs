namespace Models
{
    [Serializable]
    public class Firma:Cari,IEntity
    {
        private int _id;
        public int id { get { return _id; } set { base.Id = value;_id = value; } }
        
        public string unvan;
        private Adres _adres;
        public Adres adres { get { if (_adres == null) { _adres = new(); } return _adres; } set { _adres = value; } }
        public string vergiDairesi;
        public string vergiNumarasi;
        private List<Sektor> _sektorIdList;
        public List<Sektor> sektorIdList { get { if (_sektorIdList == null) { _sektorIdList = new(); } return _sektorIdList; } set { _sektorIdList = value; } }
        private List<BankaHesabi> _bankaHesabiList;
        public List<BankaHesabi> bankaHesabiList { get { if (_bankaHesabiList == null) { _bankaHesabiList = new(); } return _bankaHesabiList; } set { _bankaHesabiList = value; } }
        private List<Personel> _yetkiliList;
        public List<Personel> yetkiliList { get { if (_yetkiliList == null) { _yetkiliList = new(); } return _yetkiliList; } set { _yetkiliList = value; } }
        public string telefon;
        public string faks;
        public string mail;


        public Firma()  
        {
            base.cariTuru = CariTuru.FIRMA;
            base.Id = id;
        }
    }

    [Serializable]
    public class Adres:IEntity
    {
        public string ulke;
        public string sehir;
        public string postaKodu;
        public string acikAdres;
    }

}
