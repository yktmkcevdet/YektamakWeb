namespace Models
{
    [Serializable]
    public class Personel:Cari,IEntity
    {
        private int _personelId;
        public int personelId
        { get { return _personelId; } set { _personelId = value;base.Id = value; } }
        public string ad;
        public string soyad;
        public string telefon;//Daha sonra property içinde formatlama kuralları yazılacak +xx(xxx)xxxxxxx gibi
        public string mail;//Daha sonra property içinde formatlama kuralları yazılacak ****@***.com** gibi
        public string pozisyon;
        private Firma _firma;
        public Firma firma { get { if(_firma == null){ _firma = new(); } return _firma; } set { _firma = value; } }
        private PersonelResim _personelResim;
        public PersonelResim personelResim { get { if (_personelResim == null) { _personelResim = new(); } return _personelResim; } set { _personelResim = value; } }

        public Personel()
        {
            base.cariTuru = CariTuru.PERSONEL;
            base.Id = personelId;
        }
        
    }

    [Serializable]
    public class PersonelResim:IEntity
    {
        public int id;
        public int personelId;
        public byte[] resimData;
        public string imageFormat;
    }

    [Serializable]
    public class CariPersonel
    {
        public Personel personel;
    }
}
