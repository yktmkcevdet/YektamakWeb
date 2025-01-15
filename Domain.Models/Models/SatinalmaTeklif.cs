namespace Models
{
    public class SatinalmaTeklifBaslik
    {
        public int teklifId;
        public DateTime teklifTalepTarihi;
        public Firma _teklifFirma;
        public Firma teklifFirma
        {
            get
            {
                if (_teklifFirma == null)
                {
                    _teklifFirma= new Firma();
                }
                return _teklifFirma;  
            }
            set
            {
                _teklifFirma = value;
            }
        }
        public DateTime teklifTarihi;
        public Tutar _teklifTutar;
        public Tutar teklifTutar
        {
            get
            {
                if(_teklifTutar == null)
                {
                    _teklifTutar=new Tutar();
                }
                return _teklifTutar;
            }
            set
            {
                _teklifTutar = value;
            }
        }
        public int teklifGecerlilikSuresi;
        public int terminSuresi;
        public int vade;
        public string aciklama;
        public List<SatinalmaTeklifDetay> _satinalmaTeklifDetayList;
        public List<SatinalmaTeklifDetay> satinalmaTeklifDetayList
        {
            get
            {
                if(_satinalmaTeklifDetayList==null) _satinalmaTeklifDetayList=new List<SatinalmaTeklifDetay> ();
                return _satinalmaTeklifDetayList;
            }
            set
            {
                _satinalmaTeklifDetayList = value;
            }
        }
    }
    public class SatinalmaTeklifDetay
    {
        public int teklifDetayId;
        public int satinalmaTalepDetayId; 
        public Tutar tutar;
    }
}
