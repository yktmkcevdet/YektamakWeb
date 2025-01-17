namespace Models
{
    [Serializable]
    public class StokKart:IEntity
    {
        public long Id;
        public string kod;
        public string ad;
        public string boyut;
        public double uzunluk;
        public string aciklama;
        public double agirlik;
        public int miktar;
        public string malzeme;
        public string parcaAdi;
        public int adet;
        public int fark;
        public int stokTipId;
        public int profilTipId;
        public bool? isPdf;
        public bool? isDxf;
        public bool? isStep;
        public bool? isSatinalma;
        public bool? isFromExcel;
        private OlcuBirim _olcuBirim;
        public OlcuBirim olcuBirim { get { if (_olcuBirim == null) { _olcuBirim = new OlcuBirim(); } return _olcuBirim; } set { _olcuBirim = value; } }
        private ParcaGrup _parcaGrup;
        public ParcaGrup parcaGrup{get{if (_parcaGrup == null){_parcaGrup = new ParcaGrup();}return _parcaGrup;}set { _parcaGrup = value; } }
        private ParcaAltGrup _parcaAltgrup;
        public ParcaAltGrup parcaAltGrup{get{if ( _parcaAltgrup == null){_parcaAltgrup=new ParcaAltGrup();}return _parcaAltgrup;}set { _parcaAltgrup = value; } }
        private MalzemeGrup _malzemeGrup;
        public MalzemeGrup malzemeGrup { get { if (_malzemeGrup == null) { _malzemeGrup = new MalzemeGrup(); } return _malzemeGrup; } set { _malzemeGrup = value; } }
        public byte[] pdf;
        public byte[] step;
        public byte[] dxf;
        private Proje _proje;
        public Proje proje { get { if (_proje == null) _proje = new Proje(); return _proje; } set { _proje = value; } }
    }
    public class ParcaGrup:IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }
    public class ParcaAltGrup:IEntity
    {
        public int Id;
        public string kod;
        public string ad;
    }

}
