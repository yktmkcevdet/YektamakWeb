namespace Models
{
    [Serializable]
    public class StokKart:IEntity
    {
        public int Id;
        public string kod;
        public string ad;
        public string boyut;
        public string uzunluk;
        public string aciklama;
        public string agirlik;
        public string miktar;
        public bool? isPdf;
        public bool? isDxf;
        public bool? isStep;
        public bool? isSatinalma;
        private ParcaGrup _parcaGrup;
        public ParcaGrup parcaGrup{get{if (_parcaGrup == null){_parcaGrup = new ParcaGrup();}return _parcaGrup;}set { _parcaGrup = value; } }
        private ParcaAltGrup _parcaAltgrup;
        public ParcaAltGrup parcaAltGrup{get{if ( _parcaAltgrup == null){_parcaAltgrup=new ParcaAltGrup();}return _parcaAltgrup;}set { _parcaAltgrup = value; } }
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
